namespace FileCatalogBusinesLogic.Interfaces
{
    internal interface IFileService
    {
        public string[] GetFileNames();

        public string GetFile(int index);
    }
}
