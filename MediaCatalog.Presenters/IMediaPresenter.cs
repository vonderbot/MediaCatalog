using MediaCatalog.Common;
using MediaCatalog.Entities.Entities;

namespace MediaCatalog.Presenters
{
    public interface IMediaPresenter
    {
        public Task<IEnumerable<FileInfo>> ApplyTagFilterAsync(IEnumerable<int> tagIds);
        public Task AssignTagToCurrentFileAsync(int tagId, string fileName);
        public Task RemoveTagFromCurrentFileAsync(int tagId, string fileName);
        public Task<IEnumerable<Tag>> GetAllTagsAsync();
        public Task AddNewTag(string newTag);
        public Task<bool> CheckFileRegistration(string fileName);
        public Task AddCurentFiletoDb(string fileName);
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
        public Task<IEnumerable<int>> GetTagIdsForFileAsync(string fileName);
    }
}
