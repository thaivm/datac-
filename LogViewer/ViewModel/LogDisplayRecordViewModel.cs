using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// ViewModel contains data of log display in data grid, ex: Column line, data, content is show or hide in grid 
    /// </summary>
    public class LogDisplayRecordViewModel : BaseViewModel
    {
        /// <summary>
        /// Get and set Key property
        /// </summary>
        protected string _key;
        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
            }
        }
        /// <summary>
        /// Get and Set DisplayKey
        /// </summary>
        public string DisplayKey { get; set; }
        /// <summary>
        /// Get and set Value 
        /// </summary>
        protected bool _value;
        public bool Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }
        /// <summary>
        /// Initializes a new instance of the LogDisplayRecordViewModel class.
        /// </summary>
        /// <param name="logDisplay"><see cref="LogDisplay"/></param>
        public LogDisplayRecordViewModel(LogDisplay logDisplay)
        {
            Value = logDisplay.value;
            Key = logDisplay.key;
            DisplayKey = Util.Utility.Translate(Key);
        }
    }
}
