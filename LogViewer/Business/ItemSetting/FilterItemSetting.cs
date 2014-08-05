using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Media;
using LogViewer.Model;
namespace LogViewer.Business
{
    /// <summary>
    /// Class provides method for containing filter parameter
    /// </summary>
    public class FilterItemSetting : BaseItemSetting, ILogItemSearch, ICopyable<FilterItemSetting>
    {
        /// <summary>
        /// Get or set pattern color
        /// </summary>
        public object PatternColor { get; set; }
        /// <summary>
        /// Get or set font style
        /// </summary>
        public string FontStyle { get; set; }
        /// <summary>
        /// Get or set foreground
        /// </summary>
        public String Foreground { get; set; }
        /// <summary>
        /// Get or set background
        /// </summary>
        public String Background { get; set; }
        /// <summary>
        /// Get or set is pattern for indicated that is not a filter object.
        /// </summary>
        public bool IsPattern { get; set; }
        protected string _stringValue;
        /// <summary>
        /// Get or set value for filter
        /// </summary>
        public string StringValue 
        {
            get
            {
                return _stringValue;
            }
            set
            {
                //if (value != null)
                //    value = value.Trim();
                _stringValue = value;
            }
        }
        /// <summary>
        /// Get or set name of column for filtering on
        /// </summary>
        public string LogItem { get; set; }
        /// <summary>
        /// Get or set index of filter item
        /// </summary>
        public int index { get; set; }
        /// <summary>
        /// Get or set list of position that occurred filter value in string
        /// </summary>
        public List<int> listIndex { get; set; }
        /// <summary>
        /// Reference to properties as index of array. Use for checking a properties is valid or not.
        /// </summary>
        /// <param name="propertyName">Properties name</param>
        /// <returns>Empty string when a properties is valid data.</returns>
        public override string this[string propertyName]
        {
            get
            {
                string errorMessage = string.Empty;
                switch (propertyName)
                {
                    //hard code.
                    case "StringValue":
                        errorMessage = ValidateStringValue();
                        break;
                    default:
                        errorMessage = base[propertyName];
                        break;
                }
                return errorMessage;
            }
        }

        private string ValidateStringValue()
        {
            if (String.IsNullOrEmpty(StringValue.Trim()))
                return Properties.Resources.ValidateEmptyStringMessage;
            var allKeywords =GetKeywords();
            //hard code.
            if (allKeywords.Count > 5)
                return Properties.Resources.ValidateMaxKeywordCountMessage;
            //hard code.
            else if (allKeywords.Where(x => x.Count() > 50).Count() > 0)
                return Properties.Resources.ValidateLengthKeywordMessage;
            else
                return String.Empty;
        }

        private List<string> GetKeywords()
        {
            List<string> result = new List<string>();
            if (StringValue == null || StringValue == string.Empty) return result;
            var orList = Regex.Split(StringValue, Regex.Escape(ConfigValue.SEARCH_KEY_OR));
                foreach (var i in orList)
                {
                    foreach (var j in i.Split(new string[] {ConfigValue.SEARCH_KEY_AND},StringSplitOptions.RemoveEmptyEntries))
                    {
                        if(!String.IsNullOrEmpty(j))
                            result.Add(j);
                    }
                }
            return result;

        }
        /// <summary>
        /// Validate for a filter item setting object have valid data or not.
        /// This method will valid on properties: Name and StringValue
        /// </summary>
        /// <param name="logHeader">List of system log header <see cref="BaseSettingManager.GetLogHeader()"/></param>
        /// <returns>True:valid, False: not valid</returns>
        public bool IsValidDate(List<string> logHeader) {
            if (logHeader == null || logHeader.Count == 0) return false;
            if (ConfigValue.FilterSettingFontStyles.AllFontStyle.Where(fontname => fontname.Equals(FontStyle)).Count() == 0) return false;
            if (!IsAColor(Background)) return false;
            if (!IsAColor(Foreground)) return false;
            if (this["Name"] != string.Empty)
            {
                return false;
            }
            if (this["StringValue"] != string.Empty)
            {
                return false;
            }
            if (logHeader.Where(header => header.Equals(LogItem)).Count() == 0) return false;
            return true;
        }
        private bool IsAColor(string colorName)
        {
            try
            {
                System.Windows.Media.Color color = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(colorName);
                return true;
            }catch{}
            return false;
        }
        /// <summary>
        /// Clone to new object
        /// </summary>
        /// <returns></returns>
        public FilterItemSetting Copy()
        {
            FilterItemSetting temp = new FilterItemSetting();
            temp.FontStyle = this.FontStyle;
            temp.Background = this.Background;
            temp.Enabled = this.Enabled;
            temp.Foreground = this.Foreground;
            temp.Id = this.Id;
            temp.LogItem = this.LogItem;
            temp.Name = this.Name;
            temp.StringValue = this.StringValue;
            temp.index = this.index;
            temp.listIndex = this.listIndex;
            temp.IsPattern = this.IsPattern;
            return temp;
        }

    }
}
