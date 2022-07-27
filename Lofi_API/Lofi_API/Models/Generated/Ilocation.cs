using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lofi_API.Models.Generated
{
    [Table("ilocation")]
    [Index("Ilocationname", Name = "ilocation_ilocationname_key", IsUnique = true)]
    public partial class Ilocation
    {
        public Ilocation()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        [Column("ilocationid")]
        public long Ilocationid { get; set; }
        [Column("ilocationname", TypeName = "character varying")]
        public string Ilocationname { get; set; } = null!;

        [InverseProperty("Ilocation")]
        public virtual ICollection<Item> Items { get; set; }
    }
}
