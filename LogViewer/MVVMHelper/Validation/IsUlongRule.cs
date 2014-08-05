using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace LogViewer.MVVMHelper
{
    /// <summary>
    /// Class provide method for validation is Ulong number
    /// </summary>
    class IsUlongRule : ValidationRule
    {
        /// <summary>
        /// Get or set error message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="value">Object to validate</param>
        /// <param name="cultureInfo"><see cref="System.Globalization.CultureInfo"/></param>
        /// <returns><see cref="ValidationResult"/></returns>

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                ulong.Parse(value.ToString());
            }
            catch
            {
                return new ValidationResult(false, Message);
            }
            return new ValidationResult(true, null);
        }
    }
}
