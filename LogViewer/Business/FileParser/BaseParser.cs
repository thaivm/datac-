using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using LogViewer.Business.FileParser;
using LogViewer.Model;
namespace LogViewer.Business
{
    /// <summary>
    /// Common base class for all type of parser class. Any parser class 
    /// (<see cref="CCSParserNew"/>, <see cref="CCSParserOld" />, <see cref="CCSMemoParserNew" />, <see cref="CCSMemoParserOld" />,
    ///  <see cref="CXDIParser" />, <see cref="CXDIMemoParser" /> or further other parser class) must be inherited this base class.
    /// </summary>
    /// <typeparam name="T">The type of record log file. 
    /// Type can be CCSLogRecord,  CXDILogRecord or any other log record that inherit from 
    /// BaseLogRecord class.
    /// </typeparam>
    public class BaseParser<T>
    {
        /// <summary>
        /// Collection of log records that being parsing from log file.
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyCollection<T> LogRecords { set; get; }
        /// <summary>
        /// Dictionary of comments where key T are log records and values are user comments for the records T.
        /// </summary>
        public Dictionary<T, string> Comments { set; get; }
        /// <summary>
        /// Dictionary of bookmark where key T are log records that user will set as bookmark.
        /// </summary>
        public ReadOnlyCollection<T> Bookmarks { set; get; }

    }
}
