namespace MediaCatalog.Entities.Entities
{
    public class MediaFileHasTag
    {
        public int MediaFileId { get; set; }
        public MediaFile MediaFile { get; set; } = null!;

        public int TagId { get; set; }
        public Tag Tag { get; set; } = null!;
    }
}
