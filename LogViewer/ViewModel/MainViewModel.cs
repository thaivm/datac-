// File:    MainViewModel.cs
// Author:  QuocNT
// Created: Friday, April 18, 2014 12:58:51 PM
// Purpose: Definition of Class MainViewModel

using System;
using LogViewer.Business.FileSetting;
using LogViewer.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LogViewer.CustomException;
using LogViewer.MVVMHelper;
using System.Windows.Input;
using LogViewer.Business;

namespace LogViewer.ViewModel
{

    /// <summary>
    /// Class process main function in area of CCS and CXDI
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        /// <summary>
        /// Get SearchKeywordViewModel <see cref="SearchKeywordViewModel"/>
        /// </summary>
        protected SearchKeywordViewModel _searchVM;
        public SearchKeywordViewModel SearchVM
        {
            get
            {
                return _searchVM;
            }
        }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            _searchVM = new SearchKeywordViewModel(SearchCCS, SearchCXDI, ShowCCSRecord, ShowCXDIRecord);
        }

        /// <summary>
        /// Initialize data to CCSMain and CXDIMain
        /// </summary>
        public void Init()
        {
            CCSMainVM = new CCSMainViewModel(this, new CCSSettingManager(), CXDIShowRecordWithDateTime, RecentFileChange);
            CXDIMainVM = new CXDIMainViewModel(this, new CXDISettingManager(), CCSShowRecordWithDateTime, RecentFileChange);
            CXDIMainVM.OnDoneLoadDataEvent += CCSMainVM.OnOtherLogsLoadedHandler;
            CCSMainVM.OnDoneLoadDataEvent += CXDIMainVM.OnOtherLogsLoadedHandler;

            LoadConfig();
        }
        /// <summary>
        /// CXDI show record with date time
        /// </summary>
        /// <param name="date">Date to follow</param>
        /// <param name="time">Time to follow</param>
        protected void CXDIShowRecordWithDateTime(string date, string time)
        {
            CXDIMainVM.FollowRecordWithDateTime(date, time);
        }
        /// <summary>
        /// CCS Show record with date time
        /// </summary>
        /// <param name="date">Date to follow</param>
        /// <param name="time">Time to follow</param>
        protected void CCSShowRecordWithDateTime(string date, string time)
        {
            CCSMainVM.FollowRecordWithDateTime(date, time);
        }
        /// <summary>
        /// Get or set Recent File
        /// </summary>
        protected string _recentFile;
        public string RecentFile
        {
            get
            {
                return _recentFile;
            }
            set
            {
                _recentFile = value;
                OnPropertyChanged("RecentFile");
            }
        }
        /// <summary>
        /// Get or set RecentFileAction
        /// </summary>
        public RecentFileAction _recentFileAction;
        public RecentFileAction RecentFileAction
        {
            get
            {
                if(_recentFileAction == null)
                    return new RecentFileAction(null, CCSMainVM.ProcessBeforeLoadLog, CXDIMainVM.ProcessBeforeLoadLog);
                return _recentFileAction;
            }
            set
            {
                _recentFileAction = value;
                OnPropertyChanged("RecentFileAction");
            }
        }
        /// <summary>
        /// Get or set CCSMain ViewModel
        /// </summary>
        protected CCSMainViewModel _ccsMainVM;
        public CCSMainViewModel CCSMainVM
        {
            get
            {
                return _ccsMainVM;
            }
            set
            {
                _ccsMainVM = value;
                OnPropertyChanged("CCSMainVM");
            }
        }

        /// <summary>
        /// Get or set CXDI Main ViewModel
        /// </summary>
        protected CXDIMainViewModel _cxdiMainVM;
        public CXDIMainViewModel CXDIMainVM
        {
            get
            {
                return _cxdiMainVM;
            }
            set
            {
                _cxdiMainVM = value;
                OnPropertyChanged("CXDIMainVM");
            }
        }
        /// <summary>
        /// Get or set Is On follow mode CCS
        /// </summary>
        protected bool _isOnFollowModeCCS;
        public bool IsOnFollowModeCCS
        {
            get
            {
                return _isOnFollowModeCCS;
            }
            set
            {
                _isOnFollowModeCCS = value;
                _isOnFollowModeCXDI = value;
                //if (value == true)
                //{
                //    if (IsOnFollowModeCXDI == true)
                //    {
                //        _isOnFollowModeCXDI = false;
                //        OnPropertyChanged("IsOnFollowModeCXDI");
                //        CCSMainVM.LogsDisplayVM.IsOnFollowMode = false;
                //    }
                //}
                CXDIMainVM.LogsDisplayVM.IsOnFollowMode = value;
                CCSMainVM.LogsDisplayVM.IsOnFollowMode = value;
                OnPropertyChanged("IsOnFollowModeCCS");
                OnPropertyChanged("IsOnFollowModeCXDI");
            }
        }
        /// <summary>
        /// Get or set Is On Follow Mode CXDI
        /// </summary>
        protected bool _isOnFollowModeCXDI;
        public bool IsOnFollowModeCXDI
        {
            get
            {
                return _isOnFollowModeCXDI;
            }
            set
            {
                _isOnFollowModeCCS = value;
                _isOnFollowModeCXDI = value;
                //if (value == true)
                //{
                //    if (IsOnFollowModeCCS == true)
                //    {
                //        _isOnFollowModeCCS = false;
                //        OnPropertyChanged("IsOnFollowModeCCS");
                //        CXDIMainVM.LogsDisplayVM.IsOnFollowMode = false;
                //    }
                //}
                CCSMainVM.LogsDisplayVM.IsOnFollowMode = value;
                CXDIMainVM.LogsDisplayVM.IsOnFollowMode = value;
                OnPropertyChanged("IsOnFollowModeCCS");
                OnPropertyChanged("IsOnFollowModeCXDI");
            }
        }
        /// <summary>
        /// Get or set command for menu item Search keyword
        /// </summary>
        protected DelegateCommand _searchKeywordCommand;
        public ICommand SearchKeywordCommand
        {
            get
            {
                if (_searchKeywordCommand == null)
                {
                    _searchKeywordCommand = new DelegateCommand(SearchKeywordCommandCL);
                }
                return _searchKeywordCommand;
            }
        }
        /// <summary>
        /// Search keyword function run when click button search in Search Keyword window
        /// </summary>
        protected virtual void SearchKeywordCommandCL()
        {
            //var vm = new SearchKeywordViewModel(SearchCCS,SearchCXDI,ShowCCSRecord,ShowCXDIRecord);
            //vm.ShowDialog(this);
            if (!_searchVM.IsShow)
                _searchVM.init();
            _searchVM.Show(this);
        }
        /// <summary>
        /// Recent File Change
        /// </summary>
        /// <param name="recentFile">File path</param>
        /// <param name="flag">Status when add to recent list. True add, false not add</param>
        public void RecentFileChange(string recentFile, bool flag)
        {
            if (!flag)
                RecentFile = recentFile;
            else
            {
                RecentFileAction = new RecentFileAction(RecentFile, CCSMainVM.ProcessBeforeLoadLog, CXDIMainVM.ProcessBeforeLoadLog);
            }
        }
        /// <summary>
        /// Load configuration file when start application
        /// </summary>
        protected void LoadConfig()
        {

            //LogViewer.Model.BaseSettingManager settingManager = new CCSSettingManager();


            //settingManager.FilterSettingFilePath = Constant.ConfigFilterFile;
            //settingManager.PatternItemSettingFilePath = Constant.DefaultPatternSetting;
            //settingManager.ReadPattermSetting();

            //settingManager.WritePattermSetting();
            //settingManager.ReadFilterSetting();
            //settingManager.ReadKeywordCountSettingFile();

            string errorMessageCCS = CCSMainVM.LoadConfig();
            string errorMessageCXDI =  CXDIMainVM.LoadConfig();
            string errorMessage = errorMessageCCS;
            if (errorMessageCXDI != string.Empty) {
                errorMessage += Environment.NewLine+errorMessageCXDI;
            }
            if (errorMessage != string.Empty)
            {
                MessageBoxViewModel vm = new MessageBoxViewModel();
                vm.ButtonValue = System.Windows.MessageBoxButton.OK;
                vm.Text = errorMessage;
                vm.ShowDialog(this);
            }
        }

        /// <summary>
        /// Get List record when search CCS for search condition
        /// </summary>
        /// <param name="searchCondition">Search condition for CCS</param>
        /// <returns></returns>
        public IList<CCSLogRecord> SearchCCS(SearchItem searchCondition)
        {
            return CCSMainVM.Search(searchCondition);
        }
        /// <summary>
        /// Get List record when search CXDI for search condition
        /// </summary>
        /// <param name="searchCondition">Search condition for CXDI</param>
        /// <returns></returns>
        public IList<CXDILogRecord> SearchCXDI(SearchItem searchCondition)
        {
            return CXDIMainVM.Search(searchCondition);
        }
        /// <summary>
        /// Scroll to CCS record with record
        /// </summary>
        /// <param name="record"><see cref="CCSLogRecord"/></param>
        internal void ShowCCSRecord(CCSLogRecord record)
        {
            CCSMainVM.ShowRecord(record);
        }
        /// <summary>
        /// Scroll to CXDI record with record
        /// </summary>
        /// <param name="record"><see cref="CXDILogRecord"/></param>
        internal void ShowCXDIRecord(CXDILogRecord record)
        {
            CXDIMainVM.ShowRecord(record);
        }
        /// <summary>
        /// Get or set Command of menu item Set log parameter.
        /// </summary>
        protected DelegateCommand _setLogParameterCommand;
        public ICommand SetLogParameterCommand
        {
            get
            {
                if (_setLogParameterCommand == null)
                {
                    _setLogParameterCommand = new DelegateCommand(SetLogParameterCommandCL);
                }
                return _setLogParameterCommand;
            }
        }
        /// <summary>
        /// Function Show SetLogParameter Window
        /// </summary>
        protected void SetLogParameterCommandCL()
        {
            var vm = new SetLogDisplayViewModel(ApplyLogDisplay);
            vm.LoadData(CCSMainVM.SettingManager.DisplaySetting,CXDIMainVM.SettingManager.DisplaySetting);
            vm.ShowDialog(this);
        }
        /// <summary>
        /// Function run when click button Apply in SetLogParameter window
        /// </summary>
        /// <param name="data">List LogDisplay condition</param>
        protected void ApplyLogDisplay(List<List<LogDisplay>> data)
        {
            CCSMainVM.SettingManager.DisplaySetting = data[0];
            CXDIMainVM.SettingManager.DisplaySetting = data[1];
            ((CCSLogsDisplayViewModel)CCSMainVM.LogsDisplayVM).HeaderToShow = data[0];
            ((CXDILogsDisplayViewModel)CXDIMainVM.LogsDisplayVM).HeaderToShow = data[1];

            string errorMessage = string.Empty;
            try
            {
                CCSMainVM.SettingManager.WriteDisplaySetting();
            }
            catch(Exception e) {
                errorMessage = e.Message;
            }
            try
            {
                CXDIMainVM.SettingManager.WriteDisplaySetting();
            }
            catch (Exception e) {
                if (errorMessage == string.Empty)
                {
                    errorMessage = e.Message;
                }
                else { errorMessage += Environment.NewLine + e.Message; }
            }
            if (errorMessage != string.Empty)
            {
                MessageBoxViewModel vm = new MessageBoxViewModel();
                vm.ButtonValue = System.Windows.MessageBoxButton.OK;
                vm.Text = errorMessage;
                vm.ShowDialog(this);
            }
        }
        /// <summary>
        /// Get or set Command of menu item Expand.
        /// </summary>
        protected DelegateCommand _expandCommand;
        public ICommand ExpandCommand
        {
            get
            {
                if (_expandCommand == null)
                {
                    _expandCommand = new DelegateCommand(ExpandCommandCL, () => IsEnableButton());
                }
                return _expandCommand;
            }
        }
        /// <summary>
        /// Run when click menu item Expand
        /// </summary>
        public void ExpandCommandCL()
        {
            CCSMainVM.ExpandCommandCL();
            CXDIMainVM.ExpandCommandCL();
        }
        /// <summary>
        /// Get or set Command of menu item Shrink.
        /// </summary>
        protected DelegateCommand _shrinkCommand;
        public ICommand ShrinkCommand
        {
            get
            {
                if (_shrinkCommand == null)
                {
                    _shrinkCommand = new DelegateCommand(ShrinkCommandCL, () => IsEnableButton());
                }
                return _shrinkCommand;
            }
        }
        /// <summary>
        /// Run when click menu item Shrink
        /// </summary>
        public void ShrinkCommandCL()
        {
            CCSMainVM.ShirnkCommandCL();
            CXDIMainVM.ShirnkCommandCL();
        }
        /// <summary>
        /// Check can execute menu item
        /// </summary>
        /// <returns></returns>
        protected bool IsEnableButton()
        {
            if (CCSMainVM.LogAnalyser.AllLogRecordsBuffer == null && CXDIMainVM.LogAnalyser.AllLogRecordsBuffer == null)
            {
                return false;
            }
            if (CCSMainVM.LogAnalyser.AllLogRecordsBuffer.Count == 0 && CXDIMainVM.LogAnalyser.AllLogRecordsBuffer.Count == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Get or set Command of menu item Reset bookmark.
        /// </summary>
        protected DelegateCommand _resetBookmarkCommand;
        public ICommand ResetBookmarkCommand
        {
            get
            {
                if (_resetBookmarkCommand == null)
                {
                    _resetBookmarkCommand = new DelegateCommand(ResetBookmarkCommandCL,() => IsEnableButton());
                }
                return _resetBookmarkCommand;
            }
        }
        /// <summary>
        /// Run when click menu item ResetBookmark.
        /// </summary>
        public void ResetBookmarkCommandCL()
        {
            CCSMainVM.LogAnalyser.ClearBookmark();
            CXDIMainVM.LogAnalyser.ClearBookmark();
            CCSMainVM.BaseAnalyzeAreaVM.LogBookmarkTabVM.ResetBookmark();
            CXDIMainVM.BaseAnalyzeAreaVM.LogBookmarkTabVM.ResetBookmark(); 
        }
        /// <summary>
        /// Get or set Command of menu item Reset comment.
        /// </summary>
        protected DelegateCommand _resetCommentCommand;
        public ICommand ResetCommentCommand
        {
            get
            {
                if (_resetCommentCommand == null)
                {
                    _resetCommentCommand = new DelegateCommand(ResetCommentCommandCL, () => IsEnableButton());
                }
                return _resetCommentCommand;
            }
        }
        /// <summary>
        /// Run when click menu item ResetComment.
        /// </summary>
        public void ResetCommentCommandCL()
        {
            CCSMainVM.LogAnalyser.ClearComment();
            CXDIMainVM.LogAnalyser.ClearComment();
        }
        /// <summary>
        /// Get or set Command of menu item Clear all.
        /// </summary>
        protected DelegateCommand _clearAllCommand;
        public ICommand ClearAllCommand
        {
            get
            {
                if (_clearAllCommand == null)
                {
                    _clearAllCommand = new DelegateCommand(ClearAllCommandCL, () => IsEnableButton());
                }
                return _clearAllCommand;
            }
        }
        /// <summary>
        /// Run when click menu item ClearAll
        /// </summary>
        public void ClearAllCommandCL()
        {
            //ccs
            CCSMainVM.ClearAllCommandCL();
            //cxdi
            CXDIMainVM.ClearAllCommandCL();
        }
        /// <summary>
        /// Get or set Command of menu item Clear analyze.
        /// </summary>
        protected DelegateCommand _clearAnalyzeCommand;
        public ICommand ClearAnalyzeCommand
        {
            get
            {
                if (_clearAnalyzeCommand == null)
                {
                    _clearAnalyzeCommand = new DelegateCommand(ClearAnalyzeCommandCL, () => IsEnableButton());
                }
                return _clearAnalyzeCommand;
            }
        }
        /// <summary>
        /// Run when click menu item ClearAnalyze
        /// </summary>
        public virtual void ClearAnalyzeCommandCL()
        {
            //_searchVM.init();
            CCSMainVM.ClearAnalyzeCommandCL();
            CXDIMainVM.ClearAnalyzeCommandCL();
        }
        /// <summary>
        /// Get or set Command of menu item Clear color filter.
        /// </summary>
        protected DelegateCommand _clearColorFilterSettingCommand;
        public ICommand ClearColorFilterSettingCommand
        {
            get
            {
                if (_clearColorFilterSettingCommand == null)
                {
                    _clearColorFilterSettingCommand = new DelegateCommand(ClearColorFilterSettingCommandCL, () => IsEnableButton());
                }
                return _clearColorFilterSettingCommand;
            }
        }
        /// <summary>
        /// Run when click menu item ClearColorFilter
        /// </summary>
        protected virtual void ClearColorFilterSettingCommandCL()
        {
            //LoadingDialogViewModel loadDlgVM = new LoadingDialogViewModel();
            //loadDlgVM.ExecuteWhilePopUpLoading(() =>
            //{
                CCSMainVM.ClearColorFilterSetting();
                //CCSMainVM.ClearNarrowFilter();
                CCSMainVM.LoadDataWhenClearColor();
                CXDIMainVM.ClearColorFilterSetting();
                CXDIMainVM.LoadDataWhenClearColor();
                //CXDIMainVM.ClearNarrowFilter();
            //},
            //this, () =>
            //{

            //});
        }
        /// <summary>
        /// Get or set Command of menu item Reset filter.
        /// </summary>
        protected DelegateCommand _resetFilterCommand;
        public ICommand ResetFilterCommand
        {
            get
            {
                if (_resetFilterCommand == null)
                {
                    _resetFilterCommand = new DelegateCommand(ResetFilterCommandCL, () => IsEnableButton());
                }
                return _resetFilterCommand;
            }
        }
        /// <summary>
        /// Run when click menu item ResetFilter
        /// </summary>
        protected virtual void ResetFilterCommandCL()
        {
            CCSMainVM.ClearNarrowFilter();
            CXDIMainVM.ClearNarrowFilter();
        }
    }
}