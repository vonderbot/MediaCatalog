namespace MediaCatalog.BusinessLogic.Interfaces
{
    public interface IFileService
    {
        public void DirectoryReshafle(string directoryName);

        public int CountFiles();

        public void RenameFile(FileInfo file, string newName);

        public FileInfo[] GetFiles();

        public string GetDirectory();

        public string[] GetFileNames();

        public string GetFile(int index);

        public int GetFileIndex(string file);
    }
}
