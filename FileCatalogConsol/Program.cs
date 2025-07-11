using System.Diagnostics;

namespace FileCatalogConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dirName = "C:\\Папка Богдана(изменённая)\\да\\Видео\\2D";
            var directory = new DirectoryInfo(dirName);
            var flag = true;
            var files = directory.GetFiles();
            if (Directory.Exists(dirName))
            {
                while (flag) {
                    Console.WriteLine("Enter the number of option you want to do:\n" +
                        "1 See all catalogs\n" +
                        "2 see all files\n" +
                        "3 play first file\n" +
                        "4 end the program");
                    var userInput = Console.ReadLine();
                    if (userInput == "1")
                    {
                        var dirs = directory.GetDirectories();
                        if (dirs.Length > 0)
                        {
                            Console.WriteLine("Подкаталоги:");
                            foreach (DirectoryInfo s in dirs)
                            {
                                Console.WriteLine(s);
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no directories.");
                        }
                    }
                    else if (userInput == "2")
                    {
                        if (files.Length > 0)
                        {
                            Console.WriteLine("Файлы:");
                            foreach (FileInfo s in files)
                            {
                                Console.WriteLine(s);
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no files.");
                        }
                    }
                    else if(userInput == "3")
                    {
                        if (files.Length > 0)
                        {
                            var firstFile = files[0];
                            Console.WriteLine(Convert.ToString(firstFile));
                            Process.Start(new ProcessStartInfo
                            {
                                FileName = Convert.ToString(firstFile),
                                UseShellExecute = true // Важно для открытия с привязкой по умолчанию
                            });
                        }
                        else
                        {
                            Console.WriteLine("There is no files.");
                        }
                    }
                    else if(userInput == "4")
                    {
                        flag = false;
                    }
                    else {
                        Console.WriteLine("Wrong number, try again.");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}