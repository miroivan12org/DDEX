﻿using Framework.UI.Helpers;
using Business.DDEXSchemaERN_382.Schema;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using Business.DDEXSchemaERN_382.Entities;
using Business.DDEXSchemaERN_382;
using System.Linq;
using Framework.UI.Forms;
using DDEX.Navigation;

namespace DDEX.Generation.ERN_382
{
    public partial class ERN_382GenerationFormAudioAlbumMusicOnly : MREditForm
    {
        public ERN_382GenerationFormAudioAlbumMusicOnly()
        {
            InitializeComponent();

            if (System.Diagnostics.Debugger.IsAttached)
            {
                if (System.IO.File.Exists(@"C:\temp\DDEX\deezer\9008798224074_20170112173000222\9008798224074.xml"))
                {
                    Model = new AudioAlbumModel()
                    {
                        FullFileName = @"C:\temp\DDEX\deezer\9008798224074_20170112173000222\9008798224074.xml",
                        LabelName = AppSettings.GetInstance().LabelName
                    };
                }
            }                      
        }

        public ERN_382GenerationFormAudioAlbumMusicOnly(AudioAlbumModel model) : this()
        {
            Model.CopyFromSource(model);
        }

        public AudioAlbumModel Model = new AudioAlbumModel() { LabelName = AppSettings.GetInstance().LabelName };

        public AudioAlbumBinder Binder = new AudioAlbumBinder(new AudioAlbumBinder.AudioAlbumBinderSettings()
        {
            DeezerPartyID = AppSettings.GetInstance().DeezerRecipientPartyID,
            PandoraPartyID = AppSettings.GetInstance().PandoraRecipientPartyID,
            SoundCloudPartyID = AppSettings.GetInstance().SoundCloudRecipientPartyID
        });

        public new FilesForm ParentForm { get; set; }
        private void btnLoadXml_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Model.FullFileName = dlg.FileName;
                    
                    var xmlObject = Binder.GetXmlObjectFromFile(dlg.FileName);

                    Model = (AudioAlbumModel) Binder.GetModelFromXmlObject(xmlObject);
                    Model.FullFileName = dlg.FileName;

                    dgvSoundRecordingsAndReleases.ClearSelection();
                }
            }
        }

        private AudioAlbumModel GetModelFromFile(string fileName)
        {
            AudioAlbumModel ret = null;

            try
            {
                if (System.IO.File.Exists(fileName) && (new System.IO.FileInfo(fileName)).Length > 0)
                {
                    ret = (AudioAlbumModel)Binder.GetModelFromXmlObject(Binder.GetXmlObjectFromFile(fileName));
                    if (ret.ApproximateReleaseDate == new DateTime(1, 1, 1))
                    {
                        ret.ApproximateReleaseDate = DateTime.Now;
                    }
                    if (ret.MessageCreatedDateTime == new DateTime(1, 1, 1))
                    {
                        ret.MessageCreatedDateTime = DateTime.Now;
                    }
                    if (ret.DealStartDate == new DateTime(1, 1, 1))
                    {
                        ret.DealStartDate = DateTime.Now;
                    }

                }
            }
            catch (Exception ex)
            {
                string message = string.Format("Unable to read file {1}.\n{0}", ex.Message, fileName);
                if (Properties.Settings.Default.SYS_ShowExceptionStackTrace)
                {
                    message = string.Format("Unable to read file {1}.\n{0}\n{2}", ex.Message, fileName, ex.StackTrace);
                }                
                MRMessageBox.Show(message, MRMessageBox.eMessageBoxStyle.OK, MRMessageBox.eMessageBoxType.Error);
            }

            return ret;
        }

        private void ERN_382GenerationFormAudioAlbumMusicOnly_Load(object sender, EventArgs e)
        {
            AudioAlbumModel m = GetModelFromFile(Model.FullFileName);
            if (m != null)
            {
                Model.CopyFromSource(m);
                
            }
            
            InitBindings();
            dgvSoundRecordingsAndReleases.ClearSelection();
        }
        private void InitBindings()
        {
            lblFileFound.DataBindings.Add("Visible", Model, "FrontCoverImageFileExists");
            lblFileNotFound.DataBindings.Add("Visible", Model, "FrontCoverImageFileNotExists");
            btnImageChangeFileName.DataBindings.Add("Enabled", Model, "FrontCoverImageFileExists");

            btnOpenFrontCoverImage.DataBindings.Add("Enabled", this, "Editable");
            btnOpenFile.DataBindings.Add("Enabled", this, "Editable");

            dpGlobalReleaseDate.DataBindings.Add("Text", Model, "ApproximateReleaseDate");
            dpDealStartDate.DataBindings.Add("Text", Model, "DealStartDate");

            cbDeal.DataSource = new List<ComboBoxItem>() { new ComboBoxItem() { Text = "Standard", Value = AudioAlbumModel.eDealType.Standard } };
            cbDeal.DataBindings.Add("SelectedItem", Model, "DealType");

            cbUpdateIndicator.DataSource = new List<ComboBoxItem>() { new ComboBoxItem() { Text = "OriginalMessage", Value = UpdateIndicator.OriginalMessage }, new ComboBoxItem() { Text = "UpdateMessage", Value = UpdateIndicator.UpdateMessage } };
            tbMainRelease.BindedControls.Add(pnlMainRelease);
            tbMessageHeader.BindedControls.Add(pnlMessageHeader);
            tbTrackReleases.BindedControls.Add(dgvSoundRecordingsAndReleases);
            tbFrontCoverImage.BindedControls.Add(pnlFrontCoverImage);

            dgvSoundRecordingsAndReleases.AutoGenerateColumns = false;
            dgvSoundRecordingsAndReleases.DataSource = Model.Tracks;
            dgvSoundRecordingsAndReleases.ClearSelection();

            txtFileName.DataBindings.Add("Text", Model, "FullFileName");
            txtEAN.DataBindings.Add("Text", Model, "EAN");
            txtMainArtist.DataBindings.Add("Text", Model, "MainArtist");
            txtLabel.DataBindings.Add("Text", Model, "LabelName");
            txtGenre.DataBindings.Add("Text", Model, "Genre");
            txtSubGenre.DataBindings.Add("Text", Model, "SubGenre");

            txtMessageID.DataBindings.Add("Text", Model, "MessageID");
            txtMessageSender_PartyID.DataBindings.Add("Text", Model, "SenderPartyID");
            txtMessageSender_PartyName.DataBindings.Add("Text", Model, "SenderPartyName");
            txtMessageRecipient_PartyID.DataBindings.Add("Text", Model, "RecipientPartyID");
            txtMessageRecipient_PartyName.DataBindings.Add("Text", Model, "RecipientPartyName");

            dpMessageCreatedDateTime.DataBindings.Add("Value", Model, "MessageCreatedDateTime");

            cbUpdateIndicator.DataBindings.Add("SelectedItem", Model, "UpdateIndicator");
            
            txtMainReleaseReferenceTitle.DataBindings.Add("Text", Model, "MainReleaseReferenceTitle");

            txtFrontCoverImageRelativePath.DataBindings.Add("Text", Model, "FrontCoverImagePath");
            txtFrontCoverImageFileName.DataBindings.Add("Text", Model, "FrontCoverImageFileName");
            txtFrontCoverImageHeight.DataBindings.Add("Text", Model, "FrontCoverImageHeight_Materialized");
            txtFrontCoverImageWidth.DataBindings.Add("Text", Model, "FrontCoverImageWidth_Materialized");

            txtPLine.DataBindings.Add("Text", Model, "PLineText");
            txtCLine.DataBindings.Add("Text", Model, "CLineText");
            txtPReleaseYear.DataBindings.Add("Text", Model, "PLineReleaseYear");
            txtCReleaseYear.DataBindings.Add("Text", Model, "CLineReleaseYear");

            cbMessageControlType.DataSource = new List<ComboBoxItem>() { new ComboBoxItem() { Text = "LiveMessage", Value = "LiveMessage" }, new ComboBoxItem() { Text = "TestMessage", Value = "TestMessage"} };
            cbMessageControlType.DataBindings.Add("SelectedItem", Model, "MessageControlType");
            
        }

        private void tbTrackReleases_ButtonClicked(object sender, Framework.UI.Controls.MRTitleBar.ActionButtonEventArgs e)
        {
            if (e.Action == Framework.UI.Controls.MRTitleBar.eButtonAction.Add)
            {
                var track = new TrackModel() { Ordinal = 1, Parent = Model };

                if (Model.Tracks.Any())
                {
                    track.Ordinal = Model.Tracks.Max(x => x.Ordinal) + 1;
                    track.PLineText = AppSettings.GetInstance().PLineText;
                    track.CLineText = AppSettings.GetInstance().PLineText;
                }

                using (var frm = new ERN_382TrackReleaseForm(track) { Editable = this.Editable, ParentForm = this })
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Model.Tracks.Add(track);
                        dgvSoundRecordingsAndReleases.ClearSelection();
                    }
                }
            }
            else if (e.Action == Framework.UI.Controls.MRTitleBar.eButtonAction.Copy)
            {
                TrackModel selectedTrack = (TrackModel)dgvSoundRecordingsAndReleases.CurrentRow.DataBoundItem;
                if (selectedTrack != null)
                {
                    TrackModel track  = (TrackModel) selectedTrack.Copy();
                    track.Ordinal = Model.Tracks.Max(x => x.Ordinal) + 1;

                    using (var frm = new ERN_382TrackReleaseForm(track) { Editable = this.Editable, ParentForm = this })
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            Model.Tracks.Add(track);
                            dgvSoundRecordingsAndReleases.ClearSelection();
                        }
                    }
                }
            }
            
        }

        private void dgvSoundRecordingsAndReleases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int editIndex = 0;
            int deleteIndex = 1;
            if (e.ColumnIndex == editIndex)
            {
                TrackModel track = (TrackModel) dgvSoundRecordingsAndReleases.CurrentRow.DataBoundItem;
                if (track != null)
                {
                    using (var frm = new ERN_382TrackReleaseForm((TrackModel)track.Copy()) {  Editable = this.Editable, ParentForm = this })
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            track.CopyFromSource(frm.Model);
                        }
                    }
                }
            }
            else if (e.ColumnIndex == deleteIndex && this.Editable)
            {
                using (var f = new MRMessageBox("Delete record?", MRMessageBox.eMessageBoxStyle.YesNo))
                {
                    if (f.ShowDialog() == DialogResult.Yes)
                    {
                        dgvSoundRecordingsAndReleases.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }

        }
        private void dgvSoundRecordingsAndReleases_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TrackModel track = (TrackModel)dgvSoundRecordingsAndReleases.CurrentRow.DataBoundItem;
            if (track != null)
            {
                using (var frm = new ERN_382TrackReleaseForm((TrackModel)track.Copy()) { Editable = false, ParentForm = this })
                {
                    frm.ShowDialog();                    
                }
            }

        }

        private void SaveDialog()
        {
            string message = "";
            string message2 = "";
            if (Editable)
            {
                string fileName = Model.FullFileName;
                Action saveFileAction = (() => {
                    Binder.WriteXmlObjectToFile(Binder.GetXmlObjectFromModel(Model), Model);
                    DialogResult = DialogResult.OK;
                });

                Func<bool> fileIsReadOnly = () => {
                    System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
                    return ((fi.Attributes & System.IO.FileAttributes.ReadOnly) == System.IO.FileAttributes.ReadOnly);
                };

                if (Model.IsValid(out message) && IsXmlFileValid(out message2))
                {
                    try
                    {
                        saveFileAction.Invoke();
                    }
                    catch (UnauthorizedAccessException)
                    {
                        while (fileIsReadOnly.Invoke() && MRMessageBox.Show("File is in read only state.\nTo make it writable right click on it in windows explorer and remove the readonly flag.\nTry again?", MRMessageBox.eMessageBoxStyle.YesNo, MRMessageBox.eMessageBoxType.Warning) == DialogResult.Yes)
                        {
                            try
                            {
                                saveFileAction.Invoke();
                            }
                            catch (UnauthorizedAccessException)
                            {                                    
                                // RETRY
                            }
                        }
                    }
                }
                else
                {
                    rtbOutput.Text = message2 + "---\n" + rtbOutput.Text.ToString() + "\n";
                    if (MRMessageBox.Show(string.Format("Data not valid.\n{0}\n{1}\n\nDo you wish to save invalid xml file? ", message, message2), MRMessageBox.eMessageBoxStyle.YesNo, MRMessageBox.eMessageBoxType.Error, 300) == DialogResult.Yes)
                    {
                        saveFileAction.Invoke();
                    }
                }
            }

            ParentForm.Model.Refresh();
            Close();
            Dispose();
        }
        private void mrButton1_Click(object sender, EventArgs e)
        {
            if (Model != null)
            {
                Model.ComputeMaterialized();
            }
            SaveDialog();
        }

        private void Form_DialogResultClicked(object sender, DialogResultEventArgs e)
        {
            if (Model != null)
            {
                Model.ComputeMaterialized();
            }
            if (e.Result == DialogResult.OK)
            {
                SaveDialog();
            }
            else if (e.Result == DialogResult.Cancel)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                Dispose();
            }
            
        }

        private bool IsXmlFileValid(out string msg)
        {
            return Binder.IsModelValid(Model, out msg);
        }        

        private void btnOpenFrontCoverImage_Click(object sender, EventArgs e)
        {
            using (var fd = new OpenFileDialog() { RestoreDirectory = true, InitialDirectory = System.IO.Path.GetDirectoryName(Model.FullFileName) })
            {
                if (Model.FrontCoverImageFullFileName != null && System.IO.File.Exists(Model.FrontCoverImageFullFileName))
                {
                    fd.InitialDirectory = System.IO.Path.GetDirectoryName(Model.FrontCoverImageFullFileName);
                    fd.FileName = System.IO.Path.GetFileName(Model.FrontCoverImageFullFileName);
                }

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    Model.FrontCoverImageFileName = System.IO.Path.GetFileName(fd.FileName);
                    string dir = System.IO.Path.GetDirectoryName(fd.FileName);
                    string modelDir = System.IO.Path.GetDirectoryName(Model.FullFileName);
                    string prePath = "";
                    if (dir.Length > modelDir.Length)
                    {
                        prePath = dir.Substring(modelDir.Length + 1);
                    }
                    Model.FrontCoverImagePath = prePath + "/";

                    Model.FrontCoverImageFullFileName = fd.FileName;
                }
                else
                {
                    Model.FrontCoverImagePath = null;
                    Model.FrontCoverImageFileName = null;
                    Model.FrontCoverImageFullFileName = null;
                }

                Model.ComputeMaterialized();
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog()
            {
                RestoreDirectory = true,
                CheckFileExists = false
            }
            )
            {
                if (ParentForm != null && ParentForm.Model != null && ParentForm.Model.FolderPath != null && System.IO.Directory.Exists(ParentForm.Model.FolderPath))
                {
                    dlg.InitialDirectory = ParentForm.Model.FolderPath;
                }

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Model.FullFileName = dlg.FileName;
                }
            }
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            if (sender == btnTemplateDeezer)
            {
                Model.RecipientPartyName = AppSettings.GetInstance().DeezerRecipientPartyName;
                Model.RecipientPartyID = AppSettings.GetInstance().DeezerRecipientPartyID;
                Model.SenderPartyID = AppSettings.GetInstance().SenderPartyID;
                Model.SenderPartyName = AppSettings.GetInstance().SenderPartyName;
                Model.MusicService = AudioAlbumModel.eMusicService.Deezer;
            }
            else if(sender == btnTemplatePandora)
            {
                Model.RecipientPartyName = AppSettings.GetInstance().PandoraRecipientPartyName;
                Model.RecipientPartyID = AppSettings.GetInstance().PandoraRecipientPartyID;
                Model.SenderPartyID = AppSettings.GetInstance().SenderPartyID;
                Model.SenderPartyName = AppSettings.GetInstance().SenderPartyName;
                Model.MusicService = AudioAlbumModel.eMusicService.Pandora;
            }
            else if (sender == btnTemplateSoundcloud)
            {
                Model.RecipientPartyName = AppSettings.GetInstance().SoundCloudRecipientPartyName;
                Model.RecipientPartyID = AppSettings.GetInstance().SoundCloudRecipientPartyID;
                Model.SenderPartyID = AppSettings.GetInstance().SenderPartyID;
                Model.SenderPartyName = AppSettings.GetInstance().SenderPartyName;
                Model.MusicService = AudioAlbumModel.eMusicService.SoundCloud;
            }
        }

        private void btnImageChangeFileName_Click(object sender, EventArgs e)
        {
            if (Model.FrontCoverImageFullFileName != null && System.IO.File.Exists(Model.FrontCoverImageFullFileName))
            {
                string name = Model.CalculateFrontCoverImageFileName();
                if (!Equals(name.ToUpper(), Model.FrontCoverImageFileName.Substring(0, Model.FrontCoverImageFileName.LastIndexOf('.')).ToUpper()))
                {
                    string directory = System.IO.Path.GetDirectoryName(Model.FrontCoverImageFullFileName);
                    string ext = System.IO.Path.GetExtension(Model.FrontCoverImageFullFileName);
                    string newFileName = System.IO.Path.Combine(directory, name + ext);
                    System.IO.File.Move(Model.FrontCoverImageFullFileName, newFileName);
                    Model.FrontCoverImageFileName = name + ext;
                    Model.FrontCoverImageFullFileName = newFileName;
                    Model.ComputeMaterialized();
                }
            }
        }

        private void cbMessageControlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Model.MessageControlType = (MessageControlType)((ComboBoxItem)cbMessageControlType.SelectedItem).Value;
        }
    }
    
}
