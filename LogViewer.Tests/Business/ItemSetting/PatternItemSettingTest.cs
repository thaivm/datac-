using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using LogViewer.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.Business.FileSetting
{
    [TestClass]
    public class PatternItemSettingTest
    {
        [TestMethod]
        public void ValidateRootKeyTest()
        {
            var target = new PatternItemSetting();
            var keys = new List<string> { "abc", "xxxffss" };
            target.Keys = keys;
            target.RootKey = string.Empty;
            PrivateObject po = new PrivateObject(target);
            var actual = po.Invoke("ValidateRootKey");
            Assert.AreNotEqual(string.Empty, actual);
        }
        [TestMethod]
        public void ValidateRootKeyTest1()
        {
            var target = new PatternItemSetting();
            var keys = new List<string> { "abc", "xxxffss" };
            target.Keys = keys;
            target.RootKey = "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";//51 character
            PrivateObject po = new PrivateObject(target);
            var actual = po.Invoke("ValidateRootKey");
            Assert.AreNotEqual(string.Empty, actual);
        }
        [TestMethod]
        public void ValidateRootKeyTest2()
        {
            var target = new PatternItemSetting();
            var keys = new List<string> { "abc", "xxxffss" };
            target.Keys = keys;
            target.RootKey = "abc";//51 character
            PrivateObject po = new PrivateObject(target);
            var actual = po.Invoke("ValidateRootKey");
            Assert.AreEqual(string.Empty, actual);
        }
    }
}
