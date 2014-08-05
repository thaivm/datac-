using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace LogViewer.MVVMHelper
{

    /// <summary>
    /// Produces an output value based upon a collection of case statements.
    /// </summary>
    [ContentProperty("Cases")]
    public class SwitchConverter : IValueConverter
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SwitchConverter"/> class.
        /// </summary>
        public SwitchConverter()
            : this(new SwitchCaseCollection())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SwitchConverter"/> class.
        /// </summary>
        /// <param name="cases">The case collection.</param>
        internal SwitchConverter(SwitchCaseCollection cases)
        {

            //Q_Edit: Contract.Requires(cases != null);

            Cases = cases;
            StringComparison = StringComparison.OrdinalIgnoreCase;

        }

        #endregion

        #region Properties

        /// <summary>
        /// Holds a collection of switch cases that determine which output
        /// value will be produced for a given input value.
        /// </summary>
        public SwitchCaseCollection Cases
        {
            get;
            private set;
        }

        /// <summary>
        /// Specifies the type of comparison performed when comparing the input
        /// value against a case.
        /// </summary>
        public StringComparison StringComparison
        {
            get;
            set;
        }

        /// <summary>
        /// An optional value that will be output if none of the cases match.
        /// </summary>
        public object Else
        {
            get;
            set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == null)
            {

                // Special case for null
                // Null input can only equal null, no convert necessary
                var nullCase = Cases.FirstOrDefault(x => x.When == null);
                if (nullCase != null)
                    return nullCase.Then;
                return Else;

            }

            foreach (var c in Cases.Where(x => x.When != null))
            {

                // Special case for string to string comparison
                if (value is string && c.When is string)
                {
                    if (String.Equals((string)value, (string)c.When, StringComparison))
                    {
                        return c.Then;
                    }
                }

                object when = c.When;

                // Normalize the types using IConvertible if possible
                if (TryConvert(culture, value, ref when))
                {
                    if (value.Equals(when))
                    {
                        return c.Then;
                    }
                }

            }

            return Else;

        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var c in Cases.Where(x => x.Then != null))
            {

                // Special case for string to string comparison
                if (value is string && c.Then is string)
                {
                    if (String.Equals((string)value, (string)c.Then, StringComparison))
                    {
                        return c.When;
                    }
                }

                object then = c.Then;

                // Normalize the types using IConvertible if possible
                if (TryConvert(culture, value, ref then))
                {
                    if (value.Equals(then))
                    {
                        return c.When;
                    }
                }
            }
            throw new NotSupportedException();
        }

        /// <summary>
        /// Attempts to use the IConvertible interface to convert <paramref name="value2"/> into a type
        /// compatible with <paramref name="value1"/>.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="value1">The input value.</param>
        /// <param name="value2">The case value.</param>
        /// <returns>True if conversion was performed, otherwise false.</returns>
        private static bool TryConvert(CultureInfo culture, object value1, ref object value2)
        {

            Type type1 = value1.GetType();
            Type type2 = value2.GetType();

            if (type1 == type2)
            {
                return true;
            }

            if (type1.IsEnum)
            {
                value2 = Enum.Parse(type1, value2.ToString(), true);
                return true;
            }

            var convertible1 = value1 as IConvertible;
            var convertible2 = value2 as IConvertible;

            if (convertible1 != null && convertible2 != null)
            {
                value2 = System.Convert.ChangeType(value2, type1, culture);
                return true;
            }

            return false;

        }

        #endregion

    }   // class

}   // namespace
