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
            ((System.ComponentModel.ISupportInitialize)VideoView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackBarSeek).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackBarVolume).BeginInit();
            contextMenuFiles.SuspendLayout();
            SuspendLayout();
            // 
            // VideoView
            // 
            VideoView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            VideoView.BackColor = Color.Black;
            VideoView.Location = new Point(12, 37);
            VideoView.MediaPlayer = null;
            VideoView.Name = "VideoView";
            VideoView.Size = new Size(553, 379);
            VideoView.TabIndex = 0;
            VideoView.Text = "videoView1";
            // 
            // BtnPause
            // 
            BtnPause.Location = new Point(12, 8);
            BtnPause.Name = "BtnPause";
            BtnPause.Size = new Size(73, 25);
            BtnPause.TabIndex = 2;
            BtnPause.Text = "Pause";
            BtnPause.UseVisualStyleBackColor = true;
            BtnPause.Click += BtnPause_Click;
            // 
            // BtnStop
            // 
            BtnStop.Location = new Point(93, 8);
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
            PositionLbl.Location = new Point(493, 13);
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
            TrackBarSeek.Location = new Point(12, 419);
            TrackBarSeek.Margin = new Padding(0);
            TrackBarSeek.Maximum = 1000;
            TrackBarSeek.Name = "TrackBarSeek";
            TrackBarSeek.Size = new Size(553, 29);
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
            TrackBarVolume.Location = new Point(571, 323);
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
            VolumeLbl.Location = new Point(412, 13);
            VolumeLbl.Name = "VolumeLbl";
            VolumeLbl.Size = new Size(75, 15);
            VolumeLbl.TabIndex = 7;
            VolumeLbl.Text = "Volume: 50%";
            // 
            // NextFile
            // 
            NextFile.Location = new Point(294, 8);
            NextFile.Name = "NextFile";
            NextFile.Size = new Size(112, 25);
            NextFile.TabIndex = 8;
            NextFile.Text = "Next file";
            NextFile.UseVisualStyleBackColor = true;
            NextFile.Click += NextFile_Click;
            // 
            // PreviousFile
            // 
            PreviousFile.Location = new Point(174, 8);
            PreviousFile.Name = "PreviousFile";
            PreviousFile.Size = new Size(112, 25);
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
            BtnSelectFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnSelectFolder.Location = new Point(604, 10);
            BtnSelectFolder.Name = "BtnSelectFolder";
            BtnSelectFolder.Size = new Size(84, 23);
            BtnSelectFolder.TabIndex = 11;
            BtnSelectFolder.Text = "Select folder";
            BtnSelectFolder.UseVisualStyleBackColor = true;
            BtnSelectFolder.Click += BtnSelectFolder_Click;
            // 
            // ListViewFiles
            // 
            ListViewFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            ListViewFiles.Columns.AddRange(new ColumnHeader[] { FileName, Format, CreationDate });
            ListViewFiles.ContextMenuStrip = contextMenuFiles;
            ListViewFiles.FullRowSelect = true;
            ListViewFiles.GridLines = true;
            ListViewFiles.Location = new Point(604, 37);
            ListViewFiles.MultiSelect = false;
            ListViewFiles.Name = "ListViewFiles";
            ListViewFiles.Size = new Size(453, 379);
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
            // PlayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1087, 445);
            Controls.Add(ListViewFiles);
            Controls.Add(BtnSelectFolder);
            Controls.Add(PreviousFile);
            Controls.Add(NextFile);
            Controls.Add(VolumeLbl);
            Controls.Add(TrackBarVolume);
            Controls.Add(TrackBarSeek);
            Controls.Add(PositionLbl);
            Controls.Add(BtnStop);
            Controls.Add(BtnPause);
            Controls.Add(VideoView);
            Name = "PlayerForm";
            Text = "File catalog";
            Load += PlayerForm_Load;
            ((System.ComponentModel.ISupportInitialize)VideoView).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackBarSeek).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackBarVolume).EndInit();
            contextMenuFiles.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
    }
}