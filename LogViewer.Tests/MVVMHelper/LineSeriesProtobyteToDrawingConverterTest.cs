using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Windows.Media;
using System.Windows;
using LogViewer.Model;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for LineSeriesProtobyteToDrawingConverterTest and is intended
    ///to contain all LineSeriesProtobyteToDrawingConverterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LineSeriesProtobyteToDrawingConverterTest
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
            LineSeriesProtobyteToDrawingConverter target = new LineSeriesProtobyteToDrawingConverter();
            object[] values = null;
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = DependencyProperty.UnsetValue;
            object actual;
            actual = target.Convert(values, targetType, parameter, culture);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ConvertValueLengthLessThan2Test()
        {
            LineSeriesProtobyteToDrawingConverter target = new LineSeriesProtobyteToDrawingConverter();
            object[] values = new object[] { DependencyProperty.UnsetValue };
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = DependencyProperty.UnsetValue;
            object actual;
            actual = target.Convert(values, targetType, parameter, culture);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ConvertUnsetValueTest()
        {
            LineSeriesProtobyteToDrawingConverter target = new LineSeriesProtobyteToDrawingConverter();
            object[] values = new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = DependencyProperty.UnsetValue;
            object actual;
            actual = target.Convert(values, targetType, parameter, culture);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ConvertBlackSquarecolorCodeIsEmptyTest()
        {
            LineSeriesProtobyteToDrawingConverter target = new LineSeriesProtobyteToDrawingConverter();
            object[] values = new object[] { Prototype.BlackSquare, "" };
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = Prototype.BlackSquare;
            object actual;
            actual = target.Convert(values, targetType, parameter, culture);
            Assert.IsInstanceOfType(actual, typeof(GeometryDrawing));
        }
        [TestMethod()]
        public void ConvertBlackCirclecolorCodeIsNotEmptyTest()
        {
            LineSeriesProtobyteToDrawingConverter target = new LineSeriesProtobyteToDrawingConverter();
            object[] values = new object[] { Prototype.BlackCircle, "#000000" };
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = Prototype.BlackCircle;
            object actual;
            actual = target.Convert(values, targetType, parameter, culture);
            Assert.IsInstanceOfType(actual, typeof(GeometryDrawing));
        }
        [TestMethod()]
        public void ConvertWhiteCirclecolorCodeIsNotEmptyTest()
        {
            LineSeriesProtobyteToDrawingConverter target = new LineSeriesProtobyteToDrawingConverter();
            object[] values = new object[] { Prototype.WhiteCircle, "#000000" };
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = Prototype.WhiteCircle;
            object actual;
            actual = target.Convert(values, targetType, parameter, culture);
            Assert.IsInstanceOfType(actual, typeof(GeometryDrawing));
        }

        [TestMethod()]
        public void ConvertBlackSquarecolorCodeIsNotEmptyTest()
        {
            LineSeriesProtobyteToDrawingConverter target = new LineSeriesProtobyteToDrawingConverter();
            object[] values = new object[] { Prototype.BlackSquare, "#000000" };
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = Prototype.BlackSquare;
            object actual;
            actual = target.Convert(values, targetType, parameter, culture);
            Assert.IsInstanceOfType(actual, typeof(GeometryDrawing));
        }
        [TestMethod()]
        public void ConvertWhiteSquarecolorCodeIsNotEmptyTest()
        {
            LineSeriesProtobyteToDrawingConverter target = new LineSeriesProtobyteToDrawingConverter();
            object[] values = new object[] { Prototype.WhiteSquare, "#000000" };
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = Prototype.WhiteSquare;
            object actual;
            actual = target.Convert(values, targetType, parameter, culture);
            Assert.IsInstanceOfType(actual, typeof(GeometryDrawing));
        }

        [TestMethod()]
        public void ConvertBlackStarcolorCodeIsNotEmptyTest()
        {
            LineSeriesProtobyteToDrawingConverter target = new LineSeriesProtobyteToDrawingConverter();
            object[] values = new object[] { Prototype.BlackStar, "#000000" };
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = Prototype.BlackStar;
            object actual;
            actual = target.Convert(values, targetType, parameter, culture);
            Assert.IsInstanceOfType(actual, typeof(GeometryDrawing));
        }
        [TestMethod()]
        public void ConvertWhiteStarcolorCodeIsNotEmptyTest()
        {
            LineSeriesProtobyteToDrawingConverter target = new LineSeriesProtobyteToDrawingConverter();
            object[] values = new object[] { Prototype.WhiteStar, "#000000" };
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = Prototype.WhiteStar;
            object actual;
            actual = target.Convert(values, targetType, parameter, culture);
            Assert.IsInstanceOfType(actual, typeof(GeometryDrawing));
        }

        [TestMethod()]
        public void ConvertBlackTrianglecolorCodeIsNotEmptyTest()
        {
            LineSeriesProtobyteToDrawingConverter target = new LineSeriesProtobyteToDrawingConverter();
            object[] values = new object[] { Prototype.BlackTriangle, "#000000" };
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = Prototype.BlackTriangle;
            object actual;
            actual = target.Convert(values, targetType, parameter, culture);
            Assert.IsInstanceOfType(actual, typeof(GeometryDrawing));
        }
        [TestMethod()]
        public void ConvertWhiteTrianglecolorCodeIsNotEmptyTest()
        {
            LineSeriesProtobyteToDrawingConverter target = new LineSeriesProtobyteToDrawingConverter();
            object[] values = new object[] { Prototype.WhiteTriangle, "#000000" };
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = Prototype.WhiteTriangle;
            object actual;
            actual = target.Convert(values, targetType, parameter, culture);
            Assert.IsInstanceOfType(actual, typeof(GeometryDrawing));
        }

        [TestMethod()]
        [ExpectedException(typeof(NotSupportedException))]
        public void ConvertNotSupportedExceptionTest()
        {
            LineSeriesProtobyteToDrawingConverter target = new LineSeriesProtobyteToDrawingConverter();
            object[] values = new object[] { 8, "#000000" };
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object expected = Prototype.WhiteTriangle;
            object actual;
            actual = target.Convert(values, targetType, parameter, culture);
        }
        /// <summary>
        ///A test for ConvertBack
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void ConvertBackTest()
        {
            LineSeriesProtobyteToDrawingConverter target = new LineSeriesProtobyteToDrawingConverter(); // TODO: Initialize to an appropriate value
            object value = null;
            Type[] targetTypes = null;
            object parameter = null; 
            CultureInfo culture = null;
            object[] actual;
            actual = target.ConvertBack(value, targetTypes, parameter, culture);
        }

        /// <summary>
        ///A test for CreateGeometryDrawing
        ///</summary>
        [TestMethod()]
        public void CreateGeometryDrawingTest()
        {
            Geometry geometry = new EllipseGeometry(new Point(23, 0), 23, 23); 
            Color color = new Color();
            var actual = LineSeriesProtobyteToDrawingConverter_Accessor.CreateGeometryDrawing(geometry, color);
            Assert.IsInstanceOfType(actual, typeof(GeometryDrawing));
        }
    }
}
