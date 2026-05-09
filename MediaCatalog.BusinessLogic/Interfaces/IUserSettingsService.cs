namespace MediaCatalog.BusinessLogic.Interfaces
{
    public interface IUserSettingsService
    { public void ChangeDirectoryPath(string newPath);

        public void SaveLastOpenedFile(string fileName);

        public string? GetLastOpenedFile();
    }
}
