using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Collections.ObjectModel;
using LogViewer.Business;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for BaseParserTest and is intended
    ///to contain all BaseParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BaseParserTest
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
        ///A test for BaseParser`1 Constructor
        ///</summary>
        public void BaseParserConstructorTestHelper<T>()
        {
            BaseParser<T> target = new BaseParser<T>();
            Assert.AreNotEqual(null,target);
        }

        [TestMethod()]
        public void BaseParserConstructorTest()
        {
            BaseParserConstructorTestHelper<GenericParameterHelper>();
        }

     


        /// <summary>
        ///A test for Bookmarks
        ///</summary>
        public void BookmarksTestHelper<T>()
        {
            BaseParser<T> target = new BaseParser<T>(); 
            ReadOnlyCollection<T> expected = null; 
            ReadOnlyCollection<T> actual;
            target.Bookmarks = expected;
            actual = target.Bookmarks;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BookmarksTest()
        {
            BookmarksTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Comments
        ///</summary>
        public void CommentsTestHelper<T>()
        {
            BaseParser<T> target = new BaseParser<T>(); 
            Dictionary<T, string> expected = null; 
            Dictionary<T, string> actual;
            target.Comments = expected;
            actual = target.Comments;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CommentsTest()
        {
            CommentsTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for LogRecords
        ///</summary>
        public void LogRecordsTestHelper<T>()
        {
            BaseParser<T> target = new BaseParser<T>(); 
            ReadOnlyCollection<T> expected = null; 
            ReadOnlyCollection<T> actual;
            target.LogRecords = expected;
            actual = target.LogRecords;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LogRecordsTest()
        {
            LogRecordsTestHelper<GenericParameterHelper>();
        }
    }
}
