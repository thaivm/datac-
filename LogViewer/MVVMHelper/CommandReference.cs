using System;
using System.Windows;
using System.Windows.Input;

namespace LogViewer.MVVMHelper
{
    /// <summary>
    /// This class facilitates associating a key binding in XAML markup to a command
    /// defined in a View Model by exposing a Command dependency property.
    /// The class derives from Freezable to work around a limitation in WPF when data-binding from XAML.
    /// </summary>
    public class CommandReference : Freezable, ICommand
    {
        /// <summary>
        /// Initializes the <see cref="T:CommandReference"/> class.
        /// </summary>
        public CommandReference()
        {
            // Blank
        }
        /// <summary>
        /// Dependency property for the Command property.
        /// </summary>
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(CommandReference), new PropertyMetadata(new PropertyChangedCallback(OnCommandChanged)));
        /// <summary>
        /// The value to match against the input value.
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        #region ICommand Members
        /// <summary>
        /// Check Command can execute.
        /// <param name="parameter">Parameter to executer</param>
        /// <returns>A boolean value. true is can execute : false is cannot execute</returns>
        /// </summary>
        public bool CanExecute(object parameter)
        {
            if (Command != null)
                return Command.CanExecute(parameter);
            return false;
        }
        /// <summary>
        /// Execute command
        /// <param name="parameter">Parameter to executer</param>
        /// </summary>
        public void Execute(object parameter)
        {
            Command.Execute(parameter);
        }

        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// When command changed.Set value to oldCommand and newCommand.
        /// <param name="d">Dependency object</param>
        /// <param name="e">Dependency property changed event</param>
        /// </summary>
        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommandReference commandReference = d as CommandReference;
            ICommand oldCommand = e.OldValue as ICommand;
            ICommand newCommand = e.NewValue as ICommand;

            if (oldCommand != null)
            {
                oldCommand.CanExecuteChanged -= commandReference.CanExecuteChanged;
            }
            if (newCommand != null)
            {
                newCommand.CanExecuteChanged += commandReference.CanExecuteChanged;
            }
        }

        #endregion

        #region Freezable

        protected override Freezable CreateInstanceCore()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
