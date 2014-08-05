using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Microsoft.Windows.Controls;
using System.Collections.ObjectModel;
using LogViewer.Model;
using System.IO;
using LogViewer.View;
using System.Xml;
using LogViewer.MVVMHelper;
using LogViewer.Business;

namespace LogViewer.ViewModel
{
    /// <summary>
    /// Class provides methods for editing pattern setting item
    /// </summary>
    public class EditPatternSettingViewModel : BaseEditSettingViewModel<PatternItemSetting>
    {
        PatternItemViewModel _patternItemAddVM;
        PatternItemViewModel _patternItemEditVM;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="onApplyEvent"><see cref="Action<T>"/></param>
        public EditPatternSettingViewModel(Action<List<PatternItemSetting>> onApplyEvent) : base(onApplyEvent)
        {
            _patternItemAddVM = new PatternItemViewModel(x => ItemSettingList.Add(x));
            _patternItemAddVM.Title = Properties.Resources.AddPatternItem;
            _patternItemEditVM = new PatternItemViewModel(x => ItemSettingList.Add(x));
            _patternItemEditVM.Title = Properties.Resources.EditPatternItem;
        }
        /// <summary>
        /// Add pattern setting item
        /// </summary>
        protected override void AddItemSettingCL()
        {
            if (!_patternItemAddVM.IsShow)
            {
                CreateNewAndSetCandidateDefaultValue();
                //PatternItemViewModel vm = new PatternItemViewModel(_itemMemberCandidate, x => ItemSettingList.Add(x));
                //vm.ShowDialog(this);
                _patternItemAddVM.SetApplyEvent(x =>
                {
                    ItemSettingList.Add(x);
                });
                _patternItemAddVM.LoadItem(_itemMemberCandidate);   
            }
            if (_patternItemEditVM.IsShow)
            {
                _patternItemEditVM.CloseDialog();
            }
            _patternItemAddVM.Show(this);
        }
        /// <summary>
        /// Create new blank pattern setting item
        /// </summary>
        protected override void CreateNewAndSetCandidateDefaultValue()
        {
            _itemMemberCandidate = new PatternItemSetting();
            _itemMemberCandidate.Name = String.Empty;
            _itemMemberCandidate.Enabled = true;
            _itemMemberCandidate.Id = _itemMemberCandidate.Name =
                _itemMemberCandidate.RootKey = 
                _itemMemberCandidate.TimeUnit = String.Empty;
            _itemMemberCandidate.Time = 0;
            _itemMemberCandidate.Keys = new List<string>();
            _itemMemberCandidate.TimeUnit = ConfigValue.TimeUnits.S;
        }

        protected string _errorMessage;
        /// <summary>
        /// Get or set error message
        /// </summary>
        public string ErrorMessage 
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }
        /// <summary>
        /// Get status of applying
        /// </summary>
        protected override bool CanApply
        {
            get
            {
                ErrorMessage = ValidateData();
                return String.IsNullOrEmpty(ErrorMessage);
            }
        }

        protected DelegateCommand _editItemSettingCommand;
        /// <summary>
        /// Command interface for editing item setting
        /// </summary>
        public ICommand EditItemSettingCommand
        {
            get
            {
                if (_editItemSettingCommand == null)
                {
                    _editItemSettingCommand = new DelegateCommand(EditItemSettingCL, () => IsEdit());
                }
                return _editItemSettingCommand;
            }
        }
        /// <summary>
        /// Get status of editing pattern item
        /// </summary>
        /// <returns>True: editing; False: not current editing</returns>
        protected bool IsEdit()
        {
            if (_patternItemEditVM.IsShow) return false;
            return SelectedItems != null && SelectedItems.FirstOrDefault() != null;
        }
        /// <summary>
        /// Get status of adding key of pattern item
        /// </summary>
        /// <returns>True: editing; False: not current editing</returns>
        protected bool IsAdd()
        {
            if (_patternItemAddVM.IsShow) return false;
            return true;
        }
        /// <summary>
        /// Edit keys of pattern item
        /// </summary>
        protected virtual void EditItemSettingCL()
        {
            var editingItem = SelectedItems.FirstOrDefault() as PatternItemSetting;
            if (editingItem == null)
                return;
            //PatternItemViewModel vm = new PatternItemViewModel(editingItem,
            //    x =>
            //    {
            //        ItemSettingList.Remove(editingItem);
            //        ItemSettingList.Add(x);
            //    });
            //vm.ShowDialog(this);
            _patternItemEditVM.SetApplyEvent(x =>
            {
                ItemSettingList.Remove(editingItem);
                ItemSettingList.Add(x); 
            });
            _patternItemEditVM.LoadItem(editingItem);
            if (_patternItemAddVM.IsShow)
            {
                _patternItemAddVM.CloseDialog();
            }
            _patternItemEditVM.Show(this);
        }
        /// <summary>
        /// Validate keys of pattern item
        /// </summary>
        /// <returns>True: valid, False: not valid</returns>
        protected virtual string ValidateData()
        {
            var keys = ItemSettingList.Select(x => x.Name).Distinct();
            foreach (var i in keys)
            {
                if (ItemSettingList.Where(x => x.Name == i).Count() >= 2)
                {
                    return Properties.Resources.ValidateUniqueNameMessage;
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// Close dialog
        /// </summary>
        public override void CloseDialog()
        {
            _patternItemAddVM.CloseDialog();
            _patternItemEditVM.CloseDialog();
            base.CloseDialog();

        }
        /// <summary>
        /// Close dialog
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e"><see cref="CancelEventArgs"/></param>
        public override void dialog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _patternItemAddVM.IsShow = false;
            _patternItemEditVM.IsShow = false;
            base.dialog_Closing(sender, e);
        }
    }
}
