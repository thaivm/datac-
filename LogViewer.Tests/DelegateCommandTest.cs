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
    public class DelegateCommandTest
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
        ///A test for DelegateCommand`1 Constructor
        ///</summary>
        public void DelegateCommandConstructorTestHelper<T>()
        {
            Action<T> executeMethod = null; // TODO: Initialize to an appropriate value
            Func<T, bool> canExecuteMethod = null; // TODO: Initialize to an appropriate value
            bool isAutomaticRequeryDisabled = false; // TODO: Initialize to an appropriate value
            DelegateCommand<T> target = new DelegateCommand<T>(executeMethod, canExecuteMethod, isAutomaticRequeryDisabled);
        }

        [TestMethod()]
        public void DelegateCommandConstructorTest()
        {
            DelegateCommandConstructorTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for DelegateCommand`1 Constructor
        ///</summary>
        public void DelegateCommandConstructorTest1Helper<T>()
        {
            Action<T> executeMethod = null; // TODO: Initialize to an appropriate value
            Func<T, bool> canExecuteMethod = null; // TODO: Initialize to an appropriate value
            DelegateCommand<T> target = new DelegateCommand<T>(executeMethod, canExecuteMethod);
        }

        [TestMethod()]
        public void DelegateCommandConstructorTest1()
        {
            DelegateCommandConstructorTest1Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for DelegateCommand`1 Constructor
        ///</summary>
        public void DelegateCommandConstructorTest2Helper<T>()
        {
            Action<T> executeMethod = null; // TODO: Initialize to an appropriate value
            DelegateCommand<T> target = new DelegateCommand<T>(executeMethod);
        }

        [TestMethod()]
        public void DelegateCommandConstructorTest2()
        {
            DelegateCommandConstructorTest2Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for CanExecute
        ///</summary>
        [TestMethod()]
        public void CanExecuteTest()
        {
            Action<CCSLogRecord> executeMethod = new Action<CCSLogRecord>((record) => { });
            DelegateCommand<CCSLogRecord> target = new DelegateCommand<CCSLogRecord>(executeMethod);
            CCSLogRecord parameter = default(CCSLogRecord); 
            bool expected = true;
            bool actual;
            actual = target.CanExecute(parameter);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void CanExecuteTest_NotNull()
        {
            Action<CCSLogRecord> executeMethod = new Action<CCSLogRecord>((record) => { });
            Func<CCSLogRecord, bool> canExecuteMethod = new Func<CCSLogRecord, bool>((re) => { return true; });
            DelegateCommand_Accessor<CCSLogRecord> target = new DelegateCommand_Accessor<CCSLogRecord>(executeMethod, canExecuteMethod);
            CCSLogRecord parameter = default(CCSLogRecord);
            bool expected = true;
            bool actual;
            actual = target.CanExecute(parameter);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for Execute
        ///</summary>
        [TestMethod()]
        public void ExecuteTest()
        {
            Action<CCSLogRecord> executeMethod = null;
            DelegateCommand<CCSLogRecord> target = new DelegateCommand<CCSLogRecord>(executeMethod);
            CCSLogRecord parameter = default(CCSLogRecord);
            target.Execute(parameter);
        }
        [TestMethod()]
        public void ExecuteNotNullTest()
        {
            Action<CCSLogRecord> executeMethod = new Action<CCSLogRecord>((record) => { });
            DelegateCommand<CCSLogRecord> target = new DelegateCommand<CCSLogRecord>(executeMethod);
            CCSLogRecord parameter = default(CCSLogRecord);
            target.Execute(parameter);
        }

        /// <summary>
        ///A test for OnCanExecuteChanged
        ///</summary>
        [TestMethod()]
        public void OnCanExecuteChangedTest()
        {
            PrivateObject param0 = new PrivateObject(new DelegateCommand<CCSLogRecord>((record) => { })); 
            DelegateCommand_Accessor<CCSLogRecord> target = new DelegateCommand_Accessor<CCSLogRecord>(param0);
            target.OnCanExecuteChanged();
        }

        /// <summary>
        ///A test for RaiseCanExecuteChanged
        ///</summary>
        [TestMethod()]
        public void RaiseCanExecuteChangedTest()
        {
            Action<CCSLogRecord> executeMethod = null; 
            DelegateCommand<CCSLogRecord> target = new DelegateCommand<CCSLogRecord>(executeMethod); 
            target.RaiseCanExecuteChanged();
        }

        /// <summary>
        ///A test for System.Windows.Input.ICommand.CanExecute
        ///</summary>
        [TestMethod()]
        public void CanExecuteExecuteMethodNullTest1()
        {
            Action<CCSLogRecord> executeMethod = null;
            ICommand target = new DelegateCommand<CCSLogRecord>(executeMethod); 
            object parameter = null;
            bool expected = true;
            bool actual;
            actual = target.CanExecute(parameter);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void CanExecuteExecuteMethodNotNullTest1()
        {
            Action<CCSLogRecord> executeMethod = new Action<CCSLogRecord>((re) => { });
            Func<CCSLogRecord, bool> canExecuteMethod = new Func<CCSLogRecord, bool>((re) => { return true; });
            ICommand target = new DelegateCommand<CCSLogRecord>(executeMethod, canExecuteMethod);
            CCSLogRecord parameter = new CCSLogRecord();
            bool expected = true;
            bool actual;
            actual = target.CanExecute(parameter);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for System.Windows.Input.ICommand.Execute
        ///</summary>
        [TestMethod()]
        public void ExecuteExecuteMethodNullTest1()
        {
            Action<CCSLogRecord> executeMethod = null;
            ICommand target = new DelegateCommand<CCSLogRecord>(executeMethod);
            object parameter = null;
            target.Execute(parameter);
        }
        [TestMethod()]
        public void ExecuteExecuteMethodNotNullTest1()
        {
            Action<CCSLogRecord> executeMethod = new Action<CCSLogRecord>((re) => { });
            ICommand target = new DelegateCommand<CCSLogRecord>(executeMethod);
            object parameter = null;
            target.Execute(parameter);
        }
        /// <summary>
        ///A test for IsAutomaticRequeryDisabled
        ///</summary>
        [TestMethod()]
        public void IsAutomaticRequeryDisabledTrueTest()
        {
            Action<CCSLogRecord> executeMethod = null;
            DelegateCommand<CCSLogRecord> target = new DelegateCommand<CCSLogRecord>(executeMethod);
            bool expected = true;
            bool actual;
            target.IsAutomaticRequeryDisabled = expected;
            actual = target.IsAutomaticRequeryDisabled;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsAutomaticRequeryDisabledFalseTest()
        {
            Action<CCSLogRecord> executeMethod = null;
            DelegateCommand<CCSLogRecord> target = new DelegateCommand<CCSLogRecord>(executeMethod);
            bool expected = false;
            bool actual;
            target.IsAutomaticRequeryDisabled = true;
            target.IsAutomaticRequeryDisabled = expected;
            actual = target.IsAutomaticRequeryDisabled;
            Assert.AreEqual(expected, actual);
        }
    }
}
