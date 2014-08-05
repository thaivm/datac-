using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Util;
using System.Collections.Generic;
using LogViewer.Business;
using System.ComponentModel;
using System.Windows.Input;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.MVVMHelper;
using LogViewer.Model;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for GraphViewModelTest and is intended
    ///to contain all GraphViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GraphViewModelTest
    {
        
        public static MainViewModel_Accessor targetMainVM;
        public static CCSMainViewModel_Accessor ccsMain;
        public static CXDIMainViewModel_Accessor cxdiMain;
        public static GraphViewModel_Accessor graph;
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
        ///A test for GraphViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void GraphViewModelConstructorTest()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
        }

        /// <summary>
        ///A test for AddRangeWhenNotNull
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void AddRangeWhenNotNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            List<GraphParamSetting> list = new List<GraphParamSetting>();
            List<GraphParamSetting> range = new List<GraphParamSetting>();
            target.AddRangeWhenNotNull<GraphParamSetting>(list, range);
        }

        /// <summary>
        ///A test for AddWhenNotNull
        ///</summary>

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void AddWhenNotNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            List<GraphParamSetting> list = new List<GraphParamSetting>();
            GraphParamSetting element = new GraphParamSetting();
            target.AddWhenNotNull<GraphParamSetting>(list, element);
        }

        /// <summary>
        ///A test for ApplyParamSetting
        ///</summary>
        ///
        //[TestMethod()]
        //[DeploymentItem("LogViewer.exe")]
        //public void ApplyParamSettingTest()
        //{
        //    PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
        //    GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
        //    IList<GraphParamSetting> paramSetting = new List<GraphParamSetting>();
        //    PrivateObject param1 = new PrivateObject(targetMainVM.CXDIMainVM);
        //    CXDIMainViewModel_Accessor cxdi = new CXDIMainViewModel_Accessor(param1);
        //    target.OnApplyGraphSettingEvent = cxdi.ApplyGraphSetting;
        //    //target.ApplyParamSetting(paramSetting);
        //    Assert.IsNotNull(target);
        //}

        /// <summary>
        ///A test for ApplyRangeSetting
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ApplyRangeSettingTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            GraphRangeSetting rangeSetting = new GraphRangeSetting();
            target.ApplyRangeSetting(rangeSetting);
            
        }

        /// <summary>
        ///A test for CloseDialog
        ///</summary>
        [TestMethod()]
        public void CloseDialogTest()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            target.CloseDialog();
            
        }

        /// <summary>
        ///A test for ExportGraphEventDataToCSVMatrix
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ExportGraphEventDataToCSVMatrixTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            string name = "a";
            List<GraphParamResultItem> resultList = new List<GraphParamResultItem>();
            GraphParamResultItem item = new GraphParamResultItem();
            
            resultList.Add(new GraphParamResultItem());
            List<string> expected = null;
            List<string> actual;
            actual = target.ExportGraphEventDataToCSVMatrix(name, resultList);
            Assert.AreEqual(2, actual.Count);
            
        }

        /// <summary>
        ///A test for ExportGraphLineDataToCSVMatrix
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ExportGraphLineDataToCSVMatrixTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            string name = "a";
            List<GraphParamResultItem> resultList = new List<GraphParamResultItem>();
            resultList.Add(new GraphParamResultItem());
            //List<List<string>> expected = null;
            List<List<string>> actual;
            actual = target.ExportGraphLineDataToCSVMatrix(name, resultList);
            Assert.AreEqual(2, actual.Count);
            
        }

        /// <summary>
        ///A test for ExportToCSVCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ExportToCSVCLTest1()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.ExportToCSVCL();            
        }
        //Pending
        //[TestMethod()]
        //[DeploymentItem("LogViewer.exe")]
        //public void ExportToCSVCLTest2()
        //{
        //    PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
        //    GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
        //    target.GraphEventData1 = new GraphResult();
        //    target.GraphEventData1.ResultList.Add(new GraphParamResultItem());
        //    target.ExportToCSVCL();
        //}

        /// <summary>
        ///A test for ExportToCSV
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ExportToCSVGraphLineData1IsNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.GraphLineData1 = null;
            string actual = target.ExportToCSV();
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ExportToCSVGraphLineData2IsNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.GraphLineData2 = null;
            string actual = target.ExportToCSV();
        }


        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ExportToCSVGraphEventData1IsNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.GraphEventData1 = null;
            string actual = target.ExportToCSV();
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ExportToCSVGraphEventData2IsNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.GraphEventData2 = null;
            string actual = target.ExportToCSV();
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ExportToCSVGraphEventData3IsNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.GraphEventData3 = null;
            string actual = target.ExportToCSV();
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ExportToCSVGraphEventData4IsNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.GraphEventData4 = null;
            string actual = target.ExportToCSV();
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ExportToCSVGraphEventData5IsNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.GraphEventData5 = null;
            string actual = target.ExportToCSV();
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ExportToCSVGraphEventData6IsNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.GraphEventData6 = null;
            string actual = target.ExportToCSV();
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ExportToCSVGraphEventData7IsNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.GraphEventData7 = null;
            string actual = target.ExportToCSV();
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ExportToCSVGraphEventData8IsNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.GraphEventData8 = null;
            string actual = target.ExportToCSV();
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ExportToCSVGraphEventData9IsNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.GraphEventData9 = null;
            string actual = target.ExportToCSV();
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ExportToCSVGraphEventData10IsNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.GraphEventData10 = null;
            string actual = target.ExportToCSV();
        }

        [TestMethod()]
        public void ExportToCSVGraphLineData1IsNotNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.MaxDate = Convert.ToDateTime("2014-12-12 12:12:12.999");
            target.MinDate = Convert.ToDateTime("2012-12-12 12:12:12.999");
            target.FirstRangeMinY = 0;
            target.FirstRangeMaxY = 10;
            target.SecondRangeMinY = 0;
            target.SecondRangeMaxY = 10;

            GraphResult GraphLineData1 = new GraphResult();
            GraphParamSetting ParamSetting = new GraphParamSetting();
            ParamSetting.Name = "test";
            GraphLineData1.ParamSetting = ParamSetting;
            List<GraphParamResultItem> ResultList = new List<GraphParamResultItem>();
            GraphParamResultItem graphParamResultItem = new GraphParamResultItem();
            graphParamResultItem.Time = Convert.ToDateTime("2013-12-12 12:12:12.999");
            graphParamResultItem.Value = 10;
            ResultList.Add(graphParamResultItem);
            GraphLineData1.ResultList = ResultList;
            target.GraphLineData1 = GraphLineData1;
            string actual = target.ExportToCSV();
            Assert.AreNotEqual(String.Empty, actual);
        }

        [TestMethod()]
        public void ExportToCSVGraphLineData2IsNotNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.MaxDate = Convert.ToDateTime("2014-12-12 12:12:12.999");
            target.MinDate = Convert.ToDateTime("2012-12-12 12:12:12.999");
            target.FirstRangeMinY = 0;
            target.FirstRangeMaxY = 10;
            target.SecondRangeMinY = 0;
            target.SecondRangeMaxY = 10;

            GraphResult GraphLineData2 = new GraphResult();
            GraphParamSetting ParamSetting = new GraphParamSetting();
            ParamSetting.Name = "test";
            GraphLineData2.ParamSetting = ParamSetting;
            List<GraphParamResultItem> ResultList = new List<GraphParamResultItem>();
            GraphParamResultItem graphParamResultItem = new GraphParamResultItem();
            graphParamResultItem.Time = Convert.ToDateTime("2013-12-12 12:12:12.999");
            graphParamResultItem.Value = 10;
            ResultList.Add(graphParamResultItem);
            GraphLineData2.ResultList = ResultList;
            target.GraphLineData2 = GraphLineData2;
            string actual = target.ExportToCSV();
            Assert.AreNotEqual(String.Empty, actual);
        }

        [TestMethod()]
        public void ExportToCSVGraphEventData1IsNotNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.MaxDate = Convert.ToDateTime("2014-12-12 12:12:12.999");
            target.MinDate = Convert.ToDateTime("2012-12-12 12:12:12.999");
            target.FirstRangeMinY = 0;
            target.FirstRangeMaxY = 10;
            target.SecondRangeMinY = 0;
            target.SecondRangeMaxY = 10;

            GraphResult GraphEventData1 = new GraphResult();
            GraphParamSetting ParamSetting = new GraphParamSetting();
            ParamSetting.Name = "test";
            GraphEventData1.ParamSetting = ParamSetting;
            List<GraphParamResultItem> ResultList = new List<GraphParamResultItem>();
            GraphParamResultItem graphParamResultItem = new GraphParamResultItem();
            graphParamResultItem.Time = Convert.ToDateTime("2013-12-12 12:12:12.999");
            graphParamResultItem.Value = 10;
            ResultList.Add(graphParamResultItem);
            GraphEventData1.ResultList = ResultList;
            target.GraphEventData1 = GraphEventData1;
            string actual = target.ExportToCSV();
            Assert.AreNotEqual(String.Empty, actual);
        }

        [TestMethod()]
        public void ExportToCSVGraphEventData2IsNotNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.MaxDate = Convert.ToDateTime("2014-12-12 12:12:12.999");
            target.MinDate = Convert.ToDateTime("2012-12-12 12:12:12.999");
            target.FirstRangeMinY = 0;
            target.FirstRangeMaxY = 10;
            target.SecondRangeMinY = 0;
            target.SecondRangeMaxY = 10;

            GraphResult GraphEventData2 = new GraphResult();
            GraphParamSetting ParamSetting = new GraphParamSetting();
            ParamSetting.Name = "test";
            GraphEventData2.ParamSetting = ParamSetting;
            List<GraphParamResultItem> ResultList = new List<GraphParamResultItem>();
            GraphParamResultItem graphParamResultItem = new GraphParamResultItem();
            graphParamResultItem.Time = Convert.ToDateTime("2013-12-12 12:12:12.999");
            graphParamResultItem.Value = 10;
            ResultList.Add(graphParamResultItem);
            GraphEventData2.ResultList = ResultList;
            target.GraphEventData2 = GraphEventData2;
            string actual = target.ExportToCSV();
            Assert.AreNotEqual(String.Empty, actual);
        }


        [TestMethod()]
        public void ExportToCSVGraphEventData3IsNotNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.MaxDate = Convert.ToDateTime("2014-12-12 12:12:12.999");
            target.MinDate = Convert.ToDateTime("2012-12-12 12:12:12.999");
            target.FirstRangeMinY = 0;
            target.FirstRangeMaxY = 10;
            target.SecondRangeMinY = 0;
            target.SecondRangeMaxY = 10;

            GraphResult GraphEventData3 = new GraphResult();
            GraphParamSetting ParamSetting = new GraphParamSetting();
            ParamSetting.Name = "test";
            GraphEventData3.ParamSetting = ParamSetting;
            List<GraphParamResultItem> ResultList = new List<GraphParamResultItem>();
            GraphParamResultItem graphParamResultItem = new GraphParamResultItem();
            graphParamResultItem.Time = Convert.ToDateTime("2013-12-12 12:12:12.999");
            graphParamResultItem.Value = 10;
            ResultList.Add(graphParamResultItem);
            GraphEventData3.ResultList = ResultList;
            target.GraphEventData3 = GraphEventData3;
            string actual = target.ExportToCSV();
            Assert.AreNotEqual(String.Empty, actual);
        }

        [TestMethod()]
        public void ExportToCSVGraphEventData4IsNotNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.MaxDate = Convert.ToDateTime("2014-12-12 12:12:12.999");
            target.MinDate = Convert.ToDateTime("2012-12-12 12:12:12.999");
            target.FirstRangeMinY = 0;
            target.FirstRangeMaxY = 10;
            target.SecondRangeMinY = 0;
            target.SecondRangeMaxY = 10;

            GraphResult GraphEventData4 = new GraphResult();
            GraphParamSetting ParamSetting = new GraphParamSetting();
            ParamSetting.Name = "test";
            GraphEventData4.ParamSetting = ParamSetting;
            List<GraphParamResultItem> ResultList = new List<GraphParamResultItem>();
            GraphParamResultItem graphParamResultItem = new GraphParamResultItem();
            graphParamResultItem.Time = Convert.ToDateTime("2013-12-12 12:12:12.999");
            graphParamResultItem.Value = 10;
            ResultList.Add(graphParamResultItem);
            GraphEventData4.ResultList = ResultList;
            target.GraphEventData4 = GraphEventData4;
            string actual = target.ExportToCSV();
            Assert.AreNotEqual(String.Empty, actual);
        }

        [TestMethod()]
        public void ExportToCSVGraphEventData5IsNotNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.MaxDate = Convert.ToDateTime("2014-12-12 12:12:12.999");
            target.MinDate = Convert.ToDateTime("2012-12-12 12:12:12.999");
            target.FirstRangeMinY = 0;
            target.FirstRangeMaxY = 10;
            target.SecondRangeMinY = 0;
            target.SecondRangeMaxY = 10;

            GraphResult GraphEventData5 = new GraphResult();
            GraphParamSetting ParamSetting = new GraphParamSetting();
            ParamSetting.Name = "test";
            GraphEventData5.ParamSetting = ParamSetting;
            List<GraphParamResultItem> ResultList = new List<GraphParamResultItem>();
            GraphParamResultItem graphParamResultItem = new GraphParamResultItem();
            graphParamResultItem.Time = Convert.ToDateTime("2013-12-12 12:12:12.999");
            graphParamResultItem.Value = 10;
            ResultList.Add(graphParamResultItem);
            GraphEventData5.ResultList = ResultList;
            target.GraphEventData5 = GraphEventData5;
            string actual = target.ExportToCSV();
            Assert.AreNotEqual(String.Empty, actual);
        }

        [TestMethod()]
        public void ExportToCSVGraphEventData6IsNotNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.MaxDate = Convert.ToDateTime("2014-12-12 12:12:12.999");
            target.MinDate = Convert.ToDateTime("2012-12-12 12:12:12.999");
            target.FirstRangeMinY = 0;
            target.FirstRangeMaxY = 10;
            target.SecondRangeMinY = 0;
            target.SecondRangeMaxY = 10;

            GraphResult GraphEventData6 = new GraphResult();
            GraphParamSetting ParamSetting = new GraphParamSetting();
            ParamSetting.Name = "test";
            GraphEventData6.ParamSetting = ParamSetting;
            List<GraphParamResultItem> ResultList = new List<GraphParamResultItem>();
            GraphParamResultItem graphParamResultItem = new GraphParamResultItem();
            graphParamResultItem.Time = Convert.ToDateTime("2013-12-12 12:12:12.999");
            graphParamResultItem.Value = 10;
            ResultList.Add(graphParamResultItem);
            GraphEventData6.ResultList = ResultList;
            target.GraphEventData6 = GraphEventData6;
            string actual = target.ExportToCSV();
            Assert.AreNotEqual(String.Empty, actual);
        }

        [TestMethod()]
        public void ExportToCSVGraphEventData7IsNotNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.MaxDate = Convert.ToDateTime("2014-12-12 12:12:12.999");
            target.MinDate = Convert.ToDateTime("2012-12-12 12:12:12.999");
            target.FirstRangeMinY = 0;
            target.FirstRangeMaxY = 10;
            target.SecondRangeMinY = 0;
            target.SecondRangeMaxY = 10;

            GraphResult GraphEventData7 = new GraphResult();
            GraphParamSetting ParamSetting = new GraphParamSetting();
            ParamSetting.Name = "test";
            GraphEventData7.ParamSetting = ParamSetting;
            List<GraphParamResultItem> ResultList = new List<GraphParamResultItem>();
            GraphParamResultItem graphParamResultItem = new GraphParamResultItem();
            graphParamResultItem.Time = Convert.ToDateTime("2013-12-12 12:12:12.999");
            graphParamResultItem.Value = 10;
            ResultList.Add(graphParamResultItem);
            GraphEventData7.ResultList = ResultList;
            target.GraphEventData7 = GraphEventData7;
            string actual = target.ExportToCSV();
            Assert.AreNotEqual(String.Empty, actual);
        }

        [TestMethod()]
        public void ExportToCSVGraphEventData8IsNotNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.MaxDate = Convert.ToDateTime("2014-12-12 12:12:12.999");
            target.MinDate = Convert.ToDateTime("2012-12-12 12:12:12.999");
            target.FirstRangeMinY = 0;
            target.FirstRangeMaxY = 10;
            target.SecondRangeMinY = 0;
            target.SecondRangeMaxY = 10;

            GraphResult GraphEventData8 = new GraphResult();
            GraphParamSetting ParamSetting = new GraphParamSetting();
            ParamSetting.Name = "test";
            GraphEventData8.ParamSetting = ParamSetting;
            List<GraphParamResultItem> ResultList = new List<GraphParamResultItem>();
            GraphParamResultItem graphParamResultItem = new GraphParamResultItem();
            graphParamResultItem.Time = Convert.ToDateTime("2013-12-12 12:12:12.999");
            graphParamResultItem.Value = 10;
            ResultList.Add(graphParamResultItem);
            GraphEventData8.ResultList = ResultList;
            target.GraphEventData8 = GraphEventData8;
            string actual = target.ExportToCSV();
            Assert.AreNotEqual(String.Empty, actual);
        }

        [TestMethod()]
        public void ExportToCSVGraphEventData9IsNotNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.MaxDate = Convert.ToDateTime("2014-12-12 12:12:12.999");
            target.MinDate = Convert.ToDateTime("2012-12-12 12:12:12.999");
            target.FirstRangeMinY = 0;
            target.FirstRangeMaxY = 10;
            target.SecondRangeMinY = 0;
            target.SecondRangeMaxY = 10;

            GraphResult GraphEventData9 = new GraphResult();
            GraphParamSetting ParamSetting = new GraphParamSetting();
            ParamSetting.Name = "test";
            GraphEventData9.ParamSetting = ParamSetting;
            List<GraphParamResultItem> ResultList = new List<GraphParamResultItem>();
            GraphParamResultItem graphParamResultItem = new GraphParamResultItem();
            graphParamResultItem.Time = Convert.ToDateTime("2013-12-12 12:12:12.999");
            graphParamResultItem.Value = 10;
            ResultList.Add(graphParamResultItem);
            GraphEventData9.ResultList = ResultList;
            target.GraphEventData9 = GraphEventData9;
            string actual = target.ExportToCSV();
            Assert.AreNotEqual(String.Empty, actual);
        }

        [TestMethod()]
        public void ExportToCSVGraphEventData10IsNotNullTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.MaxDate = Convert.ToDateTime("2014-12-12 12:12:12.999");
            target.MinDate = Convert.ToDateTime("2012-12-12 12:12:12.999");
            target.FirstRangeMinY = 0;
            target.FirstRangeMaxY = 10;
            target.SecondRangeMinY = 0;
            target.SecondRangeMaxY = 10;

            GraphResult GraphEventData10 = new GraphResult();
            GraphParamSetting ParamSetting = new GraphParamSetting();
            ParamSetting.Name = "test";
            GraphEventData10.ParamSetting = ParamSetting;
            List<GraphParamResultItem> ResultList = new List<GraphParamResultItem>();
            GraphParamResultItem graphParamResultItem = new GraphParamResultItem();
            graphParamResultItem.Time = Convert.ToDateTime("2013-12-12 12:12:12.999");
            graphParamResultItem.Value = 10;
            ResultList.Add(graphParamResultItem);
            GraphEventData10.ResultList = ResultList;
            target.GraphEventData10 = GraphEventData10;
            string actual = target.ExportToCSV();
            Assert.AreNotEqual(String.Empty, actual);
        }
        /// <summary>
        ///A test for HasData
        ///</summary>
        //HasDataTest_False
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void HasDataTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            GraphResult graphResult = null;
            bool expected = false;
            bool actual;
            actual = target.HasData(graphResult);
            Assert.AreEqual(expected, actual);            
        }
        //HasDataTest_True
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void HasDataTest_True()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            GraphResult graphResult = new GraphResult();
            graphResult.ResultList.Add(new GraphParamResultItem());
            bool expected = true;
            bool actual;
            actual = target.HasData(graphResult);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for InitGraphRangeSetting
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void InitGraphRangeSettingTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            GraphResult graphLineData1 = null;
            GraphResult graphLineData2 = null;
            IList<GraphResult> eventListData = new List<GraphResult>();
            eventListData.Add(new GraphResult());
            target.InitGraphRangeSetting(graphLineData1, graphLineData2, eventListData);            
        }
        //InitGraphRangeSettingTest1
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void InitGraphRangeSettingTest1()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            GraphResult graphLineData1 = new GraphResult();
            GraphParamResultItem item1 = new GraphParamResultItem();
            item1.Time = new DateTime(2013, 1, 1);
            graphLineData1.ResultList.Add(item1);
            GraphResult graphLineData2 = new GraphResult();
            GraphParamResultItem item2 = new GraphParamResultItem();
            item2.Time = new DateTime(2013, 10, 10);
            graphLineData2.ResultList.Add(item2);            
            IList<GraphResult> eventListData = new List<GraphResult>();            
            eventListData.Add(graphLineData1);
            eventListData.Add(graphLineData2);
            target.InitGraphRangeSetting(graphLineData1, graphLineData2, eventListData);
        }
        //InitGraphRangeSettingTest2
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void InitGraphRangeSettingTest2()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            GraphParamResultItem item1 = new GraphParamResultItem();
            GraphParamResultItem item2 = new GraphParamResultItem();
            item1.Time = new DateTime(2013, 1, 1);
            item2.Time = new DateTime(2013, 1, 1);
            item1.Value = 12;
            item2.Value = 13;
            graphLineData1.ResultList.Add(item1);
            graphLineData1.ResultList.Add(item2);
            graphLineData2.ResultList.Add(item2);
            graphLineData2.ResultList.Add(item1);                                   
            IList<GraphResult> eventListData = new List<GraphResult>();
            eventListData.Add(graphLineData1);            
            target.InitGraphRangeSetting(graphLineData1, graphLineData2, eventListData);
        }
        //InitGraphRangeSettingTest3
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void InitGraphRangeSettingTest3()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            GraphParamResultItem item1 = new GraphParamResultItem();
            //GraphParamResultItem item2 = new GraphParamResultItem();
            item1.Time = new DateTime(2013, 1, 1);
            //item2.Time = new DateTime(2013, 1, 1);
            //item1.Value = 12;
            //item2.Value = 13;
            graphLineData1.ResultList.Add(item1);
            //graphLineData1.ResultList.Add(item2);
            //graphLineData2.ResultList.Add(item2);
            //graphLineData2.ResultList.Add(item1);
            IList<GraphResult> eventListData = new List<GraphResult>();
            //eventListData.Add(graphLineData1);
            target.InitGraphRangeSetting(graphLineData1, graphLineData2, eventListData);
        }
        /// <summary>
        ///A test for IsInRangeGraphEvent
        ///</summary>        
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsInRangeGraphEventTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            GraphParamResultItem item = new GraphParamResultItem();
            bool expected = true;
            bool actual;
            actual = target.IsInRangeGraphEvent(item);
            Assert.AreEqual(expected, actual);            
        }        

        /// <summary>
        ///A test for IsInRangeGraphLine1
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsInRangeGraphLine1Test()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null)); ;
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            GraphParamResultItem item = new GraphParamResultItem();
            bool expected = true;
            bool actual;
            actual = target.IsInRangeGraphLine1(item);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for IsInRangeGraphLine2
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsInRangeGraphLine2Test()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null)); ;
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            GraphParamResultItem item = new GraphParamResultItem();
            bool expected = true;
            bool actual;
            actual = target.IsInRangeGraphLine2(item);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for LoadData
        ///</summary>
        [TestMethod()]
        public void LoadDataTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null)); ;
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            IList<GraphResult> eventListData = new List<GraphResult>();
            target.LoadData(graphLineData1, graphLineData2, eventListData);
            
        }
        //
        [TestMethod()]
        public void LoadDataTest1()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null)); ;
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            IList<GraphResult> eventListData = new List<GraphResult>();
            GraphResult item = new GraphResult();
            GraphParamResultItem a1 = new GraphParamResultItem();
            a1.Time = new DateTime(2013, 1, 1);
            
            item.ResultList.Add(a1);
            
            eventListData.Add(item);            
            target.LoadData(graphLineData1, graphLineData2, eventListData);
        }
        //
        [TestMethod()]
        public void LoadDataTest2()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null)); ;
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            IList<GraphResult> eventListData = new List<GraphResult>();
            GraphResult item = new GraphResult();
            GraphParamResultItem a1 = new GraphParamResultItem();
            GraphParamResultItem a2 = new GraphParamResultItem();
            a1.Time = new DateTime(2013, 1, 1);
            a2.Time = new DateTime(2013, 1, 1);
            item.ResultList.Add(a1);
            item.ResultList.Add(a2);
            eventListData.Add(item);
            target.LoadData(graphLineData1, graphLineData2, eventListData);
        }
        /// <summary>
        ///A test for LoadData
        ///</summary>
        [TestMethod()]
        public void LoadDataTest3()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            IList<GraphResult> eventListData = new List<GraphResult>();
            IList<GraphParamSetting> paramSetting = new List<GraphParamSetting>();
            target.LoadData(graphLineData1, graphLineData2, eventListData, paramSetting);            
        }

        [TestMethod()]
        public void LoadDataTestEvent1()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            IList<GraphResult> eventListData = new List<GraphResult>();
            GraphResult gResult = new GraphResult();
            GraphParamResultItem item = new GraphParamResultItem();
            item.Time = Convert.ToDateTime("2013-12-12 12:12:12");
            item.Value = 123;
            gResult.ResultList = new List<GraphParamResultItem>() { item};
            eventListData.Add(gResult);
            IList<GraphParamSetting> paramSetting = new List<GraphParamSetting>();
            target.LoadData(graphLineData1, graphLineData2, eventListData, paramSetting);
        }

        [TestMethod()]
        public void LoadDataTestEvent2()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            IList<GraphResult> eventListData = new List<GraphResult>();
            GraphResult gResult = new GraphResult();
            GraphParamResultItem item = new GraphParamResultItem();
            item.Time = Convert.ToDateTime("2013-12-12 12:12:12");
            item.Value = 123;
            gResult.ResultList = new List<GraphParamResultItem>() { item };
            eventListData.Add(gResult);
            GraphResult gResult1 = new GraphResult();
            GraphParamResultItem item1 = new GraphParamResultItem();
            item1.Time = Convert.ToDateTime("2013-12-13 12:12:12");
            item1.Value = 1234;
            gResult1.ResultList = new List<GraphParamResultItem>() { item1};
            eventListData.Add(gResult1);
            IList<GraphParamSetting> paramSetting = new List<GraphParamSetting>();
            target.LoadData(graphLineData1, graphLineData2, eventListData, paramSetting);
        }

        [TestMethod()]
        public void LoadDataTestEvent3()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            IList<GraphResult> eventListData = new List<GraphResult>();

            GraphResult gResult = new GraphResult();
            GraphParamResultItem item = new GraphParamResultItem();
            item.Time = Convert.ToDateTime("2013-12-12 12:12:12");
            item.Value = 123;
            gResult.ResultList = new List<GraphParamResultItem>() { item };
            eventListData.Add(gResult);

            GraphResult gResult1 = new GraphResult();
            GraphParamResultItem item1 = new GraphParamResultItem();
            item1.Time = Convert.ToDateTime("2013-12-13 12:12:12");
            item1.Value = 1234;
            gResult1.ResultList = new List<GraphParamResultItem>() { item1 };
            eventListData.Add(gResult1);

            GraphResult gResult2 = new GraphResult();
            GraphParamResultItem item2 = new GraphParamResultItem();
            item2.Time = Convert.ToDateTime("2013-12-14 12:12:12");
            item2.Value = 12346;
            gResult2.ResultList = new List<GraphParamResultItem>() { item2 };
            eventListData.Add(gResult2);

            IList<GraphParamSetting> paramSetting = new List<GraphParamSetting>();
            target.LoadData(graphLineData1, graphLineData2, eventListData, paramSetting);
        }
        [TestMethod()]
        public void LoadDataTestEvent4()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            IList<GraphResult> eventListData = new List<GraphResult>();
            GraphResult gResult = new GraphResult();
            GraphParamResultItem item = new GraphParamResultItem();
            item.Time = Convert.ToDateTime("2013-12-12 12:12:12");
            item.Value = 123;
            gResult.ResultList = new List<GraphParamResultItem>() { item };
            eventListData.Add(gResult);

            GraphResult gResult1 = new GraphResult();
            GraphParamResultItem item1 = new GraphParamResultItem();
            item1.Time = Convert.ToDateTime("2013-12-13 12:12:12");
            item1.Value = 1234;
            gResult1.ResultList = new List<GraphParamResultItem>() { item1 };
            eventListData.Add(gResult1);

            GraphResult gResult2 = new GraphResult();
            GraphParamResultItem item2 = new GraphParamResultItem();
            item2.Time = Convert.ToDateTime("2013-12-14 12:12:12");
            item2.Value = 12346;
            gResult2.ResultList = new List<GraphParamResultItem>() { item2 };
            eventListData.Add(gResult2);

            GraphResult gResult3 = new GraphResult();
            GraphParamResultItem item3 = new GraphParamResultItem();
            item3.Time = Convert.ToDateTime("2013-12-15 12:12:12");
            item3.Value = 12346;
            gResult3.ResultList = new List<GraphParamResultItem>() { item3 };
            eventListData.Add(gResult3);
            IList<GraphParamSetting> paramSetting = new List<GraphParamSetting>();
            target.LoadData(graphLineData1, graphLineData2, eventListData, paramSetting);
        }

        [TestMethod()]
        public void LoadDataTestEvent5()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            IList<GraphResult> eventListData = new List<GraphResult>();
            GraphResult gResult = new GraphResult();
            GraphParamResultItem item = new GraphParamResultItem();
            item.Time = Convert.ToDateTime("2013-12-12 12:12:12");
            item.Value = 123;
            gResult.ResultList = new List<GraphParamResultItem>() { item };
            eventListData.Add(gResult);

            GraphResult gResult1 = new GraphResult();
            GraphParamResultItem item1 = new GraphParamResultItem();
            item1.Time = Convert.ToDateTime("2013-12-13 12:12:12");
            item1.Value = 1234;
            gResult1.ResultList = new List<GraphParamResultItem>() { item1 };
            eventListData.Add(gResult1);

            GraphResult gResult2 = new GraphResult();
            GraphParamResultItem item2 = new GraphParamResultItem();
            item2.Time = Convert.ToDateTime("2013-12-14 12:12:12");
            item2.Value = 12346;
            gResult2.ResultList = new List<GraphParamResultItem>() { item2 };
            eventListData.Add(gResult2);

            GraphResult gResult3 = new GraphResult();
            GraphParamResultItem item3 = new GraphParamResultItem();
            item3.Time = Convert.ToDateTime("2013-12-15 12:12:12");
            item3.Value = 12346;
            gResult3.ResultList = new List<GraphParamResultItem>() { item3 };
            eventListData.Add(gResult3);

            GraphResult gResult4 = new GraphResult();
            GraphParamResultItem item4 = new GraphParamResultItem();
            item4.Time = Convert.ToDateTime("2013-12-16 12:12:12");
            item4.Value = 12346;
            gResult4.ResultList = new List<GraphParamResultItem>() { item4 };
            eventListData.Add(gResult4);
            IList<GraphParamSetting> paramSetting = new List<GraphParamSetting>();
            target.LoadData(graphLineData1, graphLineData2, eventListData, paramSetting);
        }

        [TestMethod()]
        public void LoadDataTestEvent6()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            IList<GraphResult> eventListData = new List<GraphResult>();
            GraphResult gResult = new GraphResult();
            GraphParamResultItem item = new GraphParamResultItem();
            item.Time = Convert.ToDateTime("2013-12-12 12:12:12");
            item.Value = 123;
            gResult.ResultList = new List<GraphParamResultItem>() { item };
            eventListData.Add(gResult);

            GraphResult gResult1 = new GraphResult();
            GraphParamResultItem item1 = new GraphParamResultItem();
            item1.Time = Convert.ToDateTime("2013-12-13 12:12:12");
            item1.Value = 1234;
            gResult1.ResultList = new List<GraphParamResultItem>() { item1 };
            eventListData.Add(gResult1);

            GraphResult gResult2 = new GraphResult();
            GraphParamResultItem item2 = new GraphParamResultItem();
            item2.Time = Convert.ToDateTime("2013-12-14 12:12:12");
            item2.Value = 12346;
            gResult2.ResultList = new List<GraphParamResultItem>() { item2 };
            eventListData.Add(gResult2);

            GraphResult gResult3 = new GraphResult();
            GraphParamResultItem item3 = new GraphParamResultItem();
            item3.Time = Convert.ToDateTime("2013-12-15 12:12:12");
            item3.Value = 12346;
            gResult3.ResultList = new List<GraphParamResultItem>() { item3 };
            eventListData.Add(gResult3);

            GraphResult gResult4 = new GraphResult();
            GraphParamResultItem item4 = new GraphParamResultItem();
            item4.Time = Convert.ToDateTime("2013-12-16 12:12:12");
            item4.Value = 12346;
            gResult4.ResultList = new List<GraphParamResultItem>() { item4 };
            eventListData.Add(gResult4);

            GraphResult gResult5 = new GraphResult();
            GraphParamResultItem item5 = new GraphParamResultItem();
            item5.Time = Convert.ToDateTime("2013-12-17 12:12:12");
            item5.Value = 12346;
            gResult5.ResultList = new List<GraphParamResultItem>() { item5 };
            eventListData.Add(gResult5);
            IList<GraphParamSetting> paramSetting = new List<GraphParamSetting>();
            target.LoadData(graphLineData1, graphLineData2, eventListData, paramSetting);
        }

        [TestMethod()]
        public void LoadDataTestEvent7()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            IList<GraphResult> eventListData = new List<GraphResult>();
            GraphResult gResult = new GraphResult();
            GraphParamResultItem item = new GraphParamResultItem();
            item.Time = Convert.ToDateTime("2013-12-12 12:12:12");
            item.Value = 123;
            gResult.ResultList = new List<GraphParamResultItem>() { item };
            eventListData.Add(gResult);

            GraphResult gResult1 = new GraphResult();
            GraphParamResultItem item1 = new GraphParamResultItem();
            item1.Time = Convert.ToDateTime("2013-12-13 12:12:12");
            item1.Value = 1234;
            gResult1.ResultList = new List<GraphParamResultItem>() { item1 };
            eventListData.Add(gResult1);

            GraphResult gResult2 = new GraphResult();
            GraphParamResultItem item2 = new GraphParamResultItem();
            item2.Time = Convert.ToDateTime("2013-12-14 12:12:12");
            item2.Value = 12346;
            gResult2.ResultList = new List<GraphParamResultItem>() { item2 };
            eventListData.Add(gResult2);

            GraphResult gResult3 = new GraphResult();
            GraphParamResultItem item3 = new GraphParamResultItem();
            item3.Time = Convert.ToDateTime("2013-12-15 12:12:12");
            item3.Value = 12346;
            gResult3.ResultList = new List<GraphParamResultItem>() { item3 };
            eventListData.Add(gResult3);

            GraphResult gResult4 = new GraphResult();
            GraphParamResultItem item4 = new GraphParamResultItem();
            item4.Time = Convert.ToDateTime("2013-12-16 12:12:12");
            item4.Value = 12346;
            gResult4.ResultList = new List<GraphParamResultItem>() { item4 };
            eventListData.Add(gResult4);

            GraphResult gResult5 = new GraphResult();
            GraphParamResultItem item5 = new GraphParamResultItem();
            item5.Time = Convert.ToDateTime("2013-12-17 12:12:12");
            item5.Value = 12346;
            gResult5.ResultList = new List<GraphParamResultItem>() { item5 };
            eventListData.Add(gResult5);

            GraphResult gResult6 = new GraphResult();
            GraphParamResultItem item6 = new GraphParamResultItem();
            item6.Time = Convert.ToDateTime("2013-12-18 12:12:12");
            item6.Value = 123468;
            gResult6.ResultList = new List<GraphParamResultItem>() { item6 };
            eventListData.Add(gResult6);
            IList<GraphParamSetting> paramSetting = new List<GraphParamSetting>();
            target.LoadData(graphLineData1, graphLineData2, eventListData, paramSetting);
        }

        [TestMethod()]
        public void LoadDataTestEvent8()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            IList<GraphResult> eventListData = new List<GraphResult>();
            GraphResult gResult = new GraphResult();
            GraphParamResultItem item = new GraphParamResultItem();
            item.Time = Convert.ToDateTime("2013-12-12 12:12:12");
            item.Value = 123;
            gResult.ResultList = new List<GraphParamResultItem>() { item };
            eventListData.Add(gResult);

            GraphResult gResult1 = new GraphResult();
            GraphParamResultItem item1 = new GraphParamResultItem();
            item1.Time = Convert.ToDateTime("2013-12-13 12:12:12");
            item1.Value = 1234;
            gResult1.ResultList = new List<GraphParamResultItem>() { item1 };
            eventListData.Add(gResult1);

            GraphResult gResult2 = new GraphResult();
            GraphParamResultItem item2 = new GraphParamResultItem();
            item2.Time = Convert.ToDateTime("2013-12-14 12:12:12");
            item2.Value = 12346;
            gResult2.ResultList = new List<GraphParamResultItem>() { item2 };
            eventListData.Add(gResult2);

            GraphResult gResult3 = new GraphResult();
            GraphParamResultItem item3 = new GraphParamResultItem();
            item3.Time = Convert.ToDateTime("2013-12-15 12:12:12");
            item3.Value = 12346;
            gResult3.ResultList = new List<GraphParamResultItem>() { item3 };
            eventListData.Add(gResult3);

            GraphResult gResult4 = new GraphResult();
            GraphParamResultItem item4 = new GraphParamResultItem();
            item4.Time = Convert.ToDateTime("2013-12-16 12:12:12");
            item4.Value = 12346;
            gResult4.ResultList = new List<GraphParamResultItem>() { item4 };
            eventListData.Add(gResult4);

            GraphResult gResult5 = new GraphResult();
            GraphParamResultItem item5 = new GraphParamResultItem();
            item5.Time = Convert.ToDateTime("2013-12-17 12:12:12");
            item5.Value = 12346;
            gResult5.ResultList = new List<GraphParamResultItem>() { item5 };
            eventListData.Add(gResult5);

            GraphResult gResult6 = new GraphResult();
            GraphParamResultItem item6 = new GraphParamResultItem();
            item6.Time = Convert.ToDateTime("2013-12-18 12:12:12");
            item6.Value = 123468;
            gResult6.ResultList = new List<GraphParamResultItem>() { item6 };
            eventListData.Add(gResult6);

            GraphResult gResult7 = new GraphResult();
            GraphParamResultItem item7 = new GraphParamResultItem();
            item7.Time = Convert.ToDateTime("2013-12-19 12:12:12");
            item7.Value = 123468;
            gResult7.ResultList = new List<GraphParamResultItem>() { item7 };
            eventListData.Add(gResult7);
            IList<GraphParamSetting> paramSetting = new List<GraphParamSetting>();
            target.LoadData(graphLineData1, graphLineData2, eventListData, paramSetting);
        }

        [TestMethod()]
        public void LoadDataTestEvent9()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            IList<GraphResult> eventListData = new List<GraphResult>();
            GraphResult gResult = new GraphResult();
            GraphParamResultItem item = new GraphParamResultItem();
            item.Time = Convert.ToDateTime("2013-12-12 12:12:12");
            item.Value = 123;
            gResult.ResultList = new List<GraphParamResultItem>() { item };
            eventListData.Add(gResult);

            GraphResult gResult1 = new GraphResult();
            GraphParamResultItem item1 = new GraphParamResultItem();
            item1.Time = Convert.ToDateTime("2013-12-13 12:12:12");
            item1.Value = 1234;
            gResult1.ResultList = new List<GraphParamResultItem>() { item1 };
            eventListData.Add(gResult1);

            GraphResult gResult2 = new GraphResult();
            GraphParamResultItem item2 = new GraphParamResultItem();
            item2.Time = Convert.ToDateTime("2013-12-14 12:12:12");
            item2.Value = 12346;
            gResult2.ResultList = new List<GraphParamResultItem>() { item2 };
            eventListData.Add(gResult2);

            GraphResult gResult3 = new GraphResult();
            GraphParamResultItem item3 = new GraphParamResultItem();
            item3.Time = Convert.ToDateTime("2013-12-15 12:12:12");
            item3.Value = 12346;
            gResult3.ResultList = new List<GraphParamResultItem>() { item3 };
            eventListData.Add(gResult3);

            GraphResult gResult4 = new GraphResult();
            GraphParamResultItem item4 = new GraphParamResultItem();
            item4.Time = Convert.ToDateTime("2013-12-16 12:12:12");
            item4.Value = 12346;
            gResult4.ResultList = new List<GraphParamResultItem>() { item4 };
            eventListData.Add(gResult4);

            GraphResult gResult5 = new GraphResult();
            GraphParamResultItem item5 = new GraphParamResultItem();
            item5.Time = Convert.ToDateTime("2013-12-17 12:12:12");
            item5.Value = 12346;
            gResult5.ResultList = new List<GraphParamResultItem>() { item5 };
            eventListData.Add(gResult5);

            GraphResult gResult6 = new GraphResult();
            GraphParamResultItem item6 = new GraphParamResultItem();
            item6.Time = Convert.ToDateTime("2013-12-18 12:12:12");
            item6.Value = 123468;
            gResult6.ResultList = new List<GraphParamResultItem>() { item6 };
            eventListData.Add(gResult6);

            GraphResult gResult7 = new GraphResult();
            GraphParamResultItem item7 = new GraphParamResultItem();
            item7.Time = Convert.ToDateTime("2013-12-19 12:12:12");
            item7.Value = 123468;
            gResult7.ResultList = new List<GraphParamResultItem>() { item7 };
            eventListData.Add(gResult7);

            GraphResult gResult8 = new GraphResult();
            GraphParamResultItem item8 = new GraphParamResultItem();
            item8.Time = Convert.ToDateTime("2013-12-29 12:12:12");
            item8.Value = 123468;
            gResult8.ResultList = new List<GraphParamResultItem>() { item8 };
            eventListData.Add(gResult8);
            IList<GraphParamSetting> paramSetting = new List<GraphParamSetting>();
            target.LoadData(graphLineData1, graphLineData2, eventListData, paramSetting);
        }

        [TestMethod()]
        public void LoadDataTestEvent10()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult graphLineData1 = new GraphResult();
            GraphResult graphLineData2 = new GraphResult();
            IList<GraphResult> eventListData = new List<GraphResult>();
            GraphResult gResult = new GraphResult();
            GraphParamResultItem item = new GraphParamResultItem();
            item.Time = Convert.ToDateTime("2013-12-12 12:12:12");
            item.Value = 123;
            gResult.ResultList = new List<GraphParamResultItem>() { item };
            eventListData.Add(gResult);

            GraphResult gResult1 = new GraphResult();
            GraphParamResultItem item1 = new GraphParamResultItem();
            item1.Time = Convert.ToDateTime("2013-12-13 12:12:12");
            item1.Value = 1234;
            gResult1.ResultList = new List<GraphParamResultItem>() { item1 };
            eventListData.Add(gResult1);

            GraphResult gResult2 = new GraphResult();
            GraphParamResultItem item2 = new GraphParamResultItem();
            item2.Time = Convert.ToDateTime("2013-12-14 12:12:12");
            item2.Value = 12346;
            gResult2.ResultList = new List<GraphParamResultItem>() { item2 };
            eventListData.Add(gResult2);

            GraphResult gResult3 = new GraphResult();
            GraphParamResultItem item3 = new GraphParamResultItem();
            item3.Time = Convert.ToDateTime("2013-12-15 12:12:12");
            item3.Value = 12346;
            gResult3.ResultList = new List<GraphParamResultItem>() { item3 };
            eventListData.Add(gResult3);

            GraphResult gResult4 = new GraphResult();
            GraphParamResultItem item4 = new GraphParamResultItem();
            item4.Time = Convert.ToDateTime("2013-12-16 12:12:12");
            item4.Value = 12346;
            gResult4.ResultList = new List<GraphParamResultItem>() { item4 };
            eventListData.Add(gResult4);

            GraphResult gResult5 = new GraphResult();
            GraphParamResultItem item5 = new GraphParamResultItem();
            item5.Time = Convert.ToDateTime("2013-12-17 12:12:12");
            item5.Value = 12346;
            gResult5.ResultList = new List<GraphParamResultItem>() { item5 };
            eventListData.Add(gResult5);

            GraphResult gResult6 = new GraphResult();
            GraphParamResultItem item6 = new GraphParamResultItem();
            item6.Time = Convert.ToDateTime("2013-12-18 12:12:12");
            item6.Value = 123468;
            gResult6.ResultList = new List<GraphParamResultItem>() { item6 };
            eventListData.Add(gResult6);

            GraphResult gResult7 = new GraphResult();
            GraphParamResultItem item7 = new GraphParamResultItem();
            item7.Time = Convert.ToDateTime("2013-12-19 12:12:12");
            item7.Value = 123468;
            gResult7.ResultList = new List<GraphParamResultItem>() { item7 };
            eventListData.Add(gResult7);

            GraphResult gResult8 = new GraphResult();
            GraphParamResultItem item8 = new GraphParamResultItem();
            item8.Time = Convert.ToDateTime("2013-12-29 12:12:12");
            item8.Value = 123468;
            gResult8.ResultList = new List<GraphParamResultItem>() { item8 };
            eventListData.Add(gResult8);

            GraphResult gResult9 = new GraphResult();
            GraphParamResultItem item9 = new GraphParamResultItem();
            item9.Time = Convert.ToDateTime("2013-12-09 12:12:12");
            item9.Value = 123468;
            gResult9.ResultList = new List<GraphParamResultItem>() { item9 };
            eventListData.Add(gResult9);
            IList<GraphParamSetting> paramSetting = new List<GraphParamSetting>();
            target.LoadData(graphLineData1, graphLineData2, eventListData, paramSetting);
        }
        /// <summary>
        ///A test for ParamSettingCL
        ///</summary>
        //ParamSettingCLTest
        [TestMethod()]
        public void ParamSettingCLTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));            
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target._graphParamSetting = new List<GraphParamSetting>();
            target.ParamSettingCL();
            
        }
        
        /// <summary>
        ///A test for SetMinMaxAxes
        ///</summary>
        //1
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void SetMinMaxAxesTest1()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            GraphRangeSetting rangeSetting = new GraphRangeSetting();
            rangeSetting.FirstYRangeTo = 10000;
            target.FirstRangeMinY = 100000;
            rangeSetting.SecondYRangeTo = 10000;
            target.SecondRangeMinY = 100000;
            rangeSetting.To = new DateTime(2013, 1, 1);
            target.MinDate = new DateTime(2014, 10, 10);
            target.SetMinMaxAxes(rangeSetting);            
        }
        //2
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void SetMinMaxAxesTest2()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            GraphRangeSetting rangeSetting = new GraphRangeSetting();
            rangeSetting.FirstYRangeTo = 1000000;
            target.FirstRangeMinY = 100000;
            rangeSetting.SecondYRangeTo = 1000000;
            target.SecondRangeMinY = 100000;
            rangeSetting.To = new DateTime(2013, 1, 1);
            target.MinDate = new DateTime(2012, 10, 10);
            target.SetMinMaxAxes(rangeSetting);
        }
        /// <summary>
        ///A test for SetRangeCommandCL
        ///</summary>
        [TestMethod()]
        public void SetRangeCommandCLFirstRecordEqualLastRecordTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            CXDILogRecord record = new CXDILogRecord();
            record.DateTime= DateTime.Parse("2013-12-12 12:12:12");
            target._firstRecord = record;
            target._lastRecord = record;
            target.SetRangeCommandCL();            
        }
        [TestMethod()]
        public void SetRangeCommandCLFirstRecordNotEqualLastRecordTest()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            CXDILogRecord record = new CXDILogRecord();
            record.DateTime= DateTime.Parse("2013-12-12 12:12:12");
            CXDILogRecord record1 = new CXDILogRecord();
            record1.DateTime= DateTime.Parse("2013-12-12 13:12:12");
            target._firstRecord = record;
            target._lastRecord = record1;
            target.SetRangeCommandCL();
        }
        //[TestMethod()]
        //public void SetRangeCommandCLTest()
        //{
        //    PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
        //    GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
        //    CXDILogRecord record = new CXDILogRecord();
        //    record.DateTime= DateTime.Parse("2013-12-12 12:12:12");
        //    target._firstRecord = record;
        //    target._lastRecord = record;
        //    target.SetRangeCommandCL();
        //}
        //
        [TestMethod()]
        public void SetRangeCommandCLTest_null()
        {
            PrivateObject param0 = new PrivateObject(new GraphViewModel(null));
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(param0);
            target.SetRangeCommandCL();
        }
        /// <summary>
        ///A test for dialog_Closing
        ///</summary>
        [TestMethod()]
        public void dialog_ClosingTest()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            object sender = null;
            CancelEventArgs e = null;
            target.dialog_Closing(sender, e);
            
        }

        /// <summary>
        ///A test for ExportToCSVCommand
        ///</summary>
        [TestMethod()]
        public void ExportToCSVCommandTest()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            var actual = target.ExportToCSVCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for FirstRangeMaxY
        ///</summary>
        // >999999999999
        [TestMethod()]
        public void FirstRangeMaxYTest1()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            double expected = 999999999999;
            double actual;
            target.FirstRangeMaxY = 9999999999999;
            actual = target.FirstRangeMaxY;
            Assert.AreEqual(expected, actual);
            
        }
        // <=999999999999
        [TestMethod()]
        public void FirstRangeMaxYTest2()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            double expected = 10000000;
            double actual;
            target.FirstRangeMaxY = 10000000;
            actual = target.FirstRangeMaxY;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for FirstRangeMinY
        ///</summary>
        // >999999999999
        [TestMethod()]
        public void FirstRangeMinYTest1()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            double expected = 999999999998;
            double actual;
            target.FirstRangeMinY = 9999999999999;
            actual = target.FirstRangeMinY;
            Assert.AreEqual(expected, actual);
            
        }
        // <=999999999999
        [TestMethod()]
        public void FirstRangeMinYTest2()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            double expected = 11111111;
            double actual;
            target.FirstRangeMinY = 11111111;
            actual = target.FirstRangeMinY;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GraphEventData1
        ///</summary>
        [TestMethod()]
        public void GraphEventData1Test()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult expected = new GraphResult();
            GraphResult actual;
            target.GraphEventData1 = expected;
            actual = target.GraphEventData1;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GraphEventData10
        ///</summary>
        [TestMethod()]
        public void GraphEventData10Test()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult expected = new GraphResult();
            GraphResult actual;
            target.GraphEventData10 = expected;
            actual = target.GraphEventData10;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GraphEventData2
        ///</summary>
        [TestMethod()]
        public void GraphEventData2Test()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult expected = new GraphResult();
            GraphResult actual;
            target.GraphEventData2 = expected;
            actual = target.GraphEventData2;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GraphEventData3
        ///</summary>
        [TestMethod()]
        public void GraphEventData3Test()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult expected = new GraphResult();
            GraphResult actual;
            target.GraphEventData3 = expected;
            actual = target.GraphEventData3;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GraphEventData4
        ///</summary>
        [TestMethod()]
        public void GraphEventData4Test()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult expected = new GraphResult();
            GraphResult actual;
            target.GraphEventData4 = expected;
            actual = target.GraphEventData4;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GraphEventData5
        ///</summary>
        [TestMethod()]
        public void GraphEventData5Test()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult expected = new GraphResult();
            GraphResult actual;
            target.GraphEventData5 = expected;
            actual = target.GraphEventData5;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GraphEventData6
        ///</summary>
        [TestMethod()]
        public void GraphEventData6Test()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult expected = new GraphResult();
            GraphResult actual;
            target.GraphEventData6 = expected;
            actual = target.GraphEventData6;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GraphEventData7
        ///</summary>
        [TestMethod()]
        public void GraphEventData7Test()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult expected = new GraphResult();
            GraphResult actual;
            target.GraphEventData7 = expected;
            actual = target.GraphEventData7;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GraphEventData8
        ///</summary>
        [TestMethod()]
        public void GraphEventData8Test()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult expected = new GraphResult();
            GraphResult actual;
            target.GraphEventData8 = expected;
            actual = target.GraphEventData8;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GraphEventData9
        ///</summary>
        [TestMethod()]
        public void GraphEventData9Test()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult expected = new GraphResult();
            GraphResult actual;
            target.GraphEventData9 = expected;
            actual = target.GraphEventData9;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GraphLineData1
        ///</summary>
        [TestMethod()]
        public void GraphLineData1Test()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult expected = new GraphResult();
            GraphResult actual;
            target.GraphLineData1 = expected;
            actual = target.GraphLineData1;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GraphLineData2
        ///</summary>
        [TestMethod()]
        public void GraphLineData2Test()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            GraphResult expected = new GraphResult();
            GraphResult actual;
            target.GraphLineData2 = expected;
            actual = target.GraphLineData2;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GraphRangeSettingValue
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void GraphRangeSettingValueTest()
        {            
            PrivateObject param0 = new PrivateObject(targetMainVM.CXDIMainVM);
            cxdiMain = new CXDIMainViewModel_Accessor(param0);
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(cxdiMain.ApplyGraphSetting);
            
            GraphRangeSetting expected = new GraphRangeSetting();
            GraphRangeSetting actual;
            target.GraphRangeSettingValue = expected;
            actual = target.GraphRangeSettingValue;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for IsHaveGraphData
        ///</summary>
        [TestMethod()]
        public void IsHaveGraphDataTest()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            
            bool expected = false;
            bool actual;
            target.IsHaveGraphData = expected;
            actual = target.IsHaveGraphData;
            Assert.AreEqual(expected, actual);            
        }

        /// <summary>
        ///A test for IsInitGraphFlag
        ///</summary>
        [TestMethod()]
        public void IsInitGraphFlagTest()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            bool expected = false;
            bool actual;
            target.IsInitGraphFlag = expected;
            actual = target.IsInitGraphFlag;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for MaxDate
        ///</summary>
        [TestMethod()]
        public void MaxDateTest()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            DateTime expected = new DateTime(2014, 9, 30);
            DateTime actual;
            target.MaxDate = expected;
            actual = target.MaxDate;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for MinDate
        ///</summary>
        [TestMethod()]
        public void MinDateTest()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            DateTime expected = new DateTime(2014, 3, 1);
            DateTime actual;
            target.MinDate = expected;
            actual = target.MinDate;
            Assert.AreEqual(expected, actual);            
        }

        /// <summary>
        ///A test for ParamSettingCommand
        ///</summary>
        //_paramSettingCommand = null
        [TestMethod()]
        public void ParamSettingCommandTest_null()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            ICommand actual;
            actual = target.ParamSettingCommand;            
        }
        //_paramSettingCommand different null
        [TestMethod()]
        public void ParamSettingCommandTest()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel_Accessor target = new GraphViewModel_Accessor(onApplyGraphSettingEvent);
            target._paramSettingCommand = new DelegateCommand(target.ParamSettingCL);
            var actual = target.ParamSettingCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }

        /// <summary>
        ///A test for SecondRangeMaxY
        ///</summary>
        // <=999999999999
        [TestMethod()]
        public void SecondRangeMaxYTest1()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            double expected = 100000000;
            double actual;
            target.SecondRangeMaxY = 100000000;
            actual = target.SecondRangeMaxY;
            Assert.AreEqual(expected, actual);
            
        }
        // >999999999999
        [TestMethod()]
        public void SecondRangeMaxYTest2()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            double expected = 999999999999;
            double actual;
            target.SecondRangeMaxY = 9999999999999;
            actual = target.SecondRangeMaxY;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for SecondRangeMinY
        ///</summary>
        // <=999999999999
        [TestMethod()]
        public void SecondRangeMinYTest1()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            double expected = 999999999999;
            double actual;
            target.SecondRangeMinY = 999999999999;
            actual = target.SecondRangeMinY;
            Assert.AreEqual(expected, actual);            
        }
        // >999999999999
        [TestMethod()]
        public void SecondRangeMinYTest2()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            double expected = 999999999998;
            double actual;
            target.SecondRangeMinY = 9999999999999;
            actual = target.SecondRangeMinY;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SetRangeCommand
        ///</summary>
        [TestMethod()]
        public void SetRangeCommandTest()
        {
            GetGraphDataDelegate onApplyGraphSettingEvent = null;
            GraphViewModel target = new GraphViewModel(onApplyGraphSettingEvent);
            var actual = target.SetRangeCommand;
            Assert.IsInstanceOfType(actual, typeof(ICommand));
        }
    }
}
