using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Model;
using System.Diagnostics;

namespace LogViewer.Business.ItemSetting
{
    /// <summary>
    /// Class provide object for holding founded pattern of pattern analyze process
    /// </summary>
    /// <typeparam name="T">Generic class, can be: <see cref="CCSLogRecord"/> or <see cref="CXDILogRecord"/>
    /// </typeparam>
    public class FoundPattern<T> where T:BaseLogRecord
    {
        PatternItemSetting _pattern;
        /// <summary>
        /// Get or set <see cref="PatternItemSetting"/>, used for search pattern
        /// </summary>
        public PatternItemSetting Pattern
        {
            get { return _pattern; }
            set { _pattern = value; }
        }
        /// <summary>
        /// Default constructor, new object created will initialize for <seealso cref="LogRecords"/> and <see cref="Pattern"/>
        /// </summary>
        /// <param name="pattern"><see cref="PatternItemSetting"/></param>
        public FoundPattern(PatternItemSetting pattern)
        {
            _logRecords = new List<T>();
            _pattern = pattern;
        }
        /// <summary>
        /// Get or set date time of root key record.
        /// </summary>
        public DateTime RootKeyRecordDateTime { get; set; }
        /// <summary>
        /// Get or set root key. Where T is generic class, can be: <see cref="CCSLogRecord"/> or <see cref="CXDILogRecord"/>
        /// </summary>
        public T RootKeyRecord { get; set; }
        List<T> _logRecords;
        /// <summary>
        /// Get list of log record that was founded by pattern analyze process.
        /// </summary>
        public List<T> LogRecords
        {
            get { return _logRecords; }
        }
    }
}
