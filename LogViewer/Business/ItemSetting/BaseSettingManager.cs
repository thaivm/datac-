using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using LogViewer.Model;

namespace LogViewer.Business.FileSetting
{
    /// <summary>
    /// Base Class provides common method for process file setting
    /// </summary>
    public abstract class BaseSettingManager
    {
        /// <summary>
        /// Store current status of log display setting file <see cref="EnumSettingFileType">type</see>.The set by <seealso cref="BaseLogDisplaySettingFilePath"/>.
        /// </summary>
        protected EnumSettingFileType CurrentLogDisplayFileType;
        /// <summary>
        /// Store current status of pattern setting file <see cref="EnumSettingFileType">type</see>.The set by <seealso cref="BasePatternSettingFilePath"/>.
        /// </summary>
        protected EnumSettingFileType CurrentPatternFileType;
        /// <summary>
        /// Store current status of filter setting file <see cref="EnumSettingFileType">type</see>.The set by <seealso cref="BaseFilterSettingFilePath"/>.
        /// </summary>
        protected EnumSettingFileType CurrentFilterSettingFileType;
        /// <summary>
        /// Store current status of keyword count setting file <see cref="EnumSettingFileType">type</see>.The set by <seealso cref="BaseKeywordCountSettingFilePath"/>.
        /// </summary>
        protected EnumSettingFileType CurrentKeywordCountFileType;
        /// <summary>
        /// Get path of user pattern setting file, if the path is not exists the default pattern setting file will be use, 
        /// if the default pattern setting file is not exist, this method will throw <see cref="FileNotFoundException"/>.
        /// </summary>
        protected virtual string BasePatternSettingFilePath { get; set; }
        /// <summary>
        /// Get or set the path of user pattern setting file.
        /// </summary>
        protected virtual string UserPatternSettingFilePath { get; set; }
        /// <summary>
        /// Get the path of default pattern setting file.
        /// </summary>
        protected abstract string DefaultPatternSettingFilePath { get; }
        /// <summary>
        /// Get path of user filter setting file, if the path is not exists the default filter setting file will be use, 
        /// if the default filter setting file is not exist, this method will throw <see cref="FileNotFoundException"/>.
        /// </summary>
        protected virtual string BaseFilterSettingFilePath { get; set; }
        /// <summary>
        /// Get or set the path of user filter setting file.
        /// </summary>
        protected virtual string UserFilterSettingFilePath { get; set; }
        /// <summary>
        /// Get or set the path of default filter setting file.
        /// </summary>
        protected abstract string DefaultFilterSettingFilePath { get; }
        /// <summary>
        /// Get path of user keyword count setting file, if the path is not exists the default keyword count setting file will be use, 
        /// if the default keyword count setting file is not exist, this method will throw <see cref="FileNotFoundException"/>.
        /// </summary>
        protected virtual string BaseKeywordCountSettingFilePath { get; set; }
        /// <summary>
        /// Get or set the path of user keyword count setting file.
        /// </summary>
        protected virtual string UserKeywordCountSettingFilePath { get; set; }
        /// <summary>
        /// Get or set the path of default keyword count setting file.
        /// </summary>
        protected abstract string DefaultKeywordCountSettingFilePath { get; }
        /// <summary>
        /// Get path of user log display setting file, if the path is not exists the default log display setting file will be use, 
        /// if the default log display setting file is not exist, this method will throw <see cref="FileNotFoundException"/>.
        /// </summary>
        protected virtual string BaseLogDisplaySettingFilePath { get; set; }
        /// <summary>
        /// Get or set the path of user log display setting file.
        /// </summary>
        protected virtual string UserLogDisplaySettingFilePath { get; set; }
        /// <summary>
        /// Get or set the path of default log display setting file.
        /// </summary>
        protected abstract string DefaultLogDisplaySettingFilePath { get; }
        /// <summary>
        /// Initial log display setting if user or default log display setting file is not exists
        /// </summary>
        protected abstract void InitSystemLogDisplaySetting();

