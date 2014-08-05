using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Data;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for SwitchedContentTest and is intended
    ///to contain all SwitchedContentTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SwitchedContentTest
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
        ///A test for OnApplyTemplate
        ///</summary>
        [TestMethod()]
        public void OnApplyTemplateTest()
        {
            SwitchedContent target = new SwitchedContent(); 
            target.OnApplyTemplate();
        }

        /// <summary>
        ///A test for UpdateBindings
        ///</summary>
        [TestMethod()]
        public void UpdateBindingsTest()
        {
            SwitchedContent_Accessor target = new SwitchedContent_Accessor();
            target._Content = new System.Windows.Controls.ContentPresenter();
            target._Binding = null;
            target.UpdateBindings();
            Assert.IsInstanceOfType(target._Content, typeof(System.Windows.Controls.ContentPresenter));
        }
        [TestMethod()]
        public void UpdateBindingsBindingNotNullTest()
        {
            SwitchedContent_Accessor target = new SwitchedContent_Accessor();
            target._Content = new System.Windows.Controls.ContentPresenter();
            target._Binding = new Binding();
            target.UpdateBindings();
            Assert.IsInstanceOfType(target._Content, typeof(System.Windows.Controls.ContentPresenter));
        }
        /// <summary>
        ///A test for Binding
        ///</summary>
        [TestMethod()]
        public void BindingTest()
        {
            SwitchedContent target = new SwitchedContent();
            Binding expected = null;
            Binding actual;
            target.Binding = expected;
            actual = target.Binding;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void BindingNotNullTest()
        {
            SwitchedContent target = new SwitchedContent();
            Binding expected = new Binding();
            Binding actual;
            target.Binding = expected;
            actual = target.Binding;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Cases
        ///</summary>
        [TestMethod()]
        public void CasesTest()
        {
            SwitchedContent target = new SwitchedContent();
            var actual = target.Cases;
            Assert.IsInstanceOfType(actual, typeof(SwitchCaseCollection));
        }

        /// <summary>
        ///A test for Else
        ///</summary>
        [TestMethod()]
        public void ElseTest()
        {
            SwitchedContent target = new SwitchedContent();
            object expected = null;
            object actual;
            target.Else = expected;
            actual = target.Else;
            Assert.AreEqual(expected, actual);
        }
    }
}
