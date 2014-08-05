using LogViewer.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogViewer.Business;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.Collections.Generic;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for SetRangeOfGraphViewModelTest and is intended
    ///to contain all SetRangeOfGraphViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SetRangeOfGraphViewModelTest
    {
        public static GraphViewModel_Accessor a; 

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
        ///A test for SetRangeOfGraphViewModel Constructor
        ///</summary>
        [TestMethod()]
        public void SetRangeOfGraphViewModelConstructorTest()
        {
            Action<GraphRangeSetting> onApplyEvent = null; 
            SetRangeOfGraphViewModel target = new SetRangeOfGraphViewModel(onApplyEvent);
           // Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetDataToApply
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void GetDataToApplyTest()
        {
            //SetRangeOfGraphViewModel_Accessor target = new SetRangeOfGraphViewModel_Accessor(new Action<GraphRangeSetting> ());
            PrivateObject param0 = new PrivateObject(new SetRangeOfGraphViewModel(new Action<GraphRangeSetting>((param) => { }))); 
            SetRangeOfGraphViewModel_Accessor target = new SetRangeOfGraphViewModel_Accessor(param0); 
            GraphRangeSetting expected = null; 
            GraphRangeSetting actual;
            actual = target.GetDataToApply();
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CanApply
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void CanApplyTest()
        {
            Action<GraphRangeSetting> onApplyEvent = new Action<GraphRangeSetting>((list) =>{});
            
            //PrivateObject param0 = new PrivateObject(onApplyEvent); 
            //PrivateObject param0 = new PrivateObject(onApplyEvent)
            //SetRangeOfGraphViewModel_Accessor target = new SetRangeOfGraphViewModel_Accessor(param0); 
            //bool actual;
            //var actual = target.CanApply;
            //Assert.AreEqual(actual, false);
            //Assert.Inconclusive("Verify the correctness of this test method.");

            SetRangeOfGraphViewModel range = new SetRangeOfGraphViewModel(onApplyEvent);
            PrivateObject param0 = new PrivateObject(range);
            param0.SetField("_setting", new GraphRangeSetting());

            var actual = param0.GetProperty("CanApply");
            Assert.AreEqual(actual, false);
        }

        /// <summary>
        ///A test for ErrorMessage
        ///</summary>
        [TestMethod()]
        public void ErrorMessageTest()
        {
            Action<GraphRangeSetting> onApplyEvent = new Action<GraphRangeSetting>((list) => { }); 
            SetRangeOfGraphViewModel target = new SetRangeOfGraphViewModel(onApplyEvent); 
            string expected = string.Empty; 
            string actual;
            target.ErrorMessage = expected;
            actual = target.ErrorMessage;
            Assert.AreEqual(expected, actual);
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FirstYRangeFrom
        ///</summary>
        [TestMethod()]
        public void FirstYRangeFromTest()
        {           
            Action<GraphRangeSetting> onApplyEvent = new Action<GraphRangeSetting>((list) => { }); 
            
            SetRangeOfGraphViewModel range = new SetRangeOfGraphViewModel(onApplyEvent); 
            PrivateObject param0 = new PrivateObject(range);
            SetRangeOfGraphViewModel_Accessor target = new SetRangeOfGraphViewModel_Accessor(param0);
            target._setting = new GraphRangeSetting();
            double expected = 1.1F; 
            double actual;
            target.FirstYRangeFrom = expected;
            actual = target.FirstYRangeFrom;
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FirstYRangeTo
        ///</summary>
        [TestMethod()]
        public void FirstYRangeToTest()
        {
            Action<GraphRangeSetting> onApplyEvent = new Action<GraphRangeSetting>((list) => { }); 
            SetRangeOfGraphViewModel range = new SetRangeOfGraphViewModel(onApplyEvent); 
            PrivateObject param0 = new PrivateObject(range);
            SetRangeOfGraphViewModel_Accessor target = new SetRangeOfGraphViewModel_Accessor(param0);
            target._setting = new GraphRangeSetting();
            double expected = 2.2F; 
            double actual;
            target.FirstYRangeTo = expected;
            actual = target.FirstYRangeTo;
            Assert.AreEqual(expected, actual);
         //   Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for From
        ///</summary>
        [TestMethod()]
        public void FromTest()
        {
            Action<GraphRangeSetting> onApplyEvent = new Action<GraphRangeSetting>((list) => { }); 
            SetRangeOfGraphViewModel range = new SetRangeOfGraphViewModel(onApplyEvent); 
            PrivateObject param0 = new PrivateObject(range);
            SetRangeOfGraphViewModel_Accessor target = new SetRangeOfGraphViewModel_Accessor(param0);
            target._setting = new GraphRangeSetting();
            DateTime expected = new DateTime(); 
            DateTime actual;
            target.From = expected;
            actual = target.From;
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsErrorAtFirstYRangeFrom
        ///</summary>
        [TestMethod()]
        public void IsErrorAtFirstYRangeFromTest()
        {
            Action<GraphRangeSetting> onApplyEvent = new Action<GraphRangeSetting>((list) => { }); 
            SetRangeOfGraphViewModel target = new SetRangeOfGraphViewModel(onApplyEvent); 
            bool expected = false; 
            bool actual;
            target.IsErrorAtFirstYRangeFrom = expected;
            actual = target.IsErrorAtFirstYRangeFrom;
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsErrorAtFirstYRangeTo
        ///</summary>
        [TestMethod()]
        public void IsErrorAtFirstYRangeToTest()
        {
            Action<GraphRangeSetting> onApplyEvent = null; 
            SetRangeOfGraphViewModel target = new SetRangeOfGraphViewModel(onApplyEvent); 
            bool expected = false; 
            bool actual;
            target.IsErrorAtFirstYRangeTo = expected;
            actual = target.IsErrorAtFirstYRangeTo;
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsErrorAtSecondYRangeFrom
        ///</summary>
        [TestMethod()]
        public void IsErrorAtSecondYRangeFromTest()
        {
            Action<GraphRangeSetting> onApplyEvent = new Action<GraphRangeSetting>((list) => { }); 
            SetRangeOfGraphViewModel target = new SetRangeOfGraphViewModel(onApplyEvent); 
            bool expected = false; 
            bool actual;
            target.IsErrorAtSecondYRangeFrom = expected;
            actual = target.IsErrorAtSecondYRangeFrom;
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsErrorAtSecondYRangeTo
        ///</summary>
        [TestMethod()]
        public void IsErrorAtSecondYRangeToTest()
        {
            Action<GraphRangeSetting> onApplyEvent = new Action<GraphRangeSetting>((list) => { }); 
            SetRangeOfGraphViewModel target = new SetRangeOfGraphViewModel(onApplyEvent); 
            bool expected = false; 
            bool actual;
            target.IsErrorAtSecondYRangeTo = expected;
            actual = target.IsErrorAtSecondYRangeTo;
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsValidDateTime
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsValidDateTimeTest()
        {
            Action<GraphRangeSetting> onApplyEvent = new Action<GraphRangeSetting>((list) => { });
            SetRangeOfGraphViewModel range = new SetRangeOfGraphViewModel(onApplyEvent);
            PrivateObject param0 = new PrivateObject(range); 
            SetRangeOfGraphViewModel_Accessor target = new SetRangeOfGraphViewModel_Accessor(param0); 
            target._setting = new GraphRangeSetting();
            target.From = new DateTime(2014,6,7);
            target.To = new DateTime(2014,6,9);
            Assert.IsTrue(target.IsValidDateTime);
        }

        /// <summary>
        ///A test for IsValidDateTime
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsValidDateTimeTest_False()
        {
            Action<GraphRangeSetting> onApplyEvent = new Action<GraphRangeSetting>((list) => { });
            SetRangeOfGraphViewModel range = new SetRangeOfGraphViewModel(onApplyEvent);
            PrivateObject param0 = new PrivateObject(range);
            SetRangeOfGraphViewModel_Accessor target = new SetRangeOfGraphViewModel_Accessor(param0);
            target._setting = new GraphRangeSetting();
            target.From = new DateTime(2014, 6, 7);
            target.To = new DateTime(2013, 6, 9);
            Assert.IsFalse(target.IsValidDateTime);
        }

        /// <summary>
        ///A test for IsValidFirstYRange
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsValidFirstYRangeTest()
        {
            Action<GraphRangeSetting> onApplyEvent = new Action<GraphRangeSetting>((list) => { });
            SetRangeOfGraphViewModel range = new SetRangeOfGraphViewModel(onApplyEvent);
            PrivateObject param0 = new PrivateObject(range); 
            SetRangeOfGraphViewModel_Accessor target = new SetRangeOfGraphViewModel_Accessor(param0); 
            target._setting = new GraphRangeSetting();
            target.FirstYRangeFrom = 1.1;
            target.FirstYRangeTo = 2.2;
            Assert.IsTrue(target.IsValidFirstYRange);
        }

        /// <summary>
        ///A test for IsValidFirstYRange
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsValidFirstYRangeTest_False()
        {
            Action<GraphRangeSetting> onApplyEvent = new Action<GraphRangeSetting>((list) => { });
            SetRangeOfGraphViewModel range = new SetRangeOfGraphViewModel(onApplyEvent);
            PrivateObject param0 = new PrivateObject(range);
            SetRangeOfGraphViewModel_Accessor target = new SetRangeOfGraphViewModel_Accessor(param0);
            target._setting = new GraphRangeSetting();
            target.FirstYRangeFrom = 1.1;
            target.FirstYRangeTo = 0.2;
            Assert.IsFalse(target.IsValidFirstYRange);
        }

        /// <summary>
        ///A test for IsValidSecondYRange
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsValidSecondYRangeTest()
        {
            Action<GraphRangeSetting> onApplyEvent = new Action<GraphRangeSetting>((list) => { });
            SetRangeOfGraphViewModel range = new SetRangeOfGraphViewModel(onApplyEvent);
            PrivateObject param0 = new PrivateObject(range); 
            SetRangeOfGraphViewModel_Accessor target = new SetRangeOfGraphViewModel_Accessor(param0); 
            target._setting = new GraphRangeSetting();
            target.SecondYRangeFrom = 1.1;
            target.SecondYRangeTo = 2.2;
            Assert.IsTrue(target.IsValidSecondYRange);
        }

        /// <summary>
        ///A test for IsValidSecondYRange
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void IsValidSecondYRangeTest_False()
        {
            Action<GraphRangeSetting> onApplyEvent = new Action<GraphRangeSetting>((list) => { });
            SetRangeOfGraphViewModel range = new SetRangeOfGraphViewModel(onApplyEvent);
            PrivateObject param0 = new PrivateObject(range);
            SetRangeOfGraphViewModel_Accessor target = new SetRangeOfGraphViewModel_Accessor(param0);
            target._setting = new GraphRangeSetting();
            target.SecondYRangeFrom = 1.1;
            target.SecondYRangeTo = 0.2;
            Assert.IsFalse(target.IsValidSecondYRange);
        }

        /// <summary>
        ///A test for Max
        ///</summary>
        [TestMethod()]
        public void MaxTest()
        {
            Action<GraphRangeSetting> onApplyEvent = new Action<GraphRangeSetting>((list) => { }); 
            SetRangeOfGraphViewModel target = new SetRangeOfGraphViewModel(onApplyEvent); 
            string expected = string.Empty; 
            string actual;
            target.Max = expected;
            actual = target.Max;
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Min
        ///</summary>
        [TestMethod()]
        public void MinTest()
        {
            Action<GraphRangeSetting> onApplyEvent = new Action<GraphRangeSetting>((list) => { }); 
            SetRangeOfGraphViewModel target = new SetRangeOfGraphViewModel(onApplyEvent); 
            string expected = string.Empty; 
            string actual;
            target.Min = expected;
            actual = target.Min;
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SecondYRangeFrom
        ///</summary>
        [TestMethod()]
        public void SecondYRangeFromTest()
        {
            Action<GraphRangeSetting> onApplyEvent = new Action<GraphRangeSetting>((list) => { }); 
            SetRangeOfGraphViewModel range = new SetRangeOfGraphViewModel(onApplyEvent);
            PrivateObject param0 = new PrivateObject(range);
            //SetRangeOfGraphViewModel target = new SetRangeOfGraphViewModel(onApplyEvent); 
            SetRangeOfGraphViewModel_Accessor target = new SetRangeOfGraphViewModel_Accessor(param0);
            target._setting = new GraphRangeSetting();
            double expected = 0F; 
            double actual;
            target.SecondYRangeFrom = expected;
            actual = target.SecondYRangeFrom;
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SecondYRangeTo
        ///</summary>
        [TestMethod()]
        public void SecondYRangeToTest()
        {
            Action<GraphRangeSetting> onApplyEvent = new Action<GraphRangeSetting>((list) => { }); 
            SetRangeOfGraphViewModel range = new SetRangeOfGraphViewModel(onApplyEvent); 
            PrivateObject param0 = new PrivateObject(range);
            SetRangeOfGraphViewModel_Accessor target = new SetRangeOfGraphViewModel_Accessor(param0);
            target._setting = new GraphRangeSetting();
            double expected = 0F; 
            double actual;
            target.SecondYRangeTo = expected;
            actual = target.SecondYRangeTo;
            Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Setting
        ///</summary>
        [TestMethod()]
        public void SettingTest()
        {
            Action<GraphRangeSetting> onApplyEvent = new Action<GraphRangeSetting>((list) => { }); 
            SetRangeOfGraphViewModel target = new SetRangeOfGraphViewModel(onApplyEvent); 
            GraphRangeSetting expected = null; 
            GraphRangeSetting actual;
            target.Setting = expected;
            actual = target.Setting;
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for To
        ///</summary>
        [TestMethod()]
        public void ToTest()
        {
            Action<GraphRangeSetting> onApplyEvent = new Action<GraphRangeSetting>((list) => { }); 
            SetRangeOfGraphViewModel range = new SetRangeOfGraphViewModel(onApplyEvent); 
            PrivateObject param0 = new PrivateObject(range);
            SetRangeOfGraphViewModel_Accessor target = new SetRangeOfGraphViewModel_Accessor(param0);
            target._setting = new GraphRangeSetting();
            DateTime expected = new DateTime(); 
            DateTime actual;
            target.To = expected;
            actual = target.To;
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
