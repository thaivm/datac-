using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LogViewer.Model
{
    /// <summary>
    /// Model class for base log record
    /// </summary>
    public class BaseLogRecord
    {
        /// <summary>
        /// Get or set line number
        /// </summary>
        public int Line { get; set; }
        private DateTime _datetime;
        /// <summary>
        /// Get or set date time of log record
        /// </summary>
        public DateTime DateTime { get { return _datetime ;}set{_datetime=value;} }
        /// <summary>
        /// Get date
        /// </summary>
        public String Date { get {return _datetime.ToString("yyyy/MM/dd");} }
        /// <summary>
        /// Get time
        /// </summary>
        public String Time { get{return _datetime.ToString("HH:mm:ss.fff");} }
    }
}
