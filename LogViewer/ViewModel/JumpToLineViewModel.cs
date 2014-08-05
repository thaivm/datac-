using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.MVVMHelper;
using LogViewer.Service;
using System.Windows.Input;
using LogViewer.Model;

namespace LogViewer.ViewModel
{
        /// <summary>
    /// Class describing and processing for go to line.
    /// </summary>
    public class JumpToLineViewModel : BaseWindowViewModel
    {
        /// <summary>
        /// Action jump to line in grid by line.
        /// </summary>
        public event Action<int> OnJumpToLineNumberEvent;

        /// <summary>
        /// Get or set error message.
        /// </summary>
        protected string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        /// <summary>
        /// Get or set line.
        /// </summary>
        protected string _line;
        public string Line
        {
            get 
            {
                return _line;
            }
            set
            {
                _line = value;
                OnPropertyChanged("Line");
            }
        }

        /// <summary>
        /// Total line in grid.
        /// </summary>
        public int MaximumLineNumber { get; set; }

        /// <summary>
        /// Initializes a new instances of the JumpToLineViewModel class.
        /// <param name="maximumLineNumber">Total line in grid</param>
        /// </summary>
        public JumpToLineViewModel(int maximumLineNumber)
        {
            MaximumLineNumber = maximumLineNumber;
            Message = Properties.Resources.Max + maximumLineNumber;
        }

        /// <summary>
        /// Get or set Command of button jump to line.
        /// </summary>
        protected DelegateCommand _jumpToLineCommand;
        public ICommand JumpToLineCommand
        {
            get
            {
                if (_jumpToLineCommand == null)
                {
                    _jumpToLineCommand = new DelegateCommand(JumpToLineCommandCL, () => 
                    {
                        if (Line == null || Line.Trim().Equals(String.Empty))
                        {
                            return false;
                        }
                        try
                        {
                            if (Convert.ToInt32(Line) >= 1 && Convert.ToInt32(Line) <= MaximumLineNumber)
                            {
                                return true;
                            }
                        }
                        catch {
                        //Convert error, cannot jumb to line
                        }
                        return false;
                    });
                }
                return _jumpToLineCommand;
            }
        }

        /// <summary>
        /// Function callback when button jump to line.
        /// </summary>
        protected virtual void JumpToLineCommandCL()
        {
            if (OnJumpToLineNumberEvent != null)
            {
                OnJumpToLineNumberEvent(Convert.ToInt32(Line));
            }
        }
    }
}
