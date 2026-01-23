using System.ComponentModel.DataAnnotations.Schema;

namespace MediaCatalog.Entities.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; } = null!;

        [ForeignKey("TagType")]
        public int TagTypeId { get; set; }

        public TagType TagType { get; set; }

        public ICollection<MediaFileHasTag> MediaFileHasTags { get; set; } = null!;
    }
}
