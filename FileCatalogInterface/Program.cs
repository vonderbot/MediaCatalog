using Microsoft.Extensions.Configuration;
using FileCatalogTestLib;

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
                // 1) Перевіряємо наявність файлу конфігурації
                var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppSettings);
                if (!File.Exists(configFile))
                    throw new FileNotFoundException("Файл конфігурації не знайдено.", configFile);

                // 2) Завантажуємо конфігурацію
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile(AppSettings, optional: false, reloadOnChange: true)
                    .Build();

                // 3) Перевіряємо наявність ключа
                var section = configuration.GetSection(VideoSettingsDirectoryKey);
                if (!section.Exists() || string.IsNullOrWhiteSpace(section.Value))
                    throw new KeyNotFoundException(
                        $"У конфігурації відсутнє або порожнє налаштування '{VideoSettingsDirectoryKey}'.");

                // 4) Перевіряємо, що директорія існує
                var videoDir = section.Value!;
                if (!Directory.Exists(videoDir))
                    throw new DirectoryNotFoundException(
                        $"Вказана в конфігурації директорія не знайдена: {videoDir}");

                // 5) Ініціалізуємо WinForms та LibVLCSharp
                ApplicationConfiguration.Initialize();

                // 6) Запускаємо форму
                var controller = new VideoController(videoDir);
                Application.Run(new Form1(controller));
            }
            catch (FileNotFoundException ex)
            {
                MessageBoxHelper.ShowErrorBoxMessage(
                    $"{ex.Message}\n{ex.FileName}",
                    "Конфігураційний файл не знайдено");
            }
            catch (KeyNotFoundException ex)
            {
                MessageBoxHelper.ShowErrorBoxMessage(
                    ex.Message,
                    "Налаштування не знайдено");
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBoxHelper.ShowErrorBoxMessage(
                    ex.Message,
                    "Директорію з відео не знайдено");
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowErrorBoxMessage(
                    $"Невідома помилка:\n{ex.Message}", 
                    "Помилка");
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
