using MediaCatalog.BusinessLogic.Interfaces;
using MediaCatalog.DataAccess.Interfaces;
using MediaCatalog.Entities.Entities;

namespace MediaCatalog.BusinessLogic.Services
{
    public class TagService: ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMediaFileHasTagRepository _mediaFileHasTagRepository;

        public TagService(ITagRepository tagRepository, IMediaFileHasTagRepository mediaFileHasTagRepository)
        {
            _tagRepository = tagRepository;
            _mediaFileHasTagRepository = mediaFileHasTagRepository;
        }

        public async Task AssignTagToFile(int tagId, int fileId)
        {
            await _mediaFileHasTagRepository.Create(new MediaFileHasTag() { MediaFileId = fileId, TagId = tagId });
            await _mediaFileHasTagRepository.Save();
        }

        public async Task RemoveTagFromFile(int tagId, int fileId)
        {
            await _mediaFileHasTagRepository.DeleteAsync(fileId, tagId);
            await _mediaFileHasTagRepository.Save();
        }

        public async Task<IEnumerable<Tag>> GetAllTags()
        {
            return await _tagRepository.GetAll();
        }

        public async Task CreateTagAsync(string tagName)
        {
            await _tagRepository.Create(new Entities.Entities.Tag() { Name = tagName });
            await _tagRepository.Save();
        }

        public async Task<bool> TagExists(string tagName)
        {
            var tag = await _tagRepository.GetByName(tagName);
            if (tag == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<string> GetNameById(int id)
        {
            var tag = await _tagRepository.GetById(id);
            return tag.Name;
        }

        public async Task<IEnumerable<int>> GetAssignTagsId(int fileId)
        {
            return await _mediaFileHasTagRepository.GetTagIdsByMediaFileIdAsync(fileId);
        }
    }
}
