using System;
using LogViewer.Business.FileSetting;
using LogViewer.Model;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using LogViewer.Business;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides method for displaying CCS log records
    /// </summary>
    public class CCSLogsDisplayViewModel : BaseLogsDisplayViewModel<CCSLogRecord>
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
                OnPropertyChanged("IsDisplayHostName");
                OnPropertyChanged("IsDisplayThreadID");
                OnPropertyChanged("IsDisplayType");
                OnPropertyChanged("IsDisplayID");
                OnPropertyChanged("IsDisplayContent");
                OnPropertyChanged("IsDisplayAdditionalInfo");
                OnPropertyChanged("IsDisplayPersonalInfo");
                OnPropertyChanged("IsDisplayMode");
                OnPropertyChanged("IsDisplayClassName");
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
        public CCSLogsDisplayViewModel(Action<CCSLogRecord> onAddBookmarkEvent, Action<CCSLogRecord> onRemoveBookmarkEvent,
            Action<CCSLogRecord> onUpdateRecordFileName, Action<string, string> onFollowOtherLogEvent, Action<CCSLogRecord, AnalyzedPatternResultItem<CCSLogRecord>> onShowPatternColoringRecord, List<LogDisplay> logDisplay, BaseSettingManager baseSettingManger, Action<object> onClickRecordChange)
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
                return HeaderToShow.SingleOrDefault(x => x.key.ToString() == LogViewer.Model.ConfigValue.CCSHeader.HEADER_BOOKMARK).value;
            }
        }
        /// <summary>
        /// Get displaying line status
        /// </summary>
        public bool IsDisplayLine
        {
            get
            {
                return HeaderToShow.SingleOrDefault(x => x.key.ToString() == LogViewer.Model.ConfigValue.CCSHeader.HEADER_LINE).value;
            }
        }
        /// <summary>
        /// Get displaying date status
        /// </summary>
        public bool IsDisplayDate 
        { 
            get
            {
                return HeaderToShow.SingleOrDefault(x => x.key.ToString() == LogViewer.Model.ConfigValue.CCSHeader.HEADER_DATE).value;
            }
        }
        /// <summary>
        /// Get displaying time status
        /// </summary>

        public bool IsDisplayTime
        {
            get
            {
                return HeaderToShow.SingleOrDefault(x => x.key.ToString() == LogViewer.Model.ConfigValue.CCSHeader.HEADER_TIME).value;
            }
        }
        /// <summary>
        /// Get displaying host name status
        /// </summary>

        public bool IsDisplayHostName
        {
            get
            {
                return HeaderToShow.SingleOrDefault(x => x.key.ToString() == LogViewer.Model.ConfigValue.CCSHeader.HEADER_HOSTNAME).value;
            }
        }
        /// <summary>
        /// Get displaying thread id status
        /// </summary>

        public bool IsDisplayThreadID
        {
            get
            {
                return HeaderToShow.SingleOrDefault(x => x.key.ToString() == LogViewer.Model.ConfigValue.CCSHeader.HEADER_THREADID).value;
            }
        }
        /// <summary>
        /// Get displaying type status
        /// </summary>

        public bool IsDisplayType
        {
            get
            {
                return HeaderToShow.SingleOrDefault(x => x.key.ToString() == LogViewer.Model.ConfigValue.CCSHeader.HEADER_TYPE).value;
            }
        }

        /// <summary>
        /// Get displaying id status
        /// </summary>

        public bool IsDisplayID
        {
            get
            {
                return HeaderToShow.SingleOrDefault(x => x.key.ToString() == LogViewer.Model.ConfigValue.CCSHeader.HEADER_ID).value;
            }
        }

        /// <summary>
        /// Get displaying content status
        /// </summary>

        public bool IsDisplayContent
        {
            get
            {
                return HeaderToShow.SingleOrDefault(x => x.key.ToString() == LogViewer.Model.ConfigValue.CCSHeader.HEADER_CONTENT).value;
            }
        }

        /// <summary>
        /// Get displaying addition info status
        /// </summary>

        public bool IsDisplayAdditionalInfo
        {
            get
            {
                return HeaderToShow.SingleOrDefault(x => x.key.ToString() == LogViewer.Model.ConfigValue.CCSHeader.HEADER_ADDITIONINFO).value;
            }
        }

        /// <summary>
        /// Get displaying personal info status
        /// </summary>

        public bool IsDisplayPersonalInfo
        {
            get
            {
                return HeaderToShow.SingleOrDefault(x => x.key.ToString() == LogViewer.Model.ConfigValue.CCSHeader.HEADER_PERSONALINFO).value;
            }
        }

        /// <summary>
        /// Get displaying class name status
        /// </summary>
        public bool IsDisplayClassName
        {
            get
            {
                return HeaderToShow.SingleOrDefault(x => x.key.ToString() == LogViewer.Model.ConfigValue.CCSHeader.HEADER_CLASSNAME).value;
            }
        }
        /// <summary>
        /// Get displaying comment status
        /// </summary>

        public bool IsDisplayComment
        {
            get
            {
                return HeaderToShow.SingleOrDefault(x => x.key.ToString() == LogViewer.Model.ConfigValue.CCSHeader.HEADER_COMMENT).value;
            }
        }
        /// <summary>
        /// Create view model record from log record for displaying 
        /// </summary>
        /// <param name="data"><see cref="CCSLogRecord"/></param>
        /// <returns><see cref="BaseLogRecordDisplayViewModel<T>"/></returns>
        protected override BaseLogRecordDisplayViewModel<CCSLogRecord> CreateRecordVMFromData(CCSLogRecord data)
        {
            return new CCSLogRecordDisplayViewModel(data, this);
        }
        /// <summary>
        /// Command for copy action
        /// </summary>
        protected override void CopyCommandCL()
        {
            StringBuilder builder = new StringBuilder();
            var selectedItems = new List<CCSLogRecordDisplayViewModel>(SelectedItems.Cast<CCSLogRecordDisplayViewModel>());
            var orderSelectedItems = selectedItems.OrderBy(x => x.Date).ThenBy(y => y.Time).ToList();
            foreach (CCSLogRecordDisplayViewModel i in orderSelectedItems)
            {
                //builder.Append(i.Line);
                //builder.Append(",");
                builder.AppendFormat("{0} {1},{2},{3},{4},{5},{6},{7},{8},{9}", i.Date, i.Time, i.Type, 
                    i.HostName, i.ThreadId, i.Id, 
                    i.Content, i.AdditionalInfo, i.PersonalInfo, i.Comment);
                //builder.Append(i.Date);
                //builder.Append(" ");
                //builder.Append(i.Time);
                //builder.Append(",");
                //builder.Append(i.Type);
                //builder.Append(",");
                //builder.Append(i.HostName);
                //builder.Append(",");
                //builder.Append(i.ThreadId);
                //builder.Append(",");
                //builder.Append(i.Id);
                //builder.Append(",");
                //builder.Append(i.Content);
                //builder.Append(",");
                //builder.Append(i.AdditionalInfo);
                //builder.Append(",");
                //builder.Append(i.PersonalInfo);
                //builder.Append(",");
                //builder.Append(i.Comment);
                //builder.Append(",");
                //if (!i.Line.Equals(((CCSLogRecordDisplayViewModel)orderSelectedItems.LastOrDefault()).Line))
                //{
                //    builder.Append("\r\n");
                //}
                builder.Append("\r\n");
            }
            
            Clipboard.SetText(builder.ToString());
        }

        
    }
}