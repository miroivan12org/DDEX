namespace Framework.UI.Forms
{
    partial class MREditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlDlgRes = new Framework.UI.Controls.MRPanel(this.components);
            this.btnCancel = new Framework.UI.Controls.MRButton(this.components);
            this.btnOk = new Framework.UI.Controls.MRButton(this.components);
            this.pnlData = new Framework.UI.Controls.MRPanel(this.components);
            this.pnlDlgRes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDlgRes
            // 
            this.pnlDlgRes.Controls.Add(this.btnCancel);
            this.pnlDlgRes.Controls.Add(this.btnOk);
            this.pnlDlgRes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDlgRes.Location = new System.Drawing.Point(0, 420);
            this.pnlDlgRes.Name = "pnlDlgRes";
            this.pnlDlgRes.Size = new System.Drawing.Size(568, 24);
            this.pnlDlgRes.TabIndex = 17;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(490, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(409, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pnlData
            // 
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(568, 420);
            this.pnlData.TabIndex = 18;
            // 
            // MREditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(568, 466);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlDlgRes);
            this.Name = "MREditForm";
            this.Text = "MREditForm";
            this.Controls.SetChildIndex(this.pnlDlgRes, 0);
            this.Controls.SetChildIndex(this.pnlData, 0);
            this.pnlDlgRes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.MRPanel pnlDlgRes;
        private Controls.MRButton btnCancel;
        private Controls.MRButton btnOk;
        public Controls.MRPanel pnlData;
    }
}
