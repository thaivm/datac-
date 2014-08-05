using System;
using System.Collections.Generic;
using System.IO;
using LogViewer.Business.FileParser;
using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.Business.FileParser
{
    
    
    /// <summary>
    ///This is a test class for CCSParserTest and is intended
    ///to contain all CCSParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CCSParserTest
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

        #region ParserFromFile
        /// <summary>
        ///A test for ParserFromFile
        ///Decription:File is normal.
        ///Precondition:
        ///     Input file is CCSLogParser and has 13 lines
        ///     Datetime  is  right format
        ///     One Record in one line
        ///Expected: return expected CCSLogRecord List
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\TestCCSParser.csv")]
        public void ParserFromFileTest_1()
        {
            CCSParserNew target = new CCSParserNew(); 
            List<CCSLogRecord> expected = new List<CCSLogRecord>();
            for (int i = 0; i < 13; i++)
            {
                CCSLogRecord ccsLogRecord = new CCSLogRecord();
                ccsLogRecord.HostName = "MyPC";
                ccsLogRecord.Id = "4.00E+01";
                ccsLogRecord.Line = i + 1;
                ccsLogRecord.PersonalInfo = "";
                ccsLogRecord.AdditionalInfo = "";
                ccsLogRecord.ThreadId = "1";
                ccsLogRecord.DateTime = DateTime.Parse("2013/09/03 09:02:49.222");
                ccsLogRecord.Type = "I";
                ccsLogRecord.Content = "\" Print \"\"Hello World!\"\"\"";
                ccsLogRecord.ClassName = "HogeHoge.HogeManager";
                expected.Add(ccsLogRecord);
            }
          
            List<CCSLogRecord> actual = new List<CCSLogRecord>();
            actual = target.ParserFromFile("TestCCSParser.csv");
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].HostName, actual[i].HostName);
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Line, actual[i].Line);
                Assert.AreEqual(expected[i].PersonalInfo, actual[i].PersonalInfo);
                Assert.AreEqual(expected[i].ThreadId, actual[i].ThreadId);
                Assert.AreEqual(expected[i].Time, actual[i].Time);
                Assert.AreEqual(expected[i].Type, actual[i].Type);
                Assert.AreEqual(expected[i].Content, actual[i].Content);
                Assert.AreEqual(expected[i].Date, actual[i].Date);
                Assert.AreEqual(expected[i].ClassName, actual[i].ClassName);
                Assert.AreEqual(expected[i].PersonalInfo, actual[i].PersonalInfo);
            }
        }

     
        /// <summary>
        ///A test for ParserFromFile
        ///Decription:File is exist and has blank lines.
        ///Precondition:
        ///     Input file is CCSLogParser and has 16 lines
        ///     Datetime  is  right format
        ///     Line 11,13,15 are blank lines 
        ///Expected: return expected CCSLogRecord List
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\TestCCSParser1.csv")]
        public void ParserFromFileTest_2()
        {
            CCSParserNew target = new CCSParserNew(); 
            List<CCSLogRecord> expected = new List<CCSLogRecord>();
            for (int i = 0; i < 13; i++)
            {
                CCSLogRecord ccsLogRecord = new CCSLogRecord();
                ccsLogRecord.HostName = "MyPC";
                ccsLogRecord.Id = "4.00E+01";
                ccsLogRecord.Line = i + 1;
                ccsLogRecord.PersonalInfo = "";
                ccsLogRecord.AdditionalInfo = "";
                ccsLogRecord.ThreadId = "1";
                ccsLogRecord.DateTime =DateTime.Parse("2013/09/03 09:02:49.222");
                ccsLogRecord.Type = "I";
                ccsLogRecord.Content = "\" Print \"\"Hello World!\"\"\"";
                ccsLogRecord.ClassName = "HogeHoge.HogeManager";
                expected.Add(ccsLogRecord);
            }

            List<CCSLogRecord> actual = new List<CCSLogRecord>();
            actual = target.ParserFromFile("TestCCSParser1.csv");
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].HostName, actual[i].HostName);
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Line, actual[i].Line);
                Assert.AreEqual(expected[i].PersonalInfo, actual[i].PersonalInfo);
                Assert.AreEqual(expected[i].ThreadId, actual[i].ThreadId);
                Assert.AreEqual(expected[i].Time, actual[i].Time);
                Assert.AreEqual(expected[i].Type, actual[i].Type);
                Assert.AreEqual(expected[i].Content, actual[i].Content);
                Assert.AreEqual(expected[i].Date, actual[i].Date);
                Assert.AreEqual(expected[i].ClassName, actual[i].ClassName);
                Assert.AreEqual(expected[i].PersonalInfo, actual[i].PersonalInfo);
            }
        }


        /// <summary>
        /// ParserFromFile is expected to throw FileNotFoundException.
        /// precondition:
        ///     input file is "NotExistedFile.txt"
        /// expected result:
        ///     ParserFromFile will throw FileNotFoundException if file not exist.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void ParserFromFileTest_3()
        {
            CCSParserNew parser = new CCSParserNew();
            parser.ParserFromFile("NotExistedFile.txt");
        }

        /// <summary>
        /// ParserFromFile is expected to return properly value.
        /// precondition:
        ///     input file is "TestCCSParserEmpty.log"
        /// expected result:
        ///     ParserFromFile will returns an empty list if input file is an empty file.
        /// </summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\TestCCSParserEmpty.csv")]
        public void ParserFromFileTest_4()
        {
            CCSParserNew parser = new CCSParserNew();
            List<CCSLogRecord> logs = parser.ParserFromFile("TestCCSParserEmpty.csv");

            // check returned value
            Assert.AreEqual(0, logs.Count);
        }
        [TestMethod()]
        public void ParserFromFileTest_5()
        {
            string textUser =
@"2013/10/02 13:36:39.899, 
2013/10/02 13:36:40.701, A-2013-P49540, 0001, I, 020200005, Configflow : ExamFacade.GetInstance : 40.700, , , WorkflowLibrary.Configflow
2013/10/02 13:36:40.705, A-2013-P49540, 0001, I, 020200012, Outputflow : ExamFacade.GetInstance : 40.704, , , WorkflowLibrary.Outputflow
2013/10/02 13:36:40.817, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetHDDUseCapacityInfo()], , , Exam.ExamFacade
2013/10/02 13:36:40.827, A-2013-P49540, 0001, I, 020200017, Workflow : facade.GetPackageEdition : 40.827, , , WorkflowLibrary.Workflow
2013/10/02 13:36:40.828, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetPackageEdition()], , , Exam.ExamFacade
2013/10/02 13:36:40.828, A-2013-P49540, 0001, I, 020200017, Workflow : facade.ValidateProduct : 40.828, , , WorkflowLibrary.Workflow
2013/10/02 13:36:40.829, A-2013-P49540, 0001, I, 030101001, G->F CALL [ValidateProduct()], , , Exam.ExamFacade";

            string filenameUser = string.Format("ParserFromFileTest_5{0}.txt", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            
            CCSParserNew parser = new CCSParserNew();
            var ls = parser.ParserFromFile(fileFullPath);
            var expected = 7;
            var actual = ls.Count;
            Assert.AreEqual(expected,actual);


        }
        [TestMethod()]
        [ExpectedException(typeof(ObjectDisposedException))]
        public void ParserFromFileTest_6()
        {
            StringReader reader  = new StringReader(
@"2013/10/02 13:36:39.899, 
2013/10/02 13:36:40.701, A-2013-P49540, 0001, I, 020200005, Configflow : ExamFacade.GetInstance : 40.700, , , WorkflowLibrary.Configflow
2013/10/02 13:36:40.705, A-2013-P49540, 0001, I, 020200012, Outputflow : ExamFacade.GetInstance : 40.704, , , WorkflowLibrary.Outputflow
2013/10/02 13:36:40.817, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetHDDUseCapacityInfo()], , , Exam.ExamFacade
2013/10/02 13:36:40.827, A-2013-P49540, 0001, I, 020200017, Workflow : facade.GetPackageEdition : 40.827, , , WorkflowLibrary.Workflow
2013/10/02 13:36:40.828, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetPackageEdition()], , , Exam.ExamFacade
2013/10/02 13:36:40.828, A-2013-P49540, 0001, I, 020200017, Workflow : facade.ValidateProduct : 40.828, , , WorkflowLibrary.Workflow
2013/10/02 13:36:40.829, A-2013-P49540, 0001, I, 030101001, G->F CALL [ValidateProduct()], , , Exam.ExamFacade");



            CCSParserNew parser = new CCSParserNew();
            reader.Dispose();
            var ls = parser.ParserFromFile(reader);
            var expected = 7;
            var actual = ls.Count;
            Assert.AreEqual(expected, actual);


        }
        [TestMethod]
        public void ParseLineTest1()
        {
            var target = new CCSParserNew();
            var po = new PrivateObject(target);
            var ccsLogRecords = new List<CCSLogRecord>();
            var i = 0;
            string strBuffer = "2013/17/02 33:36:40.701, A-2013-P49540, 0001, I, 020200005, Configflow : ExamFacade.GetInstance : 40.700, , , WorkflowLibrary.Configflow";
              char[] colonSeperator = { ',' };
              char[] spaceSeperator = { ' ' };
              po.Invoke("ParserLine",  new object[] { ccsLogRecords, i, strBuffer, colonSeperator, spaceSeperator });
            Assert.AreEqual(0,ccsLogRecords.Count);

        }

        #endregion
    }

}
