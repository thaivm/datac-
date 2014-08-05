using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.MVVMHelper;
using System.Windows.Input;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class for base window of application
    /// </summary>
    /// /// <typeparam name="T">The type of window ViewModel.
    /// </typeparam>
    public abstract class BaseApplyWindowViewModel<T> : BaseWindowViewModel
    {
        /// <summary>
        /// Action of button apply in window.
        /// </summary>
        protected event Action<T> OnApplyEvent;
        /// <summary>
        /// Initializes OnApplyEvent.
        /// </summary>
        /// /// <param name="onApplyEvent">Action subscribing to the apply event.</param>
        public void SetApplyEvent(Action<T> applyEvent)
        {
            OnApplyEvent = applyEvent;
        }

        /// <summary>
        /// Initializes a new instances of the BaseApplyWindowViewModel class.
        /// </summary>
        /// <param name="onApplyEvent">Action subscribing to the apply event.</param>
        protected BaseApplyWindowViewModel(Action<T> onApplyEvent)
        {
            OnApplyEvent = onApplyEvent;
        }

        /// <summary>
        /// Get or set Command of button Apply
        /// </summary>
        protected DelegateCommand _applyCommand;
        public ICommand ApplyCommand
        {
            get
            {
                if (_applyCommand == null)
                {
                    _applyCommand = new DelegateCommand(ApplyCL, () => CanApply);
                }
                return _applyCommand;
            }
        }
        /// <summary>
        /// Function callback when click button apply
        /// </summary>
        protected virtual void ApplyCL()
        {
            OnApplyEvent(GetDataToApply());
        }
        /// <summary>
        /// Get or set Command of button OK
        /// </summary>
        protected DelegateCommand _okCommand;
        public ICommand OkCommand
        {
            get
            {
                if (_okCommand == null)
                {
                    _okCommand = new DelegateCommand(OkCL, () => CanApply);
                }
                return _okCommand;
            }
        }
        /// <summary>
        /// Function callback when click button OK
        /// </summary>
        protected virtual void OkCL()
        {
            this.CloseDialog();
            OnApplyEvent(GetDataToApply());
        }
        /// <summary>
        /// Get data type to apply
        /// </summary>
        protected abstract T GetDataToApply();

        /// <summary>
        /// Check can execute button apply and OK
        /// </summary>
        protected virtual bool CanApply
        {
            get
            {
                return true;
            }
        }
    }
}
