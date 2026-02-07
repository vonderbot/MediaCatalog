namespace MediaCatalog.UI.WinForms
{
    partial class PlayerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            VideoView = new LibVLCSharp.WinForms.VideoView();
            BtnPause = new Button();
            BtnStop = new Button();
            PositionLbl = new Label();
            positionTimer = new System.Windows.Forms.Timer(components);
            TrackBarSeek = new TrackBar();
            TrackBarVolume = new TrackBar();
            VolumeLbl = new Label();
            NextFile = new Button();
            PreviousFile = new Button();
            contextMenuFiles = new ContextMenuStrip(components);
            renameToolStripMenuItem = new ToolStripMenuItem();
            BtnSelectFolder = new Button();
            ListViewFiles = new ListView();
            FileName = new ColumnHeader();
            Format = new ColumnHeader();
            CreationDate = new ColumnHeader();
            label1 = new Label();
            SplitMain = new SplitContainer();
            splitContainer2 = new SplitContainer();
            splitContainer1 = new SplitContainer();
            ToggleTagPanel = new Button();
            TagPanel = new Panel();
            AssignTagButton = new Button();
            CreateTagButton = new Button();
            splitContainer3 = new SplitContainer();
            listViewAssignTags = new ListView();
            Tag = new ColumnHeader();
            listViewFilterTags = new ListView();
            columnHeader1 = new ColumnHeader();
            AddFileButton = new Button();
            ((System.ComponentModel.ISupportInitialize)VideoView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackBarSeek).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackBarVolume).BeginInit();
            contextMenuFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SplitMain).BeginInit();
            SplitMain.Panel1.SuspendLayout();
            SplitMain.Panel2.SuspendLayout();
            SplitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            TagPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            SuspendLayout();
            // 
            // VideoView
            // 
            VideoView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            VideoView.BackColor = Color.Black;
            VideoView.Location = new Point(3, 29);
            VideoView.MediaPlayer = null;
            VideoView.Name = "VideoView";
            VideoView.Size = new Size(516, 335);
            VideoView.TabIndex = 0;
            VideoView.Text = "videoView1";
            // 
            // BtnPause
            // 
            BtnPause.Location = new Point(3, 3);
            BtnPause.Name = "BtnPause";
            BtnPause.Size = new Size(73, 25);
            BtnPause.TabIndex = 2;
            BtnPause.Text = "Pause";
            BtnPause.UseVisualStyleBackColor = true;
            BtnPause.Click += BtnPause_Click;
            // 
            // BtnStop
            // 
            BtnStop.Location = new Point(82, 3);
            BtnStop.Name = "BtnStop";
            BtnStop.Size = new Size(73, 25);
            BtnStop.TabIndex = 3;
            BtnStop.Text = "Stop";
            BtnStop.UseVisualStyleBackColor = true;
            BtnStop.Click += BtnStop_Click;
            // 
            // PositionLbl
            // 
            PositionLbl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PositionLbl.AutoSize = true;
            PositionLbl.Location = new Point(447, 7);
            PositionLbl.Name = "PositionLbl";
            PositionLbl.Size = new Size(72, 15);
            PositionLbl.TabIndex = 4;
            PositionLbl.Text = "00:00 / 00:00";
            // 
            // positionTimer
            // 
            positionTimer.Tick += PositionTimer_Tick;
            // 
            // TrackBarSeek
            // 
            TrackBarSeek.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TrackBarSeek.AutoSize = false;
            TrackBarSeek.Location = new Point(3, 367);
            TrackBarSeek.Margin = new Padding(0);
            TrackBarSeek.Maximum = 1000;
            TrackBarSeek.Name = "TrackBarSeek";
            TrackBarSeek.Size = new Size(535, 29);
            TrackBarSeek.TabIndex = 5;
            TrackBarSeek.TickFrequency = 0;
            TrackBarSeek.TickStyle = TickStyle.None;
            TrackBarSeek.Scroll += TrackBarSeek_Scroll;
            TrackBarSeek.MouseDown += TrackBarSeek_MouseDown;
            TrackBarSeek.MouseUp += TrackBarSeek_MouseUp;
            // 
            // TrackBarVolume
            // 
            TrackBarVolume.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            TrackBarVolume.Location = new Point(525, 271);
            TrackBarVolume.Maximum = 100;
            TrackBarVolume.Name = "TrackBarVolume";
            TrackBarVolume.Orientation = Orientation.Vertical;
            TrackBarVolume.Size = new Size(45, 93);
            TrackBarVolume.TabIndex = 6;
            TrackBarVolume.TickFrequency = 10;
            TrackBarVolume.Value = 50;
            TrackBarVolume.Scroll += TrackBarVolume_Scroll;
            TrackBarVolume.MouseDown += TrackBarVolume_MouseDown;
            // 
            // VolumeLbl
            // 
            VolumeLbl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            VolumeLbl.AutoSize = true;
            VolumeLbl.Location = new Point(366, 8);
            VolumeLbl.Name = "VolumeLbl";
            VolumeLbl.Size = new Size(75, 15);
            VolumeLbl.TabIndex = 7;
            VolumeLbl.Text = "Volume: 50%";
            // 
            // NextFile
            // 
            NextFile.Location = new Point(261, 3);
            NextFile.Name = "NextFile";
            NextFile.Size = new Size(74, 25);
            NextFile.TabIndex = 8;
            NextFile.Text = "Next file";
            NextFile.UseVisualStyleBackColor = true;
            NextFile.Click += NextFile_Click;
            // 
            // PreviousFile
            // 
            PreviousFile.Location = new Point(161, 3);
            PreviousFile.Name = "PreviousFile";
            PreviousFile.Size = new Size(94, 25);
            PreviousFile.TabIndex = 9;
            PreviousFile.Text = "Previous file";
            PreviousFile.UseVisualStyleBackColor = true;
            PreviousFile.Click += PreviousFile_Click;
            // 
            // contextMenuFiles
            // 
            contextMenuFiles.Items.AddRange(new ToolStripItem[] { renameToolStripMenuItem });
            contextMenuFiles.Name = "contextMenuFiles";
            contextMenuFiles.Size = new Size(118, 26);
            // 
            // renameToolStripMenuItem
            // 
            renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            renameToolStripMenuItem.Size = new Size(117, 22);
            renameToolStripMenuItem.Text = "Rename";
            renameToolStripMenuItem.Click += renameToolStripMenuItem_Click;
            // 
            // BtnSelectFolder
            // 
            BtnSelectFolder.Location = new Point(3, 3);
            BtnSelectFolder.Name = "BtnSelectFolder";
            BtnSelectFolder.Size = new Size(84, 23);
            BtnSelectFolder.TabIndex = 11;
            BtnSelectFolder.Text = "Select folder";
            BtnSelectFolder.UseVisualStyleBackColor = true;
            BtnSelectFolder.Click += BtnSelectFolder_Click;
            // 
            // ListViewFiles
            // 
            ListViewFiles.Columns.AddRange(new ColumnHeader[] { FileName, Format, CreationDate });
            ListViewFiles.ContextMenuStrip = contextMenuFiles;
            ListViewFiles.Dock = DockStyle.Fill;
            ListViewFiles.FullRowSelect = true;
            ListViewFiles.GridLines = true;
            ListViewFiles.Location = new Point(0, 0);
            ListViewFiles.MultiSelect = false;
            ListViewFiles.Name = "ListViewFiles";
            ListViewFiles.Size = new Size(471, 167);
            ListViewFiles.TabIndex = 12;
            ListViewFiles.UseCompatibleStateImageBehavior = false;
            ListViewFiles.View = View.Details;
            ListViewFiles.ColumnClick += listViewFiles_ColumnClick;
            ListViewFiles.ItemActivate += renameToolStripMenuItem_Click;
            ListViewFiles.SelectedIndexChanged += listViewFiles_SelectedIndexChanged;
            // 
            // FileName
            // 
            FileName.Text = "File name";
            FileName.Width = 200;
            // 
            // Format
            // 
            Format.Text = "Format";
            Format.Width = 100;
            // 
            // CreationDate
            // 
            CreationDate.Text = "Creation date";
            CreationDate.Width = 150;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 15;
            // 
            // SplitMain
            // 
            SplitMain.Dock = DockStyle.Fill;
            SplitMain.FixedPanel = FixedPanel.Panel2;
            SplitMain.Location = new Point(0, 0);
            SplitMain.Name = "SplitMain";
            // 
            // SplitMain.Panel1
            // 
            SplitMain.Panel1.Controls.Add(BtnPause);
            SplitMain.Panel1.Controls.Add(BtnStop);
            SplitMain.Panel1.Controls.Add(PreviousFile);
            SplitMain.Panel1.Controls.Add(NextFile);
            SplitMain.Panel1.Controls.Add(VideoView);
            SplitMain.Panel1.Controls.Add(VolumeLbl);
            SplitMain.Panel1.Controls.Add(TrackBarSeek);
            SplitMain.Panel1.Controls.Add(PositionLbl);
            SplitMain.Panel1.Controls.Add(TrackBarVolume);
            // 
            // SplitMain.Panel2
            // 
            SplitMain.Panel2.Controls.Add(splitContainer2);
            SplitMain.Panel2MinSize = 350;
            SplitMain.Size = new Size(1036, 396);
            SplitMain.SplitterDistance = 561;
            SplitMain.TabIndex = 14;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(splitContainer1);
            splitContainer2.Panel1MinSize = 200;
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(TagPanel);
            splitContainer2.Panel2.Controls.Add(AddFileButton);
            splitContainer2.Size = new Size(471, 396);
            splitContainer2.SplitterDistance = 200;
            splitContainer2.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(BtnSelectFolder);
            splitContainer1.Panel1.Controls.Add(ToggleTagPanel);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(ListViewFiles);
            splitContainer1.Size = new Size(471, 200);
            splitContainer1.SplitterDistance = 29;
            splitContainer1.TabIndex = 14;
            // 
            // ToggleTagPanel
            // 
            ToggleTagPanel.Location = new Point(93, 3);
            ToggleTagPanel.Name = "ToggleTagPanel";
            ToggleTagPanel.Size = new Size(108, 23);
            ToggleTagPanel.TabIndex = 13;
            ToggleTagPanel.Text = "Toggle tag panel";
            ToggleTagPanel.UseVisualStyleBackColor = true;
            ToggleTagPanel.Click += ToggleTagPanel_Click;
            // 
            // TagPanel
            // 
            TagPanel.Controls.Add(AssignTagButton);
            TagPanel.Controls.Add(CreateTagButton);
            TagPanel.Controls.Add(splitContainer3);
            TagPanel.Dock = DockStyle.Fill;
            TagPanel.Location = new Point(0, 0);
            TagPanel.Name = "TagPanel";
            TagPanel.Size = new Size(471, 192);
            TagPanel.TabIndex = 1;
            TagPanel.Visible = false;
            // 
            // AssignTagButton
            // 
            AssignTagButton.Location = new Point(93, 3);
            AssignTagButton.Name = "AssignTagButton";
            AssignTagButton.Size = new Size(84, 41);
            AssignTagButton.TabIndex = 1;
            AssignTagButton.Text = "Assign new tag";
            AssignTagButton.UseVisualStyleBackColor = true;
            AssignTagButton.Click += AssignTagButton_Click;
            // 
            // CreateTagButton
            // 
            CreateTagButton.Location = new Point(3, 3);
            CreateTagButton.Name = "CreateTagButton";
            CreateTagButton.Size = new Size(84, 41);
            CreateTagButton.TabIndex = 0;
            CreateTagButton.Text = "Create new tag";
            CreateTagButton.UseVisualStyleBackColor = true;
            CreateTagButton.Click += CreateTagButton_Click;
            // 
            // splitContainer3
            // 
            splitContainer3.Location = new Point(0, 50);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(listViewAssignTags);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(listViewFilterTags);
            splitContainer3.Size = new Size(471, 142);
            splitContainer3.SplitterDistance = 231;
            splitContainer3.TabIndex = 0;
            // 
            // listViewAssignTags
            // 
            listViewAssignTags.CheckBoxes = true;
            listViewAssignTags.Columns.AddRange(new ColumnHeader[] { Tag });
            listViewAssignTags.Dock = DockStyle.Fill;
            listViewAssignTags.FullRowSelect = true;
            listViewAssignTags.Location = new Point(0, 0);
            listViewAssignTags.Name = "listViewAssignTags";
            listViewAssignTags.Size = new Size(231, 142);
            listViewAssignTags.TabIndex = 2;
            listViewAssignTags.UseCompatibleStateImageBehavior = false;
            listViewAssignTags.View = View.Details;
            listViewAssignTags.ItemChecked += listViewAssignTags_ItemChecked;
            // 
            // Tag
            // 
            Tag.Text = "Tag";
            Tag.Width = 200;
            // 
            // listViewFilterTags
            // 
            listViewFilterTags.CheckBoxes = true;
            listViewFilterTags.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listViewFilterTags.Dock = DockStyle.Fill;
            listViewFilterTags.FullRowSelect = true;
            listViewFilterTags.Location = new Point(0, 0);
            listViewFilterTags.Name = "listViewFilterTags";
            listViewFilterTags.Size = new Size(236, 142);
            listViewFilterTags.TabIndex = 3;
            listViewFilterTags.UseCompatibleStateImageBehavior = false;
            listViewFilterTags.View = View.Details;
            listViewFilterTags.ItemChecked += listViewFilterTags_ItemChecked;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Tag";
            columnHeader1.Width = 200;
            // 
            // AddFileButton
            // 
            AddFileButton.Location = new Point(169, 3);
            AddFileButton.Name = "AddFileButton";
            AddFileButton.Size = new Size(104, 41);
            AddFileButton.TabIndex = 0;
            AddFileButton.Text = "Add file to tag system";
            AddFileButton.UseVisualStyleBackColor = true;
            AddFileButton.Click += AddFileButton_Click;
            // 
            // PlayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1036, 396);
            Controls.Add(SplitMain);
            Controls.Add(label1);
            Name = "PlayerForm";
            Text = "File catalog";
            Load += PlayerForm_Load;
            ((System.ComponentModel.ISupportInitialize)VideoView).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackBarSeek).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackBarVolume).EndInit();
            contextMenuFiles.ResumeLayout(false);
            SplitMain.Panel1.ResumeLayout(false);
            SplitMain.Panel1.PerformLayout();
            SplitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SplitMain).EndInit();
            SplitMain.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            TagPanel.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private LibVLCSharp.WinForms.VideoView VideoView;
        private Button BtnPause;
        private Button BtnStop;
        private Label PositionLbl;
        private System.Windows.Forms.Timer positionTimer;
        private TrackBar TrackBarSeek;
        private TrackBar TrackBarVolume;
        private Label VolumeLbl;
        private Button NextFile;
        private Button PreviousFile;
        private Button BtnSelectFolder;
        private ContextMenuStrip contextMenuFiles;
        private ToolStripMenuItem renameToolStripMenuItem;
        private ListView ListViewFiles;
        private ColumnHeader FileName;
        private ColumnHeader Format;
        private ColumnHeader CreationDate;
        private Label label1;
        private SplitContainer SplitMain;
        private SplitContainer splitContainer2;
        private Button ToggleTagPanel;
        private SplitContainer splitContainer1;
        private Button AddFileButton;
        private Panel TagPanel;
        private Button CreateTagButton;
        private Button AssignTagButton;
        private ListView listViewAssignTags;
        private ColumnHeader Tag;
        private SplitContainer splitContainer3;
        private ListView listViewFilterTags;
        private ColumnHeader columnHeader1;
    }
}