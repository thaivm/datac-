using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Windows.Controls;
using LogViewer.ViewModel;
using LogViewer.Util;
using System.Windows.Input;
using Microsoft.Windows.Controls.Primitives;
using System.Windows.Media;

namespace LogViewer.MVVMHelper
{
    /// <summary>
    /// Class DatagridHelper handle events double click, click, go to line, refresh... in data grid.
    /// </summary>
    class DatagridHelper
    {
        /// <summary>
        /// Dependency property for the <see cref="P:RefreshData"/> property.
        /// </summary>
        private static readonly DependencyProperty RefreshDataProperty =
          DependencyProperty.RegisterAttached("RefreshData", typeof(bool), typeof(DatagridHelper),
          new PropertyMetadata(false, new PropertyChangedCallback(OnRefreshDataChanged)));
        /// <summary>
        /// Get property RefreshData
        /// <param name="o">Dependency Object</param>
        /// </summary>
        public static object GetRefreshData(DependencyObject o)
        {
            return o.GetValue(RefreshDataProperty);
        }
        /// <summary>
        /// Set property RefreshData
        /// <param name="o">Dependency Object</param>
        /// <param name="value">Value to set</param>
        /// </summary>
        public static void SetRefreshData(DependencyObject o, object value)
        {
            o.SetValue(RefreshDataProperty, value);
        }
        /// <summary>
        /// On RefreshData Changed
        /// <param name="o">Dependency Object</param>
        /// <param name="args">DependencyPropertyChangedEventArgs</param>
        /// </summary>
        public static void OnRefreshDataChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            var datagrid = (o as DataGrid);
            datagrid.Items.Refresh();
        }

        /// <summary>
        /// Dependency property for the <see cref="P:RecordToShow"/> property.
        /// </summary>
        private static readonly DependencyProperty RecordToShowProperty =
          DependencyProperty.RegisterAttached("RecordToShow", typeof(object), typeof(DatagridHelper),
          new PropertyMetadata(null, new PropertyChangedCallback(OnRecordToShowChanged)));
        /// <summary>
        /// Get property RecordToShow
        /// <param name="o">Dependency Object</param>
        /// </summary>
        public static object GetRecordToShow(DependencyObject o)
        {
            return o.GetValue(RecordToShowProperty);
        }
        /// <summary>
        /// Set property RecordToShow
        /// <param name="o">Dependency Object</param>
        /// <param name="value">Value to set</param>
        /// </summary>
        public static void SetRecordToShow(DependencyObject o, object value)
        {
            o.SetValue(RecordToShowProperty, value);
        }
        /// <summary>
        /// On RecordToShow Changed
        /// <param name="o">Dependency Object</param>
        /// <param name="args">DependencyPropertyChangedEventArgs</param>
        /// </summary>
        public static void OnRecordToShowChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            object row = args.NewValue as object;

