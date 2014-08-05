using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using LogViewer.Business;

namespace LogViewer.Model
{
    /// <summary>
    /// 
    /// Class provide statics properties and methods as application configure
    /// </summary>
    class ConfigValue
    {
        /// <summary>
        /// Get configure folder path
        /// </summary>
        public static string ConfigFolder = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + System.IO.Path.DirectorySeparatorChar + "FileConfig";
        /// <summary>
        /// Get action folder path
        /// </summary>
        public static string ActionListFolder = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + System.IO.Path.DirectorySeparatorChar + "ActionList";
        /// <summary>
        /// Get user CCS log setting file path
        /// </summary>
        public static string UserCCSLogSettingFile = ConfigFolder + System.IO.Path.DirectorySeparatorChar + "UserCCSLogSetting.csv";
        /// <summary>
        /// Get user CXDI log setting file path
        /// </summary>
        public static string UserCXDILogSettingFile = ConfigFolder + System.IO.Path.DirectorySeparatorChar + "UserCXDILogSetting.csv";
        /// <summary>
        /// Get user CCS filter setting file path
        /// </summary>
        public static string UserCCSFilteringSettingFile = ConfigFolder + System.IO.Path.DirectorySeparatorChar + "UserCCSFilteringSetting.csv";
        /// <summary>
        /// Get user CXDI filter setting file path
        /// </summary>
        public static string UserCXDIFilteringSettingFile = ConfigFolder + System.IO.Path.DirectorySeparatorChar + "UserCXDIFilteringSetting.csv";
        /// <summary>
        /// Get user CCS keyword setting file path
        /// </summary>
        public static string UserCCSKeywordSettingFile = ConfigFolder + System.IO.Path.DirectorySeparatorChar + "UserCCSKeywordSetting.csv";
        /// <summary>
        /// Get user CXDI keyword setting file path
        /// </summary>
        public static string UserCXDIKeywordSettingFile = ConfigFolder + System.IO.Path.DirectorySeparatorChar + "UserCXDIKeywordSetting.csv";
        /// <summary>
        /// Get user CCS pattern setting file path
        /// </summary>
        public static string UserCCSPatternSettingFile = ConfigFolder + System.IO.Path.DirectorySeparatorChar + "UserCCSPatternSetting.xml";
        /// <summary>
        /// Get user CXDI pattern setting file path
        /// </summary>
        public static string UserCXDIPatternSettingFile = ConfigFolder + System.IO.Path.DirectorySeparatorChar + "UserCXDIPatternSetting.xml";
        /// <summary>
        /// Get user CXDI graph parameter setting file path
        /// </summary>
        public static string UserGraphParamSettingFile = ConfigFolder + System.IO.Path.DirectorySeparatorChar + "UserGraphParamSetting.xml";

        /// <summary>
        /// Get default CCS filter setting file path
        /// </summary>
        public static string DefaultCCSFilteringSettingFile = ConfigFolder + System.IO.Path.DirectorySeparatorChar + "DefaultCCSFilteringSetting.csv";
        /// <summary>
        /// Get default CXDI filter setting file path
        /// </summary>
        public static string DefaultCXDIFilteringSettingFile = ConfigFolder + System.IO.Path.DirectorySeparatorChar + "DefaultCXDIFilteringSetting.csv";
        /// <summary>
        /// Get default CCS keyword count setting file path
        /// </summary>
        public static string DefaultCCSKeywordSettingFile = ConfigFolder + System.IO.Path.DirectorySeparatorChar + "DefaultCCSKeywordSetting.csv";
        /// <summary>
        /// Get default CXDI keyword count setting file path
        /// </summary>
        public static string DefaultCXDIKeywordSettingFile = ConfigFolder + System.IO.Path.DirectorySeparatorChar + "DefaultCXDIKeywordSetting.csv";
        /// <summary>
        /// Get default CCS log setting file path
        /// </summary>
        public static string DefaultCCSLogSettingFile = ConfigFolder + System.IO.Path.DirectorySeparatorChar + "DefaultCCSLogSetting.csv";
        /// <summary>
        /// Get default CXDI log setting file path
        /// </summary>
        public static string DefaultCXDILogSettingFile = ConfigFolder + System.IO.Path.DirectorySeparatorChar + "DefaultCXDILogSetting.csv";
        /// <summary>
        /// Get default CCS pattern setting file path
        /// </summary>
        public static string DefaultCCSPatternSettingFile = ConfigFolder + System.IO.Path.DirectorySeparatorChar + "DefaultCCSPatternSetting.xml";
        /// <summary>
        /// Get default CXDI pattern setting file path
        /// </summary>
        public static string DefaultCXDIPatternSettingFile = ConfigFolder + System.IO.Path.DirectorySeparatorChar + "DefaultCXDIPatternSetting.xml";
        /// <summary>
        /// Get user action list file path
        /// </summary>
        public static string UserActionList = ActionListFolder + System.IO.Path.DirectorySeparatorChar + "UserActionList.csv";
        /// <summary>
        /// Get error action list file path
        /// </summary>
        public static string ErrorActionList = ActionListFolder + System.IO.Path.DirectorySeparatorChar + "ErrorActionList.csv";

