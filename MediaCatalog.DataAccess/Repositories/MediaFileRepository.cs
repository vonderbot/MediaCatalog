using MediaCatalog.DataAccess.Contexts;
using MediaCatalog.DataAccess.Interfaces;
using MediaCatalog.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediaCatalog.DataAccess.Repositories
{
    public class MediaFileRepository : BaseRepository<MediaFile>, IMediaFileRepository
    {
        public MediaFileRepository(MediaCatalogDbContext DbContext)
            : base(DbContext)
        {
        }

        public async Task<MediaFile?> GetByNameAndFolder(string fileName, int folderId)
        {
            return await Table
                .FirstOrDefaultAsync(f => f.Name == fileName && f.FolderId == folderId);
        }
    }
}
