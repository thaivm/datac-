using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for BaseResultSearchKeywordViewModelTest and is intended
    ///to contain all BaseResultSearchKeywordViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BaseResultSearchKeywordViewModelTest
    {


        private TestContext testContextInstance;
        private static BaseResultSearchKeywordViewModel_Accessor<CCSLogRecord> target;
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
            ServiceLocator.UnRegister<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
            ServiceLocator.UnRegister<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
        }
        //
        #endregion


        /// <summary>
        ///A test for GetDefaultSelectedLogItem
        ///</summary>
        private void CreateBaseResultSearchKeywordViewModel()
        {
            // Private Accessor for GetDefaultSelectedLogItem is not found. Please rebuild the containing project or run the Publicize.exe manually.
            //Assert.Inconclusive("Private Accessor for GetDefaultSelectedLogItem is not found. Please rebuild the c" +
                 //   "ontaining project or run the Publicize.exe manually.");
        }

        //[TestMethod()]
        //[DeploymentItem("LogViewer.exe")]
        //public void GetDefaultSelectedLogItemTest()
        //{
        //    //BaseResultSearchKeywordViewModel_Accessor<CCSLogRecord> target = new BaseResultSearchKeywordViewModel_Accessor<CCSLogRecord>(new PrivateObject(null));
        //    //target.GetDefaultSelectedLogItem();
        //}

        /// <summary>
        ///A test for InitLogItemList
        ///</summary>
        //[TestMethod()]
        //[DeploymentItem("LogViewer.exe")]
        //public void InitLogItemListTest()
        //{
        //    //Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
        //         //   "Please call InitLogItemListTestHelper<T>() with appropriate type parameters.");
        //}

        /// <summary>
        ///A test for IsValidLogField
        ///</summary>
        //[TestMethod()]
        //[DeploymentItem("LogViewer.exe")]
        //public void IsValidLogFieldTest()
        //{
        //    //Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
        //      //      "Please call IsValidLogFieldTestHelper<T>() with appropriate type parameters.");
        //}

        /// <summary>
        ///A test for LoadData
        ///</summary>
        [TestMethod()]
        public void LoadDataTest()
        {
            BaseResultSearchKeywordViewModel<CCSLogRecord> target = new CCSResultSearchKeywordViewModel();
            List<CCSLogRecord> list = new List<CCSLogRecord>();
            CCSLogRecord _ccs = new CCSLogRecord();
            list.Add(_ccs);
            IList<CCSLogRecord> data = list;
            target.LoadData(data);
        }

        /// <summary>
        ///A test for DoubleClickedRecord
        ///</summary>
        [TestMethod()]
        public void DoubleClickedRecordTest()
        {
            BaseResultSearchKeywordViewModel<CCSLogRecord> target = new CCSResultSearchKeywordViewModel();
            CCSLogRecord obj = new CCSLogRecord();
            Action<CCSLogRecord> OnShowRecordEvent = new Action<CCSLogRecord>((record)=>{});
            target.OnShowRecordEvent += OnShowRecordEvent;
            CCSLogRecord expected = new CCSLogRecord();
            target.DoubleClickedRecord = expected;
        
        }

        /// <summary>
        ///A test for IsCCS
        ///</summary>
        public void IsCCSTestHelper<T>()
            where T : BaseLogRecord
        {
            BaseResultSearchKeywordViewModel<CXDILogRecord> target = new CXDIResultSearchKeywordViewModel();
            bool actual;
            actual = target.IsCCS;
            
        }

        [TestMethod()]
        public void IsCCSTest()
        {
            BaseResultSearchKeywordViewModel<CXDILogRecord> target = new CXDIResultSearchKeywordViewModel();
            bool actual;
            actual = target.IsCCS;
        }

        /// <summary>
        ///A test for IsCXDI
        ///</summary>
        public void IsCXDITestHelper<T>()
            where T : BaseLogRecord
        {
            BaseResultSearchKeywordViewModel<CXDILogRecord> target = new CXDIResultSearchKeywordViewModel();
            bool actual;
            actual = target.IsCXDI;
            
        }

        [TestMethod()]
        public void IsCXDITest()
        {
            BaseResultSearchKeywordViewModel<CXDILogRecord> target = new CXDIResultSearchKeywordViewModel();
            bool actual;
            actual = target.IsCXDI;
        }

        /// <summary>
        ///A test for IsShowTab
        ///</summary>
        public void IsShowTabTestHelper<T>()
            where T : BaseLogRecord
        {
            BaseResultSearchKeywordViewModel<CCSLogRecord> target = new CCSResultSearchKeywordViewModel();
            bool expected = false;
            bool actual;
            target.IsShowTab = expected;
            actual = target.IsShowTab;
            Assert.AreEqual(expected, actual);
            
        }
        //IsShowTabTest_False
        [TestMethod()]
        public void IsShowTabTest_False()
        {
            BaseResultSearchKeywordViewModel<CCSLogRecord> target = new CCSResultSearchKeywordViewModel();
            bool expected = false;
            bool actual;
            target.IsShowTab = expected;
            actual = target.IsShowTab;
            Assert.AreEqual(expected, actual);
        }
        //IsShowTabTest_True
        [TestMethod()]
        public void IsShowTabTest_True()
        {
            BaseResultSearchKeywordViewModel<CCSLogRecord> target = new CCSResultSearchKeywordViewModel();
            bool expected = true;
            bool actual;
            target.IsShowTab = expected;
            actual = target.IsShowTab;
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for LogItemList
        ///</summary>
        public void LogItemListTestHelper<T>()
            where T : BaseLogRecord
        {
            BaseResultSearchKeywordViewModel<CCSLogRecord> target = new CCSResultSearchKeywordViewModel();
            ObservableCollection<ValueDisplayPair<string, string>> expected = null;
            ObservableCollection<ValueDisplayPair<string, string>> actual;
            target.LogItemList = expected;
            actual = target.LogItemList;
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        public void LogItemListTest()
        {
            BaseResultSearchKeywordViewModel<CCSLogRecord> target = new CCSResultSearchKeywordViewModel();
            ObservableCollection<ValueDisplayPair<string, string>> expected = new ObservableCollection<ValueDisplayPair<string,string>>();
            ObservableCollection<ValueDisplayPair<string, string>> actual;
            target.LogItemList = expected;
            actual = target.LogItemList;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LogResultList
        ///</summary>
        public void LogResultListTestHelper<T>()
            where T : BaseLogRecord
        {
            BaseResultSearchKeywordViewModel<CCSLogRecord> target = new CCSResultSearchKeywordViewModel();
            ObservableCollection<CCSLogRecord> expected = null;
            ObservableCollection<CCSLogRecord> actual;
            target.LogResultList = expected;
            actual = target.LogResultList;
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        public void LogResultListTest()
        {
            BaseResultSearchKeywordViewModel<CCSLogRecord> target = new CCSResultSearchKeywordViewModel();
            ObservableCollection<CCSLogRecord> expected = new ObservableCollection<CCSLogRecord>();
            CCSLogRecord item = new CCSLogRecord();
            item.Id = "a";
            expected.Add(item);
            ObservableCollection<CCSLogRecord> actual;
            target.LogResultList = expected;
            actual = target.LogResultList;
            Assert.AreEqual(expected, actual);            
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        public void NameTestHelper<T>()
            where T : BaseLogRecord
        {
            BaseResultSearchKeywordViewModel<CCSLogRecord> target = new CCSResultSearchKeywordViewModel();            
            string expected = string.Empty;
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        public void NameTest()
        {
            BaseResultSearchKeywordViewModel<CCSLogRecord> target = new CCSResultSearchKeywordViewModel();
            string expected = "aaa";
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for ResultCount
        ///</summary>
        public void ResultCountTestHelper<T>()
            where T : BaseLogRecord
        {
            BaseResultSearchKeywordViewModel<CCSLogRecord> target = new CCSResultSearchKeywordViewModel();
            int expected = 0;
            int actual;
            target.ResultCount = expected;
            actual = target.ResultCount;
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        public void ResultCountTest()
        {
            BaseResultSearchKeywordViewModel<CCSLogRecord> target = new CCSResultSearchKeywordViewModel();
            int expected = 0;
            int actual;
            target.ResultCount = expected;
            actual = target.ResultCount;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for SelectedLogItem
        ///</summary>
        public void SelectedLogItemTestHelper<T>()
            where T : BaseLogRecord
        {
            BaseResultSearchKeywordViewModel<CCSLogRecord> target = new CCSResultSearchKeywordViewModel();
            string expected = string.Empty;
            string actual;
            target.SelectedLogItem = expected;
            actual = target.SelectedLogItem;
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        public void SelectedLogItemTest()
        {
            BaseResultSearchKeywordViewModel<CCSLogRecord> target = new CCSResultSearchKeywordViewModel();
            string expected = "Content";
            string actual;
            target.SelectedLogItem = expected;
            actual = target.SelectedLogItem;
            Assert.AreEqual(expected, actual);
        }
    }
}
