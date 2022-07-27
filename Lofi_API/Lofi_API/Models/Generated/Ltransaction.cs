using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lofi_API.Models.Generated
{
    [Table("ltransaction")]
    [Index("Itemid", "Userid", Name = "fk_transaction")]
    public partial class Ltransaction
    {
        [Key]
        [Column("transactionid")]
        public long Transactionid { get; set; }
        [Column("itemid")]
        public long Itemid { get; set; }
        [Column("userid")]
        public long Userid { get; set; }
        [Column("transactiondate", TypeName = "timestamp without time zone")]
        public DateTime Transactiondate { get; set; }

        [ForeignKey("Itemid")]
        [InverseProperty("Ltransactions")]
        public virtual Item Item { get; set; } = null!;
        [ForeignKey("Userid")]
        [InverseProperty("Ltransactions")]
        public virtual Luser User { get; set; } = null!;
    }
}
