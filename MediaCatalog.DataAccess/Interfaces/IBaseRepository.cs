using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCatalog.DataAccess.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<int> GetNumberOfTableRecords();

        public Task<IEnumerable<T>> GetAll();

        public Task<T> GetById(int id);

        public Task Create(T entity);

        public void Update(T entity);

        public Task Delete(int id);

        public Task Save();
    }
}
