using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Business;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for GraphRangeSettingTest and is intended
    ///to contain all GraphRangeSettingTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GraphRangeSettingTest
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
        ///A test for Copy
        ///</summary>
        [TestMethod()]
        public void CopyTest()
        {
            GraphRangeSetting target = new GraphRangeSetting();
            GraphRangeSetting expected = new GraphRangeSetting(); 
            GraphRangeSetting actual;
            actual = target.Copy();
            Assert.AreEqual(expected.From, actual.From);
            Assert.AreEqual(expected.To, actual.To);
            Assert.AreEqual(expected.FirstYRangeFrom, actual.FirstYRangeFrom);
            Assert.AreEqual(expected.FirstYRangeTo, actual.FirstYRangeTo);
            Assert.AreEqual(expected.SecondYRangeFrom, actual.SecondYRangeFrom);
            Assert.AreEqual(expected.SecondYRangeTo, actual.SecondYRangeTo);
        }

        /// <summary>
        ///A test for FirstYRangeFrom
        ///</summary>
        [TestMethod()]
        public void FirstYRangeFromTest()
        {
            GraphRangeSetting target = new GraphRangeSetting(); 
            double expected = 0F; 
            double actual;
            target.FirstYRangeFrom = expected;
            actual = target.FirstYRangeFrom;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FirstYRangeTo
        ///</summary>
        [TestMethod()]
        public void FirstYRangeToTest()
        {
            GraphRangeSetting target = new GraphRangeSetting(); 
            double expected = 0F; 
            double actual;
            target.FirstYRangeTo = expected;
            actual = target.FirstYRangeTo;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for From
        ///</summary>
        [TestMethod()]
        public void FromTest()
        {
            GraphRangeSetting target = new GraphRangeSetting(); 
            DateTime expected = new DateTime(); 
            DateTime actual;
            target.From = expected;
            actual = target.From;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SecondYRangeFrom
        ///</summary>
        [TestMethod()]
        public void SecondYRangeFromTest()
        {
            GraphRangeSetting target = new GraphRangeSetting(); 
            double expected = 0F; 
            double actual;
            target.SecondYRangeFrom = expected;
            actual = target.SecondYRangeFrom;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SecondYRangeTo
        ///</summary>
        [TestMethod()]
        public void SecondYRangeToTest()
        {
            GraphRangeSetting target = new GraphRangeSetting(); 
            double expected = 0F; 
            double actual;
            target.SecondYRangeTo = expected;
            actual = target.SecondYRangeTo;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for To
        ///</summary>
        [TestMethod()]
        public void ToTest()
        {
            GraphRangeSetting target = new GraphRangeSetting(); 
            DateTime expected = new DateTime(); 
            DateTime actual;
            target.To = expected;
            actual = target.To;
            Assert.AreEqual(expected, actual);
        }
    }
}
