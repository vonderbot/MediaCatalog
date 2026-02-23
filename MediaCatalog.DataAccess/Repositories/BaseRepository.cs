using MediaCatalog.DataAccess.Contexts;
using MediaCatalog.DataAccess.Interfaces;
using MediaCatalog.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediaCatalog.DataAccess.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        protected readonly MediaCatalogDbContext _dbContext;
        protected readonly DbSet<T> _table;

        protected BaseRepository(MediaCatalogDbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<T>();
        }

        public async Task Create(T entity)
        {
            await _table.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _table.FindAsync(id);

            if (entity is null)
            {
                throw new InvalidOperationException(
                    $"Entity of type {typeof(T).Name} with id {id} was not found.");
            }

            _table.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<int> GetCount()
        {
            return await _table.CountAsync();
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }
    }
}