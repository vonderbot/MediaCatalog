using MediaCatalog.Common;

namespace MediaCatalog.Presenters
{
    public interface IMediaPresenter
    {
        public Task<String> GetTagName(int id);
        public IEnumerable<FileInfo> GetFilesInfo();
        public void NewSort(int columnNumber);
        public CatalogSortOrder GetSortOrder();
        public void RenameFile(FileInfo file, string newName);
        public void ChangeDirectory(string newPath);
        public string GetCurrentFileDirectory();
        public void ChangeCurrentIndex(int newIndex);
        public void MoveCurrentIndex(int MoveStep);
        public int GetCurrentIndex();
    }
}
