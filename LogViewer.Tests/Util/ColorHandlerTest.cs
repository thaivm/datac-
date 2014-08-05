using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Collections.Generic;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for ColorHandlerTest and is intended
    ///to contain all ColorHandlerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ColorHandlerTest
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
        ///A test for ColorHandler Constructor
        ///</summary>
        [TestMethod()]
        public void ColorHandlerConstructorTest()
        {
            ColorHandler target = new ColorHandler();
        }

        /// <summary>
        ///A test for ToString - RGB
        ///</summary>
        [TestMethod()]
        public void ToStringRGBTest()
        {
            ColorHandler.RGB RGB = new  ColorHandler.RGB();
            RGB.ToString();
        }

        /// <summary>
        ///A test for ToString - HSV
        ///</summary>
        [TestMethod()]
        public void ToStringHSVTest()
        {
            ColorHandler.HSV HSV = new ColorHandler.HSV();
            HSV.ToString();
        }
          

        /// <summary>
        ///A test for HSVtoColor - int
        ///</summary>
        [TestMethod()]
        public void HSVtoColor_IntTest()
        {
            int H = 0; // TODO: Initialize to an appropriate value
            int S = 0; // TODO: Initialize to an appropriate value
            int V = 0; // TODO: Initialize to an appropriate value
            var expected = ColorHandler.HSVtoColor(new ColorHandler.HSV(H, S, V));
            var actual = ColorHandler.HSVtoColor(H, S, V);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for HSVtoColor - HSV
        ///</summary>
        [TestMethod()]
        public void HSVtoColor_HSVTest()
        {
            ColorHandler.HSV hsv = new ColorHandler.HSV();
            ColorHandler.RGB RGB = ColorHandler.HSVtoRGB(hsv);
            var expected = Color.FromArgb(RGB.Red, RGB.Green, RGB.Blue);
            var actual = ColorHandler.HSVtoColor(hsv);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for HSVtoRGB - int
        ///</summary>
        [TestMethod()]
        public void HSVtoRGB_IntTest()
        {
            int H = 0; // TODO: Initialize to an appropriate value
            int S = 0; // TODO: Initialize to an appropriate value
            int V = 0; // TODO: Initialize to an appropriate value
            var expected = ColorHandler.HSVtoRGB(new ColorHandler.HSV(H, S, V));
            var actual = ColorHandler.HSVtoRGB(H, S, V);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for HSVtoRGB - s = 0
        ///</summary>
        [TestMethod()]
        public void HSVtoRGB_S0Test()
        {
            var h = 100;
            var s = 0;
            var v = 100;
            ColorHandler.HSV HSV = new ColorHandler.HSV(h, s, v); // TODO: Initialize to an appropriate value
            //expected
            double value = (double)v / 255;
            var expected = new ColorHandler.RGB((int)(value * 255), (int)(value * 255), (int)(value * 255));
            Assert.AreEqual(expected, ColorHandler.HSVtoRGB(HSV));
            
        }

        /// <summary>
        ///A test for HSVtoRGB - sectorNumber = 0
        ///</summary>
        [TestMethod()]
        public void HSVtoRGB_H0Test()
        {
            var h = 0;
            var s = 100;
            var v = 100;
            ColorHandler.HSV HSV = new ColorHandler.HSV(h, s, v); // TODO: Initialize to an appropriate value
            //expected
            double valueH = ((double)h / 255 * 360) % 360;
            double valueS = (double)s / 255;
            double valueV = (double)v / 255;
            var sectorPos = valueH / 60;
            var sectorNumber = (int)(Math.Floor(sectorPos));
            var fractionalSector = sectorPos - sectorNumber;
            var p = valueV * (1 - valueS);
            var q = valueV * (1 - (valueS * fractionalSector));
            var t = valueV * (1 - (valueS * (1 - fractionalSector)));
            var r = valueV;
            var g = t;
            var b = p;
            var expected = new ColorHandler.RGB((int)(r * 255), (int)(g * 255), (int)(b * 255));
            //result
            Assert.AreEqual(expected, ColorHandler.HSVtoRGB(HSV));
        }

        /// <summary>
        ///A test for HSVtoRGB - sectorNumber = 61
        ///</summary>
        [TestMethod()]
        public void HSVtoRGB_H61Test()
        {
            var h = 61;
            var s = 100;
            var v = 100;
            ColorHandler.HSV HSV = new ColorHandler.HSV(h, s, v); // TODO: Initialize to an appropriate value
            //expected
            double valueH = ((double)h / 255 * 360) % 360;
            double valueS = (double)s / 255;
            double valueV = (double)v / 255;
            var sectorPos = valueH / 60;
            var sectorNumber = (int)(Math.Floor(sectorPos));
            var fractionalSector = sectorPos - sectorNumber;
            var p = valueV * (1 - valueS);
            var q = valueV * (1 - (valueS * fractionalSector));
            var t = valueV * (1 - (valueS * (1 - fractionalSector)));
            var r = q;
            var g = valueV;
            var b = p;
            var expected = new ColorHandler.RGB((int)(r * 255), (int)(g * 255), (int)(b * 255));
            //result
            Assert.AreEqual(expected, ColorHandler.HSVtoRGB(HSV));
        }

        /// <summary>
        ///A test for HSVtoRGB - sectorNumber = 122
        ///</summary>
        [TestMethod()]
        public void HSVtoRGB_H122Test()
        {
            var h = 122;
            var s = 100;
            var v = 100;
            ColorHandler.HSV HSV = new ColorHandler.HSV(h, s, v); // TODO: Initialize to an appropriate value
            //expected
            double valueH = ((double)h / 255 * 360) % 360;
            double valueS = (double)s / 255;
            double valueV = (double)v / 255;
            var sectorPos = valueH / 60;
            var sectorNumber = (int)(Math.Floor(sectorPos));
            var fractionalSector = sectorPos - sectorNumber;
            var p = valueV * (1 - valueS);
            var q = valueV * (1 - (valueS * fractionalSector));
            var t = valueV * (1 - (valueS * (1 - fractionalSector)));
            var r = p;
            var g = valueV;
            var b = t;
            var expected = new ColorHandler.RGB((int)(r * 255), (int)(g * 255), (int)(b * 255));
            //result
            Assert.AreEqual(expected, ColorHandler.HSVtoRGB(HSV));
        }

        /// <summary>
        ///A test for HSVtoRGB - sectorNumber = 130
        ///</summary>
        [TestMethod()]
        public void HSVtoRGB_H130Test()
        {
            var h = 130;
            var s = 100;
            var v = 100;
            ColorHandler.HSV HSV = new ColorHandler.HSV(h, s, v); // TODO: Initialize to an appropriate value
            //expected
            double valueH = ((double)h / 255 * 360) % 360;
            double valueS = (double)s / 255;
            double valueV = (double)v / 255;
            var sectorPos = valueH / 60;
            var sectorNumber = (int)(Math.Floor(sectorPos));
            var fractionalSector = sectorPos - sectorNumber;
            var p = valueV * (1 - valueS);
            var q = valueV * (1 - (valueS * fractionalSector));
            var t = valueV * (1 - (valueS * (1 - fractionalSector)));
            var r = p;
            var g = q;
            var b = valueV;
            var expected = new ColorHandler.RGB((int)(r * 255), (int)(g * 255), (int)(b * 255));
            //result
            Assert.AreEqual(expected, ColorHandler.HSVtoRGB(HSV));
        }

        /// <summary>
        ///A test for HSVtoRGB - sectorNumber = 200
        ///</summary>
        [TestMethod()]
        public void HSVtoRGB_H200Test()
        {
            var h = 200;
            var s = 100;
            var v = 100;
            ColorHandler.HSV HSV = new ColorHandler.HSV(h, s, v); // TODO: Initialize to an appropriate value
            //expected
            double valueH = ((double)h / 255 * 360) % 360;
            double valueS = (double)s / 255;
            double valueV = (double)v / 255;
            var sectorPos = valueH / 60;
            var sectorNumber = (int)(Math.Floor(sectorPos));
            var fractionalSector = sectorPos - sectorNumber;
            var p = valueV * (1 - valueS);
            var q = valueV * (1 - (valueS * fractionalSector));
            var t = valueV * (1 - (valueS * (1 - fractionalSector)));
            var r = t;
            var g = p;
            var b = valueV;
            var expected = new ColorHandler.RGB((int)(r * 255), (int)(g * 255), (int)(b * 255));
            //result
            Assert.AreEqual(expected, ColorHandler.HSVtoRGB(HSV));
        }

        /// <summary>
        ///A test for HSVtoRGB - sectorNumber = 245
        ///</summary>
        [TestMethod()]
        public void HSVtoRGB_H245Test()
        {
            var h = 245;
            var s = 100;
            var v = 100;
            ColorHandler.HSV HSV = new ColorHandler.HSV(h, s, v); // TODO: Initialize to an appropriate value
            //expected
            double valueH = ((double)h / 255 * 360) % 360;
            double valueS = (double)s / 255;
            double valueV = (double)v / 255;
            var sectorPos = valueH / 60;
            var sectorNumber = (int)(Math.Floor(sectorPos));
            var fractionalSector = sectorPos - sectorNumber;
            var p = valueV * (1 - valueS);
            var q = valueV * (1 - (valueS * fractionalSector));
            var t = valueV * (1 - (valueS * (1 - fractionalSector)));
            var r = valueV;
            var g = p;
            var b = q;
            var expected = new ColorHandler.RGB((int)(r * 255), (int)(g * 255), (int)(b * 255));
            //result
            Assert.AreEqual(expected, ColorHandler.HSVtoRGB(HSV));
        }

        /// <summary>
        ///A test for RGBtoHSV - max 0
        ///</summary>
        [TestMethod()]
        public void RGBtoHSV_Max0Test()
        {
            ColorHandler.RGB rgb = new ColorHandler.RGB(0, 0, 0);
            ColorHandler.HSV expected = new ColorHandler.HSV(0, 0, 0); // TODO: Initialize to an appropriate value            
            Assert.AreEqual(expected, ColorHandler.RGBtoHSV(rgb));
        }

        /// <summary>
        ///A test for RGBtoHSV - delta 0
        ///</summary>
        [TestMethod()]
        public void RGBtoHSV_Delta0Test()
        {
            ColorHandler.RGB rgb = new ColorHandler.RGB(100, 100, 100);
            ColorHandler.HSV expected = new ColorHandler.HSV(0, 0, 100); // TODO: Initialize to an appropriate value            
            Assert.AreEqual(expected, ColorHandler.RGBtoHSV(rgb));
        }

        /// <summary>
        ///A test for RGBtoHSV - r max
        ///</summary>
        [TestMethod()]
        public void RGBtoHSV_RMaxTest()
        {            
            ColorHandler.RGB rgb = new ColorHandler.RGB(100, 0, 0);

            //expected
            var r = (double)rgb.Red / 255;
            var g = (double)rgb.Green / 255;
            var b = (double)rgb.Blue / 255;
            var min = Math.Min(Math.Min(r, g), b);
            var max = Math.Max(Math.Max(r, g), b);
            var v = max;
            var delta = max - min;
            var s = delta / max;
            var h = (g - b) / delta;
            h *= 60;
            ColorHandler.HSV expected = new ColorHandler.HSV((int)(h / 360 * 255), (int)(s * 255), (int)(v * 255)); // TODO: Initialize to an appropriate value            
            Assert.AreEqual(expected, ColorHandler.RGBtoHSV(rgb));
        }

        /// <summary>
        ///A test for RGBtoHSV - g max
        ///</summary>
        [TestMethod()]
        public void RGBtoHSV_GMaxTest()
        {
            ColorHandler.RGB rgb = new ColorHandler.RGB(0, 100, 0);

            //expected
            var r = (double)rgb.Red / 255;
            var g = (double)rgb.Green / 255;
            var b = (double)rgb.Blue / 255;
            var min = Math.Min(Math.Min(r, g), b);
            var max = Math.Max(Math.Max(r, g), b);
            var v = max;
            var delta = max - min;
            var s = delta / max;
            var h = 2 + (b - r) / delta;
            h *= 60;
            ColorHandler.HSV expected = new ColorHandler.HSV((int)(h / 360 * 255), (int)(s * 255), (int)(v * 255)); // TODO: Initialize to an appropriate value            
            Assert.AreEqual(expected, ColorHandler.RGBtoHSV(rgb));
        }

        /// <summary>
        ///A test for RGBtoHSV - b max
        ///</summary>
        [TestMethod()]
        public void RGBtoHSV_BMaxTest()
        {
            ColorHandler.RGB rgb = new ColorHandler.RGB(0, 0, 100);

            //expected
            var r = (double)rgb.Red / 255;
            var g = (double)rgb.Green / 255;
            var b = (double)rgb.Blue / 255;
            var min = Math.Min(Math.Min(r, g), b);
            var max = Math.Max(Math.Max(r, g), b);
            var v = max;
            var delta = max - min;
            var s = delta / max;
            var h = 4 + (r - g) / delta;
            h *= 60;
            ColorHandler.HSV expected = new ColorHandler.HSV((int)(h / 360 * 255), (int)(s * 255), (int)(v * 255)); // TODO: Initialize to an appropriate value            
            Assert.AreEqual(expected, ColorHandler.RGBtoHSV(rgb));
        }

        /// <summary>
        ///A test for RGBtoHSV - h < 0
        ///</summary>
        [TestMethod()]
        public void RGBtoHSV_H0Test()
        {
            ColorHandler.RGB rgb = new ColorHandler.RGB(100, 0, 50);

            //expected
            var r = (double)rgb.Red / 255;
            var g = (double)rgb.Green / 255;
            var b = (double)rgb.Blue / 255;
            var min = Math.Min(Math.Min(r, g), b);
            var max = Math.Max(Math.Max(r, g), b);
            var v = max;
            var delta = max - min;
            var s = delta / max;
            var h = (g - b) / delta;
            h *= 60;
            h += 360;
            ColorHandler.HSV expected = new ColorHandler.HSV((int)(h / 360 * 255), (int)(s * 255), (int)(v * 255)); // TODO: Initialize to an appropriate value            
            Assert.AreEqual(expected, ColorHandler.RGBtoHSV(rgb));
        }
    }
}