        /// <summary>
        /// Build list default value for CCS display log setting
        /// </summary>
        /// <returns>List of LogDisPlaySetting</returns>
        public static List<LogDisplay> SystemCCSLogSetting()
        {
            List<LogDisplay> DisplaySetting = new List<LogDisplay>();
            LogDisplay logDisplay = new LogDisplay();
            logDisplay.key = "Bookmark";
            logDisplay.value = true;
            DisplaySetting.Add(logDisplay);

            logDisplay = new LogDisplay();
            logDisplay.key = "Line";
            logDisplay.value = true;
            DisplaySetting.Add(logDisplay);

            logDisplay = new LogDisplay();
            logDisplay.key = "Date";
            logDisplay.value = true;
            DisplaySetting.Add(logDisplay);

            logDisplay = new LogDisplay();
            logDisplay.key = "Time";
            logDisplay.value = true;
            DisplaySetting.Add(logDisplay);

            logDisplay = new LogDisplay();
            logDisplay.key = "LogType";
            logDisplay.value = true;
            DisplaySetting.Add(logDisplay);

            logDisplay = new LogDisplay();
            logDisplay.key = "HostName";
            logDisplay.value = false;
            DisplaySetting.Add(logDisplay);

            logDisplay = new LogDisplay();
            logDisplay.key = "ThreadId";
            logDisplay.value = false;
            DisplaySetting.Add(logDisplay);

            logDisplay = new LogDisplay();
            logDisplay.key = "LogId";
            logDisplay.value = false;
            DisplaySetting.Add(logDisplay);

            logDisplay = new LogDisplay();
            logDisplay.key = "Content";
            logDisplay.value = true;
            DisplaySetting.Add(logDisplay);

            logDisplay = new LogDisplay();
            logDisplay.key = "AdditionalInfo";
            logDisplay.value = false;
            DisplaySetting.Add(logDisplay);

            logDisplay = new LogDisplay();
            logDisplay.key = "PersonalInfo";
            logDisplay.value = false;
            DisplaySetting.Add(logDisplay);

            logDisplay = new LogDisplay();
            logDisplay.key = "ClassName";
            logDisplay.value = false;
            DisplaySetting.Add(logDisplay);

            logDisplay = new LogDisplay();
            logDisplay.key = "Comment";
            logDisplay.value = true;
            DisplaySetting.Add(logDisplay);
            return DisplaySetting;
        }
        /// <summary>
        /// Define max string length
        /// </summary>
        public const int MaxStringLength = 50;
        /// <summary>
        /// Defined for the first axis Y is set
        /// </summary>
        public static bool Is1stTimeSetFirstYRange = true;
        /// <summary>
        /// Defined for the second axis Y is set
        /// </summary>
        public static bool Is1stTimeSetSecondYRange = true;
        /// <summary>
        /// Defined for the date range is set
        /// </summary>
        public static bool Is1stTimeSetDateRange = true;
        /// <summary>
        /// Get <see cref="GraphRangeSetting"/>
        /// </summary>
        public static GraphRangeSetting GraphRangeSettingValue = null;

