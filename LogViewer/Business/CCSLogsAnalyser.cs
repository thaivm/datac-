// File:    CCSLogsAnalyser.cs
// Author:  CuongPNB
// Created: Friday, April 18, 2014 8:39:56 AM
// Purpose: Definition of Class CCSLogsAnalyser

using System;
using System.Collections.Generic;
using LogViewer.Model;
using System.Linq;
using System.IO;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.ComponentModel;
using LogViewer.Business.FileParser;
namespace LogViewer.Business
{
    /// <summary>
    /// Class provides methods for analyzing CCS log data 
    /// </summary>
    public class CCSLogsAnalyser : BaseLogsAnalyser<CCSLogRecord>
    {
        public CCSLogsAnalyser()
            : base()
        {
            _analyzedUserActionBuffer = new List<AnalyzedUserActionItem>();
            _analyzedErrorActionBuffer = new List<AnalyzedErrorActionItem>();
        }
        /// <summary>
        /// Get or set BackgroundWorker, for cancel waste process when analyze. <seealso cref="AnalyzeErrorAction">AnalyzeErrorAction</see>
        /// </summary>
        public BackgroundWorker ErrorActionWorker { set; get; }
        /// <summary>
        /// Used to analyze error action. AllLogRecordsBuffer must be set before do analyze action
        /// </summary>
        /// <param name="errorActionSettingList">List of error action item. This was loaded from CSV file</param>
        public void AnalyzeErrorAction(List<ErrorActionItem> errorActionSettingList)
        {
            if (errorActionSettingList == null) return;
            _analyzedErrorActionBuffer.Clear();
            foreach (ErrorActionItem errorActionItem in errorActionSettingList)
            {
                if (ErrorActionWorker == null)
                {
                    List<CCSLogRecord> lsCCSLogRecordResult = _filteredLogRecordsBuffer.FindAll(ccsLogRecord => ccsLogRecord.Type.Contains(errorActionItem.ErrorLv) && (ccsLogRecord.Id.Contains(errorActionItem.ErrorCode)));
                    foreach (CCSLogRecord record in lsCCSLogRecordResult)
                    {
                        AnalyzedErrorActionItem analyzeErrorActionItem = new AnalyzedErrorActionItem(errorActionItem, record);
                        _analyzedErrorActionBuffer.Add(analyzeErrorActionItem);
                    }
                }
                else {
                    List<CCSLogRecord> lsCCSLogRecordResult = new List<CCSLogRecord>();
                    foreach (CCSLogRecord record in _filteredLogRecordsBuffer)
                    {
                        if (ErrorActionWorker.CancellationPending) {
                            _analyzedErrorActionBuffer.Clear();
                            return;
                        }
                        if ((record.Type.Contains(errorActionItem.ErrorLv))&& record.Id.Contains(errorActionItem.ErrorCode)) {
                            lsCCSLogRecordResult.Add(record);
                        }
                    }
                    foreach (CCSLogRecord record in lsCCSLogRecordResult)
                    {
                        AnalyzedErrorActionItem analyzeErrorActionItem = new AnalyzedErrorActionItem(errorActionItem, record);
                        _analyzedErrorActionBuffer.Add(analyzeErrorActionItem);
                    }
                }
            }
        }
        public BackgroundWorker AnalyzeUserActionWorker { set; get; }
        /// <summary>
        /// Used to analyze user action. AllLogRecordsBuffer must be set before do analyze action
        /// </summary>
        /// <param name="userActionSettingList">List of user action item. This was loaded from CSV file</param>
        public void AnalyzeUserAction(List<UserActionItem> userActionSettingList)
        {
            if (userActionSettingList == null) return;
            _analyzedUserActionBuffer.Clear();
            foreach (UserActionItem userActionItem in userActionSettingList)
            {
                if (AnalyzeUserActionWorker == null)
                {
                    List<CCSLogRecord> lsCCSLogRecordResult = _filteredLogRecordsBuffer.FindAll(ccsLogRecord => ccsLogRecord.Content.IndexOf(userActionItem.RefSystemLog) != -1);
                    foreach (CCSLogRecord record in lsCCSLogRecordResult)
                    {
                        AnalyzedUserActionItem analyzeUserActionItem = new AnalyzedUserActionItem(userActionItem, record);
                        _analyzedUserActionBuffer.Add(analyzeUserActionItem);
                    }
                }
                else {
                    List<CCSLogRecord> lsCCSLogRecordResult = new List<CCSLogRecord>();
                    foreach (CCSLogRecord record in _filteredLogRecordsBuffer)
                    {
                        if (AnalyzeUserActionWorker.CancellationPending) 
                        {
                            _analyzedUserActionBuffer.Clear();
                            return;
                        }
                        if (record.Content.Contains(userActionItem.RefSystemLog)) {
                            lsCCSLogRecordResult.Add(record);
                        }
                    }
                    foreach (CCSLogRecord record in lsCCSLogRecordResult)
                    {
                        AnalyzedUserActionItem analyzeUserActionItem = new AnalyzedUserActionItem(userActionItem, record);
                        _analyzedUserActionBuffer.Add(analyzeUserActionItem);
                    }
                
                }
            }
            //Sort list by date + time by ASC
            _analyzedUserActionBuffer.Sort((x, y) => DateTime.Parse(string.Format("{0} {1}", x.Date, x.Time)).CompareTo(DateTime.Parse(string.Format("{0} {1}", y.Date, y.Time))));

        }

