using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Model;
using System.Windows.Input;
using System.Collections.Generic;
using LogViewer.MVVMHelper;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.Text;
using System.Windows;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for FirmwareInfoTabViewModelTest and is intended
    ///to contain all FirmwareInfoTabViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FirmwareInfoTabViewModelTest
    {

        private static FirmwareInfoTabViewModel_Accessor target;
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
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {

        }
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
        ///A test for FirmwareInfoTabViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void FirmwareInfoTabViewModelConstructorTest()
        {
            FirmwareInfoTabViewModel target = new FirmwareInfoTabViewModel();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for ClearData - CXDIFirmware.Count = 1 
        ///</summary>
        [TestMethod()]
        public void ClearData_CXDIFirmwareNotZeroTest()
        {
            FirmwareInfoTabViewModel target = new FirmwareInfoTabViewModel();
            target.CXDIFirmware = new CXDIFirmware { Counter = new List<Counter> {new Counter{parameter="Test", value = "Test"}}};
            target.ClearData();
            Assert.AreEqual(0, target.CXDIFirmware.Counter.Count);
        }

        /// <summary>
        ///A test for ClearData - CXDIFirmware.Count = 0
        ///</summary>
        [TestMethod()]
        public void ClearData_CXDIFirmwareZeroTest()
        {
            FirmwareInfoTabViewModel target = new FirmwareInfoTabViewModel();
            target.CXDIFirmware = new CXDIFirmware { };
            target.ClearData();
            Assert.AreEqual(0, target.CXDIFirmware.Counter.Count);
        }

        /// <summary>
        ///A test for CopyCommandCLv - SelectedItemsCounter.Count != 0 &&  SelectedItemsSaved.Count != 0
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CopyCommandCL_NotZeroTest()
        {
            FirmwareInfoTabViewModel_Accessor target = new FirmwareInfoTabViewModel_Accessor();
            Counter a = new Counter { parameter = "aaa", value = "iii" };
            List<object> list_count = new List<object>();
            list_count.Add(a);
            target.SelectedItemsCounter = list_count;
            Saved b = new Saved { parameter = "uuu", value = "ooo" };
            List<Object> list_save = new List<object>();
            list_save.Add(b);            
            target.SelectedItemsSaved = list_save;
            target.CopyCommandCL();
            Assert.AreEqual(Clipboard.GetText().Length, 18);
        }

        /// <summary>
        ///A test for CopyCommandCLv - SelectedItemsCounter.Count = 0 &&  SelectedItemsSaved.Count = 0
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CopyCommandCL_ZeroTest()
        {
            FirmwareInfoTabViewModel_Accessor target = new FirmwareInfoTabViewModel_Accessor();
            target.SelectedItemsCounter = new List<object>();
            target.SelectedItemsSaved = new List<object>();
            target.CopyCommandCL();
            Assert.AreEqual(Clipboard.GetText().Length, 0);
        }

        /// <summary>
        ///A test for CopyCommandCLv - SelectedItemsCounter.Count = 0 &&  SelectedItemsSaved.Count != 0
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CopyCommandCL_CounterNotZeroTest()
        {
            FirmwareInfoTabViewModel_Accessor target = new FirmwareInfoTabViewModel_Accessor();
            Counter a = new Counter { parameter = "aaa", value = "iii" };
            List<object> list_count = new List<object>();
            list_count.Add(a);
            target.SelectedItemsCounter = list_count;
            target.SelectedItemsSaved = new List<object>();
            target.CopyCommandCL();
            Assert.AreEqual(Clipboard.GetText().Length, 9);
        }

        /// <summary>
        ///A test for CopyCommandCLv - SelectedItemsCounter.Count != 0 &&  SelectedItemsSaved.Count = 0
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CopyCommandCL_SavedNotZeroTest()
        {
            FirmwareInfoTabViewModel_Accessor target = new FirmwareInfoTabViewModel_Accessor();
            target.SelectedItemsCounter = new List<object>();
            Saved b = new Saved { parameter = "uuu", value = "ooo" };
            List<Object> list_save = new List<object>();
            list_save.Add(b);
            target.SelectedItemsSaved = list_save;
            target.CopyCommandCL();
            Assert.AreEqual(Clipboard.GetText().Length, 9);
        }

        /// <summary>
        ///A test for IsEnableCopy - SelectedItemsCounter.Count != 0
        ///</summary>
        //IsEnableCopyTest_True
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsEnableCopyTest_SelectedItemsCounterNotZero()
        {
            Counter a = new Counter { parameter = "aaa", value = "aaa" };
            List<Object> list = new List<object>();
            list.Add(a);
            target = new FirmwareInfoTabViewModel_Accessor();
            target.SelectedItemsCounter = list;
            bool expected = true;
            bool actual;
            actual = target.IsEnableCopy();
            Assert.AreEqual(expected, actual);            
        }

        /// <summary>
        ///A test for IsEnableCopy - SelectedItemsCounter.Count = 0
        ///</summary>
        //IsEnableCopyTest_False
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsEnableCopyTest_SelectedItemsCounterZero()
        {                      
            target = new FirmwareInfoTabViewModel_Accessor();
            target.SelectedItemsCounter = new List<object>();
            bool expected = false;
            bool actual;
            actual = target.IsEnableCopy();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsEnableCopy - SelectedItemsSaved.Count != 0
        ///</summary>
        //IsEnableCopyTest_True
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsEnableCopyTest_SelectedItemsSavedNotZero()
        {
            Saved a = new Saved { parameter = "aaa", value = "aaa" };
            List<Object> list = new List<object>();
            list.Add(a);
            target = new FirmwareInfoTabViewModel_Accessor();
            target.SelectedItemsSaved = list;
            bool expected = true;
            bool actual;
            actual = target.IsEnableCopy();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsEnableCopy - SelectedItemsSaved.Count = 0
        ///</summary>
        //IsEnableCopyTest_False
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsEnableCopyTest_SelectedItemsSavedZero()
        {
            List<Object> list = new List<object>();
            target = new FirmwareInfoTabViewModel_Accessor();
            target.SelectedItemsSaved = list;
            bool expected = false;
            bool actual;
            actual = target.IsEnableCopy();
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for IsEnableCopyCounter
        ///</summary>
        //IsEnableCopyCounterTest_False
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsEnableCopyCounterTest_False()
        {
            List<Object> list = new List<object>();
            target = new FirmwareInfoTabViewModel_Accessor();
            target.SelectedItemsCounter = list;
            bool expected = false;
            bool actual;
            actual = target.IsEnableCopyCounter();
            Assert.AreEqual(expected, actual);            
        }
        //IsEnableCopyCounterTest_True
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsEnableCopyCounterTest_True()
        {
            Counter a = new Counter();
            a.parameter = "aaa";
            a.value = "aaa";
            List<Object> list = new List<object>();
            list.Add(a);
            target = new FirmwareInfoTabViewModel_Accessor(); 
            target.SelectedItemsCounter = list;
            bool expected = true; 
            bool actual;
            actual = target.IsEnableCopyCounter();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsEnableCopySaved
        ///</summary>
        //IsEnableCopySavedTest_False
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]       
        public void IsEnableCopySavedTest_False()
        {
            List<Object> list = new List<object>();
            target = new FirmwareInfoTabViewModel_Accessor(); 
            target.SelectedItemsSaved = list;
            bool expected = false;
            bool actual;
            actual = target.IsEnableCopySaved();
            Assert.AreEqual(expected, actual);            
        }
        //IsEnableCopySavedTest_True
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsEnableCopySavedTest_True()
        {
            Saved a = new Saved();
            a.parameter = "aaa";
            a.value = "aaa";
            List<Object> list = new List<object>();
            list.Add(a);
            target = new FirmwareInfoTabViewModel_Accessor();
            target.SelectedItemsSaved = list;
            bool expected = true; 
            bool actual;
            actual = target.IsEnableCopySaved();
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for CXDIFirmware - Set CXDIFirmware != null
        ///</summary>
        [TestMethod()]
        public void CXDIFirmware_SetNotNullTest()
        {
            FirmwareInfoTabViewModel_Accessor target = new FirmwareInfoTabViewModel_Accessor();
            var expected = new CXDIFirmware();
            target.CXDIFirmware = expected;
            Assert.AreEqual(expected, target._cXDIFirmware);            
        }

        /// <summary>
        ///A test for CXDIFirmware - Set CXDIFirmware = null
        ///</summary>
        [TestMethod()]
        public void CXDIFirmware_SetNullTest()
        {
            FirmwareInfoTabViewModel_Accessor target = new FirmwareInfoTabViewModel_Accessor();
            target.CXDIFirmware = null;
            Assert.IsNull(target._cXDIFirmware);
        }

        /// <summary>
        ///A test for CXDIFirmware - Get CXDIFirmware != null
        ///</summary>
        [TestMethod()]
        public void CXDIFirmware_GetNotNullTest()
        {
            FirmwareInfoTabViewModel_Accessor target = new FirmwareInfoTabViewModel_Accessor();
            target._cXDIFirmware = new CXDIFirmware();
            Assert.AreEqual(target._cXDIFirmware, target.CXDIFirmware);
        }

        /// <summary>
        ///A test for CXDIFirmware - Get CXDIFirmware = null
        ///</summary>
        [TestMethod()]
        public void CXDIFirmware_GetNullTest()
        {
            FirmwareInfoTabViewModel_Accessor target = new FirmwareInfoTabViewModel_Accessor();
            target._cXDIFirmware = null;
            Assert.IsNotNull(target.CXDIFirmware);
        }

        /// <summary>
        ///A test for CopyCommand - _copyCommand = null
        ///</summary>
        [TestMethod()]
        public void CopyCommand_NullTest()
        {
            FirmwareInfoTabViewModel_Accessor target = new FirmwareInfoTabViewModel_Accessor();
            target._copyCommand = null;
            ICommand actual;
            ICommand expected = new DelegateCommand(target.CopyCommandCL, () => target.IsEnableCopy());
            actual = target.CopyCommand;
            Assert.ReferenceEquals(expected, actual);
        }

        /// <summary>
        ///A test for CopyCommand - _copyCommand != null
        ///</summary>
        [TestMethod()]
        public void CopyCommand_NotNullTest()
        {
            FirmwareInfoTabViewModel_Accessor target = new FirmwareInfoTabViewModel_Accessor();
            target._copyCommand = new DelegateCommand(target.CopyCommandCL, () => target.IsEnableCopy());
            ICommand actual;
            ICommand expected = target._copyCommand;
            actual = target.CopyCommand;
            Assert.ReferenceEquals(expected, actual);
        }

        /// <summary>
        ///A test for SelectedItemsCounter - Get SelectedItemsCounter = null
        ///</summary>
        [TestMethod()]
        public void SelectedItemsCounter_GetNullTest()
        {
            FirmwareInfoTabViewModel_Accessor target = new FirmwareInfoTabViewModel_Accessor();
            target._selectedItemsCounter = null;
            Assert.IsNull(target.SelectedItemsCounter);            
        }

        /// <summary>
        ///A test for SelectedItemsCounter - Get SelectedItemsCounter != null
        ///</summary>
        [TestMethod()]
        public void SelectedItemsCounter_GetNotNullTest()
        {
            FirmwareInfoTabViewModel_Accessor target = new FirmwareInfoTabViewModel_Accessor();
            target._selectedItemsCounter = new List<object>();
            Assert.IsNotNull(target.SelectedItemsCounter);
        }

        /// <summary>
        ///A test for SelectedItemsCounter - Set SelectedItemsCounter = null
        ///</summary>
        [TestMethod()]
        public void SelectedItemsCounter_SetNullTest()
        {
            FirmwareInfoTabViewModel_Accessor target = new FirmwareInfoTabViewModel_Accessor();
            target.SelectedItemsCounter = null;
            Assert.IsNull(target._selectedItemsCounter);
        }

        /// <summary>
        ///A test for SelectedItemsCounter - Get SelectedItemsCounter != null
        ///</summary>
        [TestMethod()]
        public void SelectedItemsCounter_SetNotNullTest()
        {
            FirmwareInfoTabViewModel_Accessor target = new FirmwareInfoTabViewModel_Accessor();
            target.SelectedItemsCounter = new List<object>();
            Assert.IsNotNull(target._selectedItemsCounter);
        }

        /// <summary>
        ///A test for SelectedItemsSaved - Get SelectedItemsSaved = null
        ///</summary>
        [TestMethod()]
        public void SelectedItemsSaved_GetNullTest()
        {
            FirmwareInfoTabViewModel_Accessor target = new FirmwareInfoTabViewModel_Accessor();
            target._selectedItemsSaved = null;
            Assert.IsNull(target.SelectedItemsSaved);
        }

        /// <summary>
        ///A test for SelectedItemsSaved - Get SelectedItemsSaved != null
        ///</summary>
        [TestMethod()]
        public void SelectedItemsSaved_GetNotNullTest()
        {
            FirmwareInfoTabViewModel_Accessor target = new FirmwareInfoTabViewModel_Accessor();
            target._selectedItemsSaved = new List<object>();
            Assert.IsNotNull(target.SelectedItemsSaved);
        }

        /// <summary>
        ///A test for SelectedItemsSaved - Set SelectedItemsSaved = null
        ///</summary>
        [TestMethod()]
        public void SelectedItemsSaved_SetNullTest()
        {
            FirmwareInfoTabViewModel_Accessor target = new FirmwareInfoTabViewModel_Accessor();
            target.SelectedItemsSaved = null;
            Assert.IsNull(target._selectedItemsSaved);
        }

        /// <summary>
        ///A test for SelectedItemsSaved - Get SelectedItemsSaved != null
        ///</summary>
        [TestMethod()]
        public void SelectedItemsSaved_SetNotNullTest()
        {
            FirmwareInfoTabViewModel_Accessor target = new FirmwareInfoTabViewModel_Accessor();
            target.SelectedItemsSaved = new List<object>();
            Assert.IsNotNull(target._selectedItemsSaved);
        }
    }
}
