using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogViewer.Business;
using LogViewer.Model;

namespace LogViewer.Tests.Business
{
    [TestClass]
    public class IAnalyzePatternTest
    {
        public void DoAnalyzeTest()
        {
            IAnalyzePattern<CCSLogRecord> target = AnalyzePatternManager.GetPatternAnalyzeInstance<CCSLogRecord>();
            Assert.IsNotNull(target);

        }
        public void DoAnalyzeTest1()
        {
            IAnalyzePattern<CCSLogRecord> target = AnalyzePatternManager.GetPatternAnalyzeInstance<CCSLogRecord>();
            var expected = typeof(AnalyzePattern<CCSLogRecord>);
            Assert.AreEqual(expected, target.GetType());

        }
        public void DoAnalyzeTest3()
        {
            IAnalyzePattern<CXDILogRecord> target = AnalyzePatternManager.GetPatternAnalyzeInstance<CXDILogRecord>();
            Assert.IsNotNull(target);

        }

        public void DoAnalyzeTest4()
        {
            IAnalyzePattern<CXDILogRecord> target = AnalyzePatternManager.GetPatternAnalyzeInstance<CXDILogRecord>();
            var expected = typeof(AnalyzePattern<CXDILogRecord>);
            Assert.AreEqual(expected, target.GetType());

        }
    }
}
