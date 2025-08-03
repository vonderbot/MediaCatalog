using FileCatalogBusinesLogic.Interfaces;
using FileCatalogViewModels.Models;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace FileCatalogBusinesLogic.Services
{
    public class AppSettingsService : ISettingsService
    {
        private string VideoSettingsDirectoryKey;
        private string AppSettings;
        private readonly IConfigurationRoot _configuration;

        public AppSettingsService(string videoSettingsDirectoryKey, string appSettings, IConfigurationRoot newConfisuration)
        {
            VideoSettingsDirectoryKey = videoSettingsDirectoryKey;
            AppSettings = appSettings;
            _configuration = newConfisuration;
        }

        public void ChangeDirectoryPath(string newPath)
        {
            var settings = new
            {
                VideoSettings = new FileSettingsViewModel { Directory = newPath }
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(settings, options);
            File.WriteAllText(AppSettings, json);
        }

        /*public FileSettingsViewModel GetVideoSettings()
        {
            return _configuration.GetSection("VideoSettings").Get<FileSettingsViewModel>();
        }*/
    }
}
