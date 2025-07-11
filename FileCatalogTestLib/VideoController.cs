namespace FileCatalogTestLib
{
    public class VideoController
    {
        static string dirName = "C:\\Папка Богдана(изменённая)\\да\\Видео\\2D";
        DirectoryInfo directory;
        FileInfo[] files;

        public VideoController()
        {
            directory = new DirectoryInfo(dirName);
            files = directory.GetFiles();
        }

        public string GetFirstFile()
        {
            if (files.Length > 0)
            {
                return files[0].FullName;
            }
            else
            {
                return "No files in directory";
            }
        }
    }
}