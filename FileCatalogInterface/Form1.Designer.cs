namespace FileCatalogInterface
{
    partial class Form1
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
            videoView1 = new LibVLCSharp.WinForms.VideoView();
            btnPause = new Button();
            btnStop = new Button();
            lblPosition = new Label();
            positionTimer = new System.Windows.Forms.Timer(components);
            trackBarSeek = new TrackBar();
            trackBarVolume = new TrackBar();
            lblVolume = new Label();
            NextFile = new Button();
            PreviousFile = new Button();
            ((System.ComponentModel.ISupportInitialize)videoView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarSeek).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).BeginInit();
            SuspendLayout();
            // 
            // videoView1
            // 
            videoView1.BackColor = Color.Black;
            videoView1.Location = new Point(12, 37);
            videoView1.MediaPlayer = null;
            videoView1.Name = "videoView1";
            videoView1.Size = new Size(561, 377);
            videoView1.TabIndex = 0;
            videoView1.Text = "videoView1";
            // 
            // btnPause
            // 
            btnPause.Location = new Point(12, 8);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(75, 23);
            btnPause.TabIndex = 2;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(93, 8);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 3;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(495, 12);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(72, 15);
            lblPosition.TabIndex = 4;
            lblPosition.Text = "00:00 / 00:00";
            // 
            // positionTimer
            // 
            positionTimer.Tick += positionTimer_Tick;
            // 
            // trackBarSeek
            // 
            trackBarSeek.Anchor = AnchorStyles.None;
            trackBarSeek.AutoSize = false;
            trackBarSeek.Location = new Point(12, 417);
            trackBarSeek.Margin = new Padding(0);
            trackBarSeek.Maximum = 1000;
            trackBarSeek.Name = "trackBarSeek";
            trackBarSeek.Size = new Size(597, 22);
            trackBarSeek.TabIndex = 5;
            trackBarSeek.TickFrequency = 0;
            trackBarSeek.TickStyle = TickStyle.None;
            trackBarSeek.Scroll += trackBarSeek_Scroll;
            trackBarSeek.MouseDown += trackBarSeek_MouseDown;
            trackBarSeek.MouseUp += trackBarSeek_MouseUp;
            // 
            // trackBarVolume
            // 
            trackBarVolume.Anchor = AnchorStyles.None;
            trackBarVolume.Location = new Point(579, 323);
            trackBarVolume.Maximum = 100;
            trackBarVolume.Name = "trackBarVolume";
            trackBarVolume.Orientation = Orientation.Vertical;
            trackBarVolume.Size = new Size(45, 91);
            trackBarVolume.TabIndex = 6;
            trackBarVolume.TickFrequency = 10;
            trackBarVolume.Value = 50;
            trackBarVolume.Scroll += trackBarVolume_Scroll;
            trackBarVolume.MouseDown += trackBarVolume_MouseDown;
            // 
            // lblVolume
            // 
            lblVolume.AutoSize = true;
            lblVolume.Location = new Point(414, 12);
            lblVolume.Name = "lblVolume";
            lblVolume.Size = new Size(75, 15);
            lblVolume.TabIndex = 7;
            lblVolume.Text = "Volume: 50%";
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(913, 587);
            Controls.Add(PreviousFile);
            Controls.Add(NextFile);
            Controls.Add(lblVolume);
            Controls.Add(trackBarVolume);
            Controls.Add(trackBarSeek);
            Controls.Add(lblPosition);
            Controls.Add(btnStop);
            Controls.Add(btnPause);
            Controls.Add(videoView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)videoView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarSeek).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LibVLCSharp.WinForms.VideoView videoView1;
        private Button btnPause;
        private Button btnStop;
        private Label lblPosition;
        private System.Windows.Forms.Timer positionTimer;
        private TrackBar trackBarSeek;
        private TrackBar trackBarVolume;
        private Label lblVolume;
        private Button NextFile;
        private Button PreviousFile;
    }
}