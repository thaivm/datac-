using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using LogViewer.Business;
using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LogViewer.Tests.Business.FileParser
{
    [TestClass]
    public class CCSMemoParserNewTest
    {
        #region "ParserFromFile Test"

        [TestMethod]
        public void ParserFromFileTest()
        {
            string textUser =
             @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CCS><CommentArea><Comment Id='0' Line='3'>ab</Comment><Comment Id='1' Line='4'>ab</Comment></CommentArea><BookmarkArea><Bookmark Id='0' Line='1' /><Bookmark Id='1' Line='2' /><Bookmark Id='2' Line='4' /></BookmarkArea><LogArea TotalLine='15883'>
2014-04-22 09:44:39.240,A-2013-P49540,,0001,I,060100001,###### Welcome to Canon CXDI Controller RF. Copyright by CANON INC. 2014 V2.12.0.11 ######,,,Logging.LogManager2014/04/22 09:44:42.331,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetInstance()],,,Exam.ExamFacade
2014-04-22 09:44:42.332,A-2013-P49540,,0001,I,020200017,Workflow : ExamFacade.GetInstance : 42.331,,,WorkflowLibrary.Workflow
2014-04-22 09:44:42.334,A-2013-P49540,,0001,I,020200005,Configflow : facade.GetSystemInfoModelName : 42.333,,,WorkflowLibrary.Configflow
2014-04-22 09:44:42.334,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetSystemInfoModelName()],,,Exam.ExamFacade
2014-04-22 09:44:42.446,A-2013-P49540,,0001,I,020200001,WindowUtility : SetMainWindowStartupLocation Window.Name = windStartup,Top = 0,Left = 0,Height = 1080,Width = 1920,: 42.443,,,WindowLibrary.WindowUtility
2014-04-22 09:44:43.178,A-2013-P49540,,0001,I,020200001,WindowUtility : SetMainWindowStartupLocation Window.Name = windMain,Top = 0,Left = 0,Height = 1080,Width = 1920,: 43.178,,,WindowLibrary.WindowUtility
2014-04-22 09:44:43.810,A-2013-P49540,,0001,I,020200005,Configflow : ExamFacade.GetInstance : 43.809,,,WorkflowLibrary.Configflow
2014-04-22 09:44:43.814,A-2013-P49540,,0001,I,020200012,Outputflow : ExamFacade.GetInstance : 43.813,,,WorkflowLibrary.Outputflow
2014-04-22 09:44:43.919,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetHDDUseCapacityInfo()],,,Exam.ExamFacade
</LogArea></CCS></UserMemorizedLogData>";

            string filenameUser = string.Format("ParserFromFileTest{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserNew();


            MemoLog<CCSLogRecord> actual = target.ParserFromFile(fileFullPath);
            var expected = 9;
            Assert.IsNotNull(actual);
            File.Delete(fileFullPath);

        }
        [TestMethod]
        public void ParserFromFileTest31()
        {

            var target = new CCSMemoParserNew();


            MemoLog<CCSLogRecord> actual = target.ParserFromFile(string.Empty);
            Assert.IsNotNull(actual);

        }

        [TestMethod]
        [ExpectedException(typeof(XmlException))]
        public void ParserFromFileTest2()
        {
            string textUser =
             @" version='1.0' encoding='utf-8'?orizedLogData><CCS><CommentArea><Comment Id='0' Line='3'>ab</Comment><Comment Id='1' Line='4'>ab</Comment></CommentArea><BookmarkArea><Bookmark Id='0' Line='1' /><Bookmark Id='1' Line='2' /><Bookmark Id='2' Line='4' /></BookmarkArea><LogArea TotalLine='9'>
2014/04/22 09:44:39.240,A-2013-P49540,,0001,I,060100001,###### Welcome to Canon CXDI Controller RF. Copyright by CANON INC. 2014 V2.12.0.11 ######,,,Logging.LogManager2014/04/22 09:44:42.331,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetInstance()],,,Exam.ExamFacade
2014/04/22 09:44:42.332,A-2013-P49540,,0001,I,020200017,Workflow : ExamFacade.GetInstance : 42.331,,,WorkflowLibrary.Workflow
2014/04/22 09:44:42.334,A-2013-P49540,,0001,I,020200005,Configflow : facade.GetSystemInfoModelName : 42.333,,,WorkflowLibrary.Configflow
2014/04/22 09:44:42.334,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetSystemInfoModelName()],,,Exam.ExamFacade
2014/04/22 09:44:42.446,A-2013-P49540,,0001,I,020200001,WindowUtility : SetMainWindowStartupLocation Window.Name = windStartup,Top = 0,Left = 0,Height = 1080,Width = 1920,: 42.443,,,WindowLibrary.WindowUtility
2014/04/22 09:44:43.178,A-2013-P49540,,0001,I,020200001,WindowUtility : SetMainWindowStartupLocation Window.Name = windMain,Top = 0,Left = 0,Height = 1080,Width = 1920,: 43.178,,,WindowLibrary.WindowUtility
2014/04/22 09:44:43.810,A-2013-P49540,,0001,I,020200005,Configflow : ExamFacade.GetInstance : 43.809,,,WorkflowLibrary.Configflow
2014/04/22 09:44:43.814,A-2013-P49540,,0001,I,020200012,Outputflow : ExamFacade.GetInstance : 43.813,,,WorkflowLibrary.Outputflow
2014/04/22 09:44:43.919,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetHDDUseCapacityInfo()],,,Exam.ExamFacade
</LogArea></CCS></UserMemorizedLogData>";

            string filenameUser = string.Format("ParserFromFileTest2{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserNew();


            MemoLog<CCSLogRecord> actual = target.ParserFromFile(fileFullPath);
            var expected = 0;
            Assert.AreEqual(expected, actual.Records.Count);
            File.Delete(fileFullPath);

        }
        [TestMethod]
        public void ParserFromFileTest3()
        {
            string textUser =
             @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CCS><CommentArea></CommentArea><BookmarkArea></BookmarkArea><LogArea TotalLine='9'>
2014/04/22 09:44:39.240,A-2013-P49540,,0001,I,060100001,###### Welcome to Canon CXDI Controller RF. Copyright by CANON INC. 2014 V2.12.0.11 ######,,,Logging.LogManager2014/04/22 09:44:42.331,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetInstance()],,,Exam.ExamFacade
2014/04/22 09:44:42.332,A-2013-P49540,,0001,I,020200017,Workflow : ExamFacade.GetInstance : 42.331,,,WorkflowLibrary.Workflow
2014/04/22 09:44:42.334,A-2013-P49540,,0001,I,020200005,Configflow : facade.GetSystemInfoModelName : 42.333,,,WorkflowLibrary.Configflow
2014/04/22 09:44:42.334,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetSystemInfoModelName()],,,Exam.ExamFacade
2014/04/22 09:44:42.446,A-2013-P49540,,0001,I,020200001,WindowUtility : SetMainWindowStartupLocation Window.Name = windStartup,Top = 0,Left = 0,Height = 1080,Width = 1920,: 42.443,,,WindowLibrary.WindowUtility
2014/04/22 09:44:43.178,A-2013-P49540,,0001,I,020200001,WindowUtility : SetMainWindowStartupLocation Window.Name = windMain,Top = 0,Left = 0,Height = 1080,Width = 1920,: 43.178,,,WindowLibrary.WindowUtility
2014/04/22 09:44:43.810,A-2013-P49540,,0001,I,020200005,Configflow : ExamFacade.GetInstance : 43.809,,,WorkflowLibrary.Configflow
2014/04/22 09:44:43.814,A-2013-P49540,,0001,I,020200012,Outputflow : ExamFacade.GetInstance : 43.813,,,WorkflowLibrary.Outputflow
2014/04/22 09:44:43.919,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetHDDUseCapacityInfo()],,,Exam.ExamFacade
</LogArea></CCS></UserMemorizedLogData>";

            string filenameUser = string.Format("ParserFromFileTest3{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserNew();

            MemoLog<CCSLogRecord> actual = target.ParserFromFile(fileFullPath);
            var expected = 0;
            Assert.AreEqual(expected, actual.Comments.Count);
            File.Delete(fileFullPath);

        }
        [TestMethod]
        public void ParserFromFileTest4()
        {
            string textUser =
             @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CCS><BookmarkArea></BookmarkArea><LogArea TotalLine='9'>
2014/04/22 09:44:39.240,A-2013-P49540,,0001,I,060100001,###### Welcome to Canon CXDI Controller RF. Copyright by CANON INC. 2014 V2.12.0.11 ######,,,Logging.LogManager2014/04/22 09:44:42.331,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetInstance()],,,Exam.ExamFacade
2014/04/22 09:44:42.332,A-2013-P49540,,0001,I,020200017,Workflow : ExamFacade.GetInstance : 42.331,,,WorkflowLibrary.Workflow
2014/04/22 09:44:42.334,A-2013-P49540,,0001,I,020200005,Configflow : facade.GetSystemInfoModelName : 42.333,,,WorkflowLibrary.Configflow
2014/04/22 09:44:42.334,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetSystemInfoModelName()],,,Exam.ExamFacade
2014/04/22 09:44:42.446,A-2013-P49540,,0001,I,020200001,WindowUtility : SetMainWindowStartupLocation Window.Name = windStartup,Top = 0,Left = 0,Height = 1080,Width = 1920,: 42.443,,,WindowLibrary.WindowUtility
2014/04/22 09:44:43.178,A-2013-P49540,,0001,I,020200001,WindowUtility : SetMainWindowStartupLocation Window.Name = windMain,Top = 0,Left = 0,Height = 1080,Width = 1920,: 43.178,,,WindowLibrary.WindowUtility
2014/04/22 09:44:43.810,A-2013-P49540,,0001,I,020200005,Configflow : ExamFacade.GetInstance : 43.809,,,WorkflowLibrary.Configflow
2014/04/22 09:44:43.814,A-2013-P49540,,0001,I,020200012,Outputflow : ExamFacade.GetInstance : 43.813,,,WorkflowLibrary.Outputflow
2014/04/22 09:44:43.919,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetHDDUseCapacityInfo()],,,Exam.ExamFacade
</LogArea></CCS></UserMemorizedLogData>";

            string filenameUser = string.Format("ParserFromFileTest3{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserNew();

            MemoLog<CCSLogRecord> actual = target.ParserFromFile(fileFullPath);
            var expected = 0;
            Assert.AreEqual(expected, actual.Comments.Count);
            File.Delete(fileFullPath);

        }

        [TestMethod]
        public void ParserFromFileTest5()
        {
            string textUser =
                @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CCS><CommentArea><Comment Id='0' Line='3'>ab</Comment><Comment Id='1' Line='4'>ab</Comment></CommentArea><BookmarkArea><Bookmark Id='0' Line='1' /><Bookmark Id='1' Line='2' /><Bookmark Id='2' Line='4' /></BookmarkArea><LogArea TotalLine='9'>
2014/04/22 09:44:39.240,A-2013-P49540,,0001,I,060100001,###### Welcome to Canon CXDI Controller RF. Copyright by CANON INC. 2014 V2.12.0.11 ######,,,Logging.LogManager2014/04/22 09:44:42.331,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetInstance()],,,Exam.ExamFacade
2014/04/22 09:44:42.332,A-2013-P49540,,0001,I,020200017,Workflow : ExamFacade.GetInstance : 42.331,,,WorkflowLibrary.Workflow
2014/04/22 09:44:42.334,A-2013-P49540,,0001,I,020200005,Configflow : facade.GetSystemInfoModelName : 42.333,,,WorkflowLibrary.Configflow
2014/04/22 09:44:42.334,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetSystemInfoModelName()],,,Exam.ExamFacade
2014/04/22 09:44:42.446,A-2013-P49540,,0001,I,020200001,WindowUtility : SetMainWindowStartupLocation Window.Name = windStartup,Top = 0,Left = 0,Height = 1080,Width = 1920,: 42.443,,,WindowLibrary.WindowUtility
2014/04/22 09:44:43.178,A-2013-P49540,,0001,I,020200001,WindowUtility : SetMainWindowStartupLocation Window.Name = windMain,Top = 0,Left = 0,Height = 1080,Width = 1920,: 43.178,,,WindowLibrary.WindowUtility
2014/04/22 09:44:43.810,A-2013-P49540,,0001,I,020200005,Configflow : ExamFacade.GetInstance : 43.809,,,WorkflowLibrary.Configflow
2014/04/22 09:44:43.814,A-2013-P49540,,0001,I,020200012,Outputflow : ExamFacade.GetInstance : 43.813,,,WorkflowLibrary.Outputflow
2014/04/22 09:44:43.919,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetHDDUseCapacityInfo()],,,Exam.ExamFacade
</LogArea></CCS></UserMemorizedLogData>";

            string filenameUser = string.Format("ParserFromFileTest3{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserNew();

            MemoLog<CCSLogRecord> actual = target.ParserFromFile(fileFullPath);
            var expected = 2;
            Assert.AreEqual(expected, actual.Comments.Count);
            File.Delete(fileFullPath);
        }
        [TestMethod]
        public void ParserFromFileTest6()
        {
            string textUser =
                @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CCS><CommentArea><Comment Id='0' Line='3'>ab</Comment><Comment Id='1' Line='4'>ab</Comment></CommentArea><BookmarkArea></BookmarkArea><LogArea TotalLine='9'>
2014/04/22 09:44:39.240,A-2013-P49540,,0001,I,060100001,###### Welcome to Canon CXDI Controller RF. Copyright by CANON INC. 2014 V2.12.0.11 ######,,,Logging.LogManager2014/04/22 09:44:42.331,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetInstance()],,,Exam.ExamFacade
2014/04/22 09:44:42.332,A-2013-P49540,,0001,I,020200017,Workflow : ExamFacade.GetInstance : 42.331,,,WorkflowLibrary.Workflow
2014/04/22 09:44:42.334,A-2013-P49540,,0001,I,020200005,Configflow : facade.GetSystemInfoModelName : 42.333,,,WorkflowLibrary.Configflow
2014/04/22 09:44:42.334,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetSystemInfoModelName()],,,Exam.ExamFacade
2014/04/22 09:44:42.446,A-2013-P49540,,0001,I,020200001,WindowUtility : SetMainWindowStartupLocation Window.Name = windStartup,Top = 0,Left = 0,Height = 1080,Width = 1920,: 42.443,,,WindowLibrary.WindowUtility
2014/04/22 09:44:43.178,A-2013-P49540,,0001,I,020200001,WindowUtility : SetMainWindowStartupLocation Window.Name = windMain,Top = 0,Left = 0,Height = 1080,Width = 1920,: 43.178,,,WindowLibrary.WindowUtility
2014/04/22 09:44:43.810,A-2013-P49540,,0001,I,020200005,Configflow : ExamFacade.GetInstance : 43.809,,,WorkflowLibrary.Configflow
2014/04/22 09:44:43.814,A-2013-P49540,,0001,I,020200012,Outputflow : ExamFacade.GetInstance : 43.813,,,WorkflowLibrary.Outputflow
2014/04/22 09:44:43.919,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetHDDUseCapacityInfo()],,,Exam.ExamFacade
</LogArea></CCS></UserMemorizedLogData>";

            string filenameUser = string.Format("ParserFromFileTest3{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserNew();

            MemoLog<CCSLogRecord> actual = target.ParserFromFile(fileFullPath);
            var expected = 0;
            Assert.AreEqual(expected, actual.Bookmarks.Count);
            File.Delete(fileFullPath);
        }
        [TestMethod]
        public void ParserFromFileTest7()
        {
            string textUser =
                @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CCS><CommentArea><Comment Id='0' Line='3'>ab</Comment><Comment Id='1' Line='4'>ab</Comment></CommentArea><LogArea TotalLine='9'>
2014/04/22 09:44:39.240,A-2013-P49540,,0001,I,060100001,###### Welcome to Canon CXDI Controller RF. Copyright by CANON INC. 2014 V2.12.0.11 ######,,,Logging.LogManager2014/04/22 09:44:42.331,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetInstance()],,,Exam.ExamFacade
2014/04/22 09:44:42.332,A-2013-P49540,,0001,I,020200017,Workflow : ExamFacade.GetInstance : 42.331,,,WorkflowLibrary.Workflow
2014/04/22 09:44:42.334,A-2013-P49540,,0001,I,020200005,Configflow : facade.GetSystemInfoModelName : 42.333,,,WorkflowLibrary.Configflow
2014/04/22 09:44:42.334,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetSystemInfoModelName()],,,Exam.ExamFacade
2014/04/22 09:44:42.446,A-2013-P49540,,0001,I,020200001,WindowUtility : SetMainWindowStartupLocation Window.Name = windStartup,Top = 0,Left = 0,Height = 1080,Width = 1920,: 42.443,,,WindowLibrary.WindowUtility
2014/04/22 09:44:43.178,A-2013-P49540,,0001,I,020200001,WindowUtility : SetMainWindowStartupLocation Window.Name = windMain,Top = 0,Left = 0,Height = 1080,Width = 1920,: 43.178,,,WindowLibrary.WindowUtility
2014/04/22 09:44:43.810,A-2013-P49540,,0001,I,020200005,Configflow : ExamFacade.GetInstance : 43.809,,,WorkflowLibrary.Configflow
2014/04/22 09:44:43.814,A-2013-P49540,,0001,I,020200012,Outputflow : ExamFacade.GetInstance : 43.813,,,WorkflowLibrary.Outputflow
2014/04/22 09:44:43.919,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetHDDUseCapacityInfo()],,,Exam.ExamFacade
</LogArea></CCS></UserMemorizedLogData>";

            string filenameUser = string.Format("ParserFromFileTest3{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserNew();

            MemoLog<CCSLogRecord> actual = target.ParserFromFile(fileFullPath);
            var expected = 0;
            Assert.AreEqual(expected, actual.Bookmarks.Count);
            File.Delete(fileFullPath);
        }
        [TestMethod]
        public void ParserFromFileTest8()
        {
            string textUser =
                @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CCS><CommentArea><Comment Id='0' Line='3'>ab</Comment><Comment Id='1' Line='4'>ab</Comment></CommentArea><BookmarkArea><Bookmark Id='0' Line='1' /><Bookmark Id='1' Line='2' /><Bookmark Id='2' Line='4' /></BookmarkArea><LogArea TotalLine='9'>
2014/04/22 09:44:39.240,A-2013-P49540,,0001,I,060100001,###### Welcome to Canon CXDI Controller RF. Copyright by CANON INC. 2014 V2.12.0.11 ######,,,Logging.LogManager2014/04/22 09:44:42.331,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetInstance()],,,Exam.ExamFacade
2014/04/22 09:44:42.332,A-2013-P49540,,0001,I,020200017,Workflow : ExamFacade.GetInstance : 42.331,,,WorkflowLibrary.Workflow
2014/04/22 09:44:42.334,A-2013-P49540,,0001,I,020200005,Configflow : facade.GetSystemInfoModelName : 42.333,,,WorkflowLibrary.Configflow
2014/04/22 09:44:42.334,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetSystemInfoModelName()],,,Exam.ExamFacade
2014/04/22 09:44:42.446,A-2013-P49540,,0001,I,020200001,WindowUtility : SetMainWindowStartupLocation Window.Name = windStartup,Top = 0,Left = 0,Height = 1080,Width = 1920,: 42.443,,,WindowLibrary.WindowUtility
2014/04/22 09:44:43.178,A-2013-P49540,,0001,I,020200001,WindowUtility : SetMainWindowStartupLocation Window.Name = windMain,Top = 0,Left = 0,Height = 1080,Width = 1920,: 43.178,,,WindowLibrary.WindowUtility
2014/04/22 09:44:43.810,A-2013-P49540,,0001,I,020200005,Configflow : ExamFacade.GetInstance : 43.809,,,WorkflowLibrary.Configflow
2014/04/22 09:44:43.814,A-2013-P49540,,0001,I,020200012,Outputflow : ExamFacade.GetInstance : 43.813,,,WorkflowLibrary.Outputflow
2014/04/22 09:44:43.919,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetHDDUseCapacityInfo()],,,Exam.ExamFacade
</LogArea></CCS></UserMemorizedLogData>";

            string filenameUser = string.Format("ParserFromFileTest3{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserNew();

            MemoLog<CCSLogRecord> actual = target.ParserFromFile(fileFullPath);
            var expected = 3;
            Assert.AreEqual(expected, actual.Bookmarks.Count);
            File.Delete(fileFullPath);
        }
        [TestMethod]
        public void ParserFromFileTest9()
        {
            string textUser =
             @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CCS><CommentArea><Comment Id='0' Line='3'>ab</Comment><Comment Id='1' Line='4'>ab</Comment></CommentArea><BookmarkArea><Bookmark Id='0' Line='1' /><Bookmark Id='1' Line='2' /><Bookmark Id='2' Line='4' /></BookmarkArea><LogArea TotalLine='9'>
2014/04/22 09:44:39.240,A-2013-P49540,,0001,I,060100001,###### Welcome to Canon CXDI Controller RF. Copyright by CANON INC. 2014 V2.12.0.11 ######,,,Logging.LogManager2014/04/22 09:44:42.331,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetInstance()],,,Exam.ExamFacade
2014/04/22 09:44:42.332,A-2013-P49540,,0001,I,020200017,Workflow : ExamFacade.GetInstance : 42.331,,,WorkflowLibrary.Workflow
2014/04/22 09:44:42.334,A-2013-P49540,,0001,I,020200005,Configflow : facade.GetSystemInfoModelName : 42.333,,,WorkflowLibrary.Configflow
2014/04/22 09:44:42.334,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetSystemInfoModelName()],,,Exam.ExamFacade
2014/04/22 09:44:42.446,A-2013-P49540,,0001,I,020200001,WindowUtility : SetMainWindowStartupLocation Window.Name = windStartup,Top = 0,Left = 0,Height = 1080,Width = 1920,: 42.443,,,WindowLibrary.WindowUtility
2014/04/22 09:44:43.178,A-2013-P49540,,0001,I,020200001,WindowUtility : SetMainWindowStartupLocation Window.Name = windMain,Top = 0,Left = 0,Height = 1080,Width = 1920,: 43.178,,,WindowLibrary.WindowUtility
2014/04/22 09:44:43.810,A-2013-P49540,,0001,I,020200005,Configflow : ExamFacade.GetInstance : 43.809,,,WorkflowLibrary.Configflow
2014/04/22 09:44:43.814,A-2013-P49540,,0001,I,020200012,Outputflow : ExamFacade.GetInstance : 43.813,,,WorkflowLibrary.Outputflow
2014/04/22 09:44:43.919,A-2013-P49540,,0001,I,030101001,G-&gt;F CALL [GetHDDUseCapacityInfo()],,,Exam.ExamFacade
</LogArea></CCS></UserMemorizedLogData>";

            string filenameUser = string.Format("ParserFromFileTest3{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserNew();

            MemoLog<CCSLogRecord> actual = target.ParserFromFile(fileFullPath);
            var expected = 9;
            Assert.AreEqual(expected, actual.Records.Count);
            File.Delete(fileFullPath);

        }
