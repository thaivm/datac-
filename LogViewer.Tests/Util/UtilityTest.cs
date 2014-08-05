using LogViewer.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using LogViewer.Model;
using System.Windows.Controls.DataVisualization.Charting.Primitives;
using LogViewer.Properties;
using LogViewer.MVVMHelper;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for UtilityTest and is intended
    ///to contain all UtilityTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UtilityTest
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
        ///A test for FindParentWithType - return null
        ///</summary>
        [TestMethod()]
        public void FindParentWithType_NullTest()
        {
            DependencyObject uiElement = null; // TODO: Initialize to an appropriate value
            DependencyObject actual;
            actual = Utility.FindParentWithType<DependencyObject>(uiElement);
            Assert.IsNull(actual);
        }

        /// <summary>
        ///A test for FindParentWithType - tempUIElement is DependencyObject
        ///</summary>
        [TestMethod()]
        public void FindParentWithType_NotDependencyObjectTest()
        {
            EdgePanel uiElement = new EdgePanel(); // TODO: Initialize to an appropriate value
            RichTextBoxHelper actual = new RichTextBoxHelper();
            actual = Utility.FindParentWithType<RichTextBoxHelper>(uiElement);
            Assert.IsNull(actual);
        }

        /// <summary>
        ///A test for FindParentWithType - return not null
        ///</summary>
        [TestMethod()]
        public void FindParentWithType_NotNullTest()
        {
            DependencyObject uiElement = new DependencyObject(); // TODO: Initialize to an appropriate value
            DependencyObject actual;
            actual = Utility.FindParentWithType<DependencyObject>(uiElement);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for GetCurrentDateString
        ///</summary>
        [TestMethod()]
        public void GetCurrentDateStringTest()
        {
            string expected = DateTime.Now.ToString("yyyyMMddHHmmss"); // TODO: Initialize to an appropriate value
            string actual;
            actual = Utility.GetCurrentDateString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for NVL - value null
        ///</summary>
        [TestMethod()]
        public void NVL_valeNullTest()
        {
            string value = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = Utility.NVL(value);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for NVL - value null
        ///</summary>
        [TestMethod()]
        public void NVL_valeNotNullTest()
        {
            string value = "Test"; // TODO: Initialize to an appropriate value
            string expected = "Test"; // TODO: Initialize to an appropriate value
            string actual;
            actual = Utility.NVL(value);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Translate
        ///</summary>
        [TestMethod()]
        public void TranslateTest()
        {
            string str = "LogItem"; // TODO: Initialize to an appropriate value
            //string expected = Resources.ResourceManager.GetString(str); // TODO: Initialize to an appropriate value
            string actual;
            actual = Utility.Translate(str);
            Assert.AreEqual("Log Item", actual);
        }
    }
}
