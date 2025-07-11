namespace FileCatalogInterface
{
    using LibVLCSharp.Shared;
    using LibVLCSharp.WinForms;
    using FileCatalogTestLib;

    public partial class Form1 : Form
    {
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;
        VideoController videoControl;
        private bool _isSeeking = false;


        public Form1(VideoController newController)
        {
            InitializeComponent();

            Core.Initialize(); // важно

            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);
            videoControl = newController;
            videoView1.MediaPlayer = _mediaPlayer;
            _mediaPlayer.Volume = trackBarVolume.Value;
            lblVolume.Text = $"Volume: {trackBarVolume.Value}%";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            string videoPath = videoControl.GetFirstFile();

            var media = new Media(_libVLC, videoPath, FromType.FromPath);
            _mediaPlayer.Play(media);
            positionTimer.Start();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            _mediaPlayer?.Pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _mediaPlayer?.Stop();
            lblPosition.Text = "00:00 / 00:00";
        }

        private void positionTimer_Tick(object sender, EventArgs e)
        {
            if (_mediaPlayer == null || !_mediaPlayer.IsPlaying || _isSeeking)
            {
                return;
            }

            long current = _mediaPlayer.Time;        // текущая позиция в мс
            long total = _mediaPlayer.Length;        // общая длительность в мс

            lblPosition.Text = $"{FormatTime(current)} / {FormatTime(total)}";
            // Обновление позиции ползунка
            trackBarSeek.Value = (int)(current * 1000 / total);
        }
        private string FormatTime(long milliseconds)
        {
            var ts = TimeSpan.FromMilliseconds(milliseconds);
            return $"{ts.Minutes:D2}:{ts.Seconds:D2}";
        }

        private void trackBarSeek_Scroll(object sender, EventArgs e)
        {
            if (_mediaPlayer != null && _mediaPlayer.Length > 0)
            {
                long newTime = trackBarSeek.Value * _mediaPlayer.Length / 1000;
                _mediaPlayer.Time = newTime;
            }
        }

        private void trackBarSeek_MouseUp(object sender, MouseEventArgs e)
        {
            if (_mediaPlayer == null || _mediaPlayer.Length <= 0)
            {
                return;
            }
            TrackBar tb = (TrackBar)sender;
            int mouseX = e.X;
            int sliderWidth = tb.Width;
            int newValue = (int)((double)mouseX / sliderWidth * tb.Maximum);
            tb.Value = Math.Max(tb.Minimum, Math.Min(tb.Maximum, newValue));
            _mediaPlayer.Time = tb.Value * _mediaPlayer.Length / tb.Maximum;
            _isSeeking = false;
        }

        private void trackBarSeek_MouseDown(object sender, MouseEventArgs e)
        {
            if (_mediaPlayer == null || _mediaPlayer.Length <= 0)
            {
                return;
            }
            _isSeeking = true;
            TrackBar tb = (TrackBar)sender;
            int mouseX = e.X;
            int sliderWidth = tb.Width;
            int newValue = (int)((double)mouseX / sliderWidth * tb.Maximum);
            tb.Value = Math.Max(tb.Minimum, Math.Min(tb.Maximum, newValue));
            _mediaPlayer.Time = tb.Value * _mediaPlayer.Length / tb.Maximum;
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            if (_mediaPlayer != null)
            {
                _mediaPlayer.Volume = trackBarVolume.Value;
                lblVolume.Text = $"Volume: {trackBarVolume.Value}%";
            }
        }

        private void trackBarMovement(object sender, MouseEventArgs e)
        {
            if (_mediaPlayer == null || _mediaPlayer.Length <= 0)
            {
                return;
            }
            TrackBar tb = (TrackBar)sender;
            int mouseX = e.X;
            int sliderWidth = tb.Width;
            int newValue = (int)((double)mouseX / sliderWidth * tb.Maximum);
            tb.Value = Math.Max(tb.Minimum, Math.Min(tb.Maximum, newValue));
            _mediaPlayer.Time = tb.Value * _mediaPlayer.Length / tb.Maximum;
            _isSeeking = false;
        }
    }
}