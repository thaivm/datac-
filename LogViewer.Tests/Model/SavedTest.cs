﻿using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for SavedTest and is intended
    ///to contain all SavedTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SavedTest
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
        ///A test for parameter
        ///</summary>
        [TestMethod()]
        public void parameterTest()
        {
            Saved target = new Saved(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.parameter = expected;
            actual = target.parameter;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for value
        ///</summary>
        [TestMethod()]
        public void valueTest()
        {
            Saved target = new Saved(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.value = expected;
            actual = target.value;
            Assert.AreEqual(expected, actual);
        }
    }
}
