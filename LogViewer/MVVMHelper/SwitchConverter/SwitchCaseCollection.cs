using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace LogViewer.MVVMHelper
{

    /// <summary>
    /// A collection of switch cases.
    /// </summary>
    public sealed class SwitchCaseCollection : Collection<SwitchCase>
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SwitchCaseCollection"/> class.
        /// </summary>
        internal SwitchCaseCollection()
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new case to the collection.
        /// </summary>
        /// <param name="when">The value to compare against the input.</param>
        /// <param name="then">The output value to use if the case matches.</param>
        public void Add(object when, object then)
        {
            Add(
                new SwitchCase
                {
                    When = when,
                    Then = then
                }
            );
        }

        #endregion

    }   // class

}   // namespace
