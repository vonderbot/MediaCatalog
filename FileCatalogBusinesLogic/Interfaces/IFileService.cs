namespace FileCatalogBusinesLogic.Interfaces
{
    public interface IFileService
    {
        public void ChangeDirectory(string directoryName);

        public string GetDirectory();

        public string[] GetFileNames();

        public string GetFile(int index);
    }
}
