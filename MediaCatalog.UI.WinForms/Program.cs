using MediaCatalog.BusinessLogic.Services;
using MediaCatalog.DataAccess;
using MediaCatalog.DataAccess.Contexts;
using MediaCatalog.Presenters;
using MediaCatalog.UI.WinForms.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SQLitePCL;

namespace MediaCatalog.UI.WinForms
{
    internal static class Program
    {
        private const string VideoSettingsDirectoryKey = "VideoSettings:Directory";
        private const string SettingsFolderPath = "Settings/";
        private const string AppSettings = "appsettings.json";
        private const string UserSettingsFileName = "UserSettings.json";
        private const string UserSettingsFolderName = "MediaCatalogApp";

        [STAThread]
        private static void Main()
        {
            try
            {
                // Check for a configuration file
                var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SettingsFolderPath + AppSettings);
                if (!File.Exists(configFile))
                    throw new FileNotFoundException("Configuration file not found.", configFile);

                // Paths
                string appFolderPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                UserSettingsFolderName);

                Directory.CreateDirectory(appFolderPath);

                string userSettingsPath = Path.Combine(appFolderPath, UserSettingsFileName); if (!Directory.Exists(appFolderPath))
                    Directory.CreateDirectory(appFolderPath);
                if (!File.Exists(userSettingsPath))
                {
                    var originalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SettingsFolderPath + UserSettingsFileName);
                    if (File.Exists(originalPath))
                        File.Copy(originalPath, userSettingsPath);
                    else
                        File.WriteAllText(userSettingsPath, "{}"); // empty JSON
                }

                // Configuration
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile(SettingsFolderPath + AppSettings, optional: false, reloadOnChange: true)
                    .AddJsonFile(userSettingsPath, optional: false, reloadOnChange: true)
                    .Build();

                // Initialize database context
                var connectionString = configuration.GetConnectionString("DefaultConnection")
                       ?? "MediaCatalogDb.db";

                var dbPath = Path.Combine(appFolderPath, connectionString);

                var optionsBuilder = new DbContextOptionsBuilder<MediaCatalogDbContext>();
                optionsBuilder.UseSqlite($"Data Source={dbPath}");

                using (var dbContext = new MediaCatalogDbContext(optionsBuilder.Options))
                {
                    dbContext.Database.Migrate();
                }

                // Check for the video settings directory
                var section = configuration.GetSection(VideoSettingsDirectoryKey);
                if (!section.Exists() || string.IsNullOrWhiteSpace(section.Value))
                    throw new KeyNotFoundException(
                        $"There is a missing or empty setting in the configuration'{VideoSettingsDirectoryKey}'.");
                var videoDir = section.Value!;
                if (!Directory.Exists(videoDir))
                    throw new DirectoryNotFoundException(
                        $"The directory specified in the configuration was not found: {videoDir}");

                // DI container
                var services = new ServiceCollection();
                services.AddSingleton<IConfiguration>(configuration);
                services.SetInject(configuration, appFolderPath, userSettingsPath, VideoSettingsDirectoryKey);
                var serviceProvider = services.BuildServiceProvider();

                // Run UI
                ApplicationConfiguration.Initialize();
                var mainForm = serviceProvider.GetRequiredService<PlayerForm>();
                Application.Run(mainForm);
            }
            catch (FileNotFoundException ex)
            {
                MessageBoxHelper.ShowErrorBoxMessage(
                    $"{ex.Message}\n{ex.FileName}",
                    "Configuration file not found");
            }
            catch (KeyNotFoundException ex)
            {
                MessageBoxHelper.ShowErrorBoxMessage(
                    ex.Message,
                    "Settings not found");
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBoxHelper.ShowErrorBoxMessage(
                    ex.Message,
                    "Video directory not found");
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowErrorBoxMessage(
                    $"Unknown error:\n{ex.Message}",
                    "Error");
            }
        }
    }

    public static class MessageBoxHelper
    {
        public static void ShowErrorBoxMessage(string text, string caption) => ShowBoxMessage(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

        private static void ShowBoxMessage(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(
                    text,
                    caption,
                    buttons,
                    icon);
        }
    }
}
