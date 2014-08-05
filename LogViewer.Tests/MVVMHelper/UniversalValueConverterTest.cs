using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for UniversalValueConverterTest and is intended
    ///to contain all UniversalValueConverterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UniversalValueConverterTest
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
        ///A test for Convert
        ///</summary>
        [TestMethod()]
        public void ConvertTest()
        {
            UniversalValueConverter target = new UniversalValueConverter();
            object value = null; 
            String targetType = "";
            object parameter = null; 
            CultureInfo culture = null;
            object expected = null; 
            object actual;
            actual = target.Convert(value, targetType.GetType(), parameter, culture);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertIntTest()
        {
            UniversalValueConverter target = new UniversalValueConverter();
            object value = "1";
            int targetType = 1;
            object parameter = null;
            CultureInfo culture = null;
            object expected = 1;
            object actual;
            actual = target.Convert(value, targetType.GetType(), parameter, culture);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertIntTest1()
        {
            UniversalValueConverter target = new UniversalValueConverter();
            object value = 1;
            int targetType = 1;
            object parameter = null;
            CultureInfo culture = null;
            object expected = 1;
            object actual;
            actual = target.Convert(value, targetType.GetType(), parameter, culture);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for ConvertBack
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void ConvertBackTest()
        {
            UniversalValueConverter target = new UniversalValueConverter();
            object value = null;
            Type targetType = null;
            object parameter = null; 
            CultureInfo culture = null; 
            object actual;
            actual = target.ConvertBack(value, targetType, parameter, culture);
        }
    }
}
