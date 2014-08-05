using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Model;
using LogViewer.Business;
using System.Collections.Generic;
using LogViewer.MVVMHelper;
using System.Windows.Input;
using System.Collections.ObjectModel;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.IO;
using System.Linq;
namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for BaseLogMainViewModelTest and is intended
    ///to contain all BaseLogMainViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BaseLogMainViewModelTest
    {

        public static MainViewModel_Accessor targetMainVM;
        public static CCSMainViewModel_Accessor target;
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
        public void SetUp()
        {
            if (!ServiceLocator.services.ContainsKey(typeof(IDialogService)))
            {
                ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
                ServiceLocator.RegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
                ServiceLocator.Register<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
                ServiceLocator.Register<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
            }
            targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            PrivateObject param0 = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            target = new CCSMainViewModel_Accessor(param0);
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


        [TestMethod()]
        public void AddBookmarkTest()
        {
            CCSLogRecord record = new CCSLogRecord();
            record.Content = "test";
            record.Line = 1;
            target.AddBookmark(record);
            Assert.IsTrue(target.AnalyzeAreaVM.LogBookmarkTabVM.LogRecordList.Contains(record));
        }

        /// <summary>
        /// AddMoreBookmark
        /// </summary>
        [TestMethod()]
        public void AddMoreBookmarkTest()
        {
            var actual = target.AddMoreBookmark;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for AnalyzePattern
        ///</summary>
        [TestMethod()]
        public void AnalyzePatternTest()
        {
            IList<PatternItemSetting> settings = null;
            target.AnalyzePattern(settings);
            Assert.IsTrue(target.AnalyzeAreaVM.LogPatternTabVM.PatternRecordList == null || target.AnalyzeAreaVM.LogPatternTabVM.PatternRecordList.Count == 0); 
        }
        /// <summary>
        ///A test for ApplyFilterSetting
        ///</summary>
        //[TestMethod()]
        //public void ApplyFilterSettingPatternColorNotNullTest()
        //{

        //    List<FilterItemSetting> data = new List<FilterItemSetting>();
        //    //target.ApplyFilterSetting(data);

        //    PrivateObject target = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
        //    CCSLogsDisplayViewModel LogsDisplayVM = (CCSLogsDisplayViewModel)target.GetProperty("LogsDisplayVM");
        //    LogsDisplayVM.PatternColor = new PatternColor<CCSLogRecord>(new Dictionary<int, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>(), new List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>());
        //    target.Invoke("ApplyFilterSetting", new object[] { data });
        //}
        //[TestMethod()]
        //public void ApplyFilterSettingPatternColorNullTest()
        //{

        //    List<FilterItemSetting> data = new List<FilterItemSetting>();
        //    //target.ApplyFilterSetting(data);

        //    PrivateObject target = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
        //    //CCSLogsDisplayViewModel LogsDisplayVM = (CCSLogsDisplayViewModel)target.GetProperty("LogsDisplayVM");
        //    //LogsDisplayVM.PatternColor = new PatternColor<CCSLogRecord>(new Dictionary<int, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>(), new List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>());
        //    target.Invoke("ApplyFilterSetting", new object[] { data });
        //}
        /// <summary>
        ///A test for ApplyKeywordCountSetting
        ///</summary>
        [TestMethod()]
        public void ApplyKeywordCountSettingTest()
        {
            List<KeywordCountItemSetting> data = new List<KeywordCountItemSetting>();
            target.ApplyKeywordCountSetting(data);
        }

        /// <summary>
        ///A test for ApplyPatternSetting
        ///</summary>
        //[TestMethod()]
        //[DeploymentItem("LogViewer.exe")]
        //public void ApplyPatternSettingTest()
        //{
        //    List<PatternItemSetting> data = new List<PatternItemSetting>();
        //    target.ApplyPatternSetting(data);
        //}

        [TestMethod()]
        public void ClearAllCommandCLTest()
        {
            target.ClearAllCommandCL();
            Assert.AreEqual(false, target.IsOnNarrowColorFilter);
            Assert.AreEqual(0, target.LogAnalyser.PatternAnalyzeBuffer.Count);
        }

        /// <summary>
        ///A test for ClearAnalyzeCommandCL
        ///</summary>
        [TestMethod()]
        public void ClearAnalyzeCommandCLTest()
        {
            target.ClearAnalyzeCommandCL();
            Assert.AreEqual(0, target.LogAnalyser.PatternAnalyzeBuffer.Count);
        }

        /// <summary>
        ///A test for ClearColorFilterSetting
        ///</summary>
        [TestMethod()]
        public void ClearColorFilterSettingTest()
        {
            target.ClearColorFilterSetting();
            Assert.AreEqual(0, target.SettingManager.ColorFilterSettingList.FindAll(x => x.Enabled == true).Count);
        }

        /// <summary>
        ///A test for ClearColorFilterSettingCommandCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ClearColorFilterSettingCommandCLTest()
        {
            target.ClearColorFilterSettingCommandCL();
            Assert.AreEqual(0, target.SettingManager.ColorFilterSettingList.FindAll(x => x.Enabled == true).Count);
        }

        /// <summary>
        ///A test for ClearNarrowFilter
        ///</summary>
        [TestMethod()]
        public void ClearNarrowFilterTest()
        {
            target.ClearNarrowFilter();
            Assert.IsFalse(target.IsOnNarrowNonColorFilter);   
        }

        /// <summary>
        ///A test for ClearWhenLoadFile
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ClearWhenLoadFileTest()
        {
            target.ClearWhenLoadFile();
            
        }

        /// <summary>
        ///A test for ClosePopupCommandCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ClosePopupCommandCLTest()
        {
            target.ClosePopupCommandCL();
            
        }

        /// <summary>
        ///A test for ConvertToTimestamp
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ConvertToTimestampTest()
        {
            DateTime value = Convert.ToDateTime("0001-01-01 00:00:00");
            double expected = -62135622000; 
            double actual;
            actual = BaseLogMainViewModel_Accessor<CCSLogRecord>.ConvertToTimestamp(value);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CountKeyword
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CountKeywordTest()
        {
            List<KeywordCountItemSetting> settings = new List<KeywordCountItemSetting>();
            target.CountKeyword(settings);            
        }

        /// <summary>
        ///A test for CountKeywordCommandCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CountKeywordCommandCLTest()
        {
            target.CountKeywordCommandCL();
        }


        /// <summary>
        ///A test for EditFilterSettingCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void EditFilterSettingCLTest()
        {
            target.EditFilterSettingCL();
        }

        /// <summary>
        ///A test for EditKeywordCountSettingCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void EditKeywordCountSettingCLTest()
        {
            target.EditKeywordCountSettingCL();
        }

        /// <summary>
        ///A test for EditPatternSettingCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void EditPatternSettingCLTest()
        {
            target.EditPatternSettingCL();
        }

        /// <summary>
        ///A test for ExpandCommandCL
        ///</summary>
        [TestMethod()]
        public void ExpandCommandCLTest()
        {
            target.ExpandCommandCL();
        }

        /// <summary>
        ///A test for ExportMemoLogFileCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ExportMemoLogFileCLTest()
        {
            target.ExportMemoLogFileCL();
        }

        /// <summary>
        ///A test for FollowRecordWithDateTime
        ///</summary>
        [TestMethod()]
        public void FollowRecordWithDateTimeTest()
        {
            string date = "2013-10-10";
            string time = "00:00:01";
            targetMainVM.CCSMainVM.FollowRecordWithDateTime(date, time);
            Assert.IsNull(targetMainVM.CCSMainVM.LogsDisplayVM.RecordForFollow);
        }

        /// <summary>
        ///A test for FollowRecordWithDateTime
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void FollowRecordWithDateTime_LogNotEmptyTest()
        {
            string date = "2013-10-02";
            string time = "13:36:38.310";
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.FollowRecordWithDateTime(date, time);
            Assert.IsNull(targetMainVM.CCSMainVM.LogsDisplayVM.RecordForFollow);
        }
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void FollowRecordWithDateTime_LogNotEmptyTest1()
        {
            string date = "2013-10-02";
            string time = "13:36:38.494";
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.FollowRecordWithDateTime(date, time);
            Assert.IsNull(targetMainVM.CCSMainVM.LogsDisplayVM.RecordForFollow);
        }
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void FollowRecordWithDateTime_LogNotEmptyTest2()
        {
            string date = "2013-10-12";
            string time = "13:36:38.308";
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.FollowRecordWithDateTime(date, time);
            Assert.IsNull(targetMainVM.CCSMainVM.LogsDisplayVM.RecordForFollow);
        }
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void FollowRecordWithDateTime_LogNotEmptyTest3()
        {
            string date = "2013-09-12";
            string time = "13:36:38.308";
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.FollowRecordWithDateTime(date, time);
            Assert.IsNull(targetMainVM.CCSMainVM.LogsDisplayVM.RecordForFollow);
        }
        /// <summary>
        ///A test for GetDateTime
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void GetDateTimeTest()
        {
            string date =  "2013-10-10";
            string time ="00:00:01";
            DateTime expected = Convert.ToDateTime(date + " " + time);
            DateTime actual;
            actual = target.GetDateTime(date, time);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetFilterButtonList
        ///</summary>
        [TestMethod()]
        public void GetFilterButtonListTest()
        {
            List<FilterItemSetting> data = new List<FilterItemSetting>();
            List<FilterButtonViewModel> expected = new List<FilterButtonViewModel>();
            IList<FilterButtonViewModel> actual;
            actual = target.GetFilterButtonList(data);
            Assert.AreEqual(expected.Count, actual.Count);
            
        }

        /// <summary>
        ///A test for GetKeywords
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void GetKeywordsTest()
        {
            List<string> expected = new List<string>();
            List<string> actual;
            target.StringFilter = "aaa";
            expected.Add(target.StringFilter);
            actual = target.GetKeywords();
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected[expected.Count - 1], actual[actual.Count - 1]);
        }

        /// <summary>
        ///A test for GoToBotCommandCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void GoToBotCommandCLTest()
        {
            target.GoToBotCommandCL();

        }

        /// <summary>
        ///A test for GoToTopCommandCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void GoToTopCommandCLTest()
        {
            target.GoToTopCommandCL();
        }

        /// <summary>
        ///A test for InitLogItemList
        ///</summary>
        //[TestMethod()]
        //[DeploymentItem("LogViewer.exe")]
        //public void InitLogItemListTest()
        //{

        //}

        /// <summary>
        ///A test for IsExecuteDrag
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsExecuteDragTest()
        {
            DataGridDragDropEventArgs args = null; 
            bool expected = false; 
            bool actual;
            actual = target.IsExecuteDrag(args);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for JumpToLine
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void JumpToLineTest()
        {
            int line = 0; 
            target.JumpToLine(line);
        }
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void JumpToLineTest1()
        {
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
            PrivateObject target = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            int line = 1;
            target.Invoke("JumpToLine", new object[]{ line });
            Assert.AreEqual(line, targetMainVM.CCSMainVM.LogsDisplayVM.RecordForFollow.Line);
        }


        /// <summary>
        ///A test for LoadConfig
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\DefaultCCSFilteringSetting.csv")]
        [DeploymentItem(@"FileConfig\DefaultCCSKeywordSetting.csv")]
        [DeploymentItem(@"FileConfig\DefaultCCSLogSetting.csv")]
        [DeploymentItem(@"FileConfig\DefaultCCSPatternSetting.xml")]
        public void LoadConfigNotFaultUserSettingTest()
        {
            string oldDefaultCCSFilteringSetting = ConfigValue.DefaultCCSFilteringSettingFile;
            string DefaultCCSFilteringSetting = @"DefaultCCSFilteringSetting.csv";
            ConfigValue.DefaultCCSFilteringSettingFile = Path.GetFullPath(DefaultCCSFilteringSetting);

            string oldDefaultCCSKeywordSetting = ConfigValue.DefaultCCSKeywordSettingFile;
            string DefaultCCSKeywordSetting = @"DefaultCCSKeywordSetting.csv";
            ConfigValue.DefaultCCSKeywordSettingFile = Path.GetFullPath(DefaultCCSKeywordSetting);

            string oldDefaultCCSLogSetting = ConfigValue.DefaultCCSLogSettingFile;
            string DefaultCCSLogSetting = @"DefaultCCSLogSetting.csv";
            ConfigValue.DefaultCCSLogSettingFile = Path.GetFullPath(DefaultCCSLogSetting);

            string oldDefaultCCSPatternSetting = ConfigValue.DefaultCCSPatternSettingFile;
            string DefaultCCSPatternSetting = @"DefaultCCSPatternSetting.csv";
            ConfigValue.DefaultCCSPatternSettingFile = Path.GetFullPath(DefaultCCSPatternSetting);

            string actual;
            actual = targetMainVM.CCSMainVM.LoadConfig();
            Assert.IsNotNull(actual);

            ConfigValue.DefaultCCSFilteringSettingFile = oldDefaultCCSFilteringSetting;
            ConfigValue.DefaultCCSKeywordSettingFile = oldDefaultCCSKeywordSetting;
            ConfigValue.DefaultCCSLogSettingFile = oldDefaultCCSLogSetting;
            ConfigValue.DefaultCCSPatternSettingFile = oldDefaultCCSPatternSetting;
        }

        [TestMethod()]
        public void LoadConfigNotFoundSettingTest()
        {
            string actual;
            var a = ConfigValue.DefaultCCSFilteringSettingFile;
            actual = targetMainVM.CCSMainVM.LoadConfig();
            Assert.IsNotNull(actual);
        }
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void LoadConfigTest()
        {
            string expected = string.Empty;
            string actual;
            target._baseSettingManger = null;
            actual = target.LoadConfig();
            Assert.AreNotEqual(expected, actual);
        }


        /// <summary>
        ///A test for LoadDataWhenClearColor
        ///</summary>
        [TestMethod()]
        public void LoadDataWhenClearColorTest()
        {
            target.LoadDataWhenClearColor();

        }

        /// <summary>
        ///A test for LoadLogFileCL
        ///</summary>
        //[TestMethod()]
        //[DeploymentItem("LogViewer.exe")]
        //public void LoadLogFileCLTest()
        //{
        //    //target.LoadLogFileCL();

        //}

        /// <summary>
        ///A test for LoadMemoLogFileCL
        ///</summary>
        //[TestMethod()]
        //public void LoadMemoLogFileCLTest()
        //{
        //    //target.LoadMemoLogFileCL();

        //}

        ///// <summary>
        /////A test for NarrowColorFilterCL
        /////</summary>
        //[TestMethod()]
        //public void NarrowColorFilterCLStopAnalyzeTest()
        //{
        //    PrivateObject target = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
        //    CCSLogsAnalyser _logAnalyser = (CCSLogsAnalyser)target.GetField("_logAnalyser");
        //    PrivateObject AnalyserTarget = new PrivateObject(_logAnalyser);
        //    List<CCSLogRecord> listFilter = new List<CCSLogRecord>();
        //    List<CCSLogRecord> listAll = new List<CCSLogRecord>();
        //    CCSLogRecord record = new CCSLogRecord();
        //    listAll.Add(record);
        //    AnalyserTarget.SetField("_filteredLogRecordsBuffer", listFilter);
        //    AnalyserTarget.SetField("_allLogRecordsBuffer", listAll);
        //    //target.Invoke("NarrowColorFilterCL");
        //    Assert.IsFalse((bool)target.GetProperty("IsOnNarrowColorFilter"));
        //}

        //[TestMethod()]
        //public void NarrowColorFilterCLDisablePatternColorNullTest()
        //{
        //    PrivateObject target = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
        //    //target.Invoke("NarrowColorFilterCL");
        //    Assert.IsFalse((bool)target.GetProperty("IsOnNarrowColorFilter"));
        //}
        //[TestMethod()]
        //public void NarrowColorFilterCLDisablePatternColorNotNullTest()
        //{
        //    PrivateObject target = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
        //    CCSLogsDisplayViewModel LogsDisplayVM = (CCSLogsDisplayViewModel)target.GetProperty("LogsDisplayVM");
        //    LogsDisplayVM.PatternColor = new PatternColor<CCSLogRecord>(new Dictionary<int, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>(), new List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>());
        //    //target.Invoke("NarrowColorFilterCL");
        //    Assert.IsFalse((bool)target.GetProperty("IsOnNarrowColorFilter"));
        //}

        //[TestMethod()]
        //public void NarrowColorFilterCLEnableStringFilterIsEmptyTest()
        //{
        //    PrivateObject target = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
        //    target.SetProperty("IsOnNarrowColorFilter", true);
        //    target.SetProperty("LogItem", "");
        //    target.SetProperty("StringFilter", "");
        //    //CCSLogsDisplayViewModel LogsDisplayVM = (CCSLogsDisplayViewModel)target.GetProperty("LogsDisplayVM");
        //    //LogsDisplayVM.PatternColor = new PatternColor<CCSLogRecord>(new Dictionary<int, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>(), new List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>());
        //    //target.Invoke("NarrowColorFilterCL");
        //    Assert.IsTrue((bool)target.GetProperty("IsOnNarrowColorFilter"));
        //}
        //[TestMethod()]
        //public void NarrowColorFilterCLEnableStringFilterIsNotEmptyTest()
        //{
        //    PrivateObject target = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
        //    target.SetProperty("IsOnNarrowColorFilter", true);
        //    target.SetProperty("LogItem", "Content");
        //    target.SetProperty("StringFilter", "test");
        //    //CCSLogsDisplayViewModel LogsDisplayVM = (CCSLogsDisplayViewModel)target.GetProperty("LogsDisplayVM");
        //    //LogsDisplayVM.PatternColor = new PatternColor<CCSLogRecord>(new Dictionary<int, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>(), new List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>());
        //    //target.Invoke("NarrowColorFilterCL");
        //    Assert.IsTrue((bool)target.GetProperty("IsOnNarrowColorFilter"));
        //}
        //[TestMethod()]
        //public void NarrowColorFilterCLEnableStringFilterIsNotEmptyHasStopTest()
        //{
        //    PrivateObject target = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
        //    target.SetProperty("IsOnNarrowColorFilter", true);
        //    target.SetProperty("LogItem", "Content");
        //    target.SetProperty("StringFilter", "test");
        //    CCSLogsAnalyser _logAnalyser = (CCSLogsAnalyser)target.GetField("_logAnalyser");
        //    PrivateObject AnalyserTarget = new PrivateObject(_logAnalyser);
        //    List<CCSLogRecord> listFilter = new List<CCSLogRecord>();
        //    List<CCSLogRecord> listAll = new List<CCSLogRecord>();
        //    CCSLogRecord record = new CCSLogRecord();
        //    listAll.Add(record);
        //    AnalyserTarget.SetField("_filteredLogRecordsBuffer", listFilter);
        //    AnalyserTarget.SetField("_allLogRecordsBuffer", listAll);
        //    //target.Invoke("NarrowColorFilterCL");
        //    Assert.IsTrue((bool)target.GetProperty("IsOnNarrowColorFilter"));
        //}
        //[TestMethod()]
        //public void NarrowColorFilterCLEnableStringFilterIsNotEmptyHasStopPatternIsNullTest()
        //{
        //    PrivateObject target = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
        //    target.SetProperty("IsOnNarrowColorFilter", true);
        //    target.SetProperty("LogItem", "Content");
        //    target.SetProperty("StringFilter", "test");
        //    CCSLogsAnalyser _logAnalyser = (CCSLogsAnalyser)target.GetField("_logAnalyser");
        //    PrivateObject AnalyserTarget = new PrivateObject(_logAnalyser);
        //    List<CCSLogRecord> listFilter = new List<CCSLogRecord>();
        //    List<CCSLogRecord> listAll = new List<CCSLogRecord>();
        //    CCSLogRecord record = new CCSLogRecord();
        //    listAll.Add(record);
        //    AnalyserTarget.SetField("_filteredLogRecordsBuffer", listFilter);
        //    AnalyserTarget.SetField("_allLogRecordsBuffer", listAll);
        //    //target.Invoke("NarrowColorFilterCL");
        //    Assert.IsTrue((bool)target.GetProperty("IsOnNarrowColorFilter"));
        //}
        //[TestMethod()]
        //public void NarrowColorFilterCLEnableStringFilterIsNotEmptyHasStopPatternIsNotNullTest()
        //{
        //    PrivateObject target = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
        //    target.SetProperty("IsOnNarrowColorFilter", true);
        //    target.SetProperty("LogItem", "Content");
        //    target.SetProperty("StringFilter", "test");
        //    CCSLogsAnalyser _logAnalyser = (CCSLogsAnalyser)target.GetField("_logAnalyser");
        //    PrivateObject AnalyserTarget = new PrivateObject(_logAnalyser);
        //    List<CCSLogRecord> listFilter = new List<CCSLogRecord>();
        //    List<CCSLogRecord> listAll = new List<CCSLogRecord>();
        //    CCSLogRecord record = new CCSLogRecord();
        //    listAll.Add(record);
        //    AnalyserTarget.SetField("_filteredLogRecordsBuffer", listFilter);
        //    AnalyserTarget.SetField("_allLogRecordsBuffer", listAll);
        //    CCSLogsDisplayViewModel LogsDisplayVM = (CCSLogsDisplayViewModel)target.GetProperty("LogsDisplayVM");
        //    LogsDisplayVM.PatternColor = new PatternColor<CCSLogRecord>(new Dictionary<int, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>(), new List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>());
        //    //target.Invoke("NarrowColorFilterCL");
        //    Assert.IsTrue((bool)target.GetProperty("IsOnNarrowColorFilter"));
        //}
        ///// <summary>
        /////A test for NarrowNonColorFilterCL
        /////</summary>
        //[TestMethod()]
        //public void NarrowNonColorFilterCLDisableTest()
        //{
        //    //target.NarrowNonColorFilterCL();
        //    Assert.IsFalse(target.IsOnNarrowNonColorFilter);
        //}

        //[TestMethod()]
        //public void NarrowNonColorFilterCLEnableStringFilterIsEmptyTest()
        //{
        //    target.IsOnNarrowNonColorFilter = true;
        //    target.StringFilter = String.Empty;
        //    //target.NarrowNonColorFilterCL();
        //    Assert.IsTrue(target.IsOnNarrowNonColorFilter);
        //}
        //[TestMethod()]
        //public void NarrowNonColorFilterCLEnableStringFilterIsNotEmptyTest()
        //{
        //    target.IsOnNarrowNonColorFilter = true;
        //    target.StringFilter = "test";
        //    //target.NarrowNonColorFilterCL();
        //    Assert.IsTrue(target.IsOnNarrowNonColorFilter);
        //}
        /// <summary>
        ///A test for OnOtherLogsLoadedHandler
        ///</summary>
        [TestMethod()]
        public void OnOtherLogsLoadedHandlerTest()
        {
            target.OnOtherLogsLoadedHandler();

        }

        /// <summary>
        ///A test for OpenPopupCommandCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void OpenPopupCommandCLTest()
        {
            target.OpenPopupCommandCL();

        }

        /// <summary>
        ///A test for PatternAnalyserCommandCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void PatternAnalyserCommandCLTest()
        {
            target.PatternAnalyserCommandCL();

        }


        /// <summary>
        ///A test for ProcessTimeCommandCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ProcessTimeCommandCLTest()
        {
            string expected = "999 " + "ms";

            List<BaseLogRecordDisplayViewModel<CCSLogRecord>> logDisplays = new List<BaseLogRecordDisplayViewModel<CCSLogRecord>>();
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime= DateTime.Parse("2013-10-10 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime= DateTime.Parse("2013-10-10 00:00:01.999");

            CCSLogRecordDisplayViewModel recordVM1 = new CCSLogRecordDisplayViewModel(record1, null);
            CCSLogRecordDisplayViewModel recordVM2 = new CCSLogRecordDisplayViewModel(record2, null);

            logDisplays.Add(recordVM1);
            logDisplays.Add(recordVM2);
            targetMainVM.CCSMainVM.LogsDisplayVM.SelectedItems = logDisplays.Cast<object>().ToList();
            CCSMainViewModel_Accessor ccsTarget = new CCSMainViewModel_Accessor(new PrivateObject(targetMainVM.CCSMainVM));
            ccsTarget.ProcessTimeCommandCL();
            Assert.AreEqual(expected, targetMainVM.CCSMainVM.LogsDisplayVM.ProcessTime);
        }

        /// <summary>
        ///A test for ProcessTimeLog
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ProcessTimeLogTest()
        {
            string expected = "0 " + "ms";
            List<BaseLogRecordDisplayViewModel<CCSLogRecord>> logDisplays = new List<BaseLogRecordDisplayViewModel<CCSLogRecord>>();
            target.ProcessTimeLog(logDisplays);
            Assert.AreEqual(expected, targetMainVM.CCSMainVM.LogsDisplayVM.ProcessTime);
        }

        /// <summary>
        ///A test for ProcessTimeLog
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ProcessTimeLogLogRecordIsMoreThan2Test1()
        {
            string expected = "999 " + "ms";
            List<BaseLogRecordDisplayViewModel<CCSLogRecord>> logDisplays = new List<BaseLogRecordDisplayViewModel<CCSLogRecord>>();
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime= DateTime.Parse("2013-10-10 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime= DateTime.Parse("2013-10-10 00:00:01.999");

            CCSLogRecordDisplayViewModel recordVM1 = new CCSLogRecordDisplayViewModel(record1, null);
            CCSLogRecordDisplayViewModel recordVM2 = new CCSLogRecordDisplayViewModel(record2, null);

            logDisplays.Add(recordVM1);
            logDisplays.Add(recordVM2);

            target.ProcessTimeLog(logDisplays);
            Assert.AreEqual(expected, targetMainVM.CCSMainVM.LogsDisplayVM.ProcessTime);
        }

        /// <summary>
        ///A test for ProcessTimeLog
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ProcessTimeLogLogRecordIsMoreThan2Test2()
        {
            string expected = "999 " + "ms";
            List<BaseLogRecordDisplayViewModel<CCSLogRecord>> logDisplays = new List<BaseLogRecordDisplayViewModel<CCSLogRecord>>();
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime= DateTime.Parse("2013/10/10 00:00:01.000");
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime= DateTime.Parse("2013/10/10 00:00:01.999");

            CCSLogRecordDisplayViewModel recordVM1 = new CCSLogRecordDisplayViewModel(record1, null);
            CCSLogRecordDisplayViewModel recordVM2 = new CCSLogRecordDisplayViewModel(record2, null);

            logDisplays.Add(recordVM1);
            logDisplays.Add(recordVM2);

            target.ProcessTimeLog(logDisplays);
            Assert.AreEqual(expected, targetMainVM.CCSMainVM.LogsDisplayVM.ProcessTime);
        }

        /// <summary>
        ///A test for RemoveBookmark
        ///</summary>
        [TestMethod()]
        public void RemoveBookmarkTest()
        {
            CCSLogRecord record = default(CCSLogRecord); 
            target.RemoveBookmark(record);

        }

        /// <summary>
        ///A test for Search
        ///</summary>
        [TestMethod()]
        public void SearchTest()
        {
            SearchItem searchCondition = new SearchItem();
            searchCondition.LogItem = "Content";
            searchCondition.StringValue = String.Empty;
            List<CCSLogRecord> expected = new List<CCSLogRecord>();
            IList<CCSLogRecord> actual;
            actual = target.Search(searchCondition);
            Assert.AreEqual(expected.Count, actual.Count);

        }

        /// <summary>
        ///A test for SelectAllFilterSettingCommandCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void SelectAllFilterSettingCommandCLTest()
        {
            target.SelectAllFilterSettingCommandCL();
            Assert.IsTrue(target.SettingManager.ColorFilterSettingList.FindAll(x => x.Enabled == false).Count == 0);
        }

        /// <summary>
        ///A test for SelectAllFilterSettingCommandCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        [DeploymentItem(@"FileConfig\DefaultCCSFilteringSetting.csv")]
        public void SelectAllFilterSettingCommandCL_ColorFilterSettingListNotEmptyTest()
        {
            string oldDefaultCCSFilteringSetting = ConfigValue.DefaultCCSFilteringSettingFile;
            string DefaultCCSFilteringSetting = @"DefaultCCSFilteringSetting.csv";
            ConfigValue.DefaultCCSFilteringSettingFile = Path.GetFullPath(DefaultCCSFilteringSetting);
            targetMainVM.CCSMainVM.LoadConfig();

            target.SelectAllFilterSettingCommandCL();
            Assert.IsTrue(target.SettingManager.ColorFilterSettingList.FindAll(x => x.Enabled == false).Count == 0);
            ConfigValue.DefaultCCSFilteringSettingFile = oldDefaultCCSFilteringSetting;
        }

        /// <summary>
        ///A test for ShirnkCommandCL
        ///</summary>
        [TestMethod()]
        public void ShirnkCommandCLTest()
        {
            target.ShirnkCommandCL();

        }

        ///// <summary>
        /////A test for ShowPatternColoringRecord
        /////</summary>
        //[TestMethod()]
        //public void ShowPatternColoringRecordTest()
        //{
        //    CCSLogRecord record = new CCSLogRecord();
        //    record.AdditionalInfo = "";
        //    record.ClassName = "";
        //    record.Id = "1";
        //    record.Line = 1;
        //    AnalyzedPatternResultItem_Accessor<CCSLogRecord> currentPatternItem = new AnalyzedPatternResultItem_Accessor<CCSLogRecord>();
        //    Dictionary<CCSLogRecord,KeyIndexRecordPair<int,string,int,CCSLogRecord,string>> rootkey = new Dictionary<CCSLogRecord,KeyIndexRecordPair<int,string,int,CCSLogRecord,string>>();
        //    rootkey.Add(record, new KeyIndexRecordPair<int,string,int,CCSLogRecord,string>());
        //    currentPatternItem.RootKey = rootkey;
        //    Dictionary<CCSLogRecord, List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>> foundPattern = new Dictionary<CCSLogRecord, List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>>();
        //    foundPattern.Add(record, new List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>());
        //    currentPatternItem._foundPattern = foundPattern;
        //    //target.ShowPatternColoringRecord(record, (AnalyzedPatternResultItem<CCSLogRecord>)currentPatternItem.Target);

        //}

        /// <summary>
        ///A test for ShowRecord
        ///</summary>
        [TestMethod()]
        public void ShowRecordTest()
        {
            CCSLogRecord record = default(CCSLogRecord); 
            target.ShowRecord(record);

        }

        /// <summary>
        ///A test for ShowRecordWithDateTime
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void ShowRecordWithDateTimeHasNotMilisecondTest()
        {
            string date =  "2013-10-10";
            string time = "00:00:01.";
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM);
            target.Invoke("ShowRecordWithDateTime", new object[] { date, time });
            Assert.IsNotNull(targetMainVM.CCSMainVM.LogsDisplayVM.RecordForJump);
        }
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void ShowRecordWithDateTimeNotHasMilisecondTest()
        {
            string date =  "2013-10-10";
            string time = "00:00:01.999";
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM);
            target.Invoke("ShowRecordWithDateTime", new object[] { date, time });
            Assert.IsNotNull(targetMainVM.CCSMainVM.LogsDisplayVM.RecordForJump);
        }
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void ShowRecordWithDateTime_LogNotEmptyTest()
        {
            string date= "2013-10-02.";
            string time = "13:36:38.310";
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM);
            target.Invoke("ShowRecordWithDateTime", new object[] { date, time });
            Assert.IsNotNull(targetMainVM.CCSMainVM.LogsDisplayVM.RecordForJump);
        }
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void ShowRecordWithDateTime_LogNotEmptyTest1()
        {
            string date = "2013-10-02.";
            string time = "13:36:38.494";
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM);
            target.Invoke("ShowRecordWithDateTime", new object[] { date, time });
            Assert.IsNotNull(targetMainVM.CCSMainVM.LogsDisplayVM.RecordForJump);
        }
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void ShowRecordWithDateTime_LogNotEmptyTest2()
        {
            string date = "2013-10-12.";
            string time = "13:36:38.308";
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM);
            target.Invoke("ShowRecordWithDateTime", new object[] { date, time });
            Assert.IsNotNull(targetMainVM.CCSMainVM.LogsDisplayVM.RecordForJump);
        }
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void ShowRecordWithDateTime_LogNotEmptyTest3()
        {
            string date =  "2013-09-12.";
            string time = "13:36:38.308";
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
            PrivateObject target = new PrivateObject(targetMainVM.CCSMainVM);
            target.Invoke("ShowRecordWithDateTime", new object[] { date, time });
            Assert.IsNotNull(targetMainVM.CCSMainVM.LogsDisplayVM.RecordForJump);
        }
        /// <summary>
        ///A test for StartAllAnalyProcess
        ///</summary>
        [TestMethod()]
        public void StartAllAnalyzeProcessTest()
        {
            target.StartAllAnalyzeProcess();

        }

        /// <summary>
        ///A test for StopAllAnalyProcess
        ///</summary>
        [TestMethod()]
        public void StopAllAnalyzeProcessTest()
        {
            target.StopAllAnalyProcess();

        }

        /// <summary>
        ///A test for StopAnalyzePatternWorker
        ///</summary>
        [TestMethod()]
        public void StopAnalyzePatternWorkerTest()
        {
            target.StopAnalyzePatternWorker();

        }

        /// <summary>
        ///A test for StopKeywordCountWorker
        ///</summary>
        [TestMethod()]
        public void StopKeywordCountWorkerTest()
        {
            target.StopKeywordCountWorker();

        }

        /// <summary>
        ///A test for UpdateCurrentFileName
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void UpdateCurrentFileNameTest()
        {
            CCSLogRecord record = default(CCSLogRecord); 
            target.UpdateCurrentFileName(record);

        }

        ///// <summary>
        /////A test for ValidLogFileExtension
        /////</summary>
        //[TestMethod()]
        //[DeploymentItem("LogViewer.exe")]
        //public void ValidLogFileExtensionTest()
        //{

        //}

        /// <summary>
        ///A test for ValidateStringFilter
        ///</summary>
        [TestMethod()]
        public void ValidateStringFilterIsEmptyTest()
        {
            string expected = string.Empty; 
            string actual;
            actual = target.ValidateStringFilter();
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void ValidateStringFilterIsNotEmptyTest()
        {
            string expected = string.Empty;
            string actual;
            target.StringFilter = "test";
            actual = target.ValidateStringFilter();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ValidateStringFilterIsNotEmptyMaxKeywordCountTest()
        {
            string expected = "Can filter upto 5 keywords";
            string actual;
            target.StringFilter = "test test1 test2 test3 test4 test5";
            actual = target.ValidateStringFilter();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ValidateStringFilterIsNotEmptyValidateLengthKeywordTest()
        {
            string expected = "Maximum length of Keyword is 50 characters";
            string actual;
            target.StringFilter = "012345678901234567890123456789012345678901234567890123456789";
            actual = target.ValidateStringFilter();
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for contains
        ///</summary>
        //[TestMethod()]
        //public void containsTest()
        //{

        //}

        /// <summary>
        ///A test for ClearAllCommand
        ///</summary>
        [TestMethod()]
        public void ClearAllCommandTest()
        {
            ICommand actual;
            actual = target.ClearAllCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for ClearAnalyzeCommand
        ///</summary>
        [TestMethod()]
        public void ClearAnalyzeCommandTest()
        {
            ICommand actual;
            actual = target.ClearAnalyzeCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for ClearColorFilterSettingCommand
        ///</summary>
        [TestMethod()]
        public void ClearColorFilterSettingCommandTest()
        {
            ICommand actual;
            actual = target.ClearColorFilterSettingCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for ClosePopupCommand
        ///</summary>
        [TestMethod()]
        public void ClosePopupCommandTest()
        {
            ICommand actual;
            actual = target.ClosePopupCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for CountKeywordCommand
        ///</summary>
        [TestMethod()]
        public void CountKeywordCommandTest()
        {
            ICommand actual;
            actual = target.CountKeywordCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for CurrentLogFileName
        ///</summary>
        [TestMethod()]
        public void CurrentLogFileNameTest()
        {
            string expected = string.Empty;
            string actual;
            target.CurrentLogFileName = expected;
            actual = target.CurrentLogFileName;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for DisplaySetting
        ///</summary>
        [TestMethod()]
        public void DisplaySettingTest()
        {
            ObservableCollection<LogDisplay> expected = null; 
            ObservableCollection<LogDisplay> actual;
            target.DisplaySetting = expected;
            actual = target.DisplaySetting;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for DragDropCommand
        ///</summary>
        [TestMethod()]
        public void DragDropCommandTest()
        {
            ICommand actual;
            actual = target.DragDropCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for EditFilterSettingCommand
        ///</summary>
        [TestMethod()]
        public void EditFilterSettingCommandTest()
        {
            ICommand actual;
            actual = target.EditFilterSettingCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for EditKeywordCountSettingCommand
        ///</summary>
        [TestMethod()]
        public void EditKeywordCountSettingCommandTest()
        {
            ICommand actual;
            actual = target.EditKeywordCountSettingCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for EditPatternSettingCommand
        ///</summary>
        [TestMethod()]
        public void EditPatternSettingCommandTest()
        {
            ICommand actual;
            actual = target.EditPatternSettingCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for ExpandCommand
        ///</summary>
        [TestMethod()]
        public void ExpandCommandTest()
        {
            ICommand actual;
            actual = target.ExpandCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for ExportMemoLogFileCommand
        ///</summary>
        [TestMethod()]
        public void ExportMemoLogFileCommandTest()
        {
            ICommand actual;
            actual = target.ExportMemoLogFileCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for FilterSettingList
        ///</summary>
        [TestMethod()]
        public void FilterSettingListTest()
        {
            ObservableCollection<FilterButtonViewModel> expected = null; 
            ObservableCollection<FilterButtonViewModel> actual;
            target.FilterSettingList = expected;
            actual = target.FilterSettingList;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for GoToBotCommand
        ///</summary>
        [TestMethod()]
        public void GoToBotCommandTest()
        {
            ICommand actual;
            actual = target.GoToBotCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for GoToTopCommand
        ///</summary>
        [TestMethod()]
        public void GoToTopCommandTest()
        {
            ICommand actual;
            actual = target.GoToTopCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for HasLogsData
        ///</summary>
        [TestMethod()]
        public void HasLogsDataTest()
        {
            bool actual;
            actual = target.HasLogsData;
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for HasLogsData
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void HasLogsDataTrueTest()
        {
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            target.LogAnalyser.LoadLogFile(dir, false);
            bool actual;
            actual = target.HasLogsData;
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsEnableButtonFilter
        ///</summary>
        [TestMethod()]
        public void IsEnableButtonFilterTest()
        {
            bool actual;
            actual = target.IsEnableButtonFilter;
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for IsOnNarrowColorFilter
        ///</summary>
        [TestMethod()]
        public void IsOnNarrowColorFilterTest()
        {
            bool expected = false;
            bool actual;
            target.IsOnNarrowColorFilter = expected;
            actual = target.IsOnNarrowColorFilter;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for IsOnNarrowNonColorFilter
        ///</summary>
        [TestMethod()]
        public void IsOnNarrowNonColorFilterTest()
        {
            bool expected = false;
            bool actual;
            target.IsOnNarrowNonColorFilter = expected;
            actual = target.IsOnNarrowNonColorFilter;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for IsOpenPopup
        ///</summary>
        [TestMethod()]
        public void IsOpenPopupTest()
        {
            bool expected = false;
            bool actual;
            target.IsOpenPopup = expected;
            actual = target.IsOpenPopup;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for JumpToLineCommand
        ///</summary>
        [TestMethod()]
        public void JumpToLineCommandTest()
        {
            ICommand actual;
            actual = target.JumpToLineCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for JumpToTimeCommand
        ///</summary>
        [TestMethod()]
        public void JumpToTimeCommandTest()
        {
            ICommand actual;
            actual = target.JumpToTimeCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for LoadLogFileCommand
        ///</summary>
        [TestMethod()]
        public void LoadLogFileCommandTest()
        {
            ICommand actual;
            actual = target.LoadLogFileCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for LoadMemoLogFileCommand
        ///</summary>
        [TestMethod()]
        public void LoadMemoLogFileCommandTest()
        {
            ICommand actual;
            actual = target.LoadMemoLogFileCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for LogItem
        ///</summary>
        [TestMethod()]
        public void LogItemTest()
        {
            string expected = string.Empty;
            string actual;
            target.LogItem = expected;
            actual = target.LogItem;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for LogItemList
        ///</summary>
        [TestMethod()]
        public void LogItemListTest()
        {
            ObservableCollection<ValueDisplayPair<string, string>> expected = null;
            ObservableCollection<ValueDisplayPair<string, string>> actual;
            target.LogItemList = expected;
            actual = target.LogItemList;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for LogsDisplayVM
        ///</summary>
        [TestMethod()]
        public void LogsDisplayVMTest()
        {
            BaseLogsDisplayViewModel<CCSLogRecord> actual;
            actual = targetMainVM.CCSMainVM.LogsDisplayVM;
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for MainViewModelObject
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void MainViewModelObjectTest()
        {
            object expected = null;
            object actual;
            target.MainViewModelObject = expected;
            actual = target.MainViewModelObject;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for NarrowColorFilterCommand
        ///</summary>
        [TestMethod()]
        public void NarrowColorFilterCommandTest()
        {
            ICommand actual;
            actual = target.NarrowColorFilterCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for NarrowNonColorFilterCommand
        ///</summary>
        [TestMethod()]
        public void NarrowNonColorFilterCommandTest()
        {
            ICommand actual;
            actual = target.NarrowNonColorFilterCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for OpenPopupCommand
        ///</summary>
        [TestMethod()]
        public void OpenPopupCommandTest()
        {
            ICommand actual;
            actual = target.OpenPopupCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for PatternAnalyserCommand
        ///</summary>
        [TestMethod()]
        public void PatternAnalyserCommandTest()
        {
            ICommand actual;
            actual = target.PatternAnalyserCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for ProcessTimeCommand
        ///</summary>
        [TestMethod()]
        public void ProcessTimeCommandTest()
        {
            ICommand actual;
            actual = target.ProcessTimeCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for SelectAllFilterSettingCommand
        ///</summary>
        [TestMethod()]
        public void SelectAllFilterSettingCommandTest()
        {
            ICommand actual;
            actual = target.SelectAllFilterSettingCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for ShirnkCommand
        ///</summary>
        [TestMethod()]
        public void ShirnkCommandTest()
        {
            ICommand actual;
            actual = target.ShirnkCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for DelegateFilterButtonViewModel
        ///</summary>
        [TestMethod()]
        public void DelegateFilterButtonViewModelPatternColorNotNullTest()
        {
            PrivateObject target = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            CCSLogsDisplayViewModel LogsDisplayVM = (CCSLogsDisplayViewModel)target.GetProperty("LogsDisplayVM");
            LogsDisplayVM.PatternColor = new PatternColor<CCSLogRecord>(new Dictionary<int, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>(), new List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>());
            target.Invoke("DelegateFilterButtonViewModel");

        }
        [TestMethod()]
        public void DelegateFilterButtonViewModelPatternColorNullTest()
        {
            PrivateObject target = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM);
            //CCSLogsDisplayViewModel LogsDisplayVM = (CCSLogsDisplayViewModel)target.GetProperty("LogsDisplayVM");
            //LogsDisplayVM.PatternColor = new PatternColor<CCSLogRecord>(new Dictionary<int, KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>(), new List<KeyIndexRecordPair<int, string, int, CCSLogRecord, string>>());
            target.Invoke("DelegateFilterButtonViewModel");

        }

        /// <summary>
        ///A test for StringFilter
        ///</summary>
        [TestMethod()]
        public void StringFilterTest()
        {
            string expected = string.Empty; 
            string actual;
            target.StringFilter = expected;
            actual = target.StringFilter;
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for Error
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void ErrorTest()
        {
            string actual;
            actual = target.Error;
        }
        /// <summary>
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ItemTest()
        {
            string propertyName = string.Empty;
            string actual;
            actual = target[propertyName];
            Assert.AreEqual(String.Empty, actual);
        }
        [TestMethod()]
        public void ItemValidateLogItemNotNullTest()
        {
            string propertyName = "LogItem";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual(String.Empty, actual);
        }
        [TestMethod()]
        public void ItemValidateLogItemNullTest()
        {
            string propertyName = "LogItem";
            string actual;
            target.LogItem = null;
            actual = target[propertyName];
            Assert.AreEqual("Log item must not be empty.", actual);
        }
        [TestMethod()]
        public void ItemValidateStringFilterTest()
        {
            string propertyName = "StringFilter";
            string actual;
            actual = target[propertyName];
            Assert.AreEqual(String.Empty, actual);
        }
    }
}
