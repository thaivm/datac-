using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for UserActionItemTest and is intended
    ///to contain all UserActionItemTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserActionItemTest
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
        ///A test for ID
        ///</summary>
        [TestMethod()]
        public void IDTest()
        {
            UserActionItem target = new UserActionItem(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.ID = expected;
            actual = target.ID;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for RefSystemLog
        ///</summary>
        [TestMethod()]
        public void RefSystemLogTest()
        {
            UserActionItem target = new UserActionItem(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.RefSystemLog = expected;
            actual = target.RefSystemLog;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for UserAction
        ///</summary>
        [TestMethod()]
        public void UserActionTest()
        {
            UserActionItem target = new UserActionItem(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.UserAction = expected;
            actual = target.UserAction;
            Assert.AreEqual(expected, actual);
        }
    }
}
