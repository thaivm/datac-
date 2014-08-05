using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.Model
{
    /// <summary>
    /// Interface provide method for long item search
    /// </summary>
    public interface ILogItemSearch
    {
        /// <summary>
        /// Get or set string value of log item
        /// </summary>
        String StringValue { get; set; }
        /// <summary>
        /// Get or set name of log item
        /// </summary>
        String LogItem { get; set; }
    }
}
