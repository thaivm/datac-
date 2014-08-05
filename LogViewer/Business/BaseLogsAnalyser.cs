// File:    BaseLogsAnalyser.cs
// Author:  CuongPNB
// Created: Friday, April 18, 2014 2:23:45 PM
// Purpose: Definition of Class BaseLogsAnalyser

using System;
using System.Collections.Generic;
using LogViewer.Model;
using System.Collections.ObjectModel;
using System.Linq;
using LogViewer.Util;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using LogViewer.Business.FileParser;
namespace LogViewer.Business
{
    /// <summary>
    /// Base class for log analyze which provide common method for analyze log data.
    /// </summary>
    /// <typeparam name="T">Generic class, can be: <see cref="CCSLogRecord"/> or <see cref="CXDILogRecord"/></typeparam>
    public abstract class BaseLogsAnalyser<T> where T : BaseLogRecord
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        protected BaseLogsAnalyser()
        {
            _allLogRecordsBufferWithFileName = new Dictionary<string, List<T>>();
            _allLogRecordsBuffer = new List<T>();
            _bookmarkBuffer = new List<T>();
            _comments = new Dictionary<T, string>();
            _countKeywordBuffer = new List<AnalyzedCountKeywordItem>();
            _filteredLogRecordsBuffer = new List<T>();
            _patternAnalyzeBuffer = new List<AnalyzedPatternResultItem<T>>();
            _searchKeywordBuffer = new List<T>();
        }
        /// <summary>
        /// Use to search log record by a search item object. Search Item object have 2 properties:
        /// logItem and stringvalue, both of them must be set for searching. 
        /// </summary>
        /// <param name="searchItem">Two values must be set for searching:logItem and stringvalue, 
        /// by passing through searchItem object</param>
        /// <returns>A list of filtered log records</returns>
        
        public virtual void SearchKeyword(ILogItemSearch searchItem)
        {
            _searchKeywordBuffer.Clear();

            if (searchItem.StringValue == null || searchItem.StringValue.Trim().Length == 0)
            {
                return;

            }
            if (_filteredLogRecordsBuffer == null || _filteredLogRecordsBuffer.Count == 0) return;
            FilterItemProxy filterItemProxy = new FilterItemProxy(searchItem);
            filterItemProxy.BuildSearchMethod(RegexOptions.IgnoreCase);
            List<T> lsLogRecordResult = _filteredLogRecordsBuffer.FindAll(record => filterItemProxy.IsMatch(GetColumnValue(record, searchItem.LogItem)));
            _searchKeywordBuffer.AddRange(lsLogRecordResult);

        }

