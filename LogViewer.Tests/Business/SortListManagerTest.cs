using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using LogViewer.Business;
using LogViewer.Model;
using LogViewer.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.Business
{
    [TestClass]
    public class SortListManagerTest
    {
        [TestMethod]
        public void SortByFileTest()
        {
            var sl = new SortLogListManager<CCSLogRecord>();
            var po = new PrivateObject(sl);
            var dictionary = new Dictionary<string, List<CCSLogRecord>>();
            var record1 = new CCSLogRecord{ DateTime= DateTime.Parse("2014/10/09 10:10:10.100")};
            var record2 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/10 10:10:10.100") };
            var record3 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record4 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            dictionary.Add("file1", new List<CCSLogRecord> { record1, record2, record3, record4 });

            List<CCSLogRecord> sortedList = (List<CCSLogRecord>)po.Invoke("SortByFile", dictionary);
            
            Assert.AreEqual(record1,sortedList[0]);
            Assert.AreEqual(record2, sortedList[1]);
            Assert.AreEqual(record3, sortedList[2]);
            Assert.AreEqual(record4, sortedList[3]);
        }
        [TestMethod]
        public void SortByFileTestFalse()
        {
            var sl = new SortLogListManager<CCSLogRecord>();
            var po = new PrivateObject(sl);
            var dictionary = new Dictionary<string, List<CCSLogRecord>>();
            var record1 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/10 10:10:10.100") };
            var record3 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record4 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            dictionary.Add("file1", new List<CCSLogRecord> { record1, record2, record3, record4 });

            List<CCSLogRecord> sortedList = (List<CCSLogRecord>)po.Invoke("SortByFile", dictionary);

            Assert.AreNotEqual(record2, sortedList[0]);
            Assert.AreNotEqual(record3, sortedList[1]);
            Assert.AreNotEqual(record4, sortedList[2]);
            Assert.AreNotEqual(record1, sortedList[3]);
        }
        [TestMethod]
        public void SortByFileTestFalse1()
        {
            var sl = new SortLogListManager<CCSLogRecord>();
            var po = new PrivateObject(sl);
            var dictionary = new Dictionary<string, List<CCSLogRecord>>();
            var record1 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/10 10:10:10.100") };
            var record3 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record4 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            dictionary.Add("file1", new List<CCSLogRecord> { record1, record2, record3, record4 });

            List<CCSLogRecord> sortedList = (List<CCSLogRecord>)po.Invoke("SortByFile", dictionary);

            Assert.AreNotEqual(record3, sortedList[0]);
            Assert.AreNotEqual(record4, sortedList[1]);
            Assert.AreNotEqual(record1, sortedList[2]);
            Assert.AreNotEqual(record2, sortedList[3]);
        }
        [TestMethod]
        public void SortByFileTestFalse2()
        {
            var sl = new SortLogListManager<CCSLogRecord>();
            var po = new PrivateObject(sl);
            var dictionary = new Dictionary<string, List<CCSLogRecord>>();
            var record1 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/10 10:10:10.100") };
            var record3 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record4 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            dictionary.Add("file1", new List<CCSLogRecord> { record1, record2, record3, record4 });

            List<CCSLogRecord> sortedList = (List<CCSLogRecord>)po.Invoke("SortByFile", dictionary);

            Assert.AreNotEqual(record4, sortedList[0]);
            Assert.AreNotEqual(record1, sortedList[1]);
            Assert.AreNotEqual(record2, sortedList[2]);
            Assert.AreNotEqual(record3, sortedList[3]);
        }

        [TestMethod]
        public void SortByFileTest1()
        {
            var sl = new SortLogListManager<CCSLogRecord>();
            var po = new PrivateObject(sl);
            var dictionary = new Dictionary<string, List<CCSLogRecord>>();
            var record1 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/10 10:10:10.100") };
            var record3 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record4 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            dictionary.Add("file1", new List<CCSLogRecord> { record1, record2, record3, record4 });

            var record5 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/10 10:10:10.100") };
            var record6 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/20 10:10:10.100") };
            var record7 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/22 10:10:10.100") };

            dictionary.Add("file2", new List<CCSLogRecord> { record5, record6, record7 });

            List<CCSLogRecord> sortedList = (List<CCSLogRecord>)po.Invoke("SortByFile", dictionary);

            Assert.AreEqual(record5, sortedList[0]);
            Assert.AreEqual(record6, sortedList[1]);
            Assert.AreEqual(record7, sortedList[2]);

            Assert.AreEqual(record1, sortedList[3]);
            Assert.AreEqual(record2, sortedList[4]);
            Assert.AreEqual(record3, sortedList[5]);
            Assert.AreEqual(record4, sortedList[6]);
        }
        [TestMethod]
        public void SortByFileTestFalse11()
        {
            var sl = new SortLogListManager<CCSLogRecord>();
            var po = new PrivateObject(sl);
            var dictionary = new Dictionary<string, List<CCSLogRecord>>();
            var record1 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/10 10:10:10.100") };
            var record3 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record4 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            dictionary.Add("file1", new List<CCSLogRecord> { record1, record2, record3, record4 });

            var record5 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/10 10:10:10.100") };
            var record6 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/20 10:10:10.100") };
            var record7 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/22 10:10:10.100") };

            dictionary.Add("file2", new List<CCSLogRecord> { record5, record6, record7 });

            List<CCSLogRecord> sortedList = (List<CCSLogRecord>)po.Invoke("SortByFile", dictionary);

            Assert.AreNotEqual(record6, sortedList[0]);
            Assert.AreNotEqual(record7, sortedList[1]);
            Assert.AreNotEqual(record5, sortedList[2]);

            Assert.AreEqual(record1, sortedList[3]);
            Assert.AreEqual(record2, sortedList[4]);
            Assert.AreEqual(record3, sortedList[5]);
            Assert.AreEqual(record4, sortedList[6]);
        }
        [TestMethod]
        public void SortByFileTestFalse12()
        {
            var sl = new SortLogListManager<CCSLogRecord>();
            var po = new PrivateObject(sl);
            var dictionary = new Dictionary<string, List<CCSLogRecord>>();
            var record1 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/10 10:10:10.100") };
            var record3 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record4 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            dictionary.Add("file1", new List<CCSLogRecord> { record1, record2, record3, record4 });

            var record5 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/10 10:10:10.100") };
            var record6 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/20 10:10:10.100") };
            var record7 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/22 10:10:10.100") };

            dictionary.Add("file2", new List<CCSLogRecord> { record5, record6, record7 });

            List<CCSLogRecord> sortedList = (List<CCSLogRecord>)po.Invoke("SortByFile", dictionary);

            Assert.AreNotEqual(record7, sortedList[0]);
            Assert.AreNotEqual(record5, sortedList[1]);
            Assert.AreNotEqual(record6, sortedList[2]);

            Assert.AreEqual(record1, sortedList[3]);
            Assert.AreEqual(record2, sortedList[4]);
            Assert.AreEqual(record3, sortedList[5]);
            Assert.AreEqual(record4, sortedList[6]);
        }
        [TestMethod]
        public void SortByFileTestFalse13()
        {
            var sl = new SortLogListManager<CCSLogRecord>();
            var po = new PrivateObject(sl);
            var dictionary = new Dictionary<string, List<CCSLogRecord>>();
            var record1 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/10 10:10:10.100") };
            var record3 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record4 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            dictionary.Add("file1", new List<CCSLogRecord> { record1, record2, record3, record4 });

            var record5 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/10 10:10:10.100") };
            var record6 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/20 10:10:10.100") };
            var record7 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/22 10:10:10.100") };

            dictionary.Add("file2", new List<CCSLogRecord> { record5, record6, record7 });

            List<CCSLogRecord> sortedList = (List<CCSLogRecord>)po.Invoke("SortByFile", dictionary);

            Assert.AreNotEqual(record6, sortedList[0]);
            Assert.AreNotEqual(record7, sortedList[1]);
            Assert.AreNotEqual(record5, sortedList[2]);

            Assert.AreEqual(record1, sortedList[3]);
            Assert.AreEqual(record2, sortedList[4]);
            Assert.AreEqual(record3, sortedList[5]);
            Assert.AreEqual(record4, sortedList[6]);
        }

        [TestMethod]
        public void SortByFileTest2()
        {
            var sl = new SortLogListManager<CCSLogRecord>();
            var po = new PrivateObject(sl);
            var dictionary = new Dictionary<string, List<CCSLogRecord>>();

            List<CCSLogRecord> sortedList = (List<CCSLogRecord>)po.Invoke("SortByFile", dictionary);
            int expected = 0;
            Assert.AreEqual(expected, sortedList.Count);
        }

        [TestMethod]
        public void SortAllRecordTest1()
        {
            var sl = new SortLogListManager<CCSLogRecord>();
            var po = new PrivateType(sl.GetType());
            var dictionary = new Dictionary<string, List<CCSLogRecord>>();
            var record1 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/10 10:10:10.100") };
            var record3 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record4 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            dictionary.Add("file1", new List<CCSLogRecord> { record1, record2, record3, record4 });

            var record5 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/10 10:10:10.100") };
            var record6 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/20 10:10:10.100") };
            var record7 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/22 10:10:10.100") };

            dictionary.Add("file2", new List<CCSLogRecord> { record5, record6, record7 });

            List<CCSLogRecord> sortedList = (List<CCSLogRecord>)po.InvokeStatic("SortAllRecord", dictionary);

            Assert.AreEqual(record5, sortedList[0]);
            Assert.AreEqual(record6, sortedList[1]);
            Assert.AreEqual(record7, sortedList[2]);

            Assert.AreEqual(record1, sortedList[3]);
            Assert.AreEqual(record2, sortedList[4]);
            Assert.AreEqual(record3, sortedList[5]);
            Assert.AreEqual(record4, sortedList[6]);
        }
        [TestMethod]
        public void SortAllRecordTest2()
        {
            var sl = new SortLogListManager<CCSLogRecord>();
            var po = new PrivateType(sl.GetType());
            var dictionary = new Dictionary<string, List<CCSLogRecord>>();
            var record1 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/10 10:10:10.100") };
            var record3 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record4 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            dictionary.Add("file1", new List<CCSLogRecord> { record1, record2, record3, record4 });

            //var record5 = new CCSLogRecord { Date = "2014/09/10 10:10:10.100") };
            //var record6 = new CCSLogRecord { Date = "2014/09/20 10:10:10.100") };
            //var record7 = new CCSLogRecord { Date = "2014/09/22 10:10:10.100") };

            //dictionary.Add("file2", new List<CCSLogRecord> { record5, record6, record7 });

            List<CCSLogRecord> sortedList = (List<CCSLogRecord>)po.InvokeStatic("SortAllRecord", dictionary);

            //Assert.AreEqual(record5, sortedList[0]);
            //Assert.AreEqual(record6, sortedList[1]);
            //Assert.AreEqual(record7, sortedList[2]);

            Assert.AreEqual(record1, sortedList[0]);
            Assert.AreEqual(record2, sortedList[1]);
            Assert.AreEqual(record3, sortedList[2]);
            Assert.AreEqual(record4, sortedList[3]);
        }
        [TestMethod]
        public void SortAllRecordTest3()
        {
            var sl = new SortLogListManager<CCSLogRecord>();
            var po = new PrivateType(sl.GetType());
            var dictionary = new Dictionary<string, List<CCSLogRecord>>();
            var record4 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/10 10:10:10.100") };
            var record1 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record3 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            dictionary.Add("file1", new List<CCSLogRecord> { record1, record2, record3, record4 });

            //var record5 = new CCSLogRecord { Date = "2014/09/10 10:10:10.100") };
            //var record6 = new CCSLogRecord { Date = "2014/09/20 10:10:10.100") };
            //var record7 = new CCSLogRecord { Date = "2014/09/22 10:10:10.100") };

            //dictionary.Add("file2", new List<CCSLogRecord> { record5, record6, record7 });

            List<CCSLogRecord> sortedList = (List<CCSLogRecord>)po.InvokeStatic("SortAllRecord", dictionary);

            //Assert.AreEqual(record5, sortedList[0]);
            //Assert.AreEqual(record6, sortedList[1]);
            //Assert.AreEqual(record7, sortedList[2]);

            Assert.AreEqual(record4, sortedList[0]);
            Assert.AreEqual(record2, sortedList[1]);
            Assert.AreEqual(record1, sortedList[2]);
            Assert.AreEqual(record3, sortedList[3]);
        }
        [TestMethod]
        public void SortAllRecordTest4()
        {
            var sl = new SortLogListManager<CCSLogRecord>();
            var po = new PrivateType(sl.GetType());
            var dictionary = new Dictionary<string, List<CCSLogRecord>>();
            var record4 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/10 10:10:10.100") };
            var record1 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record3 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            dictionary.Add("file1", new List<CCSLogRecord> { record1, record2, record3, record4 });

            var record5 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/10 10:10:10.100") };
            var record6 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/20 10:10:10.100") };
            var record7 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/22 10:10:10.100") };

            dictionary.Add("file2", new List<CCSLogRecord> { record5, record6, record7 });

            List<CCSLogRecord> sortedList = (List<CCSLogRecord>)po.InvokeStatic("SortAllRecord", dictionary);

            Assert.AreEqual(record5, sortedList[0]);
            Assert.AreEqual(record6, sortedList[1]);
            Assert.AreEqual(record7, sortedList[2]);

            Assert.AreEqual(record4, sortedList[3]);
            Assert.AreEqual(record2, sortedList[4]);
            Assert.AreEqual(record1, sortedList[5]);
            Assert.AreEqual(record3, sortedList[6]);
        }
        [TestMethod]
        public void SortAllRecordTest5()
        {
            var sl = new SortLogListManager<CCSLogRecord>();
            var po = new PrivateType(sl.GetType());
            var dictionary = new Dictionary<string, List<CCSLogRecord>>();
            var record4 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100"),Line = 2};
            var record2 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100") ,Line = 1};
            var record1 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record3 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            dictionary.Add("file1", new List<CCSLogRecord> { record1, record2, record3, record4 });

            var record5 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/10 10:10:10.100") };
            var record6 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/20 10:10:10.100") };
            var record7 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/22 10:10:10.100") };

            dictionary.Add("file2", new List<CCSLogRecord> { record5, record6, record7 });

            List<CCSLogRecord> sortedList = (List<CCSLogRecord>)po.InvokeStatic("SortAllRecord", dictionary);

            Assert.AreEqual(record5, sortedList[0]);
            Assert.AreEqual(record6, sortedList[1]);
            Assert.AreEqual(record7, sortedList[2]);

            Assert.AreEqual(record2, sortedList[3]);
            Assert.AreEqual(record4, sortedList[4]);
            Assert.AreEqual(record1, sortedList[5]);
            Assert.AreEqual(record3, sortedList[6]);
        }
        [TestMethod]
        public void SortAllRecordTest6()
        {
            var sl = new SortLogListManager<CCSLogRecord>();
            var po = new PrivateType(sl.GetType());
            var record4 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100"), Line = 2 };
            var record2 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100"), Line = 1 };
            var record1 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record3 = new CCSLogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            var record5 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/10 10:10:10.100") };
            var record6 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/20 10:10:10.100") };
            var record7 = new CCSLogRecord { DateTime= DateTime.Parse("2014/09/22 10:10:10.100") };

            var list = new List<CCSLogRecord>{record1,record2,record3,record4,record5,record6,record7};

            List<CCSLogRecord> sortedList = (List<CCSLogRecord>)po.InvokeStatic("SortAllRecord", list);

            Assert.AreEqual(record5, sortedList[0]);
            Assert.AreEqual(record6, sortedList[1]);
            Assert.AreEqual(record7, sortedList[2]);

            Assert.AreEqual(record2, sortedList[3]);
            Assert.AreEqual(record4, sortedList[4]);
            Assert.AreEqual(record1, sortedList[5]);
            Assert.AreEqual(record3, sortedList[6]);
        }


        /////

        [TestMethod]
        public void SortByFileTest7()
        {
            var sl = new SortLogListManager<CXDILogRecord>();
            var po = new PrivateObject(sl);
            var dictionary = new Dictionary<string, List<CXDILogRecord>>();
            var record1 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/10 10:10:10.100") };
            var record3 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record4 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            dictionary.Add("file1", new List<CXDILogRecord> { record1, record2, record3, record4 });

            var sortedList = (List<CXDILogRecord>)po.Invoke("SortByFile", dictionary);

            Assert.AreEqual(record1, sortedList[0]);
            Assert.AreEqual(record2, sortedList[1]);
            Assert.AreEqual(record3, sortedList[2]);
            Assert.AreEqual(record4, sortedList[3]);
        }
        [TestMethod]
        public void SortByFileTest8()
        {
            var sl = new SortLogListManager<CXDILogRecord>();
            var po = new PrivateObject(sl);
            var dictionary = new Dictionary<string, List<CXDILogRecord>>();
            var record1 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/10 10:10:10.100") };
            var record3 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record4 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            dictionary.Add("file1", new List<CXDILogRecord> { record1, record2, record3, record4 });

            var record5 = new CXDILogRecord { DateTime= DateTime.Parse("2014/09/10 10:10:10.100") };
            var record6 = new CXDILogRecord { DateTime= DateTime.Parse("2014/09/20 10:10:10.100") };
            var record7 = new CXDILogRecord { DateTime= DateTime.Parse("2014/09/22 10:10:10.100") };

            dictionary.Add("file2", new List<CXDILogRecord> { record5, record6, record7 });

            var sortedList = (List<CXDILogRecord>)po.Invoke("SortByFile", dictionary);

            Assert.AreEqual(record5, sortedList[0]);
            Assert.AreEqual(record6, sortedList[1]);
            Assert.AreEqual(record7, sortedList[2]);

            Assert.AreEqual(record1, sortedList[3]);
            Assert.AreEqual(record2, sortedList[4]);
            Assert.AreEqual(record3, sortedList[5]);
            Assert.AreEqual(record4, sortedList[6]);
        }
        [TestMethod]
        public void SortByFileTest9()
        {
            var sl = new SortLogListManager<CXDILogRecord>();
            var po = new PrivateObject(sl);
            var dictionary = new Dictionary<string, List<CXDILogRecord>>();

            var sortedList = (List<CXDILogRecord>)po.Invoke("SortByFile", dictionary);
            int expected = 0;
            Assert.AreEqual(expected, sortedList.Count);
        }

        [TestMethod]
        public void SortAllRecordTest10()
        {
            var sl = new SortLogListManager<CXDILogRecord>();
            var po = new PrivateType(sl.GetType());
            var dictionary = new Dictionary<string, List<CXDILogRecord>>();
            var record1 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/10 10:10:10.100") };
            var record3 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record4 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            dictionary.Add("file1", new List<CXDILogRecord> { record1, record2, record3, record4 });

            var record5 = new CXDILogRecord { DateTime= DateTime.Parse("2014/09/10 10:10:10.100") };
            var record6 = new CXDILogRecord { DateTime= DateTime.Parse("2014/09/20 10:10:10.100") };
            var record7 = new CXDILogRecord { DateTime= DateTime.Parse("2014/09/22 10:10:10.100") };

            dictionary.Add("file2", new List<CXDILogRecord> { record5, record6, record7 });

            List<CXDILogRecord> sortedList = (List<CXDILogRecord>)po.InvokeStatic("SortAllRecord", dictionary);

            Assert.AreEqual(record5, sortedList[0]);
            Assert.AreEqual(record6, sortedList[1]);
            Assert.AreEqual(record7, sortedList[2]);

            Assert.AreEqual(record1, sortedList[3]);
            Assert.AreEqual(record2, sortedList[4]);
            Assert.AreEqual(record3, sortedList[5]);
            Assert.AreEqual(record4, sortedList[6]);
        }
        [TestMethod]
        public void SortAllRecordTest11()
        {
            var sl = new SortLogListManager<CXDILogRecord>();
            var po = new PrivateType(sl.GetType());
            var dictionary = new Dictionary<string, List<CXDILogRecord>>();
            var record1 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/10 10:10:10.100") };
            var record3 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record4 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            dictionary.Add("file1", new List<CXDILogRecord> { record1, record2, record3, record4 });

            //var record5 = new CCSLogRecord { Date = "2014/09/10 10:10:10.100") };
            //var record6 = new CCSLogRecord { Date = "2014/09/20 10:10:10.100") };
            //var record7 = new CCSLogRecord { Date = "2014/09/22 10:10:10.100") };

            //dictionary.Add("file2", new List<CCSLogRecord> { record5, record6, record7 });

            List<CXDILogRecord> sortedList = (List<CXDILogRecord>)po.InvokeStatic("SortAllRecord", dictionary);

            //Assert.AreEqual(record5, sortedList[0]);
            //Assert.AreEqual(record6, sortedList[1]);
            //Assert.AreEqual(record7, sortedList[2]);

            Assert.AreEqual(record1, sortedList[0]);
            Assert.AreEqual(record2, sortedList[1]);
            Assert.AreEqual(record3, sortedList[2]);
            Assert.AreEqual(record4, sortedList[3]);
        }
        [TestMethod]
        public void SortAllRecordTest13()
        {
            var sl = new SortLogListManager<CXDILogRecord>();
            var po = new PrivateType(sl.GetType());
            var dictionary = new Dictionary<string, List<CXDILogRecord>>();
            var record4 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/10 10:10:10.100") };
            var record1 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record3 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            dictionary.Add("file1", new List<CXDILogRecord> { record1, record2, record3, record4 });

            //var record5 = new CCSLogRecord { Date = "2014/09/10 10:10:10.100") };
            //var record6 = new CCSLogRecord { Date = "2014/09/20 10:10:10.100") };
            //var record7 = new CCSLogRecord { Date = "2014/09/22 10:10:10.100") };

            //dictionary.Add("file2", new List<CCSLogRecord> { record5, record6, record7 });

            List<CXDILogRecord> sortedList = (List<CXDILogRecord>)po.InvokeStatic("SortAllRecord", dictionary);

            //Assert.AreEqual(record5, sortedList[0]);
            //Assert.AreEqual(record6, sortedList[1]);
            //Assert.AreEqual(record7, sortedList[2]);

            Assert.AreEqual(record4, sortedList[0]);
            Assert.AreEqual(record2, sortedList[1]);
            Assert.AreEqual(record1, sortedList[2]);
            Assert.AreEqual(record3, sortedList[3]);
        }
        [TestMethod]
        public void SortAllRecordTest14()
        {
            var sl = new SortLogListManager<CXDILogRecord>();
            var po = new PrivateType(sl.GetType());
            var dictionary = new Dictionary<string, List<CXDILogRecord>>();
            var record4 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100") };
            var record2 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/10 10:10:10.100") };
            var record1 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record3 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            dictionary.Add("file1", new List<CXDILogRecord> { record1, record2, record3, record4 });

            var record5 = new CXDILogRecord { DateTime= DateTime.Parse("2014/09/10 10:10:10.100") };
            var record6 = new CXDILogRecord { DateTime= DateTime.Parse("2014/09/20 10:10:10.100") };
            var record7 = new CXDILogRecord { DateTime= DateTime.Parse("2014/09/22 10:10:10.100") };

            dictionary.Add("file2", new List<CXDILogRecord> { record5, record6, record7 });

            List<CXDILogRecord> sortedList = (List<CXDILogRecord>)po.InvokeStatic("SortAllRecord", dictionary);

            Assert.AreEqual(record5, sortedList[0]);
            Assert.AreEqual(record6, sortedList[1]);
            Assert.AreEqual(record7, sortedList[2]);

            Assert.AreEqual(record4, sortedList[3]);
            Assert.AreEqual(record2, sortedList[4]);
            Assert.AreEqual(record1, sortedList[5]);
            Assert.AreEqual(record3, sortedList[6]);
        }
        [TestMethod]
        public void SortAllRecordTest15()
        {
            var sl = new SortLogListManager<CXDILogRecord>();
            var po = new PrivateType(sl.GetType());
            var dictionary = new Dictionary<string, List<CXDILogRecord>>();
            var record4 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100"), Line = 2 };
            var record2 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100"), Line = 1 };
            var record1 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record3 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            dictionary.Add("file1", new List<CXDILogRecord> { record1, record2, record3, record4 });

            var record5 = new CXDILogRecord { DateTime= DateTime.Parse("2014/09/10 10:10:10.100") };
            var record6 = new CXDILogRecord { DateTime= DateTime.Parse("2014/09/20 10:10:10.100") };
            var record7 = new CXDILogRecord { DateTime= DateTime.Parse("2014/09/22 10:10:10.100") };

            dictionary.Add("file2", new List<CXDILogRecord> { record5, record6, record7 });

            List<CXDILogRecord> sortedList = (List<CXDILogRecord>)po.InvokeStatic("SortAllRecord", dictionary);

            Assert.AreEqual(record5, sortedList[0]);
            Assert.AreEqual(record6, sortedList[1]);
            Assert.AreEqual(record7, sortedList[2]);

            Assert.AreEqual(record2, sortedList[3]);
            Assert.AreEqual(record4, sortedList[4]);
            Assert.AreEqual(record1, sortedList[5]);
            Assert.AreEqual(record3, sortedList[6]);
        }
        [TestMethod]
        public void SortAllRecordTest16()
        {
            var sl = new SortLogListManager<CXDILogRecord>();
            var po = new PrivateType(sl.GetType());
            var record4 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100"), Line = 2 };
            var record2 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/09 10:10:10.100"), Line = 1 };
            var record1 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/20 10:10:10.100") };
            var record3 = new CXDILogRecord { DateTime= DateTime.Parse("2014/10/22 10:10:10.100") };
            var record5 = new CXDILogRecord { DateTime= DateTime.Parse("2014/09/10 10:10:10.100") };
            var record6 = new CXDILogRecord { DateTime= DateTime.Parse("2014/09/20 10:10:10.100") };
            var record7 = new CXDILogRecord { DateTime= DateTime.Parse("2014/09/22 10:10:10.100") };

            var list = new List<CXDILogRecord> { record1, record2, record3, record4, record5, record6, record7 };

            List<CXDILogRecord> sortedList = (List<CXDILogRecord>)po.InvokeStatic("SortAllRecord", list);

            Assert.AreEqual(record5, sortedList[0]);
            Assert.AreEqual(record6, sortedList[1]);
            Assert.AreEqual(record7, sortedList[2]);

            Assert.AreEqual(record2, sortedList[3]);
            Assert.AreEqual(record4, sortedList[4]);
            Assert.AreEqual(record1, sortedList[5]);
            Assert.AreEqual(record3, sortedList[6]);
        }


    }
}
