using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Input;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.Model;
using System.Collections.Generic;
using LogViewer.Business;
using LogViewer.MVVMHelper;
using System.Collections.ObjectModel;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for BaseApplyWindowViewModelTest and is intended
    ///to contain all BaseApplyWindowViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BaseApplyWindowViewModelTest
    {
        public static MainViewModel_Accessor targetMainVM;

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
            targetMainVM = new MainViewModel_Accessor();
            targetMainVM.Init();
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
        ///A test for ApplyCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ApplyCLTest()
        {
            var target = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay); // TODO: Initialize to an appropriate value
            PrivateObject param0 = new PrivateObject(target);
            param0.Invoke("ApplyCL");
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for OkCL
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void OkCLTest()
        {
            var target = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay); // TODO: Initialize to an appropriate value
            PrivateObject param0 = new PrivateObject(target);
            param0.Invoke("OkCL");
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for SetApplyEvent
        ///</summary>
        [TestMethod()]
        public void SetApplyEventTest()
        {
            BaseApplyWindowViewModel<List<List<LogDisplay>>> target = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay);
            ObservableCollection<List<List<LogDisplay>>> ItemSettingList = new ObservableCollection<List<List<LogDisplay>>>();
            Action<List<List<LogDisplay>>> expected = x =>
            {
                ItemSettingList.Add(x);
            };
            target.SetApplyEvent(expected);
            PrivateObject param = new PrivateObject(target, new PrivateType(typeof(BaseApplyWindowViewModel<List<List<LogDisplay>>>)));
            var actual = param.GetFieldOrProperty("OnApplyEvent");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ApplyCommand - _applyCommand is null
        ///</summary>
        [TestMethod()]
        public void ApplyCommandIsNullTest()
        {
            var target = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay); // TODO: Initialize to an appropriate value
            PrivateObject param0 = new PrivateObject(target);
            param0.SetField("_applyCommand", null);
            Assert.IsNotNull(target.ApplyCommand);
        }

        /// <summary>
        ///A test for ApplyCommand - _applyCommand is not null
        ///</summary>
        [TestMethod()]
        public void ApplyCommandIsNotNullTest()
        {
            var target = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay); // TODO: Initialize to an appropriate value
            PrivateObject param0 = new PrivateObject(target);
            //var a = new DelegateCommand(ApplyCL, () => { return true; });
            param0.SetField("_applyCommand", new DelegateCommand(ApplyCL, () => { return true; }));
            Assert.IsNotNull(target.ApplyCommand);
        }
        void ApplyCL() { }

        /// <summary>
        ///A test for CanApply
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CanApplyTest()
        {
            var target = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay); // TODO: Initialize to an appropriate value
            PrivateObject param0 = new PrivateObject(target, new PrivateType(typeof(LogViewer.ViewModel.BaseApplyWindowViewModel<List<List<LogDisplay>>>)));
            List<LogDisplay> ccsDisplaySettings = targetMainVM.CCSMainVM.SettingManager.DisplaySetting;
            List<LogDisplay> cxdiDisplaySettings = targetMainVM.CXDIMainVM.SettingManager.DisplaySetting;
            target.CCSDisplaySettings.Add(new LogDisplayRecordViewModel(ccsDisplaySettings[0]));
            target.CXDIDisplaySettings.Add(new LogDisplayRecordViewModel(cxdiDisplaySettings[0]));
            Assert.AreEqual(param0.GetProperty("CanApply"), true);
        }

        /// <summary>
        ///A test for OkCommand - _okCommand is null
        ///</summary>
        [TestMethod()]
        public void OkCommandIsNullTest()
        {
            var target = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay); // TODO: Initialize to an appropriate value
            PrivateObject param0 = new PrivateObject(target);
            param0.SetField("_okCommand", null);
            Assert.IsNotNull(target.OkCommand);
        }

        /// <summary>
        ///A test for OkCommand - _okCommand is not null
        ///</summary>
        [TestMethod()]
        public void OkCommandIsNotNullTest()
        {
            var target = new SetLogDisplayViewModel(targetMainVM.ApplyLogDisplay); // TODO: Initialize to an appropriate value
            PrivateObject param0 = new PrivateObject(target);
            //var a = new DelegateCommand(ApplyCL, () => { return true; });
            param0.SetField("_okCommand", new DelegateCommand(OkCL, () => { return true; }));
            Assert.IsNotNull(target.OkCommand);
        }
        void OkCL() { }
    }
}
