using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogViewer.Properties;
using System.Windows.Media;
using System.Windows;
using LogViewer.Model;
using LogViewer.Business;

namespace LogViewer.Util
{
    /// <summary>
    /// Class provides utility methods
    /// </summary>
    static class Utility
    {
        public static string Translate(string str)
        {
            return Resources.ResourceManager.GetString(str);
        }
        /// <summary>
        /// Check for null value
        /// </summary>
        /// <param name="value">an input string</param>
        /// <returns>Empty string if input value is null, otherwise it return original string</returns>
        public static string NVL(string value) {
            if (value == null) return string.Empty;
            return value;
        }
        public static string GetCurrentDateString() {
            string result = DateTime.Now.ToString("yyyyMMddHHmmss");
            return result;
        }

        public static T FindParentWithType<T>(DependencyObject uiElement) where T : DependencyObject
        {
            DependencyObject tempUIElement = uiElement;
            while (true)
            {
                if (tempUIElement == null)
                    return null;
                if (tempUIElement is T)
                {
                    return tempUIElement as T;
                }
                tempUIElement = VisualTreeHelper.GetParent(tempUIElement);
            }
        }
    }
    public delegate void GetGraphDataDelegate(IList<GraphParamSetting> paramSetting,
            out GraphResult graphLineData1,
            out GraphResult graphLineData2, out IList<GraphResult> eventResults);
}
