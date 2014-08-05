// File:    BaseLogsViewModel.cs
// Author:  CuongPNB
// Created: Friday, April 18, 2014 2:04:03 PM
// Purpose: Definition of Class BaseLogsViewModel

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LogViewer.Business.FileSetting;
using LogViewer.Model;
using LogViewer.Util;
using LogViewer.MVVMHelper;
using System.Windows.Input;
using System.Windows;
using LogViewer.Business;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Base class provides common methods for display log file
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseLogsDisplayViewModel<T> : BaseViewModel, ILogsDisplayContainer<T> where T : BaseLogRecord
    {
        protected event Action<T> OnAddBookmarkEvent;
        protected event Action<T> OnRemoveBookmarkEvent;
        protected event Action<T> OnUpdateRecordFileName;
        protected event Action<string, string> OnFollowOtherLogEvent;
        protected event Action<T, AnalyzedPatternResultItem<T>> OnShowPatternColoringRecord;
        protected event Action<object> OnClickRecordChange;
        protected Dictionary<T, BaseLogRecordDisplayViewModel<T>> _locatorDict;
        public Dictionary<T, string> CommentsDict { get; set; }
        public IList<T> BookmarkList { get; set; }
        protected BaseSettingManager _baseSettingManger; 

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
        protected BaseLogsDisplayViewModel(Action<T> onAddBookmarkEvent, Action<T> onRemoveBookmarkEvent,
            Action<T> onUpdateRecordFileName, Action<string, string> onFollowOtherLogEvent, Action<T, AnalyzedPatternResultItem<T>> onShowPatternColoringRecord, BaseSettingManager baseSettingManger, Action<object> onClickRecordChange)
        {
            BookmarkList = new List<T>();
            CommentsDict = new Dictionary<T, string>();
            _locatorDict = new Dictionary<T, BaseLogRecordDisplayViewModel<T>>();
            OnAddBookmarkEvent = onAddBookmarkEvent;
            OnRemoveBookmarkEvent = onRemoveBookmarkEvent;
            OnUpdateRecordFileName = onUpdateRecordFileName;
            BaseRecordVMList = new ObservableCollection<BaseLogRecordDisplayViewModel<T>>();
            FontOfDataGrid = ConfigValue.DefaultFontSize;
            OnFollowOtherLogEvent = onFollowOtherLogEvent;
            OnShowPatternColoringRecord = onShowPatternColoringRecord;
            _baseSettingManger = baseSettingManger;
            OnClickRecordChange = onClickRecordChange;
        }

        protected bool _isOnFollowMode;
        /// <summary>
        /// Get or set follow mode status
        /// </summary>
        public bool IsOnFollowMode
        {
            get
            {
                return _isOnFollowMode;
            }
            set
            {
                _isOnFollowMode = value;
                OnPropertyChanged("IsOnFollowMode");
            }
        }

        BaseLogRecordDisplayViewModel<T> _clickedRecord;
        /// <summary>
        /// Get or set clicked record
        /// </summary>
        public BaseLogRecordDisplayViewModel<T> ClickedRecord 
        {
            get
            {
                return _clickedRecord;
            }
            set
            {
                _clickedRecord = value;
                if (value != null)
                {
                    OnUpdateRecordFileName(_clickedRecord.Data);
                    _recordForFollow = value;
                    if (IsOnFollowMode)
                        OnFollowOtherLogEvent(value.Date,value.Time);
                    OnClickRecordChange(value);
                }
                OnPropertyChanged("ClickedRecord");
            }
        }
        
        protected double _fontOfDataGrid;
        /// <summary>
        /// Get or set font of data grid
        /// </summary>
        public double FontOfDataGrid
        {
            get
            {
                return _fontOfDataGrid;
            }
            set
            {
                if (value < ConfigValue.MinimunFontSize)
                {
                    value = ConfigValue.MinimunFontSize;
                }
                if (value > ConfigValue.MaximunFontSize)
                {
                    value = ConfigValue.MaximunFontSize;
                }
                _fontOfDataGrid = value;
                OnPropertyChanged("FontOfDataGrid");
            }
        }
        protected string _processTime;
        /// <summary>
        /// Get or set processing time
        /// </summary>
        public string ProcessTime
        {
            get
            {
                return _processTime;
            }
            set
            {
                _processTime = value;
                OnPropertyChanged("ProcessTime");
            }
        }
        protected IList<object> _selectedItems;
        /// <summary>
        /// Get or set list of selected items
        /// </summary>
        public IList<object> SelectedItems
        {
            get
            {
                return _selectedItems;
            }
            set
            {
                _selectedItems = value;
                OnPropertyChanged("SelectedItems");
            }
        }
        protected ObservableCollection<BaseLogRecordDisplayViewModel<T>> _baseRecordVMList;
        /// <summary>
        /// Get or set list of log records
        /// </summary>
        public ObservableCollection<BaseLogRecordDisplayViewModel<T>> BaseRecordVMList
        {
            get
            {
                return _baseRecordVMList;
            }
            set
            {
                _baseRecordVMList = value;
                OnPropertyChanged("BaseRecordVMList");
                
            }
        }

        protected BaseLogRecordDisplayViewModel<T> _recordForJump;
        /// <summary>
        /// Get or set record for jump action
        /// </summary>
        public BaseLogRecordDisplayViewModel<T> RecordForJump
        {
            get
            {
                return _recordForJump;
            }
            set
            {
                _recordForJump = value;
                OnPropertyChanged("RecordForJump");
            }
        }

        protected BaseLogRecordDisplayViewModel<T> _recordForFollow;
        /// <summary>
        /// Get or set record in follow mode
        /// </summary>
        public BaseLogRecordDisplayViewModel<T> RecordForFollow
        {
            get
            {
                return _recordForFollow;
            }
            set
            {
                _recordForFollow = value;
                OnPropertyChanged("RecordForFollow");
            }
        }

        protected bool _refreshData;
        /// <summary>
        /// Get or set refresh data status
        /// </summary>
        public bool RefreshData
        {
            get
            {
                return _refreshData;
            }
            set
            {
                _refreshData = value;
                OnPropertyChanged("RefreshData");
            }
        }

        protected List<FilterItemSetting> _filterSetting;
        /// <summary>
        /// Get or set list of filtering setting items
        /// </summary>
        public List<FilterItemSetting> FilterSetting
        {
            get
            {
                if (_filterSetting == null)
                {
                    _filterSetting = new List<FilterItemSetting>();
                }
                return _filterSetting;
            }
            set
            {
                _filterSetting = value;
                OnPropertyChanged("FilterSetting");
            }
        }

        protected PatternColor<T> _patternColor;
        /// <summary>
        /// Get or set pattern color
        /// </summary>
        public PatternColor<T> PatternColor
        {
            get
            {
                return _patternColor;
            }
            set
            {
                _patternColor = value;
                OnPropertyChanged("PatternColor");
                if (value != null)
                {
                    FilterItemSetting filter = ConfigValue.DefaultColorFilterItem.Copy();
                    filter.PatternColor = _patternColor;
                    List<FilterItemSetting> filters = new List<FilterItemSetting>(_baseSettingManger.AllEnabledColorFilters);
                    filters.Add(filter);
                    LoadFilterSetting(filters);
                }
                else
                {
                    LoadFilterSetting(_baseSettingManger.AllEnabledColorFilters);
                }
            }
        }

        abstract protected BaseLogRecordDisplayViewModel<T> CreateRecordVMFromData(T data);
        /// <summary>
        /// Initialize object after creating
        /// </summary>
        /// <param name="bookmarkList">List of record marked as bookmark</param>
        /// <param name="comments">Dictionary of comments</param>
        public void Initialize(IList<T> bookmarkList, Dictionary<T, string> comments)
        {
            BookmarkList = bookmarkList;
            CommentsDict = comments;
        }
        /// <summary>
        /// Load log records to display on data grid view
        /// </summary>
        /// <param name="data">List of log records</param>
        /// <param name="filters">List of filtering setting items</param>
        public void LoadData(IList<T> data, IList<FilterItemSetting> filters)
        {
            List<BaseLogRecordDisplayViewModel<T>> temp = new List<BaseLogRecordDisplayViewModel<T>>();
            _locatorDict = new Dictionary<T, BaseLogRecordDisplayViewModel<T>>();
            foreach (var i in data)
            {
                var v = CreateRecordVMFromData(i);
                temp.Add(v);
                _locatorDict.Add(i, v);
            }
            LoadFilterSetting(filters);
            BaseRecordVMList = new ObservableCollection<BaseLogRecordDisplayViewModel<T>>(temp);
            
            //focuse the first row, to display the current record file name on main screen
            if (BaseRecordVMList.Count > 0)
            {
                RecordForFollow = RecordForJump = BaseRecordVMList[0];
                OnUpdateRecordFileName(RecordForJump.Data);
            }
        }
        /// <summary>
        /// Load list of filtering setting items
        /// </summary>
        /// <param name="filters"></param>
        public void LoadFilterSetting(IList<FilterItemSetting> filters)
        {
            FilterSetting = new List<FilterItemSetting>(filters);
        }
        /// <summary>
        /// Refresh record source
        /// </summary>
        public void RefreshItemsSource()
        {
            var temp = BaseRecordVMList;
            BaseRecordVMList = null;
            BaseRecordVMList = temp;
        }
        /// <summary>
        /// Clear all data
        /// </summary>
        public void ClearData()
        {
            BaseRecordVMList = new ObservableCollection<BaseLogRecordDisplayViewModel<T>>();
            _locatorDict = new Dictionary<T, BaseLogRecordDisplayViewModel<T>>();
        }
        /// <summary>
        /// Mark record T as bookmark
        /// </summary>
        /// <param name="data">Log record</param>
        public virtual void AddBookmark(T data)
        {
            if(OnAddBookmarkEvent != null)
                OnAddBookmarkEvent(data);
        }
        /// <summary>
        /// Remove record T from bookmark list
        /// </summary>
        /// <param name="data"></param>
        public virtual void RemoveBookmark(T data)
        {
            if(OnRemoveBookmarkEvent != null)
                OnRemoveBookmarkEvent(data);
        }
        /// <summary>
        /// Focus to a record
        /// </summary>
        /// <param name="record">Generic log record</param>
        public void ShowRecord(T record)
        {
            if (RecordForJump != null && RecordForJump.IsViewModelOf(record))
            {
                RecordForJump = null;
            }
            if (record != null && _locatorDict.ContainsKey(record))
            {
                RecordForFollow = RecordForJump = _locatorDict[record];
                OnUpdateRecordFileName(RecordForJump.Data);
                if (IsOnFollowMode)
                    OnFollowOtherLogEvent(RecordForJump.Date, RecordForJump.Time);
            }
            else
            {
                if(record != null)
                MessageBox.Show(Properties.Resources.Line + record.Line.ToString() + Properties.Resources.NotDisplayLogViewMessage);
            }
        }
        /// <summary>
        /// Focus to related record with record of pattern result
        /// </summary>
        /// <param name="record">Generic log record</param>
        /// <param name="CurrentPatternItem">Search pattern results</param>
        public void ShowPatternColoringRecord(T record, AnalyzedPatternResultItem<T> CurrentPatternItem)
        {
            if (RecordForJump != null && RecordForJump.IsViewModelOf(record))
            {
                RecordForJump = null;
            }
            if (record != null && _locatorDict.ContainsKey(record))
            {
                RecordForJump = _locatorDict[record];
                ClickedRecord = RecordForJump;
            }
            else
            {
                if (record != null)
                {
                    MessageBox.Show(Properties.Resources.Line + record.Line.ToString() + Properties.Resources.NotDisplayLogViewMessage);
                    return;
                }

            }
            OnShowPatternColoringRecord(record, CurrentPatternItem);
        }

        /// <summary>
        /// Set follow record
        /// </summary>
        /// <param name="record">Generic log record</param>
        public void FollowRecord(T record)
        {
            if (RecordForFollow != null && RecordForFollow.IsViewModelOf(record))
            {
                RecordForFollow = null;
            }
            if (_locatorDict.ContainsKey(record))
            {
                RecordForFollow = _locatorDict[record];
                //set clicked record to update file name after jump
                //ClickedRecord = RecordForFollow;
                OnUpdateRecordFileName(RecordForFollow.Data);
            }
        }
        /// <summary>
        /// Increase height of rows
        /// </summary>
        public virtual void Expand()
        {
            if (FontOfDataGrid < ConfigValue.MaximunFontSize)
            {
                FontOfDataGrid += ConfigValue.DeltaFontSize;
            }
        }
        /// <summary>
        /// De increase height of rows
        /// </summary>
        public virtual void Shrink()
        {
            if (FontOfDataGrid > ConfigValue.MinimunFontSize)
            {
                FontOfDataGrid -= ConfigValue.DeltaFontSize;
            }
        }

        protected DelegateCommand _copyCommand;
        /// <summary>
        /// Command interface for copy records action
        /// </summary>
        public ICommand CopyCommand
        {
            get
            {
                if (_copyCommand == null)
                {
                    _copyCommand = new DelegateCommand(CopyCommandCL, () => IsEnableCopy());
                }
                return _copyCommand;
            }
        }
        /// <summary>
        /// Command for copy records action
        /// </summary>
        protected abstract void CopyCommandCL();        
        /// <summary>
        /// Get copying status
        /// </summary>
        /// <returns>True: allow copy, otherwise False</returns>
        protected bool IsEnableCopy() 
        { 
            if(SelectedItems == null || SelectedItems.Count == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Determine with side of log record list follow other
        /// </summary>
        public virtual void OnOtherLogsLoadedHandler()
        {
            if (IsOnFollowMode && RecordForFollow != null)
                OnFollowOtherLogEvent(RecordForFollow.Date, RecordForFollow.Time);
        }
    }
}