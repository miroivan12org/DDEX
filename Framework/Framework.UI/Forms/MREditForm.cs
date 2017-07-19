using Business.DDEXFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Framework.UI.Interfaces;

namespace Framework.UI.Forms
{
    public partial class MREditForm : MRStatusForm, IMRControlCollectionParent
    {
        public MREditForm()
        {
            InitializeComponent();
        }
        
        private bool editable = true;
        public bool Editable
        {
            get
            {
                return editable;
            }
            set
            {
                editable = value;
                Helpers.StaticHelpers.EnableChildren(this);
            }
        }


        public class DialogResultEventArgs : EventArgs
        {
            public DialogResult Result { get; set; }
        }

        public delegate void ButtonClickEventHandler(object sender, DialogResultEventArgs e);
        public event ButtonClickEventHandler DialogResultClicked;
        protected virtual void OnDialogResultClicked(object sender, DialogResultEventArgs e)
        {
            Helpers.CrossThreadingHelpers.InvokeControl((Control)sender, null, (x) =>
            {
                DialogResultClicked?.Invoke(sender, e);
            });
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            OnDialogResultClicked(this, new DialogResultEventArgs() { Result = DialogResult.OK });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnDialogResultClicked(this, new DialogResultEventArgs() { Result = DialogResult.Cancel });
        }
    }
}
