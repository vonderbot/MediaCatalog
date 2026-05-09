using MediaCatalog.BusinessLogic.Interfaces;
using MediaCatalog.DataAccess.Interfaces;
using MediaCatalog.Entities.Entities;

namespace MediaCatalog.BusinessLogic.Services
{
    public class TagService : ITagService
    {
        private readonly IMediaFileHasTagRepository _mediaFileHasTagRepository;
        private readonly ITagRepository _tagRepository;

        public TagService(
            ITagRepository tagRepository,
            IMediaFileHasTagRepository mediaFileHasTagRepository)
        {
            _tagRepository = tagRepository
                ?? throw new ArgumentNullException(nameof(tagRepository));
            _mediaFileHasTagRepository = mediaFileHasTagRepository
                ?? throw new ArgumentNullException(nameof(mediaFileHasTagRepository));
        }

        public async Task AssignTagToFileAsync(int tagId, int mediaFileId)
        {
            var assignedTagIds =
                await _mediaFileHasTagRepository.GetTagIdsByMediaFileIdAsync(mediaFileId);

            if (assignedTagIds.Contains(tagId))
                return;

            await _mediaFileHasTagRepository.CreateAsync(new MediaFileHasTag
            {
                MediaFileId = mediaFileId,
                TagId = tagId
            });

            await _mediaFileHasTagRepository.SaveAsync();
        }

        public async Task RemoveTagFromFileAsync(int tagId, int mediaFileId)
        {
            await _mediaFileHasTagRepository.DeleteAsync(mediaFileId, tagId);
            await _mediaFileHasTagRepository.SaveAsync();
        }

        public async Task CreateTagAsync(string tagName)
        {
            if (string.IsNullOrWhiteSpace(tagName))
                throw new ArgumentException("Tag name cannot be empty.", nameof(tagName));

            if (await ExistsAsync(tagName))
                return;

            await _tagRepository.Create(new Tag
            {
                Name = tagName.Trim()
            });

            await _tagRepository.Save();
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await _tagRepository.GetAll();
        }

        public async Task<string> GetNameByIdAsync(int tagId)
        {
            var tag = await _tagRepository.GetById(tagId)
                ?? throw new InvalidOperationException($"Tag with id {tagId} not found.");

            return tag.Name;
        }

        public async Task<IReadOnlyCollection<int>> GetTagIdsByMediaFileIdAsync(int mediaFileId)
        {
            return await _mediaFileHasTagRepository
                .GetTagIdsByMediaFileIdAsync(mediaFileId);
        }

        public async Task<bool> ExistsAsync(string tagName)
        {
            if (string.IsNullOrWhiteSpace(tagName))
                return false;

            return await _tagRepository.GetByNameAsync(tagName) != null;
        }
    }
}
