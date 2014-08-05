using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.Model
{
    /// <summary>
    /// Model class for storing information of search item.
    /// </summary>
    public class SearchItem : ILogItemSearch
    {
        /// <summary>
        /// Get or set search value
        /// </summary>
        public String StringValue { get; set; }
        /// <summary>
        /// Get or set column name of log record that will be search on.
        /// </summary>
        public String LogItem { get; set; }
    }
}
