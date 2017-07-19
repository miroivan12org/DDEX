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
            return Object.Equals(obj, Value);
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