        protected List<AnalyzedUserActionItem> _analyzedUserActionBuffer;
        /// <summary>
        /// Get <see cref="AnalyzeUserActionWorker">AnalyzeUserActionWorker</see>
        /// </summary>
        public List<AnalyzedUserActionItem> AnalyzedUserActionBuffer
        {
            get { return _analyzedUserActionBuffer; }
        }
        protected List<AnalyzedErrorActionItem> _analyzedErrorActionBuffer;
        /// <summary>
        /// Get <see cref="AnalyzedErrorActionItem">AnalyzedErrorActionItem</see>
        /// </summary>
        public List<AnalyzedErrorActionItem> AnalyzedErrorActionBuffer
        {
            get { return _analyzedErrorActionBuffer; }
        }
        /// <summary>
        /// Load log file to AllLogrecordsBuffer. Method auto detect what type of file (CCS log or CCS memo log)
        /// </summary>
        /// <param name="filePath">Location of log file</param>
        /// <param name="isAdd">True: added new to AllLogrecordsBuffer; False: replace to the new one</param>
        /// <exception cref="Exception">Throw Exception when the log file not matched with CCS log or CCS memo log</exception>
        public override void LoadLogFile(String filePath, bool isAdd)
        {
            try
            {
                LogFileExt fileExt = ParserManager.DetectFileType(filePath);
                if (fileExt == LogFileExt.Memo)
                {
                    iLogParser = ParserManager.GetCcsMemoParser(filePath);
                    base.LoadMemoLogFile(filePath);
                    _isMemoLoaded = true;
                    return;
                }
                if (fileExt == LogFileExt.Ccs)
                {
                    iLogParser = ParserManager.GetCcsCsvParser(filePath);
                    base.LoadLogFile(filePath, isAdd);
                    _isMemoLoaded = false;
                    return;
                }
                else throw new Exception(string.Format(Properties.Resources.FILE_LOG_LOAD_EXCEPTION,filePath));
            }
            catch { throw; }
      
        }



        /// <summary>
        /// Use to export log file to memo log file
        /// </summary>
        /// <param name="filePath">Location of exporting file</param>

