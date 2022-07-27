using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lofi_API.Models.Generated
{
    [Table("item")]
    [Index("Ilocationid", "Itypeid", Name = "fk_item")]
    [Index("Iname", Name = "item_iname_key", IsUnique = true)]
    public partial class Item
    {
        public Item()
        {
            Ltransactions = new HashSet<Ltransaction>();
        }

        [Key]
        [Column("itemid")]
        public long Itemid { get; set; }
        [Column("iname", TypeName = "character varying")]
        public string Iname { get; set; } = null!;
        [Column("iprice")]
        public long Iprice { get; set; }
        [Column("idescription")]
        public string? Idescription { get; set; }
        [Column("idatecreated", TypeName = "timestamp without time zone")]
        public DateTime Idatecreated { get; set; }
        [Column("idiscount")]
        public short Idiscount { get; set; }
        [Column("isizex")]
        public short Isizex { get; set; }
        [Column("isizey")]
        public short Isizey { get; set; }
        [Column("irotation")]
        public short Irotation { get; set; }
        [Column("iposition")]
        public short? Iposition { get; set; }
        [Column("iimage", TypeName = "character varying")]
        public string Iimage { get; set; } = null!;
        [Column("ilocationid")]
        public long Ilocationid { get; set; }
        [Column("itypeid")]
        public long Itypeid { get; set; }

        [ForeignKey("Ilocationid")]
        [InverseProperty("Items")]
        public virtual Ilocation Ilocation { get; set; } = null!;
        [ForeignKey("Itypeid")]
        [InverseProperty("Items")]
        public virtual Itype Itype { get; set; } = null!;
        [InverseProperty("Item")]
        public virtual ICollection<Ltransaction> Ltransactions { get; set; }
    }
}
