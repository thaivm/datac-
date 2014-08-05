using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Input;
using LogViewer.Model;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for DelegateCommandTest and is intended
    ///to contain all DelegateCommandTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DelegateCommandNotGenericTest
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
        ///A test for DelegateCommand Constructor
        ///</summary>
        [TestMethod()]
        public void DelegateCommandConstructorTest()
        {
            Action executeMethod = null; 
            Func<bool> canExecuteMethod = null; 
            bool isAutomaticRequeryDisabled = false; 
            DelegateCommand target = new DelegateCommand(executeMethod, canExecuteMethod, isAutomaticRequeryDisabled);
        }

        /// <summary>
        ///A test for DelegateCommand Constructor
        ///</summary>
        [TestMethod()]
        public void DelegateCommandConstructorTest1()
        {
            Action executeMethod = null; 
            Func<bool> canExecuteMethod = null; 
            DelegateCommand target = new DelegateCommand(executeMethod, canExecuteMethod);
        }

        /// <summary>
        ///A test for DelegateCommand Constructor
        ///</summary>
        [TestMethod()]
        //[ExpectedException()]
        public void DelegateCommandConstructorTest2()
        {
            Action executeMethod = null; 
            DelegateCommand target = new DelegateCommand(executeMethod);
        }

        /// <summary>
        ///A test for CanExecute
        ///</summary>
        [TestMethod()]
        public void CanExecuteTest()
        {
            Action executeMethod = new Action(()=>{string s="";}); 
            DelegateCommand target = new DelegateCommand(executeMethod); 
            bool expected = true; 
            bool actual;
            actual = target.CanExecute();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Execute
        ///</summary>
        [TestMethod()]
        public void ExecuteTest()
        {
            Action executeMethod = null; 
            DelegateCommand target = new DelegateCommand(executeMethod); 
            target.Execute();
        }

        /// <summary>
        ///A test for OnCanExecuteChanged
        ///</summary>
        [TestMethod()]
        public void OnCanExecuteChangedTest()
        {
            PrivateObject param0 = new PrivateObject(new DelegateCommand(() => { })); 
            DelegateCommand_Accessor target = new DelegateCommand_Accessor(param0); 
            target.OnCanExecuteChanged();
        }

        /// <summary>
        ///A test for RaiseCanExecuteChanged
        ///</summary>
        [TestMethod()]
        public void RaiseCanExecuteChangedTest()
        {
            Action executeMethod = null; 
            DelegateCommand target = new DelegateCommand(executeMethod); 
            target.RaiseCanExecuteChanged();
        }

        /// <summary>
        ///A test for System.Windows.Input.ICommand.CanExecute
        ///</summary>
        [TestMethod()]
        public void CanExecuteTest1()
        {
            Action executeMethod = null; 
            ICommand target = new DelegateCommand(executeMethod); 
            object parameter = null; 
            bool expected = true; 
            bool actual;
            actual = target.CanExecute(parameter);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for System.Windows.Input.ICommand.Execute
        ///</summary>
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void ExecuteTest1()
        {
            Action executeMethod = null; 
            ICommand target = new DelegateCommand(executeMethod); 
            object parameter = null; 
            target.Execute(parameter);
        }

        /// <summary>
        ///A test for IsAutomaticRequeryDisabled
        ///</summary>
        [TestMethod()]
        public void IsAutomaticRequeryDisabledTest()
        {
            Action executeMethod = null; 
            DelegateCommand target = new DelegateCommand(executeMethod); 
            bool expected = false; 
            bool actual;
            target.IsAutomaticRequeryDisabled = expected;
            actual = target.IsAutomaticRequeryDisabled;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void IsAutomaticRequeryDisabledTrueTest()
        {
            Action executeMethod = null;
            DelegateCommand target = new DelegateCommand(executeMethod);
            bool expected = true;
            bool actual;
            target.IsAutomaticRequeryDisabled = expected;
            actual = target.IsAutomaticRequeryDisabled;
            Assert.AreEqual(expected, actual);
        }
    }
}
