using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework.UI.Forms;
using Business.DDEXSchemaERN_382.BindingObjects;
using System.Configuration;
using Microsoft.Win32;
using System.Reflection;

namespace DDEX.Forms
{
    public partial class SettingsForm : Framework.UI.Forms.MREditForm
    {
        public SettingsForm()
        {
            InitializeComponent();
        }
        public AppSettings Model { get; set; } = AppSettings.GetInstance();
        protected override void OnDialogResultClicked(object sender, DialogResultEventArgs e)
        {
            base.OnDialogResultClicked(sender, e);
            if (e.Result == DialogResult.OK)
            {
                AppSettings.SaveSettings();
            }
            Close();
            Dispose();
        }
        private void InitBindings()
        {
            txtNavigationFolderPath.DataBindings.Add("Text", Model, "NavigationFolderPath");
            txtPLineText.DataBindings.Add("Text", Model, "PLineText");
            txtLabelName.DataBindings.Add("Text", Model, "LabelName");
            txtIndirectContributors.DataBindings.Add("Text", Model, "IndirectContributors");
            txtDisplayArtistRoles.DataBindings.Add("Text", Model, "DisplayArtistRoles");
            txtDeezerRecipientPartyID.DataBindings.Add("Text", Model, "DeezerRecipientPartyID");
            txtDeezerRecipientPartyName.DataBindings.Add("Text", Model, "DeezerRecipientPartyName");
            txtSenderPartyName.DataBindings.Add("Text", Model, "SenderPartyName");
            txtSenderPartyID.DataBindings.Add("Text", Model, "SenderPartyID");
            txtPandoraRecipientPartyID.DataBindings.Add("Text", Model, "PandoraRecipientPartyID");
            txtPandoraRecipientPartyName.DataBindings.Add("Text", Model, "PandoraRecipientPartyName");
            txtSoundCloudRecipientPartyID.DataBindings.Add("Text", Model, "SoundCloudRecipientPartyID");
            txtSoundCloudRecipientPartyName.DataBindings.Add("Text", Model, "SoundCloudRecipientPartyName");
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            AppSettings.LoadSettings(); 
            InitBindings();
        }
    }
}
