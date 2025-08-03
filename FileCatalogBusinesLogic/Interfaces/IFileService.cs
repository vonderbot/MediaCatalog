namespace FileCatalogBusinesLogic.Interfaces
{
    public interface IFileService
    {
        public string[] GetFileNames();

        public string GetFile(int index);
    }
}
