using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LogViewer.MVVMHelper;
using LogViewer.Model;
using System.Collections.ObjectModel;
using System.Windows.Controls.Primitives;
using System.Collections;

namespace LogViewer.View
{
    /// <summary>
    /// Interaction logic for FilterButtonArea.xaml
    /// </summary>
    public partial class FilterButtonArea : UserControl
    {
        public FilterButtonArea()
        {
            InitializeComponent();
        }

        private static readonly DependencyProperty ItemsSourceSummaryProperty =
            DependencyProperty.Register("ItemsSourceSummary", typeof(IList),
            typeof(FilterButtonArea), new PropertyMetadata(null, OnItemsSourceSummaryChanged));
        public IList ItemsSourceSummary
        {
            get { return (IList)GetValue(ItemsSourceSummaryProperty); }
            set { SetValue(ItemsSourceSummaryProperty, value); }
        }
        public static void OnItemsSourceSummaryChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            //  Cast the data.
            IList itemSourcesSummaries = args.NewValue as IList;
            (o as FilterButtonArea).LoadDataSummary(itemSourcesSummaries);
        }

        public static readonly RoutedEvent ButtonClickedEvent = EventManager.RegisterRoutedEvent(
            "ButtonClicked", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FilterButtonArea));
        public event RoutedEventHandler ButtonClicked
        {
            add { AddHandler(ButtonClickedEvent, value); }
            remove { RemoveHandler(ButtonClickedEvent, value); }
        }
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(FilterButtonArea.ButtonClickedEvent);
            RaiseEvent(newEventArgs);
        }


        private static readonly DependencyProperty IsDisplayThreeDotProperty =
            DependencyProperty.Register("IsDisplayThreeDot", typeof(Boolean),
            typeof(FilterButtonArea), new PropertyMetadata(false, OnIsDisplayThreeDotChanged));
        public Boolean IsDisplayThreeDot
        {
            get { return (Boolean)GetValue(IsDisplayThreeDotProperty); }
            set { SetValue(IsDisplayThreeDotProperty, value); }
        }
        public static void OnIsDisplayThreeDotChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {

        }

        public void LoadDataSummary(IEnumerable data)
        {
            RemainList.Clear();
            int i = 0;
            foreach (var obj in data)
            {
                if (i < 10)
                {
                    RemainList.Add(new DataPosition(obj, 0, i));
                }
                i++;
            }
            if (i < 11)
            {
                IsDisplayThreeDot = false;
            }
            else
            {
                IsDisplayThreeDot = true;
            }
        }

        private static readonly DependencyProperty ItemsSourceRemainProperty =
            DependencyProperty.Register("ItemsSourceRemain", typeof(IList),
            typeof(FilterButtonArea), new PropertyMetadata(null, OnItemsSourceRemainChanged));
        public IList ItemsSourceRemain
        {
            get { return (IList)GetValue(ItemsSourceRemainProperty); }
            set { SetValue(ItemsSourceRemainProperty, value); }
        }
        public static void OnItemsSourceRemainChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            //  Cast the data.
            IList itemSourceRemains = args.NewValue as IList;
            (o as FilterButtonArea).LoadDataRemain(itemSourceRemains);
        }
        public void LoadDataRemain(IEnumerable data)
        {
            RemainList.Clear();
            int i = 0;
            foreach (var obj in data)
            {
                RemainList.Add(new DataPosition(obj, i / 5, i % 5));
                i++;
            }
            IsDisplayThreeDot = false;
        }
        public ObservableCollection<DataPosition> _remainList;
        public ObservableCollection<DataPosition> RemainList
        {
            get
            {
                if (_remainList == null)
                {
                    _remainList = new ObservableCollection<DataPosition>();
                }
                return _remainList;
            }
            set
            {
                _remainList = value;
            }
        }

        public class DataPosition
        {
            public object Data{get;set;}
            public int RowIndex { get; set; }
            public int ColumnIndex { get; set; }
            public DataPosition(object data, int row, int column)
            {
                Data = data;
                RowIndex = row;
                ColumnIndex = column;
            }
        }
    }
}

