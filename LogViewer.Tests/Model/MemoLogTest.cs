using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for MemoLogTest and is intended
    ///to contain all MemoLogTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MemoLogTest
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
        ///A test for MemoLog`1 Constructor
        ///</summary>
        [TestMethod()]
        public void MemoLogConstructorTest()
        {
            MemoLog<CCSLogRecord> target = new MemoLog<CCSLogRecord>();
            Assert.IsNotNull(target.Bookmarks);
            Assert.IsNotNull(target.Comments);
            Assert.IsNotNull(target.Records);
        }

        /// <summary>
        ///A test for Bookmarks
        ///</summary>
        [TestMethod()]
        public void BookmarksTest()
        {
            MemoLog<CCSLogRecord> target = new MemoLog<CCSLogRecord>();
            List<CCSLogRecord> expected = new List<CCSLogRecord>();
            List<CCSLogRecord> actual;
            target.Bookmarks = expected;
            actual = target.Bookmarks;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Comments
        ///</summary>
        [TestMethod()]
        public void CommentsTest()
        {
            MemoLog<CCSLogRecord> target = new MemoLog<CCSLogRecord>();
            Dictionary<CCSLogRecord, string> expected = new Dictionary<CCSLogRecord, string>();
            Dictionary<CCSLogRecord, string> actual;
            target.Comments = expected;
            actual = target.Comments;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Records
        ///</summary>
        [TestMethod()]
        public void RecordsTest()
        {
            MemoLog<CCSLogRecord> target = new MemoLog<CCSLogRecord>();
            List<CCSLogRecord> expected = new List<CCSLogRecord>();
            List<CCSLogRecord> actual;
            target.Records = expected;
            actual = target.Records;
            Assert.AreEqual(expected, actual);
        }
    }
}
