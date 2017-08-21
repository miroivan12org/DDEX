using Business.DDEXSchemaERN_382;
using Business.DDEXSchemaERN_382.Entities;
using Framework.UI.Forms;
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
        
        public NavigationModel Model { get; set; } = new NavigationModel();
        private void FilesForm_Load(object sender, EventArgs e)
        {
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
            lblPath.DataBindings.Add("Text", Model, "FolderPath");
        }

        private void tbTrackReleases_ButtonClicked(object sender, Framework.UI.Controls.MRTitleBar.ActionButtonEventArgs e)
        {
            if (e.Action == Framework.UI.Controls.MRTitleBar.eButtonAction.Add)
            {
                var model = new AudioAlbumModel() { LabelName = Properties.Settings.Default.LabelName };
                using (var frmEdit = new Generation.ERN_382.ERN_382GenerationFormAudioAlbumMusicOnly(model) { ParentForm = this })
                {
                    if (frmEdit.ShowDialog() == DialogResult.OK)
                    {
                        Model.Refresh();
                    }
                }
            }
        }
        private void dgvFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AudioAlbumModelBrowseModel record = (AudioAlbumModelBrowseModel)dgvFiles.CurrentRow.DataBoundItem;
            if (record != null)
            {
                var model = new AudioAlbumModel() { FullFileName = record.FullName };
                var frm = new Generation.ERN_382.ERN_382GenerationFormAudioAlbumMusicOnly(model) { Editable = false, ParentForm = this };
                
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
                RootFolder = Environment.SpecialFolder.MyComputer,
                ShowNewFolderButton = true
            })
            {
                if (Model != null && Directory.Exists(Model.FolderPath))
                {
                    b.SelectedPath = Model.FolderPath;
                    
                }
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

        private void dgvFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int editIndex = 0;
            int deleteIndex = 1;
            if (e.ColumnIndex == editIndex)
            {
                AudioAlbumModelBrowseModel record = (AudioAlbumModelBrowseModel)dgvFiles.CurrentRow.DataBoundItem;
                if (record != null)
                {
                    var model = new AudioAlbumModel() { FullFileName = record.FullName };
                    var frm = new Generation.ERN_382.ERN_382GenerationFormAudioAlbumMusicOnly(model) { ParentForm = this };

                    frm.MdiParent = Globals.MDIMainForm;
                    frm.Show();
                }
            }
            else if (e.ColumnIndex == deleteIndex)
            {
                if (MRMessageBox.Show("Delete file?", MRMessageBox.eMessageBoxStyle.YesNo, MRMessageBox.eMessageBoxType.Warning) == DialogResult.Yes)
                {
                    AudioAlbumModelBrowseModel record = (AudioAlbumModelBrowseModel)dgvFiles.CurrentRow.DataBoundItem;
                    if (record != null)
                    {
                        File.Delete(record.FullName);
                        Model.Refresh();
                    }
                }
            }
        }
    }
}
