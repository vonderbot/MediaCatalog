namespace MediaCatalog.BusinessLogic.Interfaces
{
    public interface IFileSystemService
    {
        int CountFiles();

        string GetDirectoryPath();

        FileInfo GetFileByIndex(int index);

        FileInfo[] GetFiles();

        string[] GetFileNames();

        int GetFileIndexByName(string fileName);

        void RefreshDirectory(string directoryPath);

        //void RenameFile(FileInfo file, string newName);
    }
}
