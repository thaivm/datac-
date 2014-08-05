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

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for CountKeywordTabViewModelTest and is intended
    ///to contain all CountKeywordTabViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CountKeywordTabViewModelTest
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
            target = new PrivateObject((CountKeywordTabViewModel)targetMainVM.CCSMainVM.AnalyzeAreaVM.CountKeywordTabVM);
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
        ///A test for CancelCountKeywordCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CancelCountKeywordCLTest()
        {
            target.Invoke("CancelCountKeywordCL");
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
            ObservableCollection<AnalyzedCountKeywordItem> actual = (ObservableCollection<AnalyzedCountKeywordItem>)target.GetFieldOrProperty("AnalyzeCountKeywordItems");
            Assert.AreEqual(0, actual.Count);
        }

        /// <summary>
        ///A test for LoadData
        ///</summary>
        [TestMethod()]
        public void LoadDataTest()
        {
            List<AnalyzedCountKeywordItem> data = new List<AnalyzedCountKeywordItem>();
            AnalyzedCountKeywordItem item = new AnalyzedCountKeywordItem();
            item.Name = "test";
            data.Add(item);
            target.Invoke("LoadData", new object[] { data });
            ObservableCollection<AnalyzedCountKeywordItem> actual = (ObservableCollection<AnalyzedCountKeywordItem>)target.GetFieldOrProperty("AnalyzeCountKeywordItems");

            Assert.AreNotEqual(0, actual.Count);
        }

        /// <summary>
        ///A test for AnalyzeCountKeywordItems
        ///</summary>
        [TestMethod()]
        public void AnalyzeCountKeywordItemsTest()
        {
            List<AnalyzedCountKeywordItem> data = new List<AnalyzedCountKeywordItem>();
            AnalyzedCountKeywordItem item = new AnalyzedCountKeywordItem();
            item.Name = "test";
            data.Add(item);
            target.Invoke("LoadData", new object[] { data });
            ObservableCollection<AnalyzedCountKeywordItem> actual = (ObservableCollection<AnalyzedCountKeywordItem>)target.GetFieldOrProperty("AnalyzeCountKeywordItems");
            Assert.AreEqual(data[0].Name, actual[0].Name);
        }

        /// <summary>
        ///A test for CancelCountKeyword
        ///</summary>
        [TestMethod()]
        public void CancelCountKeywordTest()
        {            
            //ICommand actual;
            var actual = target.GetFieldOrProperty("CancelCountKeyword");
            Assert.IsInstanceOfType(actual, typeof(ICommand));
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
        ///A test for IsShowTabKeyword
        ///</summary>
        [TestMethod()]
        public void IsShowTabKeywordTest()
        {
            bool expected = true;
            target.SetFieldOrProperty("IsShowTabKeyword", true);
            bool actual = (bool)target.GetFieldOrProperty("IsShowTabKeyword");
            Assert.AreEqual(expected, actual);
        }
    }
}
