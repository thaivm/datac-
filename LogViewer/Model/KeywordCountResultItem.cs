using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.Model
{
    /// <summary>
    /// Model class for storing key word count result item.
    /// </summary>
    public class KeywordCountResultItem
    {
        /// <summary>
        /// Get or set name
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// Get or set number or found keyword
        /// </summary>
        public ulong Count { get; set; }
    }
}
