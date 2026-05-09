using MediaCatalog.Entities.Entities;

namespace MediaCatalog.BusinessLogic.Interfaces
{
    public interface ITagService
    {
        Task AssignTagToFileAsync(int tagId, int mediaFileId);

        Task RemoveTagFromFileAsync(int tagId, int mediaFileId);

        Task CreateTagAsync(string tagName);

        Task<IEnumerable<Tag>> GetAllAsync();

        Task<string> GetNameByIdAsync(int tagId);

        Task<IReadOnlyCollection<int>> GetTagIdsByMediaFileIdAsync(int mediaFileId);

        Task<bool> ExistsAsync(string tagName);
    }
}