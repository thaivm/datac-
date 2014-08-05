using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Windows.Data;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for EnumToBooleanConverterTest and is intended
    ///to contain all EnumToBooleanConverterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EnumToBooleanConverterTest
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
        ///A test for EnumToBooleanConverter Constructor
        ///</summary>
        [TestMethod()]
        public void EnumToBooleanConverterConstructorTest()
        {
            EnumToBooleanConverter target = new EnumToBooleanConverter();
        }

        /// <summary>
        ///A test for Convert
        ///</summary>
        [TestMethod()]
        public void ConvertTest()
        {
            EnumToBooleanConverter target = new EnumToBooleanConverter(); 
            object value = new object(); 
            Type targetType = null;
            object parameter = new object();
            CultureInfo culture = null;
            Boolean expected = false; 
            object actual;
            actual = target.Convert(value, targetType, parameter, culture);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ConvertBack
        ///</summary>
        [TestMethod()]
        public void ConvertBackTest()
        {
            EnumToBooleanConverter target = new EnumToBooleanConverter();
            object value = new object(); 
            Type targetType = null;
            object parameter = new object(); 
            CultureInfo culture = null;
            object actual;
            actual = target.ConvertBack(value, targetType, parameter, culture);
            Assert.AreEqual("{Binding.DoNothing}", actual.ToString());
        }
    }
}
