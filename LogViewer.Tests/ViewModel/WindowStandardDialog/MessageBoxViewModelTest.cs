using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogViewer.ViewModel;
using System.Windows;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using Moq;

namespace LogViewer.Tests.ViewModel.WindowStandardDialog
{
    [TestClass]
    public class MessageBoxViewModelTest
    {
        [TestInitialize()]
        public void MyTestInitialize()
        {
            if (!ServiceLocator.services.ContainsKey(typeof(IDialogService)))
            {
                ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
                ServiceLocator.RegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
                ServiceLocator.Register<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
                ServiceLocator.Register<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();
            }
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            ServiceLocator.UnRegisterSingleton<IDialogService, DialogService>();
            ServiceLocator.UnRegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
            ServiceLocator.UnRegister<IOpenFileDialog, LogViewer.ViewModel.OpenFileDialogViewModel>();
            ServiceLocator.UnRegister<ISaveFileDialog, LogViewer.ViewModel.SaveFileDialogViewModel>();

        }
        [TestMethod]
        public void ConstructorTest()
        {
            var target = new MessageBoxViewModel();
            Assert.IsNotNull(target);
        }
        [TestMethod]
        public void ShowDialogTest()
        {
            var owner = new Window();
            var target = new MessageBoxViewModel();
            target.ShowDialog(owner);
            owner.Loaded += (object sender,RoutedEventArgs arg) =>
            {
                Assert.IsTrue(true);
            };            
            owner.Close();
        }
        //[TestMethod]
        //public void ShowDialogDeleteTest()
        //{
        //    var owner = new Window();
        //    var mock = new Mock<MessageBoxViewModel>();
        //    mock.Setup((x=>x.ShowDialogDelete(owner))).Returns(MessageBoxResult.OK);
        //    var actual = mock.Object.ShowDialogDelete(owner);
            

        //}
        
    }
}
