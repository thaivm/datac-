using System;
using System.Net;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Interactivity;
using Microsoft.Windows.Controls;
using System.Windows;

namespace LogViewer.MVVMHelper
{
    /// <summary>
    /// Class handle event drag drop for data grid.
    /// </summary>
    public class DataGridDragDropBehavior : Behavior<DataGrid>
    {
        #region Dependency Properties
        /// <summary>
        /// Dependency property for drag drop Command.
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(DelegateCommand<DataGridDragDropEventArgs>), typeof(DataGridDragDropBehavior), new UIPropertyMetadata(null));
        /// <summary>
        /// Dependency property for AllowedEffects.
        /// </summary>
        public static readonly DependencyProperty AllowedEffectsProperty =
            DependencyProperty.Register("AllowedEffects", typeof(DragDropEffects), typeof(DataGridDragDropBehavior), new UIPropertyMetadata(DragDropEffects.All));

        #endregion

        #region Properties
        /// <summary>
        /// The value to match against the input value of AllowedEffects.
        /// </summary>
        public DragDropEffects AllowedEffects
        {
            get { return (DragDropEffects)GetValue(AllowedEffectsProperty); }
            set { SetValue(AllowedEffectsProperty, value); }
        }
        /// <summary>
        /// The value to match against the input value of Command.
        /// </summary>
        public DelegateCommand<DataGridDragDropEventArgs> Command
        {
            get {
                return (DelegateCommand<DataGridDragDropEventArgs>)GetValue(CommandProperty); 
            }
            set { SetValue(CommandProperty, value); }
        }
        #endregion
        /// <summary>
        /// On attached drag drop event.
        /// </summary>
        protected override void OnAttached()
        {
            // Drop
            WeakEventListener<DataGridDragDropBehavior, DataGrid, DragEventArgs> dropListener = new WeakEventListener<DataGridDragDropBehavior, DataGrid, DragEventArgs>(this, AssociatedObject);
            dropListener.OnEventAction = (instance, source, args) => instance.DataGrid_Drop(source, args);
            dropListener.OnDetachAction = (listenerRef, source) => source.Drop -= listenerRef.OnEvent;
            AssociatedObject.Drop += dropListener.OnEvent;

            base.OnAttached();
        }

        /// <summary>
        /// Drop file to data grid.
        /// <param name="sender">Data grid</param>
        /// <param name="e">Drag event args</param>
        /// </summary>
        private void DataGrid_Drop(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;
            // Verify that this is a valid drop and then store the drop target
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length > 0)
            {
                e.Source = files[0];
                e.Effects = ((e.AllowedEffects & DragDropEffects.Copy) == DragDropEffects.Copy) && (e.KeyStates & DragDropKeyStates.ControlKey) == DragDropKeyStates.ControlKey ? DragDropEffects.Copy : DragDropEffects.Move;
                e.Handled = true;
                DataGridDragDropEventArgs arg = new DataGridDragDropEventArgs
                {
                    Source = files[0]
                };
                Command.Execute(arg);
            }
        }

    }
}
