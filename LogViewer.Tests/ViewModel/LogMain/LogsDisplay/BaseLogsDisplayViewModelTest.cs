using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Model;
using System.Collections.Generic;
using LogViewer.Business;
using System.Collections.ObjectModel;
using System.Windows.Input;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.IO;
using System.Linq;
namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for BaseLogsDisplayViewModelTest and is intended
    ///to contain all BaseLogsDisplayViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BaseLogsDisplayViewModelTest
    {

        public CCSLogsDisplayViewModel_Accessor target;
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        [DeploymentItem(@"FileConfig\DefaultCCSLogSetting.csv")]
        public void SetUp()
        {
            if (!ServiceLocator.services.ContainsKey(typeof(IDialogService)))
            {
                ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
                ServiceLocator.RegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
                ServiceLocator.Register<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
                ServiceLocator.Register<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
            }
            Action<CCSLogRecord> onAddBookmarkEvent = (CCSLog) => { };
            Action<CCSLogRecord> onRemoveBookmarkEvent = (CCSLog) => { };
            Action<CCSLogRecord> onUpdateRecordFileName = (CCSLog) => { };
            Action<string, string> onFollowOtherLogEvent = (str1, str2) => { };
            Action<CCSLogRecord, AnalyzedPatternResultItem<CCSLogRecord>> onShowPatternColoringRecord = (CCSLog, AnalyzePattern) => { };
            string oldDefaultCCSLogSetting = ConfigValue.DefaultCCSLogSettingFile;
            string DefaultCCSLogSetting = @"DefaultCCSLogSetting.csv";
            ConfigValue.DefaultCCSLogSettingFile = Path.GetFullPath(DefaultCCSLogSetting);
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            ConfigValue.DefaultCCSLogSettingFile = oldDefaultCCSLogSetting;


            List<LogDisplay> logDisplay = new List<LogDisplay>(targetMainVM.CCSMainVM.SettingManager.DisplaySetting);
            CCSSettingManager SettingManger = new CCSSettingManager();
            CCSLogsDisplayViewModel ccsMV = new CCSLogsDisplayViewModel(onAddBookmarkEvent, onRemoveBookmarkEvent, onUpdateRecordFileName, onFollowOtherLogEvent, onShowPatternColoringRecord, logDisplay, SettingManger, null);
            PrivateObject param = new PrivateObject(ccsMV);
            target = new CCSLogsDisplayViewModel_Accessor(param);
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            ServiceLocator.UnRegisterSingleton<IDialogService, DialogService>();
            ServiceLocator.UnRegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
            ServiceLocator.UnRegister<IOpenFileDialog, LogViewer.Service.FrameworkDialogs.OpenFile.OpenFileDialogViewModel>();
            ServiceLocator.UnRegister<ISaveFileDialog, LogViewer.Service.FrameworkDialogs.SaveFile.SaveFileDialogViewModel>();
        }
        //
        #endregion


        /// <summary>
        ///A test for AddBookmark
        ///</summary>
        [TestMethod()]
        public void AddBookmarkTest()
        {
            CCSLogRecord data = default(CCSLogRecord); 
            target.AddBookmark(data);
        }

        /// <summary>
        ///A test for ClearData
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(TypeLoadException))]
        public void ClearDataTest()
        {
            target.ClearData();
            Assert.AreEqual(0, target.BaseRecordVMList.Count);
            Assert.AreEqual(0, target._locatorDict.Count);
        }

        /// <summary>
        ///A test for Expand
        ///</summary>
        [TestMethod()]
        public void ExpandTest()
        {
            target.Expand();
            Assert.AreEqual(ConfigValue.DefaultFontSize + 1, target.FontOfDataGrid);
        }

        /// <summary>
        ///A test for FollowRecord
        ///</summary>
        [TestMethod()]
        public void FollowRecordTest()
        {
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            CCSLogRecord record = new CCSLogRecord();
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
            target.Invoke("FollowRecord", new object[] { record });
            Assert.IsNull(target.GetProperty("RecordForFollow"));
        }

        
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void FollowRecord_LogNotEmptyTest()
        {
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            string date = "2013-10-12";
            string time = "13:36:38.308";
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
            targetMainVM.CCSMainVM.FollowRecordWithDateTime(date, time);
            //CCSLogsDisplayViewModel_Accessor target = new CCSLogsDisplayViewModel_Accessor(new PrivateObject(((MainViewModel)(targetMainVM.Target)).CCSMainVM.LogsDisplayVM));
            PrivateObject target = new PrivateObject(((MainViewModel)(targetMainVM.Target)).CCSMainVM.LogsDisplayVM);
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime = DateTime.Parse(string.Format("{0} {1}", date, time));
            target.Invoke("FollowRecord", new object[]{record});
            Assert.IsNotNull(target.GetFieldOrProperty("RecordForFollow"));
        }

        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void FollowRecord_FollowRecordNotEmptyTest()
        {
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            string date = "2013-10-12";
            string time = "13:36:38.308";
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
            targetMainVM.CCSMainVM.FollowRecordWithDateTime(date, time);
            targetMainVM.CCSMainVM.FollowRecordWithDateTime(date, time);
            //CCSLogsDisplayViewModel_Accessor target = new CCSLogsDisplayViewModel_Accessor(new PrivateObject(((MainViewModel)(targetMainVM.Target)).CCSMainVM.LogsDisplayVM));
            PrivateObject target = new PrivateObject(((MainViewModel)(targetMainVM.Target)).CCSMainVM.LogsDisplayVM);
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime = DateTime.Parse(date +" "+time);
            target.Invoke("FollowRecord", new object[] { record });
            Assert.IsNotNull(target.GetFieldOrProperty("RecordForFollow"));
        }
        /// <summary>
        ///A test for Initialize
        ///</summary>
        [TestMethod()]
        public void InitializeTest()
        {
            IList<CCSLogRecord> bookmarkList = null; 
            Dictionary<CCSLogRecord, string> comments = null; 
            target.Initialize(bookmarkList, comments);
            Assert.IsNull(target.BookmarkList);
            Assert.IsNull(target.CommentsDict);
        }

        /// <summary>
        ///A test for IsEnableCopy
        ///</summary
        [TestMethod()]
        public void IsEnableCopySelectionItemNullTest1()
        {
            bool expected = false;
            bool actual;
            actual = target.IsEnableCopy();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void IsEnableCopySelectionItemNullTest2()
        {
            bool expected = false;
            bool actual;
            target.SelectedItems = new List<object>();
            actual = target.IsEnableCopy();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void IsEnableCopySelectionItemNotNullTest()
        {
            bool expected = true;
            bool actual;
            List<object> list = new List<object>();
            object obj = new object();
            list.Add(obj);
            target.SelectedItems = list;
            actual = target.IsEnableCopy();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LoadData
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void LoadDataTest()
        {
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            List<CCSLogRecord> data = new List<CCSLogRecord>(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer); 
            List<FilterItemSetting> filters = new List<FilterItemSetting>(); 
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
            target.Invoke("LoadData", new object[]{data, filters});
            Dictionary<CCSLogRecord, BaseLogRecordDisplayViewModel<CCSLogRecord>> _locatorDict = (Dictionary<CCSLogRecord, BaseLogRecordDisplayViewModel<CCSLogRecord>>)target.GetFieldOrProperty("_locatorDict");
            Assert.IsTrue(_locatorDict.Count > 0);
        }

        /// <summary>
        ///A test for LoadFilterSetting
        ///</summary>
        [TestMethod()]
        public void LoadFilterSettingTest()
        {
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            List<FilterItemSetting> filters = new List<FilterItemSetting>();
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
            target.Invoke("LoadFilterSetting", new object[]{filters});
            List<FilterItemSetting> actual = (List<FilterItemSetting>)target.GetFieldOrProperty("FilterSetting");
            Assert.AreEqual(0, actual.Count);
        }

        /// <summary>
        ///A test for OnOtherLogsLoadedHandler
        ///</summary>
        [TestMethod()]
        public void OnOtherLogsLoadedHandlerTest()
        {
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            List<FilterItemSetting> filters = new List<FilterItemSetting>();
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime =DateTime.Parse("2013-10-10 12:12:12.000");
            CCSLogRecordDisplayViewModel RecordForFollow = new CCSLogRecordDisplayViewModel(record, null);
            target.SetFieldOrProperty("IsOnFollowMode", true);
            target.SetFieldOrProperty("RecordForFollow", RecordForFollow);
            target.Invoke("OnOtherLogsLoadedHandler");    
        }

        /// <summary>
        ///A test for RefreshItemsSource
        ///</summary>
        [TestMethod()]
        public void RefreshItemsSourceTest()
        {
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
            target.Invoke("RefreshItemsSource");   
        }

        /// <summary>
        ///A test for RemoveBookmark
        ///</summary>
        [TestMethod()]
        public void RemoveBookmarkTest()
        {
            CCSLogRecord data = default(CCSLogRecord); 
            target.RemoveBookmark(data);
        }

        ///// <summary>
        /////A test for ShowPatternColoringRecord
        /////</summary>
        //[TestMethod()]
        //public void ShowPatternColoringRecordTest()
        //{
        //    CCSLogRecord record = default(CCSLogRecord); 
        //    AnalyzedPatternResultItem<CCSLogRecord> CurrentPatternItem = null;
        //    MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
        //    targetMainVM.Init();
        //    PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
        //    target.Invoke("ShowPatternColoringRecord", new object[]{record, CurrentPatternItem});
        //    Assert.IsNull(target.GetFieldOrProperty("RecordForJump"));
        //}

        //[TestMethod()]
        //[DeploymentItem(@"FileConfig\CCS20131002.txt")]
        //public void ShowPatternColoringRecordRecordForJumpIsNullTest()
        //{
        //    CCSLogRecord record = default(CCSLogRecord);
        //    AnalyzedPatternResultItem<CCSLogRecord> CurrentPatternItem = null;
        //    MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
        //    targetMainVM.Init();
        //    string filerLog = @"CCS20131002.txt";
        //    string dir = Path.GetFullPath(filerLog);
        //    targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
        //    targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
        //    targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
        //    PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
        //    target.Invoke("ShowPatternColoringRecord", new object[] { null, CurrentPatternItem });
        //    Assert.IsNotNull(target.GetFieldOrProperty("RecordForJump"));
        //}
        //[TestMethod()]
        //[DeploymentItem(@"FileConfig\CCS20131002.txt")]
        //public void ShowPatternColoringRecordRecordForJumpIsNullRecordNotNullTest()
        //{
        //    CCSLogRecord record = new CCSLogRecord();
        //    AnalyzedPatternResultItem<CCSLogRecord> CurrentPatternItem = null;
        //    MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
        //    targetMainVM.Init();
        //    string filerLog = @"CCS20131002.txt";
        //    string dir = Path.GetFullPath(filerLog);
        //    targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
        //    targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
        //    targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
        //    PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
        //    target.Invoke("ShowPatternColoringRecord", new object[] { record, CurrentPatternItem });
        //    Assert.IsNotNull(target.GetFieldOrProperty("RecordForJump"));
        //}
        //[TestMethod()]
        //[DeploymentItem(@"FileConfig\CCS20131002.txt")]
        //public void ShowPatternColoringRecordRecordForJumpIsNullTest1()
        //{
        //    AnalyzedPatternResultItem<CCSLogRecord> CurrentPatternItem = null;
        //    MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
        //    targetMainVM.Init();
        //    string filerLog = @"CCS20131002.txt";
        //    string dir = Path.GetFullPath(filerLog);
        //    targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
        //    targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
        //    CCSLogRecord record = targetMainVM.CCSMainVM.LogAnalyser.AllLogRecordsBuffer.FirstOrDefault();
        //    targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
        //    PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
        //    target.Invoke("ShowPatternColoringRecord", new object[] { record, CurrentPatternItem });
        //    Assert.IsNotNull(target.GetFieldOrProperty("RecordForJump"));
        //}
        ///// <summary>
        /////A test for ShowRecord
        /////</summary>
        //[TestMethod()]
        //[DeploymentItem(@"FileConfig\CCS20131002.txt")]
        //public void ShowRecordTest()
        //{
        //    MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
        //    targetMainVM.Init();
        //    string filerLog = @"CCS20131002.txt";
        //    string dir = Path.GetFullPath(filerLog);
        //    targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
        //    targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
        //    CCSLogRecord record = targetMainVM.CCSMainVM.LogAnalyser.AllLogRecordsBuffer.FirstOrDefault();
        //    targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
        //    PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
        //    target.Invoke("ShowRecord", new object[] { record });
        //    Assert.IsNotNull(target.GetFieldOrProperty("RecordForJump"));
        //}

        //[TestMethod()]
        //[DeploymentItem(@"FileConfig\CCS20131002.txt")]
        //public void ShowRecord_locatorDictIsNullTest()
        //{
        //    MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
        //    targetMainVM.Init();
        //    string filerLog = @"CCS20131002.txt";
        //    string dir = Path.GetFullPath(filerLog);
        //    targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
        //    targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
        //    CCSLogRecord record = targetMainVM.CCSMainVM.LogAnalyser.AllLogRecordsBuffer.FirstOrDefault();
        //    targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
        //    PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
        //    target.Invoke("ShowRecord", new object[] { record });
        //    Assert.IsNull(target.GetFieldOrProperty("RecordForJump"));
        //}
        //[TestMethod()]
        //[DeploymentItem(@"FileConfig\CCS20131002.txt")]
        //public void ShowRecordIsOnFollowModeTest()
        //{
        //    MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
        //    targetMainVM.Init();
        //    string filerLog = @"CCS20131002.txt";
        //    string dir = Path.GetFullPath(filerLog);
        //    targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
        //    targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
        //    CCSLogRecord record = targetMainVM.CCSMainVM.LogAnalyser.AllLogRecordsBuffer.FirstOrDefault();
        //    targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
        //    PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
        //    target.SetProperty("IsOnFollowMode", true);
        //    target.Invoke("ShowRecord", new object[] { record });
        //    Assert.IsNotNull(target.GetProperty("RecordForJump"));
        //}
        /// <summary>
        ///A test for Shrink
        ///</summary>
        [TestMethod()]
        public void ShrinkTest()
        {
            target.Shrink();
            Assert.AreEqual(ConfigValue.DefaultFontSize - 1, target.FontOfDataGrid);
        }

        /// <summary>
        ///A test for BaseRecordVMList
        ///</summary>
        [TestMethod()]
        public void BaseRecordVMListTest()
        {
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
            ObservableCollection<BaseLogRecordDisplayViewModel<CCSLogRecord>> old = (ObservableCollection<BaseLogRecordDisplayViewModel<CCSLogRecord>>)target.GetFieldOrProperty("BaseRecordVMList"); 
            Assert.IsNotNull(target.GetFieldOrProperty("BaseRecordVMList"));
        }

        /// <summary>
        ///A test for BookmarkList
        ///</summary>
        [TestMethod()]
        public void BookmarkListTest()
        {
            IList<CCSLogRecord> expected = null; 
            IList<CCSLogRecord> actual;
            target.BookmarkList = expected;
            actual = target.BookmarkList;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ClickedRecord
        ///</summary>
        [TestMethod()]
        public void ClickedRecordTest()
        {
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
            BaseLogRecordDisplayViewModel<CCSLogRecord> actual = (BaseLogRecordDisplayViewModel<CCSLogRecord>)target.GetFieldOrProperty("ClickedRecord");
            BaseLogRecordDisplayViewModel<CCSLogRecord> expected = null; 
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ClickedRecordIsOnFollowModeTest()
        {
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime= DateTime.Parse("2013-12-12 12:12:12.000");
            CCSLogRecordDisplayViewModel clickedRecord = new CCSLogRecordDisplayViewModel(record, null); ;
            target.SetProperty("IsOnFollowMode", true);
            target.SetProperty("ClickedRecord", clickedRecord);
            BaseLogRecordDisplayViewModel<CCSLogRecord> actual = (BaseLogRecordDisplayViewModel<CCSLogRecord>)target.GetProperty("ClickedRecord");
            Assert.AreEqual(record.Date, actual.Data.Date);
        }
        /// <summary>
        ///A test for CommentsDict
        ///</summary>
        [TestMethod()]
        public void CommentsDictTest()
        {
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
            Dictionary<CCSLogRecord, string> actual = (Dictionary<CCSLogRecord, string>)target.GetFieldOrProperty("CommentsDict");
            Assert.AreEqual(0, actual.Count);
        }

        /// <summary>
        ///A test for CopyCommand
        ///</summary>
        [TestMethod()]
        public void CopyCommandTest()
        {
            ICommand actual;
            actual = target.CopyCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for FilterSetting
        ///</summary>
        [TestMethod()]
        public void FilterSettingTest()
        {
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
            List<FilterItemSetting> actual = (List<FilterItemSetting>)target.GetFieldOrProperty("FilterSetting");
            Assert.AreEqual(0, actual.Count);
        }

        /// <summary>
        ///A test for FontOfDataGrid
        ///</summary>
        [TestMethod()]
        public void FontOfDataGridTest()
        {
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
            double actual = (double)target.GetFieldOrProperty("FontOfDataGrid");
            Assert.AreEqual(ConfigValue.DefaultFontSize, actual);
        }
        [TestMethod()]
        public void FontOfDataGridMinimunFontSizeTest()
        {
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
            target.SetFieldOrProperty("FontOfDataGrid", 2);
            double actual = (double)target.GetFieldOrProperty("FontOfDataGrid");
            Assert.AreEqual(ConfigValue.MinimunFontSize, actual);
        }
        [TestMethod()]
        public void FontOfDataGridMaximunFontSizeTest()
        {
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
            target.SetFieldOrProperty("FontOfDataGrid", 20);
            double actual = (double)target.GetFieldOrProperty("FontOfDataGrid");
            Assert.AreEqual(ConfigValue.MaximunFontSize, actual);
        }
        /// <summary>
        ///A test for IsOnFollowMode
        ///</summary>
        [TestMethod()]
        public void IsOnFollowModeTest()
        {
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
            bool expected = false;
            bool actual = (bool)target.GetFieldOrProperty("IsOnFollowMode");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for PatternColor
        ///</summary>
        [TestMethod()]
        public void PatternColorTest()
        {
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
            target.SetFieldOrProperty("PatternColor", new PatternColor<CCSLogRecord>(new Dictionary<int, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>(), new List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>()));
            PatternColor<CCSLogRecord> PatternColor = (PatternColor<CCSLogRecord>)target.GetFieldOrProperty("PatternColor");
            Assert.AreEqual(0, PatternColor._rootKey.Count);
        }

        /// <summary>
        ///A test for ProcessTime
        ///</summary>

        [TestMethod()]
        public void ProcessTimeTest()
        {
            string expected = string.Empty; 
            string actual;
            target.ProcessTime = expected;
            actual = target.ProcessTime;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for RecordForFollow
        ///</summary>
        [TestMethod()]
        public void RecordForFollowTest()
        {
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
            
            BaseLogRecordDisplayViewModel<CCSLogRecord> expected = null;
            BaseLogRecordDisplayViewModel<CCSLogRecord> actual = (BaseLogRecordDisplayViewModel<CCSLogRecord>)target.GetFieldOrProperty("RecordForFollow");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for RecordForJump
        ///</summary>
        [TestMethod()]
        public void RecordForJumpTest()
        {
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM);
            BaseLogRecordDisplayViewModel<CCSLogRecord> expected = null; 
            BaseLogRecordDisplayViewModel<CCSLogRecord> actual = (BaseLogRecordDisplayViewModel<CCSLogRecord>)target.GetFieldOrProperty("RecordForJump");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for RefreshData
        ///</summary>
        [TestMethod()]
        public void RefreshDataTest()
        {
            bool expected = false;
            bool actual;
            target.RefreshData = expected;
            actual = target.RefreshData;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SelectedItems
        ///</summary>
        [TestMethod()]
        public void SelectedItemsTest()
        {
            IList<object> expected = null; 
            IList<object> actual;
            target.SelectedItems = expected;
            actual = target.SelectedItems;
            Assert.AreEqual(expected, actual);
        }
    }
}
