// File:    FirmwareInfoTabViewModel.cs
// Author:  CuongPNB
// Created: Friday, April 18, 2014 11:13:23 AM
// Purpose: Definition of Class FirmwareInfoTabViewModel

using System;
using LogViewer.Model;
using LogViewer.MVVMHelper;
using System.Windows.Input;
using System.Text;
using System.Windows;
using System.Collections.Generic;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class describing the firmware information of cxdi log.
    /// </summary>
    public class FirmwareInfoTabViewModel : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instances of the FirmwareInfoTabViewModel class.
        /// </summary>
        public FirmwareInfoTabViewModel()
        {

        }

        protected CXDIFirmware _cXDIFirmware;
        /// <summary>
        /// Get or set <see cref="CXDIFirmware"/>
        /// </summary>
        public CXDIFirmware CXDIFirmware
        {
            get
            {
                if (_cXDIFirmware == null)
                {
                    _cXDIFirmware = new CXDIFirmware();
                }
                return _cXDIFirmware;
            }
            set
            {
                _cXDIFirmware = value;
                OnPropertyChanged("CXDIFirmware");
            }
        }

        protected IList<object> _selectedItemsCounter;
        /// <summary>
        /// Get or set Selected item in counter firmware.
        /// </summary>
        public IList<object> SelectedItemsCounter
        {
            get
            {
                return _selectedItemsCounter;
            }
            set
            {
                _selectedItemsCounter = value;
                OnPropertyChanged("SelectedItemsCounter");
            }
        }

        protected IList<object> _selectedItemsSaved;
        /// <summary>
        /// Get or set Selected item in saved firmware.
        /// </summary>
        public IList<object> SelectedItemsSaved
        {
            get
            {
                return _selectedItemsSaved;
            }
            set
            {
                _selectedItemsSaved = value;
                OnPropertyChanged("SelectedItemsSaved");
            }
        }


        /// <summary>
        /// Clear data in firmware tab.
        /// </summary>
        public void ClearData()
        {
            CXDIFirmware = new CXDIFirmware();
        }

        /// <summary>
        /// Get or set Command of event copy.
        /// </summary>
        protected DelegateCommand _copyCommand;
        public ICommand CopyCommand
        {
            get
            {
                if (_copyCommand == null)
                {
                    _copyCommand = new DelegateCommand(CopyCommandCL, () => IsEnableCopy());
                }
                return _copyCommand;
            }
        }
        /// <summary>
        /// Check can execute copy
        /// </summary>
        protected bool IsEnableCopy()
        {
            return IsEnableCopyCounter() || IsEnableCopySaved();
        }

        /// <summary>
        /// Check can execute copy counter
        /// </summary>
        protected bool IsEnableCopyCounter()
        {
            if (SelectedItemsCounter == null || SelectedItemsCounter.Count == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Check can execute copy saved
        /// </summary>
        protected bool IsEnableCopySaved()
        {
            if ((SelectedItemsSaved == null || SelectedItemsSaved.Count == 0))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Function callback when click copy
        /// </summary>
        protected void CopyCommandCL()
        {
            StringBuilder builder = new StringBuilder();

            foreach (Counter i in SelectedItemsCounter)
            {
                builder.Append(i.parameter);
                builder.Append(",");
                builder.Append(i.value);
                builder.Append("\r\n");
            }
            foreach (Saved i in SelectedItemsSaved)
            {
                builder.Append(i.parameter);
                builder.Append(",");
                builder.Append(i.value);
                builder.Append("\r\n");
            }
            Clipboard.SetText(builder.ToString());
        }
    }
}