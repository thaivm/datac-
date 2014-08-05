using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;

namespace LogViewer.MVVMHelper
{
    /// <summary>
    /// Class translate bundle from properties.
    /// </summary>
    class TranslateConverter : IValueConverter
    {
        /// <summary>
        /// Convert key to string
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>Return string value of key</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Util.Utility.Translate(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
