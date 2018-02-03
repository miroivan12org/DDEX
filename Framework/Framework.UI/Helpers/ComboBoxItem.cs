using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.UI.Helpers
{
    public class ComboBoxItem
    {
        public object Value { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj is DBNull) return false;

            return Object.Equals(obj, Value);
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static List<ComboBoxItem> GetComboBoxItemsFromEnum<T>(bool valueIsText = false)
        {
            var ret = new List<ComboBoxItem>();

            var ls = Enum.GetValues(typeof(T)).Cast<T>().ToList();
            for (int i = 0; i < ls.Count; i++)
            {
                object value = i;
                if (valueIsText) value = ls[i].ToString();
                ret.Add(new ComboBoxItem() { Value = value, Text = ls[i].ToString() });
            }
            
            return ret;
        }
    }
}
