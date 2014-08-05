using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogViewer.Business;
using LogViewer.Model;

namespace LogViewer.Tests.Model.ModelInterface
{
    [TestClass]
    public class ICopyableTest
    {
        [TestMethod]
        public void ICopyableDoTest()
        {
            ICopyable<GraphParamSetting> target = new GraphParamSetting();
            var actual = target.Copy();

            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void ICopyableDoTest1()
        {
            ICopyable<GraphParamSetting> target = new GraphParamSetting();
            var actual = target.GetType();
            var expected = typeof(GraphParamSetting);
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void ICopyableDoTest2()
        {
            ICopyable<FilterItemSetting> target = new FilterItemSetting();
            var actual = target.Copy();

            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void ICopyableDoTest3()
        {
            ICopyable<FilterItemSetting> target = new FilterItemSetting();
            var actual = target.GetType();
            var expected = typeof(FilterItemSetting);
            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void ICopyableDoTest4()
        {
            ICopyable<KeywordCountItemSetting> target = new KeywordCountItemSetting();
            var actual = target.Copy();

            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void ICopyableDoTest5()
        {
            ICopyable<KeywordCountItemSetting> target = new KeywordCountItemSetting();
            var actual = target.GetType();
            var expected = typeof(KeywordCountItemSetting);
            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void ICopyableDoTest6()
        {
            ICopyable<GraphRangeSetting> target = new GraphRangeSetting();
            var actual = target.Copy();

            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void ICopyableDoTest7()
        {
            ICopyable<GraphRangeSetting> target = new GraphRangeSetting();
            var actual = target.GetType();
            var expected = typeof(GraphRangeSetting);
            Assert.IsNotNull(actual);
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ICopyableDoTest8()
        {
            ICopyable<PatternItemSetting> target = new PatternItemSetting();
            
            var actual = target.Copy();

            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void ICopyableDoTest9()
        {
            ICopyable<PatternItemSetting> target = new PatternItemSetting();
            var actual = target.GetType();
            var expected = typeof(PatternItemSetting);
            Assert.IsNotNull(actual);
        }

    }
}
