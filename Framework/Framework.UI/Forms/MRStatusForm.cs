using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Framework.UI.Forms
{
    public partial class MRStatusForm : Form
    {
        public MRStatusForm()
        {
            InitializeComponent();
        }

        public string StatusLabelText {
            get
            {
                return lblStatusLeft.Text;
            }
            set
            {
                lblStatusLeft.Text = value;
            }
        }
    }
}
