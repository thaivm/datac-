using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogViewer.Business.FileParser;
using LogViewer.Business;

namespace LogViewer.Tests.Business.FileParser
{
    [TestClass]
    public class ILogParserTest
    {
        [TestMethod]
        public void ParserFromFileTest1()
        {
            ILogParser<LogViewer.Model.CCSLogRecord> target = new CCSParserOld();
            Type expected = typeof(CCSParserOld);
            Assert.AreEqual(expected, target.GetType());
        }
        [TestMethod]
        public void ParserFromFileTest2()
        {
            ILogParser<LogViewer.Model.CCSLogRecord> target = new CCSParserNew();
            Type expected = typeof(CCSParserNew);
            Assert.AreEqual(expected, target.GetType());
        }
        [TestMethod]
        public void ParserFromFileTest3()
        {
            ILogParser<LogViewer.Model.CXDILogRecord> target = new CXDIParser();
            Type expected = typeof(CXDIParser);
            Assert.AreEqual(expected, target.GetType());
        }
        [TestMethod]
        public void ParserFromFileTest4()
        {
            ILogParser<LogViewer.Model.CCSLogRecord> target = new CCSParserOld();
            Type expected = typeof(CCSParserNew);
            Assert.AreNotEqual(expected, target.GetType());
        }
        [TestMethod]
        public void ParserFromFileTest5()
        {
            ILogParser<LogViewer.Model.CCSLogRecord> target = new CCSParserNew();
            Type expected = typeof(CCSParserOld);
            Assert.AreNotEqual(expected, target.GetType());
        }
        [TestMethod]
        public void ParserFromFileTest6()
        {
            ILogParser<LogViewer.Model.CCSLogRecord> target = new CCSParserOld();
            Type expected = typeof(CXDIParser);
            Assert.AreNotEqual(expected, target.GetType());
        }
        [TestMethod]
        public void ParserFromFileTest7()
        {
            ILogParser<LogViewer.Model.CCSLogRecord> target = new CCSParserNew();
            Type expected = typeof(CXDIParser);
            Assert.AreNotEqual(expected, target.GetType());
        }
        [TestMethod]
        public void ParserFromFileTest8()
        {
            ILogParser<LogViewer.Model.CXDILogRecord> target = new CXDIParser();
            Type expected = typeof(CCSParserOld);
            Assert.AreNotEqual(expected, target.GetType());
        }
        [TestMethod]
        public void ParserFromFileTest9()
        {
            ILogParser<LogViewer.Model.CXDILogRecord> target = new CXDIParser();
            Type expected = typeof(CCSParserNew);
            Assert.AreNotEqual(expected, target.GetType());
        }




    }
}
