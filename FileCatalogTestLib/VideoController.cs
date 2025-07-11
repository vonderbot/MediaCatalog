namespace FileCatalogTestLib
{
    public class VideoController
    {
        private readonly string _dirName;
        private readonly FileInfo[] _files;

        public VideoController(string dirName)
        {
            _dirName = dirName;
            var directory = new DirectoryInfo(dirName);
            _files = directory.GetFiles();
        }

        public string GetFirstFile()
        {
            return _files.Length > 0 ? _files[0].FullName : "No files in directory";
        }
    }
}