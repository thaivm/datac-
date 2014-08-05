using System;
using System.IO;
using LogViewer.Business;
using LogViewer.Business.FileParser;
using LogViewer.Model;
using LogViewer.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.Business.FileParser
{
    
    
    [TestClass()]
    public class ParserManagerTest
    {


        private TestContext testContextInstance;

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
        public void GetCXDIMemoParserTest()
        {
            string filePath = "MemoCXDI20140606153152.xml"; 
            Type expected = typeof(CXDIMemoParser);
            ILogParser<CXDILogRecord> result;
            result = ParserManager.GetCxdiMemoParser(filePath);
            Type actual = result.GetType();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        [DeploymentItem("FileConfig/M255_20130507144310_fe.log")]
        public void GetCXDICsvLogParserTest()
        {
            string filePath = Path.GetFullPath("M255_20130507144310_fe.log"); 
            Type expected = typeof(CXDIParser); 
            ILogParser<CXDILogRecord> result;
            result = ParserManager.GetCxdiCsvLogParser(filePath);
            Type actual = result.GetType();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void GetCXDICsvLogParserTest2()
        {
            string textUser =
@"2013-10-02 13:36:39.899, A-2013-P49540, 0001, I, 020200001, WindowUtility : SetMainWindowStartupLocation Window.Name = windMain, Top = 0, Left = 0, Height = 1080, Width = 1920,  : 39.899, , , WindowLibrary.WindowUtility
2013-10-02 13:36:40.701, A-2013-P49540, 0001, I, 020200005, Configflow : ExamFacade.GetInstance : 40.700, , , WorkflowLibrary.Configflow
2013-10-02 13:36:40.705, A-2013-P49540, 0001, I, 020200012, Outputflow : ExamFacade.GetInstance : 40.704, , , WorkflowLibrary.Outputflow
2013-10-02 13:36:40.817, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetHDDUseCapacityInfo()], , , Exam.ExamFacade
2013-10-02 13:36:40.827, A-2013-P49540, 0001, I, 020200017, Workflow : facade.GetPackageEdition : 40.827, , , WorkflowLibrary.Workflow
2013-10-02 13:36:40.828, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetPackageEdition()], , , Exam.ExamFacade
2013-10-02 13:36:40.828, A-2013-P49540, 0001, I, 020200017, Workflow : facade.ValidateProduct : 40.828, , , WorkflowLibrary.Workflow
2013-10-02 13:36:40.829, A-2013-P49540, 0001, I, 030101001, G->F CALL [ValidateProduct()], , , Exam.ExamFacade";

            string filenameUser = string.Format("a{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);
            Type expected = typeof(CXDIParser);
            ILogParser<CXDILogRecord> result;
            result = ParserManager.GetCxdiCsvLogParser(fileFullPath);
            Type actual = result.GetType();
            Assert.AreEqual(expected, actual);
            File.Delete(fileFullPath);
        }



        [TestMethod()]
        public void GetCCSMemoParserTest1()
        {
            string textUser =
@"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CCS><CommentArea><Comment Id='0' Line='3'>ab</Comment><Comment Id='1' Line='4'>ab</Comment></CommentArea><BookmarkArea><Bookmark Id='0' Line='1' /><Bookmark Id='1' Line='2' /><Bookmark Id='2' Line='4' /></BookmarkArea><LogArea TotalLine='15883'>
2014/04/22 09:44:42.332,A-2013-P49540,,0001,I,020200017,Workflow : ExamFacade.GetInstance : 42.331,,,WorkflowLibrary.Workflow
2014/04/22 09:44:42.334,A-2013-P49540,,0001,I,020200005,Configflow : facade.GetSystemInfoModelName : 42.333,,,WorkflowLibrary.Configflow
2014/04/22 09:44:42.334,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetSystemInfoModelName()],,,Exam.ExamFacade
2014/04/22 09:44:42.446,A-2013-P49540,,0001,I,020200001,WindowUtility : SetMainWindowStartupLocation Window.Name = windStartup,Top = 0,Left = 0,Height = 1080,Width = 1920,: 42.443,,,WindowLibrary.WindowUtility
2014/04/22 09:44:43.178,A-2013-P49540,,0001,I,020200001,WindowUtility : SetMainWindowStartupLocation Window.Name = windMain,Top = 0,Left = 0,Height = 1080,Width = 1920,: 43.178,,,WindowLibrary.WindowUtility
2014/04/22 09:44:43.810,A-2013-P49540,,0001,I,020200005,Configflow : ExamFacade.GetInstance : 43.809,,,WorkflowLibrary.Configflow
2014/04/22 09:44:43.814,A-2013-P49540,,0001,I,020200012,Outputflow : ExamFacade.GetInstance : 43.813,,,WorkflowLibrary.Outputflow
2014/04/22 09:44:43.919,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetHDDUseCapacityInfo()],,,Exam.ExamFacade
</LogArea></CCS></UserMemorizedLogData>";

            string filenameUser = string.Format("a{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);
            Type expected = typeof(CCSMemoParserNew);
            ILogParser<CCSLogRecord> result;
            result = ParserManager.GetCcsMemoParser(fileFullPath);
            Type actual = result.GetType();
            Assert.AreEqual(expected, actual);
            File.Delete(fileFullPath);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void GetCCSMemoParserTest2()
        {
            string textUser =
@"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CCS><CommentArea><Comment Id='0' Line='3'>ab</Comment><Comment Id='1' Line='4'>ab</Comment></CommentArea><BookmarkArea><Bookmark Id='0' Line='1' /><Bookmark Id='1' Line='2' /><Bookmark Id='2' Line='4' /></BookmarkArea><LogArea TotalLine='15883'>
201404/22 09:44:42.332,A-2013-P49540,,0001,I,020200017,Workflow : ExamFacade.GetInstance : 42.331,,,WorkflowLibrary.Workflow
</LogArea></CCS></UserMemorizedLogData>";

            string filenameUser = string.Format("a{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);
            Type expected = typeof(CCSMemoParserNew);
            ILogParser<CCSLogRecord> result;
            result = ParserManager.GetCcsMemoParser(fileFullPath);
            Type actual = result.GetType();
            Assert.AreEqual(expected, actual);
            File.Delete(fileFullPath);
        }

        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCSLogTest.csv")]
        public void GetCCSCsvParserTest()
        {
            string filePath = "CCSLogTest.csv"; 
            Type expected = typeof(CCSParserNew); 
            ILogParser<CCSLogRecord> result;
            result = ParserManager.GetCcsCsvParser(filePath);
            Type actual = result.GetType();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCCSCsvParserTest1()
        {
            StringReader reader = new StringReader(@"2013/10/02 13:36:37.095, A-2013-P49540, 0001, W, 060100001, ###### Welcome to Canon CXDI Controller RF. Copyright by CANON INC. 2013 V2.10.2.7 ######, , , Logging.LogManager
2013/10/02 13:36:38.305, A-2013-P49540, 0001, D, 030101001, G->F CALL [GetInstance()], , , Exam.ExamFacade
2013/10/02 13:36:38.306, A-2013-P49540, 0001, F, 020200017, Workflow : ExamFacade.GetInstance : 38.305, , , WorkflowLibrary.Workflow
2013/10/02 13:36:38.307, A-2013-P49540, 0001, E, 020200005, Configflow : facade.GetSystemInfoModelName : 38.307, , , WorkflowLibrary.Configflow
2013/10/02 13:36:38.308, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetSystemInfoModelName()], , , Exam.ExamFacade
2013/10/02 13:36:38.495, A-2013-P49540, 0001, I, 020200001, WindowUtility : SetMainWindowStartupLocation Window.Name = windStartup, Top = 0, Left = 0, Height = 1080, Width = 1920,  : 38.491, , , WindowLibrary.WindowUtility
2013/10/02 13:36:39.899, A-2013-P49540, 0001, I, 020200001, WindowUtility : SetMainWindowStartupLocation Window.Name = windMain, Top = 0, Left = 0, Height = 1080, Width = 1920,  : 39.899, , , WindowLibrary.WindowUtility
2013/10/02 13:36:40.701, A-2013-P49540, 0001, I, 020200005, Configflow : ExamFacade.GetInstance : 40.700, , , WorkflowLibrary.Configflow
2013/10/02 13:36:40.705, A-2013-P49540, 0001, I, 020200012, Outputflow : ExamFacade.GetInstance : 40.704, , , WorkflowLibrary.Outputflow
2013/10/02 13:36:40.817, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetHDDUseCapacityInfo()], , , Exam.ExamFacade
2013/10/02 13:36:40.827, A-2013-P49540, 0001, I, 020200017, Workflow : facade.GetPackageEdition : 40.827, , , WorkflowLibrary.Workflow
2013/10/02 13:36:40.828, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetPackageEdition()], , , Exam.ExamFacade
2013/10/02 13:36:40.828, A-2013-P49540, 0001, I, 020200017, Workflow : facade.ValidateProduct : 40.828, , , WorkflowLibrary.Workflow
2013/10/02 13:36:40.829, A-2013-P49540, 0001, I, 030101001, G->F CALL [ValidateProduct()], , , Exam.ExamFacade"); 
            Type expected = typeof(CCSParserNew); 
            ILogParser<CCSLogRecord> result;
            result = ParserManager.GetCcsCsvParser(reader);
            Type actual = result.GetType();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetCCSCsvParserTest4()
        {
            StringReader reader = new StringReader(@"2013-10-02 13:36:37.095, A-2013-P49540, 0001, W, 060100001, ###### Welcome to Canon CXDI Controller RF. Copyright by CANON INC. 2013 V2.10.2.7 ######, , , Logging.LogManager
2013-10-02 13:36:38.305, A-2013-P49540, 0001, D, 030101001, G->F CALL [GetInstance()], , , Exam.ExamFacade
2013/10/02 13:36:38.306, A-2013-P49540, 0001, F, 020200017, Workflow : ExamFacade.GetInstance : 38.305, , , WorkflowLibrary.Workflow
2013/10/02 13:36:38.307, A-2013-P49540, 0001, E, 020200005, Configflow : facade.GetSystemInfoModelName : 38.307, , , WorkflowLibrary.Configflow
2013/10/02 13:36:38.308, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetSystemInfoModelName()], , , Exam.ExamFacade
2013/10/02 13:36:38.495, A-2013-P49540, 0001, I, 020200001, WindowUtility : SetMainWindowStartupLocation Window.Name = windStartup, Top = 0, Left = 0, Height = 1080, Width = 1920,  : 38.491, , , WindowLibrary.WindowUtility
2013/10/02 13:36:39.899, A-2013-P49540, 0001, I, 020200001, WindowUtility : SetMainWindowStartupLocation Window.Name = windMain, Top = 0, Left = 0, Height = 1080, Width = 1920,  : 39.899, , , WindowLibrary.WindowUtility
2013/10/02 13:36:40.701, A-2013-P49540, 0001, I, 020200005, Configflow : ExamFacade.GetInstance : 40.700, , , WorkflowLibrary.Configflow
2013/10/02 13:36:40.705, A-2013-P49540, 0001, I, 020200012, Outputflow : ExamFacade.GetInstance : 40.704, , , WorkflowLibrary.Outputflow
2013/10/02 13:36:40.817, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetHDDUseCapacityInfo()], , , Exam.ExamFacade
2013/10/02 13:36:40.827, A-2013-P49540, 0001, I, 020200017, Workflow : facade.GetPackageEdition : 40.827, , , WorkflowLibrary.Workflow
2013/10/02 13:36:40.828, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetPackageEdition()], , , Exam.ExamFacade
2013/10/02 13:36:40.828, A-2013-P49540, 0001, I, 020200017, Workflow : facade.ValidateProduct : 40.828, , , WorkflowLibrary.Workflow
2013/10/02 13:36:40.829, A-2013-P49540, 0001, I, 030101001, G->F CALL [ValidateProduct()], , , Exam.ExamFacade");
            Type expected = typeof(CCSParserOld);
            ILogParser<CCSLogRecord> result;
            result = ParserManager.GetCcsCsvParser(reader);
            Type actual = result.GetType();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void GetCCSCsvParserTest2()
        {
            string textUser =
@"2013---10/02 13:36:37.095, A-2013-P49540, 0001, W, 060100001, ###### Welcome to Canon CXDI Controller RF. Copyright by CANON INC. 2013 V2.10.2.7 ######, , , Logging.LogManager
2013--10/02 13:36:38.305, A-2013-P49540, 0001, D, 030101001, G->F CALL [GetInstance()], , , Exam.ExamFacade
201310/02 13:36:38.306, A-2013-P49540, 0001, F, 020200017, Workflow : ExamFacade.GetInstance : 38.305, , , WorkflowLibrary.Workflow
20130/02 13:36:38.307, A-2013-P49540, 0001, E, 020200005, Configflow : facade.GetSystemInfoModelName : 38.307, , , WorkflowLibrary.Configflow
20130/02 13:36:38.308, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetSystemInfoModelName()], , , Exam.ExamFacade
201310/02 13:36:38.495, A-2013-P49540, 0001, I, 020200001, WindowUtility : SetMainWindowStartupLocation Window.Name = windStartup, Top = 0, Left = 0, Height = 1080, Width = 1920,  : 38.491, , , WindowLibrary.WindowUtility
2013/10/02 13:36:39.899, A-2013-P49540, 0001, I, 020200001, WindowUtility : SetMainWindowStartupLocation Window.Name = windMain, Top = 0, Left = 0, Height = 1080, Width = 1920,  : 39.899, , , WindowLibrary.WindowUtility
2013/10/02 13:36:40.701, A-2013-P49540, 0001, I, 020200005, Configflow : ExamFacade.GetInstance : 40.700, , , WorkflowLibrary.Configflow
2013/10/02 13:36:40.705, A-2013-P49540, 0001, I, 020200012, Outputflow : ExamFacade.GetInstance : 40.704, , , WorkflowLibrary.Outputflow
2013/10/02 13:36:40.817, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetHDDUseCapacityInfo()], , , Exam.ExamFacade
2013/10/02 13:36:40.827, A-2013-P49540, 0001, I, 020200017, Workflow : facade.GetPackageEdition : 40.827, , , WorkflowLibrary.Workflow
2013/10/02 13:36:40.828, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetPackageEdition()], , , Exam.ExamFacade
2013/10/02 13:36:40.828, A-2013-P49540, 0001, I, 020200017, Workflow : facade.ValidateProduct : 40.828, , , WorkflowLibrary.Workflow
2013/10/02 13:36:40.829, A-2013-P49540, 0001, I, 030101001, G->F CALL [ValidateProduct()], , , Exam.ExamFacade";

            string filenameUser = string.Format("a{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            
            
            ParserManager.GetCcsCsvParser(fileFullPath);
            File.Delete(fileFullPath);
        }
        [TestMethod()]
        public void GetCCSCsvParserTest3()
        {
            string textUser =
@"2013-10-02 13:36:39.899, A-2013-P49540, 0001, I, 020200001, WindowUtility : SetMainWindowStartupLocation Window.Name = windMain, Top = 0, Left = 0, Height = 1080, Width = 1920,  : 39.899, , , WindowLibrary.WindowUtility
2013-10-02 13:36:40.701, A-2013-P49540, 0001, I, 020200005, Configflow : ExamFacade.GetInstance : 40.700, , , WorkflowLibrary.Configflow
2013-10-02 13:36:40.705, A-2013-P49540, 0001, I, 020200012, Outputflow : ExamFacade.GetInstance : 40.704, , , WorkflowLibrary.Outputflow
2013-10-02 13:36:40.817, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetHDDUseCapacityInfo()], , , Exam.ExamFacade
2013-10-02 13:36:40.827, A-2013-P49540, 0001, I, 020200017, Workflow : facade.GetPackageEdition : 40.827, , , WorkflowLibrary.Workflow
2013-10-02 13:36:40.828, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetPackageEdition()], , , Exam.ExamFacade
2013-10-02 13:36:40.828, A-2013-P49540, 0001, I, 020200017, Workflow : facade.ValidateProduct : 40.828, , , WorkflowLibrary.Workflow
2013-10-02 13:36:40.829, A-2013-P49540, 0001, I, 030101001, G->F CALL [ValidateProduct()], , , Exam.ExamFacade";

            string filenameUser = string.Format("a{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);
            Type expected = typeof (CCSParserOld);
            ILogParser<CCSLogRecord> result;
            result = ParserManager.GetCcsCsvParser(fileFullPath);
            Type actual = result.GetType();
            Assert.AreEqual(expected, actual);
            File.Delete(fileFullPath);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception),"wrong format.")]
        public void GetCCSCsvParserTestWrongFormat()
        {
            StringReader reader = new StringReader(@"aaaa"); 
            Type expected = typeof(CCSParserNew); 
            ILogParser<CCSLogRecord> result;
            result = ParserManager.GetCcsCsvParser(reader);
            Type actual = result.GetType();
        }

        [TestMethod()]
        public void DetectFileTypeTestCCS()
        {
            string filePath = "CCSLogTest.csv"; 
            LogFileExt expected = LogFileExt.Ccs; 
            LogFileExt actual;
            actual = ParserManager.DetectFileType(filePath);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void DetectFileTypeTestCCS1()
        {
            string text = @"--------fdsa[counter parameter]--------
startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[savefdsafdsad parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
staticImageShootCount:8777
startCount:1523
totalTurnOnTime:297885635[sec]
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[messafdasfdsafdsge Log]-----------
[Mod=100]:EVENT_GOTO_EXPOSING(fsmProc NULL)
[2013/09/11 09:54:05.433][Mod=100]:exit status S_ExpReady";
            string filename = string.Format("a{0}.jpg", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text);
            string fullPathName = Path.GetFullPath(filename);

            var target = ParserManager.DetectFileType(fullPathName);

            var expected = CcsFileParserType.UnknowFormat;
            PrivateType parserPrivateObject = new PrivateType(typeof(ParserManager));
            CcsFileParserType actual = (CcsFileParserType)parserPrivateObject.InvokeStatic("DetectCcsVersion", new object[] { fullPathName });

            
            Assert.AreEqual(expected,actual);

            File.Delete(fullPathName);
        }
        [TestMethod()]
        public void DetectCCSVersion4()
        {
            string text = @"[2013/09/  fdsa";
            string filename = string.Format("a{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text);
            string fullPathName = Path.GetFullPath(filename);

            var target = ParserManager.DetectFileType(fullPathName);
            var expected = LogFileExt.UnknowType;
            Assert.AreEqual(expected, target);

            File.Delete(fullPathName);
        }
        [TestMethod()]
        public void DetectCCSVersion5()
        {
            string text = @"
[2013/09/  fdsa

";
            string filename = string.Format("DetectCCSVersion5{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text);
            string fullPathName = Path.GetFullPath(filename);

            var target = ParserManager.DetectFileType(fullPathName);
            var expected = LogFileExt.UnknowType;
            Assert.AreEqual(expected, target);

            File.Delete(fullPathName);
        }


        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        [DeploymentItem("FileConfig/M255_20130507144310_fe.log")]
        public void DetectFileTypeTestCXDI()
        {
            string filePath =Path.GetFullPath("M255_20130507144310_fe.log"); 
            LogFileExt expected = LogFileExt.Cxdi; 
            LogFileExt actual;
            actual = ParserManager.DetectFileType(filePath);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void DetectFileTypeTestMemo()
        {
            string filePath = "MemoCCS20140606153129.xml"; 
            LogFileExt expected = LogFileExt.Memo; 
            LogFileExt actual;
            actual = ParserManager.DetectFileType(filePath);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void DetectFileTypeTestMemoUnknownType()
        {
            string filePath = "Untitled.bmp"; 
            LogFileExt expected = LogFileExt.UnknowType; 
            LogFileExt actual;
            actual = ParserManager.DetectFileType(filePath);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DetectCCSVersionTest_VersionOld()
        {
            StringReader sr = new StringReader(@"2012-03-27 08:16:28.707,CXDI-FC-S21W-S1,CCS,916,1,060100001,###### Welcome to Canon CXDI. Copyright by CANON INC. 2011 V1.40.3.0 ######,2,,,Canon.Medical.DR.GAIA.Component.Logging.LogManager
2012-03-27 08:16:31.673,CXDI-FC-S21W-S1,CCS,916,1,030101001,G->F CALL [GetInstance()],2,,,Canon.Medical.DR.Seychelle.Facade.Exam.ExamFacade
2012-03-27 08:16:31.673,CXDI-FC-S21W-S1,CCS,916,1,020200017,Workflow : ExamFacade.GetInstance : 31.674,2,,,Canon.Medical.DR.Seychelle.UI.WorkflowLibrary.Workflow
2012-03-27 08:16:31.690,CXDI-FC-S21W-S1,CCS,916,1,020200005,Configflow : facade.GetSystemInfoModelName : 31.674,2,,,Canon.Medical.DR.Seychelle.UI.WorkflowLibrary.Configflow
2012-03-27 08:16:31.690,CXDI-FC-S21W-S1,CCS,916,1,030101001,G->F CALL [GetSystemInfoModelName()],2,,,Canon.Medical.DR.Seychelle.Facade.Exam.ExamFacade
2012-03-27 08:16:42.313,CXDI-FC-S21W-S1,CCS,916,1,020200005,Configflow : ExamFacade.GetInstance : 42.313,2,,,Canon.Medical.DR.Seychelle.UI.WorkflowLibrary.Configflow
2012-03-27 08:16:42.330,CXDI-FC-S21W-S1,CCS,916,1,020200012,Outputflow : ExamFacade.GetInstance : 42.313,2,,,Canon.Medical.DR.Seychelle.UI.WorkflowLibrary.Outputflow
2012-03-27 08:16:42.517,CXDI-FC-S21W-S1,CCS,916,1,030101001,G->F CALL [GetHDDUseCapacityInfo()],2,,,Canon.Medical.DR.Seychelle.Facade.Exam.ExamFacade
2012-03-27 08:16:42.610,CXDI-FC-S21W-S1,CCS,916,1,020200017,Workflow : facade.IsDemoVersion : 42.610,2,,,Canon.Medical.DR.Seychelle.UI.WorkflowLibrary.Workflow
2012-03-27 08:16:42.627,CXDI-FC-S21W-S1,CCS,916,1,030101001,G->F CALL [IsDemoVersion()],2,,,Canon.Medical.DR.Seychelle.Facade.Exam.ExamFacade"); 
            var expected = CcsFileParserType.CcsVersion1; 
            PrivateType parserPrivateObject = new PrivateType(typeof(ParserManager));
            CcsFileParserType actual = (CcsFileParserType)parserPrivateObject.InvokeStatic("DetectCcsVersion", new object[] {sr});
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DetectCCSVersionTest2()
        {
            StringReader sr = new StringReader(@"2012-03-");
            var expected = CcsFileParserType.UnknowFormat;
            PrivateType parserPrivateObject = new PrivateType(typeof(ParserManager));
            CcsFileParserType actual = (CcsFileParserType)parserPrivateObject.InvokeStatic("DetectCcsVersion", new object[] { sr });
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DetectCCSVersionTest3()
        {
            StringReader sr = new StringReader(@"");
            var expected = CcsFileParserType.UnknowFormat;
            PrivateType parserPrivateObject = new PrivateType(typeof(ParserManager));
            CcsFileParserType actual = (CcsFileParserType)parserPrivateObject.InvokeStatic("DetectCcsVersion", new object[] { sr });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DetectCCSVersionTest4()
        {
            string textUser =@"";

            string filenameUser = string.Format("a{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);
            CcsFileParserType expected = CcsFileParserType.UnknowFormat;
            PrivateType parserPrivateObject = new PrivateType(typeof(ParserManager));
            CcsFileParserType actual = (CcsFileParserType)parserPrivateObject.InvokeStatic("DetectCcsVersion", new[] {typeof(string)},new object[] { fileFullPath });
            Assert.AreEqual(expected, actual);
            File.Delete(fileFullPath);
        }


        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DetectCCSVersionTest_VersionNew()
        {
            StringReader sr = new StringReader(@"2013/10/02 13:36:37.095, A-2013-P49540, 0001, W, 060100001, ###### Welcome to Canon CXDI Controller RF. Copyright by CANON INC. 2013 V2.10.2.7 ######, , , Logging.LogManager
2013/10/02 13:36:38.305, A-2013-P49540, 0001, D, 030101001, G->F CALL [GetInstance()], , , Exam.ExamFacade
2013/10/02 13:36:38.306, A-2013-P49540, 0001, F, 020200017, Workflow : ExamFacade.GetInstance : 38.305, , , WorkflowLibrary.Workflow
2013/10/02 13:36:38.307, A-2013-P49540, 0001, E, 020200005, Configflow : facade.GetSystemInfoModelName : 38.307, , , WorkflowLibrary.Configflow
2013/10/02 13:36:38.308, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetSystemInfoModelName()], , , Exam.ExamFacade
2013/10/02 13:36:38.495, A-2013-P49540, 0001, I, 020200001, WindowUtility : SetMainWindowStartupLocation Window.Name = windStartup, Top = 0, Left = 0, Height = 1080, Width = 1920,  : 38.491, , , WindowLibrary.WindowUtility
2013/10/02 13:36:39.899, A-2013-P49540, 0001, I, 020200001, WindowUtility : SetMainWindowStartupLocation Window.Name = windMain, Top = 0, Left = 0, Height = 1080, Width = 1920,  : 39.899, , , WindowLibrary.WindowUtility
2013/10/02 13:36:40.701, A-2013-P49540, 0001, I, 020200005, Configflow : ExamFacade.GetInstance : 40.700, , , WorkflowLibrary.Configflow
2013/10/02 13:36:40.705, A-2013-P49540, 0001, I, 020200012, Outputflow : ExamFacade.GetInstance : 40.704, , , WorkflowLibrary.Outputflow
2013/10/02 13:36:40.817, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetHDDUseCapacityInfo()], , , Exam.ExamFacade
2013/10/02 13:36:40.827, A-2013-P49540, 0001, I, 020200017, Workflow : facade.GetPackageEdition : 40.827, , , WorkflowLibrary.Workflow
2013/10/02 13:36:40.828, A-2013-P49540, 0001, I, 030101001, G->F CALL [GetPackageEdition()], , , Exam.ExamFacade
2013/10/02 13:36:40.828, A-2013-P49540, 0001, I, 020200017, Workflow : facade.ValidateProduct : 40.828, , , WorkflowLibrary.Workflow
2013/10/02 13:36:40.829, A-2013-P49540, 0001, I, 030101001, G->F CALL [ValidateProduct()], , , Exam.ExamFacade"); 
            CcsFileParserType expected = CcsFileParserType.CcsVersion2;

            PrivateType parserPrivateObject = new PrivateType(typeof(ParserManager));

            CcsFileParserType actual = (CcsFileParserType)parserPrivateObject.InvokeStatic("DetectCcsVersion", new object[] { sr });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DetectCXDIVersionTest()
        {
            StringReader sr = new StringReader(@"--------[counter parameter]--------
startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
staticImageShootCount:8777
startCount:1523
totalTurnOnTime:297885635[sec]
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------
[Mod=100]:EVENT_GOTO_EXPOSING(fsmProc NULL)
[2013/09/11 09:54:05.433][Mod=100]:exit status S_ExpReady
");
            var expected = CxdiFileParserType.CxdiVersion1;

            PrivateType parserPrivateObject = new PrivateType(typeof(ParserManager));

            CxdiFileParserType actual = (CxdiFileParserType)parserPrivateObject.InvokeStatic("DetectCxdiVersion", new object[] { sr });
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DetectCXDIVersionTest1()
        {
            StringReader sr = new StringReader(@"-------dfascounter parameter]--------
startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------asdfsasaved parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
staticImageShootCount:8777
startCount:1523
totalTurnOnTime:297885635[sec]
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
----------aaaa-[message Log]-----------
[Mod=100]:EVENT_GOTO_EXPOSING(fsmProc NULL)
[2013/09/11 09:54:05.433][Mod=100]:exit status S_ExpReady
");
            var expected = CxdiFileParserType.UnknowFormat;

            PrivateType parserPrivateObject = new PrivateType(typeof(ParserManager));

            CxdiFileParserType actual = (CxdiFileParserType)parserPrivateObject.InvokeStatic("DetectCxdiVersion", new object[] { sr });
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DetectCXDIVersionTest3()
        {
            StringReader sr = null;
            var expected = CxdiFileParserType.UnknowFormat;

            PrivateType parserPrivateObject = new PrivateType(typeof(ParserManager));

            CxdiFileParserType actual = (CxdiFileParserType)parserPrivateObject.InvokeStatic("DetectCxdiVersion",new []{typeof(StringReader)} ,new object[] { sr });
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DetectCXDIVersionTest4()
        {
            StringReader sr = null;
            var expected = CxdiFileParserType.UnknowFormat;

            PrivateType parserPrivateObject = new PrivateType(typeof(ParserManager));

            CxdiFileParserType actual = (CxdiFileParserType)parserPrivateObject.InvokeStatic("DetectCxdiVersion", new[] { typeof(string) }, new object[] { null });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem("LogViewer.exe")]
        public void DetectCCSVersionTest_UnknownFormat()
        {
            StringReader sr = new StringReader(@"fdsafds0001, W, 060100001,"); 
            var expected = CcsFileParserType.UnknowFormat;
            PrivateType parserPrivateObject = new PrivateType(typeof(ParserManager));
            CcsFileParserType actual = (CcsFileParserType)parserPrivateObject.InvokeStatic("DetectCcsVersion", new object[] { sr });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCSLogTest.csv")]
        public void DetectCCSVersionTest1_NewVersion()
        {
            string filePath = "CCSLogTest.csv"; 
            var expected = CcsFileParserType.CcsVersion2;
            PrivateType parserPrivateObject = new PrivateType(typeof(ParserManager));
            CcsFileParserType actual = (CcsFileParserType)parserPrivateObject.InvokeStatic("DetectCcsVersion", new object[] { filePath });
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        [DeploymentItem(@"FileConfig\CCSLogTest_OldVersion.csv")]
        public void DetectCCSVersionTest_OldVersion()
        {
            string filePath = "CCSLogTest_OldVersion.csv"; 
            var expected = CcsFileParserType.CcsVersion1;
            PrivateType parserPrivateObject = new PrivateType(typeof(ParserManager));
            CcsFileParserType actual = (CcsFileParserType)parserPrivateObject.InvokeStatic("DetectCcsVersion", new object[] { filePath });
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParserManagerConstructorTest()
        {
            ParserManager target = new ParserManager();
            Assert.AreNotEqual(null, target);
        }
    }
}
