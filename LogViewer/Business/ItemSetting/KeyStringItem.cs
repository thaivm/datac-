using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.Business.ItemSetting
{
    public class KeyStringItem<T>
    {
        public KeyStringItem() {
            ChildKeys  = new List<KeyStringItem<T>>();
        }
        public string Key { get; set; }
        public List<KeyStringItem<T>> ChildKeys { get; set; }
        public T Record { get; set; }
        public int currentLevel;
    }
}
