using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Windows.Media;
using LogViewer.Model;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for ProtobyteToDrawingConverterTest and is intended
    ///to contain all ProtobyteToDrawingConverterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProtobyteToDrawingConverterTest
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
        public void ConvertBlackCircleTest()
        {
            ProtobyteToDrawingConverter target = new ProtobyteToDrawingConverter();
            object value = Prototype.BlackCircle; 
            Type targetType = null; 
            object parameter = null;
            CultureInfo culture = null;
            object actual;
            actual = target.Convert(value, targetType, parameter, culture);
            Assert.IsInstanceOfType(actual, typeof(GeometryDrawing));
        }
        [TestMethod()]
        public void ConvertBlackSquareTest()
        {
            ProtobyteToDrawingConverter target = new ProtobyteToDrawingConverter();
            object value = Prototype.BlackSquare;
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object actual;
            actual = target.Convert(value, targetType, parameter, culture);
            Assert.IsInstanceOfType(actual, typeof(GeometryDrawing));
        }
        [TestMethod()]
        public void ConvertBlackStarTest()
        {
            ProtobyteToDrawingConverter target = new ProtobyteToDrawingConverter();
            object value = Prototype.BlackStar;
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object actual;
            actual = target.Convert(value, targetType, parameter, culture);
            Assert.IsInstanceOfType(actual, typeof(GeometryDrawing));
        }
        [TestMethod()]
        public void ConvertBlackTriangleTest()
        {
            ProtobyteToDrawingConverter target = new ProtobyteToDrawingConverter();
            object value = Prototype.BlackTriangle;
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object actual;
            actual = target.Convert(value, targetType, parameter, culture);
            Assert.IsInstanceOfType(actual, typeof(GeometryDrawing));
        }
        [TestMethod()]
        public void ConvertWhiteSquareTest()
        {
            ProtobyteToDrawingConverter target = new ProtobyteToDrawingConverter();
            object value = Prototype.WhiteSquare;
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object actual;
            actual = target.Convert(value, targetType, parameter, culture);
            Assert.IsInstanceOfType(actual, typeof(GeometryDrawing));
        }
        [TestMethod()]
        public void ConvertWhiteStarTest()
        {
            ProtobyteToDrawingConverter target = new ProtobyteToDrawingConverter();
            object value = Prototype.WhiteStar;
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object actual;
            actual = target.Convert(value, targetType, parameter, culture);
            Assert.IsInstanceOfType(actual, typeof(GeometryDrawing));
        }
        [TestMethod()]
        public void ConvertWhiteTriangleTest()
        {
            ProtobyteToDrawingConverter target = new ProtobyteToDrawingConverter();
            object value = Prototype.WhiteTriangle;
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object actual;
            actual = target.Convert(value, targetType, parameter, culture);
            Assert.IsInstanceOfType(actual, typeof(GeometryDrawing));
        }
        [TestMethod()]
        [ExpectedException(typeof(NotSupportedException))]
        public void ConvertNotSupportedExceptionTest()
        {
            ProtobyteToDrawingConverter target = new ProtobyteToDrawingConverter();
            object value = 8;
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object actual;
            actual = target.Convert(value, targetType, parameter, culture);
        }
        
        /// <summary>
        ///A test for ConvertBack
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void ConvertBackTest()
        {
            ProtobyteToDrawingConverter target = new ProtobyteToDrawingConverter();
            object value = null;
            Type targetType = null;
            object parameter = null;
            CultureInfo culture = null;
            object actual;
            actual = target.ConvertBack(value, targetType, parameter, culture);
        }

        /// <summary>
        ///A test for CreateGeometryDrawing
        ///</summary>
        [TestMethod()]
        public void CreateGeometryDrawingTest()
        {
            GeometryDrawing drawing = null;
            Geometry geometry = null; 
            Color color = new Color();
            ProtobyteToDrawingConverter_Accessor.CreateGeometryDrawing(out drawing, geometry, color);
            Assert.IsNotNull(drawing);
        }
    }
}
