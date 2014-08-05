using LogViewer.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using LogViewer.Service;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.WindowViewModelMapping;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for MoveToLineTest and is intended
    ///to contain all MoveToLineTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MoveToLineTest
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
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for MoveToLine Constructor
        ///</summary>
        [TestMethod()]
        public void MoveToLineConstructorTest()
        {
            MoveToLine target = new MoveToLine();
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        public void InitializeComponentTest()
        {
            MoveToLine target = new MoveToLine(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
        }

        /// <summary>
        ///A test for IsNumber
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsNumberTest()
        {
            MoveToLine_Accessor target = new MoveToLine_Accessor(); // TODO: Initialize to an appropriate value
            string text = "test12345"; // TODO: Initialize to an appropriate value
            string numText = "0"; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsNumber(text); 
            actual = target.IsNumber(numText);
        }

        /// <summary>
        ///A test for IsOver
        ///</summary>
        [TestMethod()]
        public void IsOverStringEmptyTest()
        {
            MoveToLine_Accessor target = new MoveToLine_Accessor(); 
            string str = string.Empty;
            bool actual;
            actual = target.IsOver(str);
            Assert.AreEqual(false, actual);
        }
        [TestMethod()]
        public void IsOverStringAbNormalTest()
        {
            MoveToLine_Accessor target = new MoveToLine_Accessor();
            string str = "abc";
            bool actual;
            target.MoveToLine_Warning_Lable.Content = "";
            actual = target.IsOver(str);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void IsOverStringNormalLessThanMaxTest()
        {
            MoveToLine_Accessor target = new MoveToLine_Accessor();
            string str = "123";
            bool actual;
            target.MoveToLine_Warning_Lable.Content = "Max: 1234";
            actual = target.IsOver(str);
            Assert.AreEqual(false, actual);
        }
        [TestMethod()]
        public void IsOverTest()
        {
            MoveToLine_Accessor target = new MoveToLine_Accessor();
            string str = "123";
            bool actual;
            target.MoveToLine_Warning_Lable.Content = "Max: 12";
            actual = target.IsOver(str);
            Assert.AreEqual(true, actual);
        }
        /// <summary>
        ///A test for MoveToLine_Button_Cancel_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void MoveToLine_Button_Cancel_ClickTest()
        {
            MoveToLine_Accessor target = new MoveToLine_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            RoutedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.MoveToLine_Button_Cancel_Click(sender, e);
        }

        /// <summary>
        ///A test for MoveToLine_Button_JumpTo_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void MoveToLine_Button_JumpTo_ClickTest()
        {
            MoveToLine_Accessor target = new MoveToLine_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            RoutedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.MoveToLine_Button_JumpTo_Click(sender, e);
        }

        /// <summary>
        ///A test for MoveToLine_LineNumber_Textbox_PreviewKeyDown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void MoveToLine_LineNumber_Textbox_PreviewKeyDownTest()
        {
            MoveToLine_Accessor target = new MoveToLine_Accessor(); 
            object sender = null; 
            var mainKeyboard = Keyboard.PrimaryDevice;
            KeyEventArgs e = new KeyEventArgs(mainKeyboard, new FakePresentationSource(), 0, Key.V);
            e.RoutedEvent = UIElement.KeyDownEvent;
            //Keyboard.Modifiers = ModifierKeys.Control;
            target.MoveToLine_LineNumber_Textbox_PreviewKeyDown(sender, e);
        }

        /// <summary>
        ///A test for MoveToLine_LineNumber_Textbox_PreviewTextInput
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void MoveToLine_LineNumber_Textbox_PreviewTextInputTest()
        {
            MoveToLine_Accessor target = new MoveToLine_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            TextCompositionEventArgs e = new TextCompositionEventArgs(Keyboard.PrimaryDevice, new TextComposition(InputManager.Current, Keyboard.FocusedElement, "4Bốn"));   // TODO: Initialize to an appropriate value
            e.RoutedEvent = UIElement.KeyDownEvent;
            
            target.MoveToLine_LineNumber_Textbox_PreviewTextInput(sender, e);
        }

        /// <summary>
        ///A test for MoveToLine_LineNumber_Textbox_TextChanged
        ///</summary>
        [TestMethod()]
        public void MoveToLine_LineNumber_Textbox_TextChangedTest()
        {
            MoveToLine_Accessor target = new MoveToLine_Accessor(); 
            object sender = null; 
            TextChangedEventArgs e = null; 

            target.MoveToLine_LineNumber_Textbox_TextChanged(sender, e);
        }
        [TestMethod()]
        public void MoveToLine_LineNumber_Textbox_TextChanged_IsOverTest()
        {
            MoveToLine_Accessor target = new MoveToLine_Accessor();
            object sender = null;
            TextChangedEventArgs e = new TextChangedEventArgs(UIElement.KeyDownEvent, new UndoAction());
            target.MoveToLine_Warning_Lable.Content = "Max: 12";
            target.MoveToLine_LineNumber_Textbox.Text = "1";
            target.MoveToLine_LineNumber_Textbox.Text = "13";
            target.MoveToLine_LineNumber_Textbox_TextChanged(sender, e);
        }
        [TestMethod()]
        public void MoveToLine_LineNumber_Textbox_TextChangedbIsPasteOperationIsTrueTest()
        {
            MoveToLine_Accessor target = new MoveToLine_Accessor(); 
            object sender = null;
            TextChangedEventArgs e = new TextChangedEventArgs(UIElement.KeyDownEvent, new UndoAction());
            target.bIsPasteOperation = true;
            target.MoveToLine_LineNumber_Textbox_TextChanged(sender, e);
        }
        [TestMethod()]
        public void MoveToLine_LineNumber_Textbox_TextChanged_bIsPasteOperationIsTrue_IsOverTest()
        {
            MoveToLine_Accessor target = new MoveToLine_Accessor();
            object sender = null;
            target.bIsPasteOperation = true;
            TextChangedEventArgs e = new TextChangedEventArgs(UIElement.KeyDownEvent, new UndoAction());
            target.MoveToLine_Warning_Lable.Content = "Max: 12";
            target.MoveToLine_LineNumber_Textbox.Text = "13";
            target.MoveToLine_LineNumber_Textbox_TextChanged(sender, e);
        }
        /// <summary>
        ///A test for TextBoxTextAllowed
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void TextBoxTextAllowedTest()
        {
            MoveToLine_Accessor target = new MoveToLine_Accessor(); // TODO: Initialize to an appropriate value
            string Text2 = "4Ố"; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.TextBoxTextAllowed(Text2);
//            Assert.AreEqual(expected, actual);
        }
    }
}
