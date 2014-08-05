// File:    CXDIMainViewModel.cs
// Author:  QuocNT
// Created: Friday, April 18, 2014 12:59:10 PM
// Purpose: Definition of Class CXDIMainViewModel

using System;
using LogViewer.Business.FileSetting;
using LogViewer.Model;
using System.Linq;
using LogViewer.Business;
using System.Windows.Forms;
using System.ComponentModel;
using LogViewer.MVVMHelper;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides method for analyze CXDI log data
    /// </summary>
    public class CXDIMainViewModel : BaseLogMainViewModel<CXDILogRecord>
    {
        public CXDILogsDisplayViewModel _cXDILogsDisplayViewModel;
        public CXDIAnalyzeAreaViewModel _cXDIAnalyzeAreaViewModel;

        protected GraphViewModel graphVM;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="mainViewVM">Main model view</param>
        /// <param name="settingManager"><see cref="CXDISettingManager"/></param>
        /// <param name="onFollowOtherLogEvent">Process for follow mode action</param>
        /// <param name="onRecentFileChange">Process for recent file change </param>
        public CXDIMainViewModel(object mainViewVM, CXDISettingManager settingManager, Action<string, string> onFollowOtherLogEvent, Action<string, bool> onRecentFileChange)
            : base(mainViewVM, settingManager, onFollowOtherLogEvent, onRecentFileChange)
        {
            graphVM = new GraphViewModel(ApplyGraphSetting);
            _patternVM.Title = Properties.Resources.TitleCXDIPatternManager;
        }
        /// <summary>
        /// Get <see cref="CXDILogsAnalyze"/>
        /// </summary>
        public CXDILogsAnalyser LogAnalyser
        {
            get
            {
                return (CXDILogsAnalyser)_logAnalyser;
            }
        }
        /// <summary>
        /// Get <see cref="CXDISettingManager"/>
        /// </summary>
        public CXDISettingManager SettingManager
        {
            get
            {
                return _baseSettingManger as CXDISettingManager;
            }
        }
        /// <summary>
        /// Get <see cref="CXDIAnalyzeAreaViewModel"/>
        /// </summary>
        public CXDIAnalyzeAreaViewModel AnalyzeAreaVM
        {
            get
            {
                return (CXDIAnalyzeAreaViewModel)_baseAnalyzeAreaVM;
            }
        }
        /// <summary>
        /// Get filtering pattern for opening file <see cref="ConfigValue.CXDIFileFilter"/>
        /// </summary>
        protected override string OpenFileFilter
        {
            get { return ConfigValue.CXDIFileFilter; }
        }
        /// <summary>
        /// Get filtering pattern for opening memo file <see cref="ConfigValue.CXDIFileFilter"/>
        /// </summary>
        protected override string OpenMemoFilterFile
        {
            get { return  ConfigValue.MemoFilterFile; }
        }
        protected DelegateCommand _showGraphCommand;
        /// <summary>
        /// Command interface for showing graph
        /// </summary>
        public ICommand ShowGraphCommand
        {
            get
            {
                if (_showGraphCommand == null)
                {
                    _showGraphCommand = new DelegateCommand(ShowGraphCommandCL);
                }
                return _showGraphCommand;
            }
        }
        /// <summary>
        /// Command for loading log file
        /// </summary>
        protected override void LoadLogFileCL()
        {
            base.LoadLogFileCL();
            var firstRecord = _logAnalyser.AllLogRecordsBuffer.FirstOrDefault();
            var lastRecord = _logAnalyser.AllLogRecordsBuffer.LastOrDefault();
            //var vm = new GraphViewModel(ApplyGraphSetting);
            graphVM._firstRecord = firstRecord;
            graphVM._lastRecord = lastRecord;
        }
        /// <summary>
        /// Command for loading memo log file
        /// </summary>
        protected override void LoadMemoLogFileCL()
        {
            base.LoadMemoLogFileCL();
            var firstRecord = _logAnalyser.AllLogRecordsBuffer.FirstOrDefault();
            var lastRecord = _logAnalyser.AllLogRecordsBuffer.LastOrDefault();
            //var vm = new GraphViewModel(ApplyGraphSetting);
            graphVM._firstRecord = firstRecord;
            graphVM._lastRecord = lastRecord;
        }
        /// <summary>
        /// Command for drag and drop file
        /// </summary>
        /// <param name="args"><see cref="DataGridDragDropEventArgs"/></param>
        public override void DragDropFile(DataGridDragDropEventArgs args)
        {
            base.DragDropFile(args);
            var firstRecord = _logAnalyser.AllLogRecordsBuffer.FirstOrDefault();
            var lastRecord = _logAnalyser.AllLogRecordsBuffer.LastOrDefault();
            //var vm = new GraphViewModel(ApplyGraphSetting);
            graphVM._firstRecord = firstRecord;
            graphVM._lastRecord = lastRecord;
        }
        /// <summary>
        /// Command for showing graph
        /// </summary>
        protected virtual void ShowGraphCommandCL()
        {
            GraphResult graphLineData1,graphLineData2;
            IList<GraphResult> eventResults;
            LoadingDialogViewModel loadDlgVM = new LoadingDialogViewModel();
            loadDlgVM.ExecuteWhilePopUpLoading(() =>
                {
                    LogAnalyser.AnalyGraphParam(SettingManager.GraphParamSettingList,
                        out graphLineData1, out graphLineData2, out eventResults);
                    graphVM.LoadData(graphLineData1,
                        graphLineData2,
                        eventResults,
                        SettingManager.GraphParamSettingList);
                }, MainViewModelObject, () =>
                {
                    graphVM.Show(MainViewModelObject);
                });
            
        }
        /// <summary>
        /// Apply graph setting after edit
        /// </summary>
        /// <param name="paramSetting"><see cref="GraphParamSetting"/></param>
        /// <param name="graphLineData1"><see cref="GraphResult"/> (line 1)</param>
        /// <param name="graphLineData2"><see cref="GraphResult"/> (line 2)</param>
        /// <param name="eventResults"><see cref="GraphResult"/> (event line)</param>
        protected virtual void ApplyGraphSetting(IList<GraphParamSetting> paramSetting,
            out GraphResult graphLineData1,
            out GraphResult graphLineData2, out IList<GraphResult> eventResults)
        {
            SettingManager.GraphParamSettingList = paramSetting;
            LogAnalyser.AnalyGraphParam(paramSetting, out graphLineData1, out graphLineData2, out eventResults);
            string errorMessage = string.Empty;
            try
            {
                SettingManager.WriteGraphParamSetting();
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
    
            if (errorMessage != string.Empty)
            {
                MessageBox.Show(errorMessage);
            }
        }
        /// <summary>
        /// Load firmware <seealso cref="CXDIFirmware"/>
        /// </summary>
        protected virtual void LoadFirmware()
        {
            AnalyzeAreaVM.FirmwareInfoTabVM.CXDIFirmware = LogAnalyser.Firmware;
        }
        /// <summary>
        /// Create view model for filtering setting
        /// </summary>
        /// <param name="onApplyEvent">Process for applying action</param>
        /// <returns><see cref="EditFilterSettingViewModel"/></returns>
        protected override EditFilterSettingViewModel CreateEditFilterSettingVM(Action<List<FilterItemSetting>> onApplyEvent)
        {
            EditCXDIFilterSettingViewModel filterVM = new EditCXDIFilterSettingViewModel(onApplyEvent);
            filterVM.Title = Properties.Resources.TitleCXDIFilterSetting;
            return filterVM;
        }

        /// <summary>
        /// Get path for exporting file
        /// </summary>
        /// <returns>File name</returns>
        protected override string GetExportFilePath()
        {
            return string.Format(ConfigValue.CXDIMemoFileNameFormat, ConfigValue.DefaultMemoFolderPath, Util.Utility.GetCurrentDateString());
        }
        /// <summary>
        /// Command for clearing all processing data
        /// </summary>
        public override void ClearAllCommandCL()
        {
            base.ClearAllCommandCL();
            AnalyzeAreaVM.FirmwareInfoTabVM.ClearData();
            ((MainViewModel)MainViewModelObject).SearchVM.clearCXDI();
        }
        /// <summary>
        /// Command for clearing analyzed result
        /// </summary>
        public override void ClearAnalyzeCommandCL()
        {
            base.ClearAnalyzeCommandCL();
            ((MainViewModel)MainViewModelObject).SearchVM.clearCXDI();
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
                SettingManager.ReadGraphParamSetting();
            }
            catch(Exception e) {
                if (errorMessage != string.Empty)
                {
                    errorMessage += Environment.NewLine + e.Message;
                }
            }
            _logAnalyser = new CXDILogsAnalyser();
            _logsDisplayVM = new CXDILogsDisplayViewModel(AddBookmark, RemoveBookmark, UpdateCurrentFileName, FollowOtherLogAction, ShowPatternColoringRecord, _baseSettingManger.DisplaySetting, _baseSettingManger, OnClickRecordChange);
            _baseAnalyzeAreaVM = new CXDIAnalyzeAreaViewModel(LogsDisplayVM.ShowRecord, LogsDisplayVM.ShowPatternColoringRecord, StopKeywordCountWorker, StopAnalyzePatternWorker);
            _baseAnalyzeAreaVM.LogBookmarkTabVM.IsShowTabBookmark = true;
            return errorMessage;
        }
        /// <summary>
        /// Start all analyzing process background
        /// </summary>
		protected override void StartAllAnalyzeProcess()
        {
            base.StartAllAnalyzeProcess();
            LoadFirmware();
        }
        /// <summary>
        /// Get item log from <see cref="ConfigValue.CXDIHeader.AllLogField" /> in case there are no default one from setting file
        /// </summary>
        /// <returns>List of log display</returns>
        protected override List<ValueDisplayPair<string, string>> InitLogItemList()
        {
            var result = new List<ValueDisplayPair<string, string>>();
            ConfigValue.CXDIHeader.AllLogField.ForEach((x) =>
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
            if(String.IsNullOrEmpty(FilePath)) return false;
            if (Path.GetExtension(FilePath) == ConfigValue.LogExtension)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Get default log header for message column
        /// </summary>
        /// <returns>Name of log header</returns>
        protected override string GetDefaultLogItem()
        {
            return ConfigValue.CXDIHeader.HEADER_MESSAGE;
        }
        /// <summary>
        /// Create view model for keyword count setting 
        /// </summary>
        /// <param name="onApply">Process for applying action</param>
        /// <returns><see cref="EditKeywordCountSettingViewModel"/></returns>
        protected override EditKeywordCountSettingViewModel CreateEditKeywordCountSettingVM(Action<List<KeywordCountItemSetting>> onApply)
        {
            EditCXDIKeywordCountSettingViewModel keywordVM = new EditCXDIKeywordCountSettingViewModel(onApply);
            keywordVM.Title = Properties.Resources.TitleCXDIKeywordCountSetting;
            return keywordVM;
        }
        /// <summary>
        /// Command for editing keyword count
        /// </summary>
        protected override void EditKeywordCountSettingCL()
        {
            _keywordVM.IsCCS = false;
            base.EditKeywordCountSettingCL();
        }
        /// <summary>
        /// Command for editing filtering
        /// </summary>
        protected override void EditFilterSettingCL()
        {
            _filterVM.IsCCS = false;
            base.EditFilterSettingCL();
        }
        /// <summary>
        /// Command for editing pattern
        /// </summary>
        protected override void EditPatternSettingCL()
        {
            _patternVM.IsCCS = false;
            base.EditPatternSettingCL();
        }
        /// <summary>
        /// Get sub string status of a string key with message column of <see cref="CXDILogRecord"/>
        /// </summary>
        /// <param name="record"><see cref="CXDILogRecord"/></param>
        /// <param name="key">A substring to be search</param>
        /// <returns>True: if the message column of log record contain given key, otherwise is false</returns>
        protected override bool contains(CXDILogRecord record, string key)
        {
            return record.Message.Contains(key);
        }
    }
}
