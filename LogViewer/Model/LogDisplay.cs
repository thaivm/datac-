using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.Model
{
    /// <summary>
    /// Model class for storing information of log display parameter
    /// </summary>
    public class LogDisplay
    {
        /// <summary>
        /// Get or set key
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// Get or set value
        /// </summary>
        public bool value { get; set; }
        /// <summary>
        /// Valid input data for log display item
        /// </summary>
        /// <param name="logDisplayHeader">List of system log display item. <seealso cref="ConfigValue.SystemCCSLogSetting()"/></param>
        /// <returns>True: if item is valid; False: is otherwise</returns>
        public bool ValidDate(List<LogDisplay> logDisplayHeader) {
            if (key == null || key == string.Empty) return false;
            if (logDisplayHeader == null || logDisplayHeader.Count == 0) return false;
            if(logDisplayHeader.Where(item=>item.key.Equals(key)).Count()==0) return false;
            return true;
        }
    }
}
