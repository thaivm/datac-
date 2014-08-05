using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using LogViewer.Business;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for GraphResultTest and is intended
    ///to contain all GraphResultTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GraphResultTest
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
        ///A test for ParamSetting
        ///</summary>
        [TestMethod()]
        public void ParamSettingTest()
        {
            GraphResult target = new GraphResult();
            GraphParamSetting expected = new GraphParamSetting(); 
            GraphParamSetting actual;
            target.ParamSetting = expected;
            actual = target.ParamSetting;
            Assert.AreEqual(expected.StringValue, actual.StringValue);
        }

        /// <summary>
        ///A test for ResultList
        ///</summary>
        [TestMethod()]
        public void ResultListTest()
        {
            GraphResult target = new GraphResult(); 
            List<GraphParamResultItem> expected = new List<GraphParamResultItem>(); 
            List<GraphParamResultItem> actual;
            target.ResultList = expected;
            actual = target.ResultList;
            Assert.AreEqual(expected.Count, actual.Count);
        }
    }
}