        /// <summary>
        /// Get or set the list of <see cref="KeywordCountItemSetting"/> objects.
        /// </summary>
        public List<KeywordCountItemSetting> KeywordCountSettingList { get; set; }
        /// <summary>
        /// Get or set the list of <see cref="PatternItemSetting"/> objects.
        /// </summary>
        public List<PatternItemSetting> PatternSettingList { get; set; }
        /// <summary>
        /// Get or set the list of <see cref="FilterItemSetting"/> objects.
        /// </summary>
        public List<FilterItemSetting> ColorFilterSettingList { get; set; }
        /// <summary>
        /// Get or set the list of <see cref="LogDisplay"/> objects.
        /// </summary>
        public List<LogDisplay> DisplaySetting { get; set; }
        /// <summary>
        /// Get or set <see cref="FilterItemSetting"/> object.
        /// </summary>

        public FilterItemSetting NarrowFilterSettingItem { get; set; }
        /// <summary>
        /// Create default folder if its are not existed. Tow default folder will be create inside application path are: FileConfig and ActionList
        /// </summary>
        protected void CreateDefaultAppFolder()
        {
            if (!Directory.Exists(ConfigValue.ConfigFolder))
            {
                Directory.CreateDirectory(ConfigValue.ConfigFolder);
            }
            if (!Directory.Exists(ConfigValue.ActionListFolder))
            {
                Directory.CreateDirectory(ConfigValue.ActionListFolder);
            }
        }
        /// <summary>
        /// Get the list of enabled <see cref="FilterItemSetting"/> objects.
        /// </summary>
        public List<FilterItemSetting> AllEnabledColorFilters
        {
            get
            {
                var result = ColorFilterSettingList.FindAll(x => x.Enabled);
                if (NarrowFilterSettingItem != null)
                {
                    var narrowAlikeFilter = ColorFilterSettingList.FirstOrDefault(x => x.StringValue == NarrowFilterSettingItem.StringValue &&
                                                                                       x.LogItem == NarrowFilterSettingItem.LogItem);
                    if (narrowAlikeFilter != null)
                    {
                        if (!result.Contains(narrowAlikeFilter))
                        {
                            NarrowFilterSettingItem.Background = narrowAlikeFilter.Background;
                            NarrowFilterSettingItem.Foreground = narrowAlikeFilter.Foreground;
                            NarrowFilterSettingItem.FontStyle = narrowAlikeFilter.FontStyle;
                            result.Add(NarrowFilterSettingItem);
                        }
                    }
                    else
                    {
                        result.Add(NarrowFilterSettingItem);
                    }
                }
                return result;
            }
        }
        /// <summary>
        /// Set the list <see cref="KeywordCountItemSetting"/>
        /// </summary>
        /// <param name="data">List of <see cref="KeywordCountItemSetting"/>, the list is collected by from user input of from setting file.
        /// </param>
        public void SetKeywordCountSettingList(List<KeywordCountItemSetting> data)
        {
            KeywordCountSettingList = data;
        }
        /// <summary>
        /// Read log display setting file, depend on current context of setting file. 
        /// Display setting file can be: UserCCSLogSetting.csv/UserCXDILogSetting.csv, DefaultCCSLogSetting.csv/DefaultCXDILogSetting.csv or 
        /// <see cref="InitSystemLogDisplaySetting"/>. 
        /// </summary>
        public virtual void ReadDisplaySetting()
        {
            DisplaySetting = new List<LogDisplay>();

            try
            {

                List<LogDisplay> displaySetting;
                try
                {
                    displaySetting =ReadDisplaySetting(BaseLogDisplaySettingFilePath);
                }
                catch (UserSettingFileException)
                {
                    if (CurrentLogDisplayFileType == EnumSettingFileType.UserFile)
                    {
                        CurrentLogDisplayFileType = EnumSettingFileType.DefaultFile;
                        displaySetting = ReadDisplaySetting(DefaultLogDisplaySettingFilePath);
                    }
                    else throw;
                }
                //Sort the log display by system setting configuration
                DisplaySetting = displaySetting.OrderBy(logItem => GetSystemConfig().FindIndex(item => item.key.Equals(logItem.key))).ToList();

            }
            catch (FileNotFoundException)
            {
                InitSystemLogDisplaySetting();
                var errorMessage = string.Format(Properties.Resources.READ_DISPLAY_SETTING_FILE_NOT_FOUND_EXCEPTION, Path.GetFileName(BaseLogDisplaySettingFilePath));
                throw new Exception(errorMessage);
            }
            catch
            {
                InitSystemLogDisplaySetting();
                throw;
            }

        }

