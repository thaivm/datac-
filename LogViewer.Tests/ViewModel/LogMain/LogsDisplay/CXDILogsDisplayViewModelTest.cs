using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Model;
using System.Collections.Generic;
using LogViewer.Business.FileSetting;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.IO;
using LogViewer.Business;
using System.Windows;
using System.Linq;
namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for CXDILogsDisplayViewModelTest and is intended
    ///to contain all CXDILogsDisplayViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CXDILogsDisplayViewModelTest
    {

        public CXDILogsDisplayViewModel_Accessor target;
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
        public void MyTestInitialize()
        {
            if (!ServiceLocator.services.ContainsKey(typeof(IDialogService)))
            {
                ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
                ServiceLocator.RegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
                ServiceLocator.Register<IOpenFileDialog, LogViewer.Service.FrameworkDialogs.OpenFile.OpenFileDialogViewModel>();
                ServiceLocator.Register<ISaveFileDialog, LogViewer.Service.FrameworkDialogs.SaveFile.SaveFileDialogViewModel>();
            }
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
        ///A test for CopyCommandCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\DefaultCXDILogSetting.csv")]
        public void CopyCommandCLTest()
        {
            Action<CXDILogRecord> onAddBookmarkEvent = (CCSLog) => { };
            Action<CXDILogRecord> onRemoveBookmarkEvent = (CCSLog) => { };
            Action<CXDILogRecord> onUpdateRecordFileName = (CCSLog) => { };
            Action<string, string> onFollowOtherLogEvent = (str1, str2) => { };
            Action<CXDILogRecord, AnalyzedPatternResultItem<CXDILogRecord>> onShowPatternColoringRecord = (CCSLog, AnalyzePattern) => { };
            string oldDefaultCCSLogSetting = ConfigValue.DefaultCCSLogSettingFile;
            string DefaultCCSLogSetting = @"DefaultCXDILogSetting.csv";
            ConfigValue.DefaultCCSLogSettingFile = Path.GetFullPath(DefaultCCSLogSetting);
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            ConfigValue.DefaultCCSLogSettingFile = oldDefaultCCSLogSetting;


            List<LogDisplay> logDisplay = new List<LogDisplay>(targetMainVM.CXDIMainVM.SettingManager.DisplaySetting);
            CXDISettingManager SettingManger = new CXDISettingManager();
            CXDILogsDisplayViewModel ccsMV = new CXDILogsDisplayViewModel(onAddBookmarkEvent, onRemoveBookmarkEvent, onUpdateRecordFileName, onFollowOtherLogEvent, onShowPatternColoringRecord, logDisplay, SettingManger, null);
            PrivateObject param = new PrivateObject(ccsMV);
            target = new CXDILogsDisplayViewModel_Accessor(param);
            CXDILogRecord record = new CXDILogRecord();
            record.DateTime =DateTime.Parse( "2013-10-10 10:10:10.000");
            record.Line = 1;
            record.Message = "test copy";
            record.Module = "E";

            List<CXDILogRecordDisplayViewModel> ccsLog = new List<CXDILogRecordDisplayViewModel>();
            CXDILogRecordDisplayViewModel recordVM = new CXDILogRecordDisplayViewModel(record, null);
            ccsLog.Add(recordVM);
            target.SelectedItems = ccsLog.Cast<object>().ToList();
            target.CopyCommandCL();
            Assert.IsNotNull(Clipboard.GetText());
        }

        /// <summary>
        ///A test for CreateRecordVMFromData
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\DefaultCXDILogSetting.csv")]
        public void CreateRecordVMFromDataTest()
        {
            Action<CXDILogRecord> onAddBookmarkEvent = (CCSLog) => { };
            Action<CXDILogRecord> onRemoveBookmarkEvent = (CCSLog) => { };
            Action<CXDILogRecord> onUpdateRecordFileName = (CCSLog) => { };
            Action<string, string> onFollowOtherLogEvent = (str1, str2) => { };
            Action<CXDILogRecord, AnalyzedPatternResultItem<CXDILogRecord>> onShowPatternColoringRecord = (CCSLog, AnalyzePattern) => { };
            string oldDefaultCCSLogSetting = ConfigValue.DefaultCCSLogSettingFile;
            string DefaultCCSLogSetting = @"DefaultCXDILogSetting.csv";
            ConfigValue.DefaultCCSLogSettingFile = Path.GetFullPath(DefaultCCSLogSetting);
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            ConfigValue.DefaultCCSLogSettingFile = oldDefaultCCSLogSetting;


            List<LogDisplay> logDisplay = new List<LogDisplay>(targetMainVM.CXDIMainVM.SettingManager.DisplaySetting);
            CXDISettingManager SettingManger = new CXDISettingManager();
            CXDILogsDisplayViewModel ccsMV = new CXDILogsDisplayViewModel(onAddBookmarkEvent, onRemoveBookmarkEvent, onUpdateRecordFileName, onFollowOtherLogEvent, onShowPatternColoringRecord, logDisplay, SettingManger, null);
            PrivateObject param = new PrivateObject(ccsMV);
            target = new CXDILogsDisplayViewModel_Accessor(param);
            CXDILogRecord record = new CXDILogRecord();
            record.DateTime = DateTime.Parse("2013-10-10 10:10:10.000");
            record.Line = 1;
            record.Message = "test copy";
            record.Module = "E";
            CXDILogRecordDisplayViewModel expected = new CXDILogRecordDisplayViewModel(record, null);
            BaseLogRecordDisplayViewModel<CXDILogRecord> actual;
            actual = target.CreateRecordVMFromData(record);
            Assert.AreEqual(expected.Message, actual.Data.Message);
        }

        /// <summary>
        ///A test for HeaderToShow
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\DefaultCXDILogSetting.csv")]
        public void HeaderToShowTest()
        {
            Action<CXDILogRecord> onAddBookmarkEvent = (CCSLog) => { };
            Action<CXDILogRecord> onRemoveBookmarkEvent = (CCSLog) => { };
            Action<CXDILogRecord> onUpdateRecordFileName = (CCSLog) => { };
            Action<string, string> onFollowOtherLogEvent = (str1, str2) => { };
            Action<CXDILogRecord, AnalyzedPatternResultItem<CXDILogRecord>> onShowPatternColoringRecord = (CCSLog, AnalyzePattern) => { };
            string oldDefaultCCSLogSetting = ConfigValue.DefaultCCSLogSettingFile;
            string DefaultCCSLogSetting = @"DefaultCXDILogSetting.csv";
            ConfigValue.DefaultCCSLogSettingFile = Path.GetFullPath(DefaultCCSLogSetting);
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            ConfigValue.DefaultCCSLogSettingFile = oldDefaultCCSLogSetting;


            List<LogDisplay> logDisplay = new List<LogDisplay>(targetMainVM.CXDIMainVM.SettingManager.DisplaySetting);
            CXDISettingManager SettingManger = new CXDISettingManager();
            CXDILogsDisplayViewModel ccsMV = new CXDILogsDisplayViewModel(onAddBookmarkEvent, onRemoveBookmarkEvent, onUpdateRecordFileName, onFollowOtherLogEvent, onShowPatternColoringRecord, logDisplay, SettingManger, null);
            PrivateObject param = new PrivateObject(ccsMV);
            target = new CXDILogsDisplayViewModel_Accessor(param);
            List<LogDisplay> expected = null; 
            List<LogDisplay> actual;
            target.HeaderToShow = expected;
            actual = target.HeaderToShow;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsDisplayBookmark
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\DefaultCXDILogSetting.csv")]
        public void IsDisplayBookmarkTest()
        {
            Action<CXDILogRecord> onAddBookmarkEvent = (CCSLog) => { };
            Action<CXDILogRecord> onRemoveBookmarkEvent = (CCSLog) => { };
            Action<CXDILogRecord> onUpdateRecordFileName = (CCSLog) => { };
            Action<string, string> onFollowOtherLogEvent = (str1, str2) => { };
            Action<CXDILogRecord, AnalyzedPatternResultItem<CXDILogRecord>> onShowPatternColoringRecord = (CCSLog, AnalyzePattern) => { };
            string oldDefaultCCSLogSetting = ConfigValue.DefaultCCSLogSettingFile;
            string DefaultCCSLogSetting = @"DefaultCXDILogSetting.csv";
            ConfigValue.DefaultCCSLogSettingFile = Path.GetFullPath(DefaultCCSLogSetting);
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            ConfigValue.DefaultCCSLogSettingFile = oldDefaultCCSLogSetting;


            List<LogDisplay> logDisplay = new List<LogDisplay>(targetMainVM.CXDIMainVM.SettingManager.DisplaySetting);
            CXDISettingManager SettingManger = new CXDISettingManager();
            CXDILogsDisplayViewModel ccsMV = new CXDILogsDisplayViewModel(onAddBookmarkEvent, onRemoveBookmarkEvent, onUpdateRecordFileName, onFollowOtherLogEvent, onShowPatternColoringRecord, logDisplay, SettingManger, null);
            PrivateObject param = new PrivateObject(ccsMV);
            target = new CXDILogsDisplayViewModel_Accessor(param);
            bool actual;
            actual = target.IsDisplayBookmark;
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsDisplayComment
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\DefaultCXDILogSetting.csv")]
        public void IsDisplayCommentTest()
        {
            Action<CXDILogRecord> onAddBookmarkEvent = (CCSLog) => { };
            Action<CXDILogRecord> onRemoveBookmarkEvent = (CCSLog) => { };
            Action<CXDILogRecord> onUpdateRecordFileName = (CCSLog) => { };
            Action<string, string> onFollowOtherLogEvent = (str1, str2) => { };
            Action<CXDILogRecord, AnalyzedPatternResultItem<CXDILogRecord>> onShowPatternColoringRecord = (CCSLog, AnalyzePattern) => { };
            string oldDefaultCCSLogSetting = ConfigValue.DefaultCCSLogSettingFile;
            string DefaultCCSLogSetting = @"DefaultCXDILogSetting.csv";
            ConfigValue.DefaultCCSLogSettingFile = Path.GetFullPath(DefaultCCSLogSetting);
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            ConfigValue.DefaultCCSLogSettingFile = oldDefaultCCSLogSetting;


            List<LogDisplay> logDisplay = new List<LogDisplay>(targetMainVM.CXDIMainVM.SettingManager.DisplaySetting);
            CXDISettingManager SettingManger = new CXDISettingManager();
            CXDILogsDisplayViewModel ccsMV = new CXDILogsDisplayViewModel(onAddBookmarkEvent, onRemoveBookmarkEvent, onUpdateRecordFileName, onFollowOtherLogEvent, onShowPatternColoringRecord, logDisplay, SettingManger, null);
            PrivateObject param = new PrivateObject(ccsMV);
            target = new CXDILogsDisplayViewModel_Accessor(param);
            bool actual;
            actual = target.IsDisplayComment;
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsDisplayDate
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\DefaultCXDILogSetting.csv")]
        public void IsDisplayDateTest()
        {
            Action<CXDILogRecord> onAddBookmarkEvent = (CCSLog) => { };
            Action<CXDILogRecord> onRemoveBookmarkEvent = (CCSLog) => { };
            Action<CXDILogRecord> onUpdateRecordFileName = (CCSLog) => { };
            Action<string, string> onFollowOtherLogEvent = (str1, str2) => { };
            Action<CXDILogRecord, AnalyzedPatternResultItem<CXDILogRecord>> onShowPatternColoringRecord = (CCSLog, AnalyzePattern) => { };
            string oldDefaultCCSLogSetting = ConfigValue.DefaultCCSLogSettingFile;
            string DefaultCCSLogSetting = @"DefaultCXDILogSetting.csv";
            ConfigValue.DefaultCCSLogSettingFile = Path.GetFullPath(DefaultCCSLogSetting);
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            ConfigValue.DefaultCCSLogSettingFile = oldDefaultCCSLogSetting;


            List<LogDisplay> logDisplay = new List<LogDisplay>(targetMainVM.CXDIMainVM.SettingManager.DisplaySetting);
            CXDISettingManager SettingManger = new CXDISettingManager();
            CXDILogsDisplayViewModel ccsMV = new CXDILogsDisplayViewModel(onAddBookmarkEvent, onRemoveBookmarkEvent, onUpdateRecordFileName, onFollowOtherLogEvent, onShowPatternColoringRecord, logDisplay, SettingManger, null);
            PrivateObject param = new PrivateObject(ccsMV);
            target = new CXDILogsDisplayViewModel_Accessor(param);
            bool actual;
            actual = target.IsDisplayDate;
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsDisplayLine
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\DefaultCXDILogSetting.csv")]
        public void IsDisplayLineTest()
        {
            Action<CXDILogRecord> onAddBookmarkEvent = (CCSLog) => { };
            Action<CXDILogRecord> onRemoveBookmarkEvent = (CCSLog) => { };
            Action<CXDILogRecord> onUpdateRecordFileName = (CCSLog) => { };
            Action<string, string> onFollowOtherLogEvent = (str1, str2) => { };
            Action<CXDILogRecord, AnalyzedPatternResultItem<CXDILogRecord>> onShowPatternColoringRecord = (CCSLog, AnalyzePattern) => { };
            string oldDefaultCCSLogSetting = ConfigValue.DefaultCCSLogSettingFile;
            string DefaultCCSLogSetting = @"DefaultCXDILogSetting.csv";
            ConfigValue.DefaultCCSLogSettingFile = Path.GetFullPath(DefaultCCSLogSetting);
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            ConfigValue.DefaultCCSLogSettingFile = oldDefaultCCSLogSetting;


            List<LogDisplay> logDisplay = new List<LogDisplay>(targetMainVM.CXDIMainVM.SettingManager.DisplaySetting);
            CXDISettingManager SettingManger = new CXDISettingManager();
            CXDILogsDisplayViewModel ccsMV = new CXDILogsDisplayViewModel(onAddBookmarkEvent, onRemoveBookmarkEvent, onUpdateRecordFileName, onFollowOtherLogEvent, onShowPatternColoringRecord, logDisplay, SettingManger, null);
            PrivateObject param = new PrivateObject(ccsMV);
            target = new CXDILogsDisplayViewModel_Accessor(param);
            bool actual;
            actual = target.IsDisplayLine;
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsDisplayMessage
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\DefaultCXDILogSetting.csv")]
        public void IsDisplayMessageTest()
        {
            Action<CXDILogRecord> onAddBookmarkEvent = (CCSLog) => { };
            Action<CXDILogRecord> onRemoveBookmarkEvent = (CCSLog) => { };
            Action<CXDILogRecord> onUpdateRecordFileName = (CCSLog) => { };
            Action<string, string> onFollowOtherLogEvent = (str1, str2) => { };
            Action<CXDILogRecord, AnalyzedPatternResultItem<CXDILogRecord>> onShowPatternColoringRecord = (CCSLog, AnalyzePattern) => { };
            string oldDefaultCCSLogSetting = ConfigValue.DefaultCCSLogSettingFile;
            string DefaultCCSLogSetting = @"DefaultCXDILogSetting.csv";
            ConfigValue.DefaultCCSLogSettingFile = Path.GetFullPath(DefaultCCSLogSetting);
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            ConfigValue.DefaultCCSLogSettingFile = oldDefaultCCSLogSetting;


            List<LogDisplay> logDisplay = new List<LogDisplay>(targetMainVM.CXDIMainVM.SettingManager.DisplaySetting);
            CXDISettingManager SettingManger = new CXDISettingManager();
            CXDILogsDisplayViewModel ccsMV = new CXDILogsDisplayViewModel(onAddBookmarkEvent, onRemoveBookmarkEvent, onUpdateRecordFileName, onFollowOtherLogEvent, onShowPatternColoringRecord, logDisplay, SettingManger, null);
            PrivateObject param = new PrivateObject(ccsMV);
            target = new CXDILogsDisplayViewModel_Accessor(param);
            bool actual;
            actual = target.IsDisplayMessage;
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsDisplayModule
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\DefaultCXDILogSetting.csv")]
        public void IsDisplayModuleTest()
        {
            Action<CXDILogRecord> onAddBookmarkEvent = (CCSLog) => { };
            Action<CXDILogRecord> onRemoveBookmarkEvent = (CCSLog) => { };
            Action<CXDILogRecord> onUpdateRecordFileName = (CCSLog) => { };
            Action<string, string> onFollowOtherLogEvent = (str1, str2) => { };
            Action<CXDILogRecord, AnalyzedPatternResultItem<CXDILogRecord>> onShowPatternColoringRecord = (CCSLog, AnalyzePattern) => { };
            string oldDefaultCCSLogSetting = ConfigValue.DefaultCCSLogSettingFile;
            string DefaultCCSLogSetting = @"DefaultCXDILogSetting.csv";
            ConfigValue.DefaultCCSLogSettingFile = Path.GetFullPath(DefaultCCSLogSetting);
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            ConfigValue.DefaultCCSLogSettingFile = oldDefaultCCSLogSetting;


            List<LogDisplay> logDisplay = new List<LogDisplay>(targetMainVM.CXDIMainVM.SettingManager.DisplaySetting);
            CXDISettingManager SettingManger = new CXDISettingManager();
            CXDILogsDisplayViewModel ccsMV = new CXDILogsDisplayViewModel(onAddBookmarkEvent, onRemoveBookmarkEvent, onUpdateRecordFileName, onFollowOtherLogEvent, onShowPatternColoringRecord, logDisplay, SettingManger, null);
            PrivateObject param = new PrivateObject(ccsMV);
            target = new CXDILogsDisplayViewModel_Accessor(param);
            bool actual;
            actual = target.IsDisplayModule;
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for IsDisplayTime
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\DefaultCXDILogSetting.csv")]
        public void IsDisplayTimeTest()
        {
            Action<CXDILogRecord> onAddBookmarkEvent = (CCSLog) => { };
            Action<CXDILogRecord> onRemoveBookmarkEvent = (CCSLog) => { };
            Action<CXDILogRecord> onUpdateRecordFileName = (CCSLog) => { };
            Action<string, string> onFollowOtherLogEvent = (str1, str2) => { };
            Action<CXDILogRecord, AnalyzedPatternResultItem<CXDILogRecord>> onShowPatternColoringRecord = (CCSLog, AnalyzePattern) => { };
            string oldDefaultCCSLogSetting = ConfigValue.DefaultCCSLogSettingFile;
            string DefaultCCSLogSetting = @"DefaultCXDILogSetting.csv";
            ConfigValue.DefaultCCSLogSettingFile = Path.GetFullPath(DefaultCCSLogSetting);
            MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            ConfigValue.DefaultCCSLogSettingFile = oldDefaultCCSLogSetting;


            List<LogDisplay> logDisplay = new List<LogDisplay>(targetMainVM.CXDIMainVM.SettingManager.DisplaySetting);
            CXDISettingManager SettingManger = new CXDISettingManager();
            CXDILogsDisplayViewModel ccsMV = new CXDILogsDisplayViewModel(onAddBookmarkEvent, onRemoveBookmarkEvent, onUpdateRecordFileName, onFollowOtherLogEvent, onShowPatternColoringRecord, logDisplay, SettingManger, null);
            PrivateObject param = new PrivateObject(ccsMV);
            target = new CXDILogsDisplayViewModel_Accessor(param);
            bool actual;
            actual = target.IsDisplayTime;
            Assert.IsTrue(actual);
        }
    }
}
