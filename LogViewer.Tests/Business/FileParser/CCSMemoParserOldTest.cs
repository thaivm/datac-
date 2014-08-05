using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using LogViewer.Business.FileParser;
using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.Business.FileParser
{
    [TestClass]
    public class CCSMemoParserOldTest
    {
#region "ParseFromFileTest"
        [TestMethod]
        public void ParserFromFileTest17()
        {
            var target = new CCSMemoParserOld();

            Assert.IsNotNull(target);

        }
        //[TestMethod]
        //public void ParserFromFileTest18()
        //{

        //    var target = new CCSMemoParserOld();


        //    MemoLog<CCSLogRecord> actual = target.ParserFromFile(string.Empty);
        //    Assert.IsNotNull(actual);

        //}
        [TestMethod]
        public void ParserFromFileTest19()
        {
            string textUser =
             @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CCS><CommentArea></CommentArea><BookmarkArea></BookmarkArea><LogArea TotalLine='15883'>
</LogArea></CCS></UserMemorizedLogData>";

            string filenameUser = string.Format("ParserFromFileTest19{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserOld();


            MemoLog<CCSLogRecord> actual = target.ParserFromFile(fileFullPath);
            Assert.AreEqual(0,actual.Records.Count);
            Assert.AreEqual(0, actual.Comments.Count);
            Assert.AreEqual(0, actual.Bookmarks.Count);
            File.Delete(fileFullPath);

        }
        [TestMethod]
        public void ParserFromFileTest()
        {
            string textUser =
             @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CCS><CommentArea><Comment Id='0' Line='3'>ab</Comment><Comment Id='1' Line='4'>ab</Comment></CommentArea><BookmarkArea><Bookmark Id='0' Line='1' /><Bookmark Id='1' Line='2' /><Bookmark Id='2' Line='4' /></BookmarkArea><LogArea TotalLine='15883'>
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

            string filenameUser = string.Format("ParserFromFileTest{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserOld();
            

            MemoLog<CCSLogRecord> actual = target.ParserFromFile(fileFullPath);
            Assert.IsNotNull(actual);
            File.Delete(fileFullPath);

        }
        [TestMethod]
        [ExpectedException(typeof(XmlException))]
        public void ParserFromFileTest2()
        {
            string textUser =
             @" version='1.0' encoding='utf-8'?orizedLogData><CCS><CommentArea><Comment Id='0' Line='3'>ab</Comment><Comment Id='1' Line='4'>ab</Comment></CommentArea><BookmarkArea><Bookmark Id='0' Line='1' /><Bookmark Id='1' Line='2' /><Bookmark Id='2' Line='4' /></BookmarkArea><LogArea TotalLine='9'>
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

            string filenameUser = string.Format("ParserFromFileTest2{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserOld();


            MemoLog<CCSLogRecord> actual = target.ParserFromFile(fileFullPath);
            var expected = 0;
            Assert.AreEqual(expected,actual.Records.Count);
            File.Delete(fileFullPath);

        }
        [TestMethod]
        public void ParserFromFileTest3()
        {
            string textUser =
             @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CCS><CommentArea><Comment Id='0' Line='3'>ab</Comment><Comment Id='1' Line='4'>ab</Comment></CommentArea><BookmarkArea><Bookmark Id='0' Line='1' /><Bookmark Id='1' Line='2' /><Bookmark Id='2' Line='4' /></BookmarkArea><LogArea TotalLine='9'>
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

            string filenameUser = string.Format("a{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserOld();

            MemoLog<CCSLogRecord> actual = target.ParserFromFile(fileFullPath);
            var expected = 9;
            Assert.AreEqual(expected, actual.Records.Count);
            File.Delete(fileFullPath);

        }
        public ReadOnlyCollection<CCSLogRecord> bookMarks(List<CCSLogRecord> ls)
        {
            return new ReadOnlyCollection<CCSLogRecord>(ls);
        }
        public ReadOnlyCollection<CCSLogRecord> LogRecords(List<CCSLogRecord> ls)
        {
            return new ReadOnlyCollection<CCSLogRecord>(ls);
        }
#endregion
        [TestMethod]
        public void WriteMemoLogFileTest()
        {
            string filenameUser = string.Format("WriteMemoLogFileTest{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserOld();
            var actual = target.WriteMemoLogFile(fileFullPath);
            var expected = false;
            Assert.AreEqual(expected,actual);
            File.Delete(fileFullPath);

        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void WriteMemoLogFileTest1()
        {
            string filenameUser = string.Format("WriteMemoLogFileTest1{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);
            FileStream fs = File.OpenWrite(fileFullPath);
            var target = new CCSMemoParserOld();
            var record1 = new CCSLogRecord { Id = "30101001", ThreadId = "1", Type = "E" };
            var record2 = new CCSLogRecord { Id = "123123123", ThreadId = "2", Type = "E" };
            var record3 = new CCSLogRecord { Id = "22301010012222", ThreadId = "3", Type = "N" };
            var record4 = new CCSLogRecord { Id = "10030101001", ThreadId = "4", Type = "I" };
            var record5 = new CCSLogRecord { Id = "30101001", ThreadId = "5", Type = "E" };
            
            var ls = new List<CCSLogRecord> {record1, record2, record3, record4, record5};
            target.LogRecords = LogRecords(ls);
            target.Comments = new Dictionary<CCSLogRecord, string>();
            target.Comments.Add(record1,"abc");
            target.Bookmarks = bookMarks(new List<CCSLogRecord>());
            var actual = target.WriteMemoLogFile(fileFullPath);
            var expected = true;
            Assert.AreEqual(expected, actual);
            fs.Close();
            File.Delete(fileFullPath);

        }
        [TestMethod]
        public void WriteMemoLogFileTest2()
        {
            string filenameUser = string.Format("WriteMemoLogFileTest2{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserOld();
            var record1 = new CCSLogRecord { Id = "30101001", ThreadId = "1", Type = "E",DateTime = DateTime.Parse("2010/10/10 10:10:10.100"),Line = 1,Content = "abc",HostName = "aaaa",AdditionalInfo = "jfdosaf",Module = "jfodsa",Mode = "a",ClassName = "fdsao",PersonalInfo = "fdsaojfodsa"};
            var record2 = new CCSLogRecord { Id = "30101001", ThreadId = "1", Type = "E", DateTime = DateTime.Parse("2010/10/10 10:10:10.100"), Line = 1, Content = "abc", HostName = "aaaa", AdditionalInfo = "jfdosaf",  Module = "jfodsa", Mode = "a", ClassName = "fdsao", PersonalInfo = "jfdsaofjdso" };
            var record3 = new CCSLogRecord { Id = "30101001", ThreadId = "1", Type = "E", DateTime = DateTime.Parse("2010/10/10 10:10:10.100"), Line = 1, Content = "abc", HostName = "aaaa", AdditionalInfo = "jfdosaf", Module = "jfodsa", Mode = "a", ClassName = "fdsao", PersonalInfo = "jfdsaofjdso" };
            var record4 = new CCSLogRecord { Id = "30101001", ThreadId = "1", Type = "E", DateTime = DateTime.Parse("2010/10/10 10:10:10.100"), Line = 1, Content = "abc", HostName = "aaaa", AdditionalInfo = "jfdosaf", Module = "jfodsa", Mode = "a", ClassName = "fdsao",  PersonalInfo = "jfdsaofjdso" };
            var record5 = new CCSLogRecord { Id = "30101001", ThreadId = "1", Type = "E", DateTime = DateTime.Parse("2010/10/10 10:10:10.100"), Line = 1, Content = "abc", HostName = "aaaa", AdditionalInfo = "jfdosaf",  Module = "jfodsa", Mode = "a", ClassName = "fdsao",  PersonalInfo = "jfdsaofjdso" };

            var ls = new List<CCSLogRecord> { record1, record2, record3, record4, record5 };
            target.LogRecords = LogRecords(ls);
            target.Comments = new Dictionary<CCSLogRecord, string>();
            target.Comments.Add(record1, "abc");
            target.Bookmarks = bookMarks(new List<CCSLogRecord>());
            var actual = target.WriteMemoLogFile(fileFullPath);
            var expected = true;
            Assert.AreEqual(expected, actual);
            File.Delete(fileFullPath);

        }
        [TestMethod]
        public void WriteMemoLogFileTest3()
        {
            string filenameUser = string.Format("WriteMemoLogFileTest3{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CCSMemoParserOld();
            var record1 = new CCSLogRecord { Id = "30101001", ThreadId = "1", Type = "E", DateTime = DateTime.Parse("2010/10/10 10:10:10.100"), Line = 1, Content = "abc", HostName = "aaaa", AdditionalInfo = "jfdosaf", Module = "jfodsa", Mode = "a", ClassName = "fdsao", PersonalInfo = "fdsaojfodsa" };
            var record2 = new CCSLogRecord { Id = "30101001", ThreadId = "1", Type = "E", DateTime = DateTime.Parse("2010/10/10 10:10:10.100"), Line = 1, Content = "abc", HostName = "aaaa", AdditionalInfo = "jfdosaf", Module = "jfodsa", Mode = "a", ClassName = "fdsao", PersonalInfo = "jfdsaofjdso" };
            var record3 = new CCSLogRecord { Id = "30101001", ThreadId = "1", Type = "E", DateTime = DateTime.Parse("2010/10/10 10:10:10.100"), Line = 1, Content = "abc", HostName = "aaaa", AdditionalInfo = "jfdosaf", Module = "jfodsa", Mode = "a", ClassName = "fdsao", PersonalInfo = "jfdsaofjdso" };
            var record4 = new CCSLogRecord { Id = "30101001", ThreadId = "1", Type = "E", DateTime = DateTime.Parse("2010/10/10 10:10:10.100"), Line = 1, Content = "abc", HostName = "aaaa", AdditionalInfo = "jfdosaf", Module = "jfodsa", Mode = "a", ClassName = "fdsao", PersonalInfo = "jfdsaofjdso" };
            var record5 = new CCSLogRecord { Id = "30101001", ThreadId = "1", Type = "E", DateTime = DateTime.Parse("2010/10/10 10:10:10.100"), Line = 1, Content = "abc", HostName = "aaaa", AdditionalInfo = "jfdosaf", Module = "jfodsa", Mode = "a", ClassName = "fdsao", PersonalInfo = "jfdsaofjdso" };

            var ls = new List<CCSLogRecord> { record1, record2, record3, record4, record5 };
            target.LogRecords = LogRecords(ls);
            target.Comments = new Dictionary<CCSLogRecord, string>();
            target.Comments.Add(record1, "abc");
            target.Bookmarks = bookMarks(new List<CCSLogRecord>{record2});
            
            var actual = target.WriteMemoLogFile(fileFullPath);
            var expected = true;
            Assert.AreEqual(expected, actual);
            File.Delete(fileFullPath);

        }
    }
}
