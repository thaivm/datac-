using LogViewer.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Resources;
using LogViewer.Properties;

namespace LogViewer.Tests
{
    
    
    /// <summary>
    ///This is a test class for ResourcesTest and is intended
    ///to contain all ResourcesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ResourcesTest
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
        ///A test for Resources Constructor
        ///</summary>
        [TestMethod()]
        public void ResourcesConstructorTest()
        {
            LogViewer.Properties.Resources target = new LogViewer.Properties.Resources();
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Add", culture);
            var actual = LogViewer.Properties.Resources.Add;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AddPatternItem
        ///</summary>
        [TestMethod()]
        public void AddPatternItemTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("AddPatternItem", culture);
            var actual = LogViewer.Properties.Resources.AddPatternItem;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AdditionalInfo
        ///</summary>
        [TestMethod()]
        public void AdditionalInfoTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("AdditionalInfo", culture);
            var actual = LogViewer.Properties.Resources.AdditionalInfo;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Apply
        ///</summary>
        [TestMethod()]
        public void ApplyTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Apply", culture);
            var actual = LogViewer.Properties.Resources.Apply;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for BackGroundColor
        ///</summary>
        [TestMethod()]
        public void BackGroundColorTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("BackGroundColor", culture);
            var actual = LogViewer.Properties.Resources.BackGroundColor;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Bookmark
        ///</summary>
        [TestMethod()]
        public void BookmarkTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Bookmark", culture);
            var actual = LogViewer.Properties.Resources.Bookmark;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Bookmarks
        ///</summary>
        [TestMethod()]
        public void BookmarksTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Bookmarks", culture);
            var actual = LogViewer.Properties.Resources.Bookmarks;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CAN_NOT_CREATE_FILE
        ///</summary>
        [TestMethod()]
        public void CAN_NOT_CREATE_FILETest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("CAN_NOT_CREATE_FILE", culture);
            var actual = LogViewer.Properties.Resources.CAN_NOT_CREATE_FILE;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CCS
        ///</summary>
        [TestMethod()]
        public void CCSTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("CCS", culture);
            var actual = LogViewer.Properties.Resources.CCS;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CCSLogFile
        ///</summary>
        [TestMethod()]
        public void CCSLogFileTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("CCSLogFile", culture);
            var actual = LogViewer.Properties.Resources.CCSLogFile;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CCSMemoLogFile
        ///</summary>
        [TestMethod()]
        public void CCSMemoLogFileTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("CCSMemoLogFile", culture);
            var actual = LogViewer.Properties.Resources.CCSMemoLogFile;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CXDI
        ///</summary>
        [TestMethod()]
        public void CXDITest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("CXDI", culture);
            var actual = LogViewer.Properties.Resources.CXDI;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CXDILogFile
        ///</summary>
        [TestMethod()]
        public void CXDILogFileTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("CXDILogFile", culture);
            var actual = LogViewer.Properties.Resources.CXDILogFile;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CXDIMemoLogFile
        ///</summary>
        [TestMethod()]
        public void CXDIMemoLogFileTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("CXDIMemoLogFile", culture);
            var actual = LogViewer.Properties.Resources.CXDIMemoLogFile;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Cancel
        ///</summary>
        [TestMethod()]
        public void CancelTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Cancel", culture);
            var actual = LogViewer.Properties.Resources.Cancel;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ClassName
        ///</summary>
        [TestMethod()]
        public void ClassNameTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ClassName", culture);
            var actual = LogViewer.Properties.Resources.ClassName;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Clear
        ///</summary>
        [TestMethod()]
        public void ClearTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Clear", culture);
            var actual = LogViewer.Properties.Resources.Clear;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Colon
        ///</summary>
        [TestMethod()]
        public void ColonTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Colon", culture);
            var actual = LogViewer.Properties.Resources.Colon;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Comment
        ///</summary>
        [TestMethod()]
        public void CommentTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Comment", culture);
            var actual = LogViewer.Properties.Resources.Comment;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Confirm
        ///</summary>
        [TestMethod()]
        public void ConfirmTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Confirm", culture);
            var actual = LogViewer.Properties.Resources.Confirm;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ConfirmMergeFileCaption
        ///</summary>
        [TestMethod()]
        public void ConfirmMergeFileCaptionTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ConfirmMergeFileCaption", culture);
            var actual = LogViewer.Properties.Resources.ConfirmMergeFileCaption;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ConfirmMergeFileMessage
        ///</summary>
        [TestMethod()]
        public void ConfirmMergeFileMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ConfirmMergeFileMessage", culture);
            var actual = LogViewer.Properties.Resources.ConfirmMergeFileMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Content
        ///</summary>
        [TestMethod()]
        public void ContentTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Content", culture);
            var actual = LogViewer.Properties.Resources.Content;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Contents
        ///</summary>
        [TestMethod()]
        public void ContentsTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Contents", culture);
            var actual = LogViewer.Properties.Resources.Contents;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Copy
        ///</summary>
        [TestMethod()]
        public void CopyTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Copy", culture);
            var actual = LogViewer.Properties.Resources.Copy;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Count
        ///</summary>
        [TestMethod()]
        public void CountTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Count", culture);
            var actual = LogViewer.Properties.Resources.Count;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CounterParameter
        ///</summary>
        [TestMethod()]
        public void CounterParameterTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("CounterParameter", culture);
            var actual = LogViewer.Properties.Resources.CounterParameter;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Culture
        ///</summary>
        [TestMethod()]
        public void CultureTest()
        {
            CultureInfo expected = new CultureInfo(1); // TODO: Initialize to an appropriate value
            CultureInfo actual;
            LogViewer.Properties.Resources.Culture = expected;
            actual = LogViewer.Properties.Resources.Culture;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for DATA_VALUE_NOT_SUPPORTED_EXCEPTION_MESSAGE
        ///</summary>
        [TestMethod()]
        public void DATA_VALUE_NOT_SUPPORTED_EXCEPTION_MESSAGETest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("DATA_VALUE_NOT_SUPPORTED_EXCEPTION_MESSAGE", culture);
            var actual = LogViewer.Properties.Resources.DATA_VALUE_NOT_SUPPORTED_EXCEPTION_MESSAGE;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for DATE_DISPLAY_TEXT
        ///</summary>
        [TestMethod()]
        public void DATE_DISPLAY_TEXTTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("DATE_DISPLAY_TEXT", culture);
            var actual = LogViewer.Properties.Resources.DATE_DISPLAY_TEXT;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Date
        ///</summary>
        [TestMethod()]
        public void DateTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Date", culture);
            var actual = LogViewer.Properties.Resources.Date;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for DateColon
        ///</summary>
        [TestMethod()]
        public void DateColonTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("DateColon", culture);
            var actual = LogViewer.Properties.Resources.DateColon;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for DateTime
        ///</summary>
        [TestMethod()]
        public void DateTimeTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("DateTime", culture);
            var actual = LogViewer.Properties.Resources.DateTime;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for DateTimeToGreaterThanFromValueErrorMessage
        ///</summary>
        [TestMethod()]
        public void DateTimeToGreaterThanFromValueErrorMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("DateTimeToGreaterThanFromValueErrorMessage", culture);
            var actual = LogViewer.Properties.Resources.DateTimeToGreaterThanFromValueErrorMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Delete", culture);
            var actual = LogViewer.Properties.Resources.Delete;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for DuplicateKeywordErrorMessage
        ///</summary>
        [TestMethod()]
        public void DuplicateKeywordErrorMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("DuplicateKeywordErrorMessage", culture);
            var actual = LogViewer.Properties.Resources.DuplicateKeywordErrorMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for DuplicateKeywordWithLogItemErrorMessage
        ///</summary>
        [TestMethod()]
        public void DuplicateKeywordWithLogItemErrorMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("DuplicateKeywordWithLogItemErrorMessage", culture);
            var actual = LogViewer.Properties.Resources.DuplicateKeywordWithLogItemErrorMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for DuplicateNameErrorMessage
        ///</summary>
        [TestMethod()]
        public void DuplicateNameErrorMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("DuplicateNameErrorMessage", culture);
            var actual = LogViewer.Properties.Resources.DuplicateNameErrorMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Edit
        ///</summary>
        [TestMethod()]
        public void EditTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Edit", culture);
            var actual = LogViewer.Properties.Resources.Edit;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for EditPatternItem
        ///</summary>
        [TestMethod()]
        public void EditPatternItemTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("EditPatternItem", culture);
            var actual = LogViewer.Properties.Resources.EditPatternItem;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Elements
        ///</summary>
        [TestMethod()]
        public void ElementsTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Elements", culture);
            var actual = LogViewer.Properties.Resources.Elements;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Enable
        ///</summary>
        [TestMethod()]
        public void EnableTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Enable", culture);
            var actual = LogViewer.Properties.Resources.Enable;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Error
        ///</summary>
        [TestMethod()]
        public void ErrorTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Error", culture);
            var actual = LogViewer.Properties.Resources.Error;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ErrorAction
        ///</summary>
        [TestMethod()]
        public void ErrorActionTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ErrorAction", culture);
            var actual = LogViewer.Properties.Resources.ErrorAction;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ErrorCode
        ///</summary>
        [TestMethod()]
        public void ErrorCodeTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ErrorCode", culture);
            var actual = LogViewer.Properties.Resources.ErrorCode;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ErrorMessage
        ///</summary>
        [TestMethod()]
        public void ErrorMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ErrorMessage", culture);
            var actual = LogViewer.Properties.Resources.ErrorMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ErrorRecipe
        ///</summary>
        [TestMethod()]
        public void ErrorRecipeTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ErrorRecipe", culture);
            var actual = LogViewer.Properties.Resources.ErrorRecipe;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Event
        ///</summary>
        [TestMethod()]
        public void EventTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Event", culture);
            var actual = LogViewer.Properties.Resources.Event;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Exporting3Dot
        ///</summary>
        [TestMethod()]
        public void Exporting3DotTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Exporting3Dot", culture);
            var actual = LogViewer.Properties.Resources.Exporting3Dot;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for EXPORT_FAILURE
        ///</summary>
        [TestMethod()]
        public void EXPORT_FAILURETest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("EXPORT_FAILURE", culture);
            var actual = LogViewer.Properties.Resources.EXPORT_FAILURE;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FILE_LOG_LOAD_CAPTION
        ///</summary>
        [TestMethod()]
        public void FILE_LOG_LOAD_CAPTIONTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("FILE_LOG_LOAD_CAPTION", culture);
            var actual = LogViewer.Properties.Resources.FILE_LOG_LOAD_CAPTION;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FILE_LOG_LOAD_EXCEPTION
        ///</summary>
        [TestMethod()]
        public void FILE_LOG_LOAD_EXCEPTIONTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("FILE_LOG_LOAD_EXCEPTION", culture);
            var actual = LogViewer.Properties.Resources.FILE_LOG_LOAD_EXCEPTION;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FILE_LOG_LOAD_INVALID_EXTENSION
        ///</summary>
        [TestMethod()]
        public void FILE_LOG_LOAD_INVALID_EXTENSIONTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("FILE_LOG_LOAD_INVALID_EXTENSION", culture);
            var actual = LogViewer.Properties.Resources.FILE_LOG_LOAD_INVALID_EXTENSION;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FILE_WRITE_EXCEPTION
        ///</summary>
        [TestMethod()]
        public void FILE_WRITE_EXCEPTIONTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("FILE_WRITE_EXCEPTION", culture);
            var actual = LogViewer.Properties.Resources.FILE_WRITE_EXCEPTION;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FIND_OWNER_WINDOW_ARGUMENT_EXCEPTION
        ///</summary>
        [TestMethod()]
        public void FIND_OWNER_WINDOW_ARGUMENT_EXCEPTIONTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("FIND_OWNER_WINDOW_ARGUMENT_EXCEPTION", culture);
            var actual = LogViewer.Properties.Resources.FIND_OWNER_WINDOW_ARGUMENT_EXCEPTION;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FIND_OWNER_WINDOW_INVALID_OPERATION_EXCEPTION
        ///</summary>
        [TestMethod()]
        public void FIND_OWNER_WINDOW_INVALID_OPERATION_EXCEPTIONTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("FIND_OWNER_WINDOW_INVALID_OPERATION_EXCEPTION", culture);
            var actual = LogViewer.Properties.Resources.FIND_OWNER_WINDOW_INVALID_OPERATION_EXCEPTION;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FilterColon
        ///</summary>
        [TestMethod()]
        public void FilterColonTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("FilterColon", culture);
            var actual = LogViewer.Properties.Resources.FilterColon;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FilterNameColon
        ///</summary>
        [TestMethod()]
        public void FilterNameColonTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("FilterNameColon", culture);
            var actual = LogViewer.Properties.Resources.FilterNameColon;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FilterSetting
        ///</summary>
        [TestMethod()]
        public void FilterSettingTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("FilterSetting", culture);
            var actual = LogViewer.Properties.Resources.FilterSetting;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FilterStringColon
        ///</summary>
        [TestMethod()]
        public void FilterStringColonTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("FilterStringColon", culture);
            var actual = LogViewer.Properties.Resources.FilterStringColon;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Firmware
        ///</summary>
        [TestMethod()]
        public void FirmwareTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Firmware", culture);
            var actual = LogViewer.Properties.Resources.Firmware;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FirstYToGreaterThanFromValueErrorMessage
        ///</summary>
        [TestMethod()]
        public void FirstYToGreaterThanFromValueErrorMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("FirstYToGreaterThanFromValueErrorMessage", culture);
            var actual = LogViewer.Properties.Resources.FirstYToGreaterThanFromValueErrorMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FollowMode
        ///</summary>
        [TestMethod()]
        public void FollowModeTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("FollowMode", culture);
            var actual = LogViewer.Properties.Resources.FollowMode;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FontStyle
        ///</summary>
        [TestMethod()]
        public void FontStyleTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("FontStyle", culture);
            var actual = LogViewer.Properties.Resources.FontStyle;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ForeGroundColor
        ///</summary>
        [TestMethod()]
        public void ForeGroundColorTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ForeGroundColor", culture);
            var actual = LogViewer.Properties.Resources.ForeGroundColor;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GRAPH_EXPORT_NO_DATA
        ///</summary>
        [TestMethod()]
        public void GRAPH_EXPORT_NO_DATATest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("GRAPH_EXPORT_NO_DATA", culture);
            var actual = LogViewer.Properties.Resources.GRAPH_EXPORT_NO_DATA;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Graph
        ///</summary>
        [TestMethod()]
        public void GraphTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Graph", culture);
            var actual = LogViewer.Properties.Resources.Graph;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GraphParamSetting
        ///</summary>
        [TestMethod()]
        public void GraphParamSettingTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("GraphParamSetting", culture);
            var actual = LogViewer.Properties.Resources.GraphParamSetting;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for HostName
        ///</summary>
        [TestMethod()]
        public void HostNameTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("HostName", culture);
            var actual = LogViewer.Properties.Resources.HostName;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Id
        ///</summary>
        [TestMethod()]
        public void IdTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Id", culture);
            var actual = LogViewer.Properties.Resources.Id;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for InputKeywordColon
        ///</summary>
        [TestMethod()]
        public void InputKeywordColonTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("InputKeywordColon", culture);
            var actual = LogViewer.Properties.Resources.InputKeywordColon;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ItemTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Item", culture);
            var actual = LogViewer.Properties.Resources.Item;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for JumpTo
        ///</summary>
        [TestMethod()]
        public void JumpToTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("JumpTo", culture);
            var actual = LogViewer.Properties.Resources.JumpTo;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for KeywordColon
        ///</summary>
        [TestMethod()]
        public void KeywordColonTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("KeywordColon", culture);
            var actual = LogViewer.Properties.Resources.KeywordColon;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for KeywordCount
        ///</summary>
        [TestMethod()]
        public void KeywordCountTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("KeywordCount", culture);
            var actual = LogViewer.Properties.Resources.KeywordCount;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for KeywordCountSetting
        ///</summary>
        [TestMethod()]
        public void KeywordCountSettingTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("KeywordCountSetting", culture);
            var actual = LogViewer.Properties.Resources.KeywordCountSetting;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LOG
        ///</summary>
        [TestMethod()]
        public void LOGTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("LOG", culture);
            var actual = LogViewer.Properties.Resources.LOG;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Level
        ///</summary>
        [TestMethod()]
        public void LevelTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Level", culture);
            var actual = LogViewer.Properties.Resources.Level;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Line
        ///</summary>
        [TestMethod()]
        public void LineTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Line", culture);
            var actual = LogViewer.Properties.Resources.Line;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LineNumber
        ///</summary>
        [TestMethod()]
        public void LineNumberTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("LineNumber", culture);
            var actual = LogViewer.Properties.Resources.LineNumber;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Loading_Summary
        ///</summary>
        [TestMethod()]
        public void Loading_SummaryTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Loading_Summary", culture);
            var actual = LogViewer.Properties.Resources.Loading_Summary;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Loading_Window_Title
        ///</summary>
        [TestMethod()]
        public void Loading_Window_TitleTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Loading_Window_Title", culture);
            var actual = LogViewer.Properties.Resources.Loading_Window_Title;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LogDisplaySetting
        ///</summary>
        [TestMethod()]
        public void LogDisplaySettingTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("LogDisplaySetting", culture);
            var actual = LogViewer.Properties.Resources.LogDisplaySetting;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LogId
        ///</summary>
        [TestMethod()]
        public void LogIdTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("LogId", culture);
            var actual = LogViewer.Properties.Resources.LogId;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LogItem
        ///</summary>
        [TestMethod()]
        public void LogItemTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("LogItem", culture);
            var actual = LogViewer.Properties.Resources.LogItem;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LogItemColon
        ///</summary>
        [TestMethod()]
        public void LogItemColonTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("LogItemColon", culture);
            var actual = LogViewer.Properties.Resources.LogItemColon;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LogItemNotEmptyErrorMessage
        ///</summary>
        [TestMethod()]
        public void LogItemNotEmptyErrorMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("LogItemNotEmptyErrorMessage", culture);
            var actual = LogViewer.Properties.Resources.LogItemNotEmptyErrorMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LogKindTarget_CCS
        ///</summary>
        [TestMethod()]
        public void LogKindTarget_CCSTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("LogKindTarget_CCS", culture);
            var actual = LogViewer.Properties.Resources.LogKindTarget_CCS;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LogKindTarget_CCS_CXDI
        ///</summary>
        [TestMethod()]
        public void LogKindTarget_CCS_CXDITest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("LogKindTarget_CCS_CXDI", culture);
            var actual = LogViewer.Properties.Resources.LogKindTarget_CCS_CXDI;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LogKindTarget_CXDI
        ///</summary>
        [TestMethod()]
        public void LogKindTarget_CXDITest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("LogKindTarget_CXDI", culture);
            var actual = LogViewer.Properties.Resources.LogKindTarget_CXDI;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LogType
        ///</summary>
        [TestMethod()]
        public void LogTypeTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("LogType", culture);
            var actual = LogViewer.Properties.Resources.LogType;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LogTypeColon
        ///</summary>
        [TestMethod()]
        public void LogTypeColonTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("LogTypeColon", culture);
            var actual = LogViewer.Properties.Resources.LogTypeColon;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LogViewer
        ///</summary>
        [TestMethod()]
        public void LogViewerTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("LogViewer", culture);
            var actual = LogViewer.Properties.Resources.LogViewer;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MAXIMUM_DATE_EXCEPTION
        ///</summary>
        [TestMethod()]
        public void MAXIMUM_DATE_EXCEPTIONTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("MAXIMUM_DATE_EXCEPTION", culture);
            var actual = LogViewer.Properties.Resources.MAXIMUM_DATE_EXCEPTION;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MEMO_EXPORT_CAPTION
        ///</summary>
        [TestMethod()]
        public void MEMO_EXPORT_CAPTIONTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("MEMO_EXPORT_CAPTION", culture);
            var actual = LogViewer.Properties.Resources.MEMO_EXPORT_CAPTION;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MEMO_EXPORT_EXIST_FILE_CAPTION
        ///</summary>
        [TestMethod()]
        public void MEMO_EXPORT_EXIST_FILE_CAPTIONTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("MEMO_EXPORT_EXIST_FILE_CAPTION", culture);
            var actual = LogViewer.Properties.Resources.MEMO_EXPORT_EXIST_FILE_CAPTION;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MEMO_EXPORT_EXIST_FILE_TEXT
        ///</summary>
        [TestMethod()]
        public void MEMO_EXPORT_EXIST_FILE_TEXTTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("MEMO_EXPORT_EXIST_FILE_TEXT", culture);
            var actual = LogViewer.Properties.Resources.MEMO_EXPORT_EXIST_FILE_TEXT;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MEMO_EXPORT_NO_RECORD
        ///</summary>
        [TestMethod()]
        public void MEMO_EXPORT_NO_RECORDTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("MEMO_EXPORT_NO_RECORD", culture);
            var actual = LogViewer.Properties.Resources.MEMO_EXPORT_NO_RECORD;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MEMO_EXPORT_TEXT_EXCEPTION
        ///</summary>
        [TestMethod()]
        public void MEMO_EXPORT_TEXT_EXCEPTIONTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("MEMO_EXPORT_TEXT_EXCEPTION", culture);
            var actual = LogViewer.Properties.Resources.MEMO_EXPORT_TEXT_EXCEPTION;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MEMO_EXPORT_TEXT_SUCCESS
        ///</summary>
        [TestMethod()]
        public void MEMO_EXPORT_TEXT_SUCCESSTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("MEMO_EXPORT_TEXT_SUCCESS", culture);
            var actual = LogViewer.Properties.Resources.MEMO_EXPORT_TEXT_SUCCESS;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MEMO_IMPORT_CAPTION
        ///</summary>
        [TestMethod()]
        public void MEMO_IMPORT_CAPTIONTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("MEMO_IMPORT_CAPTION", culture);
            var actual = LogViewer.Properties.Resources.MEMO_IMPORT_CAPTION;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MEMO_IMPORT_TEXT_EXCEPTION
        ///</summary>
        [TestMethod()]
        public void MEMO_IMPORT_TEXT_EXCEPTIONTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("MEMO_IMPORT_TEXT_EXCEPTION", culture);
            var actual = LogViewer.Properties.Resources.MEMO_IMPORT_TEXT_EXCEPTION;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Max
        ///</summary>
        [TestMethod()]
        public void MaxTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Max", culture);
            var actual = LogViewer.Properties.Resources.Max;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MaximumFilterItemErrorMessage
        ///</summary>
        [TestMethod()]
        public void MaximumFilterItemErrorMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("MaximumFilterItemErrorMessage", culture);
            var actual = LogViewer.Properties.Resources.MaximumFilterItemErrorMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Merge
        ///</summary>
        [TestMethod()]
        public void MergeTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Merge", culture);
            var actual = LogViewer.Properties.Resources.Merge;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Message
        ///</summary>
        [TestMethod()]
        public void MessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Message", culture);
            var actual = LogViewer.Properties.Resources.Message;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MessageConfirm
        ///</summary>
        [TestMethod()]
        public void MessageConfirmTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("MessageConfirm", culture);
            var actual = LogViewer.Properties.Resources.MessageConfirm;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MessageFileAlreadyLoad
        ///</summary>
        [TestMethod()]
        public void MessageFileAlreadyLoadTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("MessageFileAlreadyLoad", culture);
            var actual = LogViewer.Properties.Resources.MessageFileAlreadyLoad;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Mode
        ///</summary>
        [TestMethod()]
        public void ModeTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Mode", culture);
            var actual = LogViewer.Properties.Resources.Mode;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Module
        ///</summary>
        [TestMethod()]
        public void ModuleTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Module", culture);
            var actual = LogViewer.Properties.Resources.Module;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MoveToLine
        ///</summary>
        [TestMethod()]
        public void MoveToLineTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("MoveToLine", culture);
            var actual = LogViewer.Properties.Resources.MoveToLine;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MoveToTime
        ///</summary>
        [TestMethod()]
        public void MoveToTimeTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("MoveToTime", culture);
            var actual = LogViewer.Properties.Resources.MoveToTime;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for NOT_DETECT_FORMAT_FILE_EXCEPTION
        ///</summary>
        [TestMethod()]
        public void NOT_DETECT_FORMAT_FILE_EXCEPTIONTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("NOT_DETECT_FORMAT_FILE_EXCEPTION", culture);
            var actual = LogViewer.Properties.Resources.NOT_DETECT_FORMAT_FILE_EXCEPTION;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for NOT_READ_FILE_EXCEPTION
        ///</summary>
        [TestMethod()]
        public void NOT_READ_FILE_EXCEPTIONTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("NOT_READ_FILE_EXCEPTION", culture);
            var actual = LogViewer.Properties.Resources.NOT_READ_FILE_EXCEPTION;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for NO_RECORD_EXPORTED
        ///</summary>
        [TestMethod()]
        public void NO_RECORD_EXPORTEDTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("NO_RECORD_EXPORTED", culture);
            var actual = LogViewer.Properties.Resources.NO_RECORD_EXPORTED;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Name", culture);
            var actual = LogViewer.Properties.Resources.Name;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for NameColon
        ///</summary>
        [TestMethod()]
        public void NameColonTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("NameColon", culture);
            var actual = LogViewer.Properties.Resources.NameColon;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for New
        ///</summary>
        [TestMethod()]
        public void NewTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("New", culture);
            var actual = LogViewer.Properties.Resources.New;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for No
        ///</summary>
        [TestMethod()]
        public void NoTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("No", culture);
            var actual = LogViewer.Properties.Resources.No;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for NotDisplayLogViewMessage
        ///</summary>
        [TestMethod()]
        public void NotDisplayLogViewMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("NotDisplayLogViewMessage", culture);
            var actual = LogViewer.Properties.Resources.NotDisplayLogViewMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for NotDisplayLogViewWithDateTimeMessage
        ///</summary>
        [TestMethod()]
        public void NotDisplayLogViewWithDateTimeMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("NotDisplayLogViewWithDateTimeMessage", culture);
            var actual = LogViewer.Properties.Resources.NotDisplayLogViewWithDateTimeMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for OK
        ///</summary>
        [TestMethod()]
        public void OKTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("OK", culture);
            var actual = LogViewer.Properties.Resources.OK;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Object
        ///</summary>
        [TestMethod()]
        public void ObjectTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Object", culture);
            var actual = LogViewer.Properties.Resources.Object;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Old
        ///</summary>
        [TestMethod()]
        public void OldTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Old", culture);
            var actual = LogViewer.Properties.Resources.Old;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Overwrite
        ///</summary>
        [TestMethod()]
        public void OverwriteTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Overwrite", culture);
            var actual = LogViewer.Properties.Resources.Overwrite;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Parameter
        ///</summary>
        [TestMethod()]
        public void ParameterTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Parameter", culture);
            var actual = LogViewer.Properties.Resources.Parameter;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for PatternAnalyzed
        ///</summary>
        [TestMethod()]
        public void PatternAnalyzedTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("PatternAnalyzed", culture);
            var actual = LogViewer.Properties.Resources.PatternAnalyzed;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for PersonalInfo
        ///</summary>
        [TestMethod()]
        public void PersonalInfoTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("PersonalInfo", culture);
            var actual = LogViewer.Properties.Resources.PersonalInfo;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for PleaseInputAValidDecimalNumberOrAValidFraction
        ///</summary>
        [TestMethod()]
        public void PleaseInputAValidDecimalNumberOrAValidFractionTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("PleaseInputAValidDecimalNumberOrAValidFraction", culture);
            var actual = LogViewer.Properties.Resources.PleaseInputAValidDecimalNumberOrAValidFraction;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for PleaseInputFilterString
        ///</summary>
        [TestMethod()]
        public void PleaseInputFilterStringTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("PleaseInputFilterString", culture);
            var actual = LogViewer.Properties.Resources.PleaseInputFilterString;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for PleaseInputNumberValueGreaterOrEqual0
        ///</summary>
        [TestMethod()]
        public void PleaseInputNumberValueGreaterOrEqual0Test()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("PleaseInputNumberValueGreaterOrEqual0", culture);
            var actual = LogViewer.Properties.Resources.PleaseInputNumberValueGreaterOrEqual0;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ProcessTimeColon
        ///</summary>
        [TestMethod()]
        public void ProcessTimeColonTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ProcessTimeColon", culture);
            var actual = LogViewer.Properties.Resources.ProcessTimeColon;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for READ_DISPLAY_SETTING_FILE_NOT_FOUND_EXCEPTION
        ///</summary>
        [TestMethod()]
        public void READ_DISPLAY_SETTING_FILE_NOT_FOUND_EXCEPTIONTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("READ_DISPLAY_SETTING_FILE_NOT_FOUND_EXCEPTION", culture);
            var actual = LogViewer.Properties.Resources.READ_DISPLAY_SETTING_FILE_NOT_FOUND_EXCEPTION;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for READ_FILTER_SETTING_FILE_NOT_FOUND_EXCEPTION
        ///</summary>
        [TestMethod()]
        public void READ_FILTER_SETTING_FILE_NOT_FOUND_EXCEPTIONTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("READ_FILTER_SETTING_FILE_NOT_FOUND_EXCEPTION", culture);
            var actual = LogViewer.Properties.Resources.READ_FILTER_SETTING_FILE_NOT_FOUND_EXCEPTION;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for READ_FILTER_SETTING_OTHER_EXCEPTION
        ///</summary>
        [TestMethod()]
        public void READ_FILTER_SETTING_OTHER_EXCEPTIONTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("READ_FILTER_SETTING_OTHER_EXCEPTION", culture);
            var actual = LogViewer.Properties.Resources.READ_FILTER_SETTING_OTHER_EXCEPTION;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for READ_KEYWORD_COUNT_SETTING_FILE_NOT_FOUND_EXCEPTION
        ///</summary>
        [TestMethod()]
        public void READ_KEYWORD_COUNT_SETTING_FILE_NOT_FOUND_EXCEPTIONTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("READ_KEYWORD_COUNT_SETTING_FILE_NOT_FOUND_EXCEPTION", culture);
            var actual = LogViewer.Properties.Resources.READ_KEYWORD_COUNT_SETTING_FILE_NOT_FOUND_EXCEPTION;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for READ_KEYWORD_COUNT_SETTING_OTHER_EXCEPTION
        ///</summary>
        [TestMethod()]
        public void READ_KEYWORD_COUNT_SETTING_OTHER_EXCEPTIONTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("READ_KEYWORD_COUNT_SETTING_OTHER_EXCEPTION", culture);
            var actual = LogViewer.Properties.Resources.READ_KEYWORD_COUNT_SETTING_OTHER_EXCEPTION;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for READ_PATTERN_SETTING_FILE_NOT_FOUND_EXCEPTION
        ///</summary>
        [TestMethod()]
        public void READ_PATTERN_SETTING_FILE_NOT_FOUND_EXCEPTIONTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("READ_PATTERN_SETTING_FILE_NOT_FOUND_EXCEPTION", culture);
            var actual = LogViewer.Properties.Resources.READ_PATTERN_SETTING_FILE_NOT_FOUND_EXCEPTION;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for READ_PATTERN_SETTING_OTHER_EXCEPTION
        ///</summary>
        [TestMethod()]
        public void READ_PATTERN_SETTING_OTHER_EXCEPTIONTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("READ_PATTERN_SETTING_OTHER_EXCEPTION", culture);
            var actual = LogViewer.Properties.Resources.READ_PATTERN_SETTING_OTHER_EXCEPTION;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Replace
        ///</summary>
        [TestMethod()]
        public void ReplaceTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Replace", culture);
            var actual = LogViewer.Properties.Resources.Replace;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ResourceManager - resourceMan != null
        ///</summary>
        [TestMethod()]
        public void ResourceManager_resourceManNotNullTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            PrivateType param = new PrivateType(typeof(LogViewer.Properties.Resources));
            param.SetStaticFieldOrProperty("resourceMan", new ResourceManager(typeof(LogViewer.Properties.Resources)));            ;
            var expected = param.GetStaticFieldOrProperty("resourceMan");
            var actual = LogViewer.Properties.Resources.ResourceManager;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ResourceManager - resourceMan = null
        ///</summary>
        [TestMethod()]
        public void ResourceManager_resourceManNullTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            Assert.IsNotNull(LogViewer.Properties.Resources.ResourceManager);
        }

        /// <summary>
        ///A test for ResultColon
        ///</summary>
        [TestMethod()]
        public void ResultColonTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ResultColon", culture);
            var actual = LogViewer.Properties.Resources.ResultColon;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for RootKeywordColon
        ///</summary>
        [TestMethod()]
        public void RootKeywordColonTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("RootKeywordColon", culture);
            var actual = LogViewer.Properties.Resources.RootKeywordColon;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SaveParameter
        ///</summary>
        [TestMethod()]
        public void SaveParameterTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("SaveParameter", culture);
            var actual = LogViewer.Properties.Resources.SaveParameter;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Search
        ///</summary>
        [TestMethod()]
        public void SearchTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Search", culture);
            var actual = LogViewer.Properties.Resources.Search;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SecondYToGreaterThanFromValueErrorMessage
        ///</summary>
        [TestMethod()]
        public void SecondYToGreaterThanFromValueErrorMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("SecondYToGreaterThanFromValueErrorMessage", culture);
            var actual = LogViewer.Properties.Resources.SecondYToGreaterThanFromValueErrorMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SelectAll
        ///</summary>
        [TestMethod()]
        public void SelectAllTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("SelectAll", culture);
            var actual = LogViewer.Properties.Resources.SelectAll;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SelectLogKindErrorMessage
        ///</summary>
        [TestMethod()]
        public void SelectLogKindErrorMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("SelectLogKindErrorMessage", culture);
            var actual = LogViewer.Properties.Resources.SelectLogKindErrorMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ShowGrid
        ///</summary>
        [TestMethod()]
        public void ShowGridTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ShowGrid", culture);
            var actual = LogViewer.Properties.Resources.ShowGrid;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Slash
        ///</summary>
        [TestMethod()]
        public void SlashTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Slash", culture);
            var actual = LogViewer.Properties.Resources.Slash;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for String
        ///</summary>
        [TestMethod()]
        public void StringTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("String", culture);
            var actual = LogViewer.Properties.Resources.String;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for TXT
        ///</summary>
        [TestMethod()]
        public void TXTTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("TXT", culture);
            var actual = LogViewer.Properties.Resources.TXT;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ThreadId
        ///</summary>
        [TestMethod()]
        public void ThreadIdTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ThreadId", culture);
            var actual = LogViewer.Properties.Resources.ThreadId;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Time
        ///</summary>
        [TestMethod()]
        public void TimeTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Time", culture);
            var actual = LogViewer.Properties.Resources.Time;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for TimeColon
        ///</summary>
        [TestMethod()]
        public void TimeColonTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("TimeColon", culture);
            var actual = LogViewer.Properties.Resources.TimeColon;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for TimeConditionColon
        ///</summary>
        [TestMethod()]
        public void TimeConditionColonTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("TimeConditionColon", culture);
            var actual = LogViewer.Properties.Resources.TimeConditionColon;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for TitleCCSFilterSetting
        ///</summary>
        [TestMethod()]
        public void TitleCCSFilterSettingTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("TitleCCSFilterSetting", culture);
            var actual = LogViewer.Properties.Resources.TitleCCSFilterSetting;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for TitleCCSKeywordCountSetting
        ///</summary>
        [TestMethod()]
        public void TitleCCSKeywordCountSettingTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("TitleCCSKeywordCountSetting", culture);
            var actual = LogViewer.Properties.Resources.TitleCCSKeywordCountSetting;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for TitleCCSPatternManager
        ///</summary>
        [TestMethod()]
        public void TitleCCSPatternManagerTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("TitleCCSPatternManager", culture);
            var actual = LogViewer.Properties.Resources.TitleCCSPatternManager;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for TitleCXDIFilterSetting
        ///</summary>
        [TestMethod()]
        public void TitleCXDIFilterSettingTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("TitleCXDIFilterSetting", culture);
            var actual = LogViewer.Properties.Resources.TitleCXDIFilterSetting;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for TitleCXDIKeywordCountSetting
        ///</summary>
        [TestMethod()]
        public void TitleCXDIKeywordCountSettingTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("TitleCXDIKeywordCountSetting", culture);
            var actual = LogViewer.Properties.Resources.TitleCXDIKeywordCountSetting;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for TitleCXDIPatternManager
        ///</summary>
        [TestMethod()]
        public void TitleCXDIPatternManagerTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("TitleCXDIPatternManager", culture);
            var actual = LogViewer.Properties.Resources.TitleCXDIPatternManager;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToCSV
        ///</summary>
        [TestMethod()]
        public void ToCSVTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ToCSV", culture);
            var actual = LogViewer.Properties.Resources.ToCSV;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToImage
        ///</summary>
        [TestMethod()]
        public void ToImageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ToImage", culture);
            var actual = LogViewer.Properties.Resources.ToImage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Type
        ///</summary>
        [TestMethod()]
        public void TypeTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Type", culture);
            var actual = LogViewer.Properties.Resources.Type;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for UserAction
        ///</summary>
        [TestMethod()]
        public void UserActionTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("UserAction", culture);
            var actual = LogViewer.Properties.Resources.UserAction;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateEmptyNameMessage
        ///</summary>
        [TestMethod()]
        public void ValidateEmptyNameMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ValidateEmptyNameMessage", culture);
            var actual = LogViewer.Properties.Resources.ValidateEmptyNameMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateEmptyRootKeyMessage
        ///</summary>
        [TestMethod()]
        public void ValidateEmptyRootKeyMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ValidateEmptyRootKeyMessage", culture);
            var actual = LogViewer.Properties.Resources.ValidateEmptyRootKeyMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateEmptyStringListMessage
        ///</summary>
        [TestMethod()]
        public void ValidateEmptyStringListMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ValidateEmptyStringListMessage", culture);
            var actual = LogViewer.Properties.Resources.ValidateEmptyStringListMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateEmptyStringMessage
        ///</summary>
        [TestMethod()]
        public void ValidateEmptyStringMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ValidateEmptyStringMessage", culture);
            var actual = LogViewer.Properties.Resources.ValidateEmptyStringMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateEmptyStringObjectMessage
        ///</summary>
        [TestMethod()]
        public void ValidateEmptyStringObjectMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ValidateEmptyStringObjectMessage", culture);
            var actual = LogViewer.Properties.Resources.ValidateEmptyStringObjectMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateEmptyStringValueMessage
        ///</summary>
        [TestMethod()]
        public void ValidateEmptyStringValueMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ValidateEmptyStringValueMessage", culture);
            var actual = LogViewer.Properties.Resources.ValidateEmptyStringValueMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateLengthKeywordMessage
        ///</summary>
        [TestMethod()]
        public void ValidateLengthKeywordMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ValidateLengthKeywordMessage", culture);
            var actual = LogViewer.Properties.Resources.ValidateLengthKeywordMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateLengthNameMessage
        ///</summary>
        [TestMethod()]
        public void ValidateLengthNameMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ValidateLengthNameMessage", culture);
            var actual = LogViewer.Properties.Resources.ValidateLengthNameMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateLengthRootKeyMessage
        ///</summary>
        [TestMethod()]
        public void ValidateLengthRootKeyMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ValidateLengthRootKeyMessage", culture);
            var actual = LogViewer.Properties.Resources.ValidateLengthRootKeyMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateLengthStringObjectMessage
        ///</summary>
        [TestMethod()]
        public void ValidateLengthStringObjectMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ValidateLengthStringObjectMessage", culture);
            var actual = LogViewer.Properties.Resources.ValidateLengthStringObjectMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateLengthStringValueMessage
        ///</summary>
        [TestMethod()]
        public void ValidateLengthStringValueMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ValidateLengthStringValueMessage", culture);
            var actual = LogViewer.Properties.Resources.ValidateLengthStringValueMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateMaxKeywordCountMessage
        ///</summary>
        [TestMethod()]
        public void ValidateMaxKeywordCountMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ValidateMaxKeywordCountMessage", culture);
            var actual = LogViewer.Properties.Resources.ValidateMaxKeywordCountMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateMaxRegisterItemMessage
        ///</summary>
        [TestMethod()]
        public void ValidateMaxRegisterItemMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ValidateMaxRegisterItemMessage", culture);
            var actual = LogViewer.Properties.Resources.ValidateMaxRegisterItemMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateMaximumEnableParameter
        ///</summary>
        [TestMethod()]
        public void ValidateMaximumEnableParameterTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ValidateMaximumEnableParameter", culture);
            var actual = LogViewer.Properties.Resources.ValidateMaximumEnableParameter;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateUniqueNameMessage
        ///</summary>
        [TestMethod()]
        public void ValidateUniqueNameMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ValidateUniqueNameMessage", culture);
            var actual = LogViewer.Properties.Resources.ValidateUniqueNameMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidateUniqueStringValueMessage
        ///</summary>
        [TestMethod()]
        public void ValidateUniqueStringValueMessageTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ValidateUniqueStringValueMessage", culture);
            var actual = LogViewer.Properties.Resources.ValidateUniqueStringValueMessage;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Visible
        ///</summary>
        [TestMethod()]
        public void VisibleTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Visible", culture);
            var actual = LogViewer.Properties.Resources.Visible;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Warning
        ///</summary>
        [TestMethod()]
        public void WarningTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Warning", culture);
            var actual = LogViewer.Properties.Resources.Warning;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for XML
        ///</summary>
        [TestMethod()]
        public void XMLTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("XML", culture);
            var actual = LogViewer.Properties.Resources.XML;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Yes
        ///</summary>
        [TestMethod()]
        public void YesTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("Yes", culture);
            var actual = LogViewer.Properties.Resources.Yes;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for _ClearAll
        ///</summary>
        [TestMethod()]
        public void _ClearAllTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("_ClearAll", culture);
            var actual = LogViewer.Properties.Resources._ClearAll;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for _ClearAnalyzedResult
        ///</summary>
        [TestMethod()]
        public void _ClearAnalyzedResultTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("_ClearAnalyzedResult", culture);
            var actual = LogViewer.Properties.Resources._ClearAnalyzedResult;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for _Edit
        ///</summary>
        [TestMethod()]
        public void _EditTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("_Edit", culture);
            var actual = LogViewer.Properties.Resources._Edit;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for _Export
        ///</summary>
        [TestMethod()]
        public void _ExportTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("_Export", culture);
            var actual = LogViewer.Properties.Resources._Export;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for _ExportEtc
        ///</summary>
        [TestMethod()]
        public void _ExportEtcTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("_ExportEtc", culture);
            var actual = LogViewer.Properties.Resources._ExportEtc;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for _File
        ///</summary>
        [TestMethod()]
        public void _FileTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("_File", culture);
            var actual = LogViewer.Properties.Resources._File;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for _OpenEtc
        ///</summary>
        [TestMethod()]
        public void _OpenEtcTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("_OpenEtc", culture);
            var actual = LogViewer.Properties.Resources._OpenEtc;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for _Option
        ///</summary>
        [TestMethod()]
        public void _OptionTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("_Option", culture);
            var actual = LogViewer.Properties.Resources._Option;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for _Quit
        ///</summary>
        [TestMethod()]
        public void _QuitTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("_Quit", culture);
            var actual = LogViewer.Properties.Resources._Quit;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for _Range
        ///</summary>
        [TestMethod()]
        public void _RangeTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("_Range", culture);
            var actual = LogViewer.Properties.Resources._Range;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for _ResetBookmarks
        ///</summary>
        [TestMethod()]
        public void _ResetBookmarksTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("_ResetBookmarks", culture);
            var actual = LogViewer.Properties.Resources._ResetBookmarks;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for _ResetColorFilters
        ///</summary>
        [TestMethod()]
        public void _ResetColorFiltersTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("_ResetColorFilters", culture);
            var actual = LogViewer.Properties.Resources._ResetColorFilters;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for _ResetComments
        ///</summary>
        [TestMethod()]
        public void _ResetCommentsTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("_ResetComments", culture);
            var actual = LogViewer.Properties.Resources._ResetComments;
            Assert.AreEqual(expected, actual); ;
        }

