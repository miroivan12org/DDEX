using Business.DDEXFactory.Interfaces;
using Business.DDEXSchemaERN_382.Generation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DDEX
{
    public partial class MainForm : Framework.UI.Forms.MRMDIParent
    {
        public MainForm()
        {
            InitializeComponent();
            Globals.MDIMainForm = this;
        }

        #region Properties
        
        #endregion

        #region Menus And Item Clicks

        private void menuItem_Click(object sender, EventArgs e)
        {
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            filesToolStripMenuItem_Click(this, new EventArgs());
        }

        private void validatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Forms.ValidatorForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void filesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Navigation.FilesForm();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
    /*
 TODO:
    - rijesiti display artiste
    - otvoriti menu settings i omoguciti editiranje nekih settingsa
    - napraviti license.dat file i vanjski dll za dekripciju fajla
    */