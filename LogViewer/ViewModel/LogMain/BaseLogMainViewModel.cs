using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Business.FileSetting;
using LogViewer.MVVMHelper;
using System.Windows.Input;
using LogViewer.Business;
using LogViewer.Service;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using System.Windows.Forms;
using LogViewer.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;
namespace LogViewer.ViewModel
{
    /// <summary>
    /// Base class provides common methods for analyze log data
    /// </summary>

    public abstract class BaseLogMainViewModel<T> : BaseViewModel, IDataErrorInfo where T : BaseLogRecord
    {
        protected Action<string, string> FollowOtherLogAction;
        public event Action OnDoneLoadDataEvent;
        public Action<string, bool> OnRecentFileChange;
        #region Fields
        protected BaseLogsAnalyser<T> _logAnalyser;
        protected BaseSettingManager _baseSettingManger;
        protected EditFilterSettingViewModel _filterVM;
        protected EditKeywordCountSettingViewModel _keywordVM;
        protected EditPatternSettingViewModel _patternVM;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="mainViewVM">Main model view</param>
        /// <param name="settingManager"><see cref="BaseSettingManager"/></param>
        /// <param name="onFollowOtherLogEvent">Process for follow mode action</param>
        /// <param name="onRecentFileChange">Process for recent file change </param>

        public BaseLogMainViewModel(object mainViewVM, BaseSettingManager settingManager, Action<string, string> onFollowOtherLogEvent, Action<string, bool> onRecentFileChange)
        {
            MainViewModelObject = mainViewVM;
            _baseSettingManger = settingManager;
            LogItemList = new ObservableCollection<ValueDisplayPair<string, string>>(InitLogItemList());
            LogItem = GetDefaultLogItem();
            FollowOtherLogAction = onFollowOtherLogEvent;
            OnRecentFileChange = onRecentFileChange;
            _filterVM = (CreateEditFilterSettingVM(ApplyFilterSetting));
            _keywordVM = (CreateEditKeywordCountSettingVM(ApplyKeywordCountSetting));
            IsOpenPopup = false;
            _patternVM = new EditPatternSettingViewModel(ApplyPatternSetting);
        }

        #endregion // Fields
        #region Property
        /// <summary>
        /// Get filtering pattern for opening file <see cref="ConfigValue.CCSFileFilter"/> or <see cref="ConfigValue.CXDIFileFilter"/>
        /// </summary>
        protected abstract string OpenFileFilter { get; }
        /// <summary>
        /// Get filtering pattern for opening memo file <see cref="ConfigValue.MemoFilterFile"/>
        /// </summary>

        protected abstract string OpenMemoFilterFile { get; }
        /// <summary>
        /// Get <see cref="AllLogRecordsBuffer"/> status. True: has data, otherwise is False <see cref="BaseLogsAnalyzer<T>"/>
        /// </summary>
        public bool HasLogsData
        {
            get
            {
                if (_logAnalyser.AllLogRecordsBuffer != null && _logAnalyser.AllLogRecordsBuffer.Count > 0)
                    return true;
                return false;
            }
        }
        BaseLogRecordDisplayViewModel<T> _clickedRecordChange;
        /// <summary>
        /// Get or set the record that has change status
        /// </summary>
        public BaseLogRecordDisplayViewModel<T> ClickedRecordChange
        {
            get
            {
                return _clickedRecordChange;
            }
            set
            {
                _clickedRecordChange = value;
                OnPropertyChanged("ClickedRecordChange");
            }
        }
        protected bool _isOnNarrowColorFilter;
        /// <summary>
        /// Get or set on narrow color filtering status
        /// </summary>
        public bool IsOnNarrowColorFilter
        {
            get
            {
                return _isOnNarrowColorFilter;
            }
            set
            {
                _isOnNarrowColorFilter = value;
                OnPropertyChanged("IsOnNarrowColorFilter");
            }
        }

        protected bool _isOnNarrowNonColorFilter;
        /// <summary>
        /// Get or set on narrow no color filtering status
        /// </summary>
        public bool IsOnNarrowNonColorFilter
        {
            get
            {
                return _isOnNarrowNonColorFilter;
            }
            set
            {
                _isOnNarrowNonColorFilter = value;
                OnPropertyChanged("IsOnNarrowNonColorFilter");
            }
        }

        protected ObservableCollection<FilterButtonViewModel> _filterSettingList;
        /// <summary>
        /// Get or set list of filtering setting items
        /// </summary>
        public ObservableCollection<FilterButtonViewModel> FilterSettingList
        {
            get
            {
                return _filterSettingList;
            }
            set
            {
                _filterSettingList = value;
                OnPropertyChanged("FilterSettingList");
            }
        }
        protected ObservableCollection<LogDisplay> _displaySetting;
        /// <summary>
        /// Get or set display setting item
        /// </summary>
        public ObservableCollection<LogDisplay> DisplaySetting
        {
            get
            {
                return _displaySetting;
            }
            set
            {
                _displaySetting = value;
                OnPropertyChanged("DisplaySetting");
            }
        }
        protected bool _isOpenPopup;
        /// <summary>
        /// Get or set opening status of pop-up
        /// </summary>
        public bool IsOpenPopup
        {
            get
            {
                return _isOpenPopup;
            }
            set
            {
                _isOpenPopup = value;
                OnPropertyChanged("IsOpenPopup");
            }
        }
        protected BaseLogsDisplayViewModel<T> _logsDisplayVM;
        /// <summary>
        /// Get view model of log display object
        /// </summary>
        public BaseLogsDisplayViewModel<T> LogsDisplayVM
        {
            get
            {
                return _logsDisplayVM;
            }
        }

        protected BaseLogAnalyzeAreaViewModel<T> _baseAnalyzeAreaVM;
        /// <summary>
        /// Get view model of analyze area
        /// </summary>
        public BaseLogAnalyzeAreaViewModel<T> BaseAnalyzeAreaVM
        {
            get
            {
                return _baseAnalyzeAreaVM;
            }
        }
        protected string _currentLogFileName;
        /// <summary>
        /// Get or set current log file name
        /// </summary>
        public string CurrentLogFileName
        {
            get
            {
                return _currentLogFileName;
            }
            set
            {
                _currentLogFileName = value;
                OnPropertyChanged("CurrentLogFileName");
            }
        }
        /// <summary>
        /// Get item log from <see cref="ConfigValue.CCSHeader.AllLogField"/> or <see cref="ConfigValue.CXDIHeader.AllLogField"/> in case there are no default one from setting file
        /// </summary>
        /// <returns>List of log display</returns>

        abstract protected List<ValueDisplayPair<string, string>> InitLogItemList();
        protected ObservableCollection<ValueDisplayPair<string, string>> _logItemList;
        /// <summary>
        /// Get or set list of log items
        /// </summary>
        public ObservableCollection<ValueDisplayPair<string, string>> LogItemList
        {
            get
            {
                return _logItemList;
            }
            set
            {
                _logItemList = value;
                OnPropertyChanged("LogItemList");
            }
        }
        protected string _logItem;
        /// <summary>
        /// Get or set log item
        /// </summary>
        public string LogItem
        {
            get
            {
                return _logItem;
            }
            set
            {
                _logItem = value;
                OnPropertyChanged("LogItem");
                OnPropertyChanged("IsEnableButtonFilter");
            }
        }
        protected string _stringFilter;
        /// <summary>
        /// Get or set string value for filtering
        /// </summary>
        public string StringFilter
        {
            get
            {
                return _stringFilter;
            }
            set
            {
                _stringFilter = value;
                OnPropertyChanged("StringFilter");
                OnPropertyChanged("IsEnableButtonFilter");
            }
        }

        #endregion //Property
        #region Command

        protected DelegateCommand _addMoreBookmark;
        /// <summary>
        /// Command interface for adding more bookmark
        /// </summary>
        public ICommand AddMoreBookmark
        {
            get
            {
                if (_addMoreBookmark == null)
                {
                    _addMoreBookmark = new DelegateCommand(AddMoreBookmarkCL);
                }
                return _addMoreBookmark;
            }
        }
        /// <summary>
        /// Command for add bookmark
        /// </summary>
        public void AddMoreBookmarkCL()
        {
            List<BaseLogRecordDisplayViewModel<T>> logDisplays = new List<BaseLogRecordDisplayViewModel<T>>(LogsDisplayVM.SelectedItems.Cast<BaseLogRecordDisplayViewModel<T>>().OrderBy(x => x.Line));
            if (logDisplays == null || logDisplays.Count == 0) return;
            bool flag = !logDisplays.FirstOrDefault().IsBookmarked;
            foreach (var record in logDisplays)
            {
                if (flag)
                {
                    if (!record.IsBookmarked)
                    {
                        LogsDisplayVM.AddBookmark(record.Data);
                        record.IsBookmarked = true;
                    }
                }
                else
                {
                    if (record.IsBookmarked)
                    {
                        LogsDisplayVM.RemoveBookmark(record.Data);
                        record.IsBookmarked = false;
                    }
                }
            }

        }

        protected DelegateCommand _openPopupCommand;
        /// <summary>
        /// Command interface for opening popup
        /// </summary>
        public ICommand OpenPopupCommand
        {
            get
            {
                if (_openPopupCommand == null)
                {
                    _openPopupCommand = new DelegateCommand(OpenPopupCommandCL);
                }
                return _openPopupCommand;
            }
        }
        /// <summary>
        /// Command for opening popup
        /// </summary>
        protected void OpenPopupCommandCL()
        {
            IsOpenPopup = true;
        }
        protected DelegateCommand _closePopupCommand;
        /// <summary>
        /// Command interface for closing pop-up
        /// </summary>
        public ICommand ClosePopupCommand
        {
            get
            {
                if (_closePopupCommand == null)
                {
                    _closePopupCommand = new DelegateCommand(ClosePopupCommandCL);
                }
                return _closePopupCommand;
            }
        }
        /// <summary>
        /// Command for closing pop-up
        /// </summary>
        protected void ClosePopupCommandCL()
        {
            IsOpenPopup = false;
        }
        protected DelegateCommand<DataGridDragDropEventArgs> _dragDropCommand;
        /// <summary>
        /// Command interface for drag and drop
        /// </summary>
        public ICommand DragDropCommand
        {
            get
            {
                if (_dragDropCommand == null)
                {
                    _dragDropCommand = new DelegateCommand<DataGridDragDropEventArgs>((args) => DragDropFile(args), (args) => IsExecuteDrag(args));//, (args) => args != null && args.TargetObject != null && args.DroppedObject != null && args.Effects != System.Windows.DragDropEffects.None
                }
                return _dragDropCommand;
            }
        }
        /// <summary>
        /// Command for drag and drop
        /// </summary>
        /// <param name="args"></param>
        public virtual void DragDropFile(DataGridDragDropEventArgs args)
        {
            ProcessBeforeLoadLog(args.Source.ToString());
        }
        /// <summary>
        /// Get status of executing drag
        /// </summary>
        /// <param name="args"><see cref="DataGridDragDropEventArgs"/></param>
        /// <returns></returns>
        protected bool IsExecuteDrag(DataGridDragDropEventArgs args)
        {
            //return args != null && args.TargetObject != null && args.DroppedObject != null && args.Effects != System.Windows.DragDropEffects.None;
            return args != null && args.Effects != System.Windows.DragDropEffects.None;
        }
        protected DelegateCommand _loadLogFileCommand;
        /// <summary>
        /// Command interface for loading log file
        /// </summary>
        public ICommand LoadLogFileCommand
        {
            get
            {
                if (_loadLogFileCommand == null)
                {
                    _loadLogFileCommand = new DelegateCommand(LoadLogFileCL);
                }
                return _loadLogFileCommand;
            }
        }
        /// <summary>
        /// Command for loading log file
        /// </summary>
        protected virtual void LoadLogFileCL()
        {
            OpenFileDialogViewModel openFileDlg = new OpenFileDialogViewModel
            {
                Filter = OpenFileFilter
            };

            DialogResult result = openFileDlg.ShowDialog(MainViewModelObject);
            if (result == DialogResult.OK)
            {
                loadLogFileAddRecent(openFileDlg.FileName);
            }
        }
        /// <summary>
        /// Command interface for recent log file
        /// </summary>

        public void loadLogFileAddRecent(string fileName)
        {
            //OnRecentFileChange(fileName, false);
            ProcessBeforeLoadLog(fileName);
        }
        /// <summary>
        /// Re-check from file name before use to parsing file
        /// </summary>
        /// <param name="fileName">File path</param>
        public void ProcessBeforeLoadLog(string fileName)
        {
            OnRecentFileChange(fileName, false);
            if (_logAnalyser.AllLogRecordsBuffer == null || _logAnalyser.AllLogRecordsBuffer.Count == 0 || !_logAnalyser.CanMerge(fileName))
            {
                LoadDataLogFile(fileName, false);
            }
            else
            {
                MessageBoxManager.Unregister();
                MessageBoxManager.Yes = LogViewer.Properties.Resources.Merge;
                MessageBoxManager.No = LogViewer.Properties.Resources.Replace;
                //Register manager
                MessageBoxManager.Register();
                MessageBoxViewModel confirm = new MessageBoxViewModel()
                {
                    ButtonValue = System.Windows.MessageBoxButton.YesNoCancel,
                    Caption = Properties.Resources.ConfirmMergeFileCaption,
                    Text = Properties.Resources.ConfirmMergeFileMessage
                };
                var confirmResult = confirm.ShowDialog(MainViewModelObject);
                switch (confirmResult)
                {
                    case System.Windows.MessageBoxResult.Yes:
                        {
                            bool fileExisted = false;
                            string newFileName = Path.GetFileName(fileName);
                            foreach (string filePath in _logAnalyser.AllLogRecordsFilePaths)
                            {
                                if (Path.GetFileName(filePath).Equals(newFileName))
                                {
                                    fileExisted = true;
                                    break;
                                }
                            }
                            if (fileExisted)
                            {
                                MessageBoxViewModel message = new MessageBoxViewModel();
                                message.Text = Properties.Resources.MessageFileAlreadyLoad;
                                message.ShowDialog(MainViewModelObject);
                            }
                            else
                            {
                                LoadDataLogFile(fileName, true);
                            }
                            break;
                        }
                    case System.Windows.MessageBoxResult.No:
                        {
                            LoadDataLogFile(fileName, false);
                            break;
                        }
                    case System.Windows.MessageBoxResult.Cancel:
                        {
                            return;
                        }
                }

            }
        }
        /// <summary>
        /// Load data log file
        /// </summary>
        /// <param name="fileName">File path</param>
        /// <param name="isAdd">True: for specify that file will be add to buffer; False: for replace</param>
        protected void LoadDataLogFile(String fileName, bool isAdd)
        {
            BackgroundWorker worker = new BackgroundWorker();
            LoadingDialogViewModel loadDlgVM = new LoadingDialogViewModel();
            bool IsLoadingError = false;
            string errorMessage = string.Empty;

            loadDlgVM.ExecuteWhilePopUpLoading(() =>
            {
                try
                {
                    //var filePath = fileName.Split(System.IO.Path.DirectorySeparatorChar);
                    StopAllAnalyProcess();
                    _logAnalyser.LoadLogFile(fileName, isAdd);

                    //if (isAdd == true)
                    //{
                    //    CurrentLogFileName = CurrentLogFileName + "," + filePath[filePath.Length - 1];
                    //}
                    //else
                    //{
                    //    CurrentLogFileName = filePath[filePath.Length - 1];
                    //}
                    ClearWhenLoadFile();
                    _logAnalyser.Filter(null);
                    LogsDisplayVM.Initialize(_logAnalyser.BookmarkBuffer, _logAnalyser.Comments);
                    LogsDisplayVM.LoadData(_logAnalyser.AllLogRecordsBuffer, _baseSettingManger.ColorFilterSettingList);
                    BaseAnalyzeAreaVM.LogBookmarkTabVM.LoadData(_logAnalyser.BookmarkBuffer);
                    _baseSettingManger.NarrowFilterSettingItem = null;
                    LogsDisplayVM.LoadFilterSetting(_baseSettingManger.AllEnabledColorFilters);
                    IsOnNarrowColorFilter = false;
                    IsOnNarrowNonColorFilter = false;
                    OnPropertyChanged("HasLogsData");
                    OnPropertyChanged("IsEnableButtonFilter");
                    OnRecentFileChange(null, true);
                    if (OnDoneLoadDataEvent != null)
                        OnDoneLoadDataEvent();
                    ConfigValue.Is1stTimeSetDateRange =
                        ConfigValue.Is1stTimeSetFirstYRange =
                        ConfigValue.Is1stTimeSetSecondYRange = true;

                }
                catch (Exception e)
                {
                    IsLoadingError = true;
                    errorMessage = e.Message;
                }
                if (!IsLoadingError) StartAllAnalyzeProcess();

            }, MainViewModelObject, () =>
            {
                if (IsLoadingError)
                {
                    MessageBoxViewModel messageBox = new MessageBoxViewModel();
                    messageBox.Caption = Properties.Resources.FILE_LOG_LOAD_CAPTION;
                    //messageBox.Text = string.Format(Properties.Resources.FILE_LOG_LOAD_EXCEPTION, errorMessage);
                    messageBox.Text = errorMessage;
                    messageBox.ShowDialog(MainViewModelObject);
                }
                UpdateCurrentFileName(_logAnalyser.FilteredLogRecordsBuffer.FirstOrDefault());

            });
        }
        /// <summary>
        /// Validate log file extension
        /// </summary>
        /// <param name="FilePath">File path</param>
        /// <returns>True: if valid, otherwise is False</returns>
        protected abstract bool ValidLogFileExtension(string FilePath);

        protected DelegateCommand _loadMemoLogFileCommand;
        /// <summary>
        /// Command interface for loading memo log file
        /// </summary>
        public ICommand LoadMemoLogFileCommand
        {
            get
            {
                if (_loadMemoLogFileCommand == null)
                {
                    _loadMemoLogFileCommand = new DelegateCommand(LoadMemoLogFileCL);
                }
                return _loadMemoLogFileCommand;
            }
        }
        /// <summary>
        /// Command for loading memo log file
        /// </summary>
        protected virtual void LoadMemoLogFileCL()
        {
            String pathDefault = System.AppDomain.CurrentDomain.BaseDirectory + "Memo";
            OpenFileDialogViewModel openFileDlg = new OpenFileDialogViewModel
            {
                Filter = OpenMemoFilterFile,
                InitialDirectory = pathDefault
            };

            DialogResult result = openFileDlg.ShowDialog(MainViewModelObject);
            if (result == DialogResult.OK)
            {

                loadMemoAddRecent(openFileDlg.FileName);

            }
        }
        /// <summary>
        /// Command interface for loading and add log file to recent
        /// </summary>

        public void loadMemoAddRecent(string filePath)
        {
            OnRecentFileChange(filePath, false);
            _baseSettingManger.NarrowFilterSettingItem = null;
            BackgroundWorker worker = new BackgroundWorker();
            LoadingDialogViewModel loadDlgVM = new LoadingDialogViewModel();
            bool isLoadingError = false;
            string errorMessage = string.Empty;
            loadDlgVM.ExecuteWhilePopUpLoading(() =>
            {
                try
                {
                    StopAllAnalyProcess();
                    _logAnalyser.LoadMemoLogFile(filePath);
                    ClearWhenLoadFile();

                    _logAnalyser.Filter(null);

                    LogsDisplayVM.Initialize(_logAnalyser.BookmarkBuffer, _logAnalyser.Comments);
                    LogsDisplayVM.LoadData(_logAnalyser.AllLogRecordsBuffer, _baseSettingManger.ColorFilterSettingList);
                    BaseAnalyzeAreaVM.LogBookmarkTabVM.LoadData(_logAnalyser.BookmarkBuffer);
                    LogsDisplayVM.LoadFilterSetting(_baseSettingManger.AllEnabledColorFilters);
                    IsOnNarrowColorFilter = false;
                    IsOnNarrowNonColorFilter = false;
                    OnPropertyChanged("HasLogsData");
                    OnPropertyChanged("IsEnableButtonFilter");
                    OnRecentFileChange(null, true);
                }
                catch (Exception e)
                {
                    isLoadingError = true;
                    errorMessage = e.Message;
                }
                if (!isLoadingError) StartAllAnalyzeProcess();

            }, MainViewModelObject, () =>
            {
                if (isLoadingError)
                {
                    MessageBoxViewModel messageBox = new MessageBoxViewModel();
                    messageBox.Caption = Properties.Resources.MEMO_IMPORT_CAPTION;
                    messageBox.Text = string.Format(Properties.Resources.MEMO_IMPORT_TEXT_EXCEPTION, errorMessage);
                    messageBox.ShowDialog(MainViewModelObject);
                }
                UpdateCurrentFileName(_logAnalyser.FilteredLogRecordsBuffer.FirstOrDefault());

            });
        }
        protected DelegateCommand _exportMemoLogFileCommand;
        /// <summary>
        /// Command interface for exporting memo log file
        /// </summary>
        public ICommand ExportMemoLogFileCommand
        {
            get
            {
                if (_exportMemoLogFileCommand == null)
                {
                    _exportMemoLogFileCommand = new DelegateCommand(ExportMemoLogFileCL);
                }
                return _exportMemoLogFileCommand;
            }
        }
        /// <summary>
        /// Command for exporting memo log file
        /// </summary>

        protected virtual void ExportMemoLogFileCL()
        {
            MessageBoxExportViewModel messageBoxGetFileNameExport = new MessageBoxExportViewModel();

            MessageBoxViewModel messageBoxExport = new MessageBoxViewModel();
            MessageBoxViewModel messageBoxExistFile = new MessageBoxViewModel();
            if (_logAnalyser.AllLogRecordsBuffer == null || _logAnalyser.AllLogRecordsBuffer.Count == 0)
            {
                messageBoxExport.Caption = Properties.Resources.Warning;
                messageBoxExport.Text = Properties.Resources.MEMO_EXPORT_NO_RECORD;
                messageBoxExport.ShowDialog(MainViewModelObject);
                return;
            }

            try
            {
                messageBoxGetFileNameExport.OnOkEvent += new Action(() =>
                {
                    string filePath = "";
                    try
                    {
                        filePath = Path.Combine(messageBoxGetFileNameExport.Directory, messageBoxGetFileNameExport.FileName + messageBoxGetFileNameExport.Extension);
                    }
                    catch
                    {
                        messageBoxExport.Text = Properties.Resources.CAN_NOT_CREATE_FILE;
                        messageBoxExport.ShowDialog(MainViewModelObject);
                        return;
                    }
                    if (File.Exists(filePath))
                    {
                        messageBoxExistFile.Caption = Properties.Resources.MEMO_EXPORT_EXIST_FILE_CAPTION;
                        messageBoxExistFile.Text = Properties.Resources.MEMO_EXPORT_EXIST_FILE_TEXT;
                        MessageBoxManager.Unregister();
                        MessageBoxManager.Yes = LogViewer.Properties.Resources.Yes;
                        MessageBoxManager.No = LogViewer.Properties.Resources.No;

                        //Register manager
                        MessageBoxManager.Register();
                        messageBoxExistFile.ButtonValue = System.Windows.MessageBoxButton.YesNo;
                        if (messageBoxExistFile.ShowDialog(MainViewModelObject) == System.Windows.MessageBoxResult.No)
                        {
                            ExportMemoLogFileCL();
                            return;
                        }
                    }
                    LoadingDialogViewModel loadingDlg = new LoadingDialogViewModel();
                    loadingDlg.LoadingTitle = Properties.Resources.Exporting3Dot;
                    bool isSuccessExport = false;
                    loadingDlg.ExecuteWhilePopUpLoading(() =>
                        {
                            isSuccessExport = _logAnalyser.WriteMemo(filePath);
                        }, MainViewModelObject, () =>
                        {
                            System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() =>
                            {
                                MessageBoxViewModel messageBox = new MessageBoxViewModel();
                                messageBox.Caption = Properties.Resources.MEMO_EXPORT_CAPTION;
                                if (isSuccessExport)
                                {
                                    messageBox.Text = Properties.Resources.MEMO_EXPORT_TEXT_SUCCESS;
                                }
                                else
                                {
                                    messageBox.Text = Properties.Resources.CAN_NOT_CREATE_FILE;
                                }
                                messageBox.ShowDialog(MainViewModelObject);
                            }), priority: System.Windows.Threading.DispatcherPriority.ApplicationIdle);
                        });
                });
                messageBoxExport.Caption = Properties.Resources.MEMO_EXPORT_CAPTION;
                messageBoxGetFileNameExport.Caption = Properties.Resources.MEMO_EXPORT_CAPTION;

                string FilePath = GetExportFilePath();
                messageBoxGetFileNameExport.Extension = Path.GetExtension(FilePath);
                messageBoxGetFileNameExport.FileName = Path.GetFileNameWithoutExtension(FilePath);
                messageBoxGetFileNameExport.Directory = Path.GetDirectoryName(FilePath);

                messageBoxGetFileNameExport.ShowDialog(MainViewModelObject);

            }
            catch (Exception e)
            {
                messageBoxExport.Text = string.Format(Properties.Resources.MEMO_EXPORT_TEXT_EXCEPTION, e.Message);
                messageBoxExport.ShowDialog(MainViewModelObject);
            }
        }
        /// <summary>
        /// Get path for exporting file
        /// </summary>
        /// <returns>File name</returns>

        protected abstract string GetExportFilePath();

        protected DelegateCommand _editFilterSettingCommand;
        /// <summary>
        /// Command interface for editing filter item
        /// </summary>
        public ICommand EditFilterSettingCommand
        {
            get
            {
                if (_editFilterSettingCommand == null)
                {
                    _editFilterSettingCommand = new DelegateCommand(EditFilterSettingCL);
                }
                return _editFilterSettingCommand;
            }
        }
        /// <summary>
        /// Command for editing filtering
        /// </summary>

        protected virtual void EditFilterSettingCL()
        {
            IsOpenPopup = false;
            _filterVM.LoadData(_baseSettingManger.ColorFilterSettingList);
            if (!_filterVM.IsShow)
                _filterVM.Initialize();
            _filterVM.DoubleClickedCandidate = null;
            _filterVM.Show(MainViewModelObject);
        }

        protected DelegateCommand _clearColorFilterSettingCommand;
        /// <summary>
        /// Command interface for clearing color filter setting item
        /// </summary>
        public ICommand ClearColorFilterSettingCommand
        {
            get
            {
                if (_clearColorFilterSettingCommand == null)
                {
                    _clearColorFilterSettingCommand = new DelegateCommand(ClearColorFilterSettingCommandCL);
                }
                return _clearColorFilterSettingCommand;
            }
        }
        /// <summary>
        /// Command for clearing color filter setting item
        /// </summary>
        protected virtual void ClearColorFilterSettingCommandCL()
        {
            ClearColorFilterSetting();
        }
        /// <summary>
        /// Command for clearing color filter setting item
        /// </summary>

        public void ClearColorFilterSetting()
        {
            foreach (var i in _baseSettingManger.ColorFilterSettingList)
            {
                i.Enabled = false;
            }
            IsOnNarrowColorFilter = false;
            _baseSettingManger.NarrowFilterSettingItem = null;
            FilterSettingList = new ObservableCollection<FilterButtonViewModel>
            (GetFilterButtonList(_baseSettingManger.ColorFilterSettingList));
            //LogsDisplayVM.LoadFilterSetting(_baseSettingManger.AllEnabledColorFilters);
        }

        protected DelegateCommand _selectAllFilterSettingCommand;
        /// <summary>
        /// Command interface for selecting all filter setting
        /// </summary>
        public ICommand SelectAllFilterSettingCommand
        {
            get
            {
                if (_selectAllFilterSettingCommand == null)
                {
                    _selectAllFilterSettingCommand = new DelegateCommand(SelectAllFilterSettingCommandCL);
                }
                return _selectAllFilterSettingCommand;
            }
        }
        /// <summary>
        /// Command for selecting all filter setting
        /// </summary>
        protected virtual void SelectAllFilterSettingCommandCL()
        {
            foreach (var i in _baseSettingManger.ColorFilterSettingList)
            {
                i.Enabled = true;
            }
            FilterSettingList = new ObservableCollection<FilterButtonViewModel>
            (GetFilterButtonList(_baseSettingManger.ColorFilterSettingList));
            FilterItemSetting filter = ConfigValue.DefaultColorFilterItem.Copy();
            filter.PatternColor = LogsDisplayVM.PatternColor;
            List<FilterItemSetting> filters = new List<FilterItemSetting>(_baseSettingManger.AllEnabledColorFilters);
            filters.Add(filter);
            LogsDisplayVM.LoadFilterSetting(filters);
        }

        protected DelegateCommand _editPatternSettingCommand;
        /// <summary>
        /// Command interface for editing pattern setting
        /// </summary>

        public ICommand EditPatternSettingCommand
        {
            get
            {
                if (_editPatternSettingCommand == null)
                {
                    _editPatternSettingCommand = new DelegateCommand(EditPatternSettingCL);
                }
                return _editPatternSettingCommand;
            }
        }
        /// <summary>
        /// Command for editing pattern setting
        /// </summary>

        protected virtual void EditPatternSettingCL()
        {
            _patternVM.LoadData(_baseSettingManger.PatternSettingList);
            if (!_patternVM.IsShow)
                _patternVM.Initialize();
            _patternVM.Show(MainViewModelObject);
        }

        protected DelegateCommand _clearAllCommand;
        /// <summary>
        /// Command interface for clearing any result
        /// </summary>
        public ICommand ClearAllCommand
        {
            get
            {
                if (_clearAllCommand == null)
                {
                    _clearAllCommand = new DelegateCommand(ClearAllCommandCL);
                }
                return _clearAllCommand;
            }
        }
        /// <summary>
        /// Stop any process and clear any display result
        /// </summary>

        protected virtual void ClearWhenLoadFile()
        {
            StopAllAnalyProcess();
            LogsDisplayVM.ClearData();
            //LogsDisplayVM.PatternColor = new PatternColor<T>(new Dictionary<int, string>(), new List<KeyIndexRecordPair<int, string, int, T, string>>());
            LogsDisplayVM.PatternColor = null;
            BaseAnalyzeAreaVM.CountKeywordTabVM.ClearData();
            BaseAnalyzeAreaVM.LogBookmarkTabVM.ResetBookmark();
            BaseAnalyzeAreaVM.LogPatternTabVM.ClearData();
        }
        /// <summary>
        /// Command for stoping and clearing any result
        /// </summary>

        public virtual void ClearAllCommandCL()
        {
            StopAllAnalyProcess();
            _logAnalyser.ClearOldValue(false);
            CurrentLogFileName = string.Empty;
            LogsDisplayVM.ClearData();
            BaseAnalyzeAreaVM.CountKeywordTabVM.ClearData();
            BaseAnalyzeAreaVM.LogBookmarkTabVM.ResetBookmark();
            BaseAnalyzeAreaVM.LogPatternTabVM.ClearData();
            //LogsDisplayVM.PatternColor = new PatternColor<T>(new Dictionary<int, string>(), new List<KeyIndexRecordPair<int, string, int, T, string>>());
            LogsDisplayVM.PatternColor = null;
            LogsDisplayVM.ProcessTime = "";
            LogsDisplayVM.RecordForFollow = null;
            StringFilter = "";
            OnPropertyChanged("HasLogsData");
            OnPropertyChanged("IsEnableButtonFilter");
            //((MainViewModel)MainViewModelObject).SearchVM.init();
        }

        protected DelegateCommand _clearAnalyzeCommand;
        /// <summary>
        /// Command interface for clearing analyzed result
        /// </summary>
        public ICommand ClearAnalyzeCommand
        {
            get
            {
                if (_clearAnalyzeCommand == null)
                {
                    _clearAnalyzeCommand = new DelegateCommand(ClearAnalyzeCommandCL);
                }
                return _clearAnalyzeCommand;
            }
        }
        /// <summary>
        /// Command for clearing analyzed result
        /// </summary>

        public virtual void ClearAnalyzeCommandCL()
        {
            //LogsDisplayVM.ClearMemo(_logAnalyser.ClearMemo);
            StopKeywordCountWorker();
            StopAnalyzePatternWorker();
            BaseAnalyzeAreaVM.CountKeywordTabVM.ClearData();
            //BaseAnalyzeAreaVM.LogBookmarkTabVM.ResetBookmark();
            BaseAnalyzeAreaVM.LogPatternTabVM.ClearData();
            //LogsDisplayVM.PatternColor = new PatternColor<T>(new Dictionary<int, string>(), new List<KeyIndexRecordPair<int, string, int, T, string>>());
            LogsDisplayVM.PatternColor = null;
            ClearColorFilterSetting();
            LogsDisplayVM.ProcessTime = "";
            ClearNarrowFilter();
            //((MainViewModel)MainViewModelObject).SearchVM.init();
        }
        /// <summary>
        /// Clear narrow filter data
        /// </summary>
        public void ClearNarrowFilter()
        {
            StopAllAnalyProcess();
            //StringFilter = string.Empty;
            //IsOnNarrowColorFilter = false;
            IsOnNarrowNonColorFilter = false;
            //_baseSettingManger.NarrowFilterSettingItem = null;
            _logAnalyser.Filter(null);
            LogsDisplayVM.LoadData(_logAnalyser.FilteredLogRecordsBuffer, _baseSettingManger.AllEnabledColorFilters);
        }
        /// <summary>
        /// Reload data when clear color
        /// </summary>
        public void LoadDataWhenClearColor()
        {
            FilterItemSetting filter = ConfigValue.DefaultColorFilterItem.Copy();
            filter.PatternColor = LogsDisplayVM.PatternColor;
            List<FilterItemSetting> filters = new List<FilterItemSetting>(_baseSettingManger.AllEnabledColorFilters);
            filters.Add(filter);
            //LogsDisplayVM.LoadFilterSetting(filters);
            LogsDisplayVM.LoadData(_logAnalyser.FilteredLogRecordsBuffer, filters);
        }
        protected DelegateCommand _jumpToLineCommand;
        /// <summary>
        /// Command interface for jump to line action
        /// </summary>
        public ICommand JumpToLineCommand
        {
            get
            {
                if (_jumpToLineCommand == null)
                {
                    _jumpToLineCommand = new DelegateCommand(JumpToLineCommandCL);
                }
                return _jumpToLineCommand;
            }
        }
        /// <summary>
        /// Command for jump to line action
        /// </summary>

        protected virtual void JumpToLineCommandCL()
        {
            var vm = new JumpToLineViewModel(_logAnalyser.AllLogRecordsBuffer.Count);

            vm.OnJumpToLineNumberEvent += new Action<int>((line) => JumpToLine(line));
            vm.ShowDialog(MainViewModelObject);
        }
        /// <summary>
        /// Jump to specify line
        /// </summary>
        /// <param name="line">Line of log</param>
        protected void JumpToLine(int line)
        {
            var record = _logAnalyser.FilteredLogRecordsBuffer.SingleOrDefault(x => x.Line == line);
            if (record == null)
            {
                MessageBoxViewModel mb = new MessageBoxViewModel();
                mb.Caption = "Warning";
                mb.Text = "Line " + line + " is not displayed in log view.";
                mb.ShowDialog(MainViewModelObject);
                return;
            }
            _logsDisplayVM.ShowRecord(record);
        }
        /// <summary>
        /// Search text from log file
        /// </summary>
        /// <param name="searchCondition"><see cref="SearchItem"/></param>
        /// <returns>List of record matched with search condition</returns>
        public IList<T> Search(SearchItem searchCondition)
        {

            _logAnalyser.SearchKeyword(searchCondition);
            return _logAnalyser.SearchKeywordBuffer;
        }

        protected DelegateCommand _jumpToTimeCommand;
        /// <summary>
        /// Command interface for jump to line, condition for jumping is time
        /// </summary>
        public ICommand JumpToTimeCommand
        {
            get
            {
                if (_jumpToTimeCommand == null)
                {
                    _jumpToTimeCommand = new DelegateCommand(JumpToTimeCommandCL);
                }
                return _jumpToTimeCommand;
            }
        }
        /// <summary>
        /// Command for jump to line, condition for jumping is time
        /// </summary>
        protected virtual void JumpToTimeCommandCL()
        {
            var firstRecord = _logAnalyser.AllLogRecordsBuffer.FirstOrDefault();
            var lastRecord = _logAnalyser.AllLogRecordsBuffer.LastOrDefault();
            var vm = new JumpToTimeViewModel<T>(ShowRecordWithDateTime, firstRecord, lastRecord);
            vm.ShowDialog(MainViewModelObject);
        }

        protected DelegateCommand _goToTopCommand;
        /// <summary>
        /// Command interface for go to top action
        /// </summary>
        public ICommand GoToTopCommand
        {
            get
            {
                if (_goToTopCommand == null)
                {
                    _goToTopCommand = new DelegateCommand(GoToTopCommandCL);
                }
                return _goToTopCommand;
            }
        }
        /// <summary>
        /// Command for go to top action
        /// </summary>
        protected void GoToTopCommandCL()
        {
            LogsDisplayVM.ShowRecord(_logAnalyser.FilteredLogRecordsBuffer.FirstOrDefault());
        }

        protected DelegateCommand _goToBotCommand;
        /// <summary>
        /// Command interface for go to bottom action
        /// </summary>
        public ICommand GoToBotCommand
        {
            get
            {
                if (_goToBotCommand == null)
                {
                    _goToBotCommand = new DelegateCommand(GoToBotCommandCL);
                }
                return _goToBotCommand;
            }
        }
        /// <summary>
        /// Command for go to bottom action
        /// </summary>
        protected void GoToBotCommandCL()
        {
            LogsDisplayVM.ShowRecord(_logAnalyser.FilteredLogRecordsBuffer.LastOrDefault());
        }

        protected DelegateCommand _expandCommand;
        /// <summary>
        /// Command interface for expanding action
        /// </summary>
        public ICommand ExpandCommand
        {
            get
            {
                if (_expandCommand == null)
                {
                    _expandCommand = new DelegateCommand(ExpandCommandCL);
                }
                return _expandCommand;
            }
        }
        /// <summary>
        /// Command for expanding action
        /// </summary>
        public void ExpandCommandCL()
        {
            _logsDisplayVM.Expand();
        }
        /// <summary>
        /// Get enable status of filter button
        /// </summary>

        public bool IsEnableButtonFilter
        {
            get
            {
                bool result = !String.IsNullOrEmpty(LogItem)
                    && !String.IsNullOrEmpty(StringFilter) && !String.IsNullOrEmpty(StringFilter.Trim())
                    && HasLogsData;
                return result;
            }
        }
        protected DelegateCommand _shirnkCommand;
        /// <summary>
        /// Command interface for shrinking action
        /// </summary>
        public ICommand ShirnkCommand
        {
            get
            {
                if (_shirnkCommand == null)
                {
                    _shirnkCommand = new DelegateCommand(ShirnkCommandCL);
                }
                return _shirnkCommand;
            }
        }
        /// <summary>
        /// Command for shrinking action
        /// </summary>
        public void ShirnkCommandCL()
        {
            _logsDisplayVM.Shrink();
        }
        /// <summary>
        /// Show specified record
        /// </summary>
        /// <param name="record"><see cref="CCSLogRecord"/> or <see cref="CXDILogRecord"/></param>
        public void ShowRecord(T record)
        {
            LogsDisplayVM.ShowRecord(record);
        }
        protected DelegateCommand _patternAnalyserCommand;
        /// <summary>
        /// Command interface for analyzing pattern
        /// </summary>
        public ICommand PatternAnalyserCommand
        {
            get
            {
                if (_patternAnalyserCommand == null)
                {
                    _patternAnalyserCommand = new DelegateCommand(PatternAnalyserCommandCL);
                }
                return _patternAnalyserCommand;
            }
        }
        /// <summary>
        /// Command for analyzing pattern
        /// </summary>
        protected void PatternAnalyserCommandCL()
        {
            AnalyzePattern(_baseSettingManger.PatternSettingList);
        }
        protected DelegateCommand _countKeywordCommand;
        /// <summary>
        /// Command interface for keyword count setting
        /// </summary>
        public ICommand CountKeywordCommand
        {
            get
            {
                if (_countKeywordCommand == null)
                {
                    _countKeywordCommand = new DelegateCommand(CountKeywordCommandCL);
                }
                return _countKeywordCommand;
            }
        }
        /// <summary>
        /// Command for keyword count setting
        /// </summary>
        protected void CountKeywordCommandCL()
        {
            CountKeyword(_baseSettingManger.KeywordCountSettingList);
        }
        protected DelegateCommand _processTimeCommand;
        /// <summary>
        /// Command interface for processing time
        /// </summary>
        public ICommand ProcessTimeCommand
        {
            get
            {
                if (_processTimeCommand == null)
                {
                    _processTimeCommand = new DelegateCommand(ProcessTimeCommandCL);
                }
                return _processTimeCommand;
            }
        }
        /// <summary>
        /// Command for processing time
        /// </summary>
        protected void ProcessTimeCommandCL()
        {
            List<BaseLogRecordDisplayViewModel<T>> logDisplays = new List<BaseLogRecordDisplayViewModel<T>>(LogsDisplayVM.SelectedItems.Cast<BaseLogRecordDisplayViewModel<T>>().OrderBy(x => x.Line));
            ProcessTimeLog(logDisplays);
        }

        protected DelegateCommand _editKeywordCountSettingCommand;
        /// <summary>
        /// Command interface for editing keyword count
        /// </summary>
        public ICommand EditKeywordCountSettingCommand
        {
            get
            {
                if (_editKeywordCountSettingCommand == null)
                {
                    _editKeywordCountSettingCommand = new DelegateCommand(EditKeywordCountSettingCL);
                }
                return _editKeywordCountSettingCommand;
            }
        }
        /// <summary>
        /// Command for editing keyword count
        /// </summary>
        protected virtual void EditKeywordCountSettingCL()
        {
            //var vm = CreateEditKeywordCountSettingVM(ApplyKeywordCountSetting);
            //vm.LoadData(_baseSettingManger.KeywordCountSettingList);
            //vm.ShowDialog(MainViewModelObject);
            _keywordVM.LoadData(_baseSettingManger.KeywordCountSettingList);
            if (!_keywordVM.IsShow)
                _keywordVM.Initialize();
            _keywordVM.DoubleClickedCandidate = null;
            _keywordVM.Show(MainViewModelObject);

        }

        protected abstract EditKeywordCountSettingViewModel CreateEditKeywordCountSettingVM(Action<List<KeywordCountItemSetting>> onApply);

        protected DelegateCommand _narrowNonColorFilterCommand;
        /// <summary>
        /// Command interface for narrow non color filtering action
        /// </summary>
        public ICommand NarrowNonColorFilterCommand
        {
            get
            {
                if (_narrowNonColorFilterCommand == null)
                {
                    _narrowNonColorFilterCommand = new DelegateCommand(NarrowNonColorFilterCL, () =>
                        String.IsNullOrEmpty(this["StringFilter"]));
                }
                return _narrowNonColorFilterCommand;
            }
        }
        /// <summary>
        /// Command for narrow non color filtering action
        /// </summary>
        public void NarrowNonColorFilterCL()
        {
            var loadDlgVM = new LoadingDialogViewModel();
            loadDlgVM.ExecuteWhilePopUpLoading(() =>
            {
                StopAllAnalyProcess();

                if (IsOnNarrowNonColorFilter ||
                    (_narrowNonColorFilterSettingItem != null &&
                        !(LogItem == _narrowNonColorFilterSettingItem.LogItem
                            && StringFilter == _narrowNonColorFilterSettingItem.StringValue)))
                {
                    List<FilterItemSetting> listFilter = new List<FilterItemSetting>();

                    if (!StringFilter.Trim().Equals(String.Empty))
                    {
                        var filterItem = ConfigValue.NoneColorFilterItem.Copy();
                        filterItem.LogItem = LogItem;
                        filterItem.StringValue = StringFilter;
                        listFilter.Add(filterItem);
                        _baseSettingManger.NarrowFilterSettingItem = null;
                        _narrowNonColorFilterSettingItem = filterItem;
                    }
                    _logAnalyser.Filter(listFilter);
                    LogsDisplayVM.LoadData(_logAnalyser.FilteredLogRecordsBuffer, _baseSettingManger.AllEnabledColorFilters);
                    //for the second case, set IsOnNarrowColorFilter to true
                    IsOnNarrowNonColorFilter = true;
                }
                else
                {
                    _logAnalyser.Filter(null);
                    LogsDisplayVM.LoadData(_logAnalyser.FilteredLogRecordsBuffer, _baseSettingManger.ColorFilterSettingList);
                    LogsDisplayVM.ShowRecord(ClickedRecordChange.Data);
                }
                //StartAllAnalyProcess();
            }, MainViewModelObject, null);
        }

        protected FilterItemSetting _narrowNonColorFilterSettingItem;

        protected DelegateCommand _narrowColorFilterCommand;
        /// <summary>
        /// Command interface for narrow color filter action
        /// </summary>
        public ICommand NarrowColorFilterCommand
        {
            get
            {
                if (_narrowColorFilterCommand == null)
                {
                    _narrowColorFilterCommand = new DelegateCommand(NarrowColorFilterCL, () =>
                        String.IsNullOrEmpty(this["StringFilter"]));
                }
                return _narrowColorFilterCommand;
            }
        }
        /// <summary>
        /// Command for narrow color filter action
        /// </summary>
        protected void NarrowColorFilterCL()
        {
            var loadDlgVM = new LoadingDialogViewModel();
            loadDlgVM.ExecuteWhilePopUpLoading(() =>
            {
                if (_logAnalyser.FilteredLogRecordsBuffer.Count != _logAnalyser.AllLogRecordsBuffer.Count)
                    StopAllAnalyProcess();
                //Do narrow filter when:
                //1. narrow filter button is toggled on, 
                //2. ...or it is off, but the string filter or log item is different. Set the IsOnNarrowColor is on after filter
                if (IsOnNarrowColorFilter ||
                    (_baseSettingManger.NarrowFilterSettingItem != null &&
                        !(LogItem == _baseSettingManger.NarrowFilterSettingItem.LogItem
                            && StringFilter == _baseSettingManger.NarrowFilterSettingItem.StringValue)))
                {
                    List<FilterItemSetting> listFilter = new List<FilterItemSetting>();

                    if (!StringFilter.Trim().Equals(String.Empty))
                    {
                        var filterItem = ConfigValue.DefaultColorFilterItem.Copy();
                        filterItem.LogItem = LogItem;
                        filterItem.StringValue = StringFilter;
                        listFilter.Add(filterItem);
                        _baseSettingManger.NarrowFilterSettingItem = filterItem;
                    }
                    if (_logAnalyser.FilteredLogRecordsBuffer.Count != _logAnalyser.AllLogRecordsBuffer.Count)
                        _logAnalyser.Filter(null);
                    if (LogsDisplayVM.PatternColor != null)
                    {
                        FilterItemSetting filter = ConfigValue.DefaultColorFilterItem.Copy();
                        filter.PatternColor = LogsDisplayVM.PatternColor;
                        List<FilterItemSetting> filters = new List<FilterItemSetting>(_baseSettingManger.AllEnabledColorFilters);
                        filters.Add(filter);
                        LogsDisplayVM.LoadData(_logAnalyser.FilteredLogRecordsBuffer, filters);
                    }
                    else
                        LogsDisplayVM.LoadData(_logAnalyser.FilteredLogRecordsBuffer, _baseSettingManger.AllEnabledColorFilters);
                    //for the second case, set IsOnNarrowColorFilter to true
                    IsOnNarrowColorFilter = true;
                }
                else
                {
                    if (_logAnalyser.FilteredLogRecordsBuffer.Count != _logAnalyser.AllLogRecordsBuffer.Count)
                        _logAnalyser.Filter(null);
                    _baseSettingManger.NarrowFilterSettingItem = null;
                    if (LogsDisplayVM.PatternColor != null)
                    {
                        FilterItemSetting filter = ConfigValue.DefaultColorFilterItem.Copy();
                        filter.PatternColor = LogsDisplayVM.PatternColor;
                        List<FilterItemSetting> filters = new List<FilterItemSetting>(_baseSettingManger.ColorFilterSettingList);
                        filters.Add(filter);
                        LogsDisplayVM.LoadData(_logAnalyser.FilteredLogRecordsBuffer, filters);
                    }
                    else
                        LogsDisplayVM.LoadData(_logAnalyser.FilteredLogRecordsBuffer, _baseSettingManger.ColorFilterSettingList);
                }
                //StartAllAnalyProcess();
            }, MainViewModelObject, () =>
            {
            });

        }
        #endregion //Command
        #region function
        /// <summary>
        /// Process for changing record selection
        /// </summary>
        /// <param name="clickedRecordChange"><see cref="BaseLogRecordDisplayViewModel<T>"/></param>
        public void OnClickRecordChange(object clickedRecordChange)
        {
            ClickedRecordChange = (BaseLogRecordDisplayViewModel<T>)clickedRecordChange;
        }
        /// <summary>
        /// Calculate for process time of log
        /// </summary>
        /// <param name="logDisplays"></param>
        protected void ProcessTimeLog(List<BaseLogRecordDisplayViewModel<T>> logDisplays)
        {
            if (logDisplays.Count < 2)
            {
                LogsDisplayVM.ProcessTime = "0 " + Properties.Resources.ms;
            }
            else
            {
                var first = logDisplays.FirstOrDefault();
                var last = logDisplays.LastOrDefault();
                string startDateTime = first.Date.Trim() + " " + first.Time.Trim();
                string endDateTime = last.Date.Trim() + " " + last.Time.Trim();
                DateTime startDate;
                DateTime endDate;
                try
                {
                    startDate = DateTime.ParseExact(startDateTime, "yyyy/MM/dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
                    endDate = DateTime.ParseExact(endDateTime, "yyyy/MM/dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
                }
                catch
                {
                    startDate = DateTime.ParseExact(startDateTime, "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
                    endDate = DateTime.ParseExact(endDateTime, "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);

                }
                LogsDisplayVM.ProcessTime = (endDate.Subtract(startDate)).TotalMilliseconds.ToString() + " " + Properties.Resources.ms;
            }
        }
        /// <summary>
        /// Get default log Item
        /// </summary>
        /// <returns>Log item name</returns>
        protected abstract string GetDefaultLogItem();
        /// <summary>
        /// Apply for filter setting
        /// </summary>
        /// <param name="data">List of <see cref="FilterItemSetting"/></param>
        protected virtual void ApplyFilterSetting(List<FilterItemSetting> data)
        {
            _baseSettingManger.ColorFilterSettingList = data.Select(x => x.Copy()).ToList();
            FilterSettingList = new ObservableCollection<FilterButtonViewModel>
                (GetFilterButtonList(_baseSettingManger.ColorFilterSettingList));
            //LogsDisplayVM.LoadFilterSetting(_baseSettingManger.AllEnabledColorFilters);
            if (LogsDisplayVM.PatternColor != null)
            {
                FilterItemSetting filter = ConfigValue.DefaultColorFilterItem.Copy();
                filter.PatternColor = LogsDisplayVM.PatternColor;
                List<FilterItemSetting> filters = new List<FilterItemSetting>(_baseSettingManger.AllEnabledColorFilters);
                filters.Add(filter);
                LogsDisplayVM.LoadFilterSetting(filters);
            }
            else
            {
                LogsDisplayVM.LoadFilterSetting(_baseSettingManger.AllEnabledColorFilters);
            }
            LogsDisplayVM.RefreshItemsSource();

            string errorMessage = string.Empty;
            try
            {

                _baseSettingManger.WriteFilterSetting();
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
        /// Apply for keyword count setting
        /// </summary>
        /// <param name="data">List of <see cref="KeywordCountItemSetting"/></param>
        protected virtual void ApplyKeywordCountSetting(List<KeywordCountItemSetting> data)
        {
            _baseSettingManger.KeywordCountSettingList = data;
            CountKeyword(_baseSettingManger.KeywordCountSettingList);

            string errorMessage = string.Empty;
            try
            {
                _baseSettingManger.WriteKeywordCountSettingFile();
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
        /// Apply for pattern setting
        /// </summary>
        /// <param name="data">List of <see cref="PatternItemSetting"/></param>
        protected virtual void ApplyPatternSetting(List<PatternItemSetting> data)
        {
            BaseAnalyzeAreaVM.LogPatternTabVM.ClearData();
            _baseSettingManger.PatternSettingList = data;

            string errorMessage = string.Empty;
            try
            {
                _baseSettingManger.WritePattermSetting();
                //Debug.WriteLine("Call ApplyPatternSetting at time" + DateTime.Now.ToString());
                AnalyzePattern(_baseSettingManger.PatternSettingList);
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
        /// Mark a record as bookmark
        /// </summary>
        /// <param name="record">Generic log record, can be: <see cref="CCSLogRecord"/> or <see cref="CXDILogRecord"/></param>
        public virtual void AddBookmark(T record)
        {
            BaseAnalyzeAreaVM.AddBookmark(record);
            _logAnalyser.AddBookmark(record);
        }
        /// <summary>
        /// Remove record from bookmark list
        /// </summary>
        /// <param name="record">Generic log record, can be: <see cref="CCSLogRecord"/> or <see cref="CXDILogRecord"/></param>
        public virtual void RemoveBookmark(T record)
        {
            BaseAnalyzeAreaVM.RemoveBookmark(record);
            _logAnalyser.RemoveBookmark(record);
        }
        /// <summary>
        /// method for converting a System.DateTime value to a UNIX time stamp
        /// </summary>
        /// <param name="value">date to convert/// <returns></returns>
        protected static double ConvertToTimestamp(DateTime value)
        {
            //create Timespan by subtracting the value provided from
            //the Unix Epoch
            TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());

            //return the total seconds (which is a UNIX time stamp)
            return (double)span.TotalSeconds;
        }
        /// <summary>
        /// Show record  by given date and time
        /// </summary>
        /// <param name="date">Given date</param>
        /// <param name="time">Given time</param>
        protected virtual void ShowRecordWithDateTime(string date, string time)
        {
            if (time.Split('.')[1].Trim().Equals(String.Empty))
            {
                time = time.Trim() + "000";
            }
            DateTime dateTime = GetDateTime(date, time);
            //T record = _logAnalyser.FilteredLogRecordsBuffer.FirstOrDefault(x => (x.Date == date && x.Time.StartsWith(time)));
            T record1 = _logAnalyser.FilteredLogRecordsBuffer.LastOrDefault(x => GetDateTime(x.Date, x.Time).CompareTo(dateTime) <= 0);
            T record2 = _logAnalyser.FilteredLogRecordsBuffer.FirstOrDefault(x => GetDateTime(x.Date, x.Time).CompareTo(dateTime) > 0);

            T record = null;
            if (record1 != null && record2 != null)
            {
                DateTime dateTime1 = GetDateTime(record1.Date, record1.Time);
                DateTime dateTime2 = GetDateTime(record2.Date, record2.Time);
                double timestamp = ConvertToTimestamp(dateTime);
                double timestamp1 = ConvertToTimestamp(dateTime1);
                double timestamp2 = ConvertToTimestamp(dateTime2);
                if (timestamp - timestamp1 <= timestamp2 - timestamp)
                {
                    record = record1;
                }
                else
                {
                    record = record2;
                }
            }
            else
            {
                if (record1 != null)
                {
                    record = record1;
                }
                if (record2 != null)
                {
                    record = record2;
                }
            }
            if (record != null)
            {
                LogsDisplayVM.ShowRecord(record);
            }
            else
            {
                MessageBox.Show(Properties.Resources.DateTime + date + " " + time + Properties.Resources.NotDisplayLogViewWithDateTimeMessage);
            }
        }
        /// <summary>
        /// Process follow mode by given date and time
        /// </summary>
        /// <param name="date">Given date</param>
        /// <param name="time">Given time</param>
        public virtual void FollowRecordWithDateTime(string date, string time)
        {

            DateTime dateTime = GetDateTime(date, time);
            T record1 = _logAnalyser.FilteredLogRecordsBuffer.LastOrDefault(x => GetDateTime(x.Date, x.Time).CompareTo(dateTime) <= 0);
            T record2 = _logAnalyser.FilteredLogRecordsBuffer.FirstOrDefault(x => GetDateTime(x.Date, x.Time).CompareTo(dateTime) > 0);

            T record = null;
            if (record1 != null && record2 != null)
            {
                DateTime dateTime1 = GetDateTime(record1.Date, record1.Time);
                DateTime dateTime2 = GetDateTime(record2.Date, record2.Time);
                double timestamp = ConvertToTimestamp(dateTime);
                double timestamp1 = ConvertToTimestamp(dateTime1);
                double timestamp2 = ConvertToTimestamp(dateTime2);
                if (timestamp - timestamp1 <= timestamp2 - timestamp)
                {
                    record = record1;
                }
                else
                {
                    record = record2;
                }
            }
            else
            {
                if (record1 != null)
                {
                    record = record1;
                }
                if (record2 != null)
                {
                    record = record2;
                }
            }
            if (record != null)
            {
                LogsDisplayVM.FollowRecord(record);
            }

            //T record = _logAnalyser.FilteredLogRecordsBuffer.FirstOrDefault(x => (x.Date == date && x.Time.StartsWith(time.Substring(0,time.LastIndexOf(".")))));
            //if (record != null)
            //{
            //    LogsDisplayVM.FollowRecord(record);
            //}
        }
        /// <summary>
        /// Combine date and time to date time
        /// </summary>
        /// <param name="date">Given date</param>
        /// <param name="time">Given time</param>
        /// <returns></returns>
        protected DateTime GetDateTime(string date, string time)
        {
            return Convert.ToDateTime(date + " " + time);
        }
        /// <summary>
        /// Create view model object for filter setting
        /// </summary>
        /// <param name="onApply">Process for on apply action</param>
        /// <returns><see cref="EditFilterSettingViewModel"/></returns>
        protected abstract EditFilterSettingViewModel CreateEditFilterSettingVM(Action<List<FilterItemSetting>> onApply);
        /// <summary>
        /// Get of set main view model object
        /// </summary>
        protected object MainViewModelObject { get; set; }
        /// <summary>
        /// Load config from setting file
        /// </summary>
        /// <returns>Empty string if have no error, otherwise will return error message</returns>
        public virtual string LoadConfig()
        {
            String errorMessage = string.Empty;
            try
            {
                _baseSettingManger.ReadDisplaySetting();
            }
            catch (Exception e)
            {
                errorMessage += e.Message;
            }
            try
            {
                _baseSettingManger.ReadFilterSetting();
            }
            catch (Exception e)
            {
                errorMessage += Environment.NewLine + e.Message;
            }
            try
            {
                _baseSettingManger.ReadKeywordCountSettingFile();
            }
            catch (Exception e)
            {
                errorMessage += Environment.NewLine + e.Message;
            }
            try
            {
                _baseSettingManger.ReadPattermSetting();
            }
            catch (Exception e)
            {
                errorMessage += Environment.NewLine + e.Message;
            }

            try
            {
                FilterSettingList = new ObservableCollection<FilterButtonViewModel>
                    (GetFilterButtonList(_baseSettingManger.ColorFilterSettingList));
            }
            catch (Exception e)
            {
                errorMessage += Environment.NewLine + e.Message;
            }
            return errorMessage;
        }
        BackgroundWorker keywordCountWorker = new BackgroundWorker();
        /// <summary>
        /// Do keyword count 
        /// </summary>
        /// <param name="settings">List of keyword count setting</param>
        protected virtual void CountKeyword(IList<KeywordCountItemSetting> settings)
        {
            _baseAnalyzeAreaVM.CountKeywordTabVM.ClearData();
            keywordCountWorker.WorkerReportsProgress = true;
            keywordCountWorker.WorkerSupportsCancellation = true;
            keywordCountWorker.DoWork -= DoCountKeyWordAction;
            DoCountKeyWordAction = ((sender, arg) =>
            {
                //Show the progress bar
                _baseAnalyzeAreaVM.CountKeywordTabVM.IsLoadingData = true;
                _baseAnalyzeAreaVM.CountKeywordTabVM.IsShowTabKeyword = true;
                _logAnalyser.KeywordCountWorker = keywordCountWorker;
                _logAnalyser.CountKeyword(settings);
            });

            keywordCountWorker.DoWork += DoCountKeyWordAction;

            RunCompleteCountKeywordAction = ((sender, arg) =>
            {
                _baseAnalyzeAreaVM.CountKeywordTabVM.IsLoadingData = false;
                _baseAnalyzeAreaVM.CountKeywordTabVM.LoadData(_logAnalyser.CountKeywordBuffer);
            }
            );
            keywordCountWorker.RunWorkerCompleted -= RunCompleteCountKeywordAction;
            keywordCountWorker.RunWorkerCompleted += RunCompleteCountKeywordAction;
            if (!keywordCountWorker.IsBusy)
                keywordCountWorker.RunWorkerAsync();
            else
            {
                StopKeywordCountWorker();
                keywordCountWorker.RunWorkerAsync();
            }


        }
        DoWorkEventHandler DoCountKeyWordAction;
        RunWorkerCompletedEventHandler RunCompleteCountKeywordAction;
        /// <summary>
        /// Stop keyword count thread
        /// </summary>
        public void StopKeywordCountWorker()
        {
            if (keywordCountWorker.WorkerSupportsCancellation)
            {
                keywordCountWorker.CancelAsync();
            }
            while (keywordCountWorker.IsBusy)
            {
                Application.DoEvents();
            }
        }
        /// <summary>
        /// Stop anaylyze pattern thread
        /// </summary>
        public void StopAnalyzePatternWorker()
        {
            if (analyzePatternWorker.WorkerSupportsCancellation)
            {
                analyzePatternWorker.CancelAsync();
            }
            while (analyzePatternWorker.IsBusy)
            {
                Application.DoEvents();
            }
        }
        /// <summary>
        /// Stop all analyze background process
        /// </summary>
        protected virtual void StopAllAnalyProcess()
        {
            StopKeywordCountWorker();
            StopAnalyzePatternWorker();
        }
        /// <summary>
        /// Start all analyze background process
        /// </summary>
        protected virtual void StartAllAnalyzeProcess()
        {
            CountKeyword(_baseSettingManger.KeywordCountSettingList.FindAll(x => x.Enabled == true));
        }

        DoWorkEventHandler DoAnalyzeAction;
        RunWorkerCompletedEventHandler RunCompleteAnalyzeAction;

        BackgroundWorker analyzePatternWorker = new BackgroundWorker();
        /// <summary>
        /// Do analyze for pattern
        /// </summary>
        /// <param name="settings">is a list of pattern setting</param>
        protected virtual void AnalyzePattern(IList<PatternItemSetting> settings)
        {
            BaseAnalyzeAreaVM.LogPatternTabVM.ClearData();
            analyzePatternWorker.WorkerReportsProgress = true;
            analyzePatternWorker.WorkerSupportsCancellation = true;
            analyzePatternWorker.DoWork -= DoAnalyzeAction;

            DoAnalyzeAction = ((sender, arg) =>
            {
                //Show the progress bar
                _baseAnalyzeAreaVM.LogPatternTabVM.IsLoadingData = true;
                //Show progress bar on tab pattern
                _baseAnalyzeAreaVM.LogPatternTabVM.IsShowTabPattern = true;
                _logAnalyser.AnalyzePatternWorker = analyzePatternWorker;
                _logAnalyser.AnalyzePattern(settings);
                //LogsDisplayVM.PatternColor = new PatternColor<T>(new Dictionary<int, string>(), new List<KeyIndexRecordPair<int, string, int, T, string>>());
                LogsDisplayVM.PatternColor = null;
                LogsDisplayVM.RefreshData = !LogsDisplayVM.RefreshData;
            });

            analyzePatternWorker.DoWork += DoAnalyzeAction;
            RunCompleteAnalyzeAction = ((sender, arg) =>
            {
                //Hide progress bar
                _baseAnalyzeAreaVM.LogPatternTabVM.IsLoadingData = false;
                List<AnalyzedPatternResultItem<T>> analyzeResult = new List<AnalyzedPatternResultItem<T>>(_logAnalyser.PatternAnalyzeBuffer);
                _baseAnalyzeAreaVM.LogPatternTabVM.LoadData(analyzeResult.FindAll(x => x.Count != 0));
                //LogsDisplayVM.PatternColor = new PatternColor<T>(new Dictionary<int, string>(), new List<KeyIndexRecordPair<int, string, int, T, string>>());
                LogsDisplayVM.PatternColor = null;
                //LogsDisplayVM.RefreshData = false;
            }
            );
            analyzePatternWorker.RunWorkerCompleted -= RunCompleteAnalyzeAction;
            analyzePatternWorker.RunWorkerCompleted += RunCompleteAnalyzeAction;

            if (!analyzePatternWorker.IsBusy)
                analyzePatternWorker.RunWorkerAsync();
            else
            {
                StopAnalyzePatternWorker();
                analyzePatternWorker.RunWorkerAsync();
            }

        }
        /// <summary>
        /// Get list of filter setting item 
        /// </summary>
        /// <param name="data">List of <see cref="FilterItemSetting"/></param>
        /// <returns>List of <see cref="FilterButtonViewModel"/></returns>
        public virtual IList<FilterButtonViewModel> GetFilterButtonList(IList<FilterItemSetting> data)
        {
            List<FilterButtonViewModel> temp = new List<FilterButtonViewModel>();
            foreach (var i in data)
            {
                temp.Add(new FilterButtonViewModel(i, DelegateFilterButtonViewModel
                    //() =>
                    //{
                    //    if (LogsDisplayVM.PatternColor != null)
                    //    {
                    //        FilterItemSetting filter = ConfigValue.DefaultColorFilterItem.Copy();
                    //        filter.PatternColor = LogsDisplayVM.PatternColor;
                    //        List<FilterItemSetting> filters = new List<FilterItemSetting>(_baseSettingManger.AllEnabledColorFilters);
                    //        filters.Add(filter);
                    //        LogsDisplayVM.LoadFilterSetting(filters);
                    //    }
                    //    else
                    //    {
                    //        LogsDisplayVM.LoadFilterSetting(_baseSettingManger.AllEnabledColorFilters);
                    //    }
                    //}
                        ));
            }
            return temp;
        }
        /// <summary>
        /// Delegate function list filter setting item
        /// </summary>
        public void DelegateFilterButtonViewModel()
        {
            if (LogsDisplayVM.PatternColor != null)
            {
                FilterItemSetting filter = ConfigValue.DefaultColorFilterItem.Copy();
                filter.PatternColor = LogsDisplayVM.PatternColor;
                List<FilterItemSetting> filters = new List<FilterItemSetting>(_baseSettingManger.AllEnabledColorFilters);
                filters.Add(filter);
                LogsDisplayVM.LoadFilterSetting(filters);
            }
            else
            {
                LogsDisplayVM.LoadFilterSetting(_baseSettingManger.AllEnabledColorFilters);
            }
        }
        /// <summary>
        /// Refresh to current log file name
        /// </summary>
        /// <param name="record"></param>
        protected void UpdateCurrentFileName(T record)
        {
            CurrentLogFileName = _logAnalyser.GetRecordFileName(record);
        }
        /// <summary>
        /// Get sub string status of a string key with message column of <see cref="CXDILogRecord"/>
        /// </summary>
        /// <param name="record">Generic log record, can be: <see cref="CCSLogRecord"/> or <see cref="CXDILogRecord"/></param>
        /// <param name="key">A substring to be search</param>
        /// <returns>True: if the message column of log record contain given key, otherwise is false</returns>
        protected abstract bool contains(T record, string key);
        /// <summary>
        /// Show pattern record with coloring
        /// </summary>
        /// <param name="record">Generic log record, can be: <see cref="CCSLogRecord"/> or <see cref="CXDILogRecord"/></param>
        /// <param name="currentPatternItem"><see cref="AnalyzedPatternResultItem<T>"/></param>
        public virtual void ShowPatternColoringRecord(T record, AnalyzedPatternResultItem<T> currentPatternItem)
        {
            var loadDlgVM = new LoadingDialogViewModel();
            loadDlgVM.ExecuteWhilePopUpLoading(() =>
            {
                Dictionary<int, KeyIndexRecordPair<int, string, int, T, string>> rootKey = new Dictionary<int, KeyIndexRecordPair<int, string, int, T, string>>();
                //string root = currentPatternItem.PatternItem.RootKey;
                KeyIndexRecordPair<int, string, int, T, string> root = currentPatternItem.RootKey[record];
                rootKey.Add(record.Line, root);

                List<KeyIndexRecordPair<int, string, int, T, string>> listKey = new List<KeyIndexRecordPair<int, string, int, T, string>>(currentPatternItem.FoundPattern[record]);

                PatternColor<T> patternColor = new PatternColor<T>(rootKey, listKey);
                LogsDisplayVM.PatternColor = patternColor;
            }, MainViewModelObject, () =>
            {

            });
        }
        /// <summary>
        /// Determined with side of log record list follow other
        /// </summary>
        public virtual void OnOtherLogsLoadedHandler()
        {
            LogsDisplayVM.OnOtherLogsLoadedHandler();
        }

        #endregion // function
        #region IDataErrorInfo
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        /// <summary>
        /// Reference to properties as index of array. Use for checking a properties is valid or not.
        /// </summary>
        /// <param name="propertyName">Properties name</param>
        /// <returns>Empty string when a properties is valid data.</returns>
        public string this[string propertyName]
        {
            get
            {
                string errorMessage = String.Empty;
                switch (propertyName)
                {
                    case "LogItem":
                        {
                            if (LogItem == null)
                            {
                                errorMessage = Properties.Resources.LogItemNotEmptyErrorMessage;
                            }
                            break;
                        }
                    case "StringFilter":
                        {
                            errorMessage = ValidateStringFilter();
                            break;
                        }
                }
                return errorMessage;
            }
        }
        /// <summary>
        /// Validate for value of filter string
        /// </summary>
        /// <returns>Empty string if had no error, otherwise will return error message</returns>
        protected string ValidateStringFilter()
        {
            if (!String.IsNullOrEmpty(StringFilter))
            {
                var allKeywords = GetKeywords();
                //hard code.
                if (allKeywords.Count > 5)
                    return Properties.Resources.ValidateMaxKeywordCountMessage;
                //hard code.
                else if (allKeywords.Where(x => x.Count() > ConfigValue.MaxStringLength).Count() > 0)
                    return Properties.Resources.ValidateLengthKeywordMessage;
            }
            return String.Empty;
        }
        /// <summary>
        /// Extract search keyword from input
        /// </summary>
        /// <returns>List of keyword</returns>
        protected List<string> GetKeywords()
        {
            List<string> result = new List<string>();
            var orList = Regex.Split(StringFilter, Regex.Escape(ConfigValue.SEARCH_KEY_OR));
            if (orList != null && orList.Count() != 0)
            {
                foreach (var i in orList)
                {
                    foreach (var j in i.Split(' '))
                    {
                        if (!String.IsNullOrEmpty(j))
                            result.Add(j);
                    }
                }
            }
            return result;

        }
        #endregion
    }
}
