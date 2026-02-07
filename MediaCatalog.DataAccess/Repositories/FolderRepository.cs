using MediaCatalog.DataAccess.Contexts;
using MediaCatalog.DataAccess.Interfaces;
using MediaCatalog.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediaCatalog.DataAccess.Repositories
{
    public class FolderRepository : BaseRepository<Folder>, IFolderRepository
    {
        public FolderRepository(MediaCatalogDbContext DbContext)
            : base(DbContext)
        {
        }

        public async Task<Folder?> GetByPath(string path)
        {
            return await Table.FirstOrDefaultAsync(c => c.Path == path);
        }
    }
}
