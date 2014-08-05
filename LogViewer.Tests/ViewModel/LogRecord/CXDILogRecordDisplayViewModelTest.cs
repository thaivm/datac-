using System;
using LogViewer.Model;
using LogViewer.Service;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.ViewModel;
using LogViewer.WindowViewModelMapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.ViewModel.LogRecord
{
    [TestClass]
    public class CXDILogRecordDisplayViewModelTest
    {

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
        ///A test for CXDILogRecordDisplayViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void CXDILogRecordDisplayViewModelConstructorTest()
        {
            CXDILogRecord data = null;
            ILogsDisplayContainer<CXDILogRecord> ownerVM = null;
            CXDILogRecordDisplayViewModel target = new CXDILogRecordDisplayViewModel(data, ownerVM);
        }

        [TestMethod()]
        public void MessageTest()
        {
            CXDILogRecord data = new CXDILogRecord();
            data.Message = "test";
            ILogsDisplayContainer<CXDILogRecord> ownerVM = null;
            CXDILogRecordDisplayViewModel target = new CXDILogRecordDisplayViewModel(data, ownerVM);
            string actual;
            actual = target.Message;
            Assert.AreEqual(data.Message, actual);
        }

        [TestMethod()]
        public void Module()
        {
            CXDILogRecord data = new CXDILogRecord();
            data.Module = "test";
            ILogsDisplayContainer<CXDILogRecord> ownerVM = null;
            CXDILogRecordDisplayViewModel target = new CXDILogRecordDisplayViewModel(data, ownerVM);
            string actual;
            actual = target.Module;
            Assert.AreEqual(data.Module, actual);
        }
        [TestMethod()]
        public void CXDIPropetiesTest()
        {
            CXDILogRecord data = new CXDILogRecord();
            data.DateTime = DateTime.Parse("2014/10/10 10:10:10.444");
            ILogsDisplayContainer<CXDILogRecord> ownerVM = null;
            CXDILogRecordDisplayViewModel target = new CXDILogRecordDisplayViewModel(data, ownerVM);
            var actual = target.Date;
            var expected = "2014/10/10";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void CXDIPropetiesTest1()
        {
            CXDILogRecord data = new CXDILogRecord();
            data.DateTime = DateTime.Parse("2014/10/10 10:10:10.444");
            ILogsDisplayContainer<CXDILogRecord> ownerVM = null;
            CXDILogRecordDisplayViewModel target = new CXDILogRecordDisplayViewModel(data, ownerVM);
            var actual = target.Time;
            var expected = "10:10:10.444";
            Assert.AreEqual(expected, actual);
        }
    }
}
