using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Service;
using System.Windows.Input;
using LogViewer.MVVMHelper;

namespace LogViewer.ViewModel
{
    public class BaseWindowViewModel : BaseViewModel, IClosableDialog
    {
        static IDialogService _dialogService;

        /// <summary>
        /// Returns the status of window is show or not show.
        /// </summary>
        public bool IsShow { get; set; }
        /// <summary>
        /// Returns the status of window is type CCS or CXDI.
        /// </summary>
        public bool IsCCS { get; set; }
        /// <summary>
        /// Initializes a new instances of the BaseWindowViewModel class.
        /// </summary>
        static BaseWindowViewModel()
        {
            _dialogService = ServiceLocator.Resolve<IDialogService>();
        }

        /// <summary>
        /// Function Show a dialog window when open it, cannot use parent window,
        /// override it to determine the value on-demand.
        /// </summary>
        /// <param name="ownerWindowVM">Parent window that window need show</param>
        public virtual void ShowDialog(object ownerWindowVM)
        {
            _dialogService.ShowDialog(ownerWindowVM, this);
        }

        /// <summary>
        /// Function Show a window when open it, can use parent window,
        /// override it to determine the value on-demand.
        /// </summary>
        /// <param name="ownerWindowVM">Parent window that window need show</param>
        public virtual void Show(object ownerWindowVM)
        {
            if (IsShow == false)
            {
                IsShow = true;
                _dialogService.Show(ownerWindowVM, this);
            }
            else
            {
                foreach (var view in _dialogService.Views)
                {
                    var dataContext = view.DataContext;
                    if (dataContext.GetType().Equals(this.GetType()))
                    {
                        if (view is View.GraphView)
                        {
                            View.GraphView sender = view as View.GraphView;
                            sender.WindowState = System.Windows.WindowState.Normal;
                            sender.Focus();
                        }
                        if (view is View.EditFilterSettingView)
                        {
                            View.EditFilterSettingView sender = view as View.EditFilterSettingView;
                            if ((IsCCS && sender.Title.Contains("CCS")) || (!IsCCS && sender.Title.Contains("CXDI")))
                            {
                                sender.WindowState = System.Windows.WindowState.Normal;
                                sender.Focus();
                            }
                        }
                        if (view is View.KeywordCountSettingView)
                        {
                            View.KeywordCountSettingView sender = view as View.KeywordCountSettingView;
                            if ((IsCCS && sender.Title.Contains("CCS")) || (!IsCCS && sender.Title.Contains("CXDI")))
                            {
                                sender.WindowState = System.Windows.WindowState.Normal;
                                sender.Focus();
                            }
                        }
                        if (view is View.PatternManagerView)
                        {
                            View.PatternManagerView sender = view as View.PatternManagerView;
                            if ((IsCCS && sender.Title.Contains("CCS")) || (!IsCCS && sender.Title.Contains("CXDI")))
                            {
                                sender.WindowState = System.Windows.WindowState.Normal;
                                sender.Focus();
                            }
                        }
                        if (view is View.SearchKeywordView)
                        {
                            View.SearchKeywordView sender = view as View.SearchKeywordView;
                            sender.WindowState = System.Windows.WindowState.Normal;
                            sender.Focus();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Function CloseDialog call Action close defined by each window,
        /// override it to determine the value on-demand.
        /// </summary>
        public virtual void CloseDialog()
        {
            if (CloseAction != null)
            {
                IsShow = false;
                CloseAction();
                CloseAction = null;
            }
        }

        #region IClosableDialog Members

        public event Action CloseAction;

        #endregion

        /// <summary>
        /// Trigger when closing window,
        /// override it to determine the value on-demand.
        /// </summary>
        public virtual void dialog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsShow = false;
            if (sender is View.GraphView)
            {
                View.GraphView child = (View.GraphView)sender;
                View.MainWindow owner = child.Owner as View.MainWindow;
                owner.Focus();
            }
            if (sender is View.SearchKeywordView)
            {
                View.SearchKeywordView child = (View.SearchKeywordView)sender;
                View.MainWindow owner = child.Owner as View.MainWindow;
                owner.Focus();
            }
            if (sender is View.EditFilterSettingView)
            {
                View.EditFilterSettingView child = (View.EditFilterSettingView)sender;
                View.MainWindow owner = child.Owner as View.MainWindow;
                owner.Focus();
            }
            if (sender is View.KeywordCountSettingView)
            {
                View.KeywordCountSettingView child = (View.KeywordCountSettingView)sender;
                View.MainWindow owner = child.Owner as View.MainWindow;
                owner.Focus();
            }
            if (sender is View.PatternManagerView)
            {
                View.PatternManagerView child = (View.PatternManagerView)sender;
                View.MainWindow owner = child.Owner as View.MainWindow;
                owner.Focus();
            }
            if (sender is View.PatternItemView)
            {
                View.PatternItemView child = (View.PatternItemView)sender;
                View.PatternManagerView owner = child.Owner as View.PatternManagerView;
                owner.Focus();
            }
            if (sender is View.EditGraphParamSettingView)
            {
                View.EditGraphParamSettingView child = (View.EditGraphParamSettingView)sender;
                View.GraphView owner = child.Owner as View.GraphView;
                owner.Focus();
            }
            if (sender is View.SetRangeOfGraphView)
            {
                View.SetRangeOfGraphView child = (View.SetRangeOfGraphView)sender;
                View.GraphView owner = child.Owner as View.GraphView;
                owner.Focus();
            }
        }

        /// <summary>
        /// Get or set Command of button Cancel or Close
        /// </summary>
        protected DelegateCommand _closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new DelegateCommand(CloseCommandCL);
                }
                return _closeCommand;
            }
        }
        /// <summary>
        /// Function callback when click button Cancel or Close,
        /// override it to determine the value on-demand.
        /// </summary>
        protected virtual void CloseCommandCL()
        {
            this.CloseDialog();
        }
    }
}
