using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Business;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for GraphParamSettingTest and is intended
    ///to contain all GraphParamSettingTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GraphParamSettingTest
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
        ///A test for Copy
        ///</summary>
        [TestMethod()]
        public void CopyTest()
        {
            GraphParamSetting target = new GraphParamSetting();
            GraphParamSetting expected = new GraphParamSetting(); 
            GraphParamSetting actual;
            actual = target.Copy();
            Assert.AreEqual(expected.StringValue, actual.StringValue);
        }

        /// <summary>
        ///A test for GraphTypeValue
        ///</summary>
        [TestMethod()]
        public void GraphTypeValueTest()
        {
            GraphParamSetting target = new GraphParamSetting(); 
            GraphType expected = new GraphType(); 
            GraphType actual;
            target.GraphTypeValue = expected;
            actual = target.GraphTypeValue;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for PrototypeValue
        ///</summary>
        [TestMethod()]
        public void PrototypeValueTest()
        {
            GraphParamSetting target = new GraphParamSetting(); 
            Prototype expected = new Prototype(); 
            Prototype actual;
            target.PrototypeValue = expected;
            actual = target.PrototypeValue;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for StringValue
        ///</summary>
        [TestMethod()]
        public void StringValueTest()
        {
            GraphParamSetting target = new GraphParamSetting(); 
            string expected = string.Empty; 
            string actual;
            target.StringValue = expected;
            actual = target.StringValue;
            Assert.AreEqual(expected, actual);
        }
    }
}
