namespace MediaCatalog.BusinessLogic.Interfaces
{
    public interface ITagService
    {
        public Task<string> GetNameById(int id);
    }
}
