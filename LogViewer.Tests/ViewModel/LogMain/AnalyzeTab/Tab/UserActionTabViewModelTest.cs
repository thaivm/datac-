using LogViewer.ViewModel.LogMain.AnalyzeTab.Tab;
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
using LogViewer.ViewModel;
using System.Linq;
using System.Windows;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for UserActionTabViewModelTest and is intended
    ///to contain all UserActionTabViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserActionTabViewModelTest
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
                ServiceLocator.Register<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
                ServiceLocator.Register<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
            }
            targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
            target = new PrivateObject((UserActionTabViewModel)targetMainVM.CCSMainVM.AnalyzeAreaVM.UserActionTabVM);
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
            targetMainVM = null;
        }
        //
        #endregion

        /// <summary>
        ///A test for CancelUserActionCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CancelUserActionCLTest()
        {
            target.Invoke("CancelUserActionCL");
            bool actual = (bool)target.GetFieldOrProperty("IsLoadingData");
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for ClearData
        ///</summary>
        [TestMethod()]
        public void ClearDataTest()
        {
            target.Invoke("ClearData");
            ObservableCollection<AnalyzedUserActionItem> actual = (ObservableCollection<AnalyzedUserActionItem>)target.GetFieldOrProperty("UserActionList");
            Assert.AreEqual(0, actual.Count);
        }

        /// <summary>
        ///A test for CopyCommandCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CopyCommandCLTest()
        {
            UserActionTabViewModel_Accessor target1 = new UserActionTabViewModel_Accessor(target);
            List<AnalyzedUserActionItem> selectedItems = new List<AnalyzedUserActionItem>();
            UserActionItem user = new UserActionItem();
            user.ID = "1";
            user.RefSystemLog = "test";
            user.UserAction = "test";
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime =DateTime.Parse("2013-12-12 12:12:12.000");
            AnalyzedUserActionItem errorItem = new AnalyzedUserActionItem(user, record);
            selectedItems.Add(errorItem);

            //target.SetFieldOrProperty("SelectedItems", selectedItems);
            //target.Invoke("CopyCommandCL");
            target1.SelectedItems = selectedItems.Cast<object>().ToList();
            target1.CopyCommandCL();
            Assert.IsNotNull(Clipboard.GetText());
        }

        /// <summary>
        ///A test for IsEnableCopy
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsEnableCopySelectedItemIsNullTest()
        {
            UserActionTabViewModel_Accessor target1 = new UserActionTabViewModel_Accessor(target);
            bool expected = false;
            bool actual;
            actual = target1.IsEnableCopy();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsEnableCopySelectedItemIsEmptyTest()
        {
            UserActionTabViewModel_Accessor target1 = new UserActionTabViewModel_Accessor(target);
            bool expected = false;
            bool actual;
            target1.SelectedItems = new List<object>();
            actual = target1.IsEnableCopy();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsEnableCopySelectedItemIsNotEmptyTest()
        {
            List<AnalyzedUserActionItem> selectedItems = new List<AnalyzedUserActionItem>();
            UserActionItem user = new UserActionItem();
            user.ID = "1";
            user.RefSystemLog = "test";
            user.UserAction = "test";
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime = DateTime.Parse("2013-12-12 12:12:12.000");
            AnalyzedUserActionItem userItem = new AnalyzedUserActionItem(user, record);
            selectedItems.Add(userItem);
            UserActionTabViewModel_Accessor target1 = new UserActionTabViewModel_Accessor(target);
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
            List<AnalyzedUserActionItem> data = new List<AnalyzedUserActionItem>();
            UserActionItem user = new UserActionItem();
            user.ID = "1";
            user.RefSystemLog = "test";
            user.UserAction = "test";
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime = DateTime.Parse("2013-12-12 12:12:12.000");
            AnalyzedUserActionItem userItem = new AnalyzedUserActionItem(user, record);
            data.Add(userItem);
            target.Invoke("LoadData", new object[] { data });
            ObservableCollection<AnalyzedUserActionItem> actual = (ObservableCollection<AnalyzedUserActionItem>)target.GetFieldOrProperty("UserActionList");
            Assert.AreNotEqual(0, actual.Count);
        }

        /// <summary>
        ///A test for CancelUserAction
        ///</summary>
        [TestMethod()]
        public void CancelUserActionTest()
        {
            var actual = target.GetFieldOrProperty("CancelUserAction");
            Assert.IsInstanceOfType(actual, typeof(ICommand));
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
        //    UserActionTabViewModel_Accessor target1 = new UserActionTabViewModel_Accessor(target);
        //    UserActionItem user = new UserActionItem();
        //    user.ID = "1";
        //    user.RefSystemLog = "test";
        //    user.UserAction = "test";
        //    CCSLogRecord record = new CCSLogRecord();
        //    record.Date = "2013-12-12";
        //    record.Time = "12:12:12.000";
        //    AnalyzedUserActionItem userItem = new AnalyzedUserActionItem(user, record);
        //    target1.DoubleClickedRecord = userItem;
        //}

        /// <summary>
        ///A test for IsLoadingData
        ///</summary>
        [TestMethod()]
        public void IsLoadingDataTest()
        {
            bool expected = true;

            target.SetFieldOrProperty("IsLoadingData", true);
            bool actual = (bool)target.GetFieldOrProperty("IsLoadingData");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsShowTabUserAction
        ///</summary>
        [TestMethod()]
        public void IsShowTabUserActionTest()
        {
            bool expected = true;
            target.SetFieldOrProperty("IsShowTabUserAction", true);
            bool actual = (bool)target.GetFieldOrProperty("IsShowTabUserAction");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SelectedItems
        ///</summary>
        [TestMethod()]
        public void SelectedItemsTest()
        {
            ErrorActionTabViewModel_Accessor target1 = new ErrorActionTabViewModel_Accessor(target);
            List<AnalyzedUserActionItem> selectedItems = new List<AnalyzedUserActionItem>();
            UserActionItem user = new UserActionItem();
            user.ID = "1";
            user.RefSystemLog = "test";
            user.UserAction = "test";
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime =DateTime.Parse("2013-12-12 12:12:12.000");
            AnalyzedUserActionItem userItem = new AnalyzedUserActionItem(user, record);
            selectedItems.Add(userItem);

            target1.SelectedItems = selectedItems.Cast<object>().ToList();
            List<object> actual = (List<object>)target1.SelectedItems;
            Assert.AreEqual(selectedItems.Count, actual.Count);
        }

        /// <summary>
        ///A test for UserActionList
        ///</summary>
        [TestMethod()]
        public void UserActionListTest()
        {
            UserActionTabViewModel_Accessor target1 = new UserActionTabViewModel_Accessor(target);
            UserActionItem user = new UserActionItem();
            user.ID = "1";
            user.RefSystemLog = "test";
            user.UserAction = "test";
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime =DateTime.Parse("2013-12-12 12:12:12.000");
            AnalyzedUserActionItem userItem = new AnalyzedUserActionItem(user, record);

            ObservableCollection<AnalyzedUserActionItem> list = new ObservableCollection<AnalyzedUserActionItem>();
            list.Add(userItem);

            target1.UserActionList = list;
            ObservableCollection<AnalyzedUserActionItem> actual = target1.UserActionList;
            Assert.AreEqual(list.Count, actual.Count);
        }
    }
}
