using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Model;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for CCSLogRecordDisplayViewModelTest and is intended
    ///to contain all CCSLogRecordDisplayViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CCSLogRecordDisplayViewModelTest
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
        ///A test for CCSLogRecordDisplayViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void CCSLogRecordDisplayViewModelConstructorTest()
        {
            CCSLogRecord data = null;
            ILogsDisplayContainer<CCSLogRecord> ownerVM = null;
            CCSLogRecordDisplayViewModel target = new CCSLogRecordDisplayViewModel(data, ownerVM);
        }

        /// <summary>
        ///A test for AdditionalInfo
        ///</summary>
        [TestMethod()]
        public void AdditionalInfoTest()
        {
            CCSLogRecord data = new CCSLogRecord();
            data.AdditionalInfo = "test";
            ILogsDisplayContainer<CCSLogRecord> ownerVM = null;
            CCSLogRecordDisplayViewModel target = new CCSLogRecordDisplayViewModel(data, ownerVM);
            string actual;
            actual = target.AdditionalInfo;
            Assert.AreEqual(data.AdditionalInfo, actual);
        }

        /// <summary>
        ///A test for ClassName
        ///</summary>
        [TestMethod()]
        public void ClassNameTest()
        {
            CCSLogRecord data = new CCSLogRecord();
            data.ClassName = "test";
            ILogsDisplayContainer<CCSLogRecord> ownerVM = null;
            CCSLogRecordDisplayViewModel target = new CCSLogRecordDisplayViewModel(data, ownerVM); 
            string actual;
            actual = target.ClassName;
            Assert.AreEqual(data.ClassName, actual);
        }

        /// <summary>
        ///A test for Content
        ///</summary>
        [TestMethod()]
        public void ContentTest()
        {
            CCSLogRecord data = new CCSLogRecord();
            data.Content = "test";
            ILogsDisplayContainer<CCSLogRecord> ownerVM = null;
            CCSLogRecordDisplayViewModel target = new CCSLogRecordDisplayViewModel(data, ownerVM);
            string actual;
            actual = target.Content;
            Assert.AreEqual(data.Content, actual);
        }

        /// <summary>
        ///A test for HostName
        ///</summary>
        [TestMethod()]
        public void HostNameTest()
        {
            CCSLogRecord data = new CCSLogRecord();
            data.HostName = "test";
            ILogsDisplayContainer<CCSLogRecord> ownerVM = null; 
            CCSLogRecordDisplayViewModel target = new CCSLogRecordDisplayViewModel(data, ownerVM);
            string actual;
            actual = target.HostName;
            Assert.AreEqual(data.HostName, actual);
        }

        /// <summary>
        ///A test for Id
        ///</summary>
        [TestMethod()]
        public void IdTest()
        {
            CCSLogRecord data = new CCSLogRecord();
            data.Id = "test";
            ILogsDisplayContainer<CCSLogRecord> ownerVM = null; 
            CCSLogRecordDisplayViewModel target = new CCSLogRecordDisplayViewModel(data, ownerVM); 
            string actual;
            actual = target.Id;
            Assert.AreEqual(data.Id, actual);
        }

        /// <summary>
        ///A test for Mode
        ///</summary>
        [TestMethod()]
        public void ModeTest()
        {
            CCSLogRecord data = new CCSLogRecord();
            data.Mode = "test";
            ILogsDisplayContainer<CCSLogRecord> ownerVM = null; 
            CCSLogRecordDisplayViewModel target = new CCSLogRecordDisplayViewModel(data, ownerVM); 
            string actual;
            actual = target.Mode;
            Assert.AreEqual(data.Mode, actual);
        }

        /// <summary>
        ///A test for PersonalInfo
        ///</summary>
        [TestMethod()]
        public void PersonalInfoTest()
        {
            CCSLogRecord data = new CCSLogRecord();
            data.PersonalInfo = "test";
            ILogsDisplayContainer<CCSLogRecord> ownerVM = null;
            CCSLogRecordDisplayViewModel target = new CCSLogRecordDisplayViewModel(data, ownerVM);
            string actual;
            actual = target.PersonalInfo;
            Assert.AreEqual(data.PersonalInfo, actual);
        }

        /// <summary>
        ///A test for ThreadId
        ///</summary>
        [TestMethod()]
        public void ThreadIdTest()
        {
            CCSLogRecord data = new CCSLogRecord();
            data.ThreadId = "test";
            ILogsDisplayContainer<CCSLogRecord> ownerVM = null; 
            CCSLogRecordDisplayViewModel target = new CCSLogRecordDisplayViewModel(data, ownerVM); 
            string actual;
            actual = target.ThreadId;
            Assert.AreEqual(data.ThreadId, actual);
        }

        /// <summary>
        ///A test for Type
        ///</summary>
        [TestMethod()]
        public void TypeTest()
        {
            CCSLogRecord data = new CCSLogRecord();
            data.Type = "test";
            ILogsDisplayContainer<CCSLogRecord> ownerVM = null; 
            CCSLogRecordDisplayViewModel target = new CCSLogRecordDisplayViewModel(data, ownerVM); 
            string actual;
            actual = target.Type;
            Assert.AreEqual(data.Type, actual);
        }
    }
}
