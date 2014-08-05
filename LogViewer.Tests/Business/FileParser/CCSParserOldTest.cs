using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using LogViewer.Business.FileParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.Business.FileParser
{
    [TestClass]
    public class CCSParserOldTest
    {
        [TestMethod]
        public void ParserFromFileTest()
        {

            string textUser =
                @"2011-12-13 08:28:45.537,CXDI-FC-S21W-S1,CCS,1504,1,060100001,###### Welcome to Canon CXDI. Copyright by CANON INC. 2011 V1.40.1.4 ######,2,,,Canon.Medical.DR.GAIA.Component.Logging.LogManager
2011-12-13 08:28:48.663,CXDI-FC-S21W-S1,CCS,1504,1,030101001,G->F CALL [GetInstance()],2,,,Canon.Medical.DR.Seychelle.Facade.Exam.ExamFacade
2011-12-13 08:28:48.680,CXDI-FC-S21W-S1,CCS,1504,1,020200017,Workflow : ExamFacade.GetInstance : 48.663,2,,,Canon.Medical.DR.Seychelle.UI.WorkflowLibrary.Workflow
2011-12-13 08:28:48.693,CXDI-FC-S21W-S1,CCS,1504,1,020200005,Configflow : facade.GetSystemInfoModelName : 48.678,2,,,Canon.Medical.DR.Seychelle.UI.WorkflowLibrary.Configflow
2011-12-13 08:28:48.693,CXDI-FC-S21W-S1,CCS,1504,1,030101001,G->F CALL [GetSystemInfoModelName()],2,,,Canon.Medical.DR.Seychelle.Facade.Exam.ExamFacade";

            string filenameUser = string.Format("ParserFromFileTest{0}.txt", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSParserOld();


            var actual = target.ParserFromFile(fileFullPath).Count;
            var expected = 5;
            Assert.AreEqual(expected, actual);
            File.Delete(fileFullPath);


        }
        [TestMethod]
        public void ParserFromFileTest2()
        {

            string textUser =
                "2011-12-13 08:28:45.537,CXDI-FC-S21W-S1,CCS,1504,1,060100001,###### Welcome to Canon CXDI. Copyright by CANON INC. 2011 V1.40.1.4 ######,2,\0,,Canon.Medical.DR.GAIA.Component.Logging.LogManager\n"+
@"2011-12-13 08:28:48.663,CXDI-FC-S21W-S1,CCS,1504,1,030101001,G->F CALL [GetInstance()],2,,,Canon.Medical.DR.Seychelle.Facade.Exam.ExamFacade
2011-12-13 08:28:48.680,CXDI-FC-S21W-S1,CCS,1504,1,020200017,Workflow : ExamFacade.GetInstance : 48.663,2,,,Canon.Medical.DR.Seychelle.UI.WorkflowLibrary.Workflow
2011-12-13 08:28:48.693,CXDI-FC-S21W-S1,CCS,1504,1,020200005,Configflow : facade.GetSystemInfoModelName : 48.678,2,,,Canon.Medical.DR.Seychelle.UI.WorkflowLibrary.Configflow
2011-12-13 08:28:48.693,CXDI-FC-S21W-S1,CCS,1504,1,030101001,G->F CALL [GetSystemInfoModelName()],2,,,Canon.Medical.DR.Seychelle.Facade.Exam.ExamFacade";

            string filenameUser = string.Format("ParserFromFileTest2{0}.txt", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSParserOld();


            var actual = target.ParserFromFile(fileFullPath).Count;
            var expected = 5;
            Assert.AreEqual(expected, actual);
            File.Delete(fileFullPath);


        }
        [TestMethod]
        public void ParserFromFileTest3()
        {

            string textUser =
                @"2011-13-13 08:28:45.537,CXDI-FC-S21W-S1,CCS,1504,1,060100001,###### Welcome to Canon CXDI. Copyright by CANON INC. 2011 V1.40.1.4 ######,2,\0,,Canon.Medical.DR.GAIA.Component.Logging.LogManager
2011-12-13 08:28:48.663,CXDI-FC-S21W-S1,CCS,1504,1,030101001,G->F CALL [GetInstance()],2,,,Canon.Medical.DR.Seychelle.Facade.Exam.ExamFacade
2011-12-13 08:28:48.680,CXDI-FC-S21W-S1,CCS,1504,1,020200017,Workflow : ExamFacade.GetInstance : 48.663,2,,,Canon.Medical.DR.Seychelle.UI.WorkflowLibrary.Workflow
2011-12-13 08:28:48.693,CXDI-FC-S21W-S1,CCS,1504,1,020200005,Configflow : facade.GetSystemInfoModelName : 48.678,2,,,Canon.Medical.DR.Seychelle.UI.WorkflowLibrary.Configflow
2011-12-13 08:28:48.693,CXDI-FC-S21W-S1,CCS,1504,1,030101001,G->F CALL [GetSystemInfoModelName()],2,,,Canon.Medical.DR.Seychelle.Facade.Exam.ExamFacade";

            string filenameUser = string.Format("ParserFromFileTest3{0}.txt", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSParserOld();


            var actual = target.ParserFromFile(fileFullPath).Count;
            var expected = 4;
            Assert.AreEqual(expected, actual);
            File.Delete(fileFullPath);


        }
        [TestMethod]
        public void ParserFromFileTest4()
        {

            string textUser =
@"2011-13-13 08:28:45.537
2011-12-13 08:28:48.663,CXDI-FC-S21W-S1,CCS,1504,1,030101001,G->F CALL [GetInstance()],2,,,Canon.Medical.DR.Seychelle.Facade.Exam.ExamFacade
2011-12-13 08:28:48.680,CXDI-FC-S21W-S1,CCS,1504,1,020200017,Workflow : ExamFacade.GetInstance : 48.663,2,,,Canon.Medical.DR.Seychelle.UI.WorkflowLibrary.Workflow
2011-12-13 08:28:48.693,CXDI-FC-S21W-S1,CCS,1504,1,020200005,Configflow : facade.GetSystemInfoModelName : 48.678,2,,,Canon.Medical.DR.Seychelle.UI.WorkflowLibrary.Configflow
2011-12-13 08:28:48.693,CXDI-FC-S21W-S1,CCS,1504,1,030101001,G->F CALL [GetSystemInfoModelName()],2,,,Canon.Medical.DR.Seychelle.Facade.Exam.ExamFacade";

            string filenameUser = string.Format("ParserFromFileTest4{0}.txt", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSParserOld();


            var actual = target.ParserFromFile(fileFullPath).Count;
            var expected = 3;
            Assert.AreEqual(expected, actual);
            File.Delete(fileFullPath);


        }
        [TestMethod]
        [ExpectedException(typeof(ObjectDisposedException))]
        public void ParserFromFileTest5()
        {

            StringReader reader = new StringReader(
@"2011-13-13 08:28:45.537
2011-12-13 08:28:48.663,CXDI-FC-S21W-S1,CCS,1504,1,030101001,G->F CALL [GetInstance()],2,,,Canon.Medical.DR.Seychelle.Facade.Exam.ExamFacade
2011-12-13 08:28:48.680,CXDI-FC-S21W-S1,CCS,1504,1,020200017,Workflow : ExamFacade.GetInstance : 48.663,2,,,Canon.Medical.DR.Seychelle.UI.WorkflowLibrary.Workflow
2011-12-13 08:28:48.693,CXDI-FC-S21W-S1,CCS,1504,1,020200005,Configflow : facade.GetSystemInfoModelName : 48.678,2,,,Canon.Medical.DR.Seychelle.UI.WorkflowLibrary.Configflow
2011-12-13 08:28:48.693,CXDI-FC-S21W-S1,CCS,1504,1,030101001,G->F CALL [GetSystemInfoModelName()],2,,,Canon.Medical.DR.Seychelle.Facade.Exam.ExamFacade");

            var target = new CCSParserOld();

            reader.Dispose();
            var actual = target.ParserFromFile(reader).Count;
            var expected = 3;
            Assert.AreEqual(expected, actual);


        }


    }
}
