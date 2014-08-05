using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.MVVMHelper;
using LogViewer.CustomException;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for SearchKeywordViewModelTest and is intended
    ///to contain all SearchKeywordViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SearchKeywordViewModelTest
    {
        public static MainViewModel_Accessor targetMainVM;

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
            targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
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
        ///A test for SearchKeywordViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void SearchKeywordViewModelConstructorTest()
        {
            SearchKeywordViewModel target = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
                targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(target);
            var onSearchCCSEvent = (Func<SearchItem, IList<CCSLogRecord>>)param0.GetField("OnSearchCCSEvent");
            var onSearchCXDIEvent = (Func<SearchItem, IList<CXDILogRecord>>) param0.GetField("OnSearchCXDIEvent");
            var onShowCCSRecordEvent = (Action<CCSLogRecord>) param0.GetField("OnShowCCSRecordEvent");
            var onShowCXDIRecordEvent = (Action<CXDILogRecord>) param0.GetField("OnShowCXDIRecordEvent");
            Assert.AreEqual(onSearchCCSEvent, targetMainVM.SearchCCS);
            Assert.AreEqual(onSearchCXDIEvent, targetMainVM.SearchCXDI);
            Assert.AreEqual(onShowCCSRecordEvent, targetMainVM.ShowCCSRecord);
            Assert.AreEqual(onShowCXDIRecordEvent, targetMainVM.ShowCXDIRecord);

        }

        /// <summary>
        ///A test for InitChildViewModels - CCS
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void InitChildViewModelsCCSTest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
                targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0); // TODO: Initialize to an appropriate value
            target._ccsResultVM = new CCSResultSearchKeywordViewModel();
            target._cxdiResultVM = new CXDIResultSearchKeywordViewModel();
            target.InitChildViewModels();
        }

        /// <summary>
        ///A test for InitChildViewModels - CXDI
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void InitChildViewModelsCXDITest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
                targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0); // TODO: Initialize to an appropriate value
            target._ccsResultVM = new CCSResultSearchKeywordViewModel();
            target._cxdiResultVM = new CXDIResultSearchKeywordViewModel();
            target.InitChildViewModels();
        }

        /// <summary>
        ///A test for Search - CCS_CXDI
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void SearchCCS_CXDITest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
                targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0); // TODO: Initialize to an appropriate value
            target._ccsResultVM = new CCSResultSearchKeywordViewModel();
            target._cxdiResultVM = new CXDIResultSearchKeywordViewModel();
            target.SelectedLogKindTarget = ConfigValue.LogKindTarget.CCS_CXDI;

            //search
            target._ccsResultVM.SelectedLogItem = "Line";
            target._cxdiResultVM.SelectedLogItem = "Line";
            target.SearchString = "1";

            var ccsSearchItem = new SearchItem { LogItem = target._ccsResultVM.SelectedLogItem,
                                                 StringValue = target.SearchString
            };
            var cxdiSearchItem = new SearchItem
            {
                LogItem = target._cxdiResultVM.SelectedLogItem,
                StringValue = target.SearchString
            };

            //result
            //target.Search();
            var actualCCS = target.OnSearchCCSEvent(ccsSearchItem);
            var actualCXDI = target.OnSearchCXDIEvent(cxdiSearchItem);
            Assert.IsNotNull(actualCCS);
            Assert.IsNotNull(actualCXDI);
        }

        /// <summary>
        ///A test for Search - CCS_CXDI
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void SearchCXDITest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
                targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0); // TODO: Initialize to an appropriate value
            target._ccsResultVM = new CCSResultSearchKeywordViewModel();
            target._cxdiResultVM = new CXDIResultSearchKeywordViewModel();
            target.SelectedLogKindTarget = ConfigValue.LogKindTarget.CXDI;

            //search
            target._cxdiResultVM.SelectedLogItem = "Line";
            target.SearchString = "1";

            var cxdiSearchItem = new SearchItem
            {
                LogItem = target._cxdiResultVM.SelectedLogItem,
                StringValue = target.SearchString
            };

            //result
            //target.Search();
            var actualCXDI = target.OnSearchCXDIEvent(cxdiSearchItem);
            Assert.IsNotNull(actualCXDI);
        }

        /// <summary>
        ///A test for Search - CCS
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void SearchCCSTest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
                targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0); // TODO: Initialize to an appropriate value
            target._ccsResultVM = new CCSResultSearchKeywordViewModel();
            target._cxdiResultVM = new CXDIResultSearchKeywordViewModel();
            target.SelectedLogKindTarget = ConfigValue.LogKindTarget.CCS;

            //search
            target._ccsResultVM.SelectedLogItem = "Line";
            target.SearchString = "1";

            var ccsSearchItem = new SearchItem
            {
                LogItem = target._ccsResultVM.SelectedLogItem,
                StringValue = target.SearchString
            };

            //result
            //target.Search();
            var actualCCS = target.OnSearchCCSEvent(ccsSearchItem);
            Assert.IsNotNull(actualCCS);
        }
                
        /// <summary>
        ///A test for clearCCS - ccs mot null
        ///</summary>
        [TestMethod()]
        public void clearCCS_CCSNotNullTest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
                targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0);
            target._ccsResultVM = new CCSResultSearchKeywordViewModel();
            target.clearCCS();
        }

        /// <summary>
        ///A test for clearCCS - cxdi  null
        ///</summary>
        [TestMethod()]
        public void clearCCS_CXDINullTest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
                targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0);
            target._cxdiResultVM = null;
            target.clearCCS();
        }

        /// <summary>
        ///A test for clearCCS - log result count = 0
        ///</summary>
        [TestMethod()]
        public void clearCCS_LogResultListZeroTest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
                targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0);
            target._cxdiResultVM = new CXDIResultSearchKeywordViewModel();
            target._cxdiResultVM.LogResultList = new ObservableCollection<CXDILogRecord>();
            target.clearCCS();
        }

        /// <summary>
        ///A test for clearCXDI - cxdi mot null
        ///</summary>
        [TestMethod()]
        public void clearCXDI_CXDINotNullTest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
                targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0);
            target._cxdiResultVM = new CXDIResultSearchKeywordViewModel();
            target.clearCXDI();
        }

        /// <summary>
        ///A test for clearCXDI - ccs  null
        ///</summary>
        [TestMethod()]
        public void clearCXDI_CCSNullTest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
                targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0);
            target._ccsResultVM = null;
            target.clearCXDI();
        }

        /// <summary>
        ///A test for clearCXDI - log result count = 0
        ///</summary>
        [TestMethod()]
        public void clearCXDI_LogResultListZeroTest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
                targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0);
            target._ccsResultVM = new CCSResultSearchKeywordViewModel();
            target._ccsResultVM.LogResultList = new ObservableCollection<CCSLogRecord>();
            target.clearCXDI();
        }

        /// <summary>
        ///A test for init
        ///</summary>
        [TestMethod()]
        public void initTest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
                targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0);
            target.init();
        }

        /// <summary>
        ///A test for LogKindTargetList
        ///</summary>
        [TestMethod()]
        public void LogKindTargetListTest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
                targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0);

            //value
            List<ValueDisplayPair<string, string>> value = new List<ValueDisplayPair<string, string>>();
            value.Add(new ValueDisplayPair<string, string>("CCS", "CCS"));
            ObservableCollection<ValueDisplayPair<string, string>> expected =
                new ObservableCollection<ValueDisplayPair<string, string>>(value); // TODO: Initialize to an appropriate value
            ObservableCollection<ValueDisplayPair<string, string>> actual;
            
            //result
            target.LogKindTargetList = expected;
            actual = target.LogKindTargetList;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LogKindTargetList - _logKindTargetList is null
        ///</summary>
        [TestMethod()]
        public void LogKindTargetListNullTest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
                targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0);            
            target._logKindTargetList = null;
            Assert.IsNotNull(target.LogKindTargetList);
        }

        /// <summary>
        ///A test for SearchCommand - null
        ///</summary>
        [TestMethod()]
        public void SearchCommandNullTest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
                targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0);
            Assert.IsNotNull(target.SearchCommand);
        }

        /// <summary>
        ///A test for SearchCommand
        ///</summary>
        [TestMethod()]
        public void SearchCommandTest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
                targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0);
            target.searchCommand = new DelegateCommand(target.Search);
            Assert.IsNotNull(target.SearchCommand);
        }

        /// <summary>
        ///A test for SearchResultVMList
        ///</summary>
        [TestMethod()]
        public void SearchResultVMListTest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
               targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0);
            
            //value
            ObservableCollection<object> expected =
                new ObservableCollection<object>(); // TODO: Initialize to an appropriate value
            ObservableCollection<object> actual;

            //result
            target.SearchResultVMList = expected;
            actual = target.SearchResultVMList;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SearchString
        ///</summary>
        [TestMethod()]
        public void SearchStringTest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
               targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0);
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.SearchString = expected;
            actual = target.SearchString;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SelectedLogKindTarget - empty
        ///</summary>
        [TestMethod()]
        public void SelectedLogKindTargetEmptyTest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
               targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0);
            target._selectedLogKindTarget = string.Empty;
            Assert.IsNotNull(target.SelectedLogKindTarget);
        }

        /// <summary>
        ///A test for SelectedLogKindTarget - ccs
        ///</summary>
        [TestMethod()]
        public void SelectedLogKindTargetCCSTest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
               targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0);
            target._ccsResultVM = new CCSResultSearchKeywordViewModel();
            target._cxdiResultVM = new CXDIResultSearchKeywordViewModel();

            //ccs
            target._selectedLogKindTarget = ConfigValue.LogKindTarget.CCS;
            target.SelectedLogKindTarget = target._selectedLogKindTarget;
            var actual = target.SelectedLogKindTarget;
            Assert.AreEqual(ConfigValue.LogKindTarget.CCS, actual);
        }

        /// <summary>
        ///A test for SelectedLogKindTarget - cxdi
        ///</summary>
        [TestMethod()]
        public void SelectedLogKindTargetCXDITest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
               targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0);
            target._ccsResultVM = new CCSResultSearchKeywordViewModel();
            target._cxdiResultVM = new CXDIResultSearchKeywordViewModel();

            //ccs
            target._selectedLogKindTarget = ConfigValue.LogKindTarget.CXDI;
            target.SelectedLogKindTarget = target._selectedLogKindTarget;
            var actual = target.SelectedLogKindTarget;
            Assert.AreEqual(ConfigValue.LogKindTarget.CXDI, actual);
        }

        /// <summary>
        ///A test for SelectedLogKindTarget - cxdi and ccs
        ///</summary>
        [TestMethod()]
        public void SelectedLogKindTargetCCS_CXDITest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
               targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0);
            target._ccsResultVM = new CCSResultSearchKeywordViewModel();
            target._cxdiResultVM = new CXDIResultSearchKeywordViewModel();

            //ccs
            target._selectedLogKindTarget = ConfigValue.LogKindTarget.CCS_CXDI;
            target.SelectedLogKindTarget = target._selectedLogKindTarget;
            var actual = target.SelectedLogKindTarget;
            Assert.AreEqual(ConfigValue.LogKindTarget.CCS_CXDI, actual);
        }

        /// <summary>
        ///A test for SelectedLogKindTarget - cxdi and ccs
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(DataValueNotSupportedException))]
        public void SelectedLogKindTargetExceptionTest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
               targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0);
            target._ccsResultVM = new CCSResultSearchKeywordViewModel();
            target._cxdiResultVM = new CXDIResultSearchKeywordViewModel();

            //ccs
            target._selectedLogKindTarget = "Exception";
            target.SelectedLogKindTarget = target._selectedLogKindTarget;
        }

        /// <summary>
        ///A test for SelectedSearchResultVM
        ///</summary>
        [TestMethod()]
        public void SelectedSearchResultVMTest()
        {
            SearchKeywordViewModel search = new SearchKeywordViewModel(targetMainVM.SearchCCS, targetMainVM.SearchCXDI,
               targetMainVM.ShowCCSRecord, targetMainVM.ShowCXDIRecord);
            PrivateObject param0 = new PrivateObject(search); // TODO: Initialize to an appropriate value
            SearchKeywordViewModel_Accessor target = new SearchKeywordViewModel_Accessor(param0);
            object expected = new object(); // TODO: Initialize to an appropriate value
            object actual;
            target.SelectedSearchResultVM = expected;
            actual = target.SelectedSearchResultVM;
            Assert.AreEqual(expected, actual);
        }
    }
}
