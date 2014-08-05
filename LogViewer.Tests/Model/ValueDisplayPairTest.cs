using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for ValueDisplayPairTest and is intended
    ///to contain all ValueDisplayPairTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ValueDisplayPairTest
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
        ///A test for ValueDisplayPair`0 Constructor
        ///</summary>
        [TestMethod()]
        public void ValueDisplayPairConstructor0Test()
        {
            ValueDisplayPair<string, int> target = new ValueDisplayPair<string, int>();
        }

        /// <summary>
        ///A test for ValueDisplayPair`2 Constructor
        ///</summary>
        [TestMethod()]
        public void ValueDisplayPairConstructor2Test()
        {
            ValueDisplayPair<string, int> target = new ValueDisplayPair<string, int>("1", 2);
            Assert.AreEqual("1", target.Value);
            Assert.AreEqual(2, target.Display);
        }

        /// <summary>
        ///A test for Display
        ///</summary>
        [TestMethod()]
        public void DisplayTest()
        {
            ValueDisplayPair<string, int> target = new ValueDisplayPair<string, int>();// TODO: Initialize to an appropriate value
            int expected = 1; // TODO: Initialize to an appropriate value
            int actual;
            target.Display = expected;
            actual = target.Display;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Value
        ///</summary>
        [TestMethod()]
        public void ValueTest()
        {
            ValueDisplayPair<string, int> target = new ValueDisplayPair<string, int>();// TODO: Initialize to an appropriate value
            string expected = "1"; // TODO: Initialize to an appropriate value
            string actual;
            target.Value = expected;
            actual = target.Value;
            Assert.AreEqual(expected, actual);
        }
    }
}
