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
    public class AnalyzedUserActionItemTest
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
        [TestMethod()]
        public void AnalyzedUserActionItemConstructorTest()
        {
            AnalyzedUserActionItem_Accessor target = new AnalyzedUserActionItem_Accessor(
                new UserActionItem(), new CCSLogRecord());
            Assert.IsNotNull(target._action);
            Assert.IsNotNull(target._record);
        }

        /// <summary>
        ///A test for Date
        ///</summary>
        [TestMethod()]
        public void DateTest()
        {
            AnalyzedUserActionItem_Accessor target = new AnalyzedUserActionItem_Accessor(
                new UserActionItem(), new CCSLogRecord());
            Assert.AreEqual(target._record.Date, target.Date);
        }

        /// <summary>
        ///A test for Line
        ///</summary>
        [TestMethod()]
        public void LineTest()
        {
            AnalyzedUserActionItem_Accessor target = new AnalyzedUserActionItem_Accessor(
                new UserActionItem(), new CCSLogRecord());
            Assert.AreEqual(target._record.Line, target.Line);
        }

        /// <summary>
        ///A test for Record
        ///</summary>
        [TestMethod()]
        public void RecordTest()
        {
            AnalyzedUserActionItem_Accessor target = new AnalyzedUserActionItem_Accessor(
                new UserActionItem(), new CCSLogRecord());
            CCSLogRecord expected = new CCSLogRecord(); // TODO: Initialize to an appropriate value
            CCSLogRecord actual;
            target.Record = expected;
            actual = target.Record;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Time
        ///</summary>
        [TestMethod()]
        public void TimeTest()
        {
            AnalyzedUserActionItem_Accessor target = new AnalyzedUserActionItem_Accessor(
                new UserActionItem(), new CCSLogRecord());
            Assert.AreEqual(target._record.Time, target.Time);
        }

        /// <summary>
        ///A test for Time
        ///</summary>
        [TestMethod()]
        public void UserActionTest()
        {
            AnalyzedUserActionItem_Accessor target = new AnalyzedUserActionItem_Accessor(
                new UserActionItem(), new CCSLogRecord());
            Assert.AreEqual(target._action.UserAction, target.UserAction);
        }
    }
}
