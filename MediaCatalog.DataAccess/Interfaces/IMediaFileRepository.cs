using MediaCatalog.Entities.Entities;

namespace MediaCatalog.DataAccess.Interfaces
{
    public interface IMediaFileRepository : IBaseRepository<MediaFile>
    {
        Task<MediaFile?> GetByNameAndFolderAsync(string fileName, int folderId);
    }
}
