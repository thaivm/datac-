using System;

namespace LogViewer.Model
{
    /// <summary>
    /// Model class for storing information of user action item
    /// </summary>
    public class UserActionItem
    {
        /// <summary>
        /// Get or set id
        /// </summary>
        public String ID { get; set; }
        /// <summary>
        /// Get or set reference system log
        /// </summary>
        public String RefSystemLog { get; set; }
        /// <summary>
        /// Get or set string message (user action)
        /// </summary>
        public String UserAction { get; set; }
    }
}
