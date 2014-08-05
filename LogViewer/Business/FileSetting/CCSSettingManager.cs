using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Security.Permissions;
using System.Collections.ObjectModel;
using LogViewer.Business.FileSetting;
using LogViewer.Model;

namespace LogViewer.Business
{
    /// <summary>
    /// Class provides methods for manager CCS setting file
    /// </summary>
    public class CCSSettingManager : BaseSettingManager
    {
        /// <summary>
        /// Properties for retrieval list of <see cref="ErrorActionItem">ErrorActionItem</see>
        /// when call <see cref="ReadErrorActionSetting">ReadErrorActionSetting</see>
        /// <see cref="ReadErrorActionSetting">ReadErrorActionSetting</see>
        /// </summary>
        public List<ErrorActionItem> ErrorActionSettingList { get; set; }
        /// <summary>
        /// Properties for retrieval list of <see cref="UserActionItem">UserActionItem</see>
        /// when call <see cref="ReadUserActionSetting">ReadUserActionSetting</see>
        /// </summary>
        public List<UserActionItem> UserActionSettingList { get; set; }
        /// <summary>
        /// Return the full user path of error action setting file
        /// </summary>
        public String ErrorActionSettingFilePath
        {
            get
            {
                if (File.Exists(ConfigValue.ErrorActionList)) return ConfigValue.ErrorActionList;
                else throw new FileNotFoundException(string.Format(Properties.Resources.FILE_LOG_LOAD_EXCEPTION, Path.GetFileName(ConfigValue.ErrorActionList)));
            }
        }
        /// <summary>
        /// Return the full user path of error action setting file
        /// </summary>
        public String UserActionSettingFilePath
        {
            get
            {
                if (File.Exists(ConfigValue.UserActionList)) return ConfigValue.UserActionList;
                else throw new FileNotFoundException(string.Format(Properties.Resources.FILE_LOG_LOAD_EXCEPTION, Path.GetFileName(ConfigValue.UserActionList)));
            }
        }
        /// <summary>
        /// Constructor for CCSSettingManager
        /// </summary>

        public CCSSettingManager()
        {
            CreateDefaultAppFolder();

            BasePatternSettingFilePath = ConfigValue.UserCCSPatternSettingFile;
            BaseFilterSettingFilePath = ConfigValue.UserCCSFilteringSettingFile;
            BaseKeywordCountSettingFilePath = ConfigValue.UserCCSKeywordSettingFile;
            BaseLogDisplaySettingFilePath = ConfigValue.UserCCSLogSettingFile;
        }

        /// <summary>
        /// Get path of user pattern setting file, if the path is not exists the default pattern setting file will be use, 
        /// if the default pattern setting file is not exist, this method will throw <see cref="FileNotFoundException"/>.
        /// </summary>

