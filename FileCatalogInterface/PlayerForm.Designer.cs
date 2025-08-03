namespace FileCatalogInterface
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
            ListBoxVideos = new ListBox();
            ((System.ComponentModel.ISupportInitialize)VideoView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackBarSeek).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackBarVolume).BeginInit();
            SuspendLayout();
            // 
            // VideoView
            // 
            VideoView.BackColor = Color.Black;
            VideoView.Location = new Point(12, 37);
            VideoView.MediaPlayer = null;
            VideoView.Name = "VideoView";
            VideoView.Size = new Size(561, 377);
            VideoView.TabIndex = 0;
            VideoView.Text = "videoView1";
            // 
            // BtnPause
            // 
            BtnPause.Location = new Point(12, 8);
            BtnPause.Name = "BtnPause";
            BtnPause.Size = new Size(75, 23);
            BtnPause.TabIndex = 2;
            BtnPause.Text = "Pause";
            BtnPause.UseVisualStyleBackColor = true;
            BtnPause.Click += BtnPause_Click;
            // 
            // BtnStop
            // 
            BtnStop.Location = new Point(93, 8);
            BtnStop.Name = "BtnStop";
            BtnStop.Size = new Size(75, 23);
            BtnStop.TabIndex = 3;
            BtnStop.Text = "Stop";
            BtnStop.UseVisualStyleBackColor = true;
            BtnStop.Click += BtnStop_Click;
            // 
            // PositionLbl
            // 
            PositionLbl.AutoSize = true;
            PositionLbl.Location = new Point(495, 12);
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
            TrackBarSeek.Location = new Point(12, 417);
            TrackBarSeek.Margin = new Padding(0);
            TrackBarSeek.Maximum = 1000;
            TrackBarSeek.Name = "TrackBarSeek";
            TrackBarSeek.Size = new Size(561, 26);
            TrackBarSeek.TabIndex = 5;
            TrackBarSeek.TickFrequency = 0;
            TrackBarSeek.TickStyle = TickStyle.None;
            TrackBarSeek.Scroll += TrackBarSeek_Scroll;
            TrackBarSeek.MouseDown += TrackBarSeek_MouseDown;
            TrackBarSeek.MouseUp += TrackBarSeek_MouseUp;
            // 
            // TrackBarVolume
            // 
            TrackBarVolume.Location = new Point(579, 323);
            TrackBarVolume.Maximum = 100;
            TrackBarVolume.Name = "TrackBarVolume";
            TrackBarVolume.Orientation = Orientation.Vertical;
            TrackBarVolume.Size = new Size(45, 91);
            TrackBarVolume.TabIndex = 6;
            TrackBarVolume.TickFrequency = 10;
            TrackBarVolume.Value = 50;
            TrackBarVolume.Scroll += TrackBarVolume_Scroll;
            TrackBarVolume.MouseDown += TrackBarVolume_MouseDown;
            // 
            // VolumeLbl
            // 
            VolumeLbl.AutoSize = true;
            VolumeLbl.Location = new Point(414, 12);
            VolumeLbl.Name = "VolumeLbl";
            VolumeLbl.Size = new Size(75, 15);
            VolumeLbl.TabIndex = 7;
            VolumeLbl.Text = "Volume: 50%";
            // 
            // NextFile
            // 
            NextFile.Location = new Point(294, 8);
            NextFile.Name = "NextFile";
            NextFile.Size = new Size(114, 23);
            NextFile.TabIndex = 8;
            NextFile.Text = "NextFile";
            NextFile.UseVisualStyleBackColor = true;
            NextFile.Click += NextFile_Click;
            // 
            // PreviousFile
            // 
            PreviousFile.Location = new Point(174, 8);
            PreviousFile.Name = "PreviousFile";
            PreviousFile.Size = new Size(114, 23);
            PreviousFile.TabIndex = 9;
            PreviousFile.Text = "PreviousFile";
            PreviousFile.UseVisualStyleBackColor = true;
            PreviousFile.Click += PreviousFile_Click;
            // 
            // ListBoxVideos
            // 
            ListBoxVideos.FormattingEnabled = true;
            ListBoxVideos.Location = new Point(630, 35);
            ListBoxVideos.Name = "ListBoxVideos";
            ListBoxVideos.Size = new Size(244, 379);
            ListBoxVideos.TabIndex = 10;
            ListBoxVideos.SelectedIndexChanged += ListBoxVideos_SelectedIndexChanged;
            // 
            // PlayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 443);
            Controls.Add(ListBoxVideos);
            Controls.Add(PreviousFile);
            Controls.Add(NextFile);
            Controls.Add(VolumeLbl);
            Controls.Add(TrackBarVolume);
            Controls.Add(TrackBarSeek);
            Controls.Add(PositionLbl);
            Controls.Add(BtnStop);
            Controls.Add(BtnPause);
            Controls.Add(VideoView);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "PlayerForm";
            Text = "File catalog";
            Load += PlayerForm_Load;
            ((System.ComponentModel.ISupportInitialize)VideoView).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackBarSeek).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackBarVolume).EndInit();
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
        private ListBox ListBoxVideos;
    }
}