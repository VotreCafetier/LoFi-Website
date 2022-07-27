using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lofi_API.Models.Generated
{
    [Table("itype")]
    [Index("Itypename", Name = "itype_itypename_key", IsUnique = true)]
    public partial class Itype
    {
        public Itype()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        [Column("itypeid")]
        public long Itypeid { get; set; }
        [Column("itypename", TypeName = "character varying")]
        public string Itypename { get; set; } = null!;

        [InverseProperty("Itype")]
        public virtual ICollection<Item> Items { get; set; }
    }
}
