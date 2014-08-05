using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Business;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for EventDataGridViewModelTest and is intended
    ///to contain all EventDataGridViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EventDataGridViewModelTest
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
        ///A test for EventDataGridViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void EventDataGridViewModelConstructorTest()
        {
            object ownerVM = null; // TODO: Initialize to an appropriate value
            EventDataGridViewModel target = new EventDataGridViewModel(ownerVM);
         //   Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CreateNewItem
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CreateNewItemTest()
        {
            Action<GraphParamSetting> onApplyEvent = new Action<GraphParamSetting>((list) => { });
            EventDataGridViewModel range = new EventDataGridViewModel(onApplyEvent);
            PrivateObject param0 = new PrivateObject(range); // TODO: Initialize to an appropriate value
            EventDataGridViewModel_Accessor target = new EventDataGridViewModel_Accessor(param0); // TODO: Initialize to an appropriate value
            GraphParamSetting expected = new GraphParamSetting(); // TODO: Initialize to an appropriate value
            expected.StringValue = "ABC";
            GraphParamSetting actual;
            target.CreateNewItem().StringValue = "ABC";
            actual = target.CreateNewItem();
            Assert.ReferenceEquals(expected, actual);
         //   Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
