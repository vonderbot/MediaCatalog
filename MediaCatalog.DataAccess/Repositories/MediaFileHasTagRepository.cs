using MediaCatalog.DataAccess.Contexts;
using MediaCatalog.DataAccess.Interfaces;
using MediaCatalog.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediaCatalog.DataAccess.Repositories
{
    public class MediaFileHasTagRepository : IMediaFileHasTagRepository
    {
        protected readonly MediaCatalogDbContext _mediaCatalogDbContext;
        protected readonly DbSet<MediaFileHasTag> Table;

        public MediaFileHasTagRepository(MediaCatalogDbContext DbContext)
        {
            _mediaCatalogDbContext = DbContext;
            Table = _mediaCatalogDbContext.Set<MediaFileHasTag>();
        }

        public async Task Create(MediaFileHasTag entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task DeleteAsync(int mediaFileId, int tagId)
        {
            var entity = await Table
                .FirstOrDefaultAsync(x =>
                    x.MediaFileId == mediaFileId &&
                    x.TagId == tagId);

            if (entity == null)
                return;

            Table.Remove(entity);
        }

        public async Task Save()
        {
            await _mediaCatalogDbContext.SaveChangesAsync();
        }

        public async Task<List<int>> GetFileIdsByAllTagsAsync(int folderId, IEnumerable<int> tagIds)
        {
            var tags = tagIds.ToList();

            return await Table
                .Where(x => tags.Contains(x.TagId) &&
                            x.MediaFile.FolderId == folderId)
                .GroupBy(x => x.MediaFileId)
                .Where(g => g.Select(x => x.TagId).Distinct().Count() == tags.Count)
                .Select(g => g.Key)
                .ToListAsync();
        }

        public bool ExistsByNameFolderAndIds(
    string fileName,
    int folderId,
    ICollection<int> allowedIds)
        {
            return Table.Any(x =>
                x.MediaFile.Name == fileName &&
                x.MediaFile.FolderId == folderId &&
                allowedIds.Contains(x.MediaFileId));
        }

        public async Task<List<int>> GetTagIdsByMediaFileIdAsync(int mediaFileId)
        {
            return await Table
                .Where(x => x.MediaFileId == mediaFileId)
                .Select(x => x.TagId)
                .ToListAsync();
        }
    }
}
