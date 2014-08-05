// File:    CCSMainViewModel.cs
// Author:  QuocNT
// Created: Friday, April 18, 2014 12:59:08 PM
// Purpose: Definition of Class CCSMainViewModel

using System;
using LogViewer.Model;
using System.Windows.Input;
using LogViewer.MVVMHelper;
using LogViewer.Business;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides method for analyze CCS log data
    /// </summary>

    public class CCSMainViewModel : BaseLogMainViewModel<CCSLogRecord>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="mainViewVM">Main model view</param>
        /// <param name="settingManager"><see cref="CXDISettingManager"/></param>
        /// <param name="onFollowOtherLogEvent">Process for follow mode action</param>
        /// <param name="onRecentFileChange">Process for recent file change </param>

        public CCSMainViewModel(object mainViewVM, CCSSettingManager settingManager, Action<string, string> onFollowOtherLogEvent, Action<string, bool> onRecentFileChange)
            : base(mainViewVM, settingManager, onFollowOtherLogEvent, onRecentFileChange)
        {
            //_logAnalyser = new CCSLogsAnalyser();
            //_logsDisplayVM = new CCSLogsDisplayViewModel(AddBookmark, RemoveBookmark,UpdateCurrentFileName, _baseSettingManger.DisplaySetting);
            //_baseAnalyzeAreaVM = new CCSAnalyzeAreaViewModel(LogsDisplayVM.ShowRecord);
            _patternVM.Title = Properties.Resources.TitleCCSPatternManager;
        }
        /// <summary>
        /// Get <see cref="CCSLogsAnalyser"/>
        /// </summary>
        public CCSLogsAnalyser LogAnalyser
        {
            get
            {
                return (CCSLogsAnalyser)_logAnalyser;
            }
        }
        /// <summary>
        /// Get <see cref="CCSSettingManager"/>
        /// </summary>

        public CCSSettingManager SettingManager
        {
            get
            {
                return _baseSettingManger as CCSSettingManager;
            }
        }
        /// <summary>
        /// Get <see cref="CCSAnalyzeAreaViewModel"/>
        /// </summary>
        public CCSAnalyzeAreaViewModel AnalyzeAreaVM
        {
            get
            {
                return _baseAnalyzeAreaVM as CCSAnalyzeAreaViewModel;
            }
        }
        /// <summary>
        /// Get filtering pattern for opening file <see cref="ConfigValue.CCSFileFilter"/>
        /// </summary>

        protected override string OpenFileFilter
        {
            get { return ConfigValue.CCSFileFilter; }
        }
        /// <summary>
        /// Get filtering pattern for opening memo file <see cref="ConfigValue.MemoFilterFile"/>
        /// </summary>

        protected override string OpenMemoFilterFile
        {
            get { return ConfigValue.MemoFilterFile; }
        }
        /// <summary>
        /// Create view model of filtering setting
        /// </summary>
        /// <param name="onApply">Process for filtering action</param>
        /// <returns></returns>
        protected override EditFilterSettingViewModel CreateEditFilterSettingVM(Action<List<FilterItemSetting>> onApply)
        {
            EditCCSFilterSettingViewModel filterVM = new EditCCSFilterSettingViewModel(onApply);
            filterVM.Title = Properties.Resources.TitleCCSFilterSetting;
            return filterVM;
        }
        /// <summary>
        /// Get file path for exporting memo
        /// </summary>
        /// <returns></returns>
        protected override string GetExportFilePath()
        {
            return string.Format(ConfigValue.CCSMemoFileNameFormat, ConfigValue.DefaultMemoFolderPath, Util.Utility.GetCurrentDateString());
        }
        /// <summary>
        /// Get item log from <see cref="ConfigValue.CCSHeader.AllLogField"/> in case there are no default one from setting file
        /// </summary>
        /// <returns>List of log display</returns>

        protected override List<ValueDisplayPair<string, string>> InitLogItemList()
        {
            var result = new List<ValueDisplayPair<string, string>>();
            ConfigValue.CCSHeader.AllLogField.ForEach((x) =>
            {
                result.Add(
                    new ValueDisplayPair<string, string> { Value = x, Display = Util.Utility.Translate(x) });
            });
            return result;
        }
        /// <summary>
        /// Validate log file extension
        /// </summary>
        /// <param name="FilePath">File path</param>
        /// <returns>True: if valid, otherwise is False</returns>
        protected override bool ValidLogFileExtension(string FilePath)
        {
            if (String.IsNullOrEmpty(FilePath)) return false;
            if (Path.GetExtension(FilePath) == ConfigValue.TxtExtension || Path.GetExtension(FilePath) == ConfigValue.CsvExtension)
                return true;
            else
                return false;
        }

        protected DelegateCommand _errorActionCommand;
        /// <summary>
        /// Command interface for error action
        /// </summary>
        public ICommand ErrorActionCommand
        {
            get
            {
                if (_errorActionCommand == null)
                {
                    _errorActionCommand = new DelegateCommand(ErrorActionCommandCL);
                }
                return _errorActionCommand;
            }
        }
        /// <summary>
        /// Command for error action
        /// </summary>
        protected virtual void ErrorActionCommandCL()
        {
            try{
                SettingManager.ReadErrorActionSetting();
                AnalyzeErrorAction(SettingManager.ErrorActionSettingList);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        protected DelegateCommand _userActionCommand;
        /// <summary>
        /// Command interface for user action
        /// </summary>
        public ICommand UserActionCommand
        {
            get
            {
                if (_userActionCommand == null)
                {
                    _userActionCommand = new DelegateCommand(UserActionCommandCL);
                }
                return _userActionCommand;
            }
        }
        /// <summary>
        /// Command for user action
        /// </summary>
        protected virtual void UserActionCommandCL()
        {
            try
            {
                SettingManager.ReadUserActionSetting();
                AnalyzeUserAction(SettingManager.UserActionSettingList);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        BackgroundWorker _userActionWorker = new BackgroundWorker();
        /// <summary>
        /// Do analyze user action
        /// </summary>
        /// <param name="userActions"><see cref="UserActionItem"/></param>
        protected void AnalyzeUserAction(IList<UserActionItem> userActions)
        {
            if (userActions == null) return;
            AnalyzeAreaVM.UserActionTabVM.ClearData();
            _userActionWorker.WorkerReportsProgress = true;
            _userActionWorker.WorkerSupportsCancellation = true;

            DoAnalyzeUserAction = ((sender, arg) =>
            {
                AnalyzeAreaVM.UserActionTabVM.IsShowTabUserAction = true;
                AnalyzeAreaVM.UserActionTabVM.IsLoadingData = true;
                LogAnalyser.AnalyzeUserActionWorker = _userActionWorker;
                LogAnalyser.AnalyzeUserAction(new List<UserActionItem>(userActions));
            });

            _userActionWorker.DoWork -= DoAnalyzeUserAction;
            _userActionWorker.DoWork += DoAnalyzeUserAction;
            RunCompleteDoAnalyzeUserAction = ((sender, arg) =>
            {
                AnalyzeAreaVM.UserActionTabVM.IsLoadingData= false;
                AnalyzeAreaVM.UserActionTabVM.LoadData(LogAnalyser.AnalyzedUserActionBuffer.OrderBy(x => x.Date).ThenBy(y => y.Time).ToList());
            }
            );
            _userActionWorker.RunWorkerCompleted -= RunCompleteDoAnalyzeUserAction;
            _userActionWorker.RunWorkerCompleted += RunCompleteDoAnalyzeUserAction;

            if (!_userActionWorker.IsBusy)
                _userActionWorker.RunWorkerAsync();
            else
            {
                StopUserActionWorker();
                _userActionWorker.RunWorkerAsync();
            }
        }
        DoWorkEventHandler DoAnalyzeUserAction;
        RunWorkerCompletedEventHandler RunCompleteDoAnalyzeUserAction;

        /// <summary>
        /// Stop user action background worker if had nay stop action from user input
        /// </summary>
        protected void StopUserActionWorker()
        {
            if (_userActionWorker.WorkerSupportsCancellation)
            {
                _userActionWorker.CancelAsync();
            }
            while (_userActionWorker.IsBusy)
            {
                Application.DoEvents();
            }

        }
        DoWorkEventHandler DoAnalyzeErrorAction;
        RunWorkerCompletedEventHandler RunCompleteDoAnalyzeErrorAction;
        BackgroundWorker _errorActionWorker = new BackgroundWorker();
        /// <summary>
        /// Analyze error action
        /// </summary>
        /// <param name="errorActions"><see cref="ErrorActionItem"/></param>
        protected void AnalyzeErrorAction(IList<ErrorActionItem> errorActions)
        {
            if (errorActions == null) return;
            AnalyzeAreaVM.ErrorActionTabVM.ClearData();
            _errorActionWorker.WorkerReportsProgress = true;
            _errorActionWorker.WorkerSupportsCancellation = true;
            DoAnalyzeErrorAction = ((sender, arg) =>
            {
                AnalyzeAreaVM.ErrorActionTabVM.IsShowTabError = true;
                AnalyzeAreaVM.ErrorActionTabVM.IsLoadingData = true;
                LogAnalyser.ErrorActionWorker = _errorActionWorker;
                LogAnalyser.AnalyzeErrorAction(new List<ErrorActionItem>(errorActions));
            });

            _errorActionWorker.DoWork -= DoAnalyzeErrorAction;
            _errorActionWorker.DoWork += DoAnalyzeErrorAction;

            RunCompleteDoAnalyzeErrorAction = ((sender, arg) =>
            {
                AnalyzeAreaVM.ErrorActionTabVM.IsLoadingData = false;
                AnalyzeAreaVM.ErrorActionTabVM.LoadData(LogAnalyser.AnalyzedErrorActionBuffer.OrderBy(x => x.Date).ThenBy(y => y.Time).ToList());
            }
            );
            _errorActionWorker.RunWorkerCompleted -= RunCompleteDoAnalyzeErrorAction;
            _errorActionWorker.RunWorkerCompleted += RunCompleteDoAnalyzeErrorAction;
            if (!_errorActionWorker.IsBusy)
                _errorActionWorker.RunWorkerAsync();
            else
            {
                StopErrorActionWorker();
                _errorActionWorker.RunWorkerAsync();
            }
        }
        /// <summary>
        /// Stop error action background worker if had any stop action from user input
        /// </summary>
        protected void StopErrorActionWorker()
        {
            if (_errorActionWorker.WorkerSupportsCancellation)
            {
                _errorActionWorker.CancelAsync();
            }
            while (_errorActionWorker.IsBusy)
            {
                Application.DoEvents();
            }
        }
        /// <summary>
        /// Stop any analyze process
        /// </summary>
        protected override void StopAllAnalyProcess() {
            base.StopAllAnalyProcess();
            StopUserActionWorker();
            StopErrorActionWorker();
        }
        /// <summary>
        /// Start all analyze process
        /// </summary>
        protected override void StartAllAnalyzeProcess()
        {
            base.StartAllAnalyzeProcess();
        }
        /// <summary>
        /// Initialize for system parameter from setting file
        /// </summary>
        /// <returns>Empty string if had no error, otherwise is error message</returns>

        public override string LoadConfig()
        {
            string errorMessage  = base.LoadConfig();
            try
            {
                SettingManager.ReadErrorActionSetting();
            }
            catch (Exception e){
                errorMessage += Environment.NewLine + e.Message;
            }
            try{
                SettingManager.ReadUserActionSetting();
            }
            catch (Exception e){
                errorMessage += Environment.NewLine + e.Message;
            }
            _logAnalyser = new CCSLogsAnalyser();
            _logsDisplayVM = new CCSLogsDisplayViewModel(AddBookmark, RemoveBookmark, UpdateCurrentFileName, FollowOtherLogAction, ShowPatternColoringRecord, _baseSettingManger.DisplaySetting, _baseSettingManger, OnClickRecordChange);
            _baseAnalyzeAreaVM = new CCSAnalyzeAreaViewModel(LogsDisplayVM.ShowRecord, LogsDisplayVM.ShowPatternColoringRecord, StopKeywordCountWorker, StopAnalyzePatternWorker, StopErrorActionWorker, StopUserActionWorker);
            _baseAnalyzeAreaVM.LogBookmarkTabVM.IsShowTabBookmark = true;
            return errorMessage;
        }
        /// <summary>
        /// Command for stop and clear any result
        /// </summary>
        public override void ClearAllCommandCL()
        {
            StopAllAnalyProcess();
            AnalyzeAreaVM.ErrorActionTabVM.ClearData();
            AnalyzeAreaVM.UserActionTabVM.ClearData();
            base.ClearAllCommandCL();
            ((MainViewModel)MainViewModelObject).SearchVM.clearCCS();
        }
        /// <summary>
        /// Command for clearing analyzed result
        /// </summary>

        public override void ClearAnalyzeCommandCL()
        {
            StopAllAnalyProcess();
            AnalyzeAreaVM.ErrorActionTabVM.ClearData();
            AnalyzeAreaVM.UserActionTabVM.ClearData();
            base.ClearAnalyzeCommandCL();
            ((MainViewModel)MainViewModelObject).SearchVM.clearCCS();

        }
        /// <summary>
        /// Stop any process and clear any display result
        /// </summary>
        protected override void ClearWhenLoadFile()
        {
            StopAllAnalyProcess();
            base.ClearWhenLoadFile();
            AnalyzeAreaVM.ErrorActionTabVM.ClearData();
            AnalyzeAreaVM.UserActionTabVM.ClearData();
        }
        /// <summary>
        /// Get default log header for content column
        /// </summary>
        /// <returns>Name of log header</returns>

        protected override string GetDefaultLogItem()
        {
            return ConfigValue.CCSHeader.HEADER_CONTENT;
        }
        /// <summary>
        /// Create view model for keyword count setting 
        /// </summary>
        /// <param name="onApply">Process for applying action</param>
        /// <returns><see cref="EditKeywordCountSettingViewModel"/></returns>

        protected override EditKeywordCountSettingViewModel CreateEditKeywordCountSettingVM(Action<List<KeywordCountItemSetting>> onApply)
        {
            EditCCSKeywordCountSettingViewModel keywordVM = new EditCCSKeywordCountSettingViewModel(onApply);
            keywordVM.Title = Properties.Resources.TitleCCSKeywordCountSetting;
            return keywordVM;
        }
        /// <summary>
        /// Command for editing keyword count
        /// </summary>

        protected override void EditKeywordCountSettingCL()
        {
            _keywordVM.IsCCS = true;
            base.EditKeywordCountSettingCL();
        }
        /// <summary>
        /// Command for editing filtering
        /// </summary>
        protected override void EditFilterSettingCL()
        {
            _filterVM.IsCCS = true;
            base.EditFilterSettingCL();
        }
        /// <summary>
        /// Command for editing pattern
        /// </summary>
        protected override void EditPatternSettingCL()
        {
            _patternVM.IsCCS = true;
            base.EditPatternSettingCL();
        }
        /// <summary>
        /// Get sub string status of a string key with message column of <see cref="CXDILogRecord"/>
        /// </summary>
        /// <param name="record"><see cref="CXDILogRecord"/></param>
        /// <param name="key">A substring to be search</param>
        /// <returns>True: if the content column of log record contain given key, otherwise is false</returns>
        protected override bool contains(CCSLogRecord record, string key)
        {
            return record.Content.Contains(key);
        }
    }
}