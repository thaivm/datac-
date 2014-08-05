using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;

namespace LogViewer.Business
{
    /// <summary>
    /// Class store information of pattern setting
    /// </summary>
    public class PatternItemSetting : BaseItemSetting, ICopyable<PatternItemSetting>
    {
        /// <summary>
        /// Get or set Time for pattern. 
        /// </summary>
        public ulong Time { get; set; }
        /// <summary>
        /// Get or set unit of time: "H" or "h" for hour; "M" or "m" for minute; "S" or "s" for second
        /// </summary>
        public String TimeUnit { get; set; }
        protected String _rootKey;
        /// <summary>
        /// Get or set a string for root key
        /// </summary>
        public String RootKey 
        {
            get
            {
                return _rootKey;
            }
            set
            {
                if (value != null)
                    value = value.Trim();
                _rootKey = value;
            }
        }
        /// <summary>
        /// Get or set keys string
        /// </summary>
        public List<String> Keys { get; set; }
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
                    case "RootKey":
                        errorMessage = ValidateRootKey();
                        break;
                    default:
                        errorMessage = base[propertyName];
                        break;
                }
                return errorMessage;
            }
        }
        private string ValidateRootKey()
        {
            if (String.IsNullOrEmpty(RootKey.Trim()))
                return Properties.Resources.ValidateEmptyRootKeyMessage;
             //hard code.
            else if (this.RootKey.Length > 50)
                return Properties.Resources.ValidateLengthRootKeyMessage;
            else
                return String.Empty;
        }
        /// <summary>
        /// Clone object
        /// </summary>
        /// <returns><see cref="PatternItemSetting"/></returns>
        public PatternItemSetting Copy()
        {
            PatternItemSetting temp = new PatternItemSetting();
            temp.Keys = new List<string>();
            temp.Enabled = this.Enabled;
            temp.Id = this.Id;
            temp.Name = this.Name;
            temp.Keys = new List<string>();
            foreach (var i in this.Keys)
            {
                temp.Keys.Add(i);
            }
            temp.RootKey = this.RootKey;
            temp.Time = Time;
            temp.TimeUnit = this.TimeUnit;
            return temp;
        }
    }
}