            if (row != null)
            {
                object item = row;
                var datagrid = (o as DataGrid);
                datagrid.SelectedItems.Clear();
                /* set the SelectedItem property */
                if (item != null)
                {
                    datagrid.Items.Refresh();
                    datagrid.SelectedItem = item;                   
                    datagrid.UpdateLayout();
                    datagrid.ScrollToCenterOfView(item);
                    
                    var dataGridRow = datagrid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;

                    if (dataGridRow != null)
                    {
                        DataGridCell cell = GetCell(datagrid, dataGridRow, 1);
                        if (cell != null)
                            cell.Focus();
                    }

                }
            }
        }
        /// <summary>
        /// Get cell in row of data grid
        /// <param name="dataGrid">DataGrid</param>
        /// <param name="rowContainer">DataGridRow</param>
        /// <param name="column">Index of column in data grid</param>
        /// </summary>
        private static DataGridCell GetCell(DataGrid dataGrid, DataGridRow rowContainer, int column)
        {
            if (rowContainer != null)
            {
                DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(rowContainer);
                if (presenter == null)
                {
                    /* if the row has been virtualized away, call its ApplyTemplate() method
                     * to build its visual tree in order for the DataGridCellsPresenter
                     * and the DataGridCells to be created */
                    rowContainer.ApplyTemplate();
                    presenter = FindVisualChild<DataGridCellsPresenter>(rowContainer);
                }
                if (presenter != null)
                {
                    DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
                    if (cell == null)
                    {
                        /* bring the column into view
                         * in case it has been virtualized away */
                        dataGrid.ScrollIntoView(rowContainer, dataGrid.Columns[column]);
                        cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
                    }
                    return cell;
                }
            }
            return null;
        }

        /// <summary>
        /// Find Visual Child of Dependency Object
        /// <param name="obj">DependencyObject</param>
        /// <returns>Return a child element</returns>
        /// </summary>
        private static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
        /// <summary>
        /// Dependency property for the <see cref="P:DoubleClickedRow"/> property.
        /// </summary>
        private static readonly DependencyProperty DoubleClickedRowProperty =
          DependencyProperty.RegisterAttached("DoubleClickedRow", typeof(object), typeof(DatagridHelper),
          new PropertyMetadata(null));
        /// <summary>
        /// Get property DoubleClickedRow
        /// <param name="o">Dependency Object</param>
        /// </summary>
        public static object GetDoubleClickedRow(DependencyObject o)
        {
            return o.GetValue(DoubleClickedRowProperty);
        }
        /// <summary>
        /// Set property DoubleClickedRow
        /// <param name="o">Dependency Object</param>
        /// <param name="value">Value to set</param>
        /// </summary>
        public static void SetDoubleClickedRow(DependencyObject o, object value)
        {
            o.SetValue(DoubleClickedRowProperty, value);
        }
        /// <summary>
        /// Dependency property for the <see cref="P:ClickedRow"/> property.
        /// </summary>
        private static readonly DependencyProperty ClickedRowProperty =
          DependencyProperty.RegisterAttached("ClickedRow", typeof(object), typeof(DatagridHelper),
          new PropertyMetadata(null));
        /// <summary>
        /// Get property ClickedRow
        /// <param name="o">Dependency Object</param>
        /// </summary>
        public static object GetClickedRow(DependencyObject o)
        {
            return o.GetValue(ClickedRowProperty);
        }
        /// <summary>
        /// Set property ClickedRow
        /// <param name="o">Dependency Object</param>
        /// <param name="value">Value to set</param>
        /// </summary>
        public static void SetClickedRow(DependencyObject o, object value)
        {
            o.SetValue(ClickedRowProperty, value);
        }
        /// <summary>
        /// Dependency property for the <see cref="P:RecordToFollow"/> property.
        /// </summary>
        private static readonly DependencyProperty RecordToFollowProperty =
          DependencyProperty.RegisterAttached("RecordToFollow", typeof(object), typeof(DatagridHelper),
          new PropertyMetadata(null, new PropertyChangedCallback(OnRecordToFollowChanged)));
        /// <summary>
        /// Get property RecordToFollow
        /// <param name="o">Dependency Object</param>
        /// </summary>
        public static object GetRecordToFollow(DependencyObject o)
        {
            return o.GetValue(RecordToFollowProperty);
        }
        /// <summary>
        /// Set property RecordToFollow
        /// <param name="o">Dependency Object</param>
        /// <param name="value">Value to set</param>
        /// </summary>
        public static void SetRecordToFollow(DependencyObject o, object value)
        {
            o.SetValue(RecordToFollowProperty, value);
        }
        /// <summary>
        /// On RecordToFollow Changed
        /// <param name="o">Dependency Object</param>
        /// <param name="args">DependencyPropertyChangedEventArgs</param>
        /// </summary>
        public static void OnRecordToFollowChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            object row = args.NewValue as object;

            if (row != null)
            {
                object item = row;
                var datagrid = (o as DataGrid);
                datagrid.SelectedItems.Clear();
                /* set the SelectedItem property */
                if (item != null)
                {
                    //object item = datagrid.Items[rowIndex - 1]; // = Product X
                    datagrid.SelectedItem = item;
                    //datagrid.ScrollIntoView(datagrid.Items[0]);
                    datagrid.UpdateLayout();
                    datagrid.ScrollToCenterOfView(item);
                }
            }
        }
    }
}
