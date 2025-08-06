using FileCatalogBusinesLogic.Interfaces;
using Microsoft.VisualBasic;

namespace FileCatalogBusinesLogic.Services
{
    public class FileService : IFileService
    {
        private DirectoryInfo _directory;
        private FileInfo[] _files;

        public FileService(string directoryName)
        {
            _directory = new DirectoryInfo(directoryName);
            _files = _directory.GetFiles();
        }

        public void DirectoryReshafle(string directoryName)
        {
            if (Directory.Exists(directoryName) && directoryName != _directory.FullName)
            {
                _directory = new DirectoryInfo(directoryName);
            }
            _files = _directory.GetFiles();
        }

        public string GetDirectory()
        {
            return _directory.FullName;
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

        public FileInfo[] GetFiles()
        {
            return _files;
        }

        public int GetFileIndex(string file)
        {
            if (_files.Length > 0)
            {
                for (int i = 0; i < (_files.Length - 1); i++)
                {
                    if(_files[i].Name == file)
                    {
                        return i;
                    }
                }
                throw new Exception();
            }
            else
            {
                throw new Exception();
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