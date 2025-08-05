namespace FileCatalogInterface
{
    using FileCatalogBusinesLogic.Interfaces;
    using FileCatalogBusinesLogic.Services;
    using LibVLCSharp.Shared;
    using LibVLCSharp.WinForms;

    public partial class PlayerForm : Form
    {
        private readonly LibVLC _libVlc;
        private readonly MediaPlayer _mediaPlayer;
        private readonly IFileService _fileService;
        private readonly IUserSettingsService _settingsService;
        private bool _isSeeking;
        private int _currentIndex;

        public PlayerForm(IFileService fileService, IUserSettingsService settingsService)
        {
            InitializeComponent();
            Core.Initialize(); // important

            _libVlc = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVlc);
            _fileService = fileService;
            _settingsService = settingsService;
            _isSeeking = false;
            _currentIndex = 0;
        }

        private void PlayerForm_Load(object sender, EventArgs e)
        {
            VideoView.MediaPlayer = _mediaPlayer;
            ChangeVolume(TrackBarVolume);
            VideoPlayerReload(_currentIndex);
        }

        private void VideoPlayerReload(int newIndex)
        {
            if (newIndex != _currentIndex)
            {
                _currentIndex = newIndex;
            }
            ListBoxFiles.Items.Clear();
            ListBoxFiles.Items.AddRange(_fileService.GetFileNames());
            ListBoxFiles.SelectedIndex = _currentIndex;
            positionTimer.Start();
        }

        private void PlayVideo(int fileIndex)
        {
            var media = new Media(_libVlc, _fileService.GetFile(fileIndex), FromType.FromPath);
            _mediaPlayer.Play(media);
            positionTimer.Start();
        }

        private void ChangeVolume(TrackBar trackBar)
        {
            _mediaPlayer.Volume = trackBar.Value;
            VolumeLbl.Text = $@"Volume: {trackBar.Value}%";
        }

        private void ChangeIndex(int indexChange)
        {
            if (_currentIndex + indexChange >= 0 && _currentIndex + indexChange < ListBoxFiles.Items.Count)
            {
                _currentIndex = _currentIndex + indexChange;
            }
            else if (_currentIndex + indexChange < 0)
            {
                _currentIndex = ListBoxFiles.Items.Count + _currentIndex + indexChange;
            }
            else if (_currentIndex + indexChange >= ListBoxFiles.Items.Count)
            {
                _currentIndex = _currentIndex + indexChange - ListBoxFiles.Items.Count;
            }
        }

        private static string FormatTime(long milliseconds)
        {
            var ts = TimeSpan.FromMilliseconds(milliseconds);
            return $"{ts.Minutes:D2}:{ts.Seconds:D2}";
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            if (_mediaPlayer.State != VLCState.Stopped)
            {
                _mediaPlayer?.Pause();
                BtnPause.Text = BtnPause.Text == "Pause" ? "Play" : "Pause";
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            _mediaPlayer?.Stop();
            BtnPause.Text = "Pause";
            PositionLbl.Text = @"00:00 / 00:00";
        }

        private void PositionTimer_Tick(object sender, EventArgs e)
        {
            if (!_mediaPlayer.IsPlaying || _isSeeking)
            {
                return;
            }

            long current = _mediaPlayer.Time;        // current position in MS
            long total = _mediaPlayer.Length;        // total duration in ms

            PositionLbl.Text = $@"{FormatTime(current)} / {FormatTime(total)}";
            TrackBarSeek.Value = (int)(current * 1000 / total);
        }

        private void TrackBarSeek_Scroll(object sender, EventArgs e)
        {
            if (_mediaPlayer.Length <= 0) return;

            _mediaPlayer.Time = TrackBarSeek.Value * _mediaPlayer.Length / 1000;
        }

        private void TrackBarSeek_MouseUp(object sender, MouseEventArgs e)
        {
            if (_mediaPlayer.Length <= 0)
            {
                return;
            }

            TrackBar tb = (TrackBar)sender;
            _mediaPlayer.Time = Math.Max(tb.Minimum,
                Math.Min(tb.Maximum, (int)((double)e.X / tb.Width * tb.Maximum)))
                * _mediaPlayer.Length / tb.Maximum;
            _isSeeking = false;
        }

        private void TrackBarSeek_MouseDown(object sender, MouseEventArgs e)
        {
            if (_mediaPlayer.Length <= 0)
            {
                return;
            }

            _isSeeking = true;
            TrackBar tb = (TrackBar)sender;
            _mediaPlayer.Time = Math.Max(tb.Minimum,
                Math.Min(tb.Maximum, (int)((double)e.X / tb.Width * tb.Maximum)))
                * _mediaPlayer.Length / tb.Maximum;
        }

        private void TrackBarVolume_Scroll(object sender, EventArgs e)
        {
            ChangeVolume(TrackBarVolume);
        }

        private void TrackBarMovement(object sender, MouseEventArgs e)
        {
            if (_mediaPlayer.Length <= 0)
            {
                return;
            }

            TrackBar tb = (TrackBar)sender;
            _mediaPlayer.Time = Math.Max(tb.Minimum,
                Math.Min(tb.Maximum, (int)((double)e.X / tb.Width * tb.Maximum)))
                * _mediaPlayer.Length / tb.Maximum;
            _isSeeking = false;
        }

        private void TrackBarVolume_MouseDown(object sender, MouseEventArgs e)
        {
            TrackBar tb = (TrackBar)sender;
            tb.Value = Math.Max(tb.Minimum, Math.Min(tb.Maximum, tb.Maximum - (int)((double)e.Y / tb.Height * tb.Maximum)));
            ChangeVolume(tb);
        }

        private void NextFile_Click(object sender, EventArgs e)
        {
            ChangeIndex(1);
            ListBoxFiles.SelectedIndex = _currentIndex;
        }

        private void PreviousFile_Click(object sender, EventArgs e)
        {
            ChangeIndex(-1);
            ListBoxFiles.SelectedIndex = _currentIndex;
        }

        private void ListBoxVideos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeIndex(ListBoxFiles.SelectedIndex - _currentIndex);
            PlayVideo(ListBoxFiles.SelectedIndex);
        }

        private void BtnSelectFolder_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = _fileService.GetDirectory();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _fileService.DirectoryReshafle(dialog.SelectedPath);
                _settingsService.ChangeDirectoryPath(dialog.SelectedPath);
                VideoPlayerReload(0);
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListBoxFiles.SelectedItem == null) return;

            var selectedFile = ListBoxFiles.SelectedItem.ToString();
            var currentPath = Path.Combine(_fileService.GetDirectory(), selectedFile);
            string? newName = Prompt.ShowDialog("Новое имя файла:", "Переименование", selectedFile);
            if (!string.IsNullOrWhiteSpace(newName))
            {
                var newPath = Path.Combine(_fileService.GetDirectory(), newName);
                try
                {
                    bool isSameFile = new Uri(_mediaPlayer.Media?.Mrl ?? "").LocalPath == currentPath;
                    bool isPlaying = _mediaPlayer.IsPlaying || _mediaPlayer.State == VLCState.Paused;
                    if (isSameFile && isPlaying)
                    {
                        MessageBox.Show("Невозможно переименовать файл, который воспроизводится. Остановите воспроизведение.");
                        return;
                    }
                    File.Move(currentPath, newPath);
                    _fileService.DirectoryReshafle(_fileService.GetDirectory());
                    _currentIndex = _fileService.GetFileIndex(newName);
                    VideoPlayerReload(_currentIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при переименовании файла:\n{ex.Message}");
                }
            }
        }

        private void VolumeLbl_Click(object sender, EventArgs e)
        {

        }
    }
}