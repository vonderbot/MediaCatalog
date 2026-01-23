namespace MediaCatalog.Entities.Entities
{
    public class TagType : BaseEntity
    {
        public string Name { get; set; } = null!;

        public ICollection<Tag> Tags { get; set; } = null!;
    }
}
