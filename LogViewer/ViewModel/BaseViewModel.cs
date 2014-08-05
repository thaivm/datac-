using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
namespace LogViewer.ViewModel
{
    /// <summary> 
    /// Provides common functionality for ViewModel classes 
    /// </summary> 
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}

