using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using LogViewer.Business;
using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.Business.ItemSetting
{
    [TestClass]
    public class FoundPatternTest
    {
        [TestMethod]
        public void PatternTest()
        {
            var expected = new PatternItemSetting();
            var target = new FoundPattern<BaseLogRecord>(new PatternItemSetting());
            target.Pattern = expected;
            Assert.AreEqual(expected,target.Pattern);
        }
        [TestMethod]
        public void PatternTest1()
        {
            var target = new FoundPattern<BaseLogRecord>(new PatternItemSetting());
            
            Assert.IsNotNull(target.LogRecords);
        }

        [TestMethod]
        public void PatternTest2()
        {
            var expected = new PatternItemSetting();
            var target = new FoundPattern<CCSLogRecord>(new PatternItemSetting());
            target.Pattern = expected;
            Assert.AreEqual(expected, target.Pattern);
        }
        [TestMethod]
        public void PatternTest3()
        {
            var target = new FoundPattern<CCSLogRecord>(new PatternItemSetting());

            Assert.IsNotNull(target.LogRecords);
        }

        [TestMethod]
        public void PatternTest4()
        {
            var expected = new PatternItemSetting();
            var target = new FoundPattern<CXDILogRecord>(new PatternItemSetting());
            target.Pattern = expected;
            Assert.AreEqual(expected, target.Pattern);
        }
        [TestMethod]
        public void PatternTest5()
        {
            var target = new FoundPattern<CXDILogRecord>(new PatternItemSetting());

            Assert.IsNotNull(target.LogRecords);
        }
    }
}
