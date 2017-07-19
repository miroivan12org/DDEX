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
        }

        private void InitBindings()
        {
            txtGenre.DataBindings.Add("Text", Model, "Genre");
            txtSubGenre.DataBindings.Add("Text", Model, "SubGenre");
            txtISRC.DataBindings.Add("Text", Model, "ISRC");
            txtOrdinal.DataBindings.Add("Text", Model, "Ordinal");
            txtTitle.DataBindings.Add("Text", Model, "Title");
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
