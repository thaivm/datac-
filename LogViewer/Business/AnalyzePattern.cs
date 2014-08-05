using System;
using System.Collections.Generic;
using System.Linq;
using LogViewer.Model;
using System.ComponentModel;
using System.Diagnostics;

namespace LogViewer.Business
{
    /// <summary>
    /// Class provides methods for analyzing pattern.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class AnalyzePattern<T> : IAnalyzePattern<T> where T : BaseLogRecord
    {
        /// <summary>
        /// Find records that matched with provided pattern by user.
        /// </summary>
        /// <param name="logRecordList">List of log record. T is generic log record class which can be <see cref="CCSLogRecord">CCSLogRecord</see> or <see cref="CXDILogRecord">CXDILogRecord</see>
        /// </param>
        /// <param name="patternItemSettings"></param>
        /// <param name="GetColumnContentValue"></param>
        /// <param name="AnalyzePatternWorker"></param>
        /// <returns></returns>
        public IList<AnalyzedPatternResultItem<T>> DoAnalyzePattern(IList<T> logRecordList, IList<PatternItemSetting> patternItemSettings, Func<T, string> GetColumnContentValue, System.ComponentModel.BackgroundWorker AnalyzePatternWorker = null)
        {
            var result = new List<AnalyzedPatternResultItem<T>>();

            var listRecord = new List<T>(logRecordList);

            
            foreach (var pattern in patternItemSettings)
            {
                var dicPatternResult = new Dictionary<PatternItemSetting, List<ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>>>();
                if (AnalyzePatternWorker != null && AnalyzePatternWorker.CancellationPending)
                {
                    //Stop analyze
                    result.Clear();
                    return result;
                }

                if (!pattern.Enabled) continue;

                var listDisplay = new List<ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>>(FindCageOfPattern(logRecordList, pattern, GetColumnContentValue, AnalyzePatternWorker));
                dicPatternResult.Add(pattern, listDisplay);

                var patternResult = new AnalyzedPatternResultItem<T>();
                patternResult.Name = pattern.Name;
                patternResult.PatternItem = pattern;
                //patternResult.
                StringLineIndexLevelPair<string, int, int, int, DateTime> root = null;
                foreach (var PatternResult in dicPatternResult)
                {
                    foreach (var pair in PatternResult.Value)
                    {
                        root = pair.Value;
                        var listKey = new List<KeyIndexRecordPair<int, string, int, T, string>>();
                        var cages = pair.Display.FindAll(x => x.IsPattern == true);
                        int i = 0;
                        foreach (var cage in cages)
                        {
                            var rnd = new Random();
                            ConfigValue.listColor.Sort((x, y) => x.CompareTo(y));
                            string hexColor = ConfigValue.listColor[i];
                            if (AnalyzePatternWorker != null && AnalyzePatternWorker.CancellationPending)
                            {
                                //Stop analyze
                                result.Clear();
                                return result;
                            }

                            foreach (var key in cage.elementOfCage)
                            {
                                T record = listRecord.SingleOrDefault(x => x.Line == key.Line);
                                var pairKeyIndex = new KeyIndexRecordPair<int, string, int, T, string>(key.Line, key.String, key.Index, record)
                                {
                                    Color = hexColor
                                };
                                listKey.Add(pairKeyIndex);
                            }
                            if (i == ConfigValue.listColor.Count - 1) i = 0;
                            i++;
                        }
                        T t = listRecord.SingleOrDefault(x => x.Line == root.Line);
                        if (!patternResult.RootKey.ContainsKey(t))
                        {
                            patternResult.RootKey.Add(t, new KeyIndexRecordPair<int, string, int, T, string>(root.Line, root.String, root.Index, null));
                        }
                        if (!patternResult.FoundPattern.ContainsKey(t))
                        {
                            if (listKey.Count != 0)
                                patternResult.FoundPattern.Add(t, listKey);
                        }
                    }
                }
                result.Add(patternResult);

            }
            return result;

        }

        // compare position
        private bool IsKey1AfterKey2(StringLineIndexLevelPair<string, int, int, int, DateTime> key1, StringLineIndexLevelPair<string, int, int, int, DateTime> key2)
        {
            if (key1.Line > key2.Line)
            {
                return true;
            }
            if (key1.Line == key2.Line && key1.Index > key2.Index)
            {
                return true;
            }
            return false;
        }

        // compare Date
        private bool CompareDateFollowRange(DateTime dateRoot, DateTime dateKey, double Range)
        {
            TimeSpan time = dateKey.Subtract(dateRoot);
            double miliSecond = time.TotalMilliseconds;
            return miliSecond <= Range;
        }

        // get millisecond of range
        private double GetRange(PatternItemSetting pattern)
        {
            var total = pattern.Time;
            var timeUnit = pattern.TimeUnit;
            double range = 0;
            if (timeUnit.Trim().Equals("H", StringComparison.OrdinalIgnoreCase))
            {
                range = total * 3600 * 1000;
            }
            if (timeUnit.Trim().Equals("M", StringComparison.OrdinalIgnoreCase))
            {
                range = total * 60 * 1000;
            }
            if (timeUnit.Trim().Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                range = total * 1000;
            }
            if (timeUnit.Trim().Equals("MS", StringComparison.OrdinalIgnoreCase))
            {
                range = total;
            }
            return range;
        }

        // check tag
        private bool CanTag(Cage cage, StringLineIndexLevelPair<string, int, int, int, DateTime> key, StringLineIndexLevelPair<string, int, int, int, DateTime> root, PatternItemSetting pattern)
        {
            if (!IsKey1AfterKey2(key, cage.elementOfCage[cage.elementOfCage.Count - 1]))
            {
                return false;
            }


            if (!CompareDateFollowRange(root.DateTime, key.DateTime, GetRange(pattern)))
            {
                return false;
            }

            if (cage.elementOfCage.Count == 1 && cage.elementOfCage[cage.elementOfCage.Count - 1].Level == -1)
            {
                return true;
            }

            //if (cage.elementOfCage[cage.elementOfCage.Count - 1].Level == key.Level)
            //{
            //    return true;
            //}

            if (cage.elementOfCage[cage.elementOfCage.Count - 1].Level + 1 == key.Level)
            {
                return true;
            }
            return false;
        }

        //check pattern
        private List<ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>> CheckPattern(List<ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>> listRootContainCage, int maxLevel)
        {
            foreach (var root in listRootContainCage)
            {
                //boolean IsExist = false;
                foreach (var cage in root.Display)
                {
                    if (cage.elementOfCage.Last().Level == maxLevel)
                    {
                        if (cage.elementOfCage.First().Level == -1)
                        {
                            cage.elementOfCage.Remove(cage.elementOfCage.First());
                        }

                        if (cage.elementOfCage.First().Level == 1)
                        {
                            //IsExist = true;
                            cage.IsPattern = true;
                        }
                        else
                        {
                            cage.IsPattern = false;
                        }

                        //else
                        //{
                        //    if (cage.elementofcage.last().level != maxlevel)
                        //    {
                        //        cage.ispattern = false;
                        //    }
                        //    else
                        //    {
                        //        if (isexist == true)
                        //        {
                        //            cage.ispattern = true;
                        //        }
                        //        else
                        //        {
                        //            cage.ispattern = false;
                        //        }
                        //    }
                        //}
                    }
                    else
                    {
                        cage.IsPattern = false;
                    }
                }
            }
            return listRootContainCage;
        }
        // end
        // function find all root key
        private List<ValueDisplayPair<string, int>> FindAllRoot(IList<T> logRecordList, List<PatternItemSetting> analyzePattermSettingList, Func<T, string> GetColumnContentValue)
        {
            var roots = new List<ValueDisplayPair<string, int>>();
            foreach (var record in logRecordList)
            {
                foreach (var pattern in analyzePattermSettingList)
                {
                    string content = GetColumnContentValue(record);
                    if (content.Contains(pattern.RootKey))
                    {
                        var cage = new ValueDisplayPair<string, int>();
                        cage.Value = pattern.RootKey;
                        cage.Display = record.Line;
                        roots.Add(cage);
                    }
                }
            }
            return roots;
        }
        // find all index of each root
        private List<StringLineIndexLevelPair<string, int, int, int, DateTime>> FindAllIndexOfRoot(IList<T> logRecordList, PatternItemSetting pattern, Func<T, string> GetColumnContentValue)
        {
            var roots = new List<StringLineIndexLevelPair<string, int, int, int, DateTime>>();
            foreach (var record in logRecordList)
            {
                string content = GetColumnContentValue(record);
                if (content.Contains(pattern.RootKey))
                {
                    var indexs = IndexOfAll(content, pattern.RootKey);
                    var dateTime = Convert.ToDateTime(String.Format("{0} {1}", record.Date, record.Time));
                    roots.AddRange(indexs.Select(index => new StringLineIndexLevelPair<string, int, int, int, DateTime>(pattern.RootKey, index, record.Line, 0, dateTime)));
                }

            }
            return roots;
        }
        //

        // find all key of each root
        private List<StringLineIndexLevelPair<string, int, int, int, DateTime>> FindAllKeyOfRoot(IList<T> logRecordList, PatternItemSetting pattern, Func<T, string> GetColumnContentValue)
        {
            var strings = new List<StringLineIndexLevelPair<string, int, int, int, DateTime>>();
            foreach (var record in logRecordList)
            {
                var i = 1;
                foreach (var key in pattern.Keys)
                {
                    string content = GetColumnContentValue(record);
                    if (content.Contains(key))
                    {
                        var indexs = IndexOfAll(content, key);
                        var dateTime = Convert.ToDateTime(String.Format("{0} {1}", record.Date, record.Time));
                        strings.AddRange(indexs.Select(index => new StringLineIndexLevelPair<string, int, int, int, DateTime>(key, index, record.Line, i, dateTime)));
                    }
                    i++;
                }
            }
            //List<StringLineIndexLevelPair<string, int, int, int>> temps = new List<StringLineIndexLevelPair<string, int, int, int>>(strings);
            //temps.OrderBy(x => x.Line).ThenBy(y => y.Index);

            return strings.OrderBy(x => x.Line).ThenBy(y => y.Index).ToList();
        }
        //end
        // index of sub string
        private static List<int> IndexOfAll(string str, string substr, bool ignoreCase = false)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(substr))
            {
                throw new ArgumentException("String or substring is not specified.");
            }

            var indexes = new List<int>();
            int index = 0;

            while ((index = str.IndexOf(substr, index, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal)) != -1)
            {
                indexes.Add(index++);
            }

            return indexes;
        }
        //end

        private List<ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>> FindCageOfPattern(IList<T> logRecordList, PatternItemSetting pattern, Func<T, string> GetColumnContentValue, BackgroundWorker AnalyzePatternWorker = null)
        {
            var maxLevel = pattern.Keys.Count;
            var roots = FindAllIndexOfRoot(logRecordList, pattern, GetColumnContentValue);
            var listRootContainCage = new List<ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>>();

            // init cage of each root
            foreach (var root in roots)
            {
                var cageOfRoot = new ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>();
                cageOfRoot.Value = root;
                cageOfRoot.Display = new List<Cage>();
                //Cage cage = new Cage();
                //CageOfRoot.Display.Add(cage)
                listRootContainCage.Add(cageOfRoot);
            }

            var listKey = FindAllKeyOfRoot(logRecordList, pattern, GetColumnContentValue);
            var first = listKey.FirstOrDefault();
            int indexOfKey = 0;
            foreach (var key in listKey)
            {
                if (AnalyzePatternWorker != null && AnalyzePatternWorker.CancellationPending)
                {
                    //Stop analyze
                    listRootContainCage.Clear();
                    return listRootContainCage;
                }
                foreach (var root in listRootContainCage)
                {
                    if (root.Display.FindAll(x => x.elementOfCage.Contains(key)).Count != 0)
                    {
                        break;
                    }
                    int count = root.Display == null ? 0 : root.Display.Count;
                    if (root.Display.Count == 0)
                    {
                        var cage = new Cage
                        {
                            elementOfCage = new List<StringLineIndexLevelPair<string, int, int, int, DateTime>>()
                        };
                        var dateTime = new DateTime();
                        var _string = new StringLineIndexLevelPair<string, int, int, int, DateTime>("", root.Value.Index, root.Value.Line, -1, dateTime);
                        cage.elementOfCage.Add(_string);
                        root.Display.Add(cage);
                        count = root.Display.Count;
                    }
                    for (var i = count - 1; i >= 0; i--)
                    {
                        if (!CompareDateFollowRange(root.Value.DateTime, key.DateTime, GetRange(pattern)))
                        {
                            break;
                        }
                        if (CanTag(root.Display[i], key, root.Value, pattern))
                        {
                            root.Display[i].elementOfCage.Add(key);
                            var temp = indexOfKey;
                            //while ((temp < listKey.Count -1) && (listKey[temp].Level == listKey[temp + 1].Level || listKey[temp].Level + 1 == listKey[temp + 1].Level) )
                            //{
                            //    if (temp < listKey.Count -1)
                            //    {
                            //        root.Display[i].elementOfCage.Add(listKey[temp + 1]);
                            //        temp++;
                            //    }
                            //}
                            break;
                        }
                        else
                        {
                            if (i != 0)
                            {
                                continue;
                            }

                            if (IsKey1AfterKey2(key, root.Display[i].elementOfCage[root.Display[i].elementOfCage.Count - 1]) && key.Level == 1)
                            {
                                var cage = new Cage
                                {
                                    elementOfCage =
                                        new List<StringLineIndexLevelPair<string, int, int, int, DateTime>> {key}
                                };
                                root.Display.Add(cage);
                                break;
                            }


                        }
                    }
                }
                indexOfKey++;
            }

            listRootContainCage = CheckPattern(listRootContainCage, maxLevel);
            
            foreach (var root in listRootContainCage)
            {
                root.Display = root.Display.FindAll(x => x.IsPattern == true);
            }
            return listRootContainCage;
        }
    }
}

