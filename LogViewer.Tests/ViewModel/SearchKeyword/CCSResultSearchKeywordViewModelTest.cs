using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Model;
using System.Collections.Generic;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for CCSResultSearchKeywordViewModelTest and is intended
    ///to contain all CCSResultSearchKeywordViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CCSResultSearchKeywordViewModelTest
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
        ///A test for CCSResultSearchKeywordViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void CCSResultSearchKeywordViewModelConstructorTest()
        {
            CCSResultSearchKeywordViewModel target = new CCSResultSearchKeywordViewModel();
           // Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetDefaultSelectedLogItem
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void GetDefaultSelectedLogItemTest()
        {
            CCSResultSearchKeywordViewModel_Accessor target = new CCSResultSearchKeywordViewModel_Accessor(); // TODO: Initialize to an appropriate value
            string expected = "Content"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetDefaultSelectedLogItem();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InitLogItemList
        ///</summary>
        

        /// <summary>
        ///A test for IsValidLogField
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsValidLogFieldTest()
        {
            CCSResultSearchKeywordViewModel_Accessor target = new CCSResultSearchKeywordViewModel_Accessor(); // TODO: Initialize to an appropriate value
            string value = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsValidLogField(value);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsValidLogFieldTest_false()
        {
            CCSResultSearchKeywordViewModel_Accessor target = new CCSResultSearchKeywordViewModel_Accessor(); // TODO: Initialize to an appropriate value
            string value = "abc"; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsValidLogField(value);
            Assert.AreEqual(expected, actual);
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsValidLogFieldTest_true()
        {
            CCSResultSearchKeywordViewModel_Accessor target = new CCSResultSearchKeywordViewModel_Accessor(); // TODO: Initialize to an appropriate value
            string value = "Content"; // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsValidLogField(value);
            Assert.AreEqual(expected, actual);
       //     Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsCCS
        ///</summary>
        [TestMethod()]
        public void IsCCSTest()
        {
            CCSResultSearchKeywordViewModel target = new CCSResultSearchKeywordViewModel(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsCCS;
       //     Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsCXDI
        ///</summary>
        [TestMethod()]
        public void IsCXDITest()
        {
            CCSResultSearchKeywordViewModel target = new CCSResultSearchKeywordViewModel(); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsCXDI;
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
