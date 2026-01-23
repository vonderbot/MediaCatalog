using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCatalog.Entities.Entities
{
    public class MediaFile: BaseEntity
    {
        public string Name { get; set; } = null!;

        [ForeignKey("Folder")]
        public int FolderId { get; set; }

        public Folder Folder { get; set; } = null!;

        public ICollection<MediaFileHasTag> MediaFileHasTags { get; set; } = null!;
    }
}
