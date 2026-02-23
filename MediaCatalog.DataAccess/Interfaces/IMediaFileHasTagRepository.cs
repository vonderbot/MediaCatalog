using MediaCatalog.Entities.Entities;

namespace MediaCatalog.DataAccess.Interfaces
{
    public interface IMediaFileHasTagRepository
    {
        Task CreateAsync(MediaFileHasTag entity);

        Task DeleteAsync(int mediaFileId, int tagId);

        bool ExistsByNameFolderAndIds(
            string fileName,
            int folderId,
            IReadOnlyCollection<int> allowedMediaFileIds);

        Task<IReadOnlyList<int>> GetFileIdsByAllTagsAsync(
            int folderId,
            IEnumerable<int> tagIds);

        Task<IReadOnlyList<int>> GetTagIdsByMediaFileIdAsync(int mediaFileId);

        Task SaveAsync();
    }
}