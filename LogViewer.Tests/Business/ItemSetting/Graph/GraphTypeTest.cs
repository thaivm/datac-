using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogViewer.Business;

namespace LogViewer.Tests.Business.ItemSetting.Graph
{
    [TestClass]
    public class GraphTypeTest
    {
        [TestMethod]
        public void EventTest()
        {
            var target = new GraphType();
            target = GraphType.Event;
            var expected = GraphType.Event;

            Assert.AreEqual(expected, target);
        }
        [TestMethod]
        public void EventTest1()
        {
            var target = new GraphType();
            target = GraphType.Event;
            var expected = GraphType.Value;

            Assert.AreNotEqual(expected, target);
        }
        [TestMethod]
        public void ValueTest()
        {
            var target = new GraphType();
            target = GraphType.Value;
            var expected = GraphType.Value;

            Assert.AreEqual(expected, target);
        }
        [TestMethod]
        public void ValueTest1()
        {
            var target = new GraphType();
            target = GraphType.Value;
            var expected = GraphType.Event;

            Assert.AreNotEqual(expected, target);
        }

    }
}
