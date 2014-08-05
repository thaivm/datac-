using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for CounterTest and is intended
    ///to contain all CounterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CounterTest
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
        ///A test for parameter
        ///</summary>
        [TestMethod()]
        public void parameterTest()
        {
            Counter target = new Counter();
            string expected = string.Empty; 
            string actual;
            target.parameter = expected;
            actual = target.parameter;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for value
        ///</summary>
        [TestMethod()]
        public void valueTest()
        {
            Counter target = new Counter(); 
            string expected = string.Empty; 
            string actual;
            target.value = expected;
            actual = target.value;
            Assert.AreEqual(expected, actual);
        }
    }
}
