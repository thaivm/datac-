using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for CXDIFirmwareTest and is intended
    ///to contain all CXDIFirmwareTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CXDIFirmwareTest
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
        ///A test for Counter
        ///</summary>
        [TestMethod()]
        public void CounterTest()
        {
            CXDIFirmware target = new CXDIFirmware(); 
            List<Counter> expected = null; 
            List<Counter> actual;
            target.Counter = expected;
            actual = target.Counter;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Saved
        ///</summary>
        [TestMethod()]
        public void SavedTest()
        {
            CXDIFirmware target = new CXDIFirmware(); 
            List<Saved> expected = null; 
            List<Saved> actual;
            target.Saved = expected;
            actual = target.Saved;
            Assert.AreEqual(expected, actual);
        }
    }
}
