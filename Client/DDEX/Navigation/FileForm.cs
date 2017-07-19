using Framework.UI.Forms;
using Business.DDEXSchemaERN_382.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DDEX.Navigation;

namespace DDEX.Navigation
{
    public partial class FileForm : MREditForm
    {
        public FileForm()
        {
            InitializeComponent();
            tbTrackRelease.BindedControls.Add(pnlMainRelease);
        }
        public FileForm(EditXmlFileModel model) : this()
        {
            Model = model;
        }

        public EditXmlFileModel Model { get; set; }
      
        private void Form_Load(object sender, EventArgs e)
        {
            InitBindings();
        }

        private void InitBindings()
        {
            txtOrdinal.DataBindings.Add("Text", Model, "FullName");
        }

        private void Form_DialogResultClicked(object sender, DialogResultEventArgs e)
        {
            if (e.Result == DialogResult.OK)
            {
                string message = "";
                if (Model.IsValid(out message))
                {
                    if (System.IO.File.Exists(Model.FullName) && MRMessageBox.Show("File exists. Overwrite?", MRMessageBox.eMessageBoxStyle.YesNo, MRMessageBox.eMessageBoxType.Warning) == DialogResult.Yes)
                    {
                        System.IO.File.WriteAllText(Model.FullName, "");
                        DialogResult = DialogResult.OK;
                    }
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
            using (var dlg = new SaveFileDialog() { RestoreDirectory = true, InitialDirectory = Model.DirectoryName , CheckFileExists = false })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Model.FullName = dlg.FileName;
                }
            }
        }
    }
}
