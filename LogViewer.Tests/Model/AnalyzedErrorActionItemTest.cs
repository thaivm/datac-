using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for AnalyzedErrorActionItemTest and is intended
    ///to contain all AnalyzedErrorActionItemTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AnalyzedErrorActionItemTest
    {


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
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {

        }
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
                ServiceLocator.Register<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
                ServiceLocator.Register<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
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
        ///A test for AnalyzedErrorActionItem Constructor
        ///</summary>
        [TestMethod]
        public void AnalyzedErrorActionItemConstructorTest()
        {
            ErrorActionItem error = new ErrorActionItem();
            CCSLogRecord record = new CCSLogRecord();
            AnalyzedErrorActionItem_Accessor target = new AnalyzedErrorActionItem_Accessor(error, record);
            Assert.AreEqual(record, target.Record);
            Assert.AreEqual(error, target._error);
        }

        /// <summary>
        ///A test for Date
        ///</summary>
        [TestMethod]
        public void DateTest()
        {
            ErrorActionItem error = new ErrorActionItem();
            CCSLogRecord record = new CCSLogRecord();
            AnalyzedErrorActionItem_Accessor target = new AnalyzedErrorActionItem_Accessor(error, record);
            target._record.DateTime =DateTime.Parse( "2013/10/02");
            Assert.AreEqual("2013/10/02", target.Date);
        }

        /// <summary>
        ///A test for ErrorCode
        ///</summary>
        [TestMethod]
        public void ErrorCodeTest()
        {
            ErrorActionItem error = new ErrorActionItem();
            CCSLogRecord record = new CCSLogRecord();
            AnalyzedErrorActionItem_Accessor target = new AnalyzedErrorActionItem_Accessor(error, record);
            target._error.ErrorCode = "020200001";
            Assert.AreEqual("020200001", target.ErrorCode);
        }

        /// <summary>
        ///A test for Line
        ///</summary>
        [TestMethod]
        public void LineTest()
        {
            ErrorActionItem error = new ErrorActionItem();
            CCSLogRecord record = new CCSLogRecord();
            AnalyzedErrorActionItem_Accessor target = new AnalyzedErrorActionItem_Accessor(error, record);
            target._record.Line = 1;
            Assert.AreEqual(1, target.Line);
        }

        /// <summary>
        ///A test for LogType
        ///</summary>
        [TestMethod]
        public void LogTypeTest()
        {
            ErrorActionItem error = new ErrorActionItem();
            CCSLogRecord record = new CCSLogRecord();
            AnalyzedErrorActionItem_Accessor target = new AnalyzedErrorActionItem_Accessor(error, record);
            target._error.ErrorLv = "E";
            Assert.AreEqual("E", target.LogType);
        }

        /// <summary>
        ///A test for Message
        ///</summary>
        [TestMethod]
        public void MessageTest()
        {
            ErrorActionItem error = new ErrorActionItem();
            CCSLogRecord record = new CCSLogRecord();
            AnalyzedErrorActionItem_Accessor target = new AnalyzedErrorActionItem_Accessor(error, record);
            target._error.ErrorMessage = "Error Message";
            Assert.AreEqual("Error Message", target.Message);
        }

        /// <summary>
        ///A test for Recipe
        ///</summary>
        [TestMethod]
        public void RecipeTest()
        {
            ErrorActionItem error = new ErrorActionItem();
            CCSLogRecord record = new CCSLogRecord();
            AnalyzedErrorActionItem_Accessor target = new AnalyzedErrorActionItem_Accessor(error, record);
            target._error.ErrorRecipe = "Error Recipe";
            Assert.AreEqual("Error Recipe", target.Recipe);
        }

        /// <summary>
        ///A test for Record
        ///</summary>
        [TestMethod]
        public void RecordTest()
        {
            ErrorActionItem error = new ErrorActionItem();
            CCSLogRecord record = new CCSLogRecord();
            AnalyzedErrorActionItem_Accessor target = new AnalyzedErrorActionItem_Accessor(error, record);
            CCSLogRecord expected = new CCSLogRecord(); // TODO: Initialize to an appropriate value
            CCSLogRecord actual;
            target.Record = expected;
            actual = target.Record;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Time
        ///</summary>
        [TestMethod]
        public void TimeTest()
        {
            ErrorActionItem error = new ErrorActionItem();
            CCSLogRecord record = new CCSLogRecord();
            AnalyzedErrorActionItem_Accessor target = new AnalyzedErrorActionItem_Accessor(error, record);
            target._record.DateTime = DateTime.Parse("2014/10/10 00:00:00.001");
            Assert.AreEqual("00:00:00.001", target.Time);
        }
    }
}
