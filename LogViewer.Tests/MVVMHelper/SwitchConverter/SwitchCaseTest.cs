using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for SwitchCaseTest and is intended
    ///to contain all SwitchCaseTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SwitchCaseTest
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
        ///A test for Then
        ///</summary>
        [TestMethod()]
        public void ThenTest()
        {
            SwitchCase target = new SwitchCase();
            object expected = null; 
            object actual;
            target.Then = expected;
            actual = target.Then;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for When
        ///</summary>
        [TestMethod()]
        public void WhenTest()
        {
            SwitchCase target = new SwitchCase(); 
            object expected = null; 
            object actual;
            target.When = expected;
            actual = target.When;
            Assert.AreEqual(expected, actual);
        }
    }
}
