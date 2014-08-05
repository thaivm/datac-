using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace LogViewer.MVVMHelper
{
    /// <summary>
    /// A proxy binding parent data.
    /// </summary>
    public class BindingProxy : Freezable
    {
        #region Overrides of Freezable

        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }

        #endregion
        /// <summary>
        /// The value to match against the input value.
        /// </summary>
        public object Data
        {
            get { return (object)GetValue(DataProperty); }
            set 
            { 
                SetValue(DataProperty, value); 
            }
        }
        /// <summary>
        /// Dependency property for data proxy property.
        /// </summary>
        // Using a DependencyProperty as the backing store for Data.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
    }
}
