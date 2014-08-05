using LogViewer.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for ColorPickerTest and is intended
    ///to contain all ColorPickerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ColorPickerTest
    {
        public static ColorPicker_Accessor target;
        public static ColorWheel_Accessor wheel;

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
        ///Init
        ///</summary>
        [TestInitialize()]
        public void ColorPickerConstructor()
        {
            target = new ColorPicker_Accessor();
        }

        /// <summary>
        ///myColorWheel
        ///</summary>
        public void Init_myColorWheel()
        {
            Rectangle colorRectangle = new Rectangle(target.pnlColor.Location, target.pnlColor.Size); // TODO: Initialize to an appropriate value
            Rectangle brightnessRectangle = new Rectangle(target.pnlBrightness.Location, target.pnlBrightness.Size); // TODO: Initialize to an appropriate value
            Rectangle selectedColorRectangle = new Rectangle(target.pnlSelectedColor.Location, target.pnlSelectedColor.Size); // TODO: Initialize to an appropriate value
            wheel = new ColorWheel_Accessor(colorRectangle, brightnessRectangle, selectedColorRectangle);
            target.myColorWheel = new ColorWheel(colorRectangle, brightnessRectangle, selectedColorRectangle);
            target.myColorWheel.ColorChanged += new ColorWheel.ColorChangedEventHandler(target.myColorWheel_ColorChanged);
        }

        /// <summary>
        ///A test for ColorPicker Constructor
        ///</summary>
        [TestMethod()]
        public void ColorPickerConstructorTest()
        {
            ColorPicker target = new ColorPicker();
        }

        /// <summary>
        ///A test for ColorPicker_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ColorPicker_LoadTest()
        {
            object sender = new object(); // TODO: Initialize to an appropriate value
            EventArgs e = new EventArgs(); // TODO: Initialize to an appropriate value
            target.ColorPicker_Load(sender, e);
        }

        /// <summary>
        ///A test for ColorPicker_Paint - HSV
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ColorPicker_Paint_HSVTest()
        {
            Init_myColorWheel();
            target.changeType = ColorPicker_Accessor.ChangeStyle.HSV;
            target.ColorPicker_Paint(new object(), new PaintEventArgs(Graphics.FromImage(wheel.colorImage), 
                new Rectangle()));
        }

        /// <summary>
        ///A test for ColorPicker_Paint - MouseMove
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ColorPicker_Paint_MouseMoveTest()
        {
            Init_myColorWheel();
            target.changeType = ColorPicker_Accessor.ChangeStyle.MouseMove;
            target.ColorPicker_Paint(new object(), new PaintEventArgs(Graphics.FromImage(wheel.colorImage), 
                new Rectangle()));
        }

        /// <summary>
        ///A test for ColorPicker_Paint - None
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ColorPicker_Paint_NoneTest()
        {
            Init_myColorWheel();
            target.changeType = ColorPicker_Accessor.ChangeStyle.None;
            target.ColorPicker_Paint(new object(), new PaintEventArgs(Graphics.FromImage(wheel.colorImage), 
                new Rectangle()));
        }

        /// <summary>
        ///A test for ColorPicker_Paint - RGB
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ColorPicker_Paint_RGBTest()
        {
            Init_myColorWheel();
            target.changeType = ColorPicker_Accessor.ChangeStyle.RGB;
            target.ColorPicker_Paint(new object(), new PaintEventArgs(Graphics.FromImage(wheel.colorImage),
                new Rectangle()));
        }

        /// <summary>
        ///A test for Dispose - disposing is true - components is not null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Dispose_disposingTrue_componentsNotNullTest()
        {
            bool disposing = true; // TODO: Initialize to an appropriate value
            target.components = new System.ComponentModel.Container();
            target.Dispose(disposing);
        }

        /// <summary>
        ///A test for Dispose - disposing is true - components is not null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Dispose_disposingTrue_componentsNullTest()
        {
            bool disposing = true; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
        }

        /// <summary>
        ///A test for Dispose - disposing is false
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void Dispose_disposingFalseTest()
        {
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
        }

        /// <summary>
        ///A test for HandleHSVChange - isInUpdate is false
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void HandleHSVChange_isInUpdateFalseTest()
        {
            target.isInUpdate = false;
            target.changeType = ColorPicker_Accessor.ChangeStyle.RGB;
            target.HandleHSVChange(new object(), EventArgs.Empty);
            Assert.AreEqual(ColorPicker_Accessor.ChangeStyle.HSV, target.changeType);
        }

        /// <summary>
        ///A test for HandleHSVChange - isInUpdate is true
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void HandleHSVChange_isInUpdateTrueTest()
        {
            target.isInUpdate = true;
            target.changeType = ColorPicker_Accessor.ChangeStyle.RGB;
            target.HandleHSVChange(new object(), EventArgs.Empty);
            Assert.AreNotEqual(ColorPicker_Accessor.ChangeStyle.HSV, target.changeType);
        }

        /// <summary>
        ///A test for HandleMouse - MouseButtons.Left
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void HandleMouse_MouseButtonsLeftTest()
        {
            target.changeType = ColorPicker_Accessor.ChangeStyle.HSV;
            MouseEventArgs mouseEvent = new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 0);
            target.HandleMouse(new object(), mouseEvent);
            Assert.AreEqual(ColorPicker_Accessor.ChangeStyle.MouseMove, target.changeType);
            Assert.AreEqual(new Point(mouseEvent.X, mouseEvent.Y), target.selectedPoint);
        }

        /// <summary>
        ///A test for HandleMouse - !MouseButtons.Left
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void HandleMouse_MouseButtonsNoneTest()
        {
            target.changeType = ColorPicker_Accessor.ChangeStyle.HSV;
            MouseEventArgs mouseEvent = new MouseEventArgs(MouseButtons.None, 1, 1, 1, 0);
            target.HandleMouse(new object(), mouseEvent);
            Assert.AreNotEqual(ColorPicker_Accessor.ChangeStyle.MouseMove, target.changeType);
        }

        /// <summary>
        ///A test for HandleRGBChange - isInUpdate is false
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void HandleRGBChange_isInUpdateFalseTest()
        {
            target.isInUpdate = false;
            target.changeType = ColorPicker_Accessor.ChangeStyle.HSV;
            target.HandleRGBChange(new object(), EventArgs.Empty);
            Assert.AreEqual(ColorPicker_Accessor.ChangeStyle.RGB, target.changeType);
        }

        /// <summary>
        ///A test for HandleRGBChange - isInUpdate is true
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void HandleRGBChange_isInUpdateTrueTest()
        {
            target.isInUpdate = true;
            target.changeType = ColorPicker_Accessor.ChangeStyle.HSV;
            target.HandleRGBChange(new object(), EventArgs.Empty);
            Assert.AreNotEqual(ColorPicker_Accessor.ChangeStyle.RGB, target.changeType);
        }

        /// <summary>
        ///A test for HandleTextChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void HandleTextChangedTest()
        {
            target.HandleTextChanged(new NumericUpDown(), EventArgs.Empty);
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void InitializeComponentTest()
        {
            target.InitializeComponent();
        }

        /// <summary>
        ///A test for RefreshValue - Equals
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void RefreshValue_EqualsTest()
        {
            NumericUpDown nud = new NumericUpDown(); // TODO: Initialize to an appropriate value
            nud.Value = 1;
            int value = 1; // TODO: Initialize to an appropriate value
            target.RefreshValue(nud, value);
            Assert.AreEqual(1, nud.Value);
        }

        /// <summary>
        ///A test for RefreshValue - not Equals
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void RefreshValue_NotEqualsTest()
        {
            NumericUpDown nud = new NumericUpDown(); // TODO: Initialize to an appropriate value
            nud.Value = 2;
            int value = 1; // TODO: Initialize to an appropriate value
            target.RefreshValue(nud, value);
            Assert.AreEqual(1, nud.Value);
        }

        /// <summary>
        ///A test for SetHSV
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void SetHSVTest()
        {
            target.isInUpdate = true;
            ColorHandler.HSV HSV = new ColorHandler.HSV(); // TODO: Initialize to an appropriate value
            target.SetHSV(HSV);
            Assert.AreEqual(false, target.isInUpdate);
        }

        /// <summary>
        ///A test for SetRGB
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void SetRGBTest()
        {
            target.isInUpdate = true;
            ColorHandler.RGB RGB = new ColorHandler.RGB(); // TODO: Initialize to an appropriate value
            target.SetRGB(RGB);
            Assert.AreEqual(false, target.isInUpdate);
        }

        /// <summary>
        ///A test for frmMain_MouseUp
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void frmMain_MouseUpTest()
        {
            Init_myColorWheel();
            target.frmMain_MouseUp(new object(), new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 0));
            Assert.AreEqual(ColorPicker_Accessor.ChangeStyle.None, target.changeType);
        }

        /// <summary>
        ///A test for myColorWheel_ColorChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void myColorWheel_ColorChangedTest()
        {
            target.isInUpdate = true;
            target.myColorWheel_ColorChanged(new object(), new ColorChangedEventArgs(new ColorHandler.RGB(),
                new ColorHandler.HSV()));
            Assert.AreEqual(false, target.isInUpdate);
        }

        /// <summary>
        ///A test for Color
        ///</summary>
        [TestMethod()]
        public void ColorTest()
        {
            Init_myColorWheel();
            PrivateObject param0 = new PrivateObject(target.myColorWheel);
            param0.SetField("selectedColor", Color.Red);
            Color actual = target.Color;
            target.Color = actual;
            //get
            var expected = param0.GetField("selectedColor");
            Assert.AreEqual(expected, actual);
            //set
            Assert.AreEqual(actual, target.Color);
        }
    }
}
