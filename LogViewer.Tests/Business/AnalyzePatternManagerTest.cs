using System;
using System.ComponentModel;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using LogViewer.Business;
using LogViewer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.Business
{
    [TestClass]
    class AnalyzePatternManagerTest
    {
        public void GetPatternAnalyzeInstanceTest()
        {
            IAnalyzePattern<CCSLogRecord> target = AnalyzePatternManager.GetPatternAnalyzeInstance<CCSLogRecord>();
            Assert.IsNotNull(target);

        }
        public void GetPatternAnalyzeInstanceTest1()
        {
            IAnalyzePattern<CCSLogRecord> target = AnalyzePatternManager.GetPatternAnalyzeInstance<CCSLogRecord>();
            var expected = typeof(AnalyzePattern<CCSLogRecord>);
            Assert.AreEqual(expected, target.GetType());
            
        }
        public void GetPatternAnalyzeInstanceTest2()
        {
            IAnalyzePattern<CXDILogRecord> target = AnalyzePatternManager.GetPatternAnalyzeInstance<CXDILogRecord>();
            Assert.IsNotNull(target);

        }
        public void GetPatternAnalyzeInstanceTest3()
        {
            IAnalyzePattern<CXDILogRecord> target = AnalyzePatternManager.GetPatternAnalyzeInstance<CXDILogRecord>();
            var expected = typeof(AnalyzePattern<CXDILogRecord>);
            Assert.AreEqual(expected, target.GetType());

        }
    }
}
