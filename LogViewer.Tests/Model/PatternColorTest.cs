using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for PatternColorTest and is intended
    ///to contain all PatternColorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PatternColorTest
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
        ///A test for PatternColor`1 Constructor
        ///</summary>
        [TestMethod()]
        public void PatternColorConstructorTest()
        {
            Dictionary<int, KeyIndexRecordPair<int, string, int, BaseLogRecord, string>> root = 
                new Dictionary<int, KeyIndexRecordPair<int, string, int, BaseLogRecord, string>>();
            List<KeyIndexRecordPair<int, string, int, BaseLogRecord, string>> dic = 
                new List<KeyIndexRecordPair<int, string, int, BaseLogRecord, string>>();
            PatternColor<BaseLogRecord> target = new PatternColor<BaseLogRecord>(root, dic);
            Assert.AreEqual(dic, target._dicKey);
            Assert.AreEqual(root, target._rootKey);
        }
    }
}
