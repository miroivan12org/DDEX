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
            if(sender == albumToolStripMenuItem)
            {
                var frm = new Generation.ERN_382.ERN_382GenerationFormAudioAlbumMusicOnly();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            menuItem_Click(albumToolStripMenuItem, new EventArgs());
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
    - prebaciti sve na web
    - napraviti deserijalizaciju audiosingle primjera pa pogledati nejasnoce    - iz generation forme maknuti izradu fajla - forme su samo za dobivanje objekata
    - proci dva tipa xml i sve sto se ponavlja enkapsulirati u kontrole ili forme
    - soundRecording - mozda voditi u posebnom sifrarniku
    - servisom razgovariti s bazom


     */