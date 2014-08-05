using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.Model
{
    /// <summary>
    /// Model class for storing information of memo log extracted from data log file
    /// </summary>
    /// <typeparam name="T">Generic class, can be: <see cref="CCSLogRecord"/> or <see cref="CXDILogRecord"/></typeparam>
    public class MemoLog<T>
    {
        /// <summary>
        /// Default constructor initialize for <see cref="Bookmaks"/>, <see cref="Comments"/> and <see cref="Records"/>
        /// </summary>
        public MemoLog(){
            Bookmarks = new List<T>();
            Comments = new Dictionary<T, string>();
            Records = new List<T>();
        }
        /// <summary>
        /// Get or set list of bookmark
        /// </summary>
        public List<T> Bookmarks { set; get; }
        /// <summary>
        /// Get or set dictionary of comments
        /// </summary>
        public Dictionary<T, string> Comments { set; get; }
        /// <summary>
        /// Get or set list of log records
        /// </summary>
        public List<T> Records { set; get; }
    }
}
