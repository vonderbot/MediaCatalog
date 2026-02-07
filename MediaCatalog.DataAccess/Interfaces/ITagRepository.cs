using MediaCatalog.Entities.Entities;

namespace MediaCatalog.DataAccess.Interfaces
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
        public Task<Tag?> GetByName(string tagName);
    }
}
