using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LogViewer.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogViewer.Tests.View
{
    [TestClass]
    public class ExportFileNameDialogViewTest
    {
        [TestMethod]
        public void InitComponentTest()
        {
            var target = new ExportFileNameDialogView();
            Assert.IsNotNull(target);
            target.Close();
        }

        [TestMethod]
        public void btnOK_ClickTest()
        {
            var target = new ExportFileNameDialogView();
            target.Show();
            target.btnOK.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, target.btnOK));


        }
        [TestMethod]
        public void Window_LoadedTest()
        {
            var target = new ExportFileNameDialogView();

            target.Show();
            target.Close();

        }
    }
}
