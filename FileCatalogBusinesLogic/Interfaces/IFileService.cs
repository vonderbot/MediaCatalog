namespace FileCatalogBusinesLogic.Interfaces
{
    public interface IFileService
    {
        public void DirectoryReshafle(string directoryName);

        public string GetDirectory();

        public string[] GetFileNames();

        public string GetFile(int index);

        public int GetFileIndex(string file);
    }
}
