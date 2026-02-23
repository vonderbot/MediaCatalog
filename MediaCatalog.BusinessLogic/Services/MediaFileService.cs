using MediaCatalog.BusinessLogic.Interfaces;
using MediaCatalog.DataAccess.Interfaces;
using MediaCatalog.Entities.Entities;

namespace MediaCatalog.BusinessLogic.Services
{
    public class MediaFileService : IMediaFileService
    {
        private readonly IFolderRepository _folderRepository;
        private readonly IMediaFileRepository _mediaFileRepository;
        private readonly IMediaFileHasTagRepository _mediaFileHasTagRepository;

        public MediaFileService(
            IFolderRepository folderRepository,
            IMediaFileRepository mediaFileRepository, 
            IMediaFileHasTagRepository mediaFileHasTagRepository)
        {
            _folderRepository = folderRepository
                ?? throw new ArgumentNullException(nameof(folderRepository));
            _mediaFileRepository = mediaFileRepository
                ?? throw new ArgumentNullException(nameof(mediaFileRepository));
            _mediaFileHasTagRepository = mediaFileHasTagRepository
                ?? throw new ArgumentNullException(nameof(mediaFileHasTagRepository));
        }

        public async Task AddFileIfNotExistsAsync(string directoryPath, string fileName)
        {
            var folder = await GetOrCreateFolderAsync(directoryPath);

            var existingFile = await _mediaFileRepository
                .GetByNameAndFolderAsync(fileName, folder.Id);

            if (existingFile != null)
                return;

            await _mediaFileRepository.Create(new MediaFile
            {
                FolderId = folder.Id,
                Name = fileName
            });

            await _mediaFileRepository.Save();
        }

        public async Task<MediaFile> GetByNameAndDirectoryAsync(string directoryPath, string fileName)
        {
            var folder = await GetFolderAsync(directoryPath);

            var file = await _mediaFileRepository
                .GetByNameAndFolderAsync(fileName, folder.Id);

            return file ?? throw new InvalidOperationException(
                $"MediaFile '{fileName}' not found in directory '{directoryPath}'.");
        }

        public async Task<FileInfo[]> GetFilesByTagFilterAsync(IEnumerable<int> tagIds, IFileSystemService fileSystemService)
        {
            var tagIdList = tagIds.ToList();
            var files = fileSystemService.GetFiles();
            if (!tagIdList.Any())
                return files;

            var folder = await _folderRepository.GetByPath(fileSystemService.GetDirectoryPath());
            if (folder == null)
                return Array.Empty<FileInfo>();

            // получаем Id файлов, подходящих под фильтр
            var mediaFileIds = await _mediaFileHasTagRepository
                .GetFileIdsByAllTagsAsync(folder.Id, tagIdList);

            // сопоставляем с локальными файлам
            var b = files
                .Where(f =>
                    _mediaFileHasTagRepository
                        .ExistsByNameFolderAndIds(
                            f.Name,
                            folder.Id,
                            mediaFileIds))
                .ToArray();
            return b;
        }

        public async Task<int> GetMediaFileIdAsync(string directoryPath, string fileName)
        {
            var file = await GetByNameAndDirectoryAsync(directoryPath, fileName);
            return file.Id;
        }

        public async Task<bool> IsFileRegisteredAsync(string directoryPath, string fileName)
        {
            var folder = await _folderRepository.GetByPath(directoryPath);
            if (folder == null)
                return false;

            return await _mediaFileRepository
                .GetByNameAndFolderAsync(fileName, folder.Id) != null;
        }

        private async Task<Folder> GetFolderAsync(string directoryPath)
        {
            var folder = await _folderRepository.GetByPath(directoryPath);

            return folder ?? throw new InvalidOperationException(
                $"Folder '{directoryPath}' is not registered.");
        }

        private async Task<Folder> GetOrCreateFolderAsync(string directoryPath)
        {
            var folder = await _folderRepository.GetByPath(directoryPath);
            if (folder != null)
                return folder;

            var newFolder = new Folder
            {
                Path = directoryPath
            };

            await _folderRepository.Create(newFolder);
            await _folderRepository.Save();

            return newFolder;
        }
    }
}
