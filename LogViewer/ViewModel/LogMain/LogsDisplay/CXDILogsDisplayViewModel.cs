// File:    CXDILogsDisplayViewModel.cs
// Author:  QuocNT
// Created: Friday, April 18, 2014 12:27:51 PM
// Purpose: Definition of Class CXDILogsDisplayViewModel

using System;
using LogViewer.Business.FileSetting;
using LogViewer.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text;
using LogViewer.Business;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides method for displaying CXDI log record to data gridview
    /// </summary>
    public class CXDILogsDisplayViewModel : BaseLogsDisplayViewModel<CXDILogRecord>
    {
        protected List<LogDisplay> _headerToShow;
        /// <summary>
        /// Get or header log header to show
        /// </summary>
        public List<LogDisplay> HeaderToShow
        {
            get
            {
                return _headerToShow;
            }
            set
            {
                _headerToShow = value;
                OnPropertyChanged("HeaderToShow");
                OnPropertyChanged("IsDisplayBookmark");
                OnPropertyChanged("IsDisplayLine");
                OnPropertyChanged("IsDisplayDate");
                OnPropertyChanged("IsDisplayTime");
                OnPropertyChanged("IsDisplayMessage");
                OnPropertyChanged("IsDisplayModule");
                OnPropertyChanged("IsDisplayComment");
            }
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="onAddBookmarkEvent">Process for action adding bookmark <seealso cref="Action<T>"/></param>
        /// <param name="onRemoveBookmarkEvent">Process for action removing bookmark <seealso cref="Action<T>"/></param>
        /// <param name="onUpdateRecordFileName">Process for refreshing file name <seealso cref="Action<T>"/></param>
        /// <param name="onFollowOtherLogEvent">Process for action follow mode <seealso cref="Action<T>"/></param>
        /// <param name="onShowPatternColoringRecord">Process for pattern coloring <seealso cref="Action<T>"/></param>
        /// <param name="baseSettingManger">Preference to <see cref="BaseSettingManager"/> object</param>
        /// <param name="onClickRecordChange">Process for clicking action</param>
        public CXDILogsDisplayViewModel(Action<CXDILogRecord> onAddBookmarkEvent, 
            Action<CXDILogRecord> onRemoveBookmarkEvent, Action<CXDILogRecord> onUpdateRecordFileName,
            Action<string, string> onFollowOtherLogEvent, Action<CXDILogRecord, AnalyzedPatternResultItem<CXDILogRecord>> onShowPatternColoringRecord, List<LogDisplay> logDisplay, BaseSettingManager baseSettingManger, Action<object> onClickRecordChange)
            : base(onAddBookmarkEvent, onRemoveBookmarkEvent, onUpdateRecordFileName, onFollowOtherLogEvent, onShowPatternColoringRecord, baseSettingManger, onClickRecordChange)
        {
            HeaderToShow = logDisplay;
        }
        /// <summary>
        /// Get displaying bookmark status
        /// </summary>

        public bool IsDisplayBookmark
        {
            get
            {
                return HeaderToShow.SingleOrDefault(x => x.key.ToString() == LogViewer.Model.ConfigValue.CXDIHeader.HEADER_BOOKMARK).value;
            }
        }
        /// <summary>
        /// Get displaying line status
        /// </summary>

        public bool IsDisplayLine
        {
            get
            {
                return HeaderToShow.SingleOrDefault(x => x.key.ToString() == LogViewer.Model.ConfigValue.CXDIHeader.HEADER_LINE).value;
            }
        }
        /// <summary>
        /// Get displaying date status
        /// </summary>

        public bool IsDisplayDate
        {
            get
            {
                return HeaderToShow.SingleOrDefault(x => x.key.ToString() == LogViewer.Model.ConfigValue.CXDIHeader.HEADER_DATE).value;
            }
        }
        /// <summary>
        /// Get displaying time status
        /// </summary>

        public bool IsDisplayTime
        {
            get
            {
                return HeaderToShow.SingleOrDefault(x => x.key.ToString() == LogViewer.Model.ConfigValue.CXDIHeader.HEADER_TIME).value;
            }
        }
        /// <summary>
        /// Get displaying message status
        /// </summary>

        public bool IsDisplayMessage
        {
            get
            {
                return HeaderToShow.SingleOrDefault(x => x.key.ToString() == LogViewer.Model.ConfigValue.CXDIHeader.HEADER_MESSAGE).value;
            }
        }
        /// <summary>
        /// Get displaying module status
        /// </summary>

        public bool IsDisplayModule
        {
            get
            {
                return HeaderToShow.SingleOrDefault(x => x.key.ToString() == LogViewer.Model.ConfigValue.CXDIHeader.HEADER_MODULE).value;
            }
        }
        /// <summary>
        /// Get displaying comments status
        /// </summary>

        public bool IsDisplayComment
        {
            get
            {
                return HeaderToShow.SingleOrDefault(x => x.key.ToString() == LogViewer.Model.ConfigValue.CXDIHeader.HEADER_COMMENT).value;
            }
        }
        /// <summary>
        /// Create view model record from log record for displaying 
        /// </summary>
        /// <param name="data"><see cref="CXDILogRecord"/></param>
        /// <returns><see cref="BaseLogRecordDisplayViewModel<T>"/></returns>

        protected override BaseLogRecordDisplayViewModel<CXDILogRecord> CreateRecordVMFromData(CXDILogRecord data)
        {
            return new CXDILogRecordDisplayViewModel(data, this);
        }
        /// <summary>
        /// Command for copy action
        /// </summary>
        protected override void CopyCommandCL()
        {
            StringBuilder builder = new StringBuilder();
            var selectedItems = new List<CXDILogRecordDisplayViewModel>(SelectedItems.Cast<CXDILogRecordDisplayViewModel>());
            var orderSelectedItems = selectedItems.OrderBy(x => x.Date).ThenBy(y => y.Time).ToList();
            foreach (CXDILogRecordDisplayViewModel i in orderSelectedItems)
            {
                //builder.Append(i.Line);
                //builder.Append(",");
                builder.Append(i.Date);
                builder.Append(" ");
                builder.Append(i.Time);
                builder.Append(",");
                builder.Append(i.Module);
                builder.Append(",");
                builder.Append(i.Message);
                builder.Append(",");
                builder.Append(i.Comment);
                //if (!i.Line.Equals(((CXDILogRecordDisplayViewModel)SelectedItems.LastOrDefault()).Line))
                //{
                builder.Append("\r\n");
                //}
            }
            Clipboard.SetText(builder.ToString());
        }
    }
}