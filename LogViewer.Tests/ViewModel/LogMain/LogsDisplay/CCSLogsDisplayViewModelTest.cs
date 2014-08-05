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
using LogViewer.Business;
using System.Windows;
using System.Linq;
using System.IO;
namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for CCSLogsDisplayViewModelTest and is intended
    ///to contain all CCSLogsDisplayViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CCSLogsDisplayViewModelTest
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
        [DeploymentItem(@"FileConfig\DefaultKeywordCountSetting.csv")]
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
        ///A test for CopyCommandCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CopyCommandCLTest()
        {
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime =DateTime.Parse("2013-10-10 10:10:10.000");
            record.Type = "E";
            record.HostName = "";
            record.ThreadId = "1";
            record.Id = "1";
            record.Content = "test copy";
            record.AdditionalInfo = "";
            record.PersonalInfo = "";
            List<CCSLogRecordDisplayViewModel> ccsLog = new List<CCSLogRecordDisplayViewModel>();
            CCSLogRecordDisplayViewModel recordVM = new CCSLogRecordDisplayViewModel(record, null);
            ccsLog.Add(recordVM);
            target.SelectedItems = ccsLog.Cast<object>().ToList();
            target.CopyCommandCL();
            Assert.IsNotNull(Clipboard.GetText());
        }

        /// <summary>
        ///A test for CreateRecordVMFromData
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CreateRecordVMFromDataTest()
        {
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime =DateTime.Parse("2013-10-10 10:10:10.000");
            record.Type = "E";
            record.HostName = "";
            record.ThreadId = "1";
            record.Id = "1";
            record.Content = "test copy";
            record.AdditionalInfo = "";
            record.PersonalInfo = "";
            CCSLogRecordDisplayViewModel expected = new CCSLogRecordDisplayViewModel(record, null); 
            BaseLogRecordDisplayViewModel<CCSLogRecord> actual;
            actual = target.CreateRecordVMFromData(record);
            Assert.AreEqual(expected.Content, actual.Data.Content);
        }

        /// <summary>
        ///A test for HeaderToShow
        ///</summary>
        [TestMethod()]
        public void HeaderToShowTest()
        {
            List<LogDisplay> expected = null;
            List<LogDisplay> actual;
            target.HeaderToShow = expected;
            actual = target.HeaderToShow;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsDisplayAdditionalInfo
        ///</summary>
        [TestMethod()]
        public void IsDisplayAdditionalInfoTest()
        {
            bool actual;
            actual = target.IsDisplayAdditionalInfo;
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for IsDisplayBookmark
        ///</summary>
        [TestMethod()]
        public void IsDisplayBookmarkTest()
        {
            bool actual;
            actual = target.IsDisplayBookmark;
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsDisplayClassName
        ///</summary>
        [TestMethod()]

        public void IsDisplayClassNameTest()
        {
            bool actual;
            actual = target.IsDisplayClassName;
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for IsDisplayComment
        ///</summary>
        [TestMethod()]

        public void IsDisplayCommentTest()
        {
            bool actual;
            actual = target.IsDisplayComment;
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsDisplayContent
        ///</summary>
        [TestMethod()]

        public void IsDisplayContentTest()
        {
            bool actual;
            actual = target.IsDisplayContent;
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsDisplayDate
        ///</summary>
        [TestMethod()]

        public void IsDisplayDateTest()
        {
            bool actual;
            actual = target.IsDisplayDate;
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsDisplayHostName
        ///</summary>
        [TestMethod()]

        public void IsDisplayHostNameTest()
        {
            bool actual;
            actual = target.IsDisplayHostName;
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for IsDisplayID
        ///</summary>
        [TestMethod()]

        public void IsDisplayIDTest()
        {
            bool actual;
            actual = target.IsDisplayID;
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for IsDisplayLine
        ///</summary>
        [TestMethod()]

        public void IsDisplayLineTest()
        {
            bool actual;
            actual = target.IsDisplayLine;
            Assert.IsTrue(actual);
        }

        ///// <summary>
        /////A test for IsDisplayMode
        /////</summary>
        //[TestMethod()]
        //[ExpectedException(typeof(NullReferenceException))]
        //public void IsDisplayModeTest()
        //{
        //    bool actual;
        //    actual = target.IsDisplayMode;
            
        //}

        /// <summary>
        ///A test for IsDisplayPersonalInfo
        ///</summary>
        [TestMethod()]

        public void IsDisplayPersonalInfoTest()
        {
            bool actual;
            actual = target.IsDisplayPersonalInfo;
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for IsDisplayThreadID
        ///</summary>
        [TestMethod()]

        public void IsDisplayThreadIDTest()
        {
            bool actual;
            actual = target.IsDisplayThreadID;
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for IsDisplayTime
        ///</summary>
        [TestMethod()]

        public void IsDisplayTimeTest()
        {
            bool actual;
            actual = target.IsDisplayTime;
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsDisplayType
        ///</summary>
        [TestMethod()]

        public void IsDisplayTypeTest()
        {
            bool actual;
            actual = target.IsDisplayType;
            Assert.IsTrue(actual);
        }
    }
}
