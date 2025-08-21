using MediaCatalog.BusinessLogic.Interfaces;

namespace MediaCatalog.BusinessLogic.Services
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

        public void SetNewFileSequence(FileInfo[] newFiles)
        {
            if (CompareFileList(newFiles))
            {

            }   
        }

        public bool CompareFileList(FileInfo[] newFiles)
        {
            if (_files.Length != newFiles.Length)
            {
                return false;
            }

            int[] arr1Copy = (int[])_files.Clone();
            int[] arr2Copy = (int[])newFiles.Clone();

            Array.Sort(arr1Copy);
            Array.Sort(arr2Copy);

            return Enumerable.SequenceEqual(arr1Copy, arr2Copy);
        }

        public void RenameFile(FileInfo file, string newName)
        {
            var directory = GetDirectory();
            var newPath = Path.Combine(directory, newName);
            File.Move(file.FullName, newPath);
            DirectoryReshafle(directory);
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

        public int CountFiles()
        {
            return _files.Count();
        }

        public int GetFileIndex(string file)
        {
            if (_files.Length > 0)
            {
                for (int i = 0; i < _files.Length - 1; i++)
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