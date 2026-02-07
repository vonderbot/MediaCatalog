using MediaCatalog.Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MediaCatalog.DataAccess.Interfaces
{
    public interface IMediaFileHasTagRepository
    {
        public Task Create(MediaFileHasTag entity);

        public Task DeleteAsync(int mediaFileId, int tagId);

        public Task Save();

        public Task<List<int>> GetTagIdsByMediaFileIdAsync(int mediaFileId);

        public bool ExistsByNameFolderAndIds(string fileName, int folderId, ICollection<int> allowedIds);

        public Task<List<int>> GetFileIdsByAllTagsAsync(int folderId, IEnumerable<int> tagIds);
    }
}
