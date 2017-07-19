namespace DDEX.Generation.ERN_382
{
    partial class ERN_382TrackReleaseForm
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
            this.pnlMainReleaseParent = new Framework.UI.Controls.MRPanel(this.components);
            this.pnlMainRelease = new Framework.UI.Controls.MRPanel(this.components);
            this.label2 = new Framework.UI.Controls.MRLabel(this.components);
            this.label3 = new Framework.UI.Controls.MRLabel(this.components);
            this.txtSubGenre = new Framework.UI.Controls.MRTextBox(this.components);
            this.txtGenre = new Framework.UI.Controls.MRTextBox(this.components);
            this.label1 = new Framework.UI.Controls.MRLabel(this.components);
            this.txtOrdinal = new Framework.UI.Controls.MRTextBox(this.components);
            this.label8 = new Framework.UI.Controls.MRLabel(this.components);
            this.label7 = new Framework.UI.Controls.MRLabel(this.components);
            this.txtTitle = new Framework.UI.Controls.MRTextBox(this.components);
            this.txtISRC = new Framework.UI.Controls.MRTextBox(this.components);
            this.tbTrackRelease = new Framework.UI.Controls.MRTitleBar();
            this.mrPanel1 = new Framework.UI.Controls.MRPanel(this.components);
            this.pnlData.SuspendLayout();
            this.pnlMainReleaseParent.SuspendLayout();
            this.pnlMainRelease.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.mrPanel1);
            this.pnlData.Controls.Add(this.pnlMainReleaseParent);
            this.pnlData.Size = new System.Drawing.Size(338, 255);
            // 
            // pnlMainReleaseParent
            // 
            this.pnlMainReleaseParent.AutoSize = true;
            this.pnlMainReleaseParent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlMainReleaseParent.Controls.Add(this.pnlMainRelease);
            this.pnlMainReleaseParent.Controls.Add(this.tbTrackRelease);
            this.pnlMainReleaseParent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainReleaseParent.Location = new System.Drawing.Point(0, 0);
            this.pnlMainReleaseParent.Name = "pnlMainReleaseParent";
            this.pnlMainReleaseParent.Size = new System.Drawing.Size(338, 135);
            this.pnlMainReleaseParent.TabIndex = 16;
            // 
            // pnlMainRelease
            // 
            this.pnlMainRelease.AutoSize = true;
            this.pnlMainRelease.Controls.Add(this.label2);
            this.pnlMainRelease.Controls.Add(this.label3);
            this.pnlMainRelease.Controls.Add(this.txtSubGenre);
            this.pnlMainRelease.Controls.Add(this.txtGenre);
            this.pnlMainRelease.Controls.Add(this.label1);
            this.pnlMainRelease.Controls.Add(this.txtOrdinal);
            this.pnlMainRelease.Controls.Add(this.label8);
            this.pnlMainRelease.Controls.Add(this.label7);
            this.pnlMainRelease.Controls.Add(this.txtTitle);
            this.pnlMainRelease.Controls.Add(this.txtISRC);
            this.pnlMainRelease.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainRelease.Location = new System.Drawing.Point(0, 24);
            this.pnlMainRelease.Name = "pnlMainRelease";
            this.pnlMainRelease.Size = new System.Drawing.Size(338, 111);
            this.pnlMainRelease.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Sub Genre";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(2, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Genre";
            // 
            // txtSubGenre
            // 
            this.txtSubGenre.Location = new System.Drawing.Point(171, 89);
            this.txtSubGenre.Margin = new System.Windows.Forms.Padding(2);
            this.txtSubGenre.Name = "txtSubGenre";
            this.txtSubGenre.Size = new System.Drawing.Size(148, 20);
            this.txtSubGenre.TabIndex = 14;
            // 
            // txtGenre
            // 
            this.txtGenre.Location = new System.Drawing.Point(171, 71);
            this.txtGenre.Margin = new System.Windows.Forms.Padding(2);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(148, 20);
            this.txtGenre.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ordinal";
            // 
            // txtOrdinal
            // 
            this.txtOrdinal.Location = new System.Drawing.Point(171, 1);
            this.txtOrdinal.Margin = new System.Windows.Forms.Padding(2);
            this.txtOrdinal.Name = "txtOrdinal";
            this.txtOrdinal.Size = new System.Drawing.Size(148, 20);
            this.txtOrdinal.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(2, 49);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 18);
            this.label8.TabIndex = 7;
            this.label8.Text = "Title";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(2, 31);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 18);
            this.label7.TabIndex = 5;
            this.label7.Text = "ISRC";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(171, 47);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(148, 20);
            this.txtTitle.TabIndex = 8;
            // 
            // txtISRC
            // 
            this.txtISRC.Location = new System.Drawing.Point(171, 29);
            this.txtISRC.Margin = new System.Windows.Forms.Padding(2);
            this.txtISRC.Name = "txtISRC";
            this.txtISRC.Size = new System.Drawing.Size(148, 20);
            this.txtISRC.TabIndex = 6;
            // 
            // tbTrackRelease
            // 
            this.tbTrackRelease.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbTrackRelease.Location = new System.Drawing.Point(0, 0);
            this.tbTrackRelease.Name = "tbTrackRelease";
            this.tbTrackRelease.Size = new System.Drawing.Size(338, 24);
            this.tbTrackRelease.TabIndex = 12;
            this.tbTrackRelease.Title = "Track Release";
            // 
            // mrPanel1
            // 
            this.mrPanel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mrPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mrPanel1.Location = new System.Drawing.Point(0, 135);
            this.mrPanel1.Name = "mrPanel1";
            this.mrPanel1.Size = new System.Drawing.Size(338, 100);
            this.mrPanel1.TabIndex = 17;
            // 
            // ERN_382TrackReleaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(338, 301);
            this.Name = "ERN_382TrackReleaseForm";
            this.Text = "Track Release Edit";
            this.DialogResultClicked += new Framework.UI.Forms.MREditForm.ButtonClickEventHandler(this.ERN_382TrackReleaseForm_DialogResultClicked);
            this.Load += new System.EventHandler(this.ERN_382TrackReleaseForm_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.pnlMainReleaseParent.ResumeLayout(false);
            this.pnlMainReleaseParent.PerformLayout();
            this.pnlMainRelease.ResumeLayout(false);
            this.pnlMainRelease.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.UI.Controls.MRPanel pnlMainReleaseParent;
        private Framework.UI.Controls.MRPanel pnlMainRelease;
        private Framework.UI.Controls.MRLabel label2;
        private Framework.UI.Controls.MRLabel label3;
        private Framework.UI.Controls.MRTextBox txtSubGenre;
        private Framework.UI.Controls.MRTextBox txtGenre;
        private Framework.UI.Controls.MRLabel label1;
        private Framework.UI.Controls.MRTextBox txtOrdinal;
        private Framework.UI.Controls.MRLabel label8;
        private Framework.UI.Controls.MRLabel label7;
        private Framework.UI.Controls.MRTextBox txtTitle;
        private Framework.UI.Controls.MRTextBox txtISRC;
        private Framework.UI.Controls.MRTitleBar tbTrackRelease;
        private Framework.UI.Controls.MRPanel mrPanel1;
    }
}
