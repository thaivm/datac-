using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class present for loading dialog
    /// </summary>
    public class LoadingDialogViewModel : BaseWindowViewModel
    {
        /// <summary>
        /// Get set Message in loading dialog
        /// </summary>
        public string LoadingText { get; set; }
        /// <summary>
        /// Get set Title in loading dialog
        /// </summary>
        public string LoadingTitle { get; set; }
        /// <summary>
        /// Initializes a new instance of the LoadingDialogViewModel class.
        /// </summary>
        public LoadingDialogViewModel()
        {
            LoadingText = Properties.Resources.Loading_Summary;
            LoadingTitle = Properties.Resources.Loading_Window_Title;
        }
        /// <summary>
        /// Execute while Loading dialog showing
        /// </summary>
        /// <param name="action">Main action when loading dialog is showing</param>
        /// <param name="ownerWindowVM">Parent window of loading dialog</param>
        /// <param name="onCompleteAction">Action run when main action is done</param>
        public void ExecuteWhilePopUpLoading(Action action, object ownerWindowVM, Action onCompleteAction)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = false;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler((sender, arg) =>
            {
                action();
            });
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler((sender, arg) =>
            {
                System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() =>
                    {
                        this.CloseDialog();
                        
                    }), priority: System.Windows.Threading.DispatcherPriority.SystemIdle);
                if (onCompleteAction != null)
                    onCompleteAction();
            }
            );
            
            worker.RunWorkerAsync();
            this.ShowDialog(ownerWindowVM);
        }
    }
}
