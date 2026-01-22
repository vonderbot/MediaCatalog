using MediaCatalog.DataAccess.Contexts;
using MediaCatalog.DataAccess.Interfaces;
using MediaCatalog.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCatalog.DataAccess.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly MediaCatalogDbContext ContributionDbContext;
        protected readonly DbSet<T> Table;

        protected BaseRepository(MediaCatalogDbContext contributionDbContext)
        {
            ContributionDbContext = contributionDbContext;
            Table = ContributionDbContext.Set<T>();
        }

        public async Task<int> GetNumberOfTableRecords()
        {
            return await Table.CountAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Table.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task Create(T entity)
        {
            await Table.AddAsync(entity);
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }

        public async Task Delete(int id)
        {
            var existing = await Table.FindAsync(id);

            if (existing != null)
            {
                Table.Remove(existing);
            }
            else
            {
                throw new Exception("Unable to delete, id does not exist.");
            }
        }

        public async Task Save()
        {
            await ContributionDbContext.SaveChangesAsync();
        }
    }
}
