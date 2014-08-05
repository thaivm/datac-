using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using LogViewer.Business;
using LogViewer.Business.ItemSetting;
using LogViewer.Business.TimeUnits;
using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.Business.ItemSetting
{
    [TestClass]
    public class PatternProxySettingTest
    {
        [TestMethod]
        public void PatternProxySettingConstructorTest()
        {
            var target = new PatternProxySetting<CCSLogRecord>();
            Assert.IsNotNull(target.FoundPatterns);
        }
        [TestMethod]
        public void PatternProxySettingConstructorTest21()
        {
            var target = new PatternProxySetting<CXDILogRecord>();
            Assert.IsNotNull(target.FoundPatterns);
        }
        [TestMethod]
        public void PatternProxySettingConstructorTest1()
        {
            var pattern = new PatternItemSetting{ Name = "abc",Keys = new List<string>{"a","b"},TimeUnit = "H",Enabled = true};

            var target = new PatternProxySetting<CCSLogRecord>(pattern);
            var expect = 2;
            var actual = target.Pattern.Keys.Count;
            Assert.AreEqual(expect,actual);
        }
        [TestMethod]
        public void PatternProxySettingConstructorTest22()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "H", Enabled = true };

            var target = new PatternProxySetting<CXDILogRecord>(pattern);
            var expect = 2;
            var actual = target.Pattern.Keys.Count;
            Assert.AreEqual(expect, actual);
        }
        [TestMethod]
        public void ITimeCompareTest()
        {
            var target = new PatternProxySetting<CCSLogRecord>();
            
            var actual = target.ITimeCompare;
            Assert.IsNull(actual);
        }
        [TestMethod]
        public void ITimeCompareTest21()
        {
            var target = new PatternProxySetting<CXDILogRecord>();

            var actual = target.ITimeCompare;
            Assert.IsNull(actual);
        }
        [TestMethod]
        public void ITimeCompareTest1()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "H", Enabled = true };

            var target = new PatternProxySetting<CCSLogRecord>(pattern);
            var expect = typeof(TimeCompareH);
            var actual = target.ITimeCompare.GetType();
            Assert.AreEqual(expect, actual);
        }
        public void ITimeCompareTest28()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "H", Enabled = true };

            var target = new PatternProxySetting<CXDILogRecord>(pattern);
            var expect = typeof(TimeCompareH);
            var actual = target.ITimeCompare.GetType();
            Assert.AreEqual(expect, actual);
        }
        [TestMethod]
        public void ITimeCompareTest2()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "M", Enabled = true };

            var target = new PatternProxySetting<CCSLogRecord>(pattern);
            var expect = typeof(TimeCompareM);
            var actual = target.ITimeCompare.GetType();
            Assert.AreEqual(expect, actual);
        }
        [TestMethod]
        public void ITimeCompareTest23()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "M", Enabled = true };

            var target = new PatternProxySetting<CXDILogRecord>(pattern);
            var expect = typeof(TimeCompareM);
            var actual = target.ITimeCompare.GetType();
            Assert.AreEqual(expect, actual);
        }
        [TestMethod]
        public void ITimeCompareTest3()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "S", Enabled = true };

            var target = new PatternProxySetting<CCSLogRecord>(pattern);
            var expect = typeof(TimeCompareS);
            var actual = target.ITimeCompare.GetType();
            Assert.AreEqual(expect, actual);
        }
        [TestMethod]
        public void ITimeCompareTest24()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "S", Enabled = true };

            var target = new PatternProxySetting<CXDILogRecord>(pattern);
            var expect = typeof(TimeCompareS);
            var actual = target.ITimeCompare.GetType();
            Assert.AreEqual(expect, actual);
        }
        [TestMethod]
        public void ITimeCompareTest4()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "MS", Enabled = true };

            var target = new PatternProxySetting<CCSLogRecord>(pattern);
            var expect = typeof(TimeCompareMS);
            var actual = target.ITimeCompare.GetType();
            Assert.AreEqual(expect, actual);
        }
        [TestMethod]
        public void ITimeCompareTest25()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "MS", Enabled = true };

            var target = new PatternProxySetting<CXDILogRecord>(pattern);
            var expect = typeof(TimeCompareMS);
            var actual = target.ITimeCompare.GetType();
            Assert.AreEqual(expect, actual);
        }
        [TestMethod]
        public void ITimeCompareTest5()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "h", Enabled = true };

            var target = new PatternProxySetting<CCSLogRecord>(pattern);
            var expect = typeof(TimeCompareH);
            var actual = target.ITimeCompare.GetType();
            Assert.AreEqual(expect, actual);
        }
        [TestMethod]
        public void ITimeCompareTest26()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "h", Enabled = true };

            var target = new PatternProxySetting<CXDILogRecord>(pattern);
            var expect = typeof(TimeCompareH);
            var actual = target.ITimeCompare.GetType();
            Assert.AreEqual(expect, actual);
        }
        [TestMethod]
        public void ITimeCompareTest6()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "m", Enabled = true };

            var target = new PatternProxySetting<CCSLogRecord>(pattern);
            var expect = typeof(TimeCompareM);
            var actual = target.ITimeCompare.GetType();
            Assert.AreEqual(expect, actual);
        }
        [TestMethod]
        public void ITimeCompareTest27()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "m", Enabled = true };

            var target = new PatternProxySetting<CXDILogRecord>(pattern);
            var expect = typeof(TimeCompareM);
            var actual = target.ITimeCompare.GetType();
            Assert.AreEqual(expect, actual);
        }
        [TestMethod]
        public void ITimeCompareTest7()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "s", Enabled = true };

            var target = new PatternProxySetting<CCSLogRecord>(pattern);
            var expect = typeof(TimeCompareS);
            var actual = target.ITimeCompare.GetType();
            Assert.AreEqual(expect, actual);
        }
        [TestMethod]
        public void ITimeCompareTest30()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "s", Enabled = true };

            var target = new PatternProxySetting<CXDILogRecord>(pattern);
            var expect = typeof(TimeCompareS);
            var actual = target.ITimeCompare.GetType();
            Assert.AreEqual(expect, actual);
        }
        [TestMethod]
        public void ITimeCompareTest8()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "ms", Enabled = true };

            var target = new PatternProxySetting<CCSLogRecord>(pattern);
            var expect = typeof(TimeCompareMS);
            var actual = target.ITimeCompare.GetType();
            Assert.AreEqual(expect, actual);
        }
        [TestMethod]
        public void ITimeCompareTest29()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "ms", Enabled = true };

            var target = new PatternProxySetting<CXDILogRecord>(pattern);
            var expect = typeof(TimeCompareMS);
            var actual = target.ITimeCompare.GetType();
            Assert.AreEqual(expect, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ITimeCompareTest9()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "notsouportyet", Enabled = true };

            var target = new PatternProxySetting<CCSLogRecord>(pattern);
        }
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ITimeCompareTest31()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "notsouportyet", Enabled = true };

            var target = new PatternProxySetting<CXDILogRecord>(pattern);
        }
        [TestMethod]
        public void ITimeCompareTest10()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "ms", Enabled = true,Time = 100};

            var target = new PatternProxySetting<CCSLogRecord>(pattern);
            var expect = (ulong)100;
            var actual = target.Interval;
            Assert.AreEqual(expect, actual);
        }
        [TestMethod]
        public void ITimeCompareTest20()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "ms", Enabled = true, Time = 100 };

            var target = new PatternProxySetting<CXDILogRecord>(pattern);
            var expect = (ulong)100;
            var actual = target.Interval;
            Assert.AreEqual(expect, actual);
        }
        [TestMethod]
        public void ITimeCompareTest11()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "ms", Enabled = true, Time = 100 };

            var target = new PatternProxySetting<CCSLogRecord>(pattern);
            var actual = target.AllKeyRegex;
            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void ITimeCompareTest32()
        {
            var pattern = new PatternItemSetting { Name = "abc", Keys = new List<string> { "a", "b" }, TimeUnit = "ms", Enabled = true, Time = 100 };

            var target = new PatternProxySetting<CXDILogRecord>(pattern);
            var actual = target.AllKeyRegex;
            Assert.IsNotNull(actual);
        }

    }
}
