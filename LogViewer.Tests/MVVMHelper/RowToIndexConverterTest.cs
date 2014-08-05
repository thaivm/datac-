using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using Microsoft.Windows.Controls;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for RowToIndexConverterTest and is intended
    ///to contain all RowToIndexConverterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RowToIndexConverterTest
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
            RowToIndexConverter target = new RowToIndexConverter();
            object value = null; 
            Type targetType = null;
            object parameter = null; 
            CultureInfo culture = null; 
            object expected = -1;
            object actual;
            actual = target.Convert(value, targetType, parameter, culture);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertRowNotNullTest()
        {
            RowToIndexConverter target = new RowToIndexConverter();
            DataGridRow value = new DataGridRow();
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = 0;
            object actual;
            actual = target.Convert(value, targetType, parameter, culture);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for ConvertBack
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void ConvertBackTest()
        {
            RowToIndexConverter target = new RowToIndexConverter();
            object value = null;
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null; 
            object actual;
            actual = target.ConvertBack(value, targetType, parameter, culture);
     
        }

        /// <summary>
        ///A test for ProvideValue
        ///</summary>
        [TestMethod()]
        public void ProvideValueTest()
        {
            RowToIndexConverter target = new RowToIndexConverter();
            IServiceProvider serviceProvider = null; 
            object actual;
            actual = target.ProvideValue(serviceProvider);
            Assert.IsInstanceOfType(actual, typeof(RowToIndexConverter));
        }
    }
}
