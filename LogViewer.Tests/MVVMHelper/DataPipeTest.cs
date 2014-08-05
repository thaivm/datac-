using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for DataPipeTest and is intended
    ///to contain all DataPipeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DataPipeTest
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

        [TestMethod()]
        public void SetDataPipesTest()
        {
            DataPiping target = new DataPiping();
            RichTextBox rtb = new RichTextBox();
            DataPiping.SetDataPipes(rtb, null);
            DataPipeCollection value = DataPiping.GetDataPipes(rtb);
            Assert.IsNull(value);
        }

        /// <summary>
        ///A test for Source
        ///</summary>
        [TestMethod()]
        public void SourceTest()
        {
            DataPipe target = new DataPipe(); 
            object expected = null; 
            object actual;
            target.Source = expected;
            actual = target.Source;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Target
        ///</summary>
        [TestMethod()]
        public void TargetTest()
        {
            DataPipe target = new DataPipe(); 
            object expected = null; 
            object actual;
            target.Target = expected;
            actual = target.Target;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]

        public void CreateInstanceCoreTest()
        {
            DataPipe_Accessor target = new DataPipe_Accessor();
            var actual = target.CreateInstanceCore();
            Assert.IsInstanceOfType(actual, typeof(Freezable));
        }
    }
}
