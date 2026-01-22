using MediaCatalog.BusinessLogic.Interfaces;
using MediaCatalog.DataAccess.Interfaces;

namespace MediaCatalog.BusinessLogic.Services
{
    public class TagService: ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<string> GetNameById(int id)
        {
            var tag = await _tagRepository.GetById(id);
            return tag.Name;
        }
    }
}
