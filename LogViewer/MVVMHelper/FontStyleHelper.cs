using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using LogViewer.CustomException;
using LogViewer.Model;

namespace LogViewer.MVVMHelper
{
    /// <summary>
    /// Class handle event when font style changed
    /// </summary>
    class FontStyleHelper
    {
        /// <summary>
        /// Dependency property for the <see cref="P:FontStyle"/> property.
        /// </summary>
        private static readonly DependencyProperty FontStyleProperty =
          DependencyProperty.RegisterAttached("FontStyle", typeof(string), typeof(FontStyleHelper),
          new PropertyMetadata(null, new PropertyChangedCallback(OnFontStyleChanged)));
        /// <summary>
        /// Get property FontStyle
        /// <param name="o">Dependency Object</param>
        /// </summary>
        public static object GetFontStyle(DependencyObject o)
        {
            return o.GetValue(FontStyleProperty);
        }
        /// <summary>
        /// Set property FontStyle
        /// <param name="o">Dependency Object</param>
        /// <param name="value">Value to set</param>
        /// </summary>
        public static void SetFontStyle(DependencyObject o, object value)
        {
            o.SetValue(FontStyleProperty, value);
        }
        /// <summary>
        /// On Font Style Changed
        /// <param name="o">Dependency Object</param>
        /// <param name="args">DependencyPropertyChangedEventArgs</param>
        /// </summary>
        public static void OnFontStyleChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            var control = o as Control;
            var fontStyleObject = args.NewValue;
            if (fontStyleObject == null)
                return;
            string fontStyle = fontStyleObject.ToString();
            switch (fontStyle)
            {
                case ConfigValue.FilterSettingFontStyles.BOLD:
                    {
                        control.FontWeight = FontWeights.Bold;
                        control.FontStyle = FontStyles.Normal;
                        break;
                    }
                case ConfigValue.FilterSettingFontStyles.ITALIC:
                    {
                        control.FontWeight = FontWeights.Normal;
                        control.FontStyle = FontStyles.Italic;
                        break;
                    }
                case ConfigValue.FilterSettingFontStyles.NORMAL:
                    {
                        control.FontWeight = FontWeights.Normal;
                        control.FontStyle = FontStyles.Normal;
                        break;
                    }
                case ConfigValue.FilterSettingFontStyles.BOLDITALIC:
                    {
                        control.FontWeight = FontWeights.Bold;
                        control.FontStyle = FontStyles.Italic;
                        break;
                    }
                default:
                    throw new DataValueNotSupportedException();
            }
        }
    }
}