        /// <summary>
        ///A test for _ResetFilters
        ///</summary>
        [TestMethod()]
        public void _ResetFiltersTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("_ResetFilters", culture);
            var actual = LogViewer.Properties.Resources._ResetFilters;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for _Search
        ///</summary>
        [TestMethod()]
        public void _SearchTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("_Search", culture);
            var actual = LogViewer.Properties.Resources._Search;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for _SetKeyword
        ///</summary>
        [TestMethod()]
        public void _SetKeywordTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("_SetKeyword", culture);
            var actual = LogViewer.Properties.Resources._SetKeyword;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for _SetLogParameter
        ///</summary>
        [TestMethod()]
        public void _SetLogParameterTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("_SetLogParameter", culture);
            var actual = LogViewer.Properties.Resources._SetLogParameter;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for _SetParameter
        ///</summary>
        [TestMethod()]
        public void _SetParameterTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("_SetParameter", culture);
            var actual = LogViewer.Properties.Resources._SetParameter;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for h
        ///</summary>
        [TestMethod()]
        public void hTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("h", culture);
            var actual = LogViewer.Properties.Resources.h;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for m
        ///</summary>
        [TestMethod()]
        public void mTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("m", culture);
            var actual = LogViewer.Properties.Resources.m;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ms
        ///</summary>
        [TestMethod()]
        public void msTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("ms", culture);
            var actual = LogViewer.Properties.Resources.ms;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for s
        ///</summary>
        [TestMethod()]
        public void sTest()
        {
            LogViewer.Properties.Resources.Culture = new CultureInfo(1);
            var culture = LogViewer.Properties.Resources.Culture;
            var expected = LogViewer.Properties.Resources.ResourceManager.GetString("s", culture);
            var actual = LogViewer.Properties.Resources.s;
            Assert.AreEqual(expected, actual);
        }
    }
}
