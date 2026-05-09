using MediaCatalog.Entities.Entities;

namespace MediaCatalog.DataAccess.Interfaces
{
    public interface IFolderRepository : IBaseRepository<Folder>
    {
        Task<Folder?> GetByPath(string path);
    }
}
