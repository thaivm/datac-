using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogViewer.Business;

namespace LogViewer.Tests.Business.FileSetting
{
    [TestClass]
    public class BaseItemSettingTest
    {

        [TestMethod]
        public void NameTest()
        {
            BaseItemSetting target = new KeywordCountItemSetting();
            var expected = "fdasfds";
            target.Name = expected;
            Assert.AreEqual(expected,target.Name);

        }
        [TestMethod]
        public void NameTest1()
        {
            BaseItemSetting target = new KeywordCountItemSetting();
            var expected = string.Empty;
            target.Name = expected;
            Assert.AreEqual(expected, target.Name);

        }
        [TestMethod]
        public void EnableTest()
        {
            BaseItemSetting target = new KeywordCountItemSetting();
            var expected = true;
            target.Enabled= expected;
            Assert.AreEqual(expected, target.Enabled);

        }
        [TestMethod]
        public void EnableTest1()
        {
            BaseItemSetting target = new KeywordCountItemSetting();
            var expected = false;
            target.Enabled = expected;
            Assert.AreEqual(expected, target.Enabled);

        }
        [TestMethod]
        public void IdTest()
        {
            BaseItemSetting target = new KeywordCountItemSetting();
            var expected = "1";
            target.Id = expected;
            Assert.AreEqual(expected, target.Id);

        }
        [TestMethod]
        public void IdTest1()
        {
            BaseItemSetting target = new KeywordCountItemSetting();
            var expected = string.Empty;
            target.Id = expected;
            Assert.AreEqual(expected, target.Id);

        }
        [TestMethod]
        public void ThisTest1()
        {
            BaseItemSetting target = new KeywordCountItemSetting();
            var expected = string.Empty;
            var actual = target["Id"];
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void ThisTest2()
        {
            BaseItemSetting target = new KeywordCountItemSetting();
            var expected = string.Empty;
            var actual = target["xxx"];
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ValidateTest()
        {
            BaseItemSetting target = new KeywordCountItemSetting();

            target.Name = null;
            var expected = Properties.Resources.ValidateEmptyNameMessage;
            PrivateObject po = new PrivateObject(target,new PrivateType(typeof(BaseItemSetting)));

            var actual = po.Invoke("ValidateName");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ValidateTest1()
        {
            BaseItemSetting target = new KeywordCountItemSetting();

            target.Name = string.Empty;
            var expected = Properties.Resources.ValidateEmptyNameMessage;
            PrivateObject po = new PrivateObject(target, new PrivateType(typeof(BaseItemSetting)));

            var actual = po.Invoke("ValidateName");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ValidateTest2()
        {
            var target = new KeywordCountItemSetting();

            target.Name = "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";//51 character
            var expected = Properties.Resources.ValidateLengthNameMessage;
            PrivateObject po = new PrivateObject(target, new PrivateType(typeof(BaseItemSetting)));
            var actual = po.Invoke("ValidateName");
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void ValidateTest3()
        {
            var target = new KeywordCountItemSetting();

            target.Name = "abc";//51 character
            var expected = string.Empty;
            PrivateObject po = new PrivateObject(target, new PrivateType(typeof(BaseItemSetting)));
            var actual = po.Invoke("ValidateName");
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void ValidateTest4()
        {
            var target = new KeywordCountItemSetting();

            target.Name = "abc";//51 character
            var expected = Properties.Resources.ValidateEmptyNameMessage;
            PrivateObject po = new PrivateObject(target, new PrivateType(typeof(BaseItemSetting)));
            var actual = po.Invoke("ValidateName");
            Assert.AreNotEqual(expected, actual);

        }
        [TestMethod]
        public void ValidateTest5()
        {
            var target = new KeywordCountItemSetting();

            target.Name = "abc";//51 character
            var expected = Properties.Resources.ValidateLengthNameMessage;
            PrivateObject po = new PrivateObject(target, new PrivateType(typeof(BaseItemSetting)));
            var actual = po.Invoke("ValidateName");
            Assert.AreNotEqual(expected, actual);

        }
        [TestMethod]
        public void ValidateTest6()
        {
            var target = new KeywordCountItemSetting();

            target.Name = "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";//51 character
            var expected = Properties.Resources.ValidateEmptyNameMessage;
            PrivateObject po = new PrivateObject(target, new PrivateType(typeof(BaseItemSetting)));
            var actual = po.Invoke("ValidateName");
            Assert.AreNotEqual(expected, actual);

        }
        [TestMethod]
        public void ValidateTest7()
        {
            var target = new KeywordCountItemSetting();

            target.Name = "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";//51 character
            var expected = string.Empty;
            PrivateObject po = new PrivateObject(target, new PrivateType(typeof(BaseItemSetting)));
            var actual = po.Invoke("ValidateName");
            Assert.AreNotEqual(expected, actual);

        }
        [TestMethod]
        public void ValidateTest8()
        {
            BaseItemSetting target = new KeywordCountItemSetting();

            target.Name = string.Empty;
            var expected = Properties.Resources.ValidateLengthNameMessage;
            PrivateObject po = new PrivateObject(target, new PrivateType(typeof(BaseItemSetting)));

            var actual = po.Invoke("ValidateName");
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod]
        public void ValidateTest9()
        {
            BaseItemSetting target = new KeywordCountItemSetting();

            target.Name = string.Empty;
            var expected = string.Empty;
            PrivateObject po = new PrivateObject(target, new PrivateType(typeof(BaseItemSetting)));

            var actual = po.Invoke("ValidateName");
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod]
        public void ValidateTest10()
        {
            BaseItemSetting target = new KeywordCountItemSetting();

            target.Name = null;
            var expected = Properties.Resources.ValidateLengthNameMessage;
            PrivateObject po = new PrivateObject(target, new PrivateType(typeof(BaseItemSetting)));

            var actual = po.Invoke("ValidateName");
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod]
        public void ValidateTest11()
        {
            BaseItemSetting target = new KeywordCountItemSetting();

            target.Name = null;
            var expected = string.Empty;
            PrivateObject po = new PrivateObject(target, new PrivateType(typeof(BaseItemSetting)));

            var actual = po.Invoke("ValidateName");
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod]
        public void ValidateTest12()
        {
            BaseItemSetting target = new KeywordCountItemSetting();

            target.Name = "  ";
            var expected = Properties.Resources.ValidateEmptyNameMessage;
            PrivateObject po = new PrivateObject(target, new PrivateType(typeof(BaseItemSetting)));

            var actual = po.Invoke("ValidateName");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ValidateTest13()
        {
            BaseItemSetting target = new KeywordCountItemSetting();

            target.Name = "  ";
            var expected = string.Empty;
            PrivateObject po = new PrivateObject(target, new PrivateType(typeof(BaseItemSetting)));

            var actual = po.Invoke("ValidateName");
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod]
        public void ValidateTest15()
        {
            BaseItemSetting target = new KeywordCountItemSetting();

            target.Name = "  ";
            var expected = Properties.Resources.ValidateLengthNameMessage;
            PrivateObject po = new PrivateObject(target, new PrivateType(typeof(BaseItemSetting)));

            var actual = po.Invoke("ValidateName");
            Assert.AreNotEqual(expected, actual);
        }

    }

}
