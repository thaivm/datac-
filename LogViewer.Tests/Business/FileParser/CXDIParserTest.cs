using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LogViewer.Business.FileParser;
using LogViewer.Business.FileSetting;
using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.Business.FileParser
{
    /// <summary>
    ///This is a test class for CXDIParserTest and is intended
    ///to contain all CXDIParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CXDIParserTest
    {
        #region ParserFromFile(string filePath) Test cases

        /// <summary>
        /// ParserFromFile is expected to return properly value.
        /// precondition:
        ///     input file is "TestCXDIParser.log"
        /// expected result:
        ///     ParserFromFile returns the expected results.
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\TestCXDIParser.log")]
        public void ParserFromFileStringTest_1()
        {
            // sets input file path
            string filePath = "TestCXDIParser.log";

            // executes parsing
            CXDIParser parser = new CXDIParser();
            List<CXDILogRecord> logRecords = parser.ParserFromFile(filePath);

            // prepares expected results
            CXDILogRecord log1 = new CXDILogRecord
            {
                Line = 1,
               DateTime=DateTime.Parse("2013/08/20 14:45:04.841"),
                Module = "Mod=100",
                Message = "fsmEvent Index:EVENT_GOTO_INITIALIZE "
            };
            CXDILogRecord log2 = new CXDILogRecord
            {
                Line = 38,
               DateTime=DateTime.Parse("2013/08/20 14:45:10.923"),
                Module = "Mod=103",
                Message = "XIF:Send Data:SETUPTIME 150"
            };
            CXDILogRecord log3 = new CXDILogRecord
            {
                Line = 39,
               DateTime=DateTime.Parse("2013/08/20 14:45:10.925"),
                Module = "Mod=103",
                Message = "XIF:Resp Data:SETUPTIME_OK"
            };
            CXDILogRecord log4 = new CXDILogRecord
            {
                Line = 41,
               DateTime=DateTime.Parse("2013/08/20 14:45:10.928"),
                Module = "Mod=103",
                Message = "XIF:Resp Data:DATE_OK"
            };

            // check returned value
            // compares with log1
            Assert.AreEqual(log1.Line, logRecords[0].Line);
            Assert.AreEqual(log1.Date, logRecords[0].Date);
            Assert.AreEqual(log1.Time, logRecords[0].Time);
            Assert.AreEqual(log1.Module, logRecords[0].Module);
            Assert.AreEqual(log1.Message, logRecords[0].Message);
            // compares with log2
            Assert.AreEqual(log2.Line, logRecords[37].Line);
            Assert.AreEqual(log2.Date, logRecords[37].Date);
            Assert.AreEqual(log2.Time, logRecords[37].Time);
            Assert.AreEqual(log2.Module, logRecords[37].Module);
            Assert.AreEqual(log2.Message, logRecords[37].Message);
            // compares with log3
            Assert.AreEqual(log3.Line, logRecords[38].Line);
            Assert.AreEqual(log3.Date, logRecords[38].Date);
            Assert.AreEqual(log3.Time, logRecords[38].Time);
            Assert.AreEqual(log3.Module, logRecords[38].Module);
            Assert.AreEqual(log3.Message, logRecords[38].Message);
            // compares with log4
            Assert.AreEqual(log4.Line, logRecords[40].Line);
            Assert.AreEqual(log4.Date, logRecords[40].Date);
            Assert.AreEqual(log4.Time, logRecords[40].Time);
            Assert.AreEqual(log4.Module, logRecords[40].Module);
            Assert.AreEqual(log4.Message, logRecords[40].Message);
        }

        /// <summary>
        /// ParserFromFile is expected to throw FileNotFoundException.
        /// precondition:
        ///     input file is "NotExistedFile.txt"
        /// expected result:
        ///     ParserFromFile will throw FileNotFoundException if file not exist.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof (System.IO.FileNotFoundException))]
        public void ParserFromFileStringTest_2()
        {
            CXDIParser parser = new CXDIParser();
            parser.ParserFromFile("NotExistedFile.txt");
        }

        /// <summary>
        /// ParserFromFile is expected to return properly value.
        /// precondition:
        ///     input file is "TestCXDIParserEmpty.log"
        /// expected result:
        ///     ParserFromFile will returns an empty list if input file is an empty file.
        /// </summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\TestCXDIParserEmpty.log")]
        public void ParserFromFileStringTest_3()
        {
            CXDIParser parser = new CXDIParser();
            List<CXDILogRecord> logs = parser.ParserFromFile("TestCXDIParserEmpty.log");

            // check returned value
            Assert.AreEqual(0, logs.Count);
        }


        /// <summary>
        /// ParserFromFile is expected to throw exception.
        /// precondition:
        ///     input file is "TestCXDIParser3.log".
        ///     insert "[][]:   " into line 37.
        /// expected result:
        ///     ParserFromFile will throw exception if read line is invalid.
        /// </summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\TestCXDIParser3.log")]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void ParserFromFileStringTest_4()
        {
            CXDIParser parser = new CXDIParser();
            parser.ParserFromFile("TestCXDIParser3.log");
        }

        /// <summary>
        /// ParserFromFile is expected to return properly value.
        /// precondition:
        ///     input file is "TestCXDIParser4.log"
        ///     insert "[2013/08/20 14:45:04.841][Mod=100]:exit[Checked]:entire of line" into line 39
        /// expected result:
        ///     ParserFromFile returns properly value.
        /// </summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\TestCXDIParser4.log")]
        public void ParserFromFileStringTest_5()
        {
            CXDIParser parser = new CXDIParser();
            List<CXDILogRecord> logs = parser.ParserFromFile("TestCXDIParser4.log");

            // check returned value
            Assert.AreEqual("exit[Checked]:entire of line", logs[1].Message);
        }

        [TestMethod]
        public void ParserFromFileStringTest_6()
        {
            string text = @"--------[counter parameter]--------
startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[save parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
staticImageShootCount:8777
startCount:1523
totalTurnOnTime:297885635[sec]
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------
[2013/09/11 09:54:05.433]";

            string filename = string.Format("ParserFromFileStringTest_6{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text, Encoding.UTF8);
            string fullPathName = Path.GetFullPath(filename);

            var target = new CXDIParser();
            target.ParserFromFile(fullPathName);
            Assert.IsNull(target.LogRecords);
            File.Delete(fullPathName);

        }
        [TestMethod]
        public void ParserFromFileStringTest_7()
        {
            string text = @"--------[counter parameter]--------
startCount : 1523
staticImageShootCount :8777
totalTurnOnTime :297885635
sensorTurnOn :1372773
-----------------------------------
---------[save parameter]---------
EtherMacAddress:00-1e-8f-ca-69-3b
SensorSerialNo:0x18000129
staticImageShootCount:8777
startCount:1523
totalTurnOnTime:297885635[sec]
sensorTurnOn:1372773[sec]
CheckInSaveMode:Save
-----------[message Log]-----------
[2013/09/11 09:54:05.433]";

            string filename = string.Format("ParserFromFileStringTest_7{0}.txt", DateTime.Now.GetHashCode());
            System.IO.File.WriteAllText(filename, text, Encoding.UTF8);
            string fullPathName = Path.GetFullPath(filename);

            var target = new CXDIParser();
            target.ParserFromFile(fullPathName);
            Assert.IsNull(target.LogRecords);
            File.Delete(fullPathName);

        }

        #endregion

        #region ParserFromFile(StringReader reader) Test cases

        /// <summary>
        /// ParserFromFile is expected to return a properly value.
        /// precondition:
        ///     input string is an empty string.
        /// expected result:
        ///     ParserFromFile will return an empty list if input string is empty.
        ///</summary>
        [TestMethod()]
        public void ParserFromFileStringReaderTest_1()
        {
            StringReader reader = new StringReader(String.Empty);
            CXDIParser parser = new CXDIParser();
            List<CXDILogRecord> logs = parser.ParserFromFile(reader);

            // check returned value
            Assert.AreEqual(0, logs.Count);
        }


        /// <summary>
        /// ParserFromFile is expected to return a properly value.
        /// precondition:
        ///     input string is an log invalid ([5:04.841]Mod=107]:Led Link:ON,Priority:1000[msec])
        /// expected result:
        ///     ParserFromFile will return an cxdi log record
        ///</summary>
        [TestMethod()]
        public void ParserFromFileStringTest_Invalid()
        {
            string str = "[5:04.841]Mod=107]:Led Link:ON,Priority:1000[msec]";
            StringReader reader = new StringReader(str);
            CXDIParser_Accessor parser = new CXDIParser_Accessor();
            parser.IsMessageLog = true;
            List<CXDILogRecord> logRecords = parser.ParserFromFile(reader);

            // check returned value
            Assert.IsNotNull(logRecords);
        }

        #endregion

        #region getFirmware Test cases

        /// <summary>
        /// getFirmware is expected to return properly value.
        /// precondition:
        ///     input file is "TestCXDIParser.log"
        /// expected result:
        ///     getFirmware returns the expected result.
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\TestCXDIParser.log")]
        public void getFirmwareTest_1()
        {
            // excutes get firmware
            CXDIParser parser = new CXDIParser();
            CXDIFirmware firmware = parser.GetFirmware("TestCXDIParser.log");

            // checks returned value
            Assert.AreEqual(4, firmware.Counter.Count);
            Assert.AreEqual("startCount ", firmware.Counter[0].parameter);
            Assert.AreEqual(" 539", firmware.Counter[0].value);
            Assert.AreEqual("sensorTurnOn ", firmware.Counter[3].parameter);
            Assert.AreEqual("202967", firmware.Counter[3].value);

            Assert.AreEqual(27, firmware.Saved.Count);
            Assert.AreEqual("Wired MacAddress", firmware.Saved[0].parameter);
            Assert.AreEqual("88-87-17-3a-13-37", firmware.Saved[0].value);
            Assert.AreEqual("Wireless Mask", firmware.Saved[6].parameter);
            Assert.AreEqual("255.255.255.0", firmware.Saved[6].value);
            Assert.AreEqual("WirelessChannel(2.4G)", firmware.Saved[10].parameter);
            Assert.AreEqual("0,(5G):255", firmware.Saved[10].value);
        }

        /// <summary>
        /// getFirmware is expected to throw Exception.
        /// precondition:
        ///     input file is "NotExistedFile.txt".
        /// expected result:
        ///     getFirmware throws FileNotFound exception if file is not existed.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof (System.IO.FileNotFoundException))]
        public void getFirmwareTest_2()
        {
            // executes get firmware
            CXDIParser parser = new CXDIParser();
            parser.GetFirmware("NotExistedFile.txt");
        }

        /// <summary>
        /// getFirmware is expected to return properly value.
        /// precondition:
        ///     input file is "TestCXDIParserEmpty.log"
        /// expected result:
        ///     getFirmware will returns an empty CXDI firmware if input file is an empty file.
        /// </summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\TestCXDIParserEmpty.log")]
        public void getFirmwareTest_3()
        {
            // executes get firmware
            CXDIParser parser = new CXDIParser();
            CXDIFirmware firmware = parser.GetFirmware("TestCXDIParserEmpty.log");

            // checks returned value
            Assert.AreEqual(0, firmware.Counter.Count);
            Assert.AreEqual(0, firmware.Saved.Count);
        }

        /// <summary>
        /// getFirmware is expected to throw exception.
        /// precondition:
        ///     input file is "TestCXDIParser3.log".
        ///     insert string "this is test string" in line 35.
        /// expected result:
        ///     getFirmware will throw exception if read line is invalid.
        /// </summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\TestCXDIParser3.log")]
        [ExpectedException(typeof (System.ArgumentOutOfRangeException))]
        public void getFirmwareTest_4()
        {
            // executes get firmware
            CXDIParser parser = new CXDIParser();
            CXDIFirmware firmware = parser.GetFirmware("TestCXDIParser3.log");
        }

        /// <summary>
        /// getFirmware is expected to return properly value.
        /// precondition:
        ///     input file is "TestCXDIParser4.log".
        ///     clear all value in blog "counter parameter" and "saved parameter".
        /// expected result:
        ///     getFirmware will returns a CXDI firmware with empty counter and saved list.
        /// </summary>
        [TestMethod()]
        [DeploymentItem(@"FileConfig\TestCXDIParser4.log")]
        public void getFirmwareTest_5()
        {
            // executes get firmware
            CXDIParser parser = new CXDIParser();
            CXDIFirmware firmware = parser.GetFirmware("TestCXDIParser4.log");

            // checks returned value
            Assert.AreEqual(0, firmware.Counter.Count);
            Assert.AreEqual(0, firmware.Saved.Count);
        }

        [TestMethod]
        public void ExtractFirmwareTest()
        {
            CXDIParser parser = new CXDIParser();
            PrivateObject po = new PrivateObject(parser);
            CXDIFirmware cxdiFirmware = new CXDIFirmware();
            var expected = cxdiFirmware.Saved.Count;
            po.Invoke("ExtractFirmware", null, cxdiFirmware);
            var actual = cxdiFirmware.Saved.Count;
            Assert.AreEqual(expected,actual);
        }

        #endregion

        [TestMethod]
        public void CorrectDateWhenSensorInitTest()
        {
            // executes parsing
            CXDIParser parser = new CXDIParser();
            // prepares expected results
            CXDILogRecord log1 = new CXDILogRecord
            {
                Line = 1,
               DateTime=DateTime.Parse("2013/08/20 14:45:04.841"),
                Module = "Mod=100",
                Message = "fsmEvent Index:EVENT_GOTO_INITIALIZE "
            };
            CXDILogRecord log2 = new CXDILogRecord
            {
                Line = 38,
               DateTime=DateTime.Parse("2013/08/20 14:45:10.923"),
                Module = "Mod=103",
                Message = "XIF:Send Data:SETUPTIME 150"
            };
            CXDILogRecord log3 = new CXDILogRecord
            {
                Line = 39,
               DateTime=DateTime.Parse("2013/08/20 14:45:10.925"),
                Module = "Mod=103",
                Message = "XIF:Resp Data:SETUPTIME_OK"
            };
            CXDILogRecord log4 = new CXDILogRecord
            {
                Line = 41,
               DateTime=DateTime.Parse("2013/08/20 14:45:10.928"),
                Module = "Mod=103",
                Message = "XIF:Resp Data:DATE_OK"
            };
            var cxdilogNeedResetSensorDateList = new List<CXDILogRecord>();

            PrivateObject po = new PrivateObject(parser);
            int i = 0;
            po.Invoke("CorrectDateWhenSensorInit",new object[]{null, cxdilogNeedResetSensorDateList,i});
            Assert.AreEqual(0,cxdilogNeedResetSensorDateList.Count);
        }
        [TestMethod]
        public void CorrectDateWhenSensorInitTest1()
        {
            // executes parsing
            var target = new CXDIParser();
            // prepares expected results
            var log1 = new CXDILogRecord
            {
                Line = 1,
               DateTime=DateTime.Parse("2013/08/20 14:45:04.841"),
                Module = "Mod=100",
                Message = "fsmEvent Index:EVENT_GOTO_INITIALIZE "
            };
            var log2 = new CXDILogRecord
            {
                Line = 38,
               DateTime=DateTime.Parse("2013/08/20 14:45:10.923"),
                Module = "Mod=103",
                Message = "XIF:Send Data:SETUPTIME 150"
            };
            var log3 = new CXDILogRecord
            {
                Line = 39,
               DateTime=DateTime.Parse("2013/08/20 14:45:10.925"),
                Module = "Mod=103",
                Message = "XIF:Resp Data:SETUPTIME_OK"
            };
            var log4 = new CXDILogRecord
            {
                Line = 41,
               DateTime=DateTime.Parse("2013/08/20 14:45:10.928"),
                Module = "Mod=103",
                Message = "XIF:Resp Data:DATE_OK"
            };
            var cxdilogNeedResetSensorDateList = new List<CXDILogRecord>();
            var cxdiLogRecords = new List<CXDILogRecord>
            {
                log1,log2,log3,log4
            };
            PrivateObject po = new PrivateObject(target);
            int i = 0;
            po.Invoke("CorrectDateWhenSensorInit", new object[] { cxdiLogRecords, null, i });
            Assert.AreEqual(0, cxdilogNeedResetSensorDateList.Count);
        }
              [TestMethod]
        public void CorrectDateWhenSensorInitTest2()
        {
            // executes parsing
            var target = new CXDIParser();
            // prepares expected results
            var log1 = new CXDILogRecord
            {
                Line = 1,
               DateTime=DateTime.Parse("1997/01/01 14:45:04.841"),
                Module = "Mod=100",
                Message = "fsmEvent Index:EVENT_GOTO_INITIALIZE "
            };
            var log2 = new CXDILogRecord
            {
                Line = 38,
               DateTime=DateTime.Parse("2013/08/20 14:45:10.923"),
                Module = "Mod=103",
                Message = "XIF:Send Data:SETUPTIME 150"
            };
            var log3 = new CXDILogRecord
            {
                Line = 39,
               DateTime=DateTime.Parse("1997/01/01 14:45:10.925"),
                Module = "Mod=103",
                Message = "XIF:Resp Data:SETUPTIME_OK"
            };
            var log4 = new CXDILogRecord
            {
                Line = 41,
               DateTime=DateTime.Parse("1997/01/01 14:45:10.928"),
                Module = "Mod=103",
                Message = "XIF:Resp Data:DATE_OK"
            };
            var cxdilogNeedResetSensorDateList = new List<CXDILogRecord>();
            var cxdiLogRecords = new List<CXDILogRecord>
            {
                log1,log2,log3,log4
            };
            var po = new PrivateObject(target);
            int i = 0;
            po.Invoke("CorrectDateWhenSensorInit", new object[] { cxdiLogRecords, cxdilogNeedResetSensorDateList, i });
                  i = 1;
            po.Invoke("CorrectDateWhenSensorInit", new object[] { cxdiLogRecords, cxdilogNeedResetSensorDateList, i });
            Assert.AreEqual(0, cxdilogNeedResetSensorDateList.Count);
        }
              [TestMethod]
              public void CorrectDateWhenSensorInitTest3()
              {
                  // executes parsing
                  var target = new CXDIParser();
                  // prepares expected results
                  var log1 = new CXDILogRecord
                  {
                      Line = 1,
                     DateTime=DateTime.Parse("1997/10/10 14:45:04.841"),
                      Module = "Mod=100",
                      Message = "fsmEvent Index:EVENT_GOTO_INITIALIZE "
                  };
                  var log2 = new CXDILogRecord
                  {
                      Line = 38,
                     DateTime=DateTime.Parse("2013/08/20 14:10:10.923"),
                      Module = "Mod=103",
                      Message = "XIF:Send Data:SETUPTIME 150"
                  };
                  var log3 = new CXDILogRecord
                  {
                      Line = 39,
                     DateTime=DateTime.Parse("1997/01/01 14:45:10.925"),
                      Module = "Mod=103",
                      Message = "XIF:Resp Data:SETUPTIME_OK"
                  };
                  var log4 = new CXDILogRecord
                  {
                      Line = 41,
                     DateTime=DateTime.Parse("1997/01/01 14:45:10.928"),
                      Module = "Mod=103",
                      Message = "XIF:Resp Data:DATE_OK"
                  };
                  var cxdilogNeedResetSensorDateList = new List<CXDILogRecord>();
                  var cxdiLogRecords = new List<CXDILogRecord>
            {
                log1,log2,log3,log4
            };
                  var po = new PrivateObject(target);
                  int i = 0;
                  po.Invoke("CorrectDateWhenSensorInit", new object[] { cxdiLogRecords, cxdilogNeedResetSensorDateList, i });
                  i = 1;
                  po.Invoke("CorrectDateWhenSensorInit", new object[] { cxdiLogRecords, cxdilogNeedResetSensorDateList, i });
                  var expected = "14:10:10.923";
                  var actual = cxdiLogRecords[0].Time;
                  Assert.AreEqual(expected, actual);
              }
              [TestMethod]
              public void TestIsCxdiLogType()
              {
                  StringReader reader = new StringReader("jofdas");
                  PrivateType pt = new PrivateType(typeof(CXDIParser));
                  reader.Dispose();
                  var actual = (bool)pt.InvokeStatic("IsCxdIlogType", reader);
                  var expected = false;
                  Assert.AreEqual(expected, actual);
              }

              [TestMethod]
              public void ParseLineTest1()
              {
                  var target = new CXDIParser();
                  var po = new PrivateObject(target);
                  //ParseLine(List<CXDILogRecord> cxdiLogRecords, int i, string[] split)
                  var cxdiLogRecords = new List<CXDILogRecord>();
                  var i = 0;
                  string[] split = { "[2014/10/10 10aa10:10.100]", "[jhhfod]: fdosa fds" };
                  po.Invoke("ParseLine", cxdiLogRecords, i, split);
                  Assert.AreEqual(0, cxdiLogRecords.Count);

              }

    }
}
