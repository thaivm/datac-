using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Business;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for GraphParamResultItemTest and is intended
    ///to contain all GraphParamResultItemTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GraphParamResultItemTest
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
        ///A test for Clone
        ///</summary>
        [TestMethod()]
        public void CloneTest()
        {
            GraphParamResultItem target = new GraphParamResultItem();
            GraphParamResultItem expected = new GraphParamResultItem();
            GraphParamResultItem actual;
            actual = target.Clone();
            Assert.AreEqual(expected.Value, actual.Value);
        }

        /// <summary>
        ///A test for Time
        ///</summary>
        [TestMethod()]
        public void TimeTest()
        {
            GraphParamResultItem target = new GraphParamResultItem(); 
            DateTime expected = new DateTime(); 
            DateTime actual;
            target.Time = expected;
            actual = target.Time;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Value
        ///</summary>
        [TestMethod()]
        public void ValueTest()
        {
            GraphParamResultItem target = new GraphParamResultItem(); 
            double expected = 0F; 
            double actual;
            target.Value = expected;
            actual = target.Value;
            Assert.AreEqual(expected, actual);
        }
    }
}
