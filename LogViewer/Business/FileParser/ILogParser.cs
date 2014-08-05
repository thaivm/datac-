using System;
using System.Collections.Generic;
using System.IO;
using System.Collections.ObjectModel;
using LogViewer.Business;
using LogViewer.Model;

namespace LogViewer.Business
{
    /// <summary>
    /// Interface must be extend for all log parser class
    /// </summary>
    /// <typeparam name="T">Type of log record: CCSLogRecord or CXDILogRecord</typeparam>
    public interface ILogParser<T>
    {
        /// <summary>
        /// Extract log record from a file
        /// </summary>
        /// <param name="FilePath">Location of file</param>
        /// <returns>List of log record. Where T is type of log record: CCSLogRecord or CXDILogRecord class</returns>
        List<T> ParserFromFile(String FilePath);
        /// <summary>
        /// Extract log record from a file
        /// </summary>
        /// <param name="reader">log content hold by StringReader object</param>
        /// <returns>List of log record. Where T is type of log record: CCSLogRecord or CXDILogRecord class</returns>
        List<T> ParserFromFile(StringReader reader);
    }
    /// <summary>
    /// Inteface must be extent for all memo log parser class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILogMemoParser<T> : ILogParser<T>
    {
        /// <summary>
        /// Extract log record and memo from an XML file
        /// </summary>
        /// <param name="filePath">Location of the file</param>
        /// <returns>Object is type of MemoLog which is content all log record extracted and memo information (bookmarks, comments)</returns>
        new MemoLog<T> ParserFromFile(String filePath);
        /// <summary>
        /// Export log record, bookmarks and comments to XML file.
        /// </summary>
        /// <param name="filePath">Location of file</param>
        /// <returns>True: when export successfully, otherwise is False</returns>
        bool WriteMemoLogFile(string filePath);

    }
}
