namespace Framework.UI.Forms
{
    partial class MRMessageBox
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
            this.lblTitle = new Framework.UI.Controls.MRLabel(this.components);
            this.pnlYesNo = new Framework.UI.Controls.MRPanel(this.components);
            this.mrButton2 = new Framework.UI.Controls.MRButton(this.components);
            this.mrButton1 = new Framework.UI.Controls.MRButton(this.components);
            this.pnlOk = new Framework.UI.Controls.MRPanel(this.components);
            this.btnOK = new Framework.UI.Controls.MRButton(this.components);
            this.pnlYesNo.SuspendLayout();
            this.pnlOk.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(67, 17);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "mrLabel1";
            // 
            // pnlYesNo
            // 
            this.pnlYesNo.Controls.Add(this.mrButton2);
            this.pnlYesNo.Controls.Add(this.mrButton1);
            this.pnlYesNo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlYesNo.Location = new System.Drawing.Point(0, 126);
            this.pnlYesNo.Name = "pnlYesNo";
            this.pnlYesNo.Size = new System.Drawing.Size(317, 24);
            this.pnlYesNo.TabIndex = 2;
            this.pnlYesNo.Visible = false;
            // 
            // mrButton2
            // 
            this.mrButton2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mrButton2.DialogResult = System.Windows.Forms.DialogResult.No;
            this.mrButton2.Location = new System.Drawing.Point(177, 0);
            this.mrButton2.Name = "mrButton2";
            this.mrButton2.Size = new System.Drawing.Size(75, 23);
            this.mrButton2.TabIndex = 1;
            this.mrButton2.Text = "No";
            this.mrButton2.UseVisualStyleBackColor = true;
            // 
            // mrButton1
            // 
            this.mrButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mrButton1.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.mrButton1.Location = new System.Drawing.Point(65, 0);
            this.mrButton1.Name = "mrButton1";
            this.mrButton1.Size = new System.Drawing.Size(75, 23);
            this.mrButton1.TabIndex = 0;
            this.mrButton1.Text = "Yes";
            this.mrButton1.UseVisualStyleBackColor = true;
            // 
            // pnlOk
            // 
            this.pnlOk.Controls.Add(this.btnOK);
            this.pnlOk.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlOk.Location = new System.Drawing.Point(0, 150);
            this.pnlOk.Name = "pnlOk";
            this.pnlOk.Size = new System.Drawing.Size(317, 24);
            this.pnlOk.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(121, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // MRMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(317, 174);
            this.ControlBox = false;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlYesNo);
            this.Controls.Add(this.pnlOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MRMessageBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.pnlYesNo.ResumeLayout(false);
            this.pnlOk.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.MRPanel pnlOk;
        private Controls.MRButton btnOK;
        private Controls.MRLabel lblTitle;
        private Controls.MRPanel pnlYesNo;
        private Controls.MRButton mrButton2;
        private Controls.MRButton mrButton1;
    }
}