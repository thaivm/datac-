using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using LogViewer.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.Business.ItemSetting
{
    [TestClass]
    public class KeywordCountSettingTest
    {
        [TestMethod]
        public void CopyTest()
        {
            var target = new KeywordCountItemSetting();
            target.StringValue = "abc";
            target.Name = "fdasfds";
            var actual = target.Copy();
            Assert.IsNotNull(actual);

        }
        [TestMethod]
        public void ValidateTest()
        {
            var target = new KeywordCountItemSetting();

            target.Name = "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";//51 character
            var actual = target.ValidDate(new List<string>());
            Assert.AreEqual(false,actual);

        }
        [TestMethod]
        public void ValidateTest1()
        {
            var target = new KeywordCountItemSetting();
            target.Name = "fdasfds";
            target.StringValue = "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";//51 character
            var actual = target.ValidDate(new List<string>());
            Assert.AreEqual(false,actual);

        }
        [TestMethod]
        public void ValidateTest2()
        {
            var target = new KeywordCountItemSetting();
            target.Name = "fdasfds";
            target.StringValue = "abc";
            target.LogItem = string.Empty;
            var actual = target.ValidDate(new List<string>());
            Assert.AreEqual(false, actual);

        }
        [TestMethod]
        public void ValidateTest3()
        {
            var target = new KeywordCountItemSetting();
            target.Name = "fdasfds";
            target.StringValue = "abc";
            target.LogItem = "abc";
            var actual = target.ValidDate(new List<string>{"xxx","kkk"});
            Assert.AreEqual(false, actual);

        }
        [TestMethod]
        public void ValidateTest4()
        {
            var target = new KeywordCountItemSetting();
            target.Name = "abc";
            target.StringValue = "abc";
            target.LogItem = "abc";
            var actual = target.ValidDate(new List<string> { "abc", "kkk" });
            Assert.AreEqual(true, actual);

        }
    }

}
