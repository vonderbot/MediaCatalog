using MediaCatalog.BusinessLogic.Interfaces;
using MediaCatalog.BusinessLogic.Services;
using MediaCatalog.Common;


namespace MediaCatalog.Presenters
{
    public class MediaPresenter : IMediaPresenter
    {
        //private readonly IPlayerView _view;//Возможно стоит удалить.
        private readonly IFileService _fileService;
        private readonly IUserSettingsService _settingsService;
        private readonly ITagService _tagService;
        private int _currentIndex;
        private int _sortColumn;
        private CatalogSortOrder _sortOrder;

        public MediaPresenter(IFileService fileService, IUserSettingsService settingsService, ITagService tagService)
        {
            _fileService = fileService;
            _settingsService = settingsService;
            _tagService = tagService;
            _currentIndex = 0;
            _sortColumn = -1;
            _sortOrder = CatalogSortOrder.Ascending;
        }

        public async Task<String> GetTagName(int id)
        {
            return await _tagService.GetNameById(id);
        }

        public void NewSort(int columnNumber)
        {
            if (columnNumber == _sortColumn && _sortOrder == CatalogSortOrder.Ascending)
                _sortOrder = CatalogSortOrder.Descending;
            else if (columnNumber == _sortColumn && _sortOrder == CatalogSortOrder.Descending)
                _sortOrder = CatalogSortOrder.Ascending;
            else
            {
                _sortColumn = columnNumber;
                _sortOrder = CatalogSortOrder.Ascending;
            }
            //_fileService.
        }

        public CatalogSortOrder GetSortOrder()
        {
            return _sortOrder;
        }

        public void RenameFile(FileInfo file, string newName)
        {
            _fileService.RenameFile(file, newName);
            _currentIndex = _fileService.GetFileIndex(newName);
        }

        public void ChangeDirectory(string newPath)
        {
            _fileService.DirectoryReshafle(newPath);
            _settingsService.ChangeDirectoryPath(newPath);
        }

        public IEnumerable<FileInfo> GetFilesInfo()
        {
            return _fileService.GetFiles();
        }

        public string GetCurrentFileDirectory()
        {
            return _fileService.GetDirectory();
        }

        public void MoveCurrentIndex(int MoveStep)
        {
            //Проверяем количество файлов
            int itemCount = _fileService.CountFiles();
            if (itemCount == 0) return;
            //Перемещаем действующий индекс на заданый шаг
            int newIndex = _currentIndex + MoveStep;
            //Проверяем, выход за пределы количества файлов
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

        public void ChangeCurrentIndex(int newIndex)
        {
            if (newIndex != _currentIndex)
            {
                _currentIndex = newIndex;
            }
        }

        public int GetCurrentIndex()
        {
            return _currentIndex;
        }
    }
}
