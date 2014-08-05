using System;

namespace LogViewer.Model
{
    /// <summary>
    /// Model class for storing CCS log record information.
    /// </summary>
    public class CCSLogRecord : BaseLogRecord
    {
        /// <summary>
        /// Get or set host name
        /// </summary>
        public String HostName { get; set; }
        /// <summary>
        /// Get or set thread id
        /// </summary>
        public String ThreadId { get; set; }
        /// <summary>
        /// Get or set type
        /// </summary>
        public String Type { get; set; }
        /// <summary>
        /// Get or set id
        /// </summary>
        public String Id { get; set; }
        /// <summary>
        /// Get or set content data
        /// </summary>
        public String Content { get; set; }
        /// <summary>
        /// Get or set addition information
        /// </summary>
        public String AdditionalInfo { get; set; }
        /// <summary>
        /// Get or set personal information
        /// </summary>
        public String PersonalInfo { get; set; }
        /// <summary>
        /// Get or set class name
        /// </summary>
        public String ClassName { get; set; }
        /// <summary>
        /// Get or set module
        /// </summary>
        public String Module { get; set; }
        /// <summary>
        /// Get or set mode
        /// </summary>
        public String Mode { get; set; } 
    }
}
