using MediaCatalog.Entities.Entities;

namespace MediaCatalog.BusinessLogic.Interfaces
{
    public interface IMediaFileService
    {
        Task AddFileIfNotExistsAsync(string directoryPath, string fileName);

        Task<MediaFile> GetByNameAndDirectoryAsync(string directoryPath, string fileName);

        Task<FileInfo[]> GetFilesByTagFilterAsync(IEnumerable<int> tagIds, IFileSystemService fileSystemService);

        Task<int> GetMediaFileIdAsync(string directoryPath, string fileName);

        Task<bool> IsFileRegisteredAsync(string directoryPath, string fileName);
    }
}