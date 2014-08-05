using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for KeywordCountResultItemTest and is intended
    ///to contain all KeywordCountResultItemTest Unit Tests
    ///</summary>
    [TestClass()]
    public class KeywordCountResultItemTest
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
        ///A test for Count
        ///</summary>
        [TestMethod()]
        public void CountTest()
        {
            KeywordCountResultItem target = new KeywordCountResultItem(); // TODO: Initialize to an appropriate value
            ulong expected = 1; // TODO: Initialize to an appropriate value
            ulong actual;
            target.Count = expected;
            actual = target.Count;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            KeywordCountResultItem target = new KeywordCountResultItem(); // TODO: Initialize to an appropriate value
            string expected = "Test"; // TODO: Initialize to an appropriate value
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
        }
    }
}
