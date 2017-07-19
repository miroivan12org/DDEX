using Framework.UI.Forms;
using Framework.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Framework.UI.Controls
{
    public partial class MRPanel : Panel, IMRControlCollectionParent
    {
        public MRPanel()
        {
            InitializeComponent();
        }

        public MRPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private bool editable = true;
        [DefaultValue(true)]
        public bool Editable
        {
            get
            {
                return editable;
            }
            set
            {
                editable = value;
                Helpers.StaticHelpers.EnableChildren(this);
            }
        }
        

    }
}
