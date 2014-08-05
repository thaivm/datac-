using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.Model
{
    /// <summary>
    /// Model class for storing key found when analyze pattern. <seealso cref="AnalyzePattern"/>
    /// </summary>
    /// <typeparam name="TLine">Line of generic log record, the log record can be <see cref="CCSLogRecord"/> or <see cref="CXDILogRecord"/></typeparam>
    /// <typeparam name="TKey">Key of generic log record, the log record can be <see cref="CCSLogRecord"/> or <see cref="CXDILogRecord"/></typeparam>
    /// <typeparam name="TIndex">Level of key</typeparam>
    /// <typeparam name="TRecord">Generic log record, the log record can be <see cref="CCSLogRecord"/> or <see cref="CXDILogRecord"/></typeparam>
    /// <typeparam name="TColor">Color of generic log record, the log record can be <see cref="CCSLogRecord"/> or <see cref="CXDILogRecord"/></typeparam>
    public class KeyIndexRecordPair<TLine, TKey, TIndex, TRecord, TColor>
    {
        /// <summary>
        /// Get or set line <seealso cref="TLine"/>
        /// </summary>
        public TLine Line { get; set; }
        /// <summary>
        /// Get or set key <seealso cref="TKey"/>
        /// </summary>
        public TKey Key { get; set; }
        /// <summary>
        /// Get or set index <seealso cref="TIndex"/>
        /// </summary>
        public TIndex Index { get; set; }
        /// <summary>
        /// Get or set record <seealso cref="TRecord"/>
        /// </summary>
        public TRecord Record { get; set; }
        /// <summary>
        /// Get or set color <seealso cref="TColor"/>
        /// </summary>
        public TColor Color { get; set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="line"><see cref="TLine"/></param>
        /// <param name="key"><see cref="TKey"/></param>
        /// <param name="index"><see cref="TIndex"/></param>
        /// <param name="record"><see cref="TRecord"/></param>
        public KeyIndexRecordPair(TLine line, TKey key, TIndex index, TRecord record)
        {
            Line = line;
            Key = key;
            Index = index;
            Record = record;
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public KeyIndexRecordPair()
        { }
    }
}
