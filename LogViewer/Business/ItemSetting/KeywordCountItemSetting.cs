using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;

namespace LogViewer.Business
{
    /// <summary>
    /// Class provides method for containing keyword count parameter
    /// </summary>
    public class KeywordCountItemSetting : BaseItemSetting, ILogItemSearch, ICopyable<KeywordCountItemSetting>
    {

        protected string _stringValue;
        /// <summary>
        /// Get or set value of keyword
        /// </summary>
        public string StringValue
        {
            get
            {
                return _stringValue;
            }
            set
            {
                if (value != null)
                    value = value.Trim();
                _stringValue = value;
            }
        }
        /// <summary>
        /// Get or set name of log record
        /// </summary>
        public string LogItem { get; set; }
        /// <summary>
        /// Clone to new object
        /// </summary>
        /// <returns><see cref="KeywordCountItemSetting"/></returns>
        public KeywordCountItemSetting Copy()
        {
            KeywordCountItemSetting temp = new KeywordCountItemSetting();
            temp.Enabled = this.Enabled;
            temp.Id = this.Id;
            temp.LogItem = this.LogItem;
            temp.Name = this.Name;
            temp.StringValue = this.StringValue;
            return temp;
        }
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
                    //hard code
                    case "StringValue":
                        errorMessage = ValidateStringValue();
                        break;
                    case "LogItem":
                        errorMessage = ValidateLogItemValue();
                        break;
                    default:
                        errorMessage = base[propertyName];
                        break;
                }
                return errorMessage;
            }
        }
        /// <summary>
        /// Validate for a keyword count setting object have valid data or not.
        /// This method will valid on properties: Name, StringValue and LogItem
        /// </summary>
        /// <param name="logDisplayHeader">List of system log header <see cref="BaseSettingManager.GetLogHeader()"/></param>
        /// <returns></returns>
        public bool ValidDate(List<string> logDisplayHeader)
        {
            if (this["Name"] != string.Empty) return false;
            if (this["StringValue"] != string.Empty) return false;
            if (this["LogItem"] != string.Empty) return false;
            if (logDisplayHeader.Where(item => item.Equals(LogItem)).Count() == 0) return false;
            return true;
        }
        private string ValidateStringValue()
        {
            if (String.IsNullOrEmpty(StringValue.Trim()))
                return Properties.Resources.ValidateEmptyStringMessage;
            //hard code.
            else if (this.StringValue.Length > 50)
                return Properties.Resources.ValidateLengthKeywordMessage;
            else
                return String.Empty;
        }

        private string ValidateLogItemValue()
        {
            if (String.IsNullOrEmpty(LogItem))
                return Properties.Resources.ValidateEmptyStringMessage;
            else
                return String.Empty;
        }

    }
}