        /// <summary>
        /// Build list default value for CXDI display log setting
        /// </summary>
        /// <returns>List of column to displayed on data grid</returns>
        public static List<LogDisplay> SystemCXDILogSetting()
        {
            List<LogDisplay> DisplaySetting = new List<LogDisplay>();
            LogDisplay logDisplay = new LogDisplay();
            logDisplay.key = "Bookmark";
            logDisplay.value = true;
            DisplaySetting.Add(logDisplay);

            logDisplay = new LogDisplay();
            logDisplay.key = "Line";
            logDisplay.value = true;
            DisplaySetting.Add(logDisplay);

            logDisplay = new LogDisplay();
            logDisplay.key = "Date";
            logDisplay.value = true;
            DisplaySetting.Add(logDisplay);

            logDisplay = new LogDisplay();
            logDisplay.key = "Time";
            logDisplay.value = true;
            DisplaySetting.Add(logDisplay);

            logDisplay = new LogDisplay();
            logDisplay.key = "Module";
            logDisplay.value = true;
            DisplaySetting.Add(logDisplay);

            logDisplay = new LogDisplay();
            logDisplay.key = "Message";
            logDisplay.value = true;
            DisplaySetting.Add(logDisplay);

            logDisplay = new LogDisplay();
            logDisplay.key = "Comment";
            logDisplay.value = true;
            DisplaySetting.Add(logDisplay);
            return DisplaySetting;

        }


        
        /// <summary>
        /// Get default path for memo file
        /// </summary>
        public static string DefaultMemoFolderPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + System.IO.Path.DirectorySeparatorChar + "Memo" + System.IO.Path.DirectorySeparatorChar;
        /// <summary>
        /// Get Definition of CCS memo file name format
        /// </summary>
        public static string CCSMemoFileNameFormat = "{0}MemoCCS{1}.xml";
        /// <summary>
        /// Get Definition of CXDI memo file name format
        /// </summary>
        public static string CXDIMemoFileNameFormat = "{0}MemoCXDI{1}.xml";
        /// <summary>
        /// Definition for error year in CXDI log file
        /// </summary>
        public static string SensorInitTime = "1997";
        /// <summary>
        /// Definition for OR operation keyword for pattern filtering
        /// </summary>
        public static string SEARCH_KEY_OR = "+";
        /// <summary>
        /// Definition for AND operation keyword for pattern filtering
        /// </summary>
        public static string SEARCH_KEY_AND = " ";
        /// <summary>
        /// Definition file name for exporting graph to image
        /// </summary>
        public static string ExportedGraphImageFileName = "GraphImage";
        /// <summary>
        /// Definition extension file for exporting graph
        /// </summary>
        public static string ExportedGraphImageFileExtension = "png";
        /// <summary>
        /// Definition extension file filtering for exporting graph
        /// </summary>
        public static string ExportedGraphImageFileFilter = "PNG Image (.png)|*.png|BMP Image (.bmp)|*.bmp";
        /// <summary>
        /// Definition file name for exporting graph to CSV
        /// </summary>
        public static string ExportedGraphCSVResultFileName = "GraphResult";
        /// <summary>
        /// Definition extension file for exporting graph to CSV
        /// </summary>
        public static string ExportedGraphCSVResultFileExtension = "csv";
        /// <summary>
        /// Definition extension file filtering for exporting graph to CSV
        /// </summary>
        public static string ExportedGraphCSVResultFileFilter = "CSV Comma-separated values (.csv)|*.csv";
        /// <summary>
        /// Get <see cref="FilterItemSetting"/> for none color filter item case
        /// </summary>
        public static FilterItemSetting NoneColorFilterItem { get; private set; }
        /// <summary>
        /// Get <see cref="FilterItemSetting"/> for default color filter item case
        /// </summary>
        public static FilterItemSetting DefaultColorFilterItem { get; private set; }
        /// <summary>
        /// Get <see cref="FilterItemSetting"/> for default pattern
        /// </summary>
        public static FilterItemSetting DefaultPatternItem { get; private set; }
        /// <summary>
        /// Get default font size
        /// </summary>
        public static int DefaultFontSize { get; private set; }
        /// <summary>
        /// Get delta font size
        /// </summary>
        public static int DeltaFontSize { get; private set; }
        /// <summary>
        /// Get minimum font size
        /// </summary>
        public static int MinimunFontSize { get; private set; }
        /// <summary>
        /// Get maximum font size
        /// </summary>
        public static int MaximunFontSize { get; private set; }
        /// <summary>
        /// Get CCS file filter string
        /// </summary>
        public static string CCSFileFilter { get; private set; }
        /// <summary>
        /// Get CXDI file filter string
        /// </summary>
        public static string CXDIFileFilter { get; private set; }
        /// <summary>
        /// Get memo file filter string
        /// </summary>
        public static string MemoFilterFile { get; private set; }
        /// <summary>
        /// Get background color for default filter item
        /// </summary>
        public static string DefaultFilterItemBackgroundColor { get; private set; }
        /// <summary>
        /// Get foreground color for default filter item
        /// </summary>
        public static string DefaultFilterItemForegroundColor { get; private set; }
        /// <summary>
        /// Get font style for default filter item
        /// </summary>
        public static string DefaultFilterItemFontStyle { get; private set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        static ConfigValue()
        {
            DefaultFontSize = 8;
            MinimunFontSize = 3;
            MaximunFontSize = 18;
            DeltaFontSize = 1;
            CCSFileFilter = "CCS Log (*.txt;*.csv)|*.txt;*.csv|All files (*.*)|*.*";
            CXDIFileFilter = "CXDI Log(*.log)|*.log|All files (*.*)|*.*";
            MemoFilterFile = "Memo(*.xml)|*.xml";
            TxtExtension = ".txt";
            CsvExtension = ".csv";
            LogExtension = ".log";
            DefaultFilterItemBackgroundColor = "#FFFFFF";
            DefaultFilterItemForegroundColor = "#000000";
            DefaultFilterItemFontStyle = FilterSettingFontStyles.NORMAL;

            NoneColorFilterItem = new FilterItemSetting()
            {
                Enabled = true,
                Foreground = "#000",
                Background = "#00FFFFFF",
                Name = String.Empty,
                IsPattern = false
            };

            DefaultColorFilterItem = new FilterItemSetting()
            {
                Enabled = true,
                Foreground = "#000",
                Background = "#FD720C",
                Name = String.Empty,
                IsPattern = false
            };

            DefaultPatternItem = new FilterItemSetting()
            {
                Enabled = true,
                Foreground = "#000",
                Background = "#FD720C",
                Name = String.Empty,
                IsPattern = true
            };
        }
        /// <summary>
        /// Static class for Definition base log header info
        /// </summary>
        public class BaseLogHeader
        {
            /// <summary>
            /// Bookmark header
            /// </summary>
            public const String HEADER_BOOKMARK = "Bookmark";
            /// <summary>
            /// Line header
            /// </summary>
            public const String HEADER_LINE = "Line";
            /// <summary>
            /// Date header
            /// </summary>
            public const String HEADER_DATE = "Date";
            /// <summary>
            /// Time header
            /// </summary>
            public const String HEADER_TIME = "Time";
            /// <summary>
            /// File name header
            /// </summary>
            public const String HEADER_FILENAME = "HEADER_FILENAME";

        }
        /// <summary>
        /// Static class for Definition CCS log header info
        /// </summary>
        public class CCSHeader : BaseLogHeader
        {
            /// <summary>
            /// Host name header
            /// </summary>
            public const String HEADER_HOSTNAME = "HostName";
            /// <summary>
            /// Thread id header
            /// </summary>
            public const String HEADER_THREADID = "ThreadId";
            /// <summary>
            /// Type header
            /// </summary>
            public const String HEADER_TYPE = "LogType";
            /// <summary>
            /// Content header
            /// </summary>
            public const String HEADER_CONTENT = "Content";
            /// <summary>
            /// Id header
            /// </summary>
            public const String HEADER_ID = "LogId";
            /// <summary>
            /// Addition info header
            /// </summary>
            public const String HEADER_ADDITIONINFO = "AdditionalInfo";
            /// <summary>
            /// Personal info header
            /// </summary>
            public const String HEADER_PERSONALINFO = "PersonalInfo";
            /// <summary>
            /// Class name header
            /// </summary>
            public const String HEADER_CLASSNAME = "ClassName";
            /// <summary>
            /// Comment header
            /// </summary>
            public const String HEADER_COMMENT = "Comment";
            /// <summary>
            /// Mode header
            /// </summary>
            public const String HEADER_MODE = "Mode";
            /// <summary>
            /// Error message header
            /// </summary>
            public const String HEADER_ERRORMESSAGE = "ErrorMessage";
            /// <summary>
            /// Error recipe header
            /// </summary>
            public const String HEADER_ERRORRECIPE = "ErrorRecipe";
            /// <summary>
            /// User action header
            /// </summary>
            public const String HEADER_USERACTION = "UserAction";
            /// <summary>
            /// Error code header
            /// </summary>
            public const String HEADER_ERRORCODE = "ErrorCode";
            /// <summary>
            /// Get all header
            /// </summary>
            public static List<string> AllLogField { get; private set; }
            /// <summary>
            /// Default constructor
            /// </summary>
            static CCSHeader()
            {
                AllLogField = new List<string>()
                {
                    HEADER_LINE,
                    HEADER_DATE,
                    HEADER_TIME,
                    HEADER_HOSTNAME,
                    HEADER_THREADID,
                    HEADER_TYPE,
                    HEADER_ID,
                    HEADER_CONTENT,
                    HEADER_ADDITIONINFO,
                    HEADER_PERSONALINFO,
                    HEADER_CLASSNAME,
                    HEADER_COMMENT
                    
                };
            }

        }
        /// <summary>
        /// Static class for Definition CXDI log header info
        /// </summary>

        public class CXDIHeader : BaseLogHeader
        {
            public const String HEADER_MESSAGE = "Message";
            public const String HEADER_MODULE = "Module";
            public const String HEADER_COMMENT = "Comment";
            public static List<string> AllLogField { get; private set; }
            static CXDIHeader()
            {
                AllLogField = new List<string>()
                {
                    HEADER_LINE,
                    HEADER_DATE,
                    HEADER_TIME,
                    HEADER_MODULE,
                    HEADER_MESSAGE,
                    HEADER_COMMENT
                };
            }
        }
        /// <summary>
        /// Static class provides Definitions for log type when searching
        /// </summary>

        public class LogKindTarget
        {
            /// <summary>
            /// Is CCS log type
            /// </summary>
            public const String CCS = "LogKindTarget_CCS";
            /// <summary>
            /// Is CXDI log type
            /// </summary>
            public const String CXDI = "LogKindTarget_CXDI";
            /// <summary>
            /// Is CXDI and CCS log type
            /// </summary>
            public const String CCS_CXDI = "LogKindTarget_CCS_CXDI";
            /// <summary>
            /// Get all log type
            /// </summary>
            public static List<string> AllLogKindTarget { get; private set; }
            /// <summary>
            /// Default constructor
            /// </summary>
            static LogKindTarget()
            {
                AllLogKindTarget = new List<string>()
                {
                    CCS,
                    CXDI,
                    CCS_CXDI
                };
            }
        }
        /// <summary>
        /// Static class for font style Definition
        /// </summary>
        public class FilterSettingFontStyles
        {
            /// <summary>
            /// Get normal font type
            /// </summary>
            public const String NORMAL = "Normal";
            /// <summary>
            /// Get bold font type
            /// </summary>
            public const String BOLD = "Bold";
            /// <summary>
            /// Get italic font style
            /// </summary>
            public const String ITALIC = "Italic";
            /// <summary>
            /// Get bold and italic font type
            /// </summary>
            public const String BOLDITALIC = "BoldItalic";
            /// <summary>
            /// Get all font styles
            /// </summary>
            public static List<string> AllFontStyle { get; private set; }
            static FilterSettingFontStyles()
            {
                AllFontStyle = new List<string>()
                {
                    NORMAL,
                    BOLD,
                    ITALIC,
                    BOLDITALIC
                };
            }
        }
        /// <summary>
        /// Static class for time unit Definition
        /// </summary>
        public class TimeUnits
        {
            /// <summary>
            /// Get hour symbol
            /// </summary>
            public const string H = "h";
            /// <summary>
            /// Get minute
            /// </summary>
            public const string M = "m";
            /// <summary>
            /// Get second
            /// </summary>
            public const string S = "s";
            /// <summary>
            /// Get millisecond
            /// </summary>
            public const string MS = "ms";
            /// <summary>
            /// Get all time units
            /// </summary>
            public static List<string> AllTimeUnit { get; private set; }
            static TimeUnits()
            {
                AllTimeUnit = new List<string>()
                {
                    H,
                    M,
                    S,
                    MS
                };
            }
        }

        /// <summary>
        /// Get TXT extension
        /// </summary>
        public static string TxtExtension { get; set; }
        /// <summary>
        /// Get CSV extension
        /// </summary>
        public static string CsvExtension { get; set; }
        /// <summary>
        /// Get log extension
        /// </summary>
        public static string LogExtension { get; set; }
        /// <summary>
        /// Definition for counter parameter
        /// </summary>
        public const string COUNTER_PARAMETER = "--------[counter parameter]--------";
        /// <summary>
        /// Definition for saved parameter
        /// </summary>

        public const string SAVE_PARAMETER = "---------[saved parameter]---------";
        /// <summary>
        /// Definition for error parameter
        /// </summary>
        public const string MESSAGE_ERROR_LOG = "--------[message error Log]--------";
        /// <summary>
        /// Definition for end counter parameter
        /// </summary>
        public const string END_COUNTER_PARAMETER = "-----------------------------------";
        /// <summary>
        /// Definition for message log
        /// </summary>
        public const string MESSAGE_LOG = "-----------[message Log]-----------";
        /// <summary>
        /// Definition for used color in pattern highlight
        /// </summary>
        public static List<string> listColor = new List<string> {"#6B8E23", "#D2691E", "#3CB371", "#458B00", 
            "#528B8B", "#54FF9F", "#9ACD32", "#43CD80", 
            "#4EEE94", "#548B54", "#00FF00", "#20B2AA", "#ADFF2F", "#9ACD32", "#698B22", "#66CD00", 
            "#FFD39B", "#79CDCD", "#7CCD7C", "#7CFC00", "#7FFF00", "#7FFF00", "#76EE00", "#FF7F24", "#F5FFFA",
            "#9BCD9B", "#8FBC8F", "#32CD32", "#8DEEEE", "#90EE90", "#CAFF70", "#8B6969", "#8B7355", "#228B22", 
            "#97FFFF", "#FF4040", "#F0E68C", "#00FF00", "#00EE76", "#C1FFC1", "#C6E2FF", "#8B4513", "#A2CD5A", 
            "#EE3B3B", "#2E8B57", "#D2B48C", "#CD9B9B", "#8B5A2B", "#BDB76B", "#CD661D", "#FFA54F", "#00FF7F", 
            "#556B2F", "#90EE90", "#008B45", "#00EE00", "#00CD00", "#00FA9A", "#CDC673", 
            "#EEB4B4", "#EE9A49", "#2E8B57", "#9AFF9A", "#EEE685", "#6C7B8B", "#B9D3EE", "#00FF7F", 
            "#98FB98", "#9FB6CD", "#CD3333", "#8B4513", "#EE7621", "#B3EE3A", "#CD853F", "#A52A2A", "#B4EEB4", 
            "#C0FF3E", "#6E8B3D", "#F4A460", "#FFF68F", "#8B2323", "#BCEE68", "#CD853F", "#CDAA7D", "#F5F5DC", 
            "#DEB887", "#FFC1C1", "#8B864E", "#EEC591", "#00CD66"
};
        /// <summary>
        /// Limit filter item
        /// </summary>
        public static int LimitFilterItem = 15;
    }
}

