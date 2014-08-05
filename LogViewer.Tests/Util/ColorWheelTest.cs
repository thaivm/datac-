using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using LogViewer.Util;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for ColorWheelTest and is intended
    ///to contain all ColorWheelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ColorWheelTest
    {
        public static ColorWheel_Accessor target;

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


        public void ColorWheelConstructor()
        {
            ColorPicker_Accessor picker = new ColorPicker_Accessor();
            Rectangle colorRectangle = new Rectangle(picker.pnlColor.Location, picker.pnlColor.Size); // TODO: Initialize to an appropriate value
            Rectangle brightnessRectangle = new Rectangle(picker.pnlBrightness.Location, picker.pnlBrightness.Size); // TODO: Initialize to an appropriate value
            Rectangle selectedColorRectangle = new Rectangle(picker.pnlSelectedColor.Location, picker.pnlSelectedColor.Size); // TODO: Initialize to an appropriate value
            
            //target
            target = new ColorWheel_Accessor(colorRectangle, brightnessRectangle, selectedColorRectangle);
            target.ColorChanged += new ColorWheel.ColorChangedEventHandler(picker.myColorWheel_ColorChanged);
        }

        /// <summary>
        ///A test for ColorWheel Constructor
        ///</summary>
        [TestMethod()]
        public void ColorWheelConstructorTest()
        {
            ColorWheelConstructor();
        }

        /// <summary>
        ///A test for CalcBrightnessPoint
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CalcBrightnessPointTest()
        {
            ColorWheelConstructor();            
            var brightness = 10;
            Point expected = new Point(target.brightnessX,
                (int)(target.brightnessMax - brightness / target.brightnessScaling)); ; // TODO: Initialize to an appropriate value
            Point actual = target.CalcBrightnessPoint(brightness);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CalcCoordsAndUpdate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CalcCoordsAndUpdateTest()
        {
            ColorWheelConstructor();
            ColorHandler.HSV HSV = new ColorHandler.HSV(); // TODO: Initialize to an appropriate value
            target.CalcCoordsAndUpdate(HSV);
            
            //color Point
            var expectedColorPoint = target.GetPoint((double)HSV.Hue / 255 * 360,
                (double)HSV.Saturation / 255 * target.radius, target.centerPoint);
            var actualColorPoint = target.colorPoint;
            Assert.AreEqual(expectedColorPoint, actualColorPoint);

            //brightnessPoint
            var expectedBrightnessPoint = target.CalcBrightnessPoint(HSV.value);
            var actualBrightnessPoint = target.brightnessPoint;
            Assert.AreEqual(expectedBrightnessPoint, actualBrightnessPoint);

            //brightness
            var expectedBrightness = HSV.value;
            var actualBrightness = target.brightness;
            Assert.AreEqual(expectedBrightness, actualBrightness);

            //selectedColor
            var expectedSelectedColor = ColorHandler.HSVtoColor(HSV);
            var actualSelectedColor = target.selectedColor;
            Assert.AreEqual(expectedSelectedColor, actualSelectedColor);

            //RGB
            var expectedRGB = ColorHandler.HSVtoRGB(HSV);
            var actualRGB = target.RGB;
            Assert.AreEqual(expectedRGB, actualRGB);

            //fullColor
            var expectedFullColor = ColorHandler.HSVtoColor(HSV.Hue, HSV.Saturation, 255);
            var actualFullColor = target.fullColor;
            Assert.AreEqual(expectedFullColor, actualFullColor);
        }

        /// <summary>
        ///A test for CalcDegrees - X = 0 and Y > 0
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CalcDegrees_X0YGreater0Test()
        {
            ColorWheelConstructor();
            Point pt = new Point(0, 1); // TODO: Initialize to an appropriate value
            int expected = 270; // TODO: Initialize to an appropriate value
            int actual = target.CalcDegrees(pt);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CalcDegrees - X = 0 and Y < 0
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CalcDegrees_X0YLess0Test()
        {
            ColorWheelConstructor();
            Point pt = new Point(0, -1); // TODO: Initialize to an appropriate value
            int expected = 90; // TODO: Initialize to an appropriate value
            int actual = target.CalcDegrees(pt);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CalcDegrees - X > 0
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CalcDegrees_XGreater0Test()
        {
            ColorWheelConstructor();
            Point pt = new Point(1, 0); // TODO: Initialize to an appropriate value
            int expected = (int)(-Math.Atan((double)pt.Y / pt.X) * (180.0 / Math.PI));
            expected = (expected + 360) % 360;
            int actual = target.CalcDegrees(pt);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CalcDegrees - X < 0
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CalcDegrees_XLess0Test()
        {
            ColorWheelConstructor();
            Point pt = new Point(-1, 0); // TODO: Initialize to an appropriate value
            int expected = (int)(-Math.Atan((double)pt.Y / pt.X) * (180.0 / Math.PI));
            expected += 180;
            int actual = target.CalcDegrees(pt);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CreateGradient
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CreateGradientTest()
        {
            ColorWheelConstructor();
            target.CreateGradient();
        }

        /// <summary>
        ///A test for Draw - HSV
        ///</summary>
        [TestMethod()]
        public void Draw_HSVTest()
        {
            ColorWheelConstructor();
            Graphics g = Graphics.FromImage(target.colorImage);
            ColorHandler.HSV HSV = new ColorHandler.HSV(); // TODO: Initialize to an appropriate value
            target.Draw(g, HSV);
        }

        /// <summary>
        ///A test for Draw - mousePoint - currentState = MouseUp - mousePoint is not empty - colorRegion is visible
        ///</summary>
        [TestMethod()]
        public void Draw_mousePoint_MouseUp_mousePointNotEmpty_colorRegionVisibleTest()
        {
            ColorWheelConstructor();
            Graphics g = Graphics.FromImage(target.colorImage);
            Point mousePoint = new Point(100, 150); // TODO: Initialize to an appropriate value
            target.currentState = ColorWheel.MouseState.MouseUp;
            target.colorRegion = new Region(new Rectangle(100, 150, 200, 300));
            target.Draw(g, mousePoint);
            Assert.AreEqual(target.currentState, ColorWheel.MouseState.DragInColor);
        }

        /// <summary>
        ///A test for Draw - mousePoint - currentState = MouseUp - mousePoint is not empty -  brightnessRegion is visible
        ///</summary>
        [TestMethod()]
        public void Draw_mousePoint_MouseUp_mousePointNotEmpty_brightnessRegionVisibleTest()
        {
            ColorWheelConstructor();
            Graphics g = Graphics.FromImage(target.colorImage);
            Point mousePoint = new Point(100, 200); // TODO: Initialize to an appropriate value
            target.currentState = ColorWheel.MouseState.MouseUp;
            target.brightnessRegion = new Region(new Rectangle(100, 200, 200, 300));
            target.Draw(g, mousePoint);
            Assert.AreEqual(target.currentState, ColorWheel.MouseState.DragInBrightness);
        }

        /// <summary>
        ///A test for Draw - mousePoint - currentState = MouseUp - mousePoint is not empty -  outsideRegion is visible
        ///</summary>
        [TestMethod()]
        public void Draw_mousePoint_MouseUp_mousePointNotEmpty_outsideRegionVisibleTest()
        {
            ColorWheelConstructor();
            Graphics g = Graphics.FromImage(target.colorImage);
            Point mousePoint = new Point(100, 200); // TODO: Initialize to an appropriate value
            target.currentState = ColorWheel.MouseState.MouseUp;
            target.Draw(g, mousePoint);
            Assert.AreEqual(target.currentState, ColorWheel.MouseState.DragOutsideRegion);
        }

        /// <summary>
        ///A test for Draw - ClickOnBrightness - Min
        ///</summary>
        [TestMethod()]
        public void Draw_ClickOnBrightness_MinTest()
        {
            ColorWheelConstructor();
            Graphics g = Graphics.FromImage(target.colorImage);
            Point mousePoint = new Point(100, 200); // TODO: Initialize to an appropriate value
            target.currentState = ColorWheel.MouseState.ClickOnBrightness;
            target.brightnessMin = 210;
            target.brightnessMax = 250;
            target.Draw(g, mousePoint);
            var expected = new Point(target.brightnessX, 210);
            Assert.AreEqual(expected, target.brightnessPoint);
        }

        /// <summary>
        ///A test for Draw - ClickOnBrightness - Max
        ///</summary>
        [TestMethod()]
        public void Draw_ClickOnBrightness_MaxTest()
        {
            ColorWheelConstructor();
            Graphics g = Graphics.FromImage(target.colorImage);
            Point mousePoint = new Point(100, 210); // TODO: Initialize to an appropriate value
            target.currentState = ColorWheel.MouseState.ClickOnBrightness;
            target.brightnessMax = 200;
            target.Draw(g, mousePoint);
            var expected = new Point(target.brightnessX, 200);
            Assert.AreEqual(expected, target.brightnessPoint);
        }

        /// <summary>
        ///A test for Draw - DragInBrightness - Min
        ///</summary>
        [TestMethod()]
        public void Draw_DragInBrightness_MinTest()
        {
            ColorWheelConstructor();
            Graphics g = Graphics.FromImage(target.colorImage);
            Point mousePoint = new Point(100, 200); // TODO: Initialize to an appropriate value
            target.currentState = ColorWheel.MouseState.DragInBrightness;
            target.brightnessMin = 210;
            target.brightnessMax = 250;
            target.Draw(g, mousePoint);
            var expected = new Point(target.brightnessX, 210);
            Assert.AreEqual(expected, target.brightnessPoint);
        }

        /// <summary>
        ///A test for Draw - DragInBrightness - Max
        ///</summary>
        [TestMethod()]
        public void Draw_DragInBrightness_MaxTest()
        {
            ColorWheelConstructor();
            Graphics g = Graphics.FromImage(target.colorImage);
            Point mousePoint = new Point(100, 210); // TODO: Initialize to an appropriate value
            target.currentState = ColorWheel.MouseState.DragInBrightness;
            target.brightnessMax = 200;
            target.Draw(g, mousePoint);
            var expected = new Point(target.brightnessX, 200);
            Assert.AreEqual(expected, target.brightnessPoint);
        }

        /// <summary>
        ///A test for Draw - ClickOnColor
        ///</summary>
        [TestMethod()]
        public void Draw_ClickOnColorTest()
        {
            ColorWheelConstructor();
            Graphics g = Graphics.FromImage(target.colorImage);
            Point mousePoint = new Point(100, 150); // TODO: Initialize to an appropriate value
            target.currentState = ColorWheel.MouseState.ClickOnColor;
            target.Draw(g, mousePoint);
            Assert.AreEqual(mousePoint, target.colorPoint);
            Assert.AreEqual(target.currentState, ColorWheel.MouseState.DragInColor);
        }

        /// <summary>
        ///A test for Draw - DragInColor - distance < 1
        ///</summary>
        [TestMethod()]
        public void Draw_DragInColor_distanceLess1Test()
        {
            ColorWheelConstructor();
            Graphics g = Graphics.FromImage(target.colorImage);
            Point mousePoint = new Point(100, 150); // TODO: Initialize to an appropriate value
            target.currentState = ColorWheel.MouseState.DragInColor;
            target.Draw(g, mousePoint);
            Assert.AreEqual(mousePoint, target.colorPoint);
        }

        /// <summary>
        ///A test for Draw - DragInColor - distance > 1
        ///</summary>
        [TestMethod()]
        public void Draw_DragInColor_distanceGreater1Test()
        {
            ColorWheelConstructor();
            Graphics g = Graphics.FromImage(target.colorImage);
            Point mousePoint = new Point(10, 200); // TODO: Initialize to an appropriate value
            target.currentState = ColorWheel.MouseState.DragInColor;
            
            //expected
            var delta = new Point(
                    mousePoint.X - target.centerPoint.X, mousePoint.Y - target.centerPoint.Y);
            var degrees = target.CalcDegrees(delta);
            var expected = target.GetPoint(degrees, target.radius, target.centerPoint);

            target.Draw(g, mousePoint);
            Assert.AreEqual(expected, target.colorPoint);
        }

        /// <summary>
        ///A test for Draw - RGB
        ///</summary>
        [TestMethod()]
        public void Draw_RGBTest()
        {
            ColorWheelConstructor();
            Graphics g = Graphics.FromImage(target.colorImage);
            ColorHandler.RGB RGB = new ColorHandler.RGB(); // TODO: Initialize to an appropriate value
            target.Draw(g, RGB);
        }

        /// <summary>
        ///A test for DrawBrightnessPointer
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DrawBrightnessPointerTest()
        {
            ColorWheelConstructor();
            target.g = Graphics.FromImage(target.colorImage);
            Point pt = new Point(100, 200); // TODO: Initialize to an appropriate value
            target.DrawBrightnessPointer(pt);
        }

        /// <summary>
        ///A test for DrawColorPointer
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DrawColorPointerTest()
        {
            ColorWheelConstructor();
            target.g = Graphics.FromImage(target.colorImage);
            Point pt = new Point(100, 200); // TODO: Initialize to an appropriate value
            target.DrawColorPointer(pt);
        }

        /// <summary>
        ///A test for DrawLinearGradient
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DrawLinearGradientTest()
        {
            ColorWheelConstructor();
            target.g = Graphics.FromImage(target.colorImage);
            Color c = new Color();
            target.DrawLinearGradient(c);
        }

        /// <summary>
        ///A test for GetColors
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void GetColorsTest()
        {
            ColorWheelConstructor();
            Assert.AreEqual(6*256, target.GetColors().Length);
        }

        /// <summary>
        ///A test for GetPoint
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void GetPointTest()
        {
            ColorWheelConstructor();
            double degrees = 0F; // TODO: Initialize to an appropriate value
            double radius = 0F; // TODO: Initialize to an appropriate value
            var radians = degrees / (180.0 / Math.PI);
            Point expected = new Point((int)(target.centerPoint.X + Math.Floor(radius * Math.Cos(radians))),
            (int)(target.centerPoint.Y - Math.Floor(radius * Math.Sin(radians)))); // TODO: Initialize to an appropriate value
            Point actual= target.GetPoint(degrees, radius, target.centerPoint);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetPoints
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void GetPointsTest()
        {
            ColorWheelConstructor();
            Assert.AreEqual(6 * 256, target.GetPoints(target.radius, target.centerPoint).Length);
        }

        /// <summary>
        ///A test for OnColorChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void OnColorChangedTest()
        {
            ColorWheelConstructor();
            ColorHandler.RGB RGB = new ColorHandler.RGB(); // TODO: Initialize to an appropriate value
            ColorHandler.HSV HSV = new ColorHandler.HSV(); // TODO: Initialize to an appropriate value
            target.OnColorChanged(RGB, HSV);
        }

        /// <summary>
        ///A test for SetMouseUp
        ///</summary>
        [TestMethod()]
        public void SetMouseUpTest()
        {
            ColorWheelConstructor();
            target.SetMouseUp();
            Assert.AreEqual(ColorWheel.MouseState.MouseUp, target.currentState);
        }

        /// <summary>
        ///A test for System.IDisposable.Dispose - colorImage
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Dispose_colorImageTest()
        {
            ColorWheelConstructor();
            target.colorImage = new Bitmap(10, 20);
            IDisposable IDisposable = target;
            IDisposable.Dispose();
        }

        /// <summary>
        ///A test for System.IDisposable.Dispose - colorRegion
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Dispose_colorRegionTest()
        {
            ColorWheelConstructor();
            target.colorRegion = new Region();
            IDisposable IDisposable = target;
            IDisposable.Dispose();
        }

        /// <summary>
        ///A test for System.IDisposable.Dispose - brightnessRegion
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Dispose_brightnessRegionTest()
        {
            ColorWheelConstructor();
            target.brightnessRegion = new Region();
            IDisposable IDisposable = target;
            IDisposable.Dispose();
        }

        /// <summary>
        ///A test for System.IDisposable.Dispose - g
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Dispose_GraphTest()
        {
            ColorWheelConstructor();
            target.g = Graphics.FromImage(target.colorImage);
            IDisposable IDisposable = target;
            IDisposable.Dispose();
        }

        /// <summary>
        ///A test for UpdateDisplay
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void UpdateDisplayTest()
        {
            ColorWheelConstructor();
            target.g = Graphics.FromImage(target.colorImage);
            target.UpdateDisplay();
        }

        /// <summary>
        ///A test for Color
        ///</summary>
        [TestMethod()]
        public void ColorTest()
        {
            ColorWheelConstructor();
            target.selectedColor = Color.Red;
            Assert.AreEqual(Color.Red, target.Color);
        }
    }
}
