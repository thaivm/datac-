using LogViewer.Model;
using LogViewer.Service;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.ViewModel;
using LogViewer.WindowViewModelMapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Input;
using LogViewer.MVVMHelper;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for JumpToLineViewModelTest and is intended
    ///to contain all JumpToLineViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class JumpToLineViewModelTest
    {
        MainViewModel_Accessor targetMainVM;   


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
            
        //    if (!ServiceLocator.services.ContainsKey(typeof(IDialogService)))
        //    {
        //        ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
        //        ServiceLocator.RegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
        //        ServiceLocator.Register<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
        //        ServiceLocator.Register<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
        //    }
        //    MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
        //    targetMainVM = new MainViewModel_Accessor();
        //    targetMainVM.Init();


        //}
        
        ////Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //    ServiceLocator.UnRegisterSingleton<IDialogService, DialogService>();
        //    ServiceLocator.UnRegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
        //    ServiceLocator.UnRegister<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
        //    ServiceLocator.UnRegister<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();


        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            if (!ServiceLocator.services.ContainsKey(typeof(IDialogService)))
            {
                ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
                ServiceLocator.RegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
                ServiceLocator.Register<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
                ServiceLocator.Register<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
            }
            targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
        }
        
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            ServiceLocator.UnRegisterSingleton<IDialogService, DialogService>();
            ServiceLocator.UnRegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
            ServiceLocator.UnRegister<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
            ServiceLocator.UnRegister<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();

        }
        //
        #endregion


        /// <summary>
        ///A test for JumpToLineViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void JumpToLineViewModelConstructorTest()
        {
            int maximumLineNumber = 10; 
            JumpToLineViewModel target = new JumpToLineViewModel(maximumLineNumber);
            Assert.AreEqual(maximumLineNumber, target.MaximumLineNumber);
            Assert.AreEqual(target.Message, LogViewer.Properties.Resources.Max + maximumLineNumber);
        }

        /// <summary>
        ///A test for JumpToLineCommandCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void JumpToLineCommandCL_NotNullTest()
        {
            JumpToLineViewModel vm = new JumpToLineViewModel(100);
            PrivateObject ccs = new PrivateObject((BaseLogMainViewModel<CCSLogRecord>)targetMainVM.CCSMainVM);
            vm.OnJumpToLineNumberEvent += new Action<int>((line) => ccs.Invoke("JumpToLine", line));
            PrivateObject param0 = new PrivateObject(vm);
            JumpToLineViewModel_Accessor target = new JumpToLineViewModel_Accessor(param0);
            target.JumpToLineCommandCL();
        }

        /// <summary>
        ///A test for JumpToLineCommandCL - null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void JumpToLineCommandCL_NullTest()
        {
            JumpToLineViewModel_Accessor target = new JumpToLineViewModel_Accessor(100);
            target.JumpToLineCommandCL();
        }

        /// <summary>
        ///A test for JumpToLineCommand - _jumpToLineCommand != null
        ///</summary>
        [TestMethod()]
        public void JumpToLineCommand_NotNullTest()
        {
            int maximumLineNumber = 0; 
            JumpToLineViewModel_Accessor target = new JumpToLineViewModel_Accessor(maximumLineNumber);
            target._jumpToLineCommand = new DelegateCommand(target.JumpToLineCommandCL, () => { return true; });
            Assert.AreEqual(target._jumpToLineCommand, target.JumpToLineCommand);
        }

        /// <summary>
        ///A test for JumpToLineCommand - _jumpToLineCommand = null
        ///</summary>
        [TestMethod()]
        public void JumpToLineCommand_Null_LineNull_FalseTest()
        {
            int maximumLineNumber = 0;
            JumpToLineViewModel_Accessor target = new JumpToLineViewModel_Accessor(maximumLineNumber);
            target.Line = null;
            Assert.IsFalse((bool)target.JumpToLineCommand.CanExecute(target._jumpToLineCommand));            
        }

        /// <summary>
        ///A test for JumpToLineCommand - _jumpToLineCommand = null && target.Line = 1
        ///</summary>
        [TestMethod()]
        public void JumpToLineCommand_Null_LineNotNull_TrueTest()
        {
            int maximumLineNumber = 0;
            JumpToLineViewModel_Accessor target = new JumpToLineViewModel_Accessor(maximumLineNumber);
            target.MaximumLineNumber = 2;
            target.Line = "1";
            Assert.IsTrue((bool)target.JumpToLineCommand.CanExecute(target._jumpToLineCommand));
        }

        /// <summary>
        ///A test for JumpToLineCommand - _jumpToLineCommand = null && target.Line = 0
        ///</summary>
        [TestMethod()]
        public void JumpToLineCommand_Null_LineNotNull_FalseTest()
        {
            int maximumLineNumber = 0;
            JumpToLineViewModel_Accessor target = new JumpToLineViewModel_Accessor(maximumLineNumber);
            target.MaximumLineNumber = 2;
            target.Line = "0";
            Assert.IsFalse((bool)target.JumpToLineCommand.CanExecute(target._jumpToLineCommand));
        }

        /// <summary>
        ///A test for JumpToLineCommand - _jumpToLineCommand = null && target.Line = a
        ///</summary>
        [TestMethod()]
        public void JumpToLineCommand_ExceptionTest()
        {
            int maximumLineNumber = 0;
            JumpToLineViewModel_Accessor target = new JumpToLineViewModel_Accessor(maximumLineNumber);
            target.MaximumLineNumber = 2;
            target.Line = "a";
            Assert.IsFalse((bool)target.JumpToLineCommand.CanExecute(target._jumpToLineCommand));
        }

        /// <summary>
        ///A test for Line
        ///</summary>
        [TestMethod()]
        public void Line_GetNullTest()
        {
            int maximumLineNumber = 0; 
            JumpToLineViewModel_Accessor target = new JumpToLineViewModel_Accessor(maximumLineNumber);
            target._line = null;
            Assert.IsNull(target.Line);
        }

        /// <summary>
        ///A test for Line
        ///</summary>
        [TestMethod()]
        public void Line_GetNotNullTest()
        {
            int maximumLineNumber = 0;
            JumpToLineViewModel_Accessor target = new JumpToLineViewModel_Accessor(maximumLineNumber);
            target._line = "1";
            Assert.AreEqual(target._line, target.Line);
        }

        /// <summary>
        ///A test for Line
        ///</summary>
        [TestMethod()]
        public void Line_SetNullTest()
        {
            int maximumLineNumber = 0;
            JumpToLineViewModel_Accessor target = new JumpToLineViewModel_Accessor(maximumLineNumber);
            target.Line = null;
            Assert.IsNull(target._line);
        }

        /// <summary>
        ///A test for Line
        ///</summary>
        [TestMethod()]
        public void Line_SetNotNullTest()
        {
            int maximumLineNumber = 0;
            JumpToLineViewModel_Accessor target = new JumpToLineViewModel_Accessor(maximumLineNumber);
            target.Line = "1";
            Assert.AreEqual(target._line, target.Line);
        }

        /// <summary>
        ///A test for MaximumLineNumber - 0
        ///</summary>
        [TestMethod()]
        public void MaximumLineNumber_0Test()
        {
            int maximumLineNumber = 10; 
            JumpToLineViewModel target = new JumpToLineViewModel(maximumLineNumber); 
            int expected = 0; 
            int actual;
            target.MaximumLineNumber = expected;
            actual = target.MaximumLineNumber;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MaximumLineNumber - Max
        ///</summary>
        [TestMethod()]
        public void MaximumLineNumber_MaxTest()
        {
            int maximumLineNumber = 10;
            JumpToLineViewModel target = new JumpToLineViewModel(maximumLineNumber);
            int expected = 2147483647;
            int actual;
            target.MaximumLineNumber = expected;
            actual = target.MaximumLineNumber;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MaximumLineNumber - Min
        ///</summary>
        [TestMethod()]
        public void MaximumLineNumber_MinTest()
        {
            int maximumLineNumber = 10;
            JumpToLineViewModel target = new JumpToLineViewModel(maximumLineNumber);
            int expected = -2147483647;
            int actual;
            target.MaximumLineNumber = expected;
            actual = target.MaximumLineNumber;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Message
        ///</summary>
        [TestMethod()]
        public void Message_SetNullTest()
        {
            int maximumLineNumber = 10; 
            JumpToLineViewModel_Accessor target = new JumpToLineViewModel_Accessor(maximumLineNumber); 
            target.Message = null;
            Assert.IsNull(target._message);
        }

        /// <summary>
        ///A test for Message
        ///</summary>
        [TestMethod()]
        public void Message_SetNotNullTest()
        {
            int maximumLineNumber = 10;
            JumpToLineViewModel_Accessor target = new JumpToLineViewModel_Accessor(maximumLineNumber);
            target.Message = "Message";
            Assert.AreEqual(target._message, target.Message);
        }

        /// <summary>
        ///A test for Message
        ///</summary>
        [TestMethod()]
        public void Message_GetNullTest()
        {
            int maximumLineNumber = 10;
            JumpToLineViewModel_Accessor target = new JumpToLineViewModel_Accessor(maximumLineNumber);
            target._message = null;
            Assert.IsNull(target.Message);
        }

        /// <summary>
        ///A test for Message
        ///</summary>
        [TestMethod()]
        public void Message_GetNotNullTest()
        {
            int maximumLineNumber = 10;
            JumpToLineViewModel_Accessor target = new JumpToLineViewModel_Accessor(maximumLineNumber);
            target._message = "Message";
            Assert.AreEqual(target._message, target.Message);
        }
    }
}
