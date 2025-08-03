using FileCatalogBusinesLogic.Interfaces;

namespace FileCatalogBusinesLogic.Services
{
    public class FileService : IFileService
    {
        private readonly DirectoryInfo _directory;
        private readonly FileInfo[] _files;

        public FileService(string directoryName)
        {
            _directory = new DirectoryInfo(directoryName);
            _files = _directory.GetFiles();
        }

        public string[] GetFileNames()
        {
            if (_files.Length > 0)
            {
                string[] fileList = new string[_files.Count() - 1];
                for (int i = 0; i < fileList.Length; i++)
                {
                    fileList[i] = _files[i].Name;
                }
                return fileList;
            }
            else
            {
                string[] fileList = ["No files in directory"];
                return fileList;
            }
        }

        public string GetFile(int index)
        {
            if (index >= 0 && index < _files.Count())
            {
                return _files[index].FullName;
            }
            else
            {
                return "Error";
            }
        }
    }
}