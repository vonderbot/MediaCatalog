using MediaCatalog.BusinessLogic.Interfaces;
using MediaCatalog.BusinessLogic.Services;
using MediaCatalog.DataAccess.Contexts;
using MediaCatalog.DataAccess.Interfaces;
using MediaCatalog.DataAccess.Repositories;
using MediaCatalog.Presenters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediaCatalog.UI.WinForms.Extensions
{
    public static class ServiceCollectionInjectExtension
    {
        public static IServiceCollection SetInject(
            this IServiceCollection services, 
            IConfiguration configuration,
            string appFolder,
            string userSettingsPath,
            string VideoSettingsDirectoryKey)
        {
            // ---------- DbContext ----------
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                                   ?? "MediaCatalogDb.db";

            var dbPath = Path.Combine(appFolder, connectionString);

            services.AddDbContext<MediaCatalogDbContext>(options =>
                options.UseSqlite($"Data Source={dbPath}")
            );

            // ---------- Repositories ----------
            services.AddScoped<ITagRepository, TagRepository>();

            // ---------- Services ----------
            services.AddTransient<IUserSettingsService>(
                _ => new UserSettingsService(userSettingsPath));

            services.AddTransient<IFileService>(provider =>
            {
                var config = provider.GetRequiredService<IConfiguration>();
                var videoDir = config[VideoSettingsDirectoryKey]!;
                return new FileService(videoDir);
            });

            services.AddScoped<ITagService, TagService>();

            // ---------- Presenters ----------
            services.AddTransient<IMediaPresenter, MediaPresenter>();

            // ---------- Forms ----------
            services.AddTransient<PlayerForm>();

            return services;
        }
    }
}
