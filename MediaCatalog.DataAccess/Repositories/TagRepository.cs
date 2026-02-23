using MediaCatalog.DataAccess.Contexts;
using MediaCatalog.DataAccess.Interfaces;
using MediaCatalog.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediaCatalog.DataAccess.Repositories
{
    public class TagRepository
        : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(MediaCatalogDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<Tag?> GetByNameAsync(string tagName)
        {
            return await _table
                .AsNoTracking()
                .FirstOrDefaultAsync(tag => tag.Name == tagName);
        }
    }
}
