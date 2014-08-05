using System;
using System.Collections.Generic;
using LogViewer.Business;
using LogViewer.Model;
using LogViewer.Service;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.ViewModel;
using LogViewer.WindowViewModelMapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LogViewer.Tests.ViewModel.ViewModelInterface
{
    [TestClass]
    public class ILogsDisplayContainerTest
    {
        [TestInitialize()]
        public void SetUp()
        {
            if (!ServiceLocator.services.ContainsKey(typeof(IDialogService)))
            {
                ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
                ServiceLocator.RegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
                ServiceLocator.Register<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
                ServiceLocator.Register<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
            }
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            ServiceLocator.UnRegisterSingleton<IDialogService, DialogService>();
            ServiceLocator.UnRegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
            ServiceLocator.UnRegister<IOpenFileDialog, LogViewer.Service.FrameworkDialogs.OpenFile.OpenFileDialogViewModel>();
            ServiceLocator.UnRegister<ISaveFileDialog, LogViewer.Service.FrameworkDialogs.SaveFile.SaveFileDialogViewModel>();
        }
        [TestMethod]
        public void ILogsDisplayContainerDoTest()
        {
              Action<CCSLogRecord> onAddBookmarkEvent = (CCSLog) => { };
            Action<CCSLogRecord> onRemoveBookmarkEvent = (CCSLog) => { };
            Action<CCSLogRecord> onUpdateRecordFileName = (CCSLog) => { };
            Action<string, string> onFollowOtherLogEvent = (str1, str2) => { };
            Action<CCSLogRecord, AnalyzedPatternResultItem<CCSLogRecord>> onShowPatternColoringRecord = (CCSLog, AnalyzePattern) => { };
            var logDisplay = new List<LogDisplay>();
            var SettingManger = new CCSSettingManager();
            ILogsDisplayContainer<CCSLogRecord> target = new CCSLogsDisplayViewModel(onAddBookmarkEvent, onRemoveBookmarkEvent, onUpdateRecordFileName, onFollowOtherLogEvent, onShowPatternColoringRecord, logDisplay, SettingManger, null);
            var expected = target.GetType();
            var actual = typeof(CCSLogsDisplayViewModel);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void ILogsDisplayContainerDoTest1()
        {
            Action<CXDILogRecord> onAddBookmarkEvent = (CXDILog) => { };
            Action<CXDILogRecord> onRemoveBookmarkEvent = (CXDILog) => { };
            Action<CXDILogRecord> onUpdateRecordFileName = (CXDILog) => { };
            Action<string, string> onFollowOtherLogEvent = (str1, str2) => { };
            Action<CXDILogRecord, AnalyzedPatternResultItem<CXDILogRecord>> onShowPatternColoringRecord = (CCSLog, AnalyzePattern) => { };
            var logDisplay = new List<LogDisplay>();
            var SettingManger = new CCSSettingManager();
            ILogsDisplayContainer<CXDILogRecord> target = new CXDILogsDisplayViewModel(onAddBookmarkEvent, onRemoveBookmarkEvent, onUpdateRecordFileName, onFollowOtherLogEvent, onShowPatternColoringRecord, logDisplay, SettingManger, null);
            var expected = target.GetType();
            var actual = typeof(CXDILogsDisplayViewModel);
            Assert.AreEqual(expected, actual);

        }
    }
}
