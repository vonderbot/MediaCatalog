using MediaCatalog.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCatalog.DataAccess.Interfaces
{
    public interface IFolderRepository : IBaseRepository<Folder>
    {
        public Task<Folder?> GetByPath(string path);
    }
}
