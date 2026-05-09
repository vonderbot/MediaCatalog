using MediaCatalog.BusinessLogic.Interfaces;

namespace MediaCatalog.BusinessLogic.Services
{
    public class FileSystemService : IFileSystemService
    {
        private DirectoryInfo _directory;
        private FileInfo[] _files;

        public FileSystemService(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                throw new DirectoryNotFoundException(directoryPath);

            _directory = new DirectoryInfo(directoryPath);
            _files = _directory.GetFiles();
        }

        public int CountFiles()
        {
            return _files.Length;
        }

        public string GetDirectoryPath()
        {
            return _directory.FullName;
        }

        public FileInfo GetFileByIndex(int index)
        {
            if (index < 0 || index >= _files.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            return _files[index];
        }

        public FileInfo[] GetFiles()
        {
            return _files;
        }

        public string[] GetFileNames()
        {
            return _files
                .Select(f => f.Name)
                .ToArray();
        }

        public int GetFileIndexByName(string fileName)
        {
            for (int i = 0; i < _files.Length; i++)
            {
                if (string.Equals(_files[i].Name, fileName, StringComparison.OrdinalIgnoreCase))
                    return i;
            }

            throw new FileNotFoundException($"File '{fileName}' not found in directory '{_directory.FullName}'.");
        }

        public void RefreshDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                throw new DirectoryNotFoundException(directoryPath);

            _directory = new DirectoryInfo(directoryPath);
            _files = _directory.GetFiles();
        }

        //public void RenameFile(FileInfo file, string newName)
        //{
        //    if (file == null)
        //        throw new ArgumentNullException(nameof(file));

        //    var newPath = Path.Combine(_directory.FullName, newName);
        //    File.Move(file.FullName, newPath);

        //    RefreshDirectory(_directory.FullName);
        //}
    }
}