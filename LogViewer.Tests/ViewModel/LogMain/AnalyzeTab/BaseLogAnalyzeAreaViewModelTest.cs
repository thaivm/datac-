using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Model;
using LogViewer.Service;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.Linq;
using System.Collections.Generic;
namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for BaseLogAnalyzeAreaViewModelTest and is intended
    ///to contain all BaseLogAnalyzeAreaViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BaseLogAnalyzeAreaViewModelTest
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
            target = new PrivateObject(((CCSAnalyzeAreaViewModel)targetMainVM.CCSMainVM.AnalyzeAreaVM));
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
            CCSLogRecord data = new CCSLogRecord();
            data.Line = 1;
            target.Invoke("AddBookmark", new object[] { data });
            LogBookmarkTabViewModel<CCSLogRecord> LogBookmarkTabVM = (LogBookmarkTabViewModel<CCSLogRecord>)target.GetFieldOrProperty("LogBookmarkTabVM");
            List<CCSLogRecord> logRecord = new List<CCSLogRecord>(LogBookmarkTabVM.LogRecordList);
            Assert.AreNotEqual(0, logRecord.FindAll(x => x.Line == data.Line).Count);
        }

        /// <summary>
        ///A test for RemoveBookmark
        ///</summary>
        [TestMethod()]
        public void RemoveBookmarkTest()
        {
            CCSLogRecord data = new CCSLogRecord();
            data.Line = 1;
            CCSLogRecord data1 = new CCSLogRecord();
            data1.Line = 2;
            target.Invoke("AddBookmark", new object[] { data });
            target.Invoke("AddBookmark", new object[] { data1 });
            target.Invoke("RemoveBookmark", new object[] { data });
            LogBookmarkTabViewModel<CCSLogRecord> LogBookmarkTabVM = (LogBookmarkTabViewModel<CCSLogRecord>)target.GetFieldOrProperty("LogBookmarkTabVM");
            List<CCSLogRecord> logRecord = new List<CCSLogRecord>(LogBookmarkTabVM.LogRecordList);
            Assert.AreEqual(0, logRecord.FindAll(x => x.Line == data.Line).Count);
            Assert.AreNotEqual(0, logRecord.FindAll(x => x.Line == data1.Line).Count);
        }

        /// <summary>
        ///A test for CountKeywordTabVM
        ///</summary>
        [TestMethod()]
        public void CountKeywordTabVMTest()
        {
            CountKeywordTabViewModel actual = (CountKeywordTabViewModel)target.GetFieldOrProperty("CountKeywordTabVM");
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for LogBookmarkTabVM
        ///</summary>
        [TestMethod()]
        public void LogBookmarkTabVMTest()
        {
            LogBookmarkTabViewModel<CCSLogRecord> actual = (LogBookmarkTabViewModel<CCSLogRecord>)target.GetFieldOrProperty("LogBookmarkTabVM");
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for LogPatternTabVM
        ///</summary>
        [TestMethod()]
        public void LogPatternTabVMTest()
        {
            PatternTabViewModel<CCSLogRecord> actual = (PatternTabViewModel<CCSLogRecord>)target.GetFieldOrProperty("LogPatternTabVM");
            Assert.IsNotNull(actual);
        }
    }
}
