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
                // 1) ���������� �������� ����� �����������
                var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppSettings);
                if (!File.Exists(configFile))
                    throw new FileNotFoundException("���� ����������� �� ��������.", configFile);

                // 2) ����������� �����������
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile(AppSettings, optional: false, reloadOnChange: true)
                    .Build();

                // 3) ���������� �������� �����
                var section = configuration.GetSection(VideoSettingsDirectoryKey);
                if (!section.Exists() || string.IsNullOrWhiteSpace(section.Value))
                    throw new KeyNotFoundException(
                        $"� ����������� ������ ��� ������ ������������ '{VideoSettingsDirectoryKey}'.");

                // 4) ����������, �� ��������� ����
                var videoDir = section.Value!;
                if (!Directory.Exists(videoDir))
                    throw new DirectoryNotFoundException(
                        $"������� � ����������� ��������� �� ��������: {videoDir}");

                // 5) ���������� WinForms
                ApplicationConfiguration.Initialize();

                // 6) ��������� �����
                var controller = new VideoController(videoDir);
                Application.Run(new Form1(controller));
            }
            catch (FileNotFoundException ex)
            {
                MessageBoxHelper.ShowErrorBoxMessage(
                    $"{ex.Message}\n{ex.FileName}",
                    "�������������� ���� �� ��������");
            }
            catch (KeyNotFoundException ex)
            {
                MessageBoxHelper.ShowErrorBoxMessage(
                    ex.Message,
                    "������������ �� ��������");
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBoxHelper.ShowErrorBoxMessage(
                    ex.Message,
                    "��������� � ���� �� ��������");
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowErrorBoxMessage(
                    $"������� �������:\n{ex.Message}", 
                    "�������");
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
