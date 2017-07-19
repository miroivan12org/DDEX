namespace DDEX.Generation.ERN_382
{
    partial class ERN_382GenerationFormAudioAlbumMusicOnly
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
            this.lblPath = new Framework.UI.Controls.MRLabel(this.components);
            this.btnLoadXml = new Framework.UI.Controls.MRButton(this.components);
            this.groupBox2 = new Framework.UI.Controls.MRGroupBox(this.components);
            this.pnlFrontCoverImageParent = new Framework.UI.Controls.MRPanel(this.components);
            this.pnlFrontCoverImage = new Framework.UI.Controls.MRPanel(this.components);
            this.label13 = new Framework.UI.Controls.MRLabel(this.components);
            this.txtFrontCoverImageResourceReference = new Framework.UI.Controls.MRTextBox(this.components);
            this.tbFrontCoverImage = new Framework.UI.Controls.MRTitleBar();
            this.pnlTrackReleasesParent = new Framework.UI.Controls.MRPanel(this.components);
            this.dgvSoundRecordingsAndReleases = new System.Windows.Forms.DataGridView();
            this.csEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.csDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.csTracksOrdinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csTracksISRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csTrackTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbTrackReleases = new Framework.UI.Controls.MRTitleBar();
            this.mrPanel1 = new Framework.UI.Controls.MRPanel(this.components);
            this.pnlMessageHeaderParent = new Framework.UI.Controls.MRPanel(this.components);
            this.pnlMessageHeader = new Framework.UI.Controls.MRPanel(this.components);
            this.dpMessageCreatedDateTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new Framework.UI.Controls.MRLabel(this.components);
            this.label6 = new Framework.UI.Controls.MRLabel(this.components);
            this.txtMessageID = new Framework.UI.Controls.MRTextBox(this.components);
            this.label4 = new Framework.UI.Controls.MRLabel(this.components);
            this.txtMessageSender_PartyID = new Framework.UI.Controls.MRTextBox(this.components);
            this.txtMessageRecipient_PartyName = new Framework.UI.Controls.MRTextBox(this.components);
            this.label2 = new Framework.UI.Controls.MRLabel(this.components);
            this.label5 = new Framework.UI.Controls.MRLabel(this.components);
            this.txtMessageSender_PartyName = new Framework.UI.Controls.MRTextBox(this.components);
            this.txtMessageRecipient_PartyID = new Framework.UI.Controls.MRTextBox(this.components);
            this.label3 = new Framework.UI.Controls.MRLabel(this.components);
            this.tbMessageHeader = new Framework.UI.Controls.MRTitleBar();
            this.pnlMainReleaseParent = new Framework.UI.Controls.MRPanel(this.components);
            this.pnlMainRelease = new Framework.UI.Controls.MRPanel(this.components);
            this.label8 = new Framework.UI.Controls.MRLabel(this.components);
            this.label7 = new Framework.UI.Controls.MRLabel(this.components);
            this.cbUpdateIndicator = new System.Windows.Forms.ComboBox();
            this.label12 = new Framework.UI.Controls.MRLabel(this.components);
            this.txtMainReleaseReferenceTitle = new Framework.UI.Controls.MRTextBox(this.components);
            this.txtEAN = new Framework.UI.Controls.MRTextBox(this.components);
            this.tbMainRelease = new Framework.UI.Controls.MRTitleBar();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlFrontCoverImageParent.SuspendLayout();
            this.pnlFrontCoverImage.SuspendLayout();
            this.pnlTrackReleasesParent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoundRecordingsAndReleases)).BeginInit();
            this.mrPanel1.SuspendLayout();
            this.pnlMessageHeaderParent.SuspendLayout();
            this.pnlMessageHeader.SuspendLayout();
            this.pnlMainReleaseParent.SuspendLayout();
            this.pnlMainRelease.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Size = new System.Drawing.Size(848, 596);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPath);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(848, 45);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loaded file";
            // 
            // lblPath
            // 
            this.lblPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPath.Location = new System.Drawing.Point(9, 15);
            this.lblPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(830, 23);
            this.lblPath.TabIndex = 0;
            // 
            // btnLoadXml
            // 
            this.btnLoadXml.Location = new System.Drawing.Point(19, 2);
            this.btnLoadXml.Name = "btnLoadXml";
            this.btnLoadXml.Size = new System.Drawing.Size(92, 52);
            this.btnLoadXml.TabIndex = 4;
            this.btnLoadXml.Text = "Load XML";
            this.btnLoadXml.UseVisualStyleBackColor = true;
            this.btnLoadXml.Click += new System.EventHandler(this.btnLoadXml_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlFrontCoverImageParent);
            this.groupBox2.Controls.Add(this.pnlTrackReleasesParent);
            this.groupBox2.Controls.Add(this.mrPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 45);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(848, 551);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loaded Xml Model";
            // 
            // pnlFrontCoverImageParent
            // 
            this.pnlFrontCoverImageParent.AutoSize = true;
            this.pnlFrontCoverImageParent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlFrontCoverImageParent.Controls.Add(this.pnlFrontCoverImage);
            this.pnlFrontCoverImageParent.Controls.Add(this.tbFrontCoverImage);
            this.pnlFrontCoverImageParent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFrontCoverImageParent.Location = new System.Drawing.Point(2, 270);
            this.pnlFrontCoverImageParent.Name = "pnlFrontCoverImageParent";
            this.pnlFrontCoverImageParent.Size = new System.Drawing.Size(844, 66);
            this.pnlFrontCoverImageParent.TabIndex = 19;
            // 
            // pnlFrontCoverImage
            // 
            this.pnlFrontCoverImage.AutoSize = true;
            this.pnlFrontCoverImage.Controls.Add(this.label13);
            this.pnlFrontCoverImage.Controls.Add(this.txtFrontCoverImageResourceReference);
            this.pnlFrontCoverImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFrontCoverImage.Location = new System.Drawing.Point(0, 24);
            this.pnlFrontCoverImage.Name = "pnlFrontCoverImage";
            this.pnlFrontCoverImage.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlFrontCoverImage.Size = new System.Drawing.Size(844, 42);
            this.pnlFrontCoverImage.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(15, 10);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 18);
            this.label13.TabIndex = 0;
            this.label13.Text = "ResourceReference";
            // 
            // txtFrontCoverImageResourceReference
            // 
            this.txtFrontCoverImageResourceReference.Location = new System.Drawing.Point(183, 10);
            this.txtFrontCoverImageResourceReference.Margin = new System.Windows.Forms.Padding(2);
            this.txtFrontCoverImageResourceReference.Name = "txtFrontCoverImageResourceReference";
            this.txtFrontCoverImageResourceReference.Size = new System.Drawing.Size(148, 20);
            this.txtFrontCoverImageResourceReference.TabIndex = 1;
            // 
            // tbFrontCoverImage
            // 
            this.tbFrontCoverImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbFrontCoverImage.Location = new System.Drawing.Point(0, 0);
            this.tbFrontCoverImage.Name = "tbFrontCoverImage";
            this.tbFrontCoverImage.Size = new System.Drawing.Size(844, 24);
            this.tbFrontCoverImage.TabIndex = 0;
            // 
            // pnlTrackReleasesParent
            // 
            this.pnlTrackReleasesParent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlTrackReleasesParent.Controls.Add(this.dgvSoundRecordingsAndReleases);
            this.pnlTrackReleasesParent.Controls.Add(this.tbTrackReleases);
            this.pnlTrackReleasesParent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTrackReleasesParent.Location = new System.Drawing.Point(2, 164);
            this.pnlTrackReleasesParent.Name = "pnlTrackReleasesParent";
            this.pnlTrackReleasesParent.Size = new System.Drawing.Size(844, 106);
            this.pnlTrackReleasesParent.TabIndex = 17;
            // 
            // dgvSoundRecordingsAndReleases
            // 
            this.dgvSoundRecordingsAndReleases.AllowUserToAddRows = false;
            this.dgvSoundRecordingsAndReleases.AllowUserToDeleteRows = false;
            this.dgvSoundRecordingsAndReleases.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvSoundRecordingsAndReleases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSoundRecordingsAndReleases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.csEdit,
            this.csDelete,
            this.csTracksOrdinal,
            this.csTracksISRC,
            this.csTrackTitle});
            this.dgvSoundRecordingsAndReleases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSoundRecordingsAndReleases.GridColor = System.Drawing.Color.DarkGray;
            this.dgvSoundRecordingsAndReleases.Location = new System.Drawing.Point(0, 24);
            this.dgvSoundRecordingsAndReleases.MultiSelect = false;
            this.dgvSoundRecordingsAndReleases.Name = "dgvSoundRecordingsAndReleases";
            this.dgvSoundRecordingsAndReleases.ReadOnly = true;
            this.dgvSoundRecordingsAndReleases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSoundRecordingsAndReleases.Size = new System.Drawing.Size(844, 82);
            this.dgvSoundRecordingsAndReleases.TabIndex = 3;
            this.dgvSoundRecordingsAndReleases.TabStop = false;
            this.dgvSoundRecordingsAndReleases.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSoundRecordingsAndReleases_CellClick);
            this.dgvSoundRecordingsAndReleases.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSoundRecordingsAndReleases_CellDoubleClick);
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
            // csTracksOrdinal
            // 
            this.csTracksOrdinal.DataPropertyName = "Ordinal";
            this.csTracksOrdinal.FillWeight = 136.2605F;
            this.csTracksOrdinal.HeaderText = "Ordinal";
            this.csTracksOrdinal.Name = "csTracksOrdinal";
            this.csTracksOrdinal.ReadOnly = true;
            // 
            // csTracksISRC
            // 
            this.csTracksISRC.DataPropertyName = "ISRC";
            this.csTracksISRC.FillWeight = 153.8164F;
            this.csTracksISRC.HeaderText = "ISRC";
            this.csTracksISRC.Name = "csTracksISRC";
            this.csTracksISRC.ReadOnly = true;
            // 
            // csTrackTitle
            // 
            this.csTrackTitle.DataPropertyName = "Title";
            this.csTrackTitle.FillWeight = 170.5285F;
            this.csTrackTitle.HeaderText = "Title";
            this.csTrackTitle.Name = "csTrackTitle";
            this.csTrackTitle.ReadOnly = true;
            this.csTrackTitle.Width = 280;
            // 
            // tbTrackReleases
            // 
            this.tbTrackReleases.AddVisible = true;
            this.tbTrackReleases.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbTrackReleases.Location = new System.Drawing.Point(0, 0);
            this.tbTrackReleases.Name = "tbTrackReleases";
            this.tbTrackReleases.Size = new System.Drawing.Size(844, 24);
            this.tbTrackReleases.TabIndex = 16;
            this.tbTrackReleases.Title = "Track Releases";
            this.tbTrackReleases.ButtonClicked += new Framework.UI.Controls.MRTitleBar.ButtonClickedEventHandler(this.tbTrackReleases_ButtonClicked);
            // 
            // mrPanel1
            // 
            this.mrPanel1.AutoSize = true;
            this.mrPanel1.Controls.Add(this.pnlMessageHeaderParent);
            this.mrPanel1.Controls.Add(this.pnlMainReleaseParent);
            this.mrPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mrPanel1.Location = new System.Drawing.Point(2, 15);
            this.mrPanel1.Name = "mrPanel1";
            this.mrPanel1.Size = new System.Drawing.Size(844, 149);
            this.mrPanel1.TabIndex = 18;
            // 
            // pnlMessageHeaderParent
            // 
            this.pnlMessageHeaderParent.AutoSize = true;
            this.pnlMessageHeaderParent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlMessageHeaderParent.Controls.Add(this.pnlMessageHeader);
            this.pnlMessageHeaderParent.Controls.Add(this.tbMessageHeader);
            this.pnlMessageHeaderParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMessageHeaderParent.Location = new System.Drawing.Point(352, 0);
            this.pnlMessageHeaderParent.Name = "pnlMessageHeaderParent";
            this.pnlMessageHeaderParent.Size = new System.Drawing.Size(492, 149);
            this.pnlMessageHeaderParent.TabIndex = 15;
            // 
            // pnlMessageHeader
            // 
            this.pnlMessageHeader.AutoSize = true;
            this.pnlMessageHeader.Controls.Add(this.dpMessageCreatedDateTime);
            this.pnlMessageHeader.Controls.Add(this.label1);
            this.pnlMessageHeader.Controls.Add(this.label6);
            this.pnlMessageHeader.Controls.Add(this.txtMessageID);
            this.pnlMessageHeader.Controls.Add(this.label4);
            this.pnlMessageHeader.Controls.Add(this.txtMessageSender_PartyID);
            this.pnlMessageHeader.Controls.Add(this.txtMessageRecipient_PartyName);
            this.pnlMessageHeader.Controls.Add(this.label2);
            this.pnlMessageHeader.Controls.Add(this.label5);
            this.pnlMessageHeader.Controls.Add(this.txtMessageSender_PartyName);
            this.pnlMessageHeader.Controls.Add(this.txtMessageRecipient_PartyID);
            this.pnlMessageHeader.Controls.Add(this.label3);
            this.pnlMessageHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMessageHeader.Location = new System.Drawing.Point(0, 24);
            this.pnlMessageHeader.Name = "pnlMessageHeader";
            this.pnlMessageHeader.Padding = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.pnlMessageHeader.Size = new System.Drawing.Size(492, 125);
            this.pnlMessageHeader.TabIndex = 13;
            // 
            // dpMessageCreatedDateTime
            // 
            this.dpMessageCreatedDateTime.CustomFormat = "dd.MM.yyyy HH:mm.ss";
            this.dpMessageCreatedDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpMessageCreatedDateTime.Location = new System.Drawing.Point(187, 93);
            this.dpMessageCreatedDateTime.Margin = new System.Windows.Forms.Padding(2);
            this.dpMessageCreatedDateTime.Name = "dpMessageCreatedDateTime";
            this.dpMessageCreatedDateTime.Size = new System.Drawing.Size(156, 20);
            this.dpMessageCreatedDateTime.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Message ID";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(15, 93);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "DateTime Created";
            // 
            // txtMessageID
            // 
            this.txtMessageID.Location = new System.Drawing.Point(187, 4);
            this.txtMessageID.Margin = new System.Windows.Forms.Padding(2);
            this.txtMessageID.Name = "txtMessageID";
            this.txtMessageID.Size = new System.Drawing.Size(156, 20);
            this.txtMessageID.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(15, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Recipient PartyName";
            // 
            // txtMessageSender_PartyID
            // 
            this.txtMessageSender_PartyID.Location = new System.Drawing.Point(187, 21);
            this.txtMessageSender_PartyID.Margin = new System.Windows.Forms.Padding(2);
            this.txtMessageSender_PartyID.Name = "txtMessageSender_PartyID";
            this.txtMessageSender_PartyID.Size = new System.Drawing.Size(156, 20);
            this.txtMessageSender_PartyID.TabIndex = 3;
            // 
            // txtMessageRecipient_PartyName
            // 
            this.txtMessageRecipient_PartyName.Location = new System.Drawing.Point(187, 75);
            this.txtMessageRecipient_PartyName.Margin = new System.Windows.Forms.Padding(2);
            this.txtMessageRecipient_PartyName.Name = "txtMessageRecipient_PartyName";
            this.txtMessageRecipient_PartyName.Size = new System.Drawing.Size(156, 20);
            this.txtMessageRecipient_PartyName.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sender PartyID";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(15, 57);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "Recipient PartyID";
            // 
            // txtMessageSender_PartyName
            // 
            this.txtMessageSender_PartyName.Location = new System.Drawing.Point(187, 39);
            this.txtMessageSender_PartyName.Margin = new System.Windows.Forms.Padding(2);
            this.txtMessageSender_PartyName.Name = "txtMessageSender_PartyName";
            this.txtMessageSender_PartyName.Size = new System.Drawing.Size(156, 20);
            this.txtMessageSender_PartyName.TabIndex = 5;
            // 
            // txtMessageRecipient_PartyID
            // 
            this.txtMessageRecipient_PartyID.Location = new System.Drawing.Point(187, 57);
            this.txtMessageRecipient_PartyID.Margin = new System.Windows.Forms.Padding(2);
            this.txtMessageRecipient_PartyID.Name = "txtMessageRecipient_PartyID";
            this.txtMessageRecipient_PartyID.Size = new System.Drawing.Size(156, 20);
            this.txtMessageRecipient_PartyID.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(15, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sender PartyName";
            // 
            // tbMessageHeader
            // 
            this.tbMessageHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbMessageHeader.Location = new System.Drawing.Point(0, 0);
            this.tbMessageHeader.Name = "tbMessageHeader";
            this.tbMessageHeader.Size = new System.Drawing.Size(492, 24);
            this.tbMessageHeader.TabIndex = 12;
            this.tbMessageHeader.Title = "Message Header";
            // 
            // pnlMainReleaseParent
            // 
            this.pnlMainReleaseParent.AutoSize = true;
            this.pnlMainReleaseParent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlMainReleaseParent.Controls.Add(this.pnlMainRelease);
            this.pnlMainReleaseParent.Controls.Add(this.tbMainRelease);
            this.pnlMainReleaseParent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMainReleaseParent.Location = new System.Drawing.Point(0, 0);
            this.pnlMainReleaseParent.Name = "pnlMainReleaseParent";
            this.pnlMainReleaseParent.Size = new System.Drawing.Size(352, 149);
            this.pnlMainReleaseParent.TabIndex = 14;
            // 
            // pnlMainRelease
            // 
            this.pnlMainRelease.AutoSize = true;
            this.pnlMainRelease.Controls.Add(this.label8);
            this.pnlMainRelease.Controls.Add(this.label7);
            this.pnlMainRelease.Controls.Add(this.cbUpdateIndicator);
            this.pnlMainRelease.Controls.Add(this.label12);
            this.pnlMainRelease.Controls.Add(this.txtMainReleaseReferenceTitle);
            this.pnlMainRelease.Controls.Add(this.txtEAN);
            this.pnlMainRelease.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainRelease.Location = new System.Drawing.Point(0, 24);
            this.pnlMainRelease.Name = "pnlMainRelease";
            this.pnlMainRelease.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlMainRelease.Size = new System.Drawing.Size(352, 125);
            this.pnlMainRelease.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(12, 26);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 18);
            this.label8.TabIndex = 7;
            this.label8.Text = "ReferenceTitle";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 7);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 18);
            this.label7.TabIndex = 5;
            this.label7.Text = "EAN";
            // 
            // cbUpdateIndicator
            // 
            this.cbUpdateIndicator.FormattingEnabled = true;
            this.cbUpdateIndicator.Location = new System.Drawing.Point(184, 43);
            this.cbUpdateIndicator.Margin = new System.Windows.Forms.Padding(2);
            this.cbUpdateIndicator.Name = "cbUpdateIndicator";
            this.cbUpdateIndicator.Size = new System.Drawing.Size(156, 21);
            this.cbUpdateIndicator.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(12, 44);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 18);
            this.label12.TabIndex = 0;
            this.label12.Text = "UpdateIndicator";
            // 
            // txtMainReleaseReferenceTitle
            // 
            this.txtMainReleaseReferenceTitle.Location = new System.Drawing.Point(184, 23);
            this.txtMainReleaseReferenceTitle.Margin = new System.Windows.Forms.Padding(2);
            this.txtMainReleaseReferenceTitle.Name = "txtMainReleaseReferenceTitle";
            this.txtMainReleaseReferenceTitle.Size = new System.Drawing.Size(156, 20);
            this.txtMainReleaseReferenceTitle.TabIndex = 8;
            // 
            // txtEAN
            // 
            this.txtEAN.Location = new System.Drawing.Point(184, 5);
            this.txtEAN.Margin = new System.Windows.Forms.Padding(2);
            this.txtEAN.Name = "txtEAN";
            this.txtEAN.Size = new System.Drawing.Size(156, 20);
            this.txtEAN.TabIndex = 6;
            // 
            // tbMainRelease
            // 
            this.tbMainRelease.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbMainRelease.Location = new System.Drawing.Point(0, 0);
            this.tbMainRelease.Name = "tbMainRelease";
            this.tbMainRelease.Size = new System.Drawing.Size(352, 24);
            this.tbMainRelease.TabIndex = 12;
            this.tbMainRelease.Title = "Main Release";
            // 
            // rtbOutput
            // 
            this.rtbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbOutput.Location = new System.Drawing.Point(224, 5);
            this.rtbOutput.Margin = new System.Windows.Forms.Padding(2);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(616, 50);
            this.rtbOutput.TabIndex = 5;
            this.rtbOutput.Text = "";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 12.16545F;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::DDEX.Properties.Resources.Edit;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.MinimumWidth = 20;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.ToolTipText = "Edit selected record";
            this.dataGridViewImageColumn1.Width = 20;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.FillWeight = 27.22915F;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::DDEX.Properties.Resources.Delete;
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.MinimumWidth = 20;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn2.Width = 20;
            // 
            // ERN_382GenerationFormAudioAlbumMusicOnly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(848, 642);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ERN_382GenerationFormAudioAlbumMusicOnly";
            this.Text = "Release Edit";
            this.DialogResultClicked += new Framework.UI.Forms.MREditForm.ButtonClickEventHandler(this.Form_DialogResultClicked);
            this.Load += new System.EventHandler(this.ERN_382GenerationFormAudioAlbumMusicOnly_Load);
            this.Controls.SetChildIndex(this.pnlData, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlFrontCoverImageParent.ResumeLayout(false);
            this.pnlFrontCoverImageParent.PerformLayout();
            this.pnlFrontCoverImage.ResumeLayout(false);
            this.pnlFrontCoverImage.PerformLayout();
            this.pnlTrackReleasesParent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoundRecordingsAndReleases)).EndInit();
            this.mrPanel1.ResumeLayout(false);
            this.mrPanel1.PerformLayout();
            this.pnlMessageHeaderParent.ResumeLayout(false);
            this.pnlMessageHeaderParent.PerformLayout();
            this.pnlMessageHeader.ResumeLayout(false);
            this.pnlMessageHeader.PerformLayout();
            this.pnlMainReleaseParent.ResumeLayout(false);
            this.pnlMainReleaseParent.PerformLayout();
            this.pnlMainRelease.ResumeLayout(false);
            this.pnlMainRelease.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Framework.UI.Controls.MRGroupBox groupBox1;
        public Framework.UI.Controls.MRButton btnLoadXml;
        private Framework.UI.Controls.MRLabel lblPath;
        private Framework.UI.Controls.MRGroupBox groupBox2;
        private Framework.UI.Controls.MRTextBox txtMessageID;
        private Framework.UI.Controls.MRLabel label1;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private Framework.UI.Controls.MRLabel label3;
        private Framework.UI.Controls.MRTextBox txtMessageSender_PartyName;
        private Framework.UI.Controls.MRLabel label2;
        private Framework.UI.Controls.MRTextBox txtMessageSender_PartyID;
        private Framework.UI.Controls.MRLabel label4;
        private Framework.UI.Controls.MRTextBox txtMessageRecipient_PartyName;
        private Framework.UI.Controls.MRLabel label5;
        private Framework.UI.Controls.MRTextBox txtMessageRecipient_PartyID;
        private System.Windows.Forms.DateTimePicker dpMessageCreatedDateTime;
        private Framework.UI.Controls.MRLabel label6;
        private System.Windows.Forms.ComboBox cbUpdateIndicator;
        private Framework.UI.Controls.MRLabel label12;
        private Framework.UI.Controls.MRLabel label13;
        private Framework.UI.Controls.MRTextBox txtFrontCoverImageResourceReference;
        private System.Windows.Forms.DataGridView dgvSoundRecordingsAndReleases;
        private Framework.UI.Controls.MRLabel label8;
        private Framework.UI.Controls.MRTextBox txtMainReleaseReferenceTitle;
        private Framework.UI.Controls.MRLabel label7;
        private Framework.UI.Controls.MRTextBox txtEAN;
        private Framework.UI.Controls.MRTitleBar tbMainRelease;
        private Framework.UI.Controls.MRPanel pnlMainReleaseParent;
        private Framework.UI.Controls.MRPanel pnlMainRelease;
        private Framework.UI.Controls.MRPanel pnlMessageHeaderParent;
        private Framework.UI.Controls.MRPanel pnlMessageHeader;
        private Framework.UI.Controls.MRTitleBar tbMessageHeader;
        private Framework.UI.Controls.MRPanel pnlTrackReleasesParent;
        private Framework.UI.Controls.MRTitleBar tbTrackReleases;
        private System.Windows.Forms.DataGridViewImageColumn csEdit;
        private System.Windows.Forms.DataGridViewImageColumn csDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn csTracksOrdinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn csTracksISRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn csTrackTitle;
        private Framework.UI.Controls.MRPanel mrPanel1;
        private Framework.UI.Controls.MRPanel pnlFrontCoverImageParent;
        private Framework.UI.Controls.MRPanel pnlFrontCoverImage;
        private Framework.UI.Controls.MRTitleBar tbFrontCoverImage;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
    }
}
