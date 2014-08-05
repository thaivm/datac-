using LogViewer.Service.FrameworkDialogs.FolderBrowse;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using LogViewer.Service;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using LogViewer.Service.FrameworkDialogs;
using System.Windows;
using Moq;
using WinFormsFolderBrowserDialog = System.Windows.Forms.FolderBrowserDialog;
using Microsoft.VisualStudio.TestTools.UITest;
namespace LogViewer.Tests
{


    [TestClass()]
    public class FolderBrowserDialogTest
    {
        [TestMethod]
        public void FolderBrowserDialogConstrutorTest()
        {

            IFolderBrowserDialog parrent = new FolderBrowserDialogViewModel();
            var target = new LogViewer.Service.FrameworkDialogs.FolderBrowse.FolderBrowserDialog(parrent);
            Assert.IsNotNull(target);
        }
        [TestMethod]
        public void DisposeTest()
        {

            IFolderBrowserDialog parrent = new FolderBrowserDialogViewModel();
            var releaserMock = new Mock<IDisposable>();
            var target = new Mock<LogViewer.Service.FrameworkDialogs.FolderBrowse.FolderBrowserDialog>(parrent);
            target.Object.Dispose();
            try
            {
                target.Object.Dispose();
            }
            catch (ObjectDisposedException e)
            {
                Assert.IsTrue(true);
            }

        }
    }
}
