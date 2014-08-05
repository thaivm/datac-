using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for FractionToDoubleConverterTest and is intended
    ///to contain all FractionToDoubleConverterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FractionToDoubleConverterTest
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
        ///A test for FractionToDoubleConverter Constructor
        ///</summary>
        [TestMethod()]
        public void FractionToDoubleConverterConstructorTest()
        {
            FractionToDoubleConverter target = new FractionToDoubleConverter();
        }

        /// <summary>
        ///A test for Convert
        ///</summary>
        [TestMethod()]
        public void ConvertTest()
        {
            FractionToDoubleConverter target = new FractionToDoubleConverter();
            object value = new object();
            Type targetType = null; 
            object parameter = null; 
            CultureInfo culture = null;
            object expected = new object();
            object actual;
            actual = target.Convert(value, targetType, parameter, culture);
            Assert.AreEqual(expected.ToString(), actual);
        }

        /// <summary>
        ///A test for ConvertBack
        ///</summary>
        [TestMethod()]
        //[ExpectedException(typeof(Exception), "FormatException")]
        public void ConvertBackTryParseTrueTest()
        {
            FractionToDoubleConverter target = new FractionToDoubleConverter();
            string value = "1";
            Type targetType = null; 
            object parameter = null; 
            CultureInfo culture = null;
            object expected = 1.0D;
            object actual;
            actual = target.ConvertBack(value, targetType, parameter, culture);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ConvertBackTryParseTrueReturnNullTest()
        {
            FractionToDoubleConverter target = new FractionToDoubleConverter();
            string value = "abc";
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = null;
            object actual;
            actual = target.ConvertBack(value, targetType, parameter, culture);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ConvertBackSplitLengthEqual2TreParseFailureTest()
        {
            FractionToDoubleConverter target = new FractionToDoubleConverter();
            string value = "1/abc";
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = null;
            object actual;
            actual = target.ConvertBack(value, targetType, parameter, culture);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ConvertBackSplitLengthEqual2TreParseSuccessTest()
        {
            FractionToDoubleConverter target = new FractionToDoubleConverter();
            string value = "1/1";
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = 1D;
            object actual;
            actual = target.ConvertBack(value, targetType, parameter, culture);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ConvertBackSplitLengthEqual3TreParseSuccessTest()
        {
            FractionToDoubleConverter target = new FractionToDoubleConverter();
            string value = "1/1/1";
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = 2D;
            object actual;
            actual = target.ConvertBack(value, targetType, parameter, culture);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ConvertBackSplitLengthEqual3TreParseFailureTest()
        {
            FractionToDoubleConverter target = new FractionToDoubleConverter();
            string value = "1/1/a";
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = null;
            object actual;
            actual = target.ConvertBack(value, targetType, parameter, culture);
            Assert.AreEqual(expected, actual);
        }
    }
}
