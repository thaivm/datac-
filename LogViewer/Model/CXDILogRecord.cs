using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.Model
{
    /// <summary>
    /// Model class for storing information of CXDI log record
    /// </summary>
    public class CXDILogRecord : BaseLogRecord
    {
        /// <summary>
        /// Get or set module
        /// </summary>
        public String Module { get; set; }
        /// <summary>
        /// Get or set message
        /// </summary>
        public String Message { get; set; }
    }
}
