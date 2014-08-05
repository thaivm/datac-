using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for CXDILogRecordTest and is intended
    ///to contain all CXDILogRecordTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CXDILogRecordTest
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
        ///A test for Message
        ///</summary>
        [TestMethod()]
        public void MessageTest()
        {
            CXDILogRecord target = new CXDILogRecord(); 
            string expected = string.Empty; 
            string actual;
            target.Message = expected;
            actual = target.Message;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Module
        ///</summary>
        [TestMethod()]
        public void ModuleTest()
        {
            CXDILogRecord target = new CXDILogRecord(); 
            string expected = string.Empty; 
            string actual;
            target.Module = expected;
            actual = target.Module;
            Assert.AreEqual(expected, actual);
        }
    }
}
