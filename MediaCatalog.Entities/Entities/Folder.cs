namespace MediaCatalog.Entities.Entities
{
    public class Folder: BaseEntity
    {
        public string Path { get; set; } = null!;

        public ICollection<MediaFile> Files { get; set; } = null!;
    }
}
