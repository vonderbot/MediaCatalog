using MediaCatalog.Entities.Entities;

namespace MediaCatalog.BusinessLogic.Interfaces
{
    public interface ITagService
    {
        public Task AssignTagToFile(int tagId, int FileId);
        public Task<IEnumerable<Tag>> GetAllTags();
        public Task CreateTagAsync(string tagName);
        public Task<bool> TagExists(string tagName);
        public Task<string> GetNameById(int id);
        public Task RemoveTagFromFile(int tagId, int fileId);
        public Task<IEnumerable<int>> GetAssignTagsId(int fileId);
    }
}
