namespace FileCatalogInterface
{
    using LibVLCSharp.Shared;
    using LibVLCSharp.WinForms;
    using FileCatalogTestLib;

    public partial class Form1 : Form
    {
        private readonly LibVLC _libVlc;
        private readonly MediaPlayer _mediaPlayer;
        readonly VideoController _videoControl;
        private bool _isSeeking = false;


        public Form1(VideoController newController)
        {
            InitializeComponent();

            Core.Initialize(); // важно

            _libVlc = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVlc);
            _videoControl = newController;
            videoView1.MediaPlayer = _mediaPlayer;
            _mediaPlayer.Volume = trackBarVolume.Value;
            lblVolume.Text = $@"Volume: {trackBarVolume.Value}%";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            string videoPath = _videoControl.GetFirstFile();

            var media = new Media(_libVlc, videoPath, FromType.FromPath);
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
            lblPosition.Text = @"00:00 / 00:00";
        }

        private void positionTimer_Tick(object sender, EventArgs e)
        {
            if (!_mediaPlayer.IsPlaying || _isSeeking)
            {
                return;
            }

            long current = _mediaPlayer.Time;        // текуща¤ позици¤ в мс
            long total = _mediaPlayer.Length;        // обща¤ длительность в мс

            lblPosition.Text = $@"{FormatTime(current)} / {FormatTime(total)}";
            // ќбновление позиции ползунка
            trackBarSeek.Value = (int)(current * 1000 / total);
        }
        private static string FormatTime(long milliseconds)
        {
            var ts = TimeSpan.FromMilliseconds(milliseconds);
            return $"{ts.Minutes:D2}:{ts.Seconds:D2}";
        }

        private void trackBarSeek_Scroll(object sender, EventArgs e)
        {
            if (_mediaPlayer.Length <= 0) return;
            long newTime = trackBarSeek.Value * _mediaPlayer.Length / 1000;
            _mediaPlayer.Time = newTime;
        }

        private void trackBarSeek_MouseUp(object sender, MouseEventArgs e)
        {
            if (_mediaPlayer.Length <= 0)
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
            if (_mediaPlayer.Length <= 0)
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
            _mediaPlayer.Volume = trackBarVolume.Value;
            lblVolume.Text = $@"Volume: {trackBarVolume.Value}%";
        }

        private void TrackBarMovement(object sender, MouseEventArgs e)
        {
            if (_mediaPlayer.Length <= 0)
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