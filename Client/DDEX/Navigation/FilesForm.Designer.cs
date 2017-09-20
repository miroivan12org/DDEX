﻿namespace DDEX.Navigation
{
    partial class FilesForm
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
            this.groupBox1 = new Framework.UI.Controls.MRGroupBox(this.components);
            this.btnValidateAll = new Framework.UI.Controls.MRButton(this.components);
            this.chxbSubFolders = new Framework.UI.Controls.MRCheckBox(this.components);
            this.btnOpenFolder = new Framework.UI.Controls.MRButton(this.components);
            this.lblPath = new Framework.UI.Controls.MRLabel(this.components);
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.csEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.csDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.csTrackTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Extension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DirectoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastWriteTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csIsValid_Materialized = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ValidationMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbFiles = new Framework.UI.Controls.MRTitleBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnValidateAll);
            this.groupBox1.Controls.Add(this.chxbSubFolders);
            this.groupBox1.Controls.Add(this.btnOpenFolder);
            this.groupBox1.Controls.Add(this.lblPath);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(890, 45);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loaded Navigation Folder";
            // 
            // btnValidateAll
            // 
            this.btnValidateAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidateAll.Location = new System.Drawing.Point(819, 15);
            this.btnValidateAll.Name = "btnValidateAll";
            this.btnValidateAll.Size = new System.Drawing.Size(66, 23);
            this.btnValidateAll.TabIndex = 3;
            this.btnValidateAll.Text = "Validate";
            this.btnValidateAll.UseVisualStyleBackColor = true;
            this.btnValidateAll.Click += new System.EventHandler(this.btnValidateAll_Click);
            // 
            // chxbSubFolders
            // 
            this.chxbSubFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chxbSubFolders.AutoSize = true;
            this.chxbSubFolders.Location = new System.Drawing.Point(722, 19);
            this.chxbSubFolders.Name = "chxbSubFolders";
            this.chxbSubFolders.Size = new System.Drawing.Size(100, 17);
            this.chxbSubFolders.TabIndex = 2;
            this.chxbSubFolders.Text = "scan subfolders";
            this.chxbSubFolders.UseVisualStyleBackColor = true;
            this.chxbSubFolders.CheckedChanged += new System.EventHandler(this.chxbSubFolders_CheckedChanged);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFolder.Location = new System.Drawing.Point(691, 15);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(25, 23);
            this.btnOpenFolder.TabIndex = 1;
            this.btnOpenFolder.Text = "...";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // lblPath
            // 
            this.lblPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPath.Location = new System.Drawing.Point(9, 15);
            this.lblPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(677, 23);
            this.lblPath.TabIndex = 0;
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToDeleteRows = false;
            this.dgvFiles.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.csEdit,
            this.csDelete,
            this.csTrackTitle,
            this.Extension,
            this.DirectoryName,
            this.csFileSize,
            this.LastWriteTime,
            this.csIsValid_Materialized,
            this.ValidationMessage});
            this.dgvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFiles.GridColor = System.Drawing.Color.DarkGray;
            this.dgvFiles.Location = new System.Drawing.Point(0, 69);
            this.dgvFiles.MultiSelect = false;
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.ReadOnly = true;
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiles.Size = new System.Drawing.Size(890, 312);
            this.dgvFiles.TabIndex = 17;
            this.dgvFiles.TabStop = false;
            this.dgvFiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiles_CellClick);
            this.dgvFiles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiles_CellDoubleClick);
            // 
            // csEdit
            // 
            this.csEdit.FillWeight = 12.16545F;
            this.csEdit.HeaderText = "";
            this.csEdit.Image = global::DDEX.Properties.Resources.Edit;
            this.csEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.csEdit.MinimumWidth = 20;
            this.csEdit.Name = "csEdit";
            this.csEdit.ReadOnly = true;
            this.csEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.csEdit.ToolTipText = "Edit selected record";
            this.csEdit.Width = 20;
            // 
            // csDelete
            // 
            this.csDelete.FillWeight = 27.22915F;
            this.csDelete.HeaderText = "";
            this.csDelete.Image = global::DDEX.Properties.Resources.Delete;
            this.csDelete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.csDelete.MinimumWidth = 20;
            this.csDelete.Name = "csDelete";
            this.csDelete.ReadOnly = true;
            this.csDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.csDelete.Width = 20;
            // 
            // csTrackTitle
            // 
            this.csTrackTitle.DataPropertyName = "Name";
            this.csTrackTitle.FillWeight = 170.5285F;
            this.csTrackTitle.HeaderText = "Name";
            this.csTrackTitle.Name = "csTrackTitle";
            this.csTrackTitle.ReadOnly = true;
            // 
            // Extension
            // 
            this.Extension.DataPropertyName = "Extension";
            this.Extension.HeaderText = "Type";
            this.Extension.Name = "Extension";
            this.Extension.ReadOnly = true;
            // 
            // DirectoryName
            // 
            this.DirectoryName.DataPropertyName = "DirectoryName";
            this.DirectoryName.HeaderText = "Folder";
            this.DirectoryName.Name = "DirectoryName";
            this.DirectoryName.ReadOnly = true;
            this.DirectoryName.Width = 200;
            // 
            // csFileSize
            // 
            this.csFileSize.DataPropertyName = "Size";
            this.csFileSize.HeaderText = "Size [B]";
            this.csFileSize.Name = "csFileSize";
            this.csFileSize.ReadOnly = true;
            this.csFileSize.Width = 50;
            // 
            // LastWriteTime
            // 
            this.LastWriteTime.DataPropertyName = "LastWriteTime";
            this.LastWriteTime.HeaderText = "LastWriteTime";
            this.LastWriteTime.Name = "LastWriteTime";
            this.LastWriteTime.ReadOnly = true;
            // 
            // csIsValid_Materialized
            // 
            this.csIsValid_Materialized.DataPropertyName = "IsValid_Materialized";
            this.csIsValid_Materialized.HeaderText = "Is Valid";
            this.csIsValid_Materialized.Name = "csIsValid_Materialized";
            this.csIsValid_Materialized.ReadOnly = true;
            this.csIsValid_Materialized.Width = 50;
            // 
            // ValidationMessage
            // 
            this.ValidationMessage.DataPropertyName = "ValidationMessage";
            this.ValidationMessage.HeaderText = "Xml Validation Message";
            this.ValidationMessage.Name = "ValidationMessage";
            this.ValidationMessage.ReadOnly = true;
            this.ValidationMessage.Width = 200;
            // 
            // tbFiles
            // 
            this.tbFiles.AddVisible = true;
            this.tbFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbFiles.Location = new System.Drawing.Point(0, 45);
            this.tbFiles.Name = "tbFiles";
            this.tbFiles.Size = new System.Drawing.Size(890, 24);
            this.tbFiles.TabIndex = 18;
            this.tbFiles.Title = "Files";
            this.tbFiles.ButtonClicked += new Framework.UI.Controls.MRTitleBar.ButtonClickedEventHandler(this.tbTrackReleases_ButtonClicked);
            // 
            // FilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(890, 403);
            this.Controls.Add(this.dgvFiles);
            this.Controls.Add(this.tbFiles);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FilesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Text = "Files Form";
            this.Load += new System.EventHandler(this.FilesForm_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.tbFiles, 0);
            this.Controls.SetChildIndex(this.dgvFiles, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.UI.Controls.MRGroupBox groupBox1;
        private Framework.UI.Controls.MRLabel lblPath;
        private System.Windows.Forms.DataGridView dgvFiles;
        private Framework.UI.Controls.MRTitleBar tbFiles;
        private Framework.UI.Controls.MRButton btnOpenFolder;
        private Framework.UI.Controls.MRCheckBox chxbSubFolders;
        private Framework.UI.Controls.MRButton btnValidateAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn csValidationMessage;
        private System.Windows.Forms.DataGridViewImageColumn csEdit;
        private System.Windows.Forms.DataGridViewImageColumn csDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn csTrackTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Extension;
        private System.Windows.Forms.DataGridViewTextBoxColumn DirectoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn csFileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastWriteTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn csIsValid_Materialized;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValidationMessage;
    }
}
