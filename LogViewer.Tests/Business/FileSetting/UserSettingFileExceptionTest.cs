using System;
using LogViewer.Business.FileSetting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.Business.FileSetting
{
    
    
    /// <summary>
    ///This is a test class for UserSettingFileExceptionTest and is intended
    ///to contain all UserSettingFileExceptionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserSettingFileExceptionTest
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


        [TestMethod()]
        public void UserSettingFileExceptionConstructorTest()
        {
            string message = string.Empty;
            Exception inner = new Exception(); 
            UserSettingFileException target = new UserSettingFileException(message, inner);
            Assert.IsNotNull(target);
        }

        [TestMethod()]
        public void UserSettingFileExceptionConstructorTest1()
        {
            string message = string.Empty; 
            UserSettingFileException target = new UserSettingFileException(message);
            Assert.IsNotNull(target);
        }

        [TestMethod()]
        public void UserSettingFileExceptionConstructorTest2()
        {
            UserSettingFileException target = new UserSettingFileException();
            Assert.IsNotNull(target);
        }
    }
}
