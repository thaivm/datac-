using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using LogViewer.Business;
using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.Business.ItemSetting
{
    [TestClass]
    public class FilterItemSettingTest
    {
        [TestMethod]
        public void IsValidDateTest()
        {
            var target = new FilterItemSetting();
            var logItem = new List<string> {"abc", "xxx"};
            var expected = false;
            var actual = target.IsValidDate(null);
            Assert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void IsValidDateTest1()
        {
            var target = new FilterItemSetting();
            var logItem = new List<string> { "abc", "xxx" };
            var expected = false;
            var actual = target.IsValidDate(logItem);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsValidDateTest2()
        {
            var target = new FilterItemSetting();
            var logItem = new List<string> { "abc", "xxx" };
            target.FontStyle = "jfds";
            var expected = false;
            var actual = target.IsValidDate(logItem);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsValidDateTest3()
        {
            var target = new FilterItemSetting();
            var logItem = new List<string> { "abc", "xxx" };
            target.FontStyle = ConfigValue.FilterSettingFontStyles.BOLD;
            var expected = false;
            var actual = target.IsValidDate(logItem);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsValidDateTest4()
        {
            var target = new FilterItemSetting();
            var logItem = new List<string> { "abc", "xxx" };
            target.FontStyle = ConfigValue.FilterSettingFontStyles.BOLD;
            target.Background = "jfods";
            var expected = false;
            var actual = target.IsValidDate(logItem);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsValidDateTest5()
        {
            var target = new FilterItemSetting();
            var logItem = new List<string> { "abc", "xxx" };
            target.FontStyle = ConfigValue.FilterSettingFontStyles.BOLD;
            target.Background = "#FFFFFF";
            var expected = false;
            var actual = target.IsValidDate(logItem);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsValidDateTest6()
        {
            var target = new FilterItemSetting();
            var logItem = new List<string> { "abc", "xxx" };
            target.FontStyle = ConfigValue.FilterSettingFontStyles.BOLD;
            target.Background = "#FFFFFF";
            target.Foreground = "jfodsjaof";
            var expected = false;
            var actual = target.IsValidDate(logItem);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsValidDateTest9()
        {
            var target = new FilterItemSetting();
            var logItem = new List<string> { "abc", "xxx" };
            target.FontStyle = ConfigValue.FilterSettingFontStyles.BOLD;
            target.Background = "#FFFFFF";
            target.Foreground = "#FFFFFF";
            target.Name = string.Empty;
            var expected = false;
            var actual = target.IsValidDate(logItem);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsValidDateTest10()
        {
            var target = new FilterItemSetting();
            var logItem = new List<string> { "abc", "xxx" };
            target.FontStyle = ConfigValue.FilterSettingFontStyles.BOLD;
            target.Background = "#FFFFFF";
            target.Foreground = "#FFFFFF";
            target.Name = string.Empty;
            target.StringValue = "jfodsa";
            var expected = false;
            var actual = target.IsValidDate(logItem);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsValidDateTest11()
        {
            var target = new FilterItemSetting();
            var logHeaders = new List<string> { "abc", "xxx" };
            target.FontStyle = ConfigValue.FilterSettingFontStyles.BOLD;
            target.Background = "#FFFFFF";
            target.Foreground = "#FFFFFF";
            target.Name = string.Empty;
            target.StringValue = string.Empty;
            target.LogItem = "abc";
            var expected = false;
            var actual = target.IsValidDate(logHeaders);
            Assert.AreEqual(expected, actual);
        }
    }
}
