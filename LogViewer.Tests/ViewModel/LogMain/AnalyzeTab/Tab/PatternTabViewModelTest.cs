using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Model;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for PatternTabViewModelTest and is intended
    ///to contain all PatternTabViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PatternTabViewModelTest
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
            target = new PrivateObject((PatternTabViewModel<CCSLogRecord>)targetMainVM.CCSMainVM.AnalyzeAreaVM.LogPatternTabVM);
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
        ///A test for CancelPatternAnalyzedCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CancelPatternAnalyzedCLTest()
        {
            target.Invoke("CancelPatternAnalyzedCL");
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
            ObservableCollection<AnalyzedPatternResultItem<CCSLogRecord>> actual = (ObservableCollection<AnalyzedPatternResultItem<CCSLogRecord>>)target.GetFieldOrProperty("PatternRecordList");
            Assert.AreEqual(0, actual.Count);
        }

        /// <summary>
        ///A test for LoadData
        ///</summary>
        [TestMethod()]
        public void LoadDataTest()
        {
            List<AnalyzedPatternResultItem<CCSLogRecord>> data = new List<AnalyzedPatternResultItem<CCSLogRecord>>();
            AnalyzedPatternResultItem<CCSLogRecord> item = new AnalyzedPatternResultItem<CCSLogRecord>();
            item.Name = "test";
            data.Add(item);
            target.Invoke("LoadData", new object[] { data });
            ObservableCollection<AnalyzedPatternResultItem<CCSLogRecord>> actual = (ObservableCollection<AnalyzedPatternResultItem<CCSLogRecord>>)target.GetFieldOrProperty("PatternRecordList");
            Assert.AreNotEqual(0, actual.Count);
        }

        /// <summary>
        ///A test for CancelPatternAnalyzed
        ///</summary>
        [TestMethod()]
        public void CancelPatternAnalyzedTest()
        {
            var actual = target.GetFieldOrProperty("CancelPatternAnalyzed");
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for CurrentPatternItem
        ///</summary>
        [TestMethod()]
        public void CurrentPatternItemTest()
        {
            PatternTabViewModel_Accessor<CCSLogRecord> target1 = new PatternTabViewModel_Accessor<CCSLogRecord>(target);
            AnalyzedPatternResultItem<CCSLogRecord> record = new AnalyzedPatternResultItem<CCSLogRecord>(); ;
            record.Name = "test";
            target1.CurrentPatternItem = record;
            AnalyzedPatternResultItem<CCSLogRecord> actual = target1.CurrentPatternItem;
            Assert.AreEqual(record.Name, actual.Name);
        }

        /// <summary>
        ///A test for DoubleClickedPatternResultItem
        ///</summary>
        [TestMethod()]
        public void DoubleClickedPatternResultItemTest()
        {
            PatternTabViewModel_Accessor<CCSLogRecord> target1 = new PatternTabViewModel_Accessor<CCSLogRecord>(target);
            AnalyzedPatternResultItem<CCSLogRecord> record = new AnalyzedPatternResultItem<CCSLogRecord>();
            target1.DoubleClickedPatternResultItem = record;
            Assert.AreEqual(record, target1.CurrentPatternItem);
        }

        /// <summary>
        ///A test for DoubleClickedRecord
        ///</summary>
        //[TestMethod()]
        //public void DoubleClickedRecordTest()
        //{
        //    PatternTabViewModel_Accessor<CCSLogRecord> target1 = new PatternTabViewModel_Accessor<CCSLogRecord>(target);
        //    CCSLogRecord record = new CCSLogRecord();
        //    record.DateTime = DateTime.Parse("2013-12-12 12:12:12.000");
        //    record.Type = "e";
        //    record.Content = "test";
        //    target1.DoubleClickedRecord = record;
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
        ///A test for IsShowTabPattern
        ///</summary>
        [TestMethod()]
        public void IsShowTabPatternTest()
        {
            bool expected = true;
            target.SetFieldOrProperty("IsShowTabPattern", true);
            bool actual = (bool)target.GetFieldOrProperty("IsShowTabPattern");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for PatternRecordList
        ///</summary>
        [TestMethod()]
        public void PatternRecordListTest()
        {
            PatternTabViewModel_Accessor<CCSLogRecord> target1 = new PatternTabViewModel_Accessor<CCSLogRecord>(target);
            AnalyzedPatternResultItem<CCSLogRecord> record = new AnalyzedPatternResultItem<CCSLogRecord>();
            

            ObservableCollection<AnalyzedPatternResultItem<CCSLogRecord>> list = new ObservableCollection<AnalyzedPatternResultItem<CCSLogRecord>>();
            list.Add(record);

            target1.PatternRecordList = list;
            ObservableCollection<AnalyzedPatternResultItem<CCSLogRecord>> actual = target1.PatternRecordList;
            Assert.AreEqual(list.Count, actual.Count);
        }
    }
}
