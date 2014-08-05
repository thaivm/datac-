using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogViewer.Service.FrameworkDialogs;
using System.Windows;

namespace LogViewer.Tests.Service.FrameworkDialogs
{
    [TestClass]
    public class WindowWrapperTest
    {
        [TestMethod]
        public void ContructorTest()
        {
            var owner = new Window();
            var target = new WindowWrapper(owner);
            Assert.IsNotNull(target);
        }
        [TestMethod]
        public void HandleTest()
        {
            var owner = new Window();
            var target = new WindowWrapper(owner);
            Assert.IsNotNull(target.Handle);
        }
    }
}