        public override bool WriteMemo(String filePath)
        {
            try
            {
                CCSMemoParserOld ccsMemoParser = new CCSMemoParserOld();
                ccsMemoParser.LogRecords = AllLogRecordsBuffer;
                ccsMemoParser.Bookmarks = BookmarkBuffer;
                ccsMemoParser.Comments = Comments;
                iLogParser = ccsMemoParser;
                return base.WriteMemoLogFile(filePath);
            }
            catch 
            {
                //MessageBox.Show(Properties.Resources.CAN_NOT_CREATE_FILE);
                return false;
                //throw ;
            }
        }

        /// <summary>
        /// Load all log memo from memo log file.
        /// </summary>
        /// <param name="filePath">Location of exporting file</param>
        public override void LoadMemoLogFile(string filePath)
        {
            try
            {
                  iLogParser = ParserManager.GetCcsMemoParser(filePath);
                base.LoadMemoLogFile(filePath);
                _isMemoLoaded = true;

            }
            catch 
            {
                throw;
            }
        }

        /// <summary>
        /// Get value of Content column
        /// </summary>
        /// <param name="record"><see cref="CCSLogRecord">CCSLogRecord</see></param>
        /// <returns>Value of Content column</returns>
        protected override string GetColumnContentValue(CCSLogRecord record)
        {
            if (record == null) return string.Empty;
            return record.Content;
        }
        /// <summary>
        /// Create <see cref="FilterItemProxy"/> base on <see cref="KeywordCountItemSetting">KeywordCountItemSetting</see>
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        protected override FilterItemProxy GetFilterItemProxy(KeywordCountItemSetting keyword)
        {
            var filterItemProxy = new FilterItemProxy(keyword);
            return filterItemProxy;

        }
        /// <summary>
        /// Get value of a column specified by log item parameter.
        /// </summary>
        /// <param name="record"><see cref="CCSLogRecord">CCSLogRecord</see></param>
        /// <param name="logItem">Name of log column</param>
        /// <returns>Value of the column</returns>
        protected override string GetColumnValue(CCSLogRecord record, string logItem)
        {
            if (record == null) return string.Empty;
            //Line
            if (logItem.Contains(ConfigValue.BaseLogHeader.HEADER_LINE))
            {

                return record.Line.ToString();
            }
            //Date
            if (logItem.Contains(ConfigValue.BaseLogHeader.HEADER_DATE))
            {
                return record.Date;
            }
            //Time
            if (logItem.Contains(ConfigValue.BaseLogHeader.HEADER_TIME))
            {
                return record.Time;
            }
            //HostName
            if (logItem.Contains(ConfigValue.CCSHeader.HEADER_HOSTNAME))
            {
                return record.HostName;
            }
            //ThreadId
            if (logItem.Contains(ConfigValue.CCSHeader.HEADER_THREADID))
            {
                return record.ThreadId;
            }
            //Type
            if (logItem.Contains(ConfigValue.CCSHeader.HEADER_TYPE))
            {
                return record.Type;
            }
            //ID
            if (logItem.Contains(ConfigValue.CCSHeader.HEADER_ID))
            {
                return record.Id;
            }
            //Content
            if (logItem.Contains(ConfigValue.CCSHeader.HEADER_CONTENT))
            {
                return  record.Content;
            }
            //AdditionInfo
            if (logItem.Contains(ConfigValue.CCSHeader.HEADER_ADDITIONINFO))
            {
                return record.AdditionalInfo;
            }
            //PersonalInfo
            if (logItem.Contains(ConfigValue.CCSHeader.HEADER_PERSONALINFO))
            {
                return record.PersonalInfo;
            }
            //ClassName
            if (logItem.Contains(ConfigValue.CCSHeader.HEADER_CLASSNAME))
            {
                return record.ClassName;
            }
            //Comment
            if (logItem.Contains(ConfigValue.CCSHeader.HEADER_COMMENT))
            {
                if (_comments.ContainsKey(record))
                {
                    return _comments[record];
                }
                return string.Empty;
            }
            //Module
            if (logItem.Contains(ConfigValue.CCSHeader.HEADER_MODE))
            {
                return record.Mode;
            }
            return string.Empty;
        }
    }
}