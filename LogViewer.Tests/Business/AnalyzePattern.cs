using System;
using System.ComponentModel;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using LogViewer.Business;
using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.Business
{
    [TestClass]
    public class AnalyzePatternTest
    {
        [TestMethod]
        public void CompareDateFollowRangeTest()
        {
            var target = new AnalyzePattern<CCSLogRecord>();
            PrivateObject po = new PrivateObject(target);
            var d1 = new DateTime();
            var d2 = d1.AddMilliseconds(100);
            double range = 100;

            var actual = po.Invoke("CompareDateFollowRange", new object[] { d1, d2, range });
            var expected = true;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetRangeTest()
        {
            var target = new AnalyzePattern<CCSLogRecord>();
            var po = new PrivateObject(target);
            var pattern = new PatternItemSetting { Time = 100, TimeUnit = "H" };

            var actual = po.Invoke("GetRange", new object[] { pattern });

            var expected = (double)100 * 3600 * 1000;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetRangeTest1()
        {
            var target = new AnalyzePattern<CCSLogRecord>();
            var po = new PrivateObject(target);
            var pattern = new PatternItemSetting { Time = 100, TimeUnit = "M" };

            var actual = po.Invoke("GetRange", new object[] { pattern });

            var expected = (double)100 * 60 * 1000;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetRangeTest2()
        {
            var target = new AnalyzePattern<CCSLogRecord>();
            var po = new PrivateObject(target);
            var pattern = new PatternItemSetting { Time = 100, TimeUnit = "S" };

            var actual = po.Invoke("GetRange", new object[] { pattern });

            var expected = (double)100 * 1000;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetRangeTest3()
        {
            var target = new AnalyzePattern<CCSLogRecord>();
            var po = new PrivateObject(target);
            var pattern = new PatternItemSetting { Time = 100, TimeUnit = "MS" };

            var actual = po.Invoke("GetRange", new object[] { pattern });

            var expected = (double)100;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IndexOfAllTest1()
        {
            var target = new AnalyzePattern<CCSLogRecord>();
            var po = new PrivateType(typeof(AnalyzePattern<CCSLogRecord>));
            string str = string.Empty;
            string subStr = string.Empty;
            bool ignoreCase = true;
            var actual = po.InvokeStatic("IndexOfAll", new object[] { str, subStr, ignoreCase });

        }
        [TestMethod]
        public void IndexOfAllTest2()
        {
            var target = new AnalyzePattern<CCSLogRecord>();
            var po = new PrivateType(typeof(AnalyzePattern<CCSLogRecord>));
            string str = "abc strang oc ifdaf fjos fosj outolhgg gho gds";
            string subStr = "ifdaf";
            bool ignoreCase = true;
            var expected = new List<int> { 14 };
            var actual = (List<int>)po.InvokeStatic("IndexOfAll", new object[] { str, subStr, ignoreCase });
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IndexOfAllTest3()
        {
            var target = new AnalyzePattern<CCSLogRecord>();
            var po = new PrivateType(typeof(AnalyzePattern<CCSLogRecord>));
            var str = "abc strang oc ifdaf fjos fosj outolhgg gho gds";
            var subStr = "xxx";
            var ignoreCase = true;
            var expected = new List<int> { };
            var actual = (List<int>)po.InvokeStatic("IndexOfAll", new object[] { str, subStr, ignoreCase });
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckPatternTest()
        {
            var target = new AnalyzePattern<CCSLogRecord>();
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var expected = new List<ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>>();
            var listRootContainCage = new
                List<ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>>();

            int maxLevel = 0;
            var actual = (List<ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>>)po.Invoke("CheckPattern", new object[] { listRootContainCage, maxLevel });
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void CheckPatternTest1()
        {
            var target = new AnalyzePattern<CCSLogRecord>();
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var element1 = new StringLineIndexLevelPair<string, int, int, int, DateTime>("abc", 3, 1, 1,
                DateTime.Parse("2014/10/10 10:10:10.100"));
            var element2 = new StringLineIndexLevelPair<string, int, int, int, DateTime>("xxx", 3, 2, 4,
                DateTime.Parse("2014/10/10 10:10:15.100"));
            var elementList = new List<StringLineIndexLevelPair<string, int, int, int, DateTime>> { element1, element2 };
            var listRootContainCage = new
                List<ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>>
            {
                new ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>
                {
                    Display = new List<Cage>
                    {
                        new Cage
                        {
                            IsPattern = true,
                            elementOfCage = elementList
                        }
                    },
                    Value = element1,
                },
                new ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>
                {
                    Display = new List<Cage>
                    {
                        new Cage
                        {
                            IsPattern = true,
                            elementOfCage = new List<StringLineIndexLevelPair<string, int, int, int, DateTime>>{element2}
                        }
                    },
                    Value = element2,
                }
            };
            var expected = listRootContainCage;

            int maxLevel = 4;
            var actual = (List<ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>>)
                po.Invoke("CheckPattern", new object[] { listRootContainCage, maxLevel });
            CollectionAssert.AreEqual(expected, actual);


        }
        [TestMethod]
        public void CheckPatternTest2()
        {
            var target = new AnalyzePattern<CCSLogRecord>();
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var element1 = new StringLineIndexLevelPair<string, int, int, int, DateTime>("abc", 3, 4, 1,
                DateTime.Parse("2014/10/10 10:10:10.100"));
            var element2 = new StringLineIndexLevelPair<string, int, int, int, DateTime>("xxx", 3, 2, 4,
                DateTime.Parse("2014/10/10 10:10:15.100"));
            var elementList = new List<StringLineIndexLevelPair<string, int, int, int, DateTime>> { element1, element2 };
            var listRootContainCage = new
                List<ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>>
            {
                new ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>
                {
                    Display = new List<Cage>
                    {
                        new Cage
                        {
                            IsPattern = true,
                            elementOfCage = elementList
                        }
                    },
                    Value = element1,
                },
                new ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>
                {
                    Display = new List<Cage>
                    {
                        new Cage
                        {
                            IsPattern = true,
                            elementOfCage = new List<StringLineIndexLevelPair<string, int, int, int, DateTime>>{element2}
                        }
                    },
                    Value = element2,
                }
            };
            var expected = listRootContainCage;

            int maxLevel = 4;
            var actual = (List<ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>>)
                po.Invoke("CheckPattern", new object[] { listRootContainCage, maxLevel });
            CollectionAssert.AreEqual(expected, actual);


        }
        [TestMethod]
        public void CheckPatternTest3()
        {
            var target = new AnalyzePattern<CCSLogRecord>();
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var element1 = new StringLineIndexLevelPair<string, int, int, int, DateTime>("abc", 3, 1, -1,
                DateTime.Parse("2014/10/10 10:10:10.100"));
            var element2 = new StringLineIndexLevelPair<string, int, int, int, DateTime>("xxx", 3, 4, 4,
                DateTime.Parse("2014/10/10 10:10:15.100"));
            var elementList = new List<StringLineIndexLevelPair<string, int, int, int, DateTime>> { element1, element2 };
            var listRootContainCage = new
                List<ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>>
            {
                new ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>
                {
                    Display = new List<Cage>
                    {
                        new Cage
                        {
                            IsPattern = true,
                            elementOfCage = elementList
                        }
                    },
                    Value = element1,
                },
                new ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>
                {
                    Display = new List<Cage>
                    {
                        new Cage
                        {
                            IsPattern = true,
                            elementOfCage = new List<StringLineIndexLevelPair<string, int, int, int, DateTime>>{element2}
                        }
                    },
                    Value = element2,
                }
            };
            var expected = listRootContainCage;

            int maxLevel = 4;
            var actual = (List<ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>>)
                po.Invoke("CheckPattern", new object[] { listRootContainCage, maxLevel });
            CollectionAssert.AreEqual(expected, actual);


        }
        [TestMethod]
        public void CheckPatternTest4()
        {
            var target = new AnalyzePattern<CCSLogRecord>();
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var element1 = new StringLineIndexLevelPair<string, int, int, int, DateTime>
                ("abc", 3, 1, -1, DateTime.Parse("2014/10/10 10:10:10.100"));
            var element2 = new StringLineIndexLevelPair<string, int, int, int, DateTime>
                ("xxx", 3, 4, 2, DateTime.Parse("2014/10/10 10:10:15.100"));
            var elementList = new List<StringLineIndexLevelPair<string, int, int, int, DateTime>> { element1, element2 };
            var listRootContainCage = new
                List<ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>>
            {
                new ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>
                {
                    Display = new List<Cage>
                    {
                        new Cage
                        {
                            IsPattern = true,
                            elementOfCage = elementList
                        }
                    },
                    Value = element1,
                },
                new ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>
                {
                    Display = new List<Cage>
                    {
                        new Cage
                        {
                            IsPattern = true,
                            elementOfCage = new List<StringLineIndexLevelPair<string, int, int, int, DateTime>>{element2}
                        }
                    },
                    Value = element2,
                }
            };
            var expected = listRootContainCage;

            int maxLevel = 4;
            var actual = (List<ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>>)
                po.Invoke("CheckPattern", new object[] { listRootContainCage, maxLevel });
            CollectionAssert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void CanTagTest()
        {
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var element1 = new StringLineIndexLevelPair<string, int, int, int, DateTime>
    ("abc", 3, 1, -1, DateTime.Parse("2014/10/10 10:10:10.100"));
            var element2 = new StringLineIndexLevelPair<string, int, int, int, DateTime>
                ("xxx", 3, 4, 2, DateTime.Parse("2014/10/10 10:10:15.100"));

            var root = element1;
            var key = element2;
            var cage = new Cage
            {
                IsPattern = true,
                elementOfCage = new List<StringLineIndexLevelPair<string, int, int, int, DateTime>> { element1 }
            };
            var pattern = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "ffff" },
                RootKey = "kkk"

            };
            var actual = (bool)
               po.Invoke("CanTag", new object[] { cage, key, root, pattern });
            var expected = true;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CanTagTest1()
        {
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var element1 = new StringLineIndexLevelPair<string, int, int, int, DateTime>
    ("abc", 3, 1, -1, DateTime.Parse("2014/10/10 10:10:10.100"));
            var element2 = new StringLineIndexLevelPair<string, int, int, int, DateTime>
                ("xxx", 3, 4, 2, DateTime.Parse("2014/10/10 10:10:15.100"));
            var element3 = new StringLineIndexLevelPair<string, int, int, int, DateTime>
                ("hhhh", 3, 4, 2, DateTime.Parse("2014/10/10 10:10:15.100"));

            var root = element1;
            var key = element2;
            var cage = new Cage
            {
                IsPattern = true,
                elementOfCage = new List<StringLineIndexLevelPair<string, int, int, int, DateTime>> { element3 }
            };
            var pattern = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "ffff" },
                RootKey = "kkk"

            };
            var actual = (bool)
               po.Invoke("CanTag", new object[] { cage, key, root, pattern });
            var expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CanTagTest2()
        {
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var element1 = new StringLineIndexLevelPair<string, int, int, int, DateTime>
    ("abc", 3, 1, -1, DateTime.Parse("2014/10/10 10:10:10.100"));
            var element2 = new StringLineIndexLevelPair<string, int, int, int, DateTime>
                ("xxx", 3, 4, 2, DateTime.Parse("2014/11/10 10:10:10.100"));
            var element3 = new StringLineIndexLevelPair<string, int, int, int, DateTime>
                ("hhhh", 3, 4, 2, DateTime.Parse("2014/10/10 10:10:15.100"));

            var root = element1;
            var key = element2;
            var cage = new Cage
            {
                IsPattern = true,
                elementOfCage = new List<StringLineIndexLevelPair<string, int, int, int, DateTime>> { element1 }
            };
            var pattern = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "ffff" },
                RootKey = "kkk"

            };
            var actual = (bool)
               po.Invoke("CanTag", new object[] { cage, key, root, pattern });
            var expected = false;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CanTagTest3()
        {
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var element1 = new StringLineIndexLevelPair<string, int, int, int, DateTime>
    ("abc", 3, 1, -1, DateTime.Parse("2014/10/10 10:10:10.100"));
            var element2 = new StringLineIndexLevelPair<string, int, int, int, DateTime>
                ("xxx", 3, 4, 2, DateTime.Parse("2014/10/10 10:10:15.100"));
            var element3 = new StringLineIndexLevelPair<string, int, int, int, DateTime>
                ("hhhh", 5, 4, 3, DateTime.Parse("2014/10/10 10:10:15.100"));

            var root = element1;
            var key = element3;
            var cage = new Cage
            {
                IsPattern = true,
                elementOfCage = new List<StringLineIndexLevelPair<string, int, int, int, DateTime>> { element1, element2 }
            };
            var pattern = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "ffff" },
                RootKey = "kkk"

            };
            var actual = (bool)
               po.Invoke("CanTag", new object[] { cage, key, root, pattern });
            var expected = true;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CanTagTest4()
        {
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var element1 = new StringLineIndexLevelPair<string, int, int, int, DateTime>
    ("abc", 3, 1, -1, DateTime.Parse("2014/10/10 10:10:10.100"));
            var element2 = new StringLineIndexLevelPair<string, int, int, int, DateTime>
                ("xxx", 3, 4, 2, DateTime.Parse("2014/10/10 10:10:15.100"));
            var element3 = new StringLineIndexLevelPair<string, int, int, int, DateTime>
                ("hhhh", 5, 4, 2, DateTime.Parse("2014/10/10 10:10:15.100"));

            var root = element1;
            var key = element3;
            var cage = new Cage
            {
                IsPattern = true,
                elementOfCage = new List<StringLineIndexLevelPair<string, int, int, int, DateTime>> { element1, element2 }
            };
            var pattern = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "ffff" },
                RootKey = "kkk"

            };
            var actual = (bool)
               po.Invoke("CanTag", new object[] { cage, key, root, pattern });
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindAllIndexOfRootTest()
        {
            var record1 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record2 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record3 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record4 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };

            IList<CCSLogRecord> logRecordList = new List<CCSLogRecord>();

            var pattern = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "ffff" },
                RootKey = "kkk"

            };
            Func<CCSLogRecord, string> GetColumnContentValue = record => record.Content;
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var actual = (List<StringLineIndexLevelPair<string, int, int, int, DateTime>>)
               po.Invoke("FindAllIndexOfRoot", new object[]
               {
                   logRecordList,pattern,GetColumnContentValue
               });
            var expected = new List<StringLineIndexLevelPair<string, int, int, int, DateTime>>();

            CollectionAssert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void FindAllIndexOfRootTest1()
        {
            var record1 = new CCSLogRecord
            {
                Id = "1",
                Content = "jo of dsabc ffff jfodsjofsd",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record2 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record3 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record4 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };

            IList<CCSLogRecord> logRecordList = new[] { record1, record2, record3, record4 };

            var pattern = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "fdsafds" },
                RootKey = "ffff"

            };
            Func<CCSLogRecord, string> GetColumnContentValue = record => record1.Content;
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var actual = (List<StringLineIndexLevelPair<string, int, int, int, DateTime>>)
               po.Invoke("FindAllIndexOfRoot", new object[]
               {
                   logRecordList,pattern,GetColumnContentValue
               });
            var expected = 4;

            Assert.AreEqual(expected, actual.Count);

        }

        [TestMethod]
        public void FindAllIndexOfRootTest2()
        {
            var record1 = new CCSLogRecord
            {
                Id = "1",
                Content = "jo of dsabc ffff jfodsjofsd",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record2 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record3 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record4 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };

            IList<CCSLogRecord> logRecordList = new[] { record1, record2, record3, record4 };

            var pattern = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "fdsafds" },
                RootKey = "ffff"

            };
            Func<CCSLogRecord, string> GetColumnContentValue = record => record1.Content;
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var actual = (List<StringLineIndexLevelPair<string, int, int, int, DateTime>>)
               po.Invoke("FindAllIndexOfRoot", new object[]
               {
                   logRecordList,pattern,GetColumnContentValue
               });
            var expected = 4;

            Assert.AreEqual(expected, actual.Count);

        }

        [TestMethod]
        public void FindAllKeyOfRootTest()
        {
            var record1 = new CCSLogRecord
            {
                Id = "1",
                Content = "jo of dsabc ffff jfodsjofsd",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record2 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record3 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record4 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };

            var logRecordList = new List<CCSLogRecord>();

            var pattern = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "fdsafds" },
                RootKey = "ffff"

            };
            Func<CCSLogRecord, string> GetColumnContentValue = record => record1.Content;
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var actual = (List<StringLineIndexLevelPair<string, int, int, int, DateTime>>)
               po.Invoke("FindAllKeyOfRoot", new object[]
               {
                   logRecordList,pattern,GetColumnContentValue
               });
            var expected = 0;

            Assert.AreEqual(expected, actual.Count);

        }
        [TestMethod]
        public void FindAllKeyOfRootTest1()
        {
            var record1 = new CCSLogRecord
            {
                Id = "1",
                Content = "jo of dsabc ffff jfodsjofsd",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record2 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record3 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record4 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };

            var logRecordList = new List<CCSLogRecord> { record1, record2, record3, record4 };

            var pattern = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string>(),
                RootKey = "ffff"

            };
            Func<CCSLogRecord, string> GetColumnContentValue = record => record1.Content;
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var actual = (List<StringLineIndexLevelPair<string, int, int, int, DateTime>>)
               po.Invoke("FindAllKeyOfRoot", new object[]
               {
                   logRecordList,pattern,GetColumnContentValue
               });
            var expected = 0;

            Assert.AreEqual(expected, actual.Count);

        }
        [TestMethod]
        public void FindAllKeyOfRootTest2()
        {
            var record1 = new CCSLogRecord
            {
                Id = "1",
                Content = "jo of dsabc ffff jfodsjofsd",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record2 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record3 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record4 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };

            var logRecordList = new List<CCSLogRecord> { record1, record2, record3, record4 };

            var pattern = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "ffff" },
                RootKey = "ffff"

            };
            Func<CCSLogRecord, string> GetColumnContentValue = record => record1.Content;
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var actual = (List<StringLineIndexLevelPair<string, int, int, int, DateTime>>)
               po.Invoke("FindAllKeyOfRoot", new object[]
               {
                   logRecordList,pattern,GetColumnContentValue
               });
            var expected = 4;

            Assert.AreEqual(expected, actual.Count);

        }
        [TestMethod]
        public void FindAllRootTest1()
        {
            var record1 = new CCSLogRecord
            {
                Id = "1",
                Content = "jo of dsabc ffff jfodsjofsd",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record2 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record3 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record4 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };

            var logRecordList = new List<CCSLogRecord> { };

            var pattern = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "ffff" },
                RootKey = "ffff"

            };
            var analyzePattermSettingList = new List<PatternItemSetting>
            {
                pattern

            };
            Func<CCSLogRecord, string> GetColumnContentValue = record => record1.Content;
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var actual = (List<ValueDisplayPair<string, int>>)
               po.Invoke("FindAllRoot", new object[]
               {
                   logRecordList,analyzePattermSettingList,GetColumnContentValue
               });
            var expected = 0;

            Assert.AreEqual(expected, actual.Count);

        }
        [TestMethod]
        public void FindAllRootTest2()
        {
            var record1 = new CCSLogRecord
            {
                Id = "1",
                Content = "jo of dsabc ffff jfodsjofsd",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record2 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record3 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record4 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };

            var logRecordList = new List<CCSLogRecord> { record1,record2,record3,record4};

            var pattern = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "ffff" },
                RootKey = "ffff"

            };
            var analyzePattermSettingList = new List<PatternItemSetting>
            {
                

            };
            Func<CCSLogRecord, string> GetColumnContentValue = record => record1.Content;
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var actual = (List<ValueDisplayPair<string, int>>)
               po.Invoke("FindAllRoot", new object[]
               {
                   logRecordList,analyzePattermSettingList,GetColumnContentValue
               });
            var expected = 0;

            Assert.AreEqual(expected, actual.Count);

        }
        [TestMethod]
        public void FindAllRootTest3()
        {
            var record1 = new CCSLogRecord
            {
                Id = "1",
                Content = "jo of dsabc ffff jfodsjofsd",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record2 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record3 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record4 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };

            var logRecordList = new List<CCSLogRecord> {record1,record2,record3,record4 };

            var pattern = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "ffff" },
                RootKey = "ffff"

            };
            var analyzePattermSettingList = new List<PatternItemSetting>
            {
                pattern

            };
            Func<CCSLogRecord, string> GetColumnContentValue = record => record1.Content;
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var actual = (List<ValueDisplayPair<string, int>>)
               po.Invoke("FindAllRoot", new object[]
               {
                   logRecordList,analyzePattermSettingList,GetColumnContentValue
               });
            var expected = 4;

            Assert.AreEqual(expected, actual.Count);

        }

        [TestMethod]
        public void FindCageOfPatternTest()
        {
            var record1 = new CCSLogRecord
            {
                Id = "1",
                Content = "jo of dsabc ffff jfodsjofsd",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record2 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record3 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record4 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };

            var logRecordList = new List<CCSLogRecord> { record1, record2, record3, record4 };

            var pattern = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "ffff" },
                RootKey = "ffff"

            };
            var analyzePattermSettingList = new List<PatternItemSetting>
            {
                pattern

            };
            Func<CCSLogRecord, string> GetColumnContentValue = record => record1.Content;
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var actual = (List<ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>>)
               po.Invoke("FindCageOfPattern", new object[]
               {
                   logRecordList,pattern,GetColumnContentValue,backgroundWorker
               });
            var expected = 4;

            Assert.AreEqual(expected, actual.Count);

        }
        [TestMethod]
        public void FindCageOfPatternTest1()
        {
            var record1 = new CCSLogRecord
            {
                Id = "1",
                Content = "jo of dsabc ffff jfodsjofsd",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record2 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record3 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record4 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };

            var logRecordList = new List<CCSLogRecord> { record1, record2, record3, record4 };

            var pattern = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "ffff" },
                RootKey = "ffff"

            };
            var analyzePattermSettingList = new List<PatternItemSetting>
            {
                pattern

            };
            Func<CCSLogRecord, string> GetColumnContentValue = record => record1.Content;
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.CancelAsync();
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var actual = (List<ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>>)
               po.Invoke("FindCageOfPattern", new object[]
               {
                   logRecordList,pattern,GetColumnContentValue,backgroundWorker
               });
            var expected = 0;

            Assert.AreEqual(expected, actual.Count);

        }
        [TestMethod]
        public void FindCageOfPatternTest2()
        {
            var record1 = new CCSLogRecord
            {
                Id = "1",
                Content = "jo of ds ffff jfodsjofsd abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record2 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 2,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record3 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 3,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record4 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 4,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };

            var logRecordList = new List<CCSLogRecord> { record1, record2, record3, record4 };

            var pattern = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "abc" },
                RootKey = "ffff"

            };
            var analyzePattermSettingList = new List<PatternItemSetting>
            {
                pattern

            };
            Func<CCSLogRecord, string> GetColumnContentValue = record => record1.Content;
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var actual = (List<ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>>)
               po.Invoke("FindCageOfPattern", new object[]
               {
                   logRecordList,pattern,GetColumnContentValue,backgroundWorker
               });
            var expected = 4;

            Assert.AreEqual(expected, actual.Count);

        }
        [TestMethod]
        public void FindCageOfPatternTest3()
        {
            var record1 = new CCSLogRecord
            {
                Id = "1",
                Content = "jo of ds ffff jfodsjofsd abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record2 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 2,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record3 = new CCSLogRecord
            {
                Id = "1",
                Content = " cibg  ho fosoc vc xxx jjlf os aofsa xxx",
                Line = 3,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record4 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc jof jjofsoo  xxx jfod a cx",
                Line = 4,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };

            var logRecordList = new List<CCSLogRecord> { record1, record2, record3, record4 };

            var pattern = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "xxx" },
                RootKey = "ffff"

            };
            var analyzePattermSettingList = new List<PatternItemSetting>
            {
                pattern

            };
            Func<CCSLogRecord, string> GetColumnContentValue = record => record1.Content;
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var actual = (List<ValueDisplayPair<StringLineIndexLevelPair<string, int, int, int, DateTime>, List<Cage>>>)
               po.Invoke("FindCageOfPattern", new object[]
               {
                   logRecordList,pattern,GetColumnContentValue,backgroundWorker
               });
            var expected = 4;

            Assert.AreEqual(expected, actual.Count);

        }

        [TestMethod]
        public void DoAnalyzePattern()
        {
            var record1 = new CCSLogRecord
            {
                Id = "1",
                Content = "jo of ds ffff jfodsjofsd abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record2 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 2,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record3 = new CCSLogRecord
            {
                Id = "1",
                Content = " cibg  ho fosoc vc xxx jjlf os aofsa xxx",
                Line = 3,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record4 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc jof jjofsoo  xxx jfod a cx",
                Line = 4,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };

            var logRecordList = new List<CCSLogRecord> { record1, record2, record3, record4 };

            var pattern = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "xxx" },
                RootKey = "ffff"

            };
             IList<PatternItemSetting> patternItemSettings = new PatternItemSetting[]
             {
                 pattern
             };
            Func<CCSLogRecord, string> GetColumnContentValue = record => record1.Content;
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var actual = (IList<AnalyzedPatternResultItem<CCSLogRecord>>)
               po.Invoke("DoAnalyzePattern", new object[]
               {
                   logRecordList,patternItemSettings,GetColumnContentValue,backgroundWorker
               });
            var expected = 1;

            Assert.AreEqual(expected, actual.Count);
        }
        [TestMethod]
        public void DoAnalyzePattern1()
        {
            var record1 = new CCSLogRecord
            {
                Id = "1",
                Content = "jo of ds ffff jfodsjofsd abc",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record2 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc",
                Line = 2,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record3 = new CCSLogRecord
            {
                Id = "1",
                Content = " cibg  ho fosoc vc xxx jjlf os aofsa xxx",
                Line = 3,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record4 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc jof jjofsoo  xxx jfod a cx",
                Line = 4,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };

            var logRecordList = new List<CCSLogRecord> { record1, record2, record3, record4 };

            var pattern = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "xxx" },
                RootKey = "ffff"

            };
            IList<PatternItemSetting> patternItemSettings = new PatternItemSetting[]
             {
                 pattern
             };
            Func<CCSLogRecord, string> GetColumnContentValue = record => record1.Content;
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.CancelAsync();
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var actual = (IList<AnalyzedPatternResultItem<CCSLogRecord>>)
               po.Invoke("DoAnalyzePattern", new object[]
               {
                   logRecordList,patternItemSettings,GetColumnContentValue,backgroundWorker
               });
            var expected = 0;

            Assert.AreEqual(expected, actual.Count);
        }
        [TestMethod]
        public void DoAnalyzePattern2()
        {
            var record1 = new CCSLogRecord
            {
                Id = "1",
                Content = "jo of ds ffff jfodsjofsd abc ffff ",
                Line = 1,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record2 = new CCSLogRecord
            {
                Id = "1",
                Content = " fsa fsa f abc uo jo no fsda  ",
                Line = 2,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record3 = new CCSLogRecord
            {
                Id = "1",
                Content = " cibg  ho fosoc vc xxx jjlf os aofsa xxx",
                Line = 3,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };
            var record4 = new CCSLogRecord
            {
                Id = "1",
                Content = "abc jof jjofsoo  xxx jfod a cx fsda hg",
                Line = 4,
                DateTime= DateTime.Parse("2014/10/20 10:10:10.400"),
                ThreadId = "abc",
                AdditionalInfo = "abc",
                PersonalInfo = "abc"
            };

            var logRecordList = new List<CCSLogRecord> { record1, record2, record3, record4 };

            var pattern1 = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "xxx" },
                RootKey = "ffff"

            };
            var pattern2 = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "ffff" },
                RootKey = "ffff"

            };
            var pattern3 = new PatternItemSetting
            {
                Time = 100,
                TimeUnit = "H",
                Enabled = true,
                Name = "xxx",
                Id = "1",
                Keys = new List<string> { "fsda", },
                RootKey = "no"

            };

            IList<PatternItemSetting> patternItemSettings = new PatternItemSetting[]
             {
                 pattern1,pattern2,pattern3
             };
            Func<CCSLogRecord, string> GetColumnContentValue = record => record1.Content;
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            var po = new PrivateObject(typeof(AnalyzePattern<CCSLogRecord>));
            var actual = (IList<AnalyzedPatternResultItem<CCSLogRecord>>)
               po.Invoke("DoAnalyzePattern", new object[]
               {
                   logRecordList,patternItemSettings,GetColumnContentValue,backgroundWorker
               });
            var expected = 3;

            Assert.AreEqual(expected, actual.Count);
        }
    }
}
