using LogViewer.MVVMHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using System.Windows.Input;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for CommandReferenceTest and is intended
    ///to contain all CommandReferenceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CommandReferenceTest
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
        ///A test for CanExecute
        ///</summary>
        [TestMethod()]
        public void CanExecuteCommandIsNullTest()
        {
            CommandReference target = new CommandReference(); 
            object parameter = null; 
            bool expected = false; 
            bool actual;
            actual = target.CanExecute(parameter);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void CanExecuteCommandIsNotNullTest()
        {
            CommandReference target = new CommandReference();
            Action parameter = new Action(() => { });
            target.Command = new DelegateCommand(parameter, () => isTrue());
            bool actual;
            actual = target.CanExecute(parameter);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for Command
        ///</summary>
        [TestMethod()]
        public void CommandTest()
        {
            CommandReference target = new CommandReference(); 
            ICommand expected = null; 
            ICommand actual;
            target.Command = expected;
            actual = target.Command;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CreateInstanceCore
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void CreateInstanceCoreTest()
        {
            CommandReference_Accessor target = new CommandReference_Accessor();
            Freezable actual;
            actual = target.CreateInstanceCore();
        }

        /// <summary>
        ///A test for Execute
        ///</summary>
        [TestMethod()]
        public void ExecuteTest()
        {
            CommandReference target = new CommandReference();
            Action parameter = new Action(() => { });
            target.Command = new DelegateCommand(parameter, ()=> isTrue());
            target.Execute(null);
        }

        public bool isTrue()
        {
            return true;
        }
        /// <summary>
        ///A test for OnCommandChanged
        ///</summary>
        [TestMethod()]
        public void OnCommandChangedTest()
        {
            CommandReference target = new CommandReference();
            Action parameter = new Action(() => { });
            target.Command = new DelegateCommand(parameter, () => isTrue());
            DependencyPropertyChangedEventArgs e = new DependencyPropertyChangedEventArgs();
            CommandReference_Accessor.OnCommandChanged(target, e);
        }
        [TestMethod()]
        public void OnCommandChangedOldCommandTest()
        {
            CommandReference target = new CommandReference();
            Action parameter = new Action(() => { });
            target.Command = new DelegateCommand(parameter, () => isTrue());
            DependencyPropertyChangedEventArgs e = new DependencyPropertyChangedEventArgs(CommandReference.CommandProperty, target.Command, target.Command);
            CommandReference_Accessor.OnCommandChanged(target, e);
        }
    }
}
