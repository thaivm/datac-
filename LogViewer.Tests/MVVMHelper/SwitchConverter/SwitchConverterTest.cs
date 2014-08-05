using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for SwitchConverterTest and is intended
    ///to contain all SwitchConverterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SwitchConverterTest
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
        public void ConvertValueIsNullTest()
        {
            SwitchConverter target = new SwitchConverter();
            object value = null;
            Type targetType = null; 
            object parameter = null; 
            CultureInfo culture = null; 
            object expected = null; 
            object actual;
            actual = target.Convert(value, targetType, parameter, culture);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod()]
        public void ConvertValueNotNullTest()
        {
            SwitchCaseCollection cases = new SwitchCaseCollection();
            SwitchCase cs = new SwitchCase();
            cs.When = "test";
            cs.Then = "return test";
            cases.Add(cs);
            SwitchConverter target = new SwitchConverter(cases);

            string value = "test";
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object actual;
            actual = target.Convert(value, targetType, parameter, culture);
            Assert.AreEqual("return test", actual);

        }
        [TestMethod()]
        public void ConvertValueReturnNullNullTest()
        {
            SwitchConverter target = new SwitchConverter();

            string value = "test";
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = null;
            object actual;
            actual = target.Convert(value, targetType, parameter, culture);
            Assert.AreEqual(expected, actual);

        }
        /// <summary>
        ///A test for ConvertBack
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NotSupportedException))]
        public void ConvertBackValueIsStringTest()
        {
            SwitchCaseCollection cases = new SwitchCaseCollection();
            SwitchCase cs = new SwitchCase();
            cs.When = "test";
            cs.Then = "return test";
            cases.Add(cs);
            SwitchConverter target = new SwitchConverter(cases);
            string abc = "abc";
            object value = (object)abc; 
            Type targetType = null; 
            object parameter = null; 
            CultureInfo culture = null; 
            object actual;
            actual = target.ConvertBack(value, targetType, parameter, culture);
        }
        [TestMethod()]
        public void ConvertBackValueIsStringValueEqualThenTest()
        {
            SwitchCaseCollection cases = new SwitchCaseCollection();
            SwitchCase cs = new SwitchCase();
            cs.When = "test";
            cs.Then = "test";
            cases.Add(cs);
            SwitchConverter target = new SwitchConverter(cases);
            string abc = "test";
            object value = (object)abc;
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = "test";
            object actual;
            actual = target.ConvertBack(value, targetType, parameter, culture);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ConvertBackTryConvertValueIsStringValueEqualThenTest()
        {
            SwitchCaseCollection cases = new SwitchCaseCollection();
            SwitchCase cs = new SwitchCase();
            cs.When = 1;
            cs.Then = 1;
            cases.Add(cs);
            SwitchConverter target = new SwitchConverter(cases);
            int abc = 1;
            object value = (object)abc;
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = 1;
            object actual;
            actual = target.ConvertBack(value, targetType, parameter, culture);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for TryConvert
        ///</summary>
        [TestMethod()]
        public void TryConvertCompareEnumTest()
        {
            CultureInfo culture = null;
            E e = E.A;
            bool expected = true; 
            bool actual;
            int value2 = 1;
            object value = (object)value2;
            actual = SwitchConverter_Accessor.TryConvert(culture, (object)e, ref value);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void TryConvertCompareNotEnumTest()
        {
            CultureInfo culture = null;
            E e = E.A;
            string value1 = e.ToString();
            bool expected = true;
            bool actual;
            int value2 = 1;
            object value = (object)value2;
            actual = SwitchConverter_Accessor.TryConvert(culture, (object)value1, ref value);
            Assert.AreEqual(expected, actual);
        }
        enum E { A = 1 };
        enum F { A = 1 };
        [TestMethod()]
        public void TryConvertType1EqualType2Test()
        {
            CultureInfo culture = null;
            string value1 = "test1";
            string value2 = "test2";
            bool expected = true;
            bool actual;
            object value = (object)value2;
            actual = SwitchConverter_Accessor.TryConvert(culture, (object)value1, ref value);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for Cases
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CasesTest()
        {
            SwitchConverter_Accessor target = new SwitchConverter_Accessor(); // TODO: Initialize to an appropriate value
            SwitchCaseCollection expected = null; // TODO: Initialize to an appropriate value
            SwitchCaseCollection actual;
            target.Cases = expected;
            actual = target.Cases;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Else
        ///</summary>
        [TestMethod()]
        public void ElseTest()
        {
            SwitchConverter target = new SwitchConverter(); // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            target.Else = expected;
            actual = target.Else;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for StringComparison
        ///</summary>
        [TestMethod()]
        public void StringComparisonTest()
        {
            SwitchConverter target = new SwitchConverter(); // TODO: Initialize to an appropriate value
            StringComparison expected = new StringComparison(); // TODO: Initialize to an appropriate value
            StringComparison actual;
            target.StringComparison = expected;
            actual = target.StringComparison;
            Assert.AreEqual(expected, actual);
        }
    }
}
