using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace LogViewer.Business
{
    /// <summary>
    /// Base Class provides common method for process item setting
    /// </summary>
    abstract public class BaseItemSetting : IDataErrorInfo
    {
        /// <summary>
        /// Get or set ID
        /// </summary>
        public String Id { get; set; }
        protected string _name;
        /// <summary>
        /// Get or set Name
        /// </summary>
        public String Name 
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != null)
                    value = value.Trim();
                _name = value;
            }
        }
        /// <summary>
        /// Get or set status of item
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// Get error string.
        /// </summary>
        public string Error { get { return string.Empty ; } }
        /// <summary>
        /// Reference to properties as index of array. Use for checking a properties is valid or not.
        /// </summary>
        /// <param name="propertyName">Properties name</param>
        /// <returns>Empty string when a properties is valid data.</returns>
        public virtual string this[string propertyName]
        {
            get
            {
                string errorMessage = String.Empty;
                switch (propertyName)
                {
                    //hard code.
                    case "Name":
                        errorMessage = ValidateName();
                        break;
                }
                return errorMessage;
            }
        }
        private string ValidateName()
        {
            if (String.IsNullOrEmpty(this.Name)||string.IsNullOrEmpty(this.Name.Trim()))
                return Properties.Resources.ValidateEmptyNameMessage;
            else if (this.Name.Length > 50)
                return Properties.Resources.ValidateLengthNameMessage;
            else
                return String.Empty;
        }
    }
}
