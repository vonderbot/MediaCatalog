namespace FileCatalogTestLib
{
    public class VideoController
    {
        private readonly string _directoryName;
        DirectoryInfo Directory;
        private readonly FileInfo[] _files;

        public VideoController(string directoryName)
        {
            _directoryName = directoryName;
            Directory = new DirectoryInfo(_directoryName);
            _files = Directory.GetFiles();
        }

        public string GetFirstFile()
        {
            if (_files.Length > 0)
            {
                return _files[0].FullName;
            }
            else
            {
                return "No files in directory";
            }
        }
    }
}