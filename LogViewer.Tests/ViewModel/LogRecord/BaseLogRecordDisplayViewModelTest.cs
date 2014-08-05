using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Model;
using System.Windows.Input;
using LogViewer.Business;
using System.Collections.Generic;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.IO;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for BaseLogRecordDisplayViewModelTest and is intended
    ///to contain all BaseLogRecordDisplayViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BaseLogRecordDisplayViewModelTest
    {

        public static MainViewModel_Accessor targetMainVM;
        public static PrivateObject target;
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
        //[DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void MyTestInitialize()
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
            //target = new PrivateObject((BaseLogRecordDisplayViewModel<CCSLogRecord>)targetMainVM.CCSMainVM.LogsDisplayVM.BaseRecordVMList[0]);
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
        ///A test for BookmarkCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void BookmarkCLAddTest()
        {
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
            target = new PrivateObject((BaseLogRecordDisplayViewModel<CCSLogRecord>)targetMainVM.CCSMainVM.LogsDisplayVM.BaseRecordVMList[0]);
            target.Invoke("BookmarkCL");
            Assert.AreNotEqual(0, targetMainVM.CCSMainVM.AnalyzeAreaVM.LogBookmarkTabVM.LogRecordList.Count);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void BookmarkCLRemoveTest()
        {
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
            //target = new PrivateObject((BaseLogRecordDisplayViewModel<CCSLogRecord>)targetMainVM.CCSMainVM.LogsDisplayVM.BaseRecordVMList[0]);
            //target.Invoke("BookmarkCL");
            //target.Invoke("BookmarkCL");
            BaseLogRecordDisplayViewModel_Accessor<CCSLogRecord> target = new BaseLogRecordDisplayViewModel_Accessor<CCSLogRecord>(new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM.BaseRecordVMList[0]));
            target.BookmarkCL();
            target.IsBookmarked = true;
            target.BookmarkCL();
            target.IsBookmarked = false;
            Assert.AreEqual(2, targetMainVM.CCSMainVM.AnalyzeAreaVM.LogBookmarkTabVM.LogRecordList.Count);
        }
        /// <summary>
        ///A test for IsViewModelOf
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void IsViewModelOfTest()
        {
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
            target = new PrivateObject((BaseLogRecordDisplayViewModel<CCSLogRecord>)targetMainVM.CCSMainVM.LogsDisplayVM.BaseRecordVMList[0]);
            CCSLogRecord record = targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer[0];
            bool actual = (bool)target.Invoke("IsViewModelOf", new object[]{record});
            Assert.AreEqual(true, actual);
        }

        /// <summary>
        ///A test for BookmarkCommand
        ///</summary>       
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void BookmarkCommandTest()
        {
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
            target = new PrivateObject((BaseLogRecordDisplayViewModel<CCSLogRecord>)targetMainVM.CCSMainVM.LogsDisplayVM.BaseRecordVMList[0]);
            var actual = target.GetFieldOrProperty("BookmarkCommand");
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for Comment
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void CommentTest()
        {
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
            target = new PrivateObject((BaseLogRecordDisplayViewModel<CCSLogRecord>)targetMainVM.CCSMainVM.LogsDisplayVM.BaseRecordVMList[0]);
            var actual = target.GetFieldOrProperty("Comment");
            Assert.AreEqual(String.Empty, actual);
        }

        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void CommentNotEmptyTest()
        {
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
            BaseLogRecordDisplayViewModel_Accessor<CCSLogRecord> target = new BaseLogRecordDisplayViewModel_Accessor<CCSLogRecord>(new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM.BaseRecordVMList[0]));
            target.Comment = "test";
            string actual = target.Comment;
            Assert.AreEqual("test", actual);
        }

        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void CommentModifyTest()
        {
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
            BaseLogRecordDisplayViewModel_Accessor<CCSLogRecord> target = new BaseLogRecordDisplayViewModel_Accessor<CCSLogRecord>(new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM.BaseRecordVMList[0]));
            target.Comment = "test";
            target.Comment = "test modify";
            string actual = target.Comment;
            Assert.AreEqual("test modify", actual);
        }

        /// <summary>
        ///A test for FilterSetting
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void FilterSettingTest()
        {
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
            BaseLogRecordDisplayViewModel_Accessor<CCSLogRecord> target = new BaseLogRecordDisplayViewModel_Accessor<CCSLogRecord>(new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM.BaseRecordVMList[0]));
            var actual = target.FilterSetting;
            Assert.AreEqual(0, actual.Count);
        }

        /// <summary>
        ///A test for IsBookmarked
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void IsBookmarkedTest()
        {
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
            BaseLogRecordDisplayViewModel_Accessor<CCSLogRecord> target = new BaseLogRecordDisplayViewModel_Accessor<CCSLogRecord>(new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM.BaseRecordVMList[0]));
            var actual = target.IsBookmarked;
            Assert.IsFalse(actual);
        }


        /// <summary>
        ///A test for PatternColor
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCS20131002.txt")]
        public void PatternColorTest()
        {
            string filerLog = @"CCS20131002.txt";
            string dir = Path.GetFullPath(filerLog);
            targetMainVM.CCSMainVM.LogAnalyser.LoadLogFile(dir, false);
            targetMainVM.CCSMainVM.LogAnalyser.Filter(null);
            targetMainVM.CCSMainVM.LogsDisplayVM.LoadData(targetMainVM.CCSMainVM.LogAnalyser.FilteredLogRecordsBuffer, new List<FilterItemSetting>());
            //BaseLogRecordDisplayViewModel_Accessor<CCSLogRecord> target = new BaseLogRecordDisplayViewModel_Accessor<CCSLogRecord>(new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM.BaseRecordVMList[0]));
            //CCSLogRecordDisplayViewModel_Accessor target = new CCSLogRecordDisplayViewModel_Accessor(new PrivateObject(targetMainVM.CCSMainVM.LogsDisplayVM.BaseRecordVMList[0]));
            var actual = targetMainVM.CCSMainVM.LogsDisplayVM.BaseRecordVMList[0].PatternColor;
            Assert.IsNull(actual);
        }
    }
}
