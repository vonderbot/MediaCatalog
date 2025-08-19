namespace MediaCatalog.UI.WinForms
{
    using LibVLCSharp.Shared;
    using LibVLCSharp.WinForms;
    using MediaCatalog.BusinessLogic.Interfaces;
    using System.IO;

    public partial class PlayerForm : Form
    {
        private readonly LibVLC _libVlc;
        private readonly MediaPlayer _mediaPlayer;
        private readonly IFileService _fileService;
        private readonly IUserSettingsService _settingsService;
        private bool _isSeeking;
        private int _currentIndex;
        private int _sortColumn;
        private SortOrder _sortOrder;

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
            _sortColumn = -1;
            _sortOrder = SortOrder.Ascending;
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
            LoadFilesToListView();

            positionTimer.Start();
        }

        private void LoadFilesToListView()
        {
            ListViewFiles.Items.Clear();

            foreach (var fileInfo in _fileService.GetFiles())
            {
                var item = new ListViewItem(Path.GetFileNameWithoutExtension(fileInfo.Name));
                item.SubItems.Add(fileInfo.Extension);
                item.SubItems.Add(fileInfo.CreationTime.ToString("dd.MM.yyyy"));
                item.Tag = fileInfo; // сохраняем FileInfo для дальнейшей работы (переименование, удаление, сортировка)
                ListViewFiles.Items.Add(item);
            }
        }

        private void PlayVideo(int fileIndex)
        {
            if(fileIndex < 0 || fileIndex >= ListViewFiles.Items.Count)
                return;

            var item = ListViewFiles.Items[fileIndex];
            if (item.Tag is not FileInfo fileInfo)
                return;

            var media = new Media(_libVlc, fileInfo.FullName, FromType.FromPath);
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
            int itemCount = ListViewFiles.Items.Count;
            if (itemCount == 0) return;

            int newIndex = _currentIndex + indexChange;
            if (newIndex < 0)
            {
                newIndex = itemCount + (newIndex % itemCount);
            }
            else
            {
                newIndex = newIndex % itemCount;
            }
            _currentIndex = newIndex;
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

            ListViewFiles.SelectedItems.Clear();

            if (_currentIndex >= 0 && _currentIndex < ListViewFiles.Items.Count)
            {
                var item = ListViewFiles.Items[_currentIndex];
                item.Selected = true;
                item.Focused = true;
                item.EnsureVisible();
                ListViewFiles.Focus();
            }
        }

        private void PreviousFile_Click(object sender, EventArgs e)
        {
            ChangeIndex(-1);

            // Убираем текущее выделение
            ListViewFiles.SelectedItems.Clear();

            // Проверяем корректность индекса и выделяем нужный элемент
            if (_currentIndex >= 0 && _currentIndex < ListViewFiles.Items.Count)
            {
                var item = ListViewFiles.Items[_currentIndex];
                item.Selected = true;
                item.Focused = true;
                item.EnsureVisible();
                ListViewFiles.Focus();
            }
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
            if (ListViewFiles.SelectedItems.Count != 1)
                return;

            if (ListViewFiles.SelectedItems[0].Tag is not FileInfo selectedFileInfo)
                return;

            var currentPath = selectedFileInfo.FullName;
            var selectedFileName = selectedFileInfo.Name;
            string? newName = Prompt.ShowDialog("Новое имя файла:", "Переименование", selectedFileName);

            if (!string.IsNullOrWhiteSpace(newName))
            {
                var directory = _fileService.GetDirectory();
                var newPath = Path.Combine(directory, newName);

                try
                {
                    string? mediaMrl = _mediaPlayer.Media?.Mrl;
                    string normalizedMediaPath = mediaMrl != null ? Uri.UnescapeDataString(new Uri(mediaMrl).LocalPath) : string.Empty;
                    bool isSameFile = normalizedMediaPath == currentPath;

                    bool isPlaying = _mediaPlayer.IsPlaying || _mediaPlayer.State == VLCState.Paused;

                    if (isSameFile && isPlaying)
                    {
                        MessageBox.Show("Невозможно переименовать файл, который воспроизводится. Остановите воспроизведение.");
                        return;
                    }

                    File.Move(currentPath, newPath);

                    _fileService.DirectoryReshafle(directory);
                    _currentIndex = _fileService.GetFileIndex(newName);
                    VideoPlayerReload(_currentIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при переименовании файла:\n{ex.Message}");
                }
            }
        }

        private void listViewFiles_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == _sortColumn && _sortOrder == SortOrder.Ascending)
                _sortOrder = SortOrder.Descending;
            else if (e.Column == _sortColumn && _sortOrder == SortOrder.Descending)
                _sortOrder = SortOrder.Ascending;
            else
            {
                _sortColumn = e.Column;
                _sortOrder = SortOrder.Ascending;
            }

            ListViewFiles.ListViewItemSorter = new FileListViewItemComparer(e.Column, _sortOrder);
            ListViewFiles.Sort();

            if (ListViewFiles.SelectedItems.Count > 0)
            {
                var selectedFile = (FileInfo)ListViewFiles.SelectedItems[0].Tag;

                for (int i = 0; i < ListViewFiles.Items.Count; i++)
                {
                    if (ListViewFiles.Items[i].Tag is FileInfo file && file.FullName == selectedFile.FullName)
                    {
                        ListViewFiles.Items[i].Selected = true;
                        ListViewFiles.Items[i].Focused = true;
                        ListViewFiles.Items[i].EnsureVisible();
                        _currentIndex = i; // Обновляем индекс проигрываемого файла
                        break;
                    }
                }
            }
        }

        private void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListViewFiles.SelectedIndices.Count > 0)
            {
                ChangeIndex(ListViewFiles.SelectedIndices[0] - _currentIndex);
                PlayVideo(ListViewFiles.SelectedIndices[0]);
            }
        }
    }
}