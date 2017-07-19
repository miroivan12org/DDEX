using System.IO;
using System;
using System.Drawing;
using System.Windows.Forms;
using Business.DDEXSchemaERN_382.Generation;
using Business.DDEXSchemaERN_382;

namespace DDEX.Forms
{
    public partial class ValidatorForm : Framework.UI.Forms.MRStatusForm
    {
        public ValidatorForm()
        {
            InitializeComponent();
        }
        
        public Binder Binder = new Binder();

        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtPath.Text))
            {
                
                string msg = "";
                bool isValid = Binder.IsFileValid(txtPath.Text, out msg);
                if (isValid)
                {
                    lblResult.Text = "... VALID ...";
                    lblResult.ForeColor = Color.Green;
                    richTextBox1.Text = "";
                }
                else
                {
                    lblResult.Text = "... INVALID ...";
                    lblResult.ForeColor = Color.Red;
                    richTextBox1.Text = msg;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = dlg.FileName;
                    richTextBox1.Text = "";
                    lblResult.Text = "";
                }
            }
        }
    }
}
