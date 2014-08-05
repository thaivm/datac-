using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.Model
{
    /// <summary>
    /// Model class for storing information of string in a given line of log <seealso cref="AnalyzePattern"/>
    /// </summary>
    /// <typeparam name="TString">Pattern string</typeparam>
    /// <typeparam name="TIndex">Index of string </typeparam>
    /// <typeparam name="TLine">Line of log record</typeparam>
    /// <typeparam name="TLevel">Level of key string</typeparam>
    /// <typeparam name="TDateTime">Date time of log record</typeparam>
    public class StringLineIndexLevelPair<TString, TIndex, TLine, TLevel, TDateTime>
    {
        /// <summary>
        /// Get or set pattern string
        /// </summary>
        public TString String { get; set; }
        /// <summary>
        /// Get or set index of string
        /// </summary>
        public TIndex Index { get; set; }
        /// <summary>
        /// Get or set line of log record
        /// </summary>
        public TLine Line { get; set; }
        /// <summary>
        /// Get or set level of key string
        /// </summary>
        public TLevel Level { get; set; }
        /// <summary>
        /// Get or set date time of log record
        /// </summary>
        public TDateTime DateTime { get; set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="str">Pattern string</param>
        /// <param name="index">Index of string</param>
        /// <param name="line">Line for log record</param>
        /// <param name="level">Level of key string</param>
        /// <param name="dateTime">Date time of log record</param>
        public StringLineIndexLevelPair(TString str, TIndex index, TLine line, TLevel level, TDateTime dateTime)
        {
            String = str;
            Index = index;
            Line = line;
            Level = level;
            DateTime = dateTime;
        }
    }
}
