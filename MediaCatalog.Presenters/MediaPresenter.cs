using MediaCatalog.BusinessLogic.Interfaces;
using MediaCatalog.Common;
using MediaCatalog.Entities.Entities;


namespace MediaCatalog.Presenters
{
    public class MediaPresenter : IMediaPresenter
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IMediaFileService _mediaFileService;
        private readonly IUserSettingsService _settingsService;
        private readonly ITagService _tagService;
        private int _sortColumn;
        private CatalogSortOrder _sortOrder;

        public MediaPresenter(IFileSystemService fileSystemService, IMediaFileService mediaFileService, IUserSettingsService settingsService, ITagService tagService)
        {
            _fileSystemService = fileSystemService;
            _mediaFileService = mediaFileService;
            _settingsService = settingsService;
            _tagService = tagService;
            _sortColumn = -1;
            _sortOrder = CatalogSortOrder.Ascending;
        }

        public string? GetLastOpenedFile()
        {
            return _settingsService.GetLastOpenedFile();
        }

        public void SaveLastOpenedFile(string fileName)
        {
             _settingsService.SaveLastOpenedFile(fileName);
        }

        public async Task<IEnumerable<FileInfo>> ApplyTagFilterAsync(IEnumerable<int> tagIds)
        {
            var files = await _mediaFileService.GetFilesByTagFilterAsync(tagIds, _fileSystemService);
            return files;
        }

        public async Task<IEnumerable<int>> GetTagIdsForFileAsync(string fileName)
        {
            var fileId = await _mediaFileService.GetMediaFileIdAsync(_fileSystemService.GetDirectoryPath(), fileName);
            return await _tagService.GetTagIdsByMediaFileIdAsync(fileId);
        }

        public async Task AssignTagToCurrentFileAsync(int tagId, string fileName)
        {
            var fileId = await _mediaFileService.GetMediaFileIdAsync(_fileSystemService.GetDirectoryPath(), fileName);
            await _tagService.AssignTagToFileAsync(tagId, fileId);
        }

        public async Task RemoveTagFromCurrentFileAsync(int tagId, string fileName)
        {
            var fileId = await _mediaFileService.GetMediaFileIdAsync(_fileSystemService.GetDirectoryPath(), fileName);
            await _tagService.RemoveTagFromFileAsync(tagId, fileId);
        }

        public async Task<IEnumerable<Tag>> GetAllTagsAsync()
        {
            return await _tagService.GetAllAsync();
        }

        public async Task AddNewTag(string newTagName)
        {
            if (string.IsNullOrWhiteSpace(newTagName))
                throw new Exception("название тэга не может быть пустым");
            if (await _tagService.ExistsAsync(newTagName))
                throw new Exception("такой тэг уже существует");

            await _tagService.CreateTagAsync(newTagName);
        }

        public async Task<bool> CheckFileRegistration(string fileName)
        {
            return await _mediaFileService.IsFileRegisteredAsync(_fileSystemService.GetDirectoryPath(), fileName);
        }

        public async Task AddCurentFiletoDb(string fileName)
        {
            await _mediaFileService.AddFileIfNotExistsAsync(_fileSystemService.GetDirectoryPath(), fileName);
        }

        public async Task<String> GetTagName(int id)
        {
            return await _tagService.GetNameByIdAsync(id);
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
        }

        public CatalogSortOrder GetSortOrder()
        {
            return _sortOrder;
        }

        //public void RenameFile(FileInfo file, string newName)
        //{
        //    _fileService.RenameFile(file, newName);
        //    _currentIndex = _fileService.GetFileIndex(newName);
        //}

        public void ChangeDirectory(string newPath)
        {
            _fileSystemService.RefreshDirectory(newPath);
            _settingsService.ChangeDirectoryPath(newPath);
        }

        public IEnumerable<FileInfo> GetFilesInfo()
        {
            return _fileSystemService.GetFiles();
        }

        public string GetCurrentFileDirectory()
        {
            return _fileSystemService.GetDirectoryPath();
        }
    }
}
