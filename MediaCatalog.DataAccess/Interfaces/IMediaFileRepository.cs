using MediaCatalog.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCatalog.DataAccess.Interfaces
{
    public interface IMediaFileRepository : IBaseRepository<MediaFile>
    {
        public Task<MediaFile?> GetByNameAndFolder(string fileName, int folderId);
    }
}
