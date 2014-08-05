using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Controls;
using LogViewer.CustomException;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for FontStyleHelperTest and is intended
    ///to contain all FontStyleHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FontStyleHelperTest
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
        ///A test for FontStyleHelper Constructor
        ///</summary>
        [TestMethod()]
        public void FontStyleHelperConstructorTest()
        {
            FontStyleHelper target = new FontStyleHelper();
        }

        /// <summary>
        ///A test for GetFontStyle
        ///</summary>
        [TestMethod()]
        public void GetFontStyleTest()
        {
            DependencyObject o = new DependencyObject(); 
            object expected = null; 
            object actual;
            actual = FontStyleHelper.GetFontStyle(o);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for OnFontStyleChanged
        ///</summary>
        [TestMethod()]
        public void OnFontStyleChangedFontStyleObjectIsNullTest()
        {
            RichTextBox o = new RichTextBox();
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs(); 
            FontStyleHelper.OnFontStyleChanged(o, args);
        }
        [TestMethod()]
        public void OnFontStyleChangedItalicTest()
        {
            RichTextBox o = new RichTextBox();
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs(FontStyleHelper_Accessor.FontStyleProperty, "Normal","Italic");
            FontStyleHelper.OnFontStyleChanged(o, args);
        }
        [TestMethod()]
        public void OnFontStyleChangedNormalTest()
        {
            RichTextBox o = new RichTextBox();
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs(FontStyleHelper_Accessor.FontStyleProperty, "Normal1", "Normal");
            FontStyleHelper.OnFontStyleChanged(o, args);
        }
        [TestMethod()]
        public void OnFontStyleChangedBoldTest()
        {
            RichTextBox o = new RichTextBox();
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs(FontStyleHelper_Accessor.FontStyleProperty, "Normal1", "Bold");
            FontStyleHelper.OnFontStyleChanged(o, args);
        }
        [TestMethod()]
        public void OnFontStyleChangedBoldItalicTest()
        {
            RichTextBox o = new RichTextBox();
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs(FontStyleHelper_Accessor.FontStyleProperty, "Normal", "BoldItalic");
            FontStyleHelper.OnFontStyleChanged(o, args);
        }
        [TestMethod()]
        [ExpectedException(typeof(DataValueNotSupportedException))]
        public void OnFontStyleChangedDataValueNotSupportedExceptionTest()
        {
            RichTextBox o = new RichTextBox();
            DependencyPropertyChangedEventArgs args = new DependencyPropertyChangedEventArgs(FontStyleHelper_Accessor.FontStyleProperty, "Normal", "BoldItalicasdasd");
            FontStyleHelper.OnFontStyleChanged(o, args);
        }
        
        //[TestMethod()]
        //public void SetFontStyleNormalTest()
        //{
        //    Run control = new Run("test");
        //    string fontStyle = "Normal";
        //    RichTextBoxHelper_Accessor.SetFontStyle(control, fontStyle);
        //}
        //[TestMethod()]
        //public void SetFontStyleBoldTest()
        //{
        //    Run control = new Run("test");
        //    string fontStyle = "Bold";
        //    RichTextBoxHelper_Accessor.SetFontStyle(control, fontStyle);
        //}
        //[TestMethod()]
        //public void SetFontStyleItalicTest()
        //{
        //    Run control = new Run("test");
        //    string fontStyle = "Italic";
        //    RichTextBoxHelper_Accessor.SetFontStyle(control, fontStyle);
        //}
        //[TestMethod()]
        //public void SetFontStyleBoldItalicTest()
        //{
        //    Run control = new Run("test");
        //    string fontStyle = "BoldItalic";
        //    RichTextBoxHelper_Accessor.SetFontStyle(control, fontStyle);
        //}
        //[TestMethod()]
        //[ExpectedException(typeof(DataValueNotSupportedException))]
        //public void SetFontStyleBoldItalicDataValueNotSupportedExceptionTest()
        //{
        //    Run control = new Run("test");
        //    string fontStyle = "asdasdasd";
        //    RichTextBoxHelper_Accessor.SetFontStyle(control, fontStyle);
        //}
        /// <summary>
        ///A test for SetFontStyle
        ///</summary>
        [TestMethod()]
        public void SetFontStyleTest()
        {
            DependencyObject o = new DependencyObject();
            object value = null; 
            FontStyleHelper.SetFontStyle(o, value);
        }
    }
}
