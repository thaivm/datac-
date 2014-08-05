using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for BaseLogRecordTest and is intended
    ///to contain all BaseLogRecordTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BaseLogRecordTest
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
        ///A test for BaseLogRecord Constructor
        ///</summary>
        [TestMethod()]
        public void BaseLogRecordConstructorTest()
        {
            BaseLogRecord target = new BaseLogRecord();
            Assert.AreNotEqual(null,target);
        }

        /// <summary>
        ///A test for Date
        ///</summary>
        [TestMethod()]
        public void DateTest()
        {
            BaseLogRecord target = new BaseLogRecord(); 
            DateTime expected = DateTime.Now; 
            DateTime actual;
            target.DateTime = expected;
            actual = target.DateTime;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Line
        ///</summary>
        [TestMethod()]
        public void LineTest()
        {
            BaseLogRecord target = new BaseLogRecord(); 
            int expected = 0; 
            int actual;
            target.Line = expected;
            actual = target.Line;
            Assert.AreEqual(expected, actual);
        }

        ///// <summary>
        /////A test for Time
        /////</summary>
        //[TestMethod()]
        //public void TimeTest()
        //{
        //    BaseLogRecord target = new BaseLogRecord(); 
        //    string expected = string.Empty; 
        //    string actual;
        //    target.Time = expected;
        //    actual = target.Time;
        //    Assert.AreEqual(expected, actual);
        //}
    }
}
