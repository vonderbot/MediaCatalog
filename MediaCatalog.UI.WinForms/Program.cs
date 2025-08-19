using Microsoft.Extensions.Configuration;
using MediaCatalog.BusinessLogic.Services;

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

                // Check for a user configuration file
                string appFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    UserSettingsFolderName);
                string settingsPath = Path.Combine(appFolder, UserSettingsFileName);
                if (!Directory.Exists(appFolder))
                    Directory.CreateDirectory(appFolder);
                if (!File.Exists(settingsPath))
                {
                    var originalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SettingsFolderPath + UserSettingsFileName);
                    if (File.Exists(originalPath))
                        File.Copy(originalPath, settingsPath);
                    else
                        File.WriteAllText(settingsPath, "{}"); // empty JSON
                }

                // Upload the configuration
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile(SettingsFolderPath + AppSettings, optional: false, reloadOnChange: true)
                    .AddJsonFile(settingsPath, optional: false, reloadOnChange: true)
                    .Build();

                // Check for the key
                var section = configuration.GetSection(VideoSettingsDirectoryKey);
                if (!section.Exists() || string.IsNullOrWhiteSpace(section.Value))
                    throw new KeyNotFoundException(
                        $"There is a missing or empty setting in the configuration'{VideoSettingsDirectoryKey}'.");

                // Check that the directory exists
                var videoDir = section.Value!;
                if (!Directory.Exists(videoDir))
                    throw new DirectoryNotFoundException(
                        $"The directory specified in the configuration was not found: {videoDir}");

                // Initialize WinForms
                ApplicationConfiguration.Initialize();

                // Run the form
                var controller = new FileService(videoDir);
                var settingService = new UserSettingsService(settingsPath);
                Application.Run(new PlayerForm(controller, settingService));
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
