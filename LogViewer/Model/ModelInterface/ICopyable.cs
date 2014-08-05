using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.Model
{
    /// <summary>
    /// Interface provide method for clone object feature
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface ICopyable<T>
    {
        T Copy();
    }
}
