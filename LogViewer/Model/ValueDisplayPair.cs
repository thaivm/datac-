using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.Model
{
    /// <summary>
    /// Model class for storing information of pair value in analyze pattern process <seealso cref="AnalyzePattern"/>
    /// </summary>
    /// <typeparam name="TValue"><see cref="TValue"/></typeparam>
    /// <typeparam name="TDisplay"><see cref="TDisplay"/></typeparam>
    public class ValueDisplayPair<TValue,TDisplay>
    {
        /// <summary>
        /// Get or set <see cref="TValue"/>
        /// </summary>
        public TValue Value { get; set; }
        /// <summary>
        /// Get or set <see cref="TDisplay"/>
        /// </summary>
        public TDisplay Display { get; set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="value"><see cref="TValue"/></param>
        /// <param name="display"><see cref="TDisplay"/></param>
        public ValueDisplayPair(TValue value, TDisplay display)
        {
            Value = value;
            Display = display;
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public ValueDisplayPair()
        { }
    }
}
