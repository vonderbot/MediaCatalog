namespace MediaCatalog.UI.WinForms
{
    using LibVLCSharp.Shared;
    using LibVLCSharp.WinForms;
    using MediaCatalog.Presenters;
    using System.IO;

    public partial class PlayerForm : Form
    {
        private readonly LibVLC _libVlc;
        private readonly MediaPlayer _mediaPlayer;
        private readonly IMediaPresenter _presenter;
        private bool _isSeeking;

        public PlayerForm(IMediaPresenter presenter)
        {
            InitializeComponent();
            Core.Initialize(); // important

            _libVlc = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVlc);
            _presenter = presenter;
            _isSeeking = false;
        }

        private void PlayerForm_Load(object sender, EventArgs e)
        {
            VideoView.MediaPlayer = _mediaPlayer;
            ChangeVolume(TrackBarVolume);
            VideoPlayerReload(_presenter.GetCurrentIndex());
        }

        private void VideoPlayerReload(int newIndex)
        {
            _presenter.ChangeCurrentIndex(newIndex);
            LoadFiles(_presenter.GetFilesInfo());
            positionTimer.Start();
            ReselectItem();
        }

        private void LoadFiles(IEnumerable<FileInfo> files)
        {
            ListViewFiles.Items.Clear();
            foreach (var fileInfo in files)
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
            BtnPause.Text = "Play";
        }

        private void ChangeVolume(TrackBar trackBar)
        {
            _mediaPlayer.Volume = trackBar.Value;
            VolumeLbl.Text = $@"Volume: {trackBar.Value}%";
        }

        private static string FormatTimeString(long milliseconds)
        {
            var ts = TimeSpan.FromMilliseconds(milliseconds);
            return $"{ts.Minutes:D2}:{ts.Seconds:D2}";
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            if (_mediaPlayer.State == VLCState.Playing)
            {
                _mediaPlayer?.Pause();
                BtnPause.Text = "Pause";
            }
            else if (_mediaPlayer.State == VLCState.Paused)
            {
                _mediaPlayer?.Pause();
                BtnPause.Text = "Play";
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            _mediaPlayer?.Stop();
            BtnPause.Text = "Stoped";
            PositionLbl.Text = @"00:00 / 00:00";
        }

        private void PositionTimer_Tick(object sender, EventArgs e)
        {
            if (!_mediaPlayer.IsPlaying || _isSeeking)
            {
                return;
            }
            else if (_mediaPlayer == null || _mediaPlayer.Length <= 0)
            {
                TrackBarSeek.Value = 0;
                return;
            }//экспериментальная защита от деления на ноль при фото

            long current = _mediaPlayer.Time;        // current position in MS
            long total = _mediaPlayer.Length;        // total duration in ms

            PositionLbl.Text = $@"{FormatTimeString(current)} / {FormatTimeString(total)}";
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
            _presenter.MoveCurrentIndex(1);
            ReselectItem();
        }

        private void ReselectItem()
        {
            ListViewFiles.SelectedItems.Clear();
            if (_presenter.GetCurrentIndex() >= 0 && _presenter.GetCurrentIndex() < ListViewFiles.Items.Count)
            {
                var item = ListViewFiles.Items[_presenter.GetCurrentIndex()];
                item.Selected = true;
                item.Focused = true;
                item.EnsureVisible();
                ListViewFiles.Focus();
            }
        }

        private void PreviousFile_Click(object sender, EventArgs e)
        {
            _presenter.MoveCurrentIndex(-1);
            ReselectItem();
        }

        private void BtnSelectFolder_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = _presenter.GetCurrentFileDirectory();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _presenter.ChangeDirectory(dialog.SelectedPath);
                VideoPlayerReload(0);
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //проверяем, выделен ли только один объект и получаем его информацию
            if (ListViewFiles.SelectedItems.Count != 1||
                ListViewFiles.SelectedItems[0].Tag is not FileInfo selectedFileInfo)
                return;
            //выводим пользователю диалогове окно для воода нового имени
            string? newName = Prompt.ShowDialog("Новое имя файла:", "Переименование", selectedFileInfo.Name);

            if (!string.IsNullOrWhiteSpace(newName))
            {
                try
                {
                    string? mediaMrl = _mediaPlayer.Media?.Mrl;
                    string normalizedMediaPath = mediaMrl != null ? Uri.UnescapeDataString(new Uri(mediaMrl).LocalPath) : string.Empty;
                    bool isSameFile = normalizedMediaPath == selectedFileInfo.FullName;
                    bool isPlaying = _mediaPlayer.IsPlaying || _mediaPlayer.State == VLCState.Paused;
                    if (isSameFile && isPlaying)
                    {
                        MessageBox.Show("Невозможно переименовать файл, который воспроизводится. Остановите воспроизведение.");
                        return;
                    }
                    _presenter.RenameFile(selectedFileInfo, newName);
                    VideoPlayerReload(_presenter.GetCurrentIndex());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при переименовании файла:\n{ex.Message}");
                }
            }
        }

        private void listViewFiles_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            _presenter.NewSort(e.Column);
            ListViewFiles.ListViewItemSorter = new FileListViewItemComparer(e.Column, _presenter.GetSortOrder());
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
                        _presenter.ChangeCurrentIndex(i);
                        break;
                    }
                }
            }
        }

        private void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListViewFiles.SelectedIndices.Count > 0)
            {
                _presenter.MoveCurrentIndex(ListViewFiles.SelectedIndices[0] - _presenter.GetCurrentIndex());
                PlayVideo(ListViewFiles.SelectedIndices[0]);
            }
        }
    }
}