using System;
using Microsoft.Extensions.Configuration;
using LibVLCSharp.Shared;
using FileCatalogTestLib;  // <-- ваше бібліотечне збірка

namespace FileCatalogInterface
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // 1) Створюємо IConfiguration, щоб читати appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // 2) Дістаємо шлях до теки відео
            var videoDir = config["VideoSettings:Directory"];

            // 3) Ініціалізація WinForms
            ApplicationConfiguration.Initialize();

            // 4) Створюємо VideoController із переданим шляхом
            var controller = new VideoController(videoDir);

            // 5) Передаємо controller у Form1 через DI-подібний підхід
            Application.Run(new Form1(controller));
        }
    }
}
