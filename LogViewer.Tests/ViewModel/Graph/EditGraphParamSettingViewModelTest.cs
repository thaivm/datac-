using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Business;
using System.Collections.Generic;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.Collections.ObjectModel;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for EditGraphParamSettingViewModelTest and is intended
    ///to contain all EditGraphParamSettingViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EditGraphParamSettingViewModelTest
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
        //}
        
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            ServiceLocator.UnRegisterSingleton<IDialogService, DialogService>();
            ServiceLocator.UnRegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
            ServiceLocator.UnRegister<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
            ServiceLocator.UnRegister<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
        }
        
        #endregion

        /// <summary>
        ///A test for GetDataToApply
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void GetDataToApplyTest()
        {
            EditGraphParamSettingViewModel _edit = new EditGraphParamSettingViewModel(new Action<IList<GraphParamSetting>>((list) => { }));
            PrivateObject param0 = new PrivateObject(_edit);
            EditGraphParamSettingViewModel_Accessor target = new EditGraphParamSettingViewModel_Accessor(param0);
            GraphParamSetting item = new GraphParamSetting();
            item.Name = "a";
            item.StringValue = "a";
            item.Enabled = true;            
            item.Id = "a";
            object owm = new object();
            ParameterDataGridViewModel param = new ParameterDataGridViewModel(owm);
            EventDataGridViewModel even = new EventDataGridViewModel(owm);
            GraphParamSetting _baseitem = new GraphParamSetting();
            _baseitem.Id = "a";
            _baseitem.Name = "a";
            _baseitem.StringValue = "a";
            ObservableCollection<GraphParamSetting> _sourceList = new ObservableCollection<GraphParamSetting>();            
            _sourceList.Add(_baseitem);
            param.SourceList = _sourceList;
            even.SourceList = _sourceList;            
            target.ParameterDataGridVM = param;
            target.EventDataGridVM = even;            
            IList<GraphParamSetting> actual = target.GetDataToApply();
            Assert.AreEqual(2, actual.Count);
            
        }

        /// <summary>
        ///A test for LoadParam
        ///</summary>
        [TestMethod()]
        public void LoadParamTest()
        {
            Action<IList<GraphParamSetting>> onApplyEvent = new Action<IList<GraphParamSetting>>((list) => {  });
            EditGraphParamSettingViewModel target = new EditGraphParamSettingViewModel(onApplyEvent);
            IList<GraphParamSetting> graphParamSetting = null;
            List<GraphParamSetting> _list = new List<GraphParamSetting>();
            GraphParamSetting item = new GraphParamSetting();
            item.Id = "a";
            item.GraphTypeValue = GraphType.Event;            
            _list.Add(item);
            graphParamSetting = _list;
            target.LoadParam(graphParamSetting);
            
        }

        /// <summary>
        ///A test for CanApply
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CanApplyTest()
        {
            PrivateObject param0 = new PrivateObject(new EditGraphParamSettingViewModel(null));
            EditGraphParamSettingViewModel_Accessor target = new EditGraphParamSettingViewModel_Accessor(param0);
            target.ParameterDataGridVM = new ParameterDataGridViewModel(null);
            ObservableCollection<GraphParamSetting> list = new ObservableCollection<GraphParamSetting>();
            GraphParamSetting item = new GraphParamSetting();
            item.StringValue = "String Value";
            item.Name = "Name";
            list.Add(item);
            target.ParameterDataGridVM.SourceList = list;
            target.EventDataGridVM = new EventDataGridViewModel(null);
            target.EventDataGridVM.SourceList = list;
            Assert.IsTrue(target.CanApply);
        }

        /// <summary>
        ///A test for EventDataGridVM
        ///</summary>
        [TestMethod()]
        public void EventDataGridVMTest()
        {
            Action<IList<GraphParamSetting>> onApplyEvent = null;
            EditGraphParamSettingViewModel target = new EditGraphParamSettingViewModel(onApplyEvent);
            EventDataGridViewModel expected = null;
            EventDataGridViewModel actual;
            target.EventDataGridVM = expected;
            actual = target.EventDataGridVM;
            Assert.AreEqual(expected, actual);            
        }

        /// <summary>
        ///A test for ParameterDataGridVM
        ///</summary>
        [TestMethod()]
        public void ParameterDataGridVMTest()
        {
            Action<IList<GraphParamSetting>> onApplyEvent = null;
            EditGraphParamSettingViewModel target = new EditGraphParamSettingViewModel(onApplyEvent);
            ParameterDataGridViewModel expected = null;
            ParameterDataGridViewModel actual;
            target.ParameterDataGridVM = expected;
            actual = target.ParameterDataGridVM;
            Assert.AreEqual(expected, actual);
            
        }
    }
}
