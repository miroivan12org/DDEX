using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Framework.UI.Forms
{
    public partial class MRMessageBox : Form
    {
        public MRMessageBox()
        {
            InitializeComponent();
        }
        public MRMessageBox(string message, eMessageBoxStyle messageBoxStyle) : this()
        {
            lblTitle.Text = SplitStringWithNewLines(message);
            MessageBoxStyle = messageBoxStyle;
        }

        public MRMessageBox(string message, eMessageBoxStyle messageBoxStyle, int lineLength) : this(message, messageBoxStyle)
        {
            LineLength = lineLength;
            lblTitle.Text = SplitStringWithNewLines(message);
        }
        [DefaultValue(DEFAULT_LINE_LENGTH)]
        public int LineLength { get; set; } = DEFAULT_LINE_LENGTH;
        public enum eMessageBoxStyle
        {
            YesNo,
            OK
        }

        private eMessageBoxStyle messageBoxStyle = eMessageBoxStyle.OK;
        public eMessageBoxStyle MessageBoxStyle
        {
            get
            {
                return messageBoxStyle;
            }
            set
            {
                messageBoxStyle = value;
                BindToForm();
            }
        }

        public enum eMessageBoxType
        {
            Warning,
            Error,
            Info
        }

        private eMessageBoxType messageBoxType = eMessageBoxType.Info;
        public eMessageBoxType MessageBoxType
        {
            get
            {
                return messageBoxType;
            }
            set
            {
                messageBoxType = value;
                BindToForm();
            }
        }

        public Color TitleColor
        {
            get
            {
                Color ret = Color.RoyalBlue;
                if (messageBoxType == eMessageBoxType.Warning)
                    ret = Color.Orange;
                else if (messageBoxType == eMessageBoxType.Error)
                    ret = Color.Red;

                return ret;
            }
        }
        public string FormTitle
        {
            get
            {
                string ret = "Informacija";
                if (messageBoxType == eMessageBoxType.Warning)
                    ret = "Upozorenje";
                else if (messageBoxType == eMessageBoxType.Error)
                    ret = "Greška!";

                return ret;
            }
        }

        private void BindToForm()
        {
            lblTitle.ForeColor = TitleColor;
            Text = FormTitle;
            pnlYesNo.Visible = MessageBoxStyle == eMessageBoxStyle.YesNo;
            pnlOk.Visible = messageBoxStyle == eMessageBoxStyle.OK;
        }

        private string SplitStringWithNewLines(string s)
        {
            string ret = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (i % LineLength == 0 && i != 0) ret += "\n";
                ret += s[i];
            }

            return ret;
        }
        private const int DEFAULT_LINE_LENGTH = 300;
        public static DialogResult Show(string message, eMessageBoxStyle style, eMessageBoxType type, int lineLength = DEFAULT_LINE_LENGTH)
        {
            using (var frm = new MRMessageBox(message, style, lineLength) {  MessageBoxType = type })
            {
                return frm.ShowDialog();
            }
        }

    }
}
