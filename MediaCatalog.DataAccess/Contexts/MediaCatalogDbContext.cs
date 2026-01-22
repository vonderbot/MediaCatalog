using MediaCatalog.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediaCatalog.DataAccess.Contexts
{
    public sealed class MediaCatalogDbContext : DbContext
    {
        public DbSet<Tag> Tags { get; set; }

        public MediaCatalogDbContext(DbContextOptions<MediaCatalogDbContext> options)
        : base(options) {
            //Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=MediaCatalog.db");
        //}

        //public MediaCatalogDbContext(){
        //    Database.EnsureCreated();
        //}
    }
}