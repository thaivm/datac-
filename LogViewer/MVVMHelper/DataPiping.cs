using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace LogViewer.MVVMHelper
{
    public class DataPiping
    {
        /// <summary>
        /// Dependency property for the <see cref="P:DataPipes"/> property.
        /// </summary>
        public static readonly DependencyProperty DataPipesProperty =
        DependencyProperty.RegisterAttached("DataPipes",
        typeof(DataPipeCollection),
        typeof(DataPiping),
        new UIPropertyMetadata(null));
        /// <summary>
        /// Set property DataPipes
        /// <param name="o">Dependency Object</param>
        /// <param name="value">Value to set</param>
        /// </summary>
        public static void SetDataPipes(DependencyObject o, DataPipeCollection value)
        {
            o.SetValue(DataPipesProperty, value);
        }
        /// <summary>
        /// Get property DataPipes
        /// <param name="o">Dependency Object</param>
        /// </summary>
        public static DataPipeCollection GetDataPipes(DependencyObject o)
        {
            return (DataPipeCollection)o.GetValue(DataPipesProperty);
        }
    }

    public class DataPipeCollection : FreezableCollection<DataPipe>
    {

    }

    public class DataPipe : Freezable
    {
        #region Source (DependencyProperty)
        /// <summary>
        /// The value to match against the input value.
        /// </summary>
        public object Source
        {
            get { return (object)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
        /// <summary>
        /// Dependency property for the <see cref="P:Source"/> property.
        /// </summary>
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(object), typeof(DataPipe),
            new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnSourceChanged)));
        /// <summary>
        /// On Source Changed.
        /// <param name="d">DependencyObject</param>
        /// <param name="e">DependencyPropertyChangedEventArgs</param>
        /// </summary>
        private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DataPipe)d).OnSourceChanged(e);
        }
        /// <summary>
        /// On Source Changed.
        /// <param name="e">DependencyPropertyChangedEventArgs</param>
        /// </summary>
        protected virtual void OnSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            Target = e.NewValue;
        }

        #endregion

        #region Target (DependencyProperty)
        /// <summary>
        /// The value to match against the input value.
        /// </summary>
        public object Target
        {
            get { return (object)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }
        /// <summary>
        /// Dependency property for the <see cref="P:Target"/> property.
        /// </summary>
        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("Target", typeof(object), typeof(DataPipe),
            new FrameworkPropertyMetadata(null));

        #endregion

        protected override Freezable CreateInstanceCore()
        {
            return new DataPipe();
        }
    }
}
