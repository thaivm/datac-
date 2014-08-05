using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogViewer.WindowViewModelMapping;
using LogViewer.View;
using LogViewer.ViewModel;
using LogViewer.Model;

namespace LogViewer.Tests.WindowViewModelMapping
{
    [TestClass]
    public class IWindowViewModelMappingsTest
    {
        [TestMethod]
        public void IWindowViewModelMappingsDoTest()
        {
            IWindowViewModelMappings target = new WindowViewModelMappings();
            Assert.IsNotNull(target);
        }
        [TestMethod]
        public void IWindowViewModelMappingsDoTest1()
        {
            IWindowViewModelMappings target = new WindowViewModelMappings();
            var expected = typeof(EditFilterSettingView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(EditCCSFilterSettingViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IWindowViewModelMappingsDoTest2()
        {
            IWindowViewModelMappings target = new WindowViewModelMappings();
            var expected = typeof(EditFilterSettingView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(EditCXDIFilterSettingViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IWindowViewModelMappingsDoTest3()
        {
            IWindowViewModelMappings target = new WindowViewModelMappings();
            var expected = typeof(KeywordCountSettingView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(EditCCSKeywordCountSettingViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IWindowViewModelMappingsDoTest4()
        {
            IWindowViewModelMappings target = new WindowViewModelMappings();
            var expected = typeof(KeywordCountSettingView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(EditCXDIKeywordCountSettingViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IWindowViewModelMappingsDoTest5()
        {
            IWindowViewModelMappings target = new WindowViewModelMappings();
            var expected = typeof(PatternManagerView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(EditPatternSettingViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IWindowViewModelMappingsDoTest6()
        {
            IWindowViewModelMappings target = new WindowViewModelMappings();
            var expected = typeof(SearchKeywordView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(SearchKeywordViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IWindowViewModelMappingsDoTest7()
        {
            IWindowViewModelMappings target = new WindowViewModelMappings();
            var expected = typeof(MoveToLine);
            var actual = target.GetWindowTypeFromViewModelType(typeof(JumpToLineViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IWindowViewModelMappingsDoTest8()
        {
            IWindowViewModelMappings target = new WindowViewModelMappings();
            var expected = typeof(LoadingDialog);
            var actual = target.GetWindowTypeFromViewModelType(typeof(LoadingDialogViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IWindowViewModelMappingsDoTest9()
        {
            IWindowViewModelMappings target = new WindowViewModelMappings();
            var expected = typeof(MoveToTime);
            var actual = target.GetWindowTypeFromViewModelType(typeof(JumpToTimeViewModel<CCSLogRecord>));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IWindowViewModelMappingsDoTest10()
        {
            IWindowViewModelMappings target = new WindowViewModelMappings();
            var expected = typeof(MoveToTime);
            var actual = target.GetWindowTypeFromViewModelType(typeof(JumpToTimeViewModel<CXDILogRecord>));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IWindowViewModelMappingsDoTest11()
        {
            IWindowViewModelMappings target = new WindowViewModelMappings();
            var expected = typeof(SetFontStyleDialog);
            var actual = target.GetWindowTypeFromViewModelType(typeof(SetFontStyleDialogViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IWindowViewModelMappingsDoTest12()
        {
            IWindowViewModelMappings target = new WindowViewModelMappings();
            var expected = typeof(PatternItemView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(PatternItemViewModel));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IWindowViewModelMappingsDoTest13()
        {
            IWindowViewModelMappings target = new WindowViewModelMappings();
            var expected = typeof(LogDisplaySettingView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(SetLogDisplayViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IWindowViewModelMappingsDoTest14()
        {
            IWindowViewModelMappings target = new WindowViewModelMappings();
            var expected = typeof(GraphView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(GraphViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IWindowViewModelMappingsDoTest15()
        {
            IWindowViewModelMappings target = new WindowViewModelMappings();
            var expected = typeof(SetRangeOfGraphView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(SetRangeOfGraphViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IWindowViewModelMappingsDoTest16()
        {
            IWindowViewModelMappings target = new WindowViewModelMappings();
            var expected = typeof(ExportFileNameDialogView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(MessageBoxExportViewModel));
            Assert.AreEqual(expected, actual);
        }
    }
}