        protected override string BasePatternSettingFilePath
        {
            get
            {
                if (File.Exists(ConfigValue.UserCCSPatternSettingFile))
                {
                    CurrentPatternFileType = EnumSettingFileType.UserFile;
                    return ConfigValue.UserCCSPatternSettingFile;
                }
                if (File.Exists(ConfigValue.DefaultCCSPatternSettingFile))
                {
                    CurrentPatternFileType = EnumSettingFileType.DefaultFile;
                    return ConfigValue.DefaultCCSPatternSettingFile;
                }
                CurrentPatternFileType = EnumSettingFileType.SystemFile;
                throw new FileNotFoundException(string.Format(Properties.Resources.FILE_LOG_LOAD_EXCEPTION, Path.GetFileName(ConfigValue.DefaultCCSPatternSettingFile)));
            }
        }
        /// <summary>
        /// Get or set the path of user pattern setting file.
        /// </summary>
        protected override string UserPatternSettingFilePath { get { return ConfigValue.UserCCSPatternSettingFile; } }
        /// <summary>
        /// Get path of user filter setting file, if the path is not exists the default filter setting file will be use, 
        /// if the default filter setting file is not exist, this method will throw <see cref="FileNotFoundException"/>.
        /// </summary>
        protected override string BaseFilterSettingFilePath
        {
            get
            {
                if (File.Exists(ConfigValue.UserCCSFilteringSettingFile))
                {
                    CurrentFilterSettingFileType = EnumSettingFileType.UserFile;
                    return ConfigValue.UserCCSFilteringSettingFile;
                }
                if (File.Exists(ConfigValue.DefaultCCSFilteringSettingFile))
                {
                    CurrentFilterSettingFileType = EnumSettingFileType.DefaultFile;

                    return ConfigValue.DefaultCCSFilteringSettingFile;
                }
                CurrentFilterSettingFileType = EnumSettingFileType.SystemFile;
                throw new FileNotFoundException(ConfigValue.DefaultCCSFilteringSettingFile);
            }
        }
        /// <summary>
        /// Get or set the path of user filter setting file.
        /// </summary>
        protected override string UserFilterSettingFilePath { get { return ConfigValue.UserCCSFilteringSettingFile; } }
        /// <summary>
        /// Get path of user keyword count setting file, if the path is not exists the default keyword count setting file will be use, 
        /// if the default keyword count setting file is not exist, this method will throw <see cref="FileNotFoundException"/>.
        /// </summary>
        protected override string BaseKeywordCountSettingFilePath
        {
            get
            {
                if (File.Exists(ConfigValue.UserCCSKeywordSettingFile))
                {
                    CurrentKeywordCountFileType = EnumSettingFileType.UserFile;

                    return ConfigValue.UserCCSKeywordSettingFile;
                }
                if (File.Exists(ConfigValue.DefaultCCSKeywordSettingFile))
                {
                    CurrentKeywordCountFileType = EnumSettingFileType.DefaultFile;
                    return ConfigValue.DefaultCCSKeywordSettingFile;
                }
                CurrentKeywordCountFileType = EnumSettingFileType.SystemFile;
                throw new FileNotFoundException(ConfigValue.DefaultCCSKeywordSettingFile);
            }
        }
        /// <summary>
        /// Get or set the path of user keyword count setting file.
        /// </summary>
        protected override string UserKeywordCountSettingFilePath { get { return ConfigValue.UserCCSKeywordSettingFile; } }
        /// <summary>
        /// Get path of user log display setting file, if the path is not exists the default log display setting file will be use, 
        /// if the default log display setting file is not exist, this method will throw <see cref="FileNotFoundException"/>.
        /// </summary>
        protected override string BaseLogDisplaySettingFilePath
        {
            get
            {
                if (File.Exists(ConfigValue.UserCCSLogSettingFile))
                {
                    CurrentLogDisplayFileType = EnumSettingFileType.UserFile;
                    return ConfigValue.UserCCSLogSettingFile;
                }
                if (File.Exists(ConfigValue.DefaultCCSLogSettingFile))
                {
                    CurrentLogDisplayFileType = EnumSettingFileType.DefaultFile;
                    return ConfigValue.DefaultCCSLogSettingFile;
                }
                CurrentLogDisplayFileType = EnumSettingFileType.SystemFile;
                    
                throw new FileNotFoundException(string.Format(Properties.Resources.FILE_LOG_LOAD_EXCEPTION, Path.GetFileName(ConfigValue.DefaultCCSLogSettingFile)));
            }
        }
        /// <summary>
        /// Get or set the path of user log display setting file.
        /// </summary>
        protected override string UserLogDisplaySettingFilePath { get { return ConfigValue.UserCCSLogSettingFile; } }
        /// <summary>
        /// Initial log display setting if user or default log display setting file is not exists
        /// </summary>
        protected override string DefaultLogDisplaySettingFilePath { get { return ConfigValue.DefaultCCSLogSettingFile; } }
        /// <summary>
        /// Read information from the error action setting file setting. 
        /// The error action setting will be store to ErrorActionSettingList properties
        /// </summary>
        /// <exception cref="Exception">IO Exception must be catch</exception>
        public void ReadErrorActionSetting()
        {
            ErrorActionSettingList = new List<ErrorActionItem>();
            if (File.Exists(ErrorActionSettingFilePath))
            {
                List<ErrorActionItem> lsErrorActionSetting = new List<ErrorActionItem>();
                try
                {
                    using (StreamReader r = new StreamReader(ErrorActionSettingFilePath, Encoding.GetEncoding(932)))
                    {
                        string line;
                        while ((line = r.ReadLine()) != null)
                        {
                            var split = line.Split(',');
                            if (split.Length == 4)
                            {
                                ErrorActionItem errorAction = new ErrorActionItem
                                {
                                    ErrorLv = split[0],
                                    ErrorCode = split[1],
                                    ErrorMessage = split[2],
                                    ErrorRecipe = split[3]
                                };

                                lsErrorActionSetting.Add(errorAction);
                            }
                        }
                        r.Close();
                    }
                    ErrorActionSettingList = lsErrorActionSetting;
                }
                catch
                {
                    //Read file error;
                    throw new Exception(string.Format(Properties.Resources.FILE_LOG_LOAD_EXCEPTION, Path.GetFileName(ErrorActionSettingFilePath)));
                }
            }
        }

