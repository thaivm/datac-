using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace LogViewer.MVVMHelper
{
    /// <summary>
    /// Class convert number to Font size
    /// </summary>
    public class FontSizeConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>Return a int font size</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var convertFrom = new System.Windows.FontSizeConverter().ConvertFrom(value.ToString());
            if (convertFrom != null)
                return (int)(((double)convertFrom) * 96 / 72);
            return 1;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;     
        }
    }
}