        /// <summary>
        /// Use to filter all log records matched with filter conditions.
        /// </summary>
        /// <param name="filterItemSetting">The list of filter conditions</param>
        public virtual void Filter(IList<FilterItemSetting> filterItemSetting)
        {
            _filteredLogRecordsBuffer.Clear();
            if (filterItemSetting == null || filterItemSetting.Count == 0)
            {
                _filteredLogRecordsBuffer.AddRange(_allLogRecordsBuffer);
                return;
            }
            List<FilterItemProxy> filterItemList = new List<FilterItemProxy>();
            foreach (FilterItemSetting filter in filterItemSetting)
            {
                if (filter.Enabled)
                {
                    FilterItemProxy filteProxy = new FilterItemProxy(filter);
                    filteProxy.BuildSearchMethod(RegexOptions.IgnoreCase);
                    filterItemList.Add(filteProxy);
                }
            }
            if (filterItemList.Count == 0)
            {
                _filteredLogRecordsBuffer.AddRange(_allLogRecordsBuffer);
                return;
            }
            foreach (T record in _allLogRecordsBuffer)
            {
                foreach (FilterItemProxy filterItem in filterItemList)
                {
                    //Existed atleast one not match filter. The record will not be display
                    string columnValue = GetColumnValue(record, filterItem.FilterItemSettingObj.LogItem);
                    if (filterItem.IsMatch(columnValue))
                    {
                        _filteredLogRecordsBuffer.Add(record);
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Get of Set BackgroundWorker. Use to cancel waste time of analyzing process.
        /// </summary>
        public BackgroundWorker KeywordCountWorker { get; set; }
        /// <summary>
        /// Use to analyze the amount of keywords in log record buffer
        /// </summary>
        /// <param name="setttingItems">The keyword list used to analyzing</param>
        public virtual void CountKeyword(IList<KeywordCountItemSetting> setttingItems)
        {
            _countKeywordBuffer.Clear();
            //Build List of FilterItemProxy base on list of keyword
            Dictionary<FilterItemProxy, AnalyzedCountKeywordItem> filterItemProxyDict = new Dictionary<FilterItemProxy, AnalyzedCountKeywordItem>();
            foreach (KeywordCountItemSetting keyword in setttingItems)
            {
                if (keyword.Enabled)
                {
                    FilterItemProxy filterItemProxy = GetFilterItemProxy(keyword);
                    filterItemProxy.FilterItemSettingObj.StringValue = keyword.StringValue.Trim();
                    filterItemProxy.BuildSearchMethod(RegexOptions.IgnoreCase);
                    AnalyzedCountKeywordItem analyzedCountItem = new AnalyzedCountKeywordItem();
                    analyzedCountItem.Name = keyword.Name;
                    filterItemProxyDict.Add(filterItemProxy, analyzedCountItem);
                }
            }
            if (KeywordCountWorker == null)
            {
                foreach (var record in _filteredLogRecordsBuffer)
                {
                    foreach (var filterItemProxy in filterItemProxyDict.Keys)
                    {
                        if (filterItemProxy.IsMatch(GetColumnValue(record, filterItemProxy.FilterItemSettingObj.LogItem)))
                        {
                            filterItemProxyDict[filterItemProxy].Count++;
                        }
                    }
                }
            }
            else
            {
                foreach (var record in _filteredLogRecordsBuffer)
                {
                    if (KeywordCountWorker.CancellationPending) { _countKeywordBuffer.Clear(); return; }
                    foreach (var filterItemProxy in filterItemProxyDict.Keys)
                    {
                        if (filterItemProxy.IsMatch(GetColumnValue(record, filterItemProxy.FilterItemSettingObj.LogItem)))
                        {
                            filterItemProxyDict[filterItemProxy].Count++;
                        }
                    }
                }

            }
            _countKeywordBuffer.AddRange(filterItemProxyDict.Values);
        }
        /// <summary>
        /// Abstract method for getting value of a column of log record.
        /// </summary>
        /// <param name="record">Generic log record, that can be <see cref="CCSLogRecord">CCSLogRecord</see> or <see cref="CXDILogRecord"/> </param>
        /// <param name="logItem">Name of column of log record</param>
        /// <returns></returns>
        protected abstract string GetColumnValue(T record, string logItem);
        /// <summary>
        /// Abstract method, for creating <see cref="FilterItemProxy">FilterItemProxy</see> 
        /// </summary>
        /// <param name="keyword"><see cref="KeywordCountItemSetting">KeywordCountItemSetting</see></param>
        /// <returns><see cref="FilterItemProxy">FilterItemProxy</see></returns>
        protected abstract FilterItemProxy GetFilterItemProxy(KeywordCountItemSetting keyword);

        /// <summary>
        /// Use to export log file to memo log file
        /// </summary>
        /// <param name="filePath">Location of exporting file</param>
        public abstract bool WriteMemo(String filePath);

        protected Dictionary<string, List<T>> _allLogRecordsBufferWithFileName;
        /// <summary>
        /// Get the file name of a record.
        /// </summary>
        /// <param name="record">Generic log record (<see cref="CCSLogRecord">CCSLogRecord</see>, <see cref="CXDILogRecord">CXDILogRecord</see>)</param>
        /// <returns>File name of file contain that record.</returns>
        public string GetRecordFileName(T record)
        {
            if (record == null) return string.Empty;
            string filePath = _allLogRecordsBufferWithFileName.FirstOrDefault(x => x.Value.Contains(record)).Key;
            var remaindedFileNames = _allLogRecordsBufferWithFileName.Keys.Where(x => !x.Contains(filePath)).Select(fullPath=>Path.GetFileName(fullPath));
            if (remaindedFileNames.Count() > 0)
            {
                string combinePaths = string.Format("{0}, {1}", Path.GetFileName(filePath), string.Join(", ", remaindedFileNames.ToArray()));
                return combinePaths;
            }
            else {
                return Path.GetFileName(filePath);
            }
        }
        protected List<T> _allLogRecordsBuffer;
        protected bool _isMemoLoaded = false;
        /// <summary>
        /// For checking if current file can merge with the olds
        /// </summary>
        /// <param name="filePath">Location of file</param>
        /// <returns>True: allow merge; False: do not allow merge.</returns>
        public bool CanMerge(string filePath)
        {
            if (_isMemoLoaded) return false;

            if (ParserManager.DetectFileType(filePath) == LogFileExt.Memo)
            {
                return false;
            } return true;
        }
        /// <summary>
        /// Get list of file name of log file had loaded.
        /// </summary>
        public ReadOnlyCollection<string> AllLogRecordsFilePaths
        {
            get
            {
                return _allLogRecordsBufferWithFileName.Keys.ToList<string>().AsReadOnly();
            }
        }
        /// <summary>
        /// Get list of all log records had loaded.
        /// </summary>
        public ReadOnlyCollection<T> AllLogRecordsBuffer
        {
            get
            {
                return _allLogRecordsBuffer.AsReadOnly();
            }
        }

        protected List<T> _filteredLogRecordsBuffer;
        /// <summary>
        /// Get list of all filtered log records.
        /// </summary>
        public ReadOnlyCollection<T> FilteredLogRecordsBuffer
        {
            get
            {
                return _filteredLogRecordsBuffer.AsReadOnly();
            }
        }
        protected List<T> _searchKeywordBuffer;
        /// <summary>
        /// Get list of record, that is result of searching process.
        /// </summary>
        public ReadOnlyCollection<T> SearchKeywordBuffer
        {
            get { return _searchKeywordBuffer.AsReadOnly(); }
        }

        protected List<AnalyzedPatternResultItem<T>> _patternAnalyzeBuffer;
        /// <summary>
        /// Get result of analyzing pattern process. <seealso cref="AnalyzedPatternResultItem{T}">AnalyzedPatternResultItem</seealso>
        /// </summary>
        public ReadOnlyCollection<AnalyzedPatternResultItem<T>> PatternAnalyzeBuffer
        {
            get { return _patternAnalyzeBuffer.AsReadOnly(); }
        }

        protected List<AnalyzedCountKeywordItem> _countKeywordBuffer;
        /// <summary>
        /// Get result of analyzing keyword count process. <seealso cref="AnalyzedCountKeywordItem{T}">AnalyzedCountKeywordItem</seealso>
        /// </summary>
        public ReadOnlyCollection<AnalyzedCountKeywordItem> CountKeywordBuffer
        {
            get { return _countKeywordBuffer.AsReadOnly(); }
        }
        protected List<T> _bookmarkBuffer;
        /// <summary>
        /// Get list of log records, that were mark as bookmark.
        /// </summary>
        public ReadOnlyCollection<T> BookmarkBuffer
        {
            get { return _bookmarkBuffer.AsReadOnly(); }
        }
        protected Dictionary<T, string> _comments;
        /// <summary>
        /// Get dictionary of comments, where keys are log records and values is comments.
        /// </summary>
        public Dictionary<T, string> Comments
        {
            get { return _comments; }
        }
        protected ILogParser<T> iLogParser;
        #region LoadlogFile: defined method for processing loading log file
        /// <summary>
        /// Load all log record from log file.
        /// </summary>
        /// <param name="filePath">The log record's file path</param>
        /// <param name="isAdd">The variable used to check either old log record buffer
        /// was replaced or merged with new one</param>
        public virtual void LoadLogFile(string filePath, bool isAdd)
        {
            var temp = iLogParser.ParserFromFile(filePath);
            ClearOldValue(isAdd);
            if (isAdd == true)
            {
                if (temp != null && temp.Count > 0)
                {

                    _allLogRecordsBufferWithFileName.Add(filePath, temp);
                    _allLogRecordsBuffer.Clear();
                    //BuildSortedListByRecordDateTime();
                    _allLogRecordsBuffer.AddRange(SortLogListManager<T>.SortAllRecord(_allLogRecordsBufferWithFileName));

                    int line = 1;
                    //set line number
                    foreach (var record in _allLogRecordsBuffer)
                    {
                        record.Line = line++;
                    }

                }
            }
            else
            {
                _allLogRecordsBufferWithFileName = new Dictionary<string, List<T>>();
                _allLogRecordsBufferWithFileName.Add(filePath, temp);
                _allLogRecordsBuffer.AddRange(SortLogListManager<T>.SortAllRecord(_allLogRecordsBufferWithFileName));

                int line = 1;
                foreach (var record in _allLogRecordsBuffer)
                {
                    record.Line = line++;
                }

            }
        }

        #endregion
        /// <summary>
        /// Load all log memo from memo log file.
        /// </summary>
        /// <param name="filePath">The memo log's file path</param>
        public virtual void LoadMemoLogFile(String filePath)
        {
            try
            {
                MemoLog<T> memoLog = ((ILogMemoParser<T>)iLogParser).ParserFromFile(filePath);
                if (memoLog != null)
                {
                    if (_allLogRecordsBuffer != null)
                    {
                        _allLogRecordsBuffer.Clear();
                        _allLogRecordsBufferWithFileName.Clear();
                    }
                    _allLogRecordsBufferWithFileName = new Dictionary<string, List<T>>();
                    _allLogRecordsBufferWithFileName.Add(filePath, memoLog.Records);
                    //_allLogRecordsBuffer.AddRange(_allLogRecordsBufferWithFileName[filePath]);
                    _allLogRecordsBuffer.AddRange(SortLogListManager<T>.SortAllRecord(_allLogRecordsBufferWithFileName));
                    _comments = memoLog.Comments;
                    _bookmarkBuffer = memoLog.Bookmarks;
                    if(_bookmarkBuffer!=null)
                    _bookmarkBuffer.Sort((x, y) => x.Line.CompareTo(y.Line));

                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Writes memo log to file.
        /// </summary>
        /// <param name="filePath">The output file's path</param>
        /// <returns></returns>
        public virtual bool WriteMemoLogFile(String filePath)
        {   //Create memo file if not exist directory
            string dirName = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dirName)) Directory.CreateDirectory(dirName);
            return ((ILogMemoParser<T>)iLogParser).WriteMemoLogFile(filePath);
        }

        /// <summary>
        /// Save log record as bookmark state.
        /// </summary>
        /// <param name="record">Record will be bookmarked</param>
        public virtual void AddBookmark(T record)
        {
            _bookmarkBuffer.Add(record);
        }

        /// <summary>
        /// Remove record from bookmark state.
        /// </summary>
        /// <param name="record">The record will not bookmarked</param>
        public virtual void RemoveBookmark(T record)
        {
            _bookmarkBuffer.Remove(record);
        }

        /// <summary>
        /// Clear old value of all fields
        /// </summary>
        /// <param name="isAdd">The variable used to mark replacing or merging state 
        /// of log record buffer</param>
        public virtual void ClearOldValue(bool isAdd)
        {
            if (isAdd == false)
            {
                ClearMemo();
                _countKeywordBuffer.Clear();
                _allLogRecordsBufferWithFileName.Clear();
            }
            _filteredLogRecordsBuffer.Clear();
            _allLogRecordsBuffer.Clear();
            _patternAnalyzeBuffer.Clear();
            _searchKeywordBuffer.Clear();
        }
        /// <summary>
        /// Clear comments and bookmarks buffer.
        /// </summary>
        public virtual void ClearMemo()
        {
            _bookmarkBuffer.Clear();
            Comments.Clear();
        }
        /// <summary>
        /// Clear bookmark buffer
        /// </summary>
        public virtual void ClearBookmark()
        {
            _bookmarkBuffer.Clear();
        }
        /// <summary>
        /// Clear comment buffer
        /// </summary>
        public virtual void ClearComment()
        {
            Comments.Clear();
        }
        /// <summary>
        /// Get or set<see cref="BackgroundWorker">BackgroundWorker</see> for canceling waste time process.
        /// </summary>
        public BackgroundWorker AnalyzePatternWorker { get; set; }
        /// <summary>
        /// Find the records by root keyword, from this record find in forward in range Time by others keyword.
        /// The condition search of keyword base on content/message column of log file.
        /// </summary>
        /// <param name="patternItemSettings">List of PatternItemSetting</param>
        public virtual void AnalyzePattern(IList<PatternItemSetting> patternItemSettings) {
            _patternAnalyzeBuffer.Clear();
            IAnalyzePattern<T> patternAnalyzer = AnalyzePatternManager.GetPatternAnalyzeInstance<T>();
            _patternAnalyzeBuffer.AddRange(patternAnalyzer.DoAnalyzePattern(_filteredLogRecordsBuffer, patternItemSettings, GetColumnContentValue, AnalyzePatternWorker));

        }
       /// <summary>
       /// Get value of content column of log record
       /// </summary>
        /// <param name="record">Generic log record, that can be <see cref="CCSLogRecord">CCSLogRecord</see> or <see cref="CXDILogRecord">CCSLogRecord</see></param>
       /// <returns>value of content column</returns>
        protected abstract string GetColumnContentValue(T record);
    }
}