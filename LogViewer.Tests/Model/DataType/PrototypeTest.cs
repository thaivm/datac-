using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogViewer.Model;

namespace LogViewer.Tests.Model.DataType
{
    [TestClass]
    public class PrototypeTest
    {
        [TestMethod]
        public void PrototypeEnumTest()
        {
            var target = new Prototype();
            Assert.IsNotNull(target);
        }
        [TestMethod]
        public void PrototypeEnumTest1()
        {
            var target = new Prototype();
            target = Prototype.BlackCircle;
            Assert.AreEqual(Prototype.BlackCircle,target);
        }
        [TestMethod]
        public void PrototypeEnumTest2()
        {
            var target = new Prototype();
            target = Prototype.BlackSquare;
            Assert.AreEqual(Prototype.BlackSquare, target);
        }
        [TestMethod]
        public void PrototypeEnumTest3()
        {
            var target = new Prototype();
            target = Prototype.BlackStar;
            Assert.AreEqual(Prototype.BlackStar, target);
        }
        [TestMethod]
        public void PrototypeEnumTest4()
        {
            var target = new Prototype();
            target = Prototype.BlackTriangle;
            Assert.AreEqual(Prototype.BlackTriangle, target);
        }
        [TestMethod]
        public void PrototypeEnumTest5()
        {
            var target = new Prototype();
            target = Prototype.WhiteCircle;
            Assert.AreEqual(Prototype.WhiteCircle, target);
        }
        [TestMethod]
        public void PrototypeEnumTest6()
        {
            var target = new Prototype();
            target = Prototype.WhiteSquare;
            Assert.AreEqual(Prototype.WhiteSquare, target);
        }
        [TestMethod]
        public void PrototypeEnumTest7()
        {
            var target = new Prototype();
            target = Prototype.WhiteStar;
            Assert.AreEqual(Prototype.WhiteStar, target);
        }
        [TestMethod]
        public void PrototypeEnumTest8()
        {
            var target = new Prototype();
            target = Prototype.WhiteTriangle;
            Assert.AreEqual(Prototype.WhiteTriangle, target);
        }

    }
}
