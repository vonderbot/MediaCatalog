namespace MediaCatalog.DataAccess.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task Create(T entity);

        Task Delete(int id);

        Task<IEnumerable<T>> GetAll();

        Task<T?> GetById(int id);

        Task<int> GetCount();

        Task Save();

        void Update(T entity);
    }
}
