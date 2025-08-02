using System;

namespace FileCatalogTestLib
{
    public class VideoController
    {
        private readonly string _directoryName;
        DirectoryInfo Directory;
        private readonly FileInfo[] _files;
        private int _currentIndex;

        public VideoController(string directoryName)
        {
            _directoryName = directoryName;
            Directory = new DirectoryInfo(_directoryName);
            _files = Directory.GetFiles();
            _currentIndex = 0;
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

        public string GetFile(int indexChange)
        {
            if (_currentIndex + indexChange >= 0 && _currentIndex + indexChange < _files.Count())
            {
                _currentIndex = _currentIndex + indexChange;
                return _files[_currentIndex].FullName;
            }
            else if(_currentIndex + indexChange < 0)
            {
                _currentIndex = _files.Count() + _currentIndex + indexChange;
                return _files[_currentIndex].FullName;
            }
            else if (_currentIndex + indexChange >= _files.Count())
            {
                _currentIndex = _currentIndex + indexChange - _files.Count();
                return _files[_currentIndex].FullName;
            }
            else
            {
                return "Error";
            }
        }
    }
}