using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Business;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for ParameterDataGridViewModelTest and is intended
    ///to contain all ParameterDataGridViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ParameterDataGridViewModelTest
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
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ParameterDataGridViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void ParameterDataGridViewModelConstructorTest()
        {
            object ownerVM = null; 
            ParameterDataGridViewModel target = new ParameterDataGridViewModel(ownerVM);
          //  Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CreateNewItem
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CreateNewItemTest()
        {
            Action<GraphParamSetting> onApplyEvent = new Action<GraphParamSetting>((list) => { });
            ParameterDataGridViewModel range = new ParameterDataGridViewModel(onApplyEvent);
            PrivateObject param0 = new PrivateObject(range); 
            ParameterDataGridViewModel_Accessor target = new ParameterDataGridViewModel_Accessor(param0); 
            GraphParamSetting expected = new GraphParamSetting(); 
            expected.StringValue = "ABC";
            GraphParamSetting actual;
            target.CreateNewItem().StringValue = "ABC";
            actual = target.CreateNewItem();
            
            Assert.ReferenceEquals(expected, actual);
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ValidateData
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ValidateDataTest()
        {
            Action<GraphParamSetting> onApplyEvent = new Action<GraphParamSetting>((list) => { });
            ParameterDataGridViewModel range = new ParameterDataGridViewModel(onApplyEvent);
            PrivateObject param0 = new PrivateObject (range); 
            ParameterDataGridViewModel_Accessor target = new ParameterDataGridViewModel_Accessor(param0); 
            string expected = String.Empty; 
            string actual;
            ObservableCollection<GraphParamSetting> _list = new ObservableCollection<GraphParamSetting>();
            GraphParamSetting item = new GraphParamSetting();
            item.Enabled = true;
            _list.Add(item);
            target.SourceList = _list;
            actual = target.ValidateData();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateData
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ValidateDataTest1()
        {
            Action<GraphParamSetting> onApplyEvent = new Action<GraphParamSetting>((list) => { });
            ParameterDataGridViewModel range = new ParameterDataGridViewModel(onApplyEvent);
            PrivateObject param0 = new PrivateObject(range); 
            ParameterDataGridViewModel_Accessor target = new ParameterDataGridViewModel_Accessor(param0); 
            string expected = "Object must not be empty"; 
            string actual;
            ObservableCollection<GraphParamSetting> _list = new ObservableCollection<GraphParamSetting>();
            GraphParamSetting item = new GraphParamSetting();
            item.Name = "123456789012345678901234567890123456789012345678901234567890";
            item.Enabled = true;
            _list.Add(item);
            target.SourceList = _list;
            actual = target.ValidateData();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateData
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ValidateDataTest2()
        {
            Action<GraphParamSetting> onApplyEvent = new Action<GraphParamSetting>((list) => { });
            ParameterDataGridViewModel range = new ParameterDataGridViewModel(onApplyEvent);
            PrivateObject param0 = new PrivateObject(range);
            ParameterDataGridViewModel_Accessor target = new ParameterDataGridViewModel_Accessor(param0);
            string expected = "Can enable upto 2 parameters";
            string actual;
            ObservableCollection<GraphParamSetting> _list = new ObservableCollection<GraphParamSetting>();
            GraphParamSetting item1 = new GraphParamSetting { Enabled = true };
            GraphParamSetting item2 = new GraphParamSetting { Enabled = true };
            GraphParamSetting item3 = new GraphParamSetting { Enabled = true };
            _list.Add(item1);
            _list.Add(item2);
            _list.Add(item3);
            target.SourceList = _list;
            actual = target.ValidateData();
            Assert.AreEqual(expected, actual);
        }
    }
}