        /// <summary>
        /// Read information from the user action setting file setting. 
        /// The user action setting will be store to ErrorActionSettingList properties
        /// </summary>
        /// <exception cref="Exception">IO Exception must be catch</exception>
        public void ReadUserActionSetting()
        {
            UserActionSettingList = new List<UserActionItem>();
            if (File.Exists(UserActionSettingFilePath))
            {
                List<UserActionItem> lsUserActionSetting = new List<UserActionItem>();
                try
                {
                    using (StreamReader r = new StreamReader(UserActionSettingFilePath, Encoding.GetEncoding(932)))
                    {
                        string line;
                        while ((line = r.ReadLine()) != null)
                        {
                            var split = line.Split(',');
                            if (split.Length == 3)
                            {
                                UserActionItem errorAction = new UserActionItem
                                {
                                    ID = split[0],
                                    RefSystemLog = split[1],
                                    UserAction = split[2]
                                };

                                lsUserActionSetting.Add(errorAction);
                            }
                        }
                        r.Close();
                    }
                    UserActionSettingList = lsUserActionSetting;
                }
                catch
                {
                    //Read file error;
                    throw new Exception(string.Format(Properties.Resources.FILE_LOG_LOAD_EXCEPTION, Path.GetFileName(UserActionSettingFilePath)));
                }
            }
        }

        /// <summary>
        /// Initialize for log display settings, the list of display setting is got from <see cref="ConfigValue.SystemCCSLogSetting()"/>
        /// </summary>

        protected override void InitSystemLogDisplaySetting()
        {

            DisplaySetting.AddRange(ConfigValue.SystemCCSLogSetting());
        }


        /// <summary>
        /// Get log display settings, the list of display setting is got from <see cref="ConfigValue.SystemCCSLogSetting()"/>
        /// </summary>

        protected override List<LogDisplay> GetSystemConfig()
        {
            return ConfigValue.SystemCCSLogSetting();
        }
        /// <summary>
        /// Get log header list for CCS log file, the list of log header is got from <see cref="ConfigValue.CCSHeader.AllLogField"/>
        /// </summary>

        protected override List<string> GetLogHeader()
        {
            return ConfigValue.CCSHeader.AllLogField;
        }
        /// <summary>
        /// Get the path of default pattern setting file
        /// </summary>
        protected override string DefaultPatternSettingFilePath
        {
            get {
                return ConfigValue.DefaultCCSPatternSettingFile;
            }
        }
        /// <summary>
        /// Get the path of default filter setting file
        /// </summary>

        protected override string DefaultFilterSettingFilePath
        {
            get { return ConfigValue.DefaultCCSFilteringSettingFile; }
        }
        /// <summary>
        /// Get the path of default keyword count setting file
        /// </summary>

        protected override string DefaultKeywordCountSettingFilePath
        {
            get { return ConfigValue.DefaultCCSKeywordSettingFile; }
        }
    }

}
