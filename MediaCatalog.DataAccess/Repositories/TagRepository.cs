using MediaCatalog.DataAccess.Contexts;
using MediaCatalog.DataAccess.Interfaces;
using MediaCatalog.Entities.Entities;

namespace MediaCatalog.DataAccess.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(MediaCatalogDbContext contributionDbContext)
            : base(contributionDbContext)
        {
        }
    }
}