#endregion
        #region "WriteMemoLogTest"
        [TestMethod]
        public void WriteMemoLogTest10()
        {

            string filenameUser = string.Format("WriteMemoLogTest1{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserNew();
            var actual = target.WriteMemoLogFile(fileFullPath);

            var expected = false;
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);
        }
        [TestMethod]
        public void WriteMemoLogTest11()
        {

            string filenameUser = string.Format("WriteMemoLogTest1{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserNew();

            var ls = new List<CCSLogRecord> ();
            var actual = target.WriteMemoLogFile(fileFullPath);
            target.LogRecords = logRecords(ls);
            var expected = false;
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);
        }

        [TestMethod]
        public void WriteMemoLogTest1()
        {

            string filenameUser = string.Format("WriteMemoLogTest1{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserNew();
            var record1 = new CCSLogRecord { DateTime =DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CCSLogRecord { DateTime =DateTime.Parse("2014/10/10 10:10:10.100") };
            var record3 = new CCSLogRecord { DateTime =DateTime.Parse("2014/10/20 10:10:10.100") };
            var record4 = new CCSLogRecord { DateTime = DateTime.Parse("2014/10/22 10:10:10.100") };

            var ls = new List<CCSLogRecord> { record1, record2, record3, record4 };
            target.LogRecords = logRecords(ls);
            var actual = target.WriteMemoLogFile(fileFullPath);

            var expected = true;
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);
        }
        [TestMethod]
        public void WriteMemoLogTest2()
        {

            string filenameUser = string.Format("WriteMemoLogTest2{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserNew();
            var record1 = new CCSLogRecord { DateTime =DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CCSLogRecord { DateTime =DateTime.Parse("2014/10/10 10:10:10.100") };
            var record3 = new CCSLogRecord { DateTime =DateTime.Parse("2014/10/20 10:10:10.100") };
            var record4 = new CCSLogRecord { DateTime = DateTime.Parse("2014/10/22 10:10:10.100") };

            var ls = new List<CCSLogRecord> { record1, record2, record3, record4 };
            
            var actual = target.WriteMemoLogFile(fileFullPath);

            var expected = false;
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);
        }
        [TestMethod]
    [ExpectedException(typeof(IOException))]
        public void WriteMemoLogTest3()
        {

            string filenameUser = string.Format("WriteMemoLogTest3{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserNew();
            var record1 = new CCSLogRecord { DateTime =DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CCSLogRecord { DateTime =DateTime.Parse("2014/10/10 10:10:10.100") };
            var record3 = new CCSLogRecord { DateTime =DateTime.Parse("2014/10/20 10:10:10.100") };
            var record4 = new CCSLogRecord { DateTime = DateTime.Parse("2014/10/22 10:10:10.100") };

            var ls = new List<CCSLogRecord> { record1, record2, record3, record4 };
            target.LogRecords = logRecords(ls);
            FileStream fs = File.OpenWrite(fileFullPath);
            var actual = target.WriteMemoLogFile(fileFullPath);
            fs.Close();
            var expected = false;
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);
        }

        public ReadOnlyCollection<CCSLogRecord> logRecords(List<CCSLogRecord> ls)
        {
            return new ReadOnlyCollection<CCSLogRecord>(ls);
        }
        public ReadOnlyCollection<CCSLogRecord> bookMarks(List<CCSLogRecord> ls)
        {
            return new ReadOnlyCollection<CCSLogRecord>(ls);
        }
        [TestMethod]
        public void WriteMemoLogTest4()
        {

            string filenameUser = string.Format("WriteMemoLogTest4{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserNew();
            var record1 = new CCSLogRecord { DateTime =DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CCSLogRecord { DateTime =DateTime.Parse("2014/10/10 10:10:10.100") };
            var record3 = new CCSLogRecord { DateTime =DateTime.Parse("2014/10/20 10:10:10.100") };
            var record4 = new CCSLogRecord { DateTime =DateTime.Parse("2014/10/22 10:10:10.100") };

            var ls = new List<CCSLogRecord> { record1, record2, record3, record4 };
            target.LogRecords = logRecords(ls);
            target.Comments = new Dictionary<CCSLogRecord, string>();
            target.Comments.Add(record1,"abc");
            target.Comments.Add(record3,"xxx");

            var actual = target.WriteMemoLogFile(fileFullPath);

            var expected = true;
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);
        }
        [TestMethod]
        public void WriteMemoLogTest5()
        {

            string filenameUser = string.Format("WriteMemoLogTest5{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserNew();
            var record1 = new CCSLogRecord { DateTime =DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CCSLogRecord { DateTime =DateTime.Parse("2014/10/10 10:10:10.100") };
            var record3 = new CCSLogRecord { DateTime =DateTime.Parse("2014/10/20 10:10:10.100") };
            var record4 = new CCSLogRecord { DateTime =DateTime.Parse("2014/10/22 10:10:10.100") };

            var ls = new List<CCSLogRecord> { record1, record2, record3, record4 };
            target.LogRecords = logRecords(ls);
            target.Comments = new Dictionary<CCSLogRecord, string>();
            target.Comments.Add(record1, "abc");
            target.Comments.Add(record3, "xxx");
            target.Bookmarks = bookMarks(new List<CCSLogRecord> {record2, record4});
            var actual = target.WriteMemoLogFile(fileFullPath);

            var expected = true;
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);
        }
        [TestMethod]
        public void WriteMemoLogTest6()
        {

            string filenameUser = string.Format("WriteMemoLogTest6{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserNew();
            var record1 = new CCSLogRecord { DateTime =DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CCSLogRecord { DateTime =DateTime.Parse("2014/10/10 10:10:10.100") };
            var record3 = new CCSLogRecord { DateTime =DateTime.Parse("2014/10/20 10:10:10.100") };
            var record4 = new CCSLogRecord { DateTime =DateTime.Parse("2014/10/22 10:10:10.100") };

            var ls = new List<CCSLogRecord> { record1, record2, record3, record4 };
            target.LogRecords = logRecords(ls);
            target.Comments = new Dictionary<CCSLogRecord, string>();
            target.Bookmarks = bookMarks(new List<CCSLogRecord> { record2, record4 });
            var actual = target.WriteMemoLogFile(fileFullPath);

            var expected = true;
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);
        }
        #endregion
    }
}