        /// <summary>
        /// Read log display setting file, depend on current context of setting file. 
        /// Display setting file can be: UserCCSLogSetting.csv/UserCXDILogSetting.csv, DefaultCCSLogSetting.csv/DefaultCXDILogSetting.csv or 
        /// </summary>
        /// <param name="filePath">Location of display setting file</param>
        /// <returns>List of display setting object <see cref="LogDisplay"/></returns>
        protected List<LogDisplay> ReadDisplaySetting(string filePath)
        {
            var displaySetting = new List<LogDisplay>();
            using (var r = new StreamReader(filePath))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    var split = line.Split(',');
                    if (split.Length == 3)
                    {
                        try
                        {
                            bool isDisplay = Boolean.Parse(split[2]);
                            var logItem = new LogDisplay { key = split[1], value = isDisplay };
                            if (logItem.ValidDate(GetSystemConfig()))
                            {
                                displaySetting.Add(logItem);
                            }
                        }
                        catch{ }
                    }
                }
                if (!IsValidLogDisplay(displaySetting))
                {
                    r.Close();
                      throw new UserSettingFileException(string.Format(Properties.Resources.FILE_LOG_LOAD_EXCEPTION, Path.GetFileName(filePath)));
                }

                r.Close();
            }
            return displaySetting;
        }
        /// <summary>
        /// Check validation for list of log display setting item
        /// </summary>
        /// <param name="displaySetting">List of display setting item, see <see cref="LogDisplay"/> for more infomation</param>
        /// <returns>True: if log display setting item is valid, otherwise is False. The log display item setting list is valid when 
        /// <see cref="LogDisplay"/> name match with <see cref="LogDisplay"/> defined in <see cref="ConfigValue.SystemCCSLogSetting"/> 
        /// or <see cref="ConfigValue.SystemCXDILogSetting"/> 
        /// </returns>
        protected bool IsValidLogDisplay(List<LogDisplay> displaySetting)
        {
            if (displaySetting == null || displaySetting.Count == 0) return false;
            if (displaySetting.Count != GetSystemConfig().Count()) return false;
            try
            {
                if (GetSystemConfig().Select(logItem => displaySetting.FindAll(item => item.key.Equals(logItem.key))).Any(ls => ls.Count != 1))
                {
                    return false;
                }
            }
            catch { return false; }

            return true;

        }
        /// <summary>
        /// Get list of log display setting item that defined in <see cref="ConfigValue.SystemCCSLogSetting"/> or <see cref="ConfigValue.SystemCXDILogSetting"/>
        /// </summary>
        /// <returns></returns>
        protected abstract List<LogDisplay> GetSystemConfig();
        /// <summary>
        /// Write log display setting file to user log display setting file(UserCCSLogSetting.csv,UserCXDILogSetting.csv). File type is csv
        /// </summary>
        public virtual void WriteDisplaySetting()
        {
            CreateDefaultAppFolder();
            try
            {
                using (var fs = new FileStream(UserLogDisplaySettingFilePath, FileMode.Create))
                {
                    fs.SetLength(0);
                    using (var sw = new StreamWriter(fs))
                    {
                        int i = 1;
                        foreach (var logDisplay in DisplaySetting)
                        {
                            string data = i + "," + logDisplay.key.Trim() + "," + logDisplay.value.ToString().ToLower();
                            sw.WriteLine(data);
                            i++;
                        }
                        sw.Close();
                    }
                    fs.Close();
                }
            }
            catch
            {
                throw new Exception(string.Format(Properties.Resources.FILE_WRITE_EXCEPTION, Path.GetFileName(UserLogDisplaySettingFilePath)));
            }
        }
        /// <summary>
        /// Read keyword count setting file, depend on current context of setting file. 
        /// Keyword count setting file can be: UserCCSKeywordSetting.csv/UserCXDIKeywordSetting.csv, DefaultCCSKeywordSetting.csv/DefaultCXDIKeywordSetting.csv 
        /// or empty list. 
        /// </summary>
        public virtual void ReadKeywordCountSettingFile()
        {
            KeywordCountSettingList = new List<KeywordCountItemSetting>();

            try
            {
                var lsKeywordCountSetting = new List<KeywordCountItemSetting>();
                using (var r = new StreamReader(BaseKeywordCountSettingFilePath))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        var split = line.Split(',');
                        if (split.Length == 5)
                        {
                            try
                            {
                                var keyword = new KeywordCountItemSetting
                                {
                                    Id = split[0],
                                    Name = split[1],
                                    StringValue = split[2],
                                    LogItem = split[3],
                                    Enabled = Convert.ToBoolean(split[4])
                                };
                                if (keyword.ValidDate(GetLogHeader()))
                                {
                                    if (!lsKeywordCountSetting.Any(f => f.Name.Trim().ToLower().Equals(keyword.Name.Trim().ToLower())))
                                    {
                                        lsKeywordCountSetting.Add(keyword);
                                    }
                                }
                            }
                            catch { }
                        }
                    }
                    r.Close();
                }
                KeywordCountSettingList = lsKeywordCountSetting;
            }
            catch
            {
                string currentErrorPath;
                if (CurrentKeywordCountFileType == EnumSettingFileType.UserFile)
                    currentErrorPath = UserKeywordCountSettingFilePath;
                else if (CurrentKeywordCountFileType == EnumSettingFileType.DefaultFile)
                    currentErrorPath = DefaultKeywordCountSettingFilePath;
                else currentErrorPath = DefaultKeywordCountSettingFilePath;

                throw new Exception(string.Format(Properties.Resources.READ_KEYWORD_COUNT_SETTING_FILE_NOT_FOUND_EXCEPTION, Path.GetFileName(currentErrorPath)));
            }
        }
        /// <summary>
        /// Write to user keyword count setting file(UserCCSKeywordSetting.csv/UserCXDIKeywordSetting.csv)
        /// <exception cref="Exception">IO Exception must be catch</exception>
        /// </summary>
        public virtual void WriteKeywordCountSettingFile()
        {
            CreateDefaultAppFolder();

            try
            {
                using (var fs = new FileStream(UserKeywordCountSettingFilePath, FileMode.Create))
                {
                    fs.SetLength(0);
                    using (var sw = new StreamWriter(fs))
                    {
                        int i = 1;
                        foreach (var keyword in KeywordCountSettingList)
                        {
                            string data = i + "," + keyword.Name.Trim() + "," + keyword.StringValue.Trim() + "," + keyword.LogItem.Trim() + "," + keyword.Enabled.ToString();
                            sw.WriteLine(data);
                            i++;
                        }
                        sw.Close();
                    }
                    fs.Close();
                }
            }
            catch
            {
                throw new Exception(string.Format(Properties.Resources.FILE_WRITE_EXCEPTION, Path.GetFileName(UserKeywordCountSettingFilePath)));
            }
        }
        /// <summary>
        /// Read File pattern setting. File type is XML
        /// </summary>
        public virtual void ReadPattermSetting()
        {
            PatternSettingList = new List<PatternItemSetting>();

            try
            {
                List<PatternItemSetting> lsPatternSetting;
                try
                {
                    lsPatternSetting = ReadPatternSetting(BasePatternSettingFilePath);
                }
                catch (UserSettingFileException) {
                    if (CurrentPatternFileType == EnumSettingFileType.UserFile)
                    {
                        CurrentPatternFileType = EnumSettingFileType.DefaultFile;
                        lsPatternSetting = ReadPatternSetting(DefaultPatternSettingFilePath);
                    }
                    else throw;
                }
                PatternSettingList = lsPatternSetting;
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch
            {
                throw new Exception(Properties.Resources.READ_PATTERN_SETTING_OTHER_EXCEPTION);
            }
        }

        protected List<PatternItemSetting> ReadPatternSetting(string filePath)
        {
            var lsPatternSetting = new List<PatternItemSetting>();
            try
            {
                var doc = new XmlDocument();
                doc.Load(filePath);

                XmlNodeList contentList =
                    doc.SelectNodes("/PatternAnalyze/Content");

                if (contentList != null)
                    foreach (XmlNode content in contentList)
                    {
                        //Get content attribute
                        if (content.Attributes != null)
                        {
                            var pattermItem = new PatternItemSetting
                            {
                                Id = content.Attributes
                                    .GetNamedItem("ID").Value,
                                Name = content.Attributes
                                    .GetNamedItem("Name").Value,
                                Enabled = bool.Parse(content.Attributes
                                    .GetNamedItem("Enable").Value)
                            };
                            //Get root Item
                            var rootItem = content.SelectSingleNode("RootItem");

                            if (rootItem != null)
                            {
                                if (rootItem.Attributes != null)
                                {
                                    pattermItem.Time = ulong.Parse(rootItem.Attributes.GetNamedItem("Time").Value);
                                    pattermItem.TimeUnit = rootItem.Attributes.GetNamedItem("TimeUnit").Value;
                                }
                                pattermItem.RootKey = rootItem.InnerText;
                            }
                            //Get Items nod
                            var items = content.SelectSingleNode("Items");
                            //Get Item list
                            if (items != null)
                            {
                                var itemList = items.SelectNodes("Item");
                                pattermItem.Keys = new List<string>();
                                if (itemList != null)
                                    foreach (XmlNode item in itemList)
                                    {
                                        pattermItem.Keys.Add(item.InnerText);
                                    }
                            }
                            lsPatternSetting.Add(pattermItem);
                        }
                    }
            }
            catch {
                throw new UserSettingFileException(string.Format(Properties.Resources.FILE_LOG_LOAD_EXCEPTION, Path.GetFileName(filePath)));
            }
            return lsPatternSetting;
        }
        /// <summary>
        /// Write Pattern setting to file xml file. The file will be writen as user setting file
        /// </summary>
        /// <exception cref="Exception">IO Exception must be catch</exception>
        public virtual void WritePattermSetting()
        {
            CreateDefaultAppFolder();

            try
            {

                using (var fs = new FileStream(UserPatternSettingFilePath, FileMode.Create))
                {
                    using (var w = XmlWriter.Create(fs))
                    {
                        var doc = new XmlDocument();
                        var docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                        doc.AppendChild(docNode);

                        var patternAnalyzeNode = doc.CreateElement("PatternAnalyze");
                        doc.AppendChild(patternAnalyzeNode);
                        foreach (var pattern in PatternSettingList)
                        {
                            var contentNode = doc.CreateElement("Content");

                            //Create content attribute
                            var contentNodeAttribute = doc.CreateAttribute("ID");
                            contentNodeAttribute.Value = pattern.Id.Trim();
                            contentNode.Attributes.Append(contentNodeAttribute);

                            contentNodeAttribute = doc.CreateAttribute("Name");
                            contentNodeAttribute.Value = pattern.Name.Trim();
                            contentNode.Attributes.Append(contentNodeAttribute);

                            contentNodeAttribute = doc.CreateAttribute("Enable");
                            contentNodeAttribute.Value = pattern.Enabled.ToString();
                            contentNode.Attributes.Append(contentNodeAttribute);


                            var rootItemNode = doc.CreateElement("RootItem");

                            var rootItemAttribute = doc.CreateAttribute("Time");
                            rootItemAttribute.Value = pattern.Time.ToString();
                            rootItemNode.Attributes.Append(rootItemAttribute);

                            rootItemAttribute = doc.CreateAttribute("TimeUnit");
                            rootItemAttribute.Value = pattern.TimeUnit.Trim();
                            rootItemNode.Attributes.Append(rootItemAttribute);
                            rootItemNode.InnerText = pattern.RootKey.Trim();
                            contentNode.AppendChild(rootItemNode);

                            var itemsNode = doc.CreateElement("Items");

                            foreach (var item in pattern.Keys)
                            {
                                var itemNode = doc.CreateElement("Item");
                                itemNode.InnerText = item.Trim();

                                itemsNode.AppendChild(itemNode);
                            }
                            contentNode.AppendChild(itemsNode);
                            patternAnalyzeNode.AppendChild(contentNode);


                        }

                        doc.Save(w);
                        w.Close();
                    }
                    fs.Close();
                }
            }
            catch
            {
                throw new Exception(string.Format(Properties.Resources.FILE_WRITE_EXCEPTION, Path.GetFileName(UserPatternSettingFilePath)));
            }

        }
        /// <summary>
        /// Read filter setting file, depend on current context of setting file. 
        /// Filter setting file can be: UserCCSFilteringSetting.csv/UserCXDIFilteringSetting.csv, DefaultCCSFilteringSetting.csv/DefaultCXDIFilteringSetting.csv 
        /// or empty list. 
        /// </summary>
        public virtual void ReadFilterSetting()
        {
            ColorFilterSettingList = new List<FilterItemSetting>();

            try
            {
                var lsFilterSetting = new List<FilterItemSetting>();
                using (var r = new StreamReader(BaseFilterSettingFilePath))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        var split = line.Split(',');
                        if (split.Length == 8)
                        {
                            FilterItemSetting filterLog = null;
                            try
                            {
                                filterLog = new FilterItemSetting
                                {
                                    Id = split[0],
                                    Name = split[1],
                                    StringValue = split[2],
                                    LogItem = split[3],
                                    Foreground = split[4],
                                    Background = split[5],
                                    FontStyle = split[6],
                                    Enabled = Convert.ToBoolean(split[7])
                                };
                            }
                            catch
                            {
                                //inogre error  record
                            };
                            if (filterLog != null)
                            {
                                if (IsValidFilterLogItem(lsFilterSetting, filterLog) && lsFilterSetting.Count < ConfigValue.LimitFilterItem)
                                {
                                    lsFilterSetting.Add(filterLog);
                                }
                            }
                        }
                    }
                    r.Close();
                }
                ColorFilterSettingList = lsFilterSetting;
            }
            catch
            {
                string currentErrorPath;
                switch (CurrentFilterSettingFileType)
                {
                    case EnumSettingFileType.UserFile:
                        currentErrorPath = UserFilterSettingFilePath;
                        break;
                    case EnumSettingFileType.DefaultFile:
                        currentErrorPath = DefaultFilterSettingFilePath;
                        break;
                    default:
                        currentErrorPath = DefaultFilterSettingFilePath;
                        break;
                }

                throw new Exception(string.Format(Properties.Resources.READ_FILTER_SETTING_FILE_NOT_FOUND_EXCEPTION, Path.GetFileName(currentErrorPath)));
            }
        }
        protected bool IsValidFilterLogItem(IEnumerable<FilterItemSetting> ls, FilterItemSetting logItem)
        {
            //Valid logItem value
            if (!logItem.IsValidDate(GetLogHeader())) return false;
            //Existed log item;
            return ls.Count(f => f.Name.Trim().ToLower().Equals(logItem.Name.Trim().ToLower())) <= 0;
        }
        /// <summary>
        /// Get list of column name of log file. The column list defend on which class inherited this class
        /// </summary>
        /// <returns>List of column name of log file</returns>
        protected abstract List<string> GetLogHeader();
        /// <summary>
        /// Write to filter setting file. This action will write to user filter setting file. 
        /// Filter setting file can be: UserCCSFilteringSetting.csv, UserCXDIFilteringSetting.csv
        /// </summary>
        /// <exception cref="Exception">IO Exception must be catch</exception>
        public virtual void WriteFilterSetting()
        {
            CreateDefaultAppFolder();

            try
            {

                using (var fs = new FileStream(UserFilterSettingFilePath, FileMode.Create))
                {
                    fs.SetLength(0);
                    using (var sw = new StreamWriter(fs))
                    {
                        var i = 1;
                        foreach (var filter in ColorFilterSettingList)
                        {
                            string data = i + "," + filter.Name.Trim() + "," + filter.StringValue.Trim() + "," +
                                filter.LogItem.Trim() + "," + filter.Foreground.Trim() + "," + filter.Background.Trim() + "," +
                                filter.FontStyle.Trim() + "," + filter.Enabled;
                            sw.WriteLine(data);
                            i++;
                        }
                        sw.Close();
                    }
                    fs.Close();
                }
            }
            catch
            {
                throw new Exception(string.Format(Properties.Resources.FILE_WRITE_EXCEPTION, Path.GetFileName(UserFilterSettingFilePath)));
            }
        }
    }
}