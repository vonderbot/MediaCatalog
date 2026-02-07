using MediaCatalog.BusinessLogic.Interfaces;
using MediaCatalog.DataAccess.Interfaces;
using MediaCatalog.DataAccess.Repositories;
using MediaCatalog.Entities.Entities;

namespace MediaCatalog.BusinessLogic.Services
{
    public class FileService : IFileService
    {
        private DirectoryInfo _directory;
        private FileInfo[] _files;
        private readonly IMediaFileRepository _mediaFileRepository;
        private readonly IFolderRepository _folderRepository;
        private readonly IMediaFileHasTagRepository _mediaFileHasTagRepository;

        public FileService(string directoryName, IMediaFileRepository MediaFileRepository, 
            IFolderRepository FolderRepository, IMediaFileHasTagRepository mediaFileHasTagRepository)
        {
            _directory = new DirectoryInfo(directoryName);
            _files = _directory.GetFiles();
            _mediaFileRepository = MediaFileRepository;
            _folderRepository = FolderRepository;
            _mediaFileHasTagRepository = mediaFileHasTagRepository;
        }

        public async Task<FileInfo[]> GetFilesByTagFilterAsync(IEnumerable<int> tagIds)
        {
            var tagIdList = tagIds.ToList();
            if (!tagIdList.Any())
                return _files;

            var folder = await _folderRepository.GetByPath(GetDirectory());
            if (folder == null)
                return Array.Empty<FileInfo>();

            // получаем Id файлов, подходящих под фильтр
            var mediaFileIds = await _mediaFileHasTagRepository
                .GetFileIdsByAllTagsAsync(folder.Id, tagIdList);
            // сопоставляем с локальными файлам
            var b = _files
                .Where(f =>
                    _mediaFileHasTagRepository
                        .ExistsByNameFolderAndIds(
                            f.Name,
                            folder.Id,
                            mediaFileIds))
                .ToArray();
            return b;
        }

        public async Task<int> CurrentFileId(int index)
        {
            var folder = await _folderRepository.GetByPath(this.GetDirectory());
            var fileName = _files[index].Name;
            if (folder == null)
                throw new Exception("Can`t find folder");

            var file = await _mediaFileRepository
                .GetByNameAndFolder(fileName, folder.Id) 
                ?? throw new Exception("Can`t find file");
            return file.Id;
        }

        public async Task<bool> IsFileRegistered(int index)
        {
            var folder = await _folderRepository.GetByPath(this.GetDirectory());
            var fileName = _files[index].Name;
            if (folder == null)
                return false;

            var file = await _mediaFileRepository
                .GetByNameAndFolder(fileName, folder.Id);

            return file != null;
        }

        public async Task AddFileToDb(int index)
        {
            var fileName = _files[index].Name;
            var folder = await _folderRepository.GetByPath(this.GetDirectory());

            if (folder == null)
            {
                await _folderRepository.Create(new Folder { Path = this.GetDirectory() });
                await _folderRepository.Save();
                folder = await _folderRepository.GetByPath(this.GetDirectory());
            }
            var existingFile = await _mediaFileRepository.GetByNameAndFolder(fileName, folder.Id);
            if (existingFile == null)
            {
                await _mediaFileRepository.Create(new MediaFile
                {
                    Name = fileName,
                    FolderId = folder.Id
                });
                await _folderRepository.Save();
            }
        }

        public bool CompareFileList(FileInfo[] newFiles)
        {
            if (_files.Length != newFiles.Length)
            {
                return false;
            }

            int[] arr1Copy = (int[])_files.Clone();
            int[] arr2Copy = (int[])newFiles.Clone();

            Array.Sort(arr1Copy);
            Array.Sort(arr2Copy);

            return Enumerable.SequenceEqual(arr1Copy, arr2Copy);
        }

        public void RenameFile(FileInfo file, string newName)
        {
            var directory = GetDirectory();
            var newPath = Path.Combine(directory, newName);
            File.Move(file.FullName, newPath);
            DirectoryReshafle(directory);
        }

        public void DirectoryReshafle(string directoryName)
        {
            if (Directory.Exists(directoryName) && directoryName != _directory.FullName)
            {
                _directory = new DirectoryInfo(directoryName);
            }
            _files = _directory.GetFiles();
        }

        public string GetDirectory()
        {
            return _directory.FullName;
        }

        public string[] GetFileNames()
        {
            if (_files.Length > 0)
            {
                string[] fileList = new string[_files.Count() - 1];
                for (int i = 0; i < fileList.Length; i++)
                {
                    fileList[i] = _files[i].Name;
                }
                return fileList;
            }
            else
            {
                string[] fileList = ["No files in directory"];
                return fileList;
            }
        }

        public FileInfo[] GetFiles()
        {
            return _files;
        }

        public int CountFiles()
        {
            return _files.Count();
        }

        public int GetFileIndex(string file)
        {
            if (_files.Length > 0)
            {
                for (int i = 0; i < _files.Length - 1; i++)
                {
                    if(_files[i].Name == file)
                    {
                        return i;
                    }
                }
                throw new Exception();
            }
            else
            {
                throw new Exception();
            }
        }

        public string GetFile(int index)
        {
            if (index >= 0 && index < _files.Count())
            {
                return _files[index].FullName;
            }
            else
            {
                return "Error";
            }
        }
    }
}