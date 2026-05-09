using MediaCatalog.DataAccess.Contexts;
using MediaCatalog.DataAccess.Interfaces;
using MediaCatalog.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediaCatalog.DataAccess.Repositories
{
    public class FolderRepository : BaseRepository<Folder>, IFolderRepository
    {
        public FolderRepository(MediaCatalogDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<Folder?> GetByPath(string path)
        {
            return await _table
                .AsNoTracking()
                .FirstOrDefaultAsync(folder => folder.Path == path);
        }
    }
}