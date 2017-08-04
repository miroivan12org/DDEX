using Framework.UI.Forms;
using Business.DDEXSchemaERN_382.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
        
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ERN_382TrackReleaseForm_Load(object sender, EventArgs e)
        {
            InitBindings();
            tbContributor1.BindedControls.Add(pnlContributor1);
            tbContributor2.BindedControls.Add(pnlContributor2);
            tbContributor3.BindedControls.Add(pnlContributor3);
            tbContributor4.BindedControls.Add(pnlContributor4);
            tbContributor5.BindedControls.Add(pnlContributor5);
            tbContributor6.BindedControls.Add(pnlContributor6);
        }

        private void InitBindings()
        {
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
            txtContributor1Role.DataBindings.Add("Text", Model, "Contributor1Role");
            txtContributor2.DataBindings.Add("Text", Model, "Contributor2");
            txtContributor2Role.DataBindings.Add("Text", Model, "Contributor2Role");
            txtContributor3.DataBindings.Add("Text", Model, "Contributor3");
            txtContributor3Role.DataBindings.Add("Text", Model, "Contributor3Role");
            txtContributor4.DataBindings.Add("Text", Model, "Contributor4");
            txtContributor4Role.DataBindings.Add("Text", Model, "Contributor4Role");
            txtContributor5.DataBindings.Add("Text", Model, "Contributor5");
            txtContributor5Role.DataBindings.Add("Text", Model, "Contributor5Role");
            txtContributor6.DataBindings.Add("Text", Model, "Contributor6");
            txtContributor6Role.DataBindings.Add("Text", Model, "Contributor6Role");
        }

        private void ERN_382TrackReleaseForm_DialogResultClicked(object sender, DialogResultEventArgs e)
        {
            if (e.Result == DialogResult.OK)
            {
                string message = "";
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
    }
}
