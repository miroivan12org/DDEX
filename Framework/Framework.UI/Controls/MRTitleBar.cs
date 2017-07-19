using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework.UI.Forms;
using Framework.UI.Interfaces;

namespace Framework.UI.Controls
{
    public partial class MRTitleBar : UserControl, IMREditableControl, IMRControlCollectionParent
    {
        public MRTitleBar()
        {
            InitializeComponent();
        }

        private Color titleColor = Color.LightGoldenrodYellow;
        [DefaultValue(typeof(Color), "LightGoldenrodYellow")]
        public Color TitleColor
        {
            get
            {
                return titleColor;
            }
            set
            {
                titleColor = value;
                BindToControl();
            }
        }
            

        private string title = "Title";
        [DefaultValue("Title")]
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                BindToControl();
            }
        }
        private void BindToControl()
        {
            lblTitle.Text = Title;
            pnlTitle.BackColor = titleColor;
            btnCollapse.Visible = expanded;
            btnExpand.Visible = !expanded;
            btnAdd.Visible = addVisible;
        }

        private bool expanded = true;
        [DefaultValue(true)]
        public bool Expanded
        {
            get
            {
                return expanded;
            }
            set
            {
                expanded = value;
                BindToControl();
            }
        }

        private bool addVisible = false;
        [DefaultValue(false)]
        public bool AddVisible
        {
            get
            {
                return addVisible;
            }
            set
            {
                addVisible = value;
                BindToControl();
            }
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            OnChanged(this, new TitleBarChangedEventArgs() { Expanded = false });
        }
        private void btnExpand_Click(object sender, EventArgs e)
        {            
            OnChanged(this, new TitleBarChangedEventArgs() { Expanded = true });
        }

        public class TitleBarChangedEventArgs : EventArgs
        {
            public bool Expanded { get; set; }
        }

        public delegate void ChangedEventHandler(object sender, TitleBarChangedEventArgs e);
        public event ChangedEventHandler Changed;
        public virtual void OnChanged(object sender, TitleBarChangedEventArgs e)
        {
            Expanded = e.Expanded;
            BindedControls.ForEach(x => x.Visible = e.Expanded);
            Changed?.Invoke(sender, e);
        }

        public List<Control> BindedControls { get; } = new List<Control>();

        [DefaultValue(true)]
        public bool IgnoreParentsEnabled { get; set; } = true;
        
        public delegate void ButtonClickedEventHandler(object sender, ActionButtonEventArgs e);
        public event ButtonClickedEventHandler ButtonClicked;
        public virtual void OnButtonClicked(object sender, ActionButtonEventArgs e)
        {
            ButtonClicked?.Invoke(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OnButtonClicked(sender, new ActionButtonEventArgs() {  Action = eButtonAction.Add });
        }

        public enum eButtonAction
        {
            Add
        }

        public class ActionButtonEventArgs : EventArgs
        {
            public eButtonAction Action;
        }

        private bool editable = true;
        [DefaultValue(true)]
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


    }
}

