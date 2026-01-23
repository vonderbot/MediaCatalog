using MediaCatalog.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediaCatalog.DataAccess.Contexts
{
    public sealed class MediaCatalogDbContext : DbContext
    {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagType> TagTypes { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<MediaFile> Files { get; set; }
        public DbSet<MediaFileHasTag> MediaFileHasTags { get; set; }

        public MediaCatalogDbContext(DbContextOptions<MediaCatalogDbContext> options)
        : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MediaFileHasTag>()
                .HasKey(x => new { x.MediaFileId, x.TagId });

            modelBuilder.Entity<MediaFileHasTag>()
                .HasOne(x => x.MediaFile)
                .WithMany(f => f.MediaFileHasTags)
                .HasForeignKey(x => x.MediaFileId);

            modelBuilder.Entity<MediaFileHasTag>()
                .HasOne(x => x.Tag)
                .WithMany(t => t.MediaFileHasTags)
                .HasForeignKey(x => x.TagId);
        }
    }
}