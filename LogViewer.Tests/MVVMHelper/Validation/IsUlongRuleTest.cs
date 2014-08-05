using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Windows.Controls;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for IsUlongRuleTest and is intended
    ///to contain all IsUlongRuleTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IsUlongRuleTest
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
        ///A test for Validate
        ///</summary>
        [TestMethod()]
        public void ValidateTest()
        {
            IsUlongRule target = new IsUlongRule();
            object value = "1";
            CultureInfo cultureInfo = null;
            ValidationResult expected = new ValidationResult(true, null);
            ValidationResult actual;
            actual = target.Validate(value, cultureInfo);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ValidateFailureTest()
        {
            IsUlongRule target = new IsUlongRule();
            target.Message = "test";
            object value = "1asd";
            CultureInfo cultureInfo = null;
            ValidationResult expected = new ValidationResult(false, "test");
            ValidationResult actual;
            actual = target.Validate(value, cultureInfo);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Message
        ///</summary>
        [TestMethod()]
        public void MessageTest()
        {
            IsUlongRule target = new IsUlongRule();
            string expected = string.Empty;
            string actual;
            target.Message = expected;
            actual = target.Message;
            Assert.AreEqual(expected, actual);
        }
    }
}
