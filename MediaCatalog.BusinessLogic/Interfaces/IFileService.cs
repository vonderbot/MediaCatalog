namespace MediaCatalog.BusinessLogic.Interfaces
{
    public interface IFileService
    {
        public Task<FileInfo[]> GetFilesByTagFilterAsync(IEnumerable<int> tagIds);

        public Task<int> CurrentFileId(int index);

        public Task<bool> IsFileRegistered(int index);

        public Task AddFileToDb(int index);

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
