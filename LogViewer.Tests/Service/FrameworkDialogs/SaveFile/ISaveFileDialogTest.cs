using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogViewer.Service.FrameworkDialogs.SaveFile;

namespace LogViewer.Tests.Service.FrameworkDialogs.SaveFile
{
    [TestClass]
    public class ISaveFileDialogTest
    {
        [TestMethod]
        public void ISaveFileDialogDoTest()
        {
            ISaveFileDialog target = new SaveFileDialogViewModel();
            Assert.IsNotNull(target);
        }
        [TestMethod]
        public void ISaveFileDialogDoTest1()
        {
            ISaveFileDialog target = new SaveFileDialogViewModel();
            var expected = typeof(SaveFileDialogViewModel);
            Assert.AreEqual(expected,target.GetType());
        }
        [TestMethod]
        public void ISaveFileDialogDoTest2()
        {
            ISaveFileDialog target = new SaveFileDialogViewModel();
            var expected = string.Empty;
            target.FileName = expected;
            var actual = target.FileName;
            Assert.AreEqual(expected, expected);
        }
        [TestMethod]
        public void ISaveFileDialogDoTest3()
        {
            ISaveFileDialog target = new SaveFileDialogViewModel();
            var expected = "abc";
            target.FileName = expected;
            var actual = target.FileName;
            Assert.AreEqual(expected, expected);
        }
        [TestMethod]
        public void ISaveFileDialogDoTest4()
        {
            ISaveFileDialog target = new SaveFileDialogViewModel();
            var expected = string.Empty;
            target.Filter = expected;
            var actual = target.Filter;
            Assert.AreEqual(expected, expected);
        }
        [TestMethod]
        public void ISaveFileDialogDoTest5()
        {
            ISaveFileDialog target = new SaveFileDialogViewModel();
            var expected = "abc";
            target.Filter = expected;
            var actual = target.Filter;
            Assert.AreEqual(expected, expected);
        }
        [TestMethod]
        public void ISaveFileDialogDoTest6()
        {
            ISaveFileDialog target = new SaveFileDialogViewModel();
            var expected = string.Empty;
            target.DefaultExt = expected;
            var actual = target.DefaultExt;
            Assert.AreEqual(expected, expected);
        }
        [TestMethod]
        public void ISaveFileDialogDoTest7()
        {
            ISaveFileDialog target = new SaveFileDialogViewModel();
            var expected = "abc";
            target.DefaultExt = expected;
            var actual = target.DefaultExt;
            Assert.AreEqual(expected, expected);
        }

    }
}
