using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogViewer.Service.FrameworkDialogs;
using LogViewer.Service.FrameworkDialogs.OpenFile;

namespace LogViewer.Tests.Service.FrameworkDialogs
{
    [TestClass]
    public class IFileDialogTest
    {
        [TestMethod]
        public void IFileDialogDoTest1()
        {
            IFileDialog target = new OpenFileDialogViewModel();
            Assert.IsNotNull(target);
        }
        [TestMethod]
        public void IFileDialogDoTest2()
        {
            IFileDialog target = new OpenFileDialogViewModel();
            var expected = typeof(OpenFileDialogViewModel);
            var actual = target.GetType();
            Assert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void IFileDialogDoTest3()
        {
            IFileDialog target = new OpenFileDialogViewModel();
            var expected = string.Empty;
            target.FileName = expected;
            var actual = target.FileName;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IFileDialogDoTest4()
        {
            IFileDialog target = new OpenFileDialogViewModel();
            var expected = "abc";
            target.FileName = expected;
            var actual = target.FileName;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IFileDialogDoTest5()
        {
            IFileDialog target = new OpenFileDialogViewModel();
            var expected = string.Empty;
            target.DefaultExt = expected;
            var actual = target.DefaultExt;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IFileDialogDoTest6()
        {
            IFileDialog target = new OpenFileDialogViewModel();
            target.FileNames = null;
            var actual = target.FileNames;
            Assert.AreEqual(null, actual);
        }
        [TestMethod]
        public void IFileDialogDoTest7()
        {
            IFileDialog target = new OpenFileDialogViewModel();
            var expected = new string[]{};
            target.FileNames = expected;
            var actual = target.FileNames;
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IFileDialogDoTest8()
        {
            IFileDialog target = new OpenFileDialogViewModel();
            var expected = new string[] {"ab","abc" };
            target.FileNames = expected;
            var actual = target.FileNames;
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IFileDialogDoTest9()
        {
            IFileDialog target = new OpenFileDialogViewModel();
            var expected = string.Empty;
            target.Filter = expected;
            var actual = target.Filter;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IFileDialogDoTest10()
        {
            IFileDialog target = new OpenFileDialogViewModel();
            var expected = "abc";
            target.Filter = expected;
            var actual = target.Filter;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IFileDialogDoTest11()
        {
            IFileDialog target = new OpenFileDialogViewModel();
            var expected = string.Empty;
            target.InitialDirectory = expected;
            var actual = target.InitialDirectory;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IFileDialogDoTest12()
        {
            IFileDialog target = new OpenFileDialogViewModel();
            var expected = "abc";
            target.InitialDirectory = expected;
            var actual = target.InitialDirectory;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IFileDialogDoTest13()
        {
            IFileDialog target = new OpenFileDialogViewModel();
            var expected = "abc";
            target.DefaultExt = expected;
            var actual = target.DefaultExt;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IFileDialogDoTest14()
        {
            IFileDialog target = new OpenFileDialogViewModel();
            var expected = string.Empty;
            target.Title = expected;
            var actual = target.Title;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IFileDialogDoTest15()
        {
            IFileDialog target = new OpenFileDialogViewModel();
            var expected = "abc";
            target.Title = expected;
            var actual = target.Title;
            Assert.AreEqual(expected, actual);
        }

    }
}
