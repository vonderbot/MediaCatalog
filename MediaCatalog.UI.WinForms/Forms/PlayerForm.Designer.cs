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
            splitContainer4 = new SplitContainer();
            splitContainer5 = new SplitContainer();
            splitContainer6 = new SplitContainer();
            splitContainer7 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            splitContainer1 = new SplitContainer();
            ToggleTagPanel = new Button();
            TagPanel = new Panel();
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
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer5).BeginInit();
            splitContainer5.Panel1.SuspendLayout();
            splitContainer5.Panel2.SuspendLayout();
            splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer6).BeginInit();
            splitContainer6.Panel1.SuspendLayout();
            splitContainer6.Panel2.SuspendLayout();
            splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer7).BeginInit();
            splitContainer7.Panel1.SuspendLayout();
            splitContainer7.Panel2.SuspendLayout();
            splitContainer7.SuspendLayout();
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
            VideoView.BackColor = Color.Black;
            VideoView.Dock = DockStyle.Fill;
            VideoView.Location = new Point(0, 0);
            VideoView.MediaPlayer = null;
            VideoView.Name = "VideoView";
            VideoView.Size = new Size(520, 329);
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
            PositionLbl.Location = new Point(143, 9);
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
            TrackBarSeek.AutoSize = false;
            TrackBarSeek.Dock = DockStyle.Fill;
            TrackBarSeek.Location = new Point(0, 0);
            TrackBarSeek.Margin = new Padding(0);
            TrackBarSeek.Maximum = 1000;
            TrackBarSeek.Name = "TrackBarSeek";
            TrackBarSeek.Size = new Size(561, 27);
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
            TrackBarVolume.Location = new Point(3, 231);
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
            VolumeLbl.Location = new Point(62, 9);
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
            SplitMain.Panel1.Controls.Add(splitContainer4);
            // 
            // SplitMain.Panel2
            // 
            SplitMain.Panel2.Controls.Add(splitContainer2);
            SplitMain.Panel2MinSize = 350;
            SplitMain.Size = new Size(1036, 396);
            SplitMain.SplitterDistance = 561;
            SplitMain.TabIndex = 14;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            splitContainer4.Orientation = Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(splitContainer5);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(splitContainer6);
            splitContainer4.Size = new Size(561, 396);
            splitContainer4.SplitterDistance = 32;
            splitContainer4.TabIndex = 0;
            // 
            // splitContainer5
            // 
            splitContainer5.Dock = DockStyle.Fill;
            splitContainer5.Location = new Point(0, 0);
            splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            splitContainer5.Panel1.Controls.Add(BtnPause);
            splitContainer5.Panel1.Controls.Add(BtnStop);
            splitContainer5.Panel1.Controls.Add(NextFile);
            splitContainer5.Panel1.Controls.Add(PreviousFile);
            // 
            // splitContainer5.Panel2
            // 
            splitContainer5.Panel2.Controls.Add(VolumeLbl);
            splitContainer5.Panel2.Controls.Add(PositionLbl);
            splitContainer5.Size = new Size(561, 32);
            splitContainer5.SplitterDistance = 339;
            splitContainer5.TabIndex = 0;
            // 
            // splitContainer6
            // 
            splitContainer6.Dock = DockStyle.Fill;
            splitContainer6.Location = new Point(0, 0);
            splitContainer6.Name = "splitContainer6";
            splitContainer6.Orientation = Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            splitContainer6.Panel1.Controls.Add(splitContainer7);
            // 
            // splitContainer6.Panel2
            // 
            splitContainer6.Panel2.Controls.Add(TrackBarSeek);
            splitContainer6.Size = new Size(561, 360);
            splitContainer6.SplitterDistance = 329;
            splitContainer6.TabIndex = 0;
            // 
            // splitContainer7
            // 
            splitContainer7.Dock = DockStyle.Fill;
            splitContainer7.Location = new Point(0, 0);
            splitContainer7.Name = "splitContainer7";
            // 
            // splitContainer7.Panel1
            // 
            splitContainer7.Panel1.Controls.Add(VideoView);
            // 
            // splitContainer7.Panel2
            // 
            splitContainer7.Panel2.Controls.Add(TrackBarVolume);
            splitContainer7.Size = new Size(561, 329);
            splitContainer7.SplitterDistance = 520;
            splitContainer7.TabIndex = 0;
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
            TagPanel.Controls.Add(CreateTagButton);
            TagPanel.Controls.Add(splitContainer3);
            TagPanel.Dock = DockStyle.Fill;
            TagPanel.Location = new Point(0, 0);
            TagPanel.Name = "TagPanel";
            TagPanel.Size = new Size(471, 192);
            TagPanel.TabIndex = 1;
            TagPanel.Visible = false;
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
            splitContainer3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
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
            listViewAssignTags.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            listViewAssignTags.CheckBoxes = true;
            listViewAssignTags.Columns.AddRange(new ColumnHeader[] { Tag });
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
            listViewFilterTags.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            listViewFilterTags.CheckBoxes = true;
            listViewFilterTags.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
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
            KeyPreview = true;
            Name = "PlayerForm";
            Text = "File catalog";
            FormClosing += PlayerForm_FormClosing;
            Load += PlayerForm_Load;
            KeyDown += PlayerForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)VideoView).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackBarSeek).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackBarVolume).EndInit();
            contextMenuFiles.ResumeLayout(false);
            SplitMain.Panel1.ResumeLayout(false);
            SplitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SplitMain).EndInit();
            SplitMain.ResumeLayout(false);
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            splitContainer5.Panel1.ResumeLayout(false);
            splitContainer5.Panel2.ResumeLayout(false);
            splitContainer5.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer5).EndInit();
            splitContainer5.ResumeLayout(false);
            splitContainer6.Panel1.ResumeLayout(false);
            splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer6).EndInit();
            splitContainer6.ResumeLayout(false);
            splitContainer7.Panel1.ResumeLayout(false);
            splitContainer7.Panel2.ResumeLayout(false);
            splitContainer7.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer7).EndInit();
            splitContainer7.ResumeLayout(false);
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
        private ListView listViewAssignTags;
        private ColumnHeader Tag;
        private SplitContainer splitContainer3;
        private ListView listViewFilterTags;
        private ColumnHeader columnHeader1;
        private SplitContainer splitContainer4;
        private SplitContainer splitContainer5;
        private SplitContainer splitContainer6;
        private SplitContainer splitContainer7;
    }
}