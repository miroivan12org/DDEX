using Framework.UI.Forms;
using Business.DDEXSchemaERN_382.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business.DDEXSchemaERN_382.Schema;
using Framework.UI.Helpers;

namespace DDEX.Generation.ERN_382
{
    public partial class ERN_382TrackReleaseForm : MREditForm
    {
        public ERN_382TrackReleaseForm()
        {
            InitializeComponent();
            tbTrackRelease.BindedControls.Add(pnlMainRelease);
        }
        public ERN_382TrackReleaseForm(TrackModel model) : this()
        {
            Model = model;
        }

        public TrackModel Model { get; set; }
        public new Form ParentForm { get; set; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ERN_382TrackReleaseForm_Load(object sender, EventArgs e)
        {
            InitBindings();

            tbTechnicalDetails.BindedControls.Add(pnlTechnicalDetails);

            tbContributor1.BindedControls.Add(pnlContributor1);
            tbContributor1.OnChanged(this, new Framework.UI.Controls.MRTitleBar.TitleBarChangedEventArgs() { Expanded = (!string.IsNullOrWhiteSpace(Model.Contributor1) || !string.IsNullOrWhiteSpace(Model.Contributor1Role)) });

            tbContributor2.BindedControls.Add(pnlContributor2);
            tbContributor2.OnChanged(this, new Framework.UI.Controls.MRTitleBar.TitleBarChangedEventArgs() { Expanded = (!string.IsNullOrWhiteSpace(Model.Contributor2) || !string.IsNullOrWhiteSpace(Model.Contributor2Role)) });

            tbContributor3.BindedControls.Add(pnlContributor3);
            tbContributor3.OnChanged(this, new Framework.UI.Controls.MRTitleBar.TitleBarChangedEventArgs() { Expanded = (!string.IsNullOrWhiteSpace(Model.Contributor3) || !string.IsNullOrWhiteSpace(Model.Contributor3Role)) });

            tbContributor4.BindedControls.Add(pnlContributor4);
            tbContributor4.OnChanged(this, new Framework.UI.Controls.MRTitleBar.TitleBarChangedEventArgs() { Expanded = (!string.IsNullOrWhiteSpace(Model.Contributor4) || !string.IsNullOrWhiteSpace(Model.Contributor4Role)) });

            tbContributor5.BindedControls.Add(pnlContributor5);
            tbContributor5.OnChanged(this, new Framework.UI.Controls.MRTitleBar.TitleBarChangedEventArgs() { Expanded = (!string.IsNullOrWhiteSpace(Model.Contributor5) || !string.IsNullOrWhiteSpace(Model.Contributor5Role)) });

            tbContributor6.BindedControls.Add(pnlContributor6);
            tbContributor6.OnChanged(this, new Framework.UI.Controls.MRTitleBar.TitleBarChangedEventArgs() { Expanded = (!string.IsNullOrWhiteSpace(Model.Contributor6) || !string.IsNullOrWhiteSpace(Model.Contributor6Role)) });

            tbDisplayArtist1.BindedControls.Add(pnlDisplayArtist1);
            tbDisplayArtist1.OnChanged(this, new Framework.UI.Controls.MRTitleBar.TitleBarChangedEventArgs() { Expanded = (!string.IsNullOrWhiteSpace(Model.DisplayArtist1) || !string.IsNullOrWhiteSpace(Model.DisplayArtist1Role)) });
        }

        private void InitCombos()
        {
            cbContributor1Role.DataSource = DataSources.ComboBoxDataSources.GetComboDataSourceIndirectResourceContributorRole();
            cbContributor2Role.DataSource = DataSources.ComboBoxDataSources.GetComboDataSourceIndirectResourceContributorRole();
            cbContributor3Role.DataSource = DataSources.ComboBoxDataSources.GetComboDataSourceIndirectResourceContributorRole();
            cbContributor4Role.DataSource = DataSources.ComboBoxDataSources.GetComboDataSourceIndirectResourceContributorRole();
            cbContributor5Role.DataSource = DataSources.ComboBoxDataSources.GetComboDataSourceIndirectResourceContributorRole();
            cbContributor6Role.DataSource = DataSources.ComboBoxDataSources.GetComboDataSourceIndirectResourceContributorRole();
            cbDisplayArtistRole1.DataSource = DataSources.ComboBoxDataSources.GetComboDataSourceDisplayArtistRole();

            cbAudioCodecType.DataSource = DataSources.ComboBoxDataSources.GetComboDataSourceAudioCodecType();
        }
        private void InitBindings()
        {
            InitCombos();

            btnOpenFile.DataBindings.Add("Enabled", this, "Editable");
            txtGenre.DataBindings.Add("Text", Model, "Genre");
            txtSubGenre.DataBindings.Add("Text", Model, "SubGenre");
            txtISRC.DataBindings.Add("Text", Model, "ISRC");
            txtOrdinal.DataBindings.Add("Text", Model, "Ordinal");
            txtTitle.DataBindings.Add("Text", Model, "Title");
            txtDurationMins.DataBindings.Add("Text", Model, "DurationMin");
            txtDurationSecs.DataBindings.Add("Text", Model, "DurationSec");
            txtMainArtist.DataBindings.Add("Text", Model, "MainArtist");
            txtProducer.DataBindings.Add("Text", Model, "Producer");
            txtPLineReleaseYear.DataBindings.Add("Text", Model, "PLineReleaseYear");
            txtPLineText.DataBindings.Add("Text", Model, "PLineText");
            txtCLineReleaseYear.DataBindings.Add("Text", Model, "CLineReleaseYear");
            txtCLineText.DataBindings.Add("Text", Model, "CLineText");
            txtContributor1.DataBindings.Add("Text", Model, "Contributor1");
            cbContributor1Role.DataBindings.Add("SelectedItem", Model, "Contributor1Role");
            txtContributor2.DataBindings.Add("Text", Model, "Contributor2");
            cbContributor2Role.DataBindings.Add("SelectedItem", Model, "Contributor2Role");
            txtContributor3.DataBindings.Add("Text", Model, "Contributor3");
            cbContributor3Role.DataBindings.Add("SelectedItem", Model, "Contributor3Role");
            txtContributor4.DataBindings.Add("Text", Model, "Contributor4");
            cbContributor4Role.DataBindings.Add("SelectedItem", Model, "Contributor4Role");
            txtContributor5.DataBindings.Add("Text", Model, "Contributor5");
            cbContributor5Role.DataBindings.Add("SelectedItem", Model, "Contributor5Role");
            txtContributor6.DataBindings.Add("Text", Model, "Contributor6");
            cbContributor6Role.DataBindings.Add("SelectedItem", Model, "Contributor6Role");

            txtDisplayArtist1.DataBindings.Add("Text", Model, "DisplayArtist1");
            cbDisplayArtistRole1.DataBindings.Add("SelectedItem", Model, "DisplayArtist1Role");
            
            txtResourceReleaseDate.DataBindings.Add("Text", Model, "ResourceReleaseDate");

            cbAudioCodecType.DataBindings.Add("SelectedItem", Model, "AudioCodec");
            txtNumberOfChannels.DataBindings.Add("Text", Model, "NumberOfChannels");
            txtSamplingRate.DataBindings.Add("Text", Model, "SamplingRate");
            txtBitsPerSample.DataBindings.Add("Text", Model, "BitsPerSample");
            txtFileName.DataBindings.Add("Text", Model, "FileName");
            txtRelativePath.DataBindings.Add("Text", Model, "FilePath");

        }

        private void ERN_382TrackReleaseForm_DialogResultClicked(object sender, DialogResultEventArgs e)
        {
            if (e.Result == DialogResult.OK)
            {
                string message = "";
                Model.ComputeMaterialized();

                if (Model.IsValid(out message))
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MRMessageBox.Show(string.Format("Data not valid.\n{0}", message), MRMessageBox.eMessageBoxStyle.OK, MRMessageBox.eMessageBoxType.Error);
                }
            }
            else if (e.Result == DialogResult.Cancel)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (var fd = new OpenFileDialog() { RestoreDirectory = true, InitialDirectory = System.IO.Path.GetDirectoryName(((ERN_382GenerationFormAudioAlbumMusicOnly)ParentForm).Model.FullFileName) })
            {
                if (Model.TrackFullFileName != null && System.IO.File.Exists(Model.TrackFullFileName))
                {
                    fd.InitialDirectory = System.IO.Path.GetDirectoryName(Model.TrackFullFileName);
                    fd.FileName = System.IO.Path.GetFileName(Model.TrackFullFileName);
                }

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    string dir = System.IO.Path.GetDirectoryName(fd.FileName);
                    string modelDir = System.IO.Path.GetDirectoryName(((ERN_382GenerationFormAudioAlbumMusicOnly)ParentForm).Model.FullFileName);
                    string prePath = "";
                    if (dir.Length > modelDir.Length)
                    {
                        prePath = dir.Substring(modelDir.Length + 1);
                    }
                    
                    Model.FilePath = prePath + "/";
                    Model.TrackFullFileName = fd.FileName;
                    Model.FileName = System.IO.Path.GetFileName(fd.FileName);
                }
                else
                {
                    Model.FilePath = null;
                    Model.FileName = null;
                    Model.TrackFullFileName = null;
                }

                Model.ComputeMaterialized();
            }
        }
    }
}
