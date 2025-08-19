using MediaCatalog.BusinessLogic.Interfaces;
using System.Text.Json;

namespace MediaCatalog.BusinessLogic.Services
{
    public class UserSettingsService : IUserSettingsService
    {
        private readonly string UserSettings;

        public UserSettingsService(string userSettings)
        {
            UserSettings = userSettings;
        }

        public void ChangeDirectoryPath(string newPath)
        {
            var settings = new
            {
                VideoSettings = new
                {
                    Directory = newPath
                }
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(settings, options);
            File.WriteAllText(UserSettings, json);
        }
    }
}
