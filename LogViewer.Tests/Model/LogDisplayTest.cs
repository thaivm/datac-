using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for LogDisplayTest and is intended
    ///to contain all LogDisplayTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LogDisplayTest
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
        ///A test for ValidDate - key null
        ///</summary>
        [TestMethod()]
        public void ValidDate_KeyNullTest()
        {
            LogDisplay target = new LogDisplay(); // TODO: Initialize to an appropriate value
            List<LogDisplay> logDisplayHeader = new List<LogDisplay>(); // TODO: Initialize to an appropriate value
            target.key = null;
            Assert.IsFalse(target.ValidDate(logDisplayHeader));
        }

        /// <summary>
        ///A test for ValidDate - key is empty
        ///</summary>
        [TestMethod()]
        public void ValidDate_KeyEmptyTest()
        {
            LogDisplay target = new LogDisplay(); // TODO: Initialize to an appropriate value
            List<LogDisplay> logDisplayHeader = new List<LogDisplay>(); // TODO: Initialize to an appropriate value
            target.key = string.Empty;
            Assert.IsFalse(target.ValidDate(logDisplayHeader));
        }

        /// <summary>
        ///A test for ValidDate - logDisplayHeader null
        ///</summary>
        [TestMethod()]
        public void ValidDate_LogDisplayHeaderNullTest()
        {
            LogDisplay target = new LogDisplay(); // TODO: Initialize to an appropriate value
            List<LogDisplay> logDisplayHeader = null; // TODO: Initialize to an appropriate value
            target.key = "Test";
            Assert.IsFalse(target.ValidDate(logDisplayHeader));
        }

        /// <summary>
        ///A test for ValidDate - logDisplayHeader count 0
        ///</summary>
        [TestMethod()]
        public void ValidDate_LogDisplayHeader0Test()
        {
            LogDisplay target = new LogDisplay(); // TODO: Initialize to an appropriate value
            List<LogDisplay> logDisplayHeader = new List<LogDisplay>(); // TODO: Initialize to an appropriate value
            target.key = "Test";
            Assert.IsFalse(target.ValidDate(logDisplayHeader));
        }

        /// <summary>
        ///A test for ValidDate - logDisplayHeader key 0
        ///</summary>
        [TestMethod()]
        public void ValidDate_LogDisplayHeaderKey0Test()
        {
            LogDisplay target = new LogDisplay(); // TODO: Initialize to an appropriate value
            List<LogDisplay> logDisplayHeader = new List<LogDisplay>(); // TODO: Initialize to an appropriate value
            target.key = "Test";
            logDisplayHeader.Add(new LogDisplay { key = "Test1", value = true });
            Assert.IsFalse(target.ValidDate(logDisplayHeader));
        }

        /// <summary>
        ///A test for ValidDate - true
        ///</summary>
        [TestMethod()]
        public void ValidDate_TrueTest()
        {
            LogDisplay target = new LogDisplay(); // TODO: Initialize to an appropriate value
            List<LogDisplay> logDisplayHeader = new List<LogDisplay>(); // TODO: Initialize to an appropriate value
            target.key = "Test";
            logDisplayHeader.Add(new LogDisplay { key = "Test", value = true });
            Assert.IsTrue(target.ValidDate(logDisplayHeader));
        }

        /// <summary>
        ///A test for key
        ///</summary>
        [TestMethod()]
        public void keyTest()
        {
            LogDisplay target = new LogDisplay(); // TODO: Initialize to an appropriate value
            string expected = "Test"; // TODO: Initialize to an appropriate value
            string actual;
            target.key = expected;
            actual = target.key;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for value
        ///</summary>
        [TestMethod()]
        public void valueTest()
        {
            LogDisplay target = new LogDisplay(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.value = expected;
            actual = target.value;
            Assert.AreEqual(expected, actual);
        }
    }
}
