using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Model;
using System.Collections.Generic;
using System.Windows.Input;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.Business;
using System.IO;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for MainViewModelTest and is intended
    ///to contain all MainViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MainViewModelTest
    {
        public static MainViewModel_Accessor targetMainVM;
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
        ///A test for ApplyLogDisplay
        ///</summary>
        [TestMethod()]
        public void ApplyLogDisplayTest()
        { 
            List<List<LogDisplay>> data = new List<List<LogDisplay>>{targetMainVM.CCSMainVM.SettingManager.DisplaySetting, targetMainVM.CXDIMainVM.SettingManager.DisplaySetting};
            targetMainVM.ApplyLogDisplay(data);
        }

        /// <summary>
        ///A test for ApplyLogDisplay
        ///</summary>
        [TestMethod()]
        public void ApplyLogDisplayTestException()
        {
            List<List<LogDisplay>> data = new List<List<LogDisplay>> { targetMainVM.CCSMainVM.SettingManager.DisplaySetting, targetMainVM.CXDIMainVM.SettingManager.DisplaySetting };
            string oldString = ConfigValue.UserCCSLogSettingFile;
            ConfigValue.UserCCSLogSettingFile = "";
            targetMainVM.ApplyLogDisplay(data);
            ConfigValue.UserCCSLogSettingFile = oldString;
        }

        /// <summary>
        ///A test for ApplyLogDisplay
        ///</summary>
        [TestMethod()]
        public void ApplyLogDisplayTestException1()
        {
            List<List<LogDisplay>> data = new List<List<LogDisplay>> { targetMainVM.CCSMainVM.SettingManager.DisplaySetting, targetMainVM.CXDIMainVM.SettingManager.DisplaySetting };
            string oldString = ConfigValue.UserCXDILogSettingFile;
            ConfigValue.UserCXDILogSettingFile = "";
            targetMainVM.ApplyLogDisplay(data);
            ConfigValue.UserCXDILogSettingFile = oldString;
        }

        /// <summary>
        ///A test for ApplyLogDisplay
        ///</summary>
        [TestMethod()]
        public void ApplyLogDisplayTestException2()
        {
            List<List<LogDisplay>> data = new List<List<LogDisplay>> { targetMainVM.CCSMainVM.SettingManager.DisplaySetting, targetMainVM.CXDIMainVM.SettingManager.DisplaySetting };
            string oldString = ConfigValue.UserCCSLogSettingFile;
            string oldString1 = ConfigValue.UserCXDILogSettingFile;
            ConfigValue.UserCCSLogSettingFile = "";
            ConfigValue.UserCXDILogSettingFile = "";
            targetMainVM.ApplyLogDisplay(data);
            ConfigValue.UserCCSLogSettingFile = oldString;
            ConfigValue.UserCXDILogSettingFile = oldString1;
        }

        /// <summary>
        ///A test for CCSShowRecordWithDateTime
        ///</summary>
        [TestMethod()]
        public void CCSShowRecordWithDateTimeTest()
        {
            string date = "2013-12-12";
            string time = "12:12:12";
            targetMainVM.CCSShowRecordWithDateTime(date, time);
        }

        /// <summary>
        ///A test for CXDIShowRecordWithDateTime
        ///</summary>
        [TestMethod()]
        //[DeploymentItem("LogViewer.exe")]
        public void CXDIShowRecordWithDateTimeTest()
        {
            string date = "2013-12-12";
            string time = "12:12:12";
            targetMainVM.CXDIShowRecordWithDateTime(date, time);
        }

        /// <summary>
        ///A test for ClearAllCommandCL
        ///</summary>
        [TestMethod()]
        public void ClearAllCommandCLTest()
        {
            targetMainVM.ClearAllCommandCL();
            Assert.AreEqual(false, targetMainVM.CCSMainVM.IsOnNarrowColorFilter);
            Assert.AreEqual(0, targetMainVM.CCSMainVM.LogAnalyser.PatternAnalyzeBuffer.Count);
        }

        /// <summary>
        ///A test for ClearAnalyzeCommandCL
        ///</summary>
        [TestMethod()]
        public void ClearAnalyzeCommandCLTest()
        { 
            targetMainVM.ClearAnalyzeCommandCL();
            Assert.AreEqual(0, targetMainVM.CCSMainVM.LogAnalyser.PatternAnalyzeBuffer.Count);

        }

        /// <summary>
        ///A test for ClearColorFilterSettingCommandCL
        ///</summary>
        [TestMethod()]
        public void ClearColorFilterSettingCommandCLTest()
        {
            targetMainVM.ClearColorFilterSettingCommandCL();
            Assert.AreEqual(false, targetMainVM.CCSMainVM.IsOnNarrowColorFilter);
        }

        /// <summary>
        ///A test for ExpandCommandCL
        ///</summary>
        [TestMethod()]
        public void ExpandCommandCLTest()
        {
            targetMainVM.ExpandCommandCL();
            Assert.AreEqual(9, targetMainVM.CCSMainVM.LogsDisplayVM.FontOfDataGrid);
            Assert.AreEqual(9, targetMainVM.CXDIMainVM.LogsDisplayVM.FontOfDataGrid);
        }

        /// <summary>
        ///A test for Init
        ///</summary>
        [TestMethod()]
        public void InitTest()
        {
            MainViewModel target = new MainViewModel();
            target.Init();
        }

        /// <summary>
        ///A test for IsEnableButton
        ///</summary>
        [TestMethod()]
        public void IsEnableButtonTest()
        { 
            bool expected = false; 
            bool actual;
            actual = targetMainVM.IsEnableButton();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsEnableButton
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void IsEnableButtonIsNullTest()
        {
            bool expected = false;
            bool actual;
            PrivateObject CCSLogAnalyzer = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM.LogAnalyser);
            CCSLogAnalyzer.SetFieldOrProperty("_allLogRecordsBuffer", null);
            PrivateObject CXDILogAnalyzer = new PrivateObject(((MainViewModel)targetMainVM.Target).CXDIMainVM.LogAnalyser);
            CXDILogAnalyzer.SetFieldOrProperty("_allLogRecordsBuffer", null);
            actual = targetMainVM.IsEnableButton();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsEnableButton
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void IsEnableButtonHaveLogTest()
        {
            bool expected = true;
            bool actual;
            PrivateObject CCSLogAnalyzer = new PrivateObject(((MainViewModel)targetMainVM.Target).CCSMainVM.LogAnalyser);
            CCSLogAnalyzer.SetFieldOrProperty("_allLogRecordsBuffer", new List<CCSLogRecord> {new CCSLogRecord{Id="1"} });
            PrivateObject CXDILogAnalyzer = new PrivateObject(((MainViewModel)targetMainVM.Target).CXDIMainVM.LogAnalyser);
            CXDILogAnalyzer.SetFieldOrProperty("_allLogRecordsBuffer",  new List<CXDILogRecord> {new CXDILogRecord{Line=1}});
            actual = targetMainVM.IsEnableButton();
            Assert.AreEqual(expected, actual);
        }

        ///// <summary>
        /////A test for LoadConfig
        /////</summary>
        [TestMethod()]
        public void LoadConfigTest()
        {
            targetMainVM.LoadConfig();
            Assert.AreEqual(13, targetMainVM.CCSMainVM.SettingManager.DisplaySetting.Count);
            Assert.AreEqual(7, targetMainVM.CXDIMainVM.SettingManager.DisplaySetting.Count);
        }

        /// <summary>
        ///A test for ResetBookmarkCommandCL
        ///</summary>
        [TestMethod()]
        public void ResetBookmarkCommandCLTest()
        {
            targetMainVM.ResetBookmarkCommandCL();
            Assert.AreEqual(0, targetMainVM.CCSMainVM.LogAnalyser.BookmarkBuffer.Count);
            Assert.AreEqual(0, targetMainVM.CXDIMainVM.LogAnalyser.BookmarkBuffer.Count);
        }

        /// <summary>
        ///A test for ResetCommentCommandCL
        ///</summary>
        [TestMethod()]
        public void ResetCommentCommandCLTest()
        {  
            targetMainVM.ResetCommentCommandCL();
            Assert.AreEqual(0, targetMainVM.CCSMainVM.LogAnalyser.Comments.Count);
            Assert.AreEqual(0, targetMainVM.CXDIMainVM.LogAnalyser.Comments.Count);
        }

        /// <summary>
        ///A test for ResetFilterCommandCL
        ///</summary>
        [TestMethod()]
        public void ResetFilterCommandCLTest()
        {
            targetMainVM.ResetFilterCommandCL();
            int actualCCS = targetMainVM.CCSMainVM.LogsDisplayVM.FilterSetting.FindAll(x => x.Enabled == true).Count;
            int actualCXDI = targetMainVM.CXDIMainVM.LogsDisplayVM.FilterSetting.FindAll(x => x.Enabled == true).Count;
            Assert.AreEqual(0, actualCCS);
            Assert.AreEqual(0, actualCXDI);
        }

        /// <summary>
        ///A test for SearchCCS
        ///</summary>
        [TestMethod()]
        public void SearchCCSTest()
        {
            SearchItem searchCondition = new SearchItem { StringValue = String.Empty, LogItem = "Content" };
            IList<CCSLogRecord> actual;
            actual = targetMainVM.SearchCCS(searchCondition);
            Assert.AreEqual(0 , actual.Count);
        }

        /// <summary>
        ///A test for SearchCXDI
        ///</summary>
        [TestMethod()]
        public void SearchCXDITest()
        {
            SearchItem searchCondition = new SearchItem { StringValue = String.Empty, LogItem = "Message" };
            IList<CXDILogRecord> actual;
            actual = targetMainVM.SearchCXDI(searchCondition);
            Assert.AreEqual(0, actual.Count);
        }

        /// <summary>
        ///A test for SearchKeywordCommandCL
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void SearchKeywordCommandCLTest()
        {
            targetMainVM.SearchKeywordCommandCL();
            targetMainVM._searchVM.CloseDialog();
        }

        /// <summary>
        ///A test for SetLogParameterCommandCL
        ///</summary>
        //[TestMethod()]
        //public void SetLogParameterCommandCLTest()
        //{
        //    //targetMainVM.SetLogParameterCommandCL();
        //}

        /// <summary>
        ///A test for ShowCCSRecord
        ///</summary>
        [TestMethod()]
        public void ShowCCSRecordTest()
        { 
            CCSLogRecord record = null;
            targetMainVM.ShowCCSRecord(record);
            //Assert.IsNull(targetMainVM.CCSMainVM.LogsDisplayVM.RecordForJump);
        }

        /// <summary>
        ///A test for ShowCXDIRecord
        ///</summary>
        [TestMethod()]
        public void ShowCXDIRecordTest()
        {
            CXDILogRecord record = null; 
            targetMainVM.ShowCXDIRecord(record);
            //Assert.IsNull(targetMainVM.CXDIMainVM.LogsDisplayVM.RecordForJump);
        }

        /// <summary>
        ///A test for ShrinkCommandCL
        ///</summary>
        [TestMethod()]
        public void ShrinkCommandCLTest()
        {
            targetMainVM.ShrinkCommandCL();
            Assert.AreEqual(7, targetMainVM.CCSMainVM.LogsDisplayVM.FontOfDataGrid);
            Assert.AreEqual(7, targetMainVM.CXDIMainVM.LogsDisplayVM.FontOfDataGrid);
        }

        /// <summary>
        ///A test for ClearAllCommand
        ///</summary>
        [TestMethod()]
        public void ClearAllCommandTest()
        {
            var actual= targetMainVM.ClearAllCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));

        }

        /// <summary>
        ///A test for ClearAnalyzeCommand
        ///</summary>
        [TestMethod()]
        public void ClearAnalyzeCommandTest()
        {
            var actual = targetMainVM.ClearAnalyzeCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for ClearColorFilterSettingCommand
        ///</summary>
        [TestMethod()]
        public void ClearColorFilterSettingCommandTest()
        {
            var actual = targetMainVM.ClearColorFilterSettingCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for ExpandCommand
        ///</summary>
        [TestMethod()]
        public void ExpandCommandTest()
        {
            var actual = targetMainVM.ExpandCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for IsOnFollowModeCCS
        ///</summary>
        [TestMethod()]
        public void IsOnFollowModeCCSTest()
        {
            bool expected = false; 
            bool actual;
            targetMainVM.IsOnFollowModeCCS = expected;
            actual = targetMainVM.IsOnFollowModeCCS;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsOnFollowModeCXDI
        ///</summary>
        [TestMethod()]
        public void IsOnFollowModeCXDITest()
        {
            bool expected = false;
            bool actual;
            targetMainVM.IsOnFollowModeCXDI = expected;
            actual = targetMainVM.IsOnFollowModeCXDI;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ResetBookmarkCommand
        ///</summary>
        [TestMethod()]
        public void ResetBookmarkCommandTest()
        {
            var actual= targetMainVM.ResetBookmarkCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for ResetCommentCommand
        ///</summary>
        [TestMethod()]
        public void ResetCommentCommandTest()
        {
            var actual = targetMainVM.ResetCommentCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for ResetFilterCommand
        ///</summary>
        [TestMethod()]
        public void ResetFilterCommandTest()
        {
            var actual = targetMainVM.ResetFilterCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for SearchKeywordCommand
        ///</summary>
        [TestMethod()]
        public void SearchKeywordCommandTest()
        {
            var actual = targetMainVM.SearchKeywordCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for SearchVM
        ///</summary>
        [TestMethod()]
        public void SearchVMTest()
        {
            var actual = targetMainVM.SearchVM;
            Assert.IsInstanceOfType(actual, typeof(SearchKeywordViewModel));
        }

        /// <summary>
        ///A test for SetLogParameterCommand
        ///</summary>
        [TestMethod()]
        public void SetLogParameterCommandTest()
        {
            var actual = targetMainVM.SetLogParameterCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for ShrinkCommand
        ///</summary>
        [TestMethod()]
        public void ShrinkCommandTest()
        {
            var actual = targetMainVM.ShrinkCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for RecentFileAction
        ///</summary>
        [TestMethod()]
        public void GetRecentFileActionTest()
        {
            RecentFileAction action = new RecentFileAction("test.csv", new Action<string>((str) => { }), new Action<string>((str) => { }));
            targetMainVM.RecentFileAction = action;
            var actual = targetMainVM.RecentFileAction;
            Assert.AreEqual("test.csv", actual.FilePath);
        }
        [TestMethod()]
        public void GetRecentFileActionNullTest()
        {            
            targetMainVM.RecentFileAction = null;
            var actual = targetMainVM.RecentFileAction;
            Assert.IsNull(actual.FilePath);
        }

        /// <summary>
        ///A test for RecentFile
        ///</summary>
        [TestMethod()]
        public void GetSetRecentFileTest()
        {
            targetMainVM.RecentFile = "test";
            var actual = targetMainVM.RecentFile;
            Assert.AreEqual("test", actual);
        }

        /// <summary>
        ///A test for RecentFile
        ///</summary>
        [TestMethod()]
        public void RecentFileChangeFlagIsFalseTest()
        {
            targetMainVM.RecentFileChange("test.csv", false);
            var actual = targetMainVM.RecentFile;
            Assert.AreEqual("test.csv", actual);
        }
        [TestMethod()]
        public void RecentFileChangeFlagIsTrueTest()
        {
            targetMainVM.RecentFileChange("test.csv", false);
            targetMainVM.RecentFileChange("test.csv", true);
            var actual = targetMainVM.RecentFileAction;
            Assert.AreEqual("test.csv", actual.FilePath);
        }
    }
}
