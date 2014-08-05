using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.Model
{
    /// <summary>
    /// Model class for storing keyword
    /// </summary>
    public class KeywordModel
    {
        protected string _value;
        /// <summary>
        /// Get or set keyword value
        /// </summary>
        public string Value 
        {
            get
            {
                return _value;
            }
            set
            {
                if (value != null)
                    value = value.Trim();
                _value = value;
            }
        }
        /// <summary>
        /// Get or set index of keyword
        /// </summary>
        public int Index { get; set; }
    }
}
