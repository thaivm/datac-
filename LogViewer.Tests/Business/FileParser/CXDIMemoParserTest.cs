using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using LogViewer.Business.FileParser;
using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.Business.FileParser
{
    [TestClass]
    public class CXDIMemoParserTest
    {


        [TestMethod]
        public void ParserFromMemoFileTest()
        {
            string textUser = 
                         @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CXDI><CommentArea /><BookmarkArea><Bookmark Id='0' Line='3' /><Bookmark Id='1' Line='4' /><Bookmark Id='2' Line='5' /></BookmarkArea><LogArea TotalLine='58281'>--------[counter parameter]--------startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------
[2013/09/11 09:54:05.433][Mod=100]:exit status S_ExpReady
[2013/09/11 09:54:05.434][Mod=107]:Led Ready:ON,Priority:-1[msec]
[2013/09/11 09:54:05.434][Mod=102]:StateNotifySet. systemState:0xb0
[2013/09/11 09:54:05.434][Mod=100]:Status = S_EXPOSING
[2013/09/11 09:54:05.434][Mod=100]:entry status S_Exposing
[2013/09/11 09:54:05.434][Mod=106]:BatteryMgr:Stop.
[2013/09/11 09:54:05.434][Mod=105]:TempMgr:Stop.
[2013/09/11 09:54:05.437][Mod=103]:XIF:Resp Data:GRANT_OK
</LogArea></CXDI></UserMemorizedLogData>";

            string filenameUser = string.Format("ParserFromMemoFileTest{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CXDIMemoParser();


            MemoLog<CXDILogRecord> actual = target.ParserFromFile(fileFullPath);
            var expected = 5;
            Assert.IsNotNull(actual);
            File.Delete(fileFullPath);
        }


        [TestMethod]
        public void ParserFromMemoFileTest1()
        {
            string textUser =
                         @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CXDI><CommentArea /><BookmarkArea><Bookmark Id='0' Line='3' /><Bookmark Id='1' Line='4' /><Bookmark Id='2' Line='5' /></BookmarkArea><LogArea TotalLine='58281'>--------[counter parameter]--------startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------
[2013/09/11 09:54:05.433][Mod=100]:exit status S_ExpReady
[2013/09/11 09:54:05.434][Mod=107]:Led Ready:ON,Priority:-1[msec]
[2013/09/11 09:54:05.434][Mod=102]:StateNotifySet. systemState:0xb0
[2013/09/11 09:54:05.434][Mod=100]:Status = S_EXPOSING
[2013/09/11 09:54:05.434][Mod=100]:entry status S_Exposing
[2013/09/11 09:54:05.434][Mod=106]:BatteryMgr:Stop.
[2013/09/11 09:54:05.434][Mod=105]:TempMgr:Stop.
[2013/09/11 09:54:05.437][Mod=103]:XIF:Resp Data:GRANT_OK
</LogArea></CXDI></UserMemorizedLogData>";

            string filenameUser = string.Format("ParserFromMemoFileTest1{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CXDIMemoParser();


            MemoLog<CXDILogRecord> actual = target.ParserFromFile(fileFullPath);
            var expected = 8;
            Assert.AreEqual(expected,actual.Records.Count);
            File.Delete(fileFullPath);
        }
        [TestMethod]
        public void ParserFromMemoFileTest3()
        {
            string textUser =
                         @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CXDI><CommentArea /><BookmarkArea><Bookmark Id='0' Line='3' /><Bookmark Id='1' Line='4' /><Bookmark Id='2' Line='5' /></BookmarkArea><LogArea TotalLine='58281'>--------[counter parameter]--------startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------
[2013/09/11 09:54:05.433][Mod=100]:exit status S_ExpReady
[2013/09/11 09:54:05.434][Mod=107]:Led Ready:ON,Priority:-1[msec]
[2013/09/11 09:54:05.434][Mod=102]:StateNotifySet. systemState:0xb0
[2013/09/11 09:54:05.434][Mod=100]:Status = S_EXPOSING
[2013/09/11 09:54:05.434][Mod=100]:entry status S_Exposing
[2013/09/11 09:54:05.434][Mod=106]:BatteryMgr:Stop.
[2013/09/11 09:54:05.434][Mod=105]:TempMgr:Stop.
[2013/09/11 09:54:05.437][Mod=103]:XIF:Resp Data:GRANT_OK
</LogArea></CXDI></UserMemorizedLogData>";

            string filenameUser = string.Format("ParserFromMemoFileTest3{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CXDIMemoParser();


            MemoLog<CXDILogRecord> actual = target.ParserFromFile(fileFullPath);
            var expected = 0;
            Assert.AreEqual(expected, actual.Comments.Count);
            File.Delete(fileFullPath);
        }
        [TestMethod]
        public void ParserFromMemoFileTest4()
        {
            string textUser =
                         @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CXDI><CommentArea /><BookmarkArea><Bookmark Id='0' Line='3' /><Bookmark Id='1' Line='4' /><Bookmark Id='2' Line='5' /></BookmarkArea><LogArea TotalLine='58281'>--------[counter parameter]--------startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------
[2013/09/11 09:54:05.433][Mod=100]:exit status S_ExpReady
[2013/09/11 09:54:05.434][Mod=107]:Led Ready:ON,Priority:-1[msec]
[2013/09/11 09:54:05.434][Mod=102]:StateNotifySet. systemState:0xb0
[2013/09/11 09:54:05.434][Mod=100]:Status = S_EXPOSING
[2013/09/11 09:54:05.434][Mod=100]:entry status S_Exposing
[2013/09/11 09:54:05.434][Mod=106]:BatteryMgr:Stop.
[2013/09/11 09:54:05.434][Mod=105]:TempMgr:Stop.
[2013/09/11 09:54:05.437][Mod=103]:XIF:Resp Data:GRANT_OK
</LogArea></CXDI></UserMemorizedLogData>";

            string filenameUser = string.Format("ParserFromMemoFileTest4{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CXDIMemoParser();


            MemoLog<CXDILogRecord> actual = target.ParserFromFile(fileFullPath);
            var expected = 3;
            Assert.AreEqual(expected, actual.Bookmarks.Count);
            File.Delete(fileFullPath);
        }
        [TestMethod]
        public void ParserFromMemoFileTest5()
        {
            string textUser =
                         @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CXDI><CommentArea><Comment Id='0' Line='1'>abc</Comment><Comment Id='1' Line='2'>agb</Comment><Comment Id='2' Line='3'>ab</Comment></CommentArea><BookmarkArea><Bookmark Id='0' Line='3' /><Bookmark Id='1' Line='4' /><Bookmark Id='2' Line='5' /></BookmarkArea><LogArea TotalLine='58281'>--------[counter parameter]--------startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------
[2013/09/11 09:54:05.433][Mod=100]:exit status S_ExpReady
[2013/09/11 09:54:05.434][Mod=107]:Led Ready:ON,Priority:-1[msec]
[2013/09/11 09:54:05.434][Mod=102]:StateNotifySet. systemState:0xb0
[2013/09/11 09:54:05.434][Mod=100]:Status = S_EXPOSING
[2013/09/11 09:54:05.434][Mod=100]:entry status S_Exposing
[2013/09/11 09:54:05.434][Mod=106]:BatteryMgr:Stop.
[2013/09/11 09:54:05.434][Mod=105]:TempMgr:Stop.
[2013/09/11 09:54:05.437][Mod=103]:XIF:Resp Data:GRANT_OK
</LogArea></CXDI></UserMemorizedLogData>";

            string filenameUser = string.Format("ParserFromMemoFileTest5{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CXDIMemoParser();


            MemoLog<CXDILogRecord> actual = target.ParserFromFile(fileFullPath);
            var expected = 3;
            Assert.AreEqual(expected, actual.Comments.Count);
            File.Delete(fileFullPath);
        }
        [TestMethod]
        public void ParserFromMemoFileTest6()
        {
            string textUser =
                         @"<?xml version='1.0' encoding='utf-8'?><UserMemorizedLogData><CXDI><CommentArea><Comment Id='0' Line='1'>abc</Comment><Comment Id='1' Line='2'>agb</Comment><Comment Id='2' Line='3'>ab</Comment></CommentArea><BookmarkArea></BookmarkArea><LogArea TotalLine='58281'>--------[counter parameter]--------startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[saved parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
EtherIpAddress:192.168.100.254
Wireless IpAddress:192.168.100.12
staticImageShootCount:8777
startCount:1523
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------
[2013/09/11 09:54:05.433][Mod=100]:exit status S_ExpReady
[2013/09/11 09:54:05.434][Mod=107]:Led Ready:ON,Priority:-1[msec]
[2013/09/11 09:54:05.434][Mod=102]:StateNotifySet. systemState:0xb0
[2013/09/11 09:54:05.434][Mod=100]:Status = S_EXPOSING
[2013/09/11 09:54:05.434][Mod=100]:entry status S_Exposing
[2013/09/11 09:54:05.434][Mod=106]:BatteryMgr:Stop.
[2013/09/11 09:54:05.434][Mod=105]:TempMgr:Stop.
[2013/09/11 09:54:05.437][Mod=103]:XIF:Resp Data:GRANT_OK
</LogArea></CXDI></UserMemorizedLogData>";

            string filenameUser = string.Format("ParserFromMemoFileTest6{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            System.IO.File.WriteAllText(filenameUser, textUser);
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CXDIMemoParser();


            MemoLog<CXDILogRecord> actual = target.ParserFromFile(fileFullPath);
            var expected = 0;
            Assert.AreEqual(expected, actual.Bookmarks.Count);
            File.Delete(fileFullPath);
        }

        [TestMethod]
        public void WriteMemoLogTest1()
        {

            string filenameUser = string.Format("WriteMemoLogTest1{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CXDIMemoParser();
            var r1 = new CXDILogRecord
            {
                Line = 1,
                DateTime =DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "exit status S_ExpReady",
                Module = "100"
            };
            var r2 = new CXDILogRecord
            {
                Line = 1,
                DateTime =DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "Led Ready:ON,Priority:-1[msec]",
                Module = "107"
            };
            var r3 = new CXDILogRecord
            {
                Line = 1,
                DateTime =DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "StateNotifySet. systemState:0xb0",
                Module = "102"
            };
            var r4 = new CXDILogRecord
            {
                Line = 1,
                DateTime =DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "Status = S_EXPOSING",
                Module = "100"
            };
            var r5 = new CXDILogRecord
            {
                Line = 1,
                DateTime =DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "entry status S_Exposing",
                Module = "100"
            };
            var ls = new List<CXDILogRecord>{r1,r2,r3,r4,r5};
            target.LogRecords = logRecords(ls);
            target.FirmWare = new CXDIFirmware();
            var actual = target.WriteMemoLogFile(fileFullPath);

            var expected = true;
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);
        }
        public ReadOnlyCollection<CXDILogRecord> logRecords(List<CXDILogRecord> ls)
        {
            return new ReadOnlyCollection<CXDILogRecord>(ls);
        }
        public ReadOnlyCollection<CXDILogRecord> bookMarks(List<CXDILogRecord> ls)
        {
            return new ReadOnlyCollection<CXDILogRecord>(ls);
        }
        [TestMethod]
        public void WriteMemoLogTest2()
        {

            string filenameUser = string.Format("WriteMemoLogTest2{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CXDIMemoParser();
            var r1 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "exit status S_ExpReady",
                Module = "100"
            };
            var r2 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "Led Ready:ON,Priority:-1[msec]",
                Module = "107"
            };
            var r3 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "StateNotifySet. systemState:0xb0",
                Module = "102"
            };
            var r4 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "Status = S_EXPOSING",
                Module = "100"
            };
            var r5 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "entry status S_Exposing",
                Module = "100"
            };
            var ls = new List<CXDILogRecord> { r1, r2, r3, r4, r5 };
            target.LogRecords = logRecords(ls);
            target.Comments = new Dictionary<CXDILogRecord,string>();
            target.Bookmarks = bookMarks(new List<CXDILogRecord>());
            target.FirmWare = new CXDIFirmware();
            var actual = target.WriteMemoLogFile(fileFullPath);

            var expected = true;
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);
        }
        [TestMethod]
        public void WriteMemoLogTest3()
        {

            string filenameUser = string.Format("WriteMemoLogTest3{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CXDIMemoParser();
            var r1 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "exit status S_ExpReady",
                Module = "100"
            };
            var r2 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "Led Ready:ON,Priority:-1[msec]",
                Module = "107"
            };
            var r3 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "StateNotifySet. systemState:0xb0",
                Module = "102"
            };
            var r4 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "Status = S_EXPOSING",
                Module = "100"
            };
            var r5 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "entry status S_Exposing",
                Module = "100"
            };
            var ls = new List<CXDILogRecord> { r1, r2, r3, r4, r5 };
            target.LogRecords = logRecords(ls);
            target.Comments = new Dictionary<CXDILogRecord, string>();
            target.Comments.Add(r1,"abc");
            target.Comments.Add(r2, "xxx");
            target.Comments.Add(r3, "fdsafds"); 

            target.Bookmarks = bookMarks(new List<CXDILogRecord>());
            target.FirmWare = new CXDIFirmware();
            var actual = target.WriteMemoLogFile(fileFullPath);

            var expected = true;
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);
        }
        [TestMethod]
        public void WriteMemoLogTest4()
        {

            string filenameUser = string.Format("WriteMemoLogTest4{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CXDIMemoParser();
            var r1 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "exit status S_ExpReady",
                Module = "100"
            };
            var r2 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "Led Ready:ON,Priority:-1[msec]",
                Module = "107"
            };
            var r3 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "StateNotifySet. systemState:0xb0",
                Module = "102"
            };
            var r4 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "Status = S_EXPOSING",
                Module = "100"
            };
            var r5 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "entry status S_Exposing",
                Module = "100"
            };
            var ls = new List<CXDILogRecord> { r1, r2, r3, r4, r5 };
            target.LogRecords = logRecords(ls);
            target.Comments = new Dictionary<CXDILogRecord, string>();
            var bm = new List<CXDILogRecord> {r2, r3, r5};
            target.Bookmarks = bookMarks(bm);
            target.FirmWare = new CXDIFirmware();
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

            var target = new CXDIMemoParser();
            var r1 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "exit status S_ExpReady",
                Module = "100"
            };
            var r2 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "Led Ready:ON,Priority:-1[msec]",
                Module = "107"
            };
            var r3 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "StateNotifySet. systemState:0xb0",
                Module = "102"
            };
            var r4 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "Status = S_EXPOSING",
                Module = "100"
            };
            var r5 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "entry status S_Exposing",
                Module = "100"
            };
            var ls = new List<CXDILogRecord> { r1, r2, r3, r4, r5 };
            target.LogRecords = logRecords(ls);
            target.Comments = new Dictionary<CXDILogRecord, string>();
            target.Comments.Add(r1, "abc");
            target.Comments.Add(r2, "xxx");
            target.Comments.Add(r3, "fdsafds"); 

            var bm = new List<CXDILogRecord> { r2, r3, r5 };
            target.Bookmarks = bookMarks(bm);
            target.FirmWare = new CXDIFirmware();
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

            var target = new CXDIMemoParser();
            var r1 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "exit status S_ExpReady",
                Module = "100"
            };
            var r2 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "Led Ready:ON,Priority:-1[msec]",
                Module = "107"
            };
            var r3 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "StateNotifySet. systemState:0xb0",
                Module = "102"
            };
            var r4 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "Status = S_EXPOSING",
                Module = "100"
            };
            var r5 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "entry status S_Exposing",
                Module = "100"
            };
            var ls = new List<CXDILogRecord> { r1, r2, r3, r4, r5 };
            target.LogRecords = logRecords(ls);
            target.Comments = new Dictionary<CXDILogRecord, string>();
            target.Comments.Add(r1, "abc");
            target.Comments.Add(r2, "xxx");
            target.Comments.Add(r3, "fdsafds");

            var bm = new List<CXDILogRecord> { r2, r3, r5 };
            target.Bookmarks = bookMarks(bm);
            target.FirmWare = new CXDIFirmware();
            target.FirmWare.Counter = new List<Counter>();
            target.FirmWare.Counter.Add(new Counter{parameter = "startCount",value = "1523"});
            target.FirmWare.Counter.Add(new Counter{parameter = "staticImageShootCount",value = "8777"});
            target.FirmWare.Counter.Add(new Counter{parameter = "totalTurnOnTime",value = "297885635"});
            target.FirmWare.Saved = new List<Saved>();
            target.FirmWare.Saved.Add(new Saved{parameter = "EtherMacAddress",value = "00-1e-8f-ca-69-3b"});
            target.FirmWare.Saved.Add(new Saved{parameter = "SensorSerialNo",value = "0x18000129"});
            target.FirmWare.Saved.Add(new Saved{parameter = "EtherIpAddress",value = "192.168.100.254"});

            var actual = target.WriteMemoLogFile(fileFullPath);

            var expected = true;
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);
        }
        [TestMethod]
        public void WriteMemoLogTest7()
        {

            string filenameUser = string.Format("WriteMemoLogTest7{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CXDIMemoParser();
            var r1 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "exit status S_ExpReady",
                Module = "100"
            };
            var r2 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "Led Ready:ON,Priority:-1[msec]",
                Module = "107"
            };
            var r3 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "StateNotifySet. systemState:0xb0",
                Module = "102"
            };
            var r4 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "Status = S_EXPOSING",
                Module = "100"
            };
            var r5 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "entry status S_Exposing",
                Module = "100"
            };
            var ls = new List<CXDILogRecord> { r1, r2, r3, r4, r5 };
            target.LogRecords = logRecords(ls);
            target.Comments = new Dictionary<CXDILogRecord, string>();
            target.Comments.Add(r1, "abc");
            target.Comments.Add(r2, "xxx");
            target.Comments.Add(r3, "fdsafds");

            var bm = new List<CXDILogRecord> { r2, r3, r5 };
            target.Bookmarks = bookMarks(bm);
            target.FirmWare = new CXDIFirmware();
            target.FirmWare.Saved = new List<Saved>();
            target.FirmWare.Saved.Add(new Saved { parameter = "EtherMacAddress", value = "00-1e-8f-ca-69-3b" });
            target.FirmWare.Saved.Add(new Saved { parameter = "SensorSerialNo", value = "0x18000129" });
            target.FirmWare.Saved.Add(new Saved { parameter = "EtherIpAddress", value = "192.168.100.254" });

            var actual = target.WriteMemoLogFile(fileFullPath);

            var expected = true;
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);
        }
        [TestMethod]
        public void WriteMemoLogTest8()
        {

            string filenameUser = string.Format("WriteMemoLogTest8{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CXDIMemoParser();
            var r1 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "exit status S_ExpReady",
                Module = "100"
            };
            var r2 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "Led Ready:ON,Priority:-1[msec]",
                Module = "107"
            };
            var r3 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "StateNotifySet. systemState:0xb0",
                Module = "102"
            };
            var r4 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "Status = S_EXPOSING",
                Module = "100"
            };
            var r5 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "entry status S_Exposing",
                Module = "100"
            };
            var ls = new List<CXDILogRecord> { r1, r2, r3, r4, r5 };
            target.LogRecords = logRecords(ls);
            target.Comments = new Dictionary<CXDILogRecord, string>();
            target.Comments.Add(r1, "abc");
            target.Comments.Add(r2, "xxx");
            target.Comments.Add(r3, "fdsafds");

            var bm = new List<CXDILogRecord> { r2, r3, r5 };
            target.Bookmarks = bookMarks(bm);
            target.FirmWare = new CXDIFirmware();
            target.FirmWare.Counter = new List<Counter>();
            target.FirmWare.Counter.Add(new Counter { parameter = "startCount", value = "1523" });
            target.FirmWare.Counter.Add(new Counter { parameter = "staticImageShootCount", value = "8777" });
            target.FirmWare.Counter.Add(new Counter { parameter = "totalTurnOnTime", value = "297885635" });
            target.FirmWare.Saved = new List<Saved>();

            var actual = target.WriteMemoLogFile(fileFullPath);

            var expected = true;
            Assert.AreEqual(expected, actual);

            File.Delete(fileFullPath);
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void WriteMemoLogTest9()
        {

            string filenameUser = string.Format("WriteMemoLogTest9{0}.xml", DateTime.Now.ToString("yyMMddhhmmss"));
            string fileFullPath = Path.GetFullPath(filenameUser);

            var target = new CXDIMemoParser();
            var r1 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "exit status S_ExpReady",
                Module = "100"
            };
            var r2 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "Led Ready:ON,Priority:-1[msec]",
                Module = "107"
            };
            var r3 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "StateNotifySet. systemState:0xb0",
                Module = "102"
            };
            var r4 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "Status = S_EXPOSING",
                Module = "100"
            };
            var r5 = new CXDILogRecord
            {
                Line = 1,
                DateTime= DateTime.Parse("2013/09/11 10:10:10.100"),
                Message = "entry status S_Exposing",
                Module = "100"
            };
            var ls = new List<CXDILogRecord> { r1, r2, r3, r4, r5 };
            target.LogRecords = logRecords(ls);
            target.Comments = new Dictionary<CXDILogRecord, string>();
            target.Comments.Add(r1, "abc");
            target.Comments.Add(r2, "xxx");
            target.Comments.Add(r3, "fdsafds");

            var bm = new List<CXDILogRecord> { r2, r3, r5 };
            target.Bookmarks = bookMarks(bm);

            var actual = target.WriteMemoLogFile(fileFullPath);

            File.Delete(fileFullPath);
        }
        [TestMethod()]
        public void ParserFromFileTest()
        {
            CXDIMemoParser target = new CXDIMemoParser();
            string filePath = string.Empty;
            MemoLog<CXDILogRecord> expected = new MemoLog<CXDILogRecord>();
            MemoLog<CXDILogRecord> actual;
            actual = target.ParserFromFile(filePath);
            Assert.AreEqual(expected.Records.Count, actual.Records.Count);
        }

        /// <summary>
        ///A test for WriteMemoLogFile
        ///</summary>
        [TestMethod()]
        public void WriteMemoLogFileTest()
        {
            CXDIMemoParser target = new CXDIMemoParser();
            string filePath = string.Empty;
            bool expected = false;
            bool actual;
            actual = target.WriteMemoLogFile(filePath);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FirmWare
        ///</summary>
        [TestMethod()]
        public void FirmWareTest()
        {
            CXDIMemoParser target = new CXDIMemoParser();
            CXDIFirmware expected = null;
            CXDIFirmware actual;
            target.FirmWare = expected;
            actual = target.FirmWare;
            Assert.AreEqual(expected, actual);
        }

    }

}
