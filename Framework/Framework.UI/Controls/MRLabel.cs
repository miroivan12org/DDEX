using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.UI.Controls
{
    public partial class MRLabel : System.Windows.Forms.Label
    {
        public MRLabel()
        {
            InitializeComponent();
        }

        public MRLabel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
