using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Input;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for MouseWheelGestureTest and is intended
    ///to contain all MouseWheelGestureTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MouseWheelGestureTest
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
        ///A test for MouseWheelGesture Constructor
        ///</summary>
        [TestMethod()]
        public void MouseWheelGestureConstructorTest()
        {
            ModifierKeys modifiers = new ModifierKeys();
            MouseWheelGesture target = new MouseWheelGesture(modifiers);
        }

        /// <summary>
        ///A test for MouseWheelGesture Constructor
        ///</summary>
        [TestMethod()]
        public void MouseWheelGestureConstructorTest1()
        {
            MouseWheelGesture target = new MouseWheelGesture();
        }

        /// <summary>
        ///A test for Matches
        ///</summary>
        [TestMethod()]
        public void MatchesTest()
        {
            MouseWheelGesture target = new MouseWheelGesture();
            object targetElement = null;
            InputEventArgs inputEventArgs = null;
            bool expected = false;
            bool actual;
            actual = target.Matches(targetElement, inputEventArgs);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CtrlDown
        ///</summary>
        [TestMethod()]
        public void CtrlDownTest()
        {
            var actual = MouseWheelGesture.CtrlDown;
            Assert.IsInstanceOfType(actual, typeof(MouseWheelGesture));
        }

        /// <summary>
        ///A test for CtrlUp
        ///</summary>
        [TestMethod()]
        public void CtrlUpTest()
        {
            var actual = MouseWheelGesture.CtrlUp;
            Assert.IsInstanceOfType(actual, typeof(MouseWheelGesture));
        }

        /// <summary>
        ///A test for Direction
        ///</summary>
        [TestMethod()]
        public void DirectionTest()
        {
            MouseWheelGesture target = new MouseWheelGesture();
            MouseWheelGesture.WheelDirection expected = new MouseWheelGesture.WheelDirection();
            MouseWheelGesture.WheelDirection actual;
            target.Direction = expected;
            actual = target.Direction;
            Assert.AreEqual(expected, actual);
        }
    }
}
