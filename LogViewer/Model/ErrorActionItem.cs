using System;

namespace LogViewer.Model
{
    /// <summary>
    /// Model class for storing information of error action item
    /// </summary>
    public class ErrorActionItem
    {
        /// <summary>
        /// Get or set error level
        /// </summary>
        public String ErrorLv { get; set; }
        /// <summary>
        /// Get or set error code
        /// </summary>
        public String ErrorCode { get; set; }
        /// <summary>
        /// Get or set error message
        /// </summary>
        public String ErrorMessage { get; set; }
        /// <summary>
        /// Get or set error recipe
        /// </summary>
        public String ErrorRecipe { get; set; }
    }
}
