using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Markup;

namespace LogViewer.MVVMHelper
{

    /// <summary>
    /// An individual case in the switch statement.
    /// </summary>
    [ContentProperty("Then")]
    public sealed class SwitchCase : DependencyObject
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SwitchCase"/> class.
        /// </summary>
        public SwitchCase()
        {

        }

        #endregion

        #region Properties

        /// <summary>
        /// Dependency property for the <see cref="P:When"/> property.
        /// </summary>
        public static readonly DependencyProperty WhenProperty = DependencyProperty.Register("When", typeof(object), typeof(SwitchCase), new PropertyMetadata(default(object)));

        /// <summary>
        /// The value to match against the input value.
        /// </summary>
        public object When
        {
            get
            {
                return (object)GetValue(WhenProperty);
            }
            set
            {
                SetValue(WhenProperty, value);
            }
        }

        /// <summary>
        /// Dependency property for the <see cref="P:Then"/> property.
        /// </summary>
        public static readonly DependencyProperty ThenProperty = DependencyProperty.Register("Then", typeof(object), typeof(SwitchCase), new PropertyMetadata(default(object)));

        /// <summary>
        /// The output value to use if the current case matches.
        /// </summary>
        public object Then
        {
            get
            {
                return (object)GetValue(ThenProperty);
            }
            set
            {
                SetValue(ThenProperty, value);
            }
        }

        #endregion

    }   // class

}   // name space
