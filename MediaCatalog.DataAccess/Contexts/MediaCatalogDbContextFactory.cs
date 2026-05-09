using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MediaCatalog.DataAccess.Contexts
{
    internal class MediaCatalogDbContextFactory : IDesignTimeDbContextFactory<MediaCatalogDbContext>
    {
        public MediaCatalogDbContext CreateDbContext(string[] args)
        {
            // 1. Определяем базовый путь
            var basePath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Settings");

            // 2. Загружаем конфигурацию (как EF ожидает)
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            // 3. Берём строку подключения
            var connectionString =
                configuration.GetConnectionString("DesignTimeConnection")
                ?? configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Connection string not found.");

            // 4. НЕ используем %AppData% — только dev путь
            var optionsBuilder = new DbContextOptionsBuilder<MediaCatalogDbContext>();
            optionsBuilder.UseSqlite($"Data Source={connectionString}");

            return new MediaCatalogDbContext(optionsBuilder.Options);
        }
    }
}
