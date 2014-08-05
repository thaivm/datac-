using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for ErrorActionItemTest and is intended
    ///to contain all ErrorActionItemTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ErrorActionItemTest
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
        ///A test for ErrorCode
        ///</summary>
        [TestMethod()]
        public void ErrorCodeTest()
        {
            ErrorActionItem target = new ErrorActionItem(); 
            string expected = string.Empty;
            string actual;
            target.ErrorCode = expected;
            actual = target.ErrorCode;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ErrorLv
        ///</summary>
        [TestMethod()]
        public void ErrorLvTest()
        {
            ErrorActionItem target = new ErrorActionItem(); 
            string expected = string.Empty; 
            string actual;
            target.ErrorLv = expected;
            actual = target.ErrorLv;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ErrorMessage
        ///</summary>
        [TestMethod()]
        public void ErrorMessageTest()
        {
            ErrorActionItem target = new ErrorActionItem(); 
            string expected = string.Empty; 
            string actual;
            target.ErrorMessage = expected;
            actual = target.ErrorMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ErrorRecipe
        ///</summary>
        [TestMethod()]
        public void ErrorRecipeTest()
        {
            ErrorActionItem target = new ErrorActionItem(); 
            string expected = string.Empty; 
            string actual;
            target.ErrorRecipe = expected;
            actual = target.ErrorRecipe;
            Assert.AreEqual(expected, actual);
        }
    }
}
