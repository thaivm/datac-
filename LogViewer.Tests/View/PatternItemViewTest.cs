using LogViewer.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Input;
using LogViewer.Service;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.WindowViewModelMapping;
using System.Windows;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for PatternItemViewTest and is intended
    ///to contain all PatternItemViewTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PatternItemViewTest
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
        [TestInitialize()]
        public void SetUp()
        {
            if (!ServiceLocator.services.ContainsKey(typeof(IDialogService)))
            {
                ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
                ServiceLocator.RegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
                ServiceLocator.Register<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
                ServiceLocator.Register<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
            }
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            ServiceLocator.UnRegisterSingleton<IDialogService, DialogService>();
            ServiceLocator.UnRegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
            ServiceLocator.UnRegister<IOpenFileDialog, LogViewer.Service.FrameworkDialogs.OpenFile.OpenFileDialogViewModel>();
            ServiceLocator.UnRegister<ISaveFileDialog, LogViewer.Service.FrameworkDialogs.SaveFile.SaveFileDialogViewModel>();
        }
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for PatternItemView Constructor
        ///</summary>
        [TestMethod()]
        public void PatternItemViewConstructorTest()
        {
            PatternItemView target = new PatternItemView();
        }

        /// <summary>
        ///A test for DataGrid_KeyDown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DataGrid_KeyDownTest()
        {
            PatternItemView_Accessor target = new PatternItemView_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            //KeyEventArgs args = null; // TODO: Initialize to an appropriate value
            KeyEventArgs e = new KeyEventArgs(Keyboard.PrimaryDevice, new FakePresentationSource(), 0, Key.Delete);
            e.RoutedEvent = UIElement.KeyDownEvent;
            target.DataGrid_KeyDown(sender, e);
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        public void InitializeComponentTest()
        {
            PatternItemView target = new PatternItemView(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
        }

        /// <summary>
        ///A test for TextBoxTextAllowed
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void TextBoxTextAllowedTest()
        {
            PatternItemView_Accessor target = new PatternItemView_Accessor(); // TODO: Initialize to an appropriate value
            string Text2 = "4Bốn"; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.TextBoxTextAllowed(Text2);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for TextBox_PreviewTextInput
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void TextBox_PreviewTextInputTest()
        {
           
                PatternItemView_Accessor target = new PatternItemView_Accessor(); // TODO: Initialize to an appropriate value
                object sender = null; // TODO: Initialize to an appropriate value
                TextCompositionEventArgs e = new TextCompositionEventArgs(Keyboard.PrimaryDevice, new TextComposition(InputManager.Current, Keyboard.FocusedElement, "4Bốn"));   // TODO: Initialize to an appropriate value
                e.RoutedEvent = UIElement.KeyDownEvent;
            
               target.TextBox_PreviewTextInput(sender, e);
            
        }
    }
}
