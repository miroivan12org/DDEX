using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDEX
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private string loginName;

        private bool IsValid()
        {
            bool ret = false;
            var dir = Directory.GetCurrentDirectory();
            var filePath = dir + @"\licence.dat";
            if (File.Exists(filePath))
            {
                var encryptedMessage = File.ReadAllText(filePath);
                string licence = Encrpytion.Cipher.Decrypt(encryptedMessage);

                if (licence.ToUpper() == (loginName + DateTime.Now.Year.ToString()).ToUpper())
                {
                    ret = true;
                }
                else
                {
                    throw new Exception("Login and licence missmatch.");
                }
            }
            else
            {
                throw new Exception("Missing licence.dat file.");
            }

            return ret;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            loginName = mrTextBox1.Text;
            try
            {
                if (IsValid())
                {
                    //var mainForm = new MainForm();
                    //mainForm.FormClosed += mainForm_FormClosed;
                    //mainForm.Show();
                    //Visible = false;
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Framework.UI.Forms.MRMessageBox.Show(ex.Message, Framework.UI.Forms.MRMessageBox.eMessageBoxStyle.OK, Framework.UI.Forms.MRMessageBox.eMessageBoxType.Error);
            }
            
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
            Dispose();
        }
    }
}
