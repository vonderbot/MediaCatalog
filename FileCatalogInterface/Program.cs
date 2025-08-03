using Microsoft.Extensions.Configuration;
using FileCatalogBusinesLogic.Services;

namespace FileCatalogInterface
{
    internal static class Program
    {
        private const string VideoSettingsDirectoryKey = "VideoSettings:Directory";
        private const string AppSettings = "appsettings.json";

        [STAThread]
        private static void Main()
        {
            try
            {
                // 1) Check for a configuration file
                var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppSettings);
                if (!File.Exists(configFile))
                    throw new FileNotFoundException("Configuration file not found.", configFile);

                // 2) Upload the configuration
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile(AppSettings, optional: false, reloadOnChange: true)
                    .Build();

                // 3) Check for the key
                var section = configuration.GetSection(VideoSettingsDirectoryKey);
                if (!section.Exists() || string.IsNullOrWhiteSpace(section.Value))
                    throw new KeyNotFoundException(
                        $"There is a missing or empty setting in the configuration'{VideoSettingsDirectoryKey}'.");

                // 4) Check that the directory exists
                var videoDir = section.Value!;
                if (!Directory.Exists(videoDir))
                    throw new DirectoryNotFoundException(
                        $"The directory specified in the configuration was not found: {videoDir}");

                // 5) Initialize WinForms
                ApplicationConfiguration.Initialize();

                // 6) Run the form
                var controller = new FileService(videoDir);
                Application.Run(new PlayerForm(controller));
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
