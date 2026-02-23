using MediaCatalog.DataAccess.Contexts;
using MediaCatalog.DataAccess.Interfaces;
using MediaCatalog.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediaCatalog.DataAccess.Repositories
{
    public class MediaFileHasTagRepository : IMediaFileHasTagRepository
    {
        private readonly MediaCatalogDbContext _dbContext;

        private readonly DbSet<MediaFileHasTag> _table;

        public MediaFileHasTagRepository(MediaCatalogDbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<MediaFileHasTag>();
        }

        public async Task CreateAsync(MediaFileHasTag entity)
        {
            await _table.AddAsync(entity);
        }

        public async Task DeleteAsync(int mediaFileId, int tagId)
        {
            var entity = await _table
                .FirstOrDefaultAsync(x =>
                    x.MediaFileId == mediaFileId &&
                    x.TagId == tagId);

            if (entity != null)
            {
                _table.Remove(entity);
            }
        }

        public bool ExistsByNameFolderAndIds(
            string fileName,
            int folderId,
            IReadOnlyCollection<int> allowedMediaFileIds)
        {
            return _table.Any(x =>
                x.MediaFile.Name == fileName &&
                x.MediaFile.FolderId == folderId &&
                allowedMediaFileIds.Contains(x.MediaFileId));
        }

        public async Task<IReadOnlyList<int>> GetFileIdsByAllTagsAsync(
            int folderId,
            IEnumerable<int> tagIds)
        {
            var tagIdList = tagIds.ToList();

            if (!tagIdList.Any())
            {
                return Array.Empty<int>();
            }

            return await _table
                .AsNoTracking()
                .Where(x =>
                    tagIdList.Contains(x.TagId) &&
                    x.MediaFile.FolderId == folderId)
                .GroupBy(x => x.MediaFileId)
                .Where(group =>
                    group
                        .Select(x => x.TagId)
                        .Distinct()
                        .Count() == tagIdList.Count)
                .Select(group => group.Key)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<int>> GetTagIdsByMediaFileIdAsync(int mediaFileId)
        {
            return await _table
                .AsNoTracking()
                .Where(x => x.MediaFileId == mediaFileId)
                .Select(x => x.TagId)
                .ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}