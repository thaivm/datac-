using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Model;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using LogViewer.Service;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.WindowViewModelMapping;
using System.Windows;
using System.Linq;
namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for LogBookmarkTabViewModelTest and is intended
    ///to contain all LogBookmarkTabViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LogBookmarkTabViewModelTest
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
        public void MyTestInitialize()
        {
            if (!ServiceLocator.services.ContainsKey(typeof(IDialogService)))
            {
                ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
                ServiceLocator.RegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
                ServiceLocator.Register<IOpenFileDialog, LogViewer.Service.FrameworkDialogs.OpenFile.OpenFileDialogViewModel>();
                ServiceLocator.Register<ISaveFileDialog, LogViewer.Service.FrameworkDialogs.SaveFile.SaveFileDialogViewModel>();
            }
            targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            target = new PrivateObject((LogBookmarkTabViewModel<CCSLogRecord>)targetMainVM.CCSMainVM.AnalyzeAreaVM.LogBookmarkTabVM);
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
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime =DateTime.Parse( "2013-12-12 12:12:12.000");
            target.Invoke("AddBookmark", new object[]{record});
            ObservableCollection<CCSLogRecord> LogRecordList = (ObservableCollection<CCSLogRecord>)target.GetFieldOrProperty("LogRecordList");
            Assert.AreEqual(record.Date, LogRecordList[0].Date);
        }

        /// <summary>
        ///A test for CopyCommandCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CopyCommandCLCCSTest()
        {
            LogBookmarkTabViewModel_Accessor<CCSLogRecord> target1 = new LogBookmarkTabViewModel_Accessor<CCSLogRecord>(target);
            List<CCSLogRecord> selectedItems = new List<CCSLogRecord>();
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime =DateTime.Parse( "2013-12-12 12:12:12.000");
            record.Type = "e";
            record.Content = "test";
            selectedItems.Add(record);
            target1.SelectedItems = selectedItems.Cast<object>().ToList();
            target1.CopyCommandCL();
            Assert.IsNotNull(Clipboard.GetText());
        }


        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CopyCommandCLCXDITest()
        {
            PrivateObject target = new PrivateObject(targetMainVM.CXDIMainVM.AnalyzeAreaVM.LogBookmarkTabVM);
            LogBookmarkTabViewModel_Accessor<CXDILogRecord> target1 = new LogBookmarkTabViewModel_Accessor<CXDILogRecord>(target);
            List<CXDILogRecord> selectedItems = new List<CXDILogRecord>();
            CXDILogRecord record = new CXDILogRecord();
            record.DateTime =DateTime.Parse( "2013-12-12 12:12:12.000");
            record.Module = "e";
            record.Message = "test";
            selectedItems.Add(record);
            target1.SelectedItems = selectedItems.Cast<object>().ToList();
            target1.CopyCommandCL();
            Assert.IsNotNull(Clipboard.GetText());
        }
        /// <summary>
        ///A test for IsEnableCopy
        ///</summary>
        [TestMethod()]
        public void IsEnableCopySelectedItemIsNullTest()
        {
            LogBookmarkTabViewModel_Accessor<CCSLogRecord> target1 = new LogBookmarkTabViewModel_Accessor<CCSLogRecord>(target);
            bool expected = false;
            bool actual;
            actual = target1.IsEnableCopy();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsEnableCopySelectedItemIsEmptyTest()
        {
            LogBookmarkTabViewModel_Accessor<CCSLogRecord> target1 = new LogBookmarkTabViewModel_Accessor<CCSLogRecord>(target);
            bool expected = false;
            bool actual;
            target1.SelectedItems = new List<object>();
            actual = target1.IsEnableCopy();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsEnableCopySelectedItemIsNotEmptyTest()
        {
            List<CCSLogRecord> selectedItems = new List<CCSLogRecord>();
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime =DateTime.Parse( "2013-12-12 12:12:12.000");
            record.Type = "e";
            record.Content = "test";
            selectedItems.Add(record);
            LogBookmarkTabViewModel_Accessor<CCSLogRecord> target1 = new LogBookmarkTabViewModel_Accessor<CCSLogRecord>(target);
            bool expected = true;
            bool actual;
            target1.SelectedItems = selectedItems.Cast<object>().ToList();
            actual = target1.IsEnableCopy();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LoadData
        ///</summary>
        [TestMethod()]
        public void LoadDataTest()
        {
            List<CCSLogRecord> data = new List<CCSLogRecord>();
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime =DateTime.Parse( "2013-12-12 12:12:12.000");
            record.Type = "e";
            record.Content = "test";
            data.Add(record);
            target.Invoke("LoadData", new object[] { data });
            ObservableCollection<CCSLogRecord> actual = (ObservableCollection<CCSLogRecord>)target.GetFieldOrProperty("LogRecordList");
            Assert.AreNotEqual(0, actual.Count);
        }

        /// <summary>
        ///A test for RemoveBookmark
        ///</summary>
        [TestMethod()]
        public void RemoveBookmarkTest()
        {
            CCSLogRecord record1 = new CCSLogRecord();
            record1.DateTime =DateTime.Parse( "2013-12-12 12:12:12.000");
            record1.Id = "1";
            CCSLogRecord record2 = new CCSLogRecord();
            record2.DateTime =DateTime.Parse( "2013-12-12 12:12:12.000");
            record2.Id = "2";
            target.Invoke("AddBookmark", new object[] { record1 });
            target.Invoke("AddBookmark", new object[] { record2 });
            target.Invoke("RemoveBookmark", new object[] { record1 });
            ObservableCollection<CCSLogRecord> LogRecordList = (ObservableCollection<CCSLogRecord>)target.GetFieldOrProperty("LogRecordList");
            Assert.AreEqual(record2.Id, LogRecordList[0].Id);
        }

        /// <summary>
        ///A test for ResetBookmark
        ///</summary>
        [TestMethod()]
        public void ResetBookmarkTest()
        {
            target.Invoke("ResetBookmark");
            ObservableCollection<CCSLogRecord> actual = (ObservableCollection<CCSLogRecord>)target.GetFieldOrProperty("LogRecordList");
            Assert.AreEqual(0, actual.Count);
        }

        /// <summary>
        ///A test for CopyCommand
        ///</summary>
        [TestMethod()]
        public void CopyCommandTest()
        {
            var actual = target.GetFieldOrProperty("CopyCommand");
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for DoubleClickedRecord
        ///</summary>
        //[TestMethod()]
        //public void DoubleClickedRecordTest()
        //{
        //    LogBookmarkTabViewModel_Accessor<CCSLogRecord> target1 = new LogBookmarkTabViewModel_Accessor<CCSLogRecord>(target);
        //    CCSLogRecord record = new CCSLogRecord();
        //    record.DateTime =DateTime.Parse( "2013-12-12 12:12:12.000");
        //    record.Type = "e";
        //    record.Content = "test";
        //    target1.DoubleClickedRecord = record;
        //}

        /// <summary>
        ///A test for IsShowTabBookmark
        ///</summary>
        [TestMethod()]
        public void IsShowTabBookmarkTest()
        {
            bool expected = true;
            target.SetFieldOrProperty("IsShowTabBookmark", true);
            bool actual = (bool)target.GetFieldOrProperty("IsShowTabBookmark");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LogRecordList
        ///</summary>
        [TestMethod()]
        public void LogRecordListTest()
        {
            LogBookmarkTabViewModel_Accessor<CCSLogRecord> target1 = new LogBookmarkTabViewModel_Accessor<CCSLogRecord>(target);
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime =DateTime.Parse("2013-12-12 12:12:12.000");
            record.Type = "e";
            record.Content = "test";

            ObservableCollection<CCSLogRecord> list = new ObservableCollection<CCSLogRecord>();
            list.Add(record);

            target1.LogRecordList = list;
            ObservableCollection<CCSLogRecord> actual = target1.LogRecordList;
            Assert.AreEqual(list.Count, actual.Count);
        }

        /// <summary>
        ///A test for SelectedItems
        ///</summary>
        [TestMethod()]
        public void SelectedItemsTest()
        {
            LogBookmarkTabViewModel_Accessor<CCSLogRecord> target1 = new LogBookmarkTabViewModel_Accessor<CCSLogRecord>(target);
            List<CCSLogRecord> selectedItems = new List<CCSLogRecord>();
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime =DateTime.Parse("2013-12-12 12:12:12.000");
            record.Type = "e";
            record.Content = "test";
            selectedItems.Add(record);

            target1.SelectedItems = selectedItems.Cast<object>().ToList();
            List<object> actual = (List<object>)target1.SelectedItems;
            Assert.AreEqual(selectedItems.Count, actual.Count);
        }
    }
}
