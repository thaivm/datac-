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
    ///This is a test class for ErrorActionTabViewModelTest and is intended
    ///to contain all ErrorActionTabViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ErrorActionTabViewModelTest
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
            target = new PrivateObject((ErrorActionTabViewModel)targetMainVM.CCSMainVM.AnalyzeAreaVM.ErrorActionTabVM);
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
        ///A test for CancelErrorCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CancelErrorCLTest()
        {
            target.Invoke("CancelErrorCL");
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
            ObservableCollection<AnalyzedErrorActionItem> actual = (ObservableCollection<AnalyzedErrorActionItem>)target.GetFieldOrProperty("ErrorActionList");
            Assert.AreEqual(0, actual.Count);
        }

        /// <summary>
        ///A test for CopyCommandCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CopyCommandCLTest()
        {
            
            ErrorActionTabViewModel_Accessor target1 = new ErrorActionTabViewModel_Accessor(target);
            List<AnalyzedErrorActionItem> selectedItems = new List<AnalyzedErrorActionItem>();
            ErrorActionItem error = new ErrorActionItem();
            error.ErrorCode = "1";
            error.ErrorMessage = "test";
            error.ErrorRecipe = "test";
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime =DateTime.Parse("2013-12-12 12:12:12.000");
            AnalyzedErrorActionItem errorItem = new AnalyzedErrorActionItem(error, record);
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
        public void IsEnableCopySelectedItemIsNullTest()
        {
            ErrorActionTabViewModel_Accessor target1 = new ErrorActionTabViewModel_Accessor(target);
            bool expected = false;
            bool actual;
            actual = target1.IsEnableCopy();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsEnableCopySelectedItemIsEmptyTest()
        {
            ErrorActionTabViewModel_Accessor target1 = new ErrorActionTabViewModel_Accessor(target);
            bool expected = false;
            bool actual;
            target1.SelectedItems = new List<object>();
            actual = target1.IsEnableCopy();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsEnableCopySelectedItemIsNotEmptyTest()
        {
            List<AnalyzedErrorActionItem> selectedItems = new List<AnalyzedErrorActionItem>();
            ErrorActionItem error = new ErrorActionItem();
            error.ErrorCode = "1";
            error.ErrorMessage = "test";
            error.ErrorRecipe = "test";
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime = DateTime.Parse("2013-12-12 12:12:12.000");
            AnalyzedErrorActionItem errorItem = new AnalyzedErrorActionItem(error, record);
            selectedItems.Add(errorItem);
            ErrorActionTabViewModel_Accessor target1 = new ErrorActionTabViewModel_Accessor(target);
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
            List<AnalyzedErrorActionItem> data = new List<AnalyzedErrorActionItem>();
            ErrorActionItem error = new ErrorActionItem();
            error.ErrorCode = "1";
            error.ErrorMessage = "test";
            error.ErrorRecipe = "test";
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime = DateTime.Parse("2013-12-12 12:12:12.000");
            AnalyzedErrorActionItem errorItem = new AnalyzedErrorActionItem(error, record);
            data.Add(errorItem);
            target.Invoke("LoadData", new object[] { data });
            ObservableCollection<AnalyzedErrorActionItem> actual = (ObservableCollection<AnalyzedErrorActionItem>)target.GetFieldOrProperty("ErrorActionList");
            Assert.AreNotEqual(0, actual.Count);
        }

        /// <summary>
        ///A test for CancelError
        ///</summary>
        [TestMethod()]
        public void CancelErrorTest()
        {
            var actual = target.GetFieldOrProperty("CancelError");
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
        //    ErrorActionTabViewModel_Accessor target1 = new ErrorActionTabViewModel_Accessor(target);
        //    ErrorActionItem error = new ErrorActionItem();
        //    error.ErrorCode = "1";
        //    error.ErrorMessage = "test";
        //    error.ErrorRecipe = "test";
        //    CCSLogRecord record = new CCSLogRecord();
        //    record.DateTime =DateTime.Parse("2013-12-12 12:12:12.000");
        //    AnalyzedErrorActionItem errorItem = new AnalyzedErrorActionItem(error, record);
        //    target.SetFieldOrProperty("DoubleClickedRecord", errorItem);
        //    target1.DoubleClickedRecord = errorItem;
        //}

        /// <summary>
        ///A test for ErrorActionList
        ///</summary>
        [TestMethod()]
        public void ErrorActionListTest()
        {
            ErrorActionTabViewModel_Accessor target1 = new ErrorActionTabViewModel_Accessor(target);
            ErrorActionItem error = new ErrorActionItem();
            error.ErrorCode = "1";
            error.ErrorMessage = "test";
            error.ErrorRecipe = "test";
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime =DateTime.Parse("2013-12-12 12:12:12.000");
            AnalyzedErrorActionItem errorItem = new AnalyzedErrorActionItem(error, record);

            ObservableCollection<AnalyzedErrorActionItem> list = new ObservableCollection<AnalyzedErrorActionItem>();
            list.Add(errorItem);

            target1.ErrorActionList = list;
            ObservableCollection<AnalyzedErrorActionItem> actual = target1.ErrorActionList;
            Assert.AreEqual(list.Count, actual.Count);
        }

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
        ///A test for IsShowTabError
        ///</summary>
        [TestMethod()]
        public void IsShowTabErrorTest()
        {
            bool expected = true;
            target.SetFieldOrProperty("IsShowTabError", true);
            bool actual = (bool)target.GetFieldOrProperty("IsShowTabError");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SelectedItems
        ///</summary>
        [TestMethod()]
        public void SelectedItemsTest()
        {
            ErrorActionTabViewModel_Accessor target1 = new ErrorActionTabViewModel_Accessor(target);
            ErrorActionItem error = new ErrorActionItem();
            error.ErrorCode = "1";
            error.ErrorMessage = "test";
            error.ErrorRecipe = "test";
            CCSLogRecord record = new CCSLogRecord();
            record.DateTime =DateTime.Parse("2013-12-12 12:12:12.000");
            AnalyzedErrorActionItem errorItem = new AnalyzedErrorActionItem(error, record);

            List<AnalyzedErrorActionItem> list = new List<AnalyzedErrorActionItem>();
            list.Add(errorItem);

            target1.SelectedItems = list.Cast<object>().ToList();
            List<object> actual = (List<object>)target1.SelectedItems;
            Assert.AreEqual(list.Count, actual.Count);
        }
    }
}
