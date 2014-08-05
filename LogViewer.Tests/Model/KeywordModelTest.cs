using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for KeywordModelTest and is intended
    ///to contain all KeywordModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class KeywordModelTest
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
        ///A test for Index
        ///</summary>
        [TestMethod()]
        public void IndexTest()
        {
            KeywordModel target = new KeywordModel(); // TODO: Initialize to an appropriate value
            int expected = 1; // TODO: Initialize to an appropriate value
            int actual;
            target.Index = expected;
            actual = target.Index;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Value - null
        ///</summary>
        [TestMethod()]
        public void ValueNullTest()
        {
            KeywordModel target = new KeywordModel(); // TODO: Initialize to an appropriate value
            string expected = null; // TODO: Initialize to an appropriate value
            string actual;
            target.Value = expected;
            actual = target.Value;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Value - not null
        ///</summary>
        [TestMethod()]
        public void ValueNotNullTest()
        {
            KeywordModel target = new KeywordModel(); // TODO: Initialize to an appropriate value
            string expected = "Test"; // TODO: Initialize to an appropriate value
            string actual;
            target.Value = expected;
            actual = target.Value;
            Assert.AreEqual(expected, actual);
        }
    }
}
