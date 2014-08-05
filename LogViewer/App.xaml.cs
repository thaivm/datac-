using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows;
using System.IO;
using LogViewer.Service;
using LogViewer.WindowViewModelMapping;
using LogViewer.Service.FrameworkDialogs.OpenFile;
using LogViewer.Service.FrameworkDialogs.SaveFile;
using System.Windows.Forms;

namespace LogViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
            ServiceLocator.RegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
            ServiceLocator.Register<IOpenFileDialog, OpenFileDialogViewModel>();
            ServiceLocator.Register<ISaveFileDialog, SaveFileDialogViewModel>();
            string fileConfig = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + System.IO.Path.DirectorySeparatorChar + "FileConfig";
            if (!Directory.Exists(fileConfig))
            {
                Directory.CreateDirectory(fileConfig);
            }
            
            //MessageBoxManager.OK = LocalResource.OK;
            MessageBoxManager.Cancel = LogViewer.Properties.Resources.Cancel;
            //MessageBoxManager.Retry = LogViewer.Properties.Resources.Merge;
            //MessageBoxManager.Ignore = LogViewer.Properties.Resources.Replace;
            //MessageBoxManager.Abort = LogViewer.Properties.Resources.Replace;
            //MessageBoxManager.Yes = LogViewer.Properties.Resources.Merge;
            //MessageBoxManager.No = LogViewer.Properties.Resources.Replace;
            MessageBoxManager.Yes = LogViewer.Properties.Resources.Yes;
            MessageBoxManager.No = LogViewer.Properties.Resources.No;

            //Register manager
            MessageBoxManager.Register();
        }
    }
}
