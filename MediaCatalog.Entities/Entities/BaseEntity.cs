using System.ComponentModel.DataAnnotations;

namespace MediaCatalog.Entities.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
