using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for StringLineIndexLevelPairTest and is intended
    ///to contain all StringLineIndexLevelPairTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StringLineIndexLevelPairTest
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
        ///A test for StringLineIndexLevelPair`5 Constructor
        ///</summary>
        [TestMethod()]
        public void StringLineIndexLevelPairConstructorTest()
        {
            DateTime date = new DateTime(2013, 10, 02, 01, 01, 01, 001);
            StringLineIndexLevelPair<string, int, int, int, DateTime> target =
                new StringLineIndexLevelPair<string, int, int, int, DateTime>("Test", 1, 2, 3, date);
            Assert.AreEqual("Test", target.String);
            Assert.AreEqual(1, target.Index);
            Assert.AreEqual(2, target.Line);
            Assert.AreEqual(3, target.Level);
            Assert.AreEqual(date, target.DateTime);
        }

        /// <summary>
        ///A test for DateTime
        ///</summary>
        [TestMethod()]
        public void DateTimeTest()
        {
            DateTime expected = new DateTime(2013, 10, 02, 01, 01, 01, 001);
            StringLineIndexLevelPair<string, int, int, int, DateTime> target =
                new StringLineIndexLevelPair<string, int, int, int, DateTime>("Test", 1, 2, 3, expected);
            DateTime actual;
            target.DateTime = expected;
            actual = target.DateTime;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Index
        ///</summary>
        [TestMethod()]
        public void IndexTest()
        {
            DateTime date = new DateTime(2013, 10, 02, 01, 01, 01, 001);
            StringLineIndexLevelPair<string, int, int, int, DateTime> target =
                new StringLineIndexLevelPair<string, int, int, int, DateTime>("Test", 1, 2, 3, date);
            int expected = 1;
            int actual;
            target.Index = expected;
            actual = target.Index;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Level
        ///</summary>
        [TestMethod()]
        public void LevelTest()
        {
            DateTime date = new DateTime(2013, 10, 02, 01, 01, 01, 001);
            StringLineIndexLevelPair<string, int, int, int, DateTime> target =
                new StringLineIndexLevelPair<string, int, int, int, DateTime>("Test", 1, 2, 3, date);
            int expected = 1;
            int actual;
            target.Level = expected;
            actual = target.Level;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Line
        ///</summary>
        [TestMethod()]
        public void LineTest()
        {
            DateTime date = new DateTime(2013, 10, 02, 01, 01, 01, 001);
            StringLineIndexLevelPair<string, int, int, int, DateTime> target =
                new StringLineIndexLevelPair<string, int, int, int, DateTime>("Test", 1, 2, 3, date);
            int expected = 1;
            int actual;
            target.Line = expected;
            actual = target.Line;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for String
        ///</summary>
        [TestMethod()]
        public void StringTest()
        {
            DateTime date = new DateTime(2013, 10, 02, 01, 01, 01, 001);
            StringLineIndexLevelPair<string, int, int, int, DateTime> target =
                new StringLineIndexLevelPair<string, int, int, int, DateTime>("Test", 1, 2, 3, date);
            string expected = string.Empty;
            string actual;
            target.String = expected;
            actual = target.String;
            Assert.AreEqual(expected, actual);
        }
    }
}
