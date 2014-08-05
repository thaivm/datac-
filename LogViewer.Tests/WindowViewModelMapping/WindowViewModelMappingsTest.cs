using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogViewer.WindowViewModelMapping;
using LogViewer.ViewModel;
using LogViewer.View;
using LogViewer.Model;

namespace LogViewer.Tests.WindowViewModelMapping
{
    [TestClass]
    public class WindowViewModelMappingsTest
    {
        [TestMethod]
        public void WindowViewModelMappingsDoTest()
        {
            var target = new WindowViewModelMappings();
            Assert.IsNotNull(target);
        }
        [TestMethod]
        public void WindowViewModelMappingsDoTest1()
        {
            var target = new WindowViewModelMappings();
            var expected = typeof(EditFilterSettingView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(EditCCSFilterSettingViewModel));
            Assert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void WindowViewModelMappingsDoTest2()
        {
            var target = new WindowViewModelMappings();
            var expected = typeof(EditFilterSettingView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(EditCXDIFilterSettingViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WindowViewModelMappingsDoTest3()
        {
            var target = new WindowViewModelMappings();
            var expected = typeof(KeywordCountSettingView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(EditCCSKeywordCountSettingViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WindowViewModelMappingsDoTest4()
        {
            var target = new WindowViewModelMappings();
            var expected = typeof(KeywordCountSettingView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(EditCXDIKeywordCountSettingViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WindowViewModelMappingsDoTest5()
        {
            var target = new WindowViewModelMappings();
            var expected = typeof(PatternManagerView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(EditPatternSettingViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WindowViewModelMappingsDoTest6()
        {
            var target = new WindowViewModelMappings();
            var expected = typeof(SearchKeywordView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(SearchKeywordViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WindowViewModelMappingsDoTest7()
        {
            var target = new WindowViewModelMappings();
            var expected = typeof(MoveToLine);
            var actual = target.GetWindowTypeFromViewModelType(typeof(JumpToLineViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WindowViewModelMappingsDoTest8()
        {
            var target = new WindowViewModelMappings();
            var expected = typeof(LoadingDialog);
            var actual = target.GetWindowTypeFromViewModelType(typeof(LoadingDialogViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WindowViewModelMappingsDoTest9()
        {
            var target = new WindowViewModelMappings();
            var expected = typeof(MoveToTime);
            var actual = target.GetWindowTypeFromViewModelType(typeof(JumpToTimeViewModel<CCSLogRecord>));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WindowViewModelMappingsDoTest10()
        {
            var target = new WindowViewModelMappings();
            var expected = typeof(MoveToTime);
            var actual = target.GetWindowTypeFromViewModelType(typeof(JumpToTimeViewModel<CXDILogRecord>));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WindowViewModelMappingsDoTest11()
        {
            var target = new WindowViewModelMappings();
            var expected = typeof(SetFontStyleDialog);
            var actual = target.GetWindowTypeFromViewModelType(typeof(SetFontStyleDialogViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WindowViewModelMappingsDoTest12()
        {
            var target = new WindowViewModelMappings();
            var expected = typeof(PatternItemView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(PatternItemViewModel));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WindowViewModelMappingsDoTest13()
        {
            var target = new WindowViewModelMappings();
            var expected = typeof(LogDisplaySettingView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(SetLogDisplayViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WindowViewModelMappingsDoTest14()
        {
            var target = new WindowViewModelMappings();
            var expected = typeof(GraphView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(GraphViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WindowViewModelMappingsDoTest15()
        {
            var target = new WindowViewModelMappings();
            var expected = typeof(SetRangeOfGraphView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(SetRangeOfGraphViewModel));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WindowViewModelMappingsDoTest16()
        {
            var target = new WindowViewModelMappings();
            var expected = typeof(ExportFileNameDialogView);
            var actual = target.GetWindowTypeFromViewModelType(typeof(MessageBoxExportViewModel));
            Assert.AreEqual(expected, actual);
        }

    }
}
