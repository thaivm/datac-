using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using LogViewer.ViewModel;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.Service.FrameworkDialogs.OpenFile;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for MessageBoxManagerTest and is intended
    ///to contain all MessageBoxManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MessageBoxManagerTest
    {
        public static MessageBoxManager_Accessor target;

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
        public void MyTestInitialize()
        {
            if (!ServiceLocator.services.ContainsKey(typeof(IDialogService)))
            {
                ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
                ServiceLocator.RegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
                ServiceLocator.Register<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
                ServiceLocator.Register<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
            }
            //targetMainVM = new MainViewModel_Accessor();
            //targetMainVM.Init();
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
        #endregion


        /// <summary>
        ///A test for MessageBoxManager Constructor
        ///</summary>
        [TestMethod()]
        public void MessageBoxManagerConstructorTest()
        {
            target = new MessageBoxManager_Accessor();
            PrivateType type = new PrivateType(typeof(MessageBoxManager));
            Assert.IsNotNull(type.GetStaticField("hookProc"));
            Assert.IsNotNull(type.GetStaticField("enumProc"));
            Assert.IsNotNull(type.GetStaticField("hHook"));
        }

        /// <summary>
        ///A test for MessageBoxEnumProc
        ///</summary>
        //[TestMethod()]
        //[DeploymentItem("LogViewer.exe")]
        //public void MessageBoxEnumProcTest()
        //{
        //    //MainViewModel_Accessor targetMainVM = new MainViewModel_Accessor();
        //    //targetMainVM.Init();
        //    //PrivateObject param0 = new PrivateObject(targetMainVM.CCSMainVM);
        //    //CCSMainViewModel_Accessor ccsMain = new CCSMainViewModel_Accessor(param0);
        //    //BaseWindowViewModel edit = new EditPatternSettingViewModel(ccsMain.ApplyPatternSetting);
        //    //MessageBoxManager.Register();
        //    //MessageBoxManager.Yes = "Merge";
        //    //MessageBoxManager.No = "Replace";
        //    ////Register manager
        //    //MessageBoxManager.Register();
        //    //MessageBoxViewModel confirm = new MessageBoxViewModel()
        //    //{
        //    //    ButtonValue = System.Windows.MessageBoxButton.YesNoCancel,
        //    //    Caption = "ConfirmMergeFile",
        //    //    Text = "Do you want to merge file(s)?"
        //    //};
        //    //confirm.ShowDialog(edit);
        //    ////edit.ShowDialog(confirm);

        //    //IntPtr hWnd = new IntPtr();
        //    //IntPtr lParam = new IntPtr();
        //    //bool expected = false;
        //    //bool actual;

        //    //actual = MessageBoxManager_Accessor.MessageBoxEnumProc(hWnd, lParam);
        //    //Assert.AreEqual(expected, actual);
        //}

        /// <summary>
        ///A test for MessageBoxHookProc
        ///</summary>
        //[TestMethod()]
        ////[ExpectedException(typeof(AccessViolationException))]
        //public void MessageBoxHookProc_LessZeroTest()
        //{
        //    //int nCode = 0;
        //    //IntPtr wParam = new IntPtr(1);
        //    //IntPtr lParam = new IntPtr(2);
        //    //MessageBoxManager_Accessor.MessageBoxHookProc(nCode, wParam, lParam);
        //}

        /// <summary>
        ///A test for Register - not null
        ///</summary>
        [TestMethod()]
        public void Register_NotNullTest()
        {
            MessageBoxManager_Accessor.hHook = IntPtr.Zero;
            MessageBoxManager.Register();
            Assert.IsNotNull(MessageBoxManager_Accessor.hHook);
        }

        /// <summary>
        ///A test for Register - throw exception
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NotSupportedException))]
        public void Register_ExceptionTest()
        {
            MessageBoxManager_Accessor.hHook = new IntPtr(2);
            MessageBoxManager.Register();
        }

        /// <summary>
        ///A test for Unregister - hHook is Zero
        ///</summary>
        [TestMethod()]
        public void Unregister_hHookZeroTest()
        {
            MessageBoxManager_Accessor.hHook = IntPtr.Zero;
            MessageBoxManager.Unregister();
        }

        /// <summary>
        ///A test for Unregister - hHook is not Zero
        ///</summary>
        [TestMethod()]
        public void Unregister_hHookNotZeroTest()
        {
            MessageBoxManager_Accessor.hHook = new IntPtr(2);
            MessageBoxManager.Unregister();
            Assert.AreEqual(IntPtr.Zero, MessageBoxManager_Accessor.hHook);
        }
    }
}
