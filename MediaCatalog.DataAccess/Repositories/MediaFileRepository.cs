using MediaCatalog.DataAccess.Contexts;
using MediaCatalog.DataAccess.Interfaces;
using MediaCatalog.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediaCatalog.DataAccess.Repositories
{
    public class MediaFileRepository
        : BaseRepository<MediaFile>, IMediaFileRepository
    {
        public MediaFileRepository(MediaCatalogDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<MediaFile?> GetByNameAndFolderAsync(
            string fileName,
            int folderId)
        {
            return await _table
                .AsNoTracking()
                .FirstOrDefaultAsync(mediaFile =>
                    mediaFile.Name == fileName &&
                    mediaFile.FolderId == folderId);
        }
    }
}
