using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace LogViewer.Util
{
    public static class ExtensionMethod
    {
        public static T DeepCopy<T>(this T thisInst)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, thisInst);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

        public static void ClearAndSetNull<T>(this ICollection<T> list)
        {
            if (list != null)
            {
                list.Clear();
                list = null;
            }
        }
    }
}
