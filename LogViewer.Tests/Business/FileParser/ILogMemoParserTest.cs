using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogViewer.Business;
using LogViewer.Business.FileParser;

namespace LogViewer.Tests.Business.FileParser
{
    [TestClass]
    public class ILogMemoParserTest
    {
        [TestMethod]
        public void ParserFromFileTest1()
        {
            ILogMemoParser<LogViewer.Model.CCSLogRecord> target = new CCSMemoParserOld();
            Type expected = typeof(CCSMemoParserOld);
            Assert.AreEqual(expected, target.GetType());
        }
        [TestMethod]
        public void ParserFromFileTest2()
        {
            ILogMemoParser<LogViewer.Model.CCSLogRecord> target = new CCSMemoParserNew();
            Type expected = typeof(CCSMemoParserNew);
            Assert.AreEqual(expected, target.GetType());
        }
        [TestMethod]
        public void ParserFromFileTest3()
        {
            ILogMemoParser<LogViewer.Model.CXDILogRecord> target = new CXDIMemoParser();
            Type expected = typeof(CXDIMemoParser);
            Assert.AreEqual(expected, target.GetType());
        }
        [TestMethod]
        public void ParserFromFileTest4()
        {
            ILogMemoParser<LogViewer.Model.CCSLogRecord> target = new CCSMemoParserOld();
            Type expected = typeof(CCSMemoParserNew);
            Assert.AreNotEqual(expected, target.GetType());
        }
        [TestMethod]
        public void ParserFromFileTest5()
        {
            ILogMemoParser<LogViewer.Model.CCSLogRecord> target = new CCSMemoParserNew();
            Type expected = typeof(CCSMemoParserOld);
            Assert.AreNotEqual(expected, target.GetType());
        }
        [TestMethod]
        public void ParserFromFileTest6()
        {
            ILogMemoParser<LogViewer.Model.CCSLogRecord> target = new CCSMemoParserOld();
            Type expected = typeof(CXDIMemoParser);
            Assert.AreNotEqual(expected, target.GetType());
        }
        [TestMethod]
        public void ParserFromFileTest7()
        {
            ILogMemoParser<LogViewer.Model.CCSLogRecord> target = new CCSMemoParserNew();
            Type expected = typeof(CXDIMemoParser);
            Assert.AreNotEqual(expected, target.GetType());
        }
        [TestMethod]
        public void ParserFromFileTest8()
        {
            ILogMemoParser<LogViewer.Model.CXDILogRecord> target = new CXDIMemoParser();
            Type expected = typeof(CCSMemoParserOld);
            Assert.AreNotEqual(expected, target.GetType());
        }
        [TestMethod]
        public void ParserFromFileTest9()
        {
            ILogMemoParser<LogViewer.Model.CXDILogRecord> target = new CXDIMemoParser();
            Type expected = typeof(CCSMemoParserNew);
            Assert.AreNotEqual(expected, target.GetType());
        }
    }
}
