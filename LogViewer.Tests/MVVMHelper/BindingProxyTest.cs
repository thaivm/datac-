using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for BindingProxyTest and is intended
    ///to contain all BindingProxyTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BindingProxyTest
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
        ///A test for Data
        ///</summary>
        [TestMethod()]
        public void DataTest()
        {
            BindingProxy target = new BindingProxy(); 
            object expected = null; 
            object actual;
            target.Data = expected;
            actual = target.Data;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CreateInstanceCoreTest()
        {
            BindingProxy_Accessor target = new BindingProxy_Accessor();
            var actual = target.CreateInstanceCore();
            Assert.IsInstanceOfType(actual, typeof(Freezable));
        }
    }
}
