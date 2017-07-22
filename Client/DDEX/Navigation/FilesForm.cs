using Business.DDEXSchemaERN_382;
using Business.DDEXSchemaERN_382.Entities;
using Newtonsoft;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DDEX.Navigation
{
    public partial class FilesForm : Framework.UI.Forms.MRStatusForm
    {
        public FilesForm()
        {
            InitializeComponent();
            tbFiles.BindedControls.Add(dgvFiles);
        }
        
        public static NavigationModel Model { get; set; } = new NavigationModel();
        private void FilesForm_Load(object sender, EventArgs e)
        {
            lblPath.Text = Properties.Settings.Default.NavigationFolderPath;
            Model.FolderPath = Properties.Settings.Default.NavigationFolderPath;
            Model.Refresh();
            InitBindings();
        }
        private void InitBindings()
        {
            if (Model != null)
            {
                dgvFiles.AutoGenerateColumns = false;
                dgvFiles.DataSource = Model.Files;
                dgvFiles.ClearSelection();
            }
        }

        private void tbTrackReleases_ButtonClicked(object sender, Framework.UI.Controls.MRTitleBar.ActionButtonEventArgs e)
        {
            if (e.Action == Framework.UI.Controls.MRTitleBar.eButtonAction.Add)
            {
                var record = new EditXmlFileModel();

                using (var frm = new FileForm(record))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Model.Files.Add(record);
                        dgvFiles.ClearSelection();

                        var model = new AudioAlbumModel() { FullFileName = record.FullName };
                        using (var frmEdit = new Generation.ERN_382.ERN_382GenerationFormAudioAlbumMusicOnly(model))
                        {
                            frmEdit.ShowDialog();
                        }
                    }
                }

                
            }
        }
        private void dgvFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditXmlFileModel record = (EditXmlFileModel)dgvFiles.CurrentRow.DataBoundItem;
            if (record != null)
            {
                var model = new AudioAlbumModel() { FullFileName = record.FullName };
                var frm = new Generation.ERN_382.ERN_382GenerationFormAudioAlbumMusicOnly(model) { Editable = true };
                frm.MdiParent = Globals.MDIMainForm;
                frm.Show();
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            using(var b = new FolderBrowserDialog()
            {
                Description = "Select folder for xml files",
                SelectedPath = Properties.Settings.Default.NavigationFolderPath,
                ShowNewFolderButton = true
            })
            {
                if (b.ShowDialog() == DialogResult.OK)
                {
                    Model.FolderPath = b.SelectedPath;
                    Model.Refresh();
                }
            }
        }

        private void chxbSubFolders_CheckedChanged(object sender, EventArgs e)
        {
            Model.ScanSubFolders = chxbSubFolders.Checked;
            Model.Refresh();
        }

        private void btnValidateAll_Click(object sender, EventArgs e)
        {
            Model.Refresh();
        }
    }
}
