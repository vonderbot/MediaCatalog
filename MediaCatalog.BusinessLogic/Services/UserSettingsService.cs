using MediaCatalog.BusinessLogic.Dtos;
using MediaCatalog.BusinessLogic.Interfaces;
using System.Text.Json;

namespace MediaCatalog.BusinessLogic.Services
{
    public class UserSettingsService : IUserSettingsService
    {
        private readonly string _settingsPath;

        public UserSettingsService(string settingsPath)
        {
            _settingsPath = settingsPath;
        }

        public void ChangeDirectoryPath(string newPath)
        {
            var settings = LoadSettings();
            settings.VideoSettings.Directory = newPath;
            SaveSettings(settings);
        }

        public void SaveLastOpenedFile(string fileName)
        {
            var settings = LoadSettings();
            settings.VideoSettings.LastOpenedFileName = fileName;
            SaveSettings(settings);
        }

        public string? GetLastOpenedFile()
        {
            var settings = LoadSettings();
            return settings.VideoSettings.LastOpenedFileName;
        }

        //public string? GetDirectoryPath()
        //{
        //    var settings = LoadSettings();
        //    return settings.VideoSettings.Directory;
        //}

        private UserSettingsDto LoadSettings()
        {
            if (!File.Exists(_settingsPath))
                return new UserSettingsDto();

            var json = File.ReadAllText(_settingsPath);
            return JsonSerializer.Deserialize<UserSettingsDto>(json)
                   ?? new UserSettingsDto();
        }

        private void SaveSettings(UserSettingsDto settings)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(settings, options);
            File.WriteAllText(_settingsPath, json);
        }
    }
}
