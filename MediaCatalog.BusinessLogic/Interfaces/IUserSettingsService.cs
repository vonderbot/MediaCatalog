namespace MediaCatalog.BusinessLogic.Interfaces
{
    public interface IUserSettingsService
    {
        //VideoSettings GetVideoSettings();

        public void ChangeDirectoryPath(string newPath);
    }
}
