using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lofi_API.Models.Generated
{
    [Table("luser")]
    [Index("Uname", "Uemail", Name = "luser_uname_uemail_key", IsUnique = true)]
    public partial class Luser
    {
        public Luser()
        {
            Ltransactions = new HashSet<Ltransaction>();
        }

        [Key]
        [Column("userid")]
        public long Userid { get; set; }
        [Column("cookieid")]
        [StringLength(128)]
        public string? Cookieid { get; set; }
        [Column("uname", TypeName = "character varying")]
        public string Uname { get; set; } = null!;
        [Column("uemail", TypeName = "character varying")]
        public string Uemail { get; set; } = null!;
        [Column("upwd", TypeName = "character varying")]
        public string Upwd { get; set; } = null!;
        [Column("uwallet")]
        public long Uwallet { get; set; }
        [Column("utimelistened")]
        public double Utimelistened { get; set; }
        [Column("ubackgroundhex")]
        [StringLength(7)]
        public string Ubackgroundhex { get; set; } = null!;
        [Column("udatecreated", TypeName = "timestamp without time zone")]
        public DateTime Udatecreated { get; set; }
        [Column("ulastlogin", TypeName = "timestamp without time zone")]
        public DateTime Ulastlogin { get; set; }
        [Column("ulastnamechange", TypeName = "timestamp without time zone")]
        public DateTime? Ulastnamechange { get; set; }
        [Column("ulastemailchange", TypeName = "timestamp without time zone")]
        public DateTime? Ulastemailchange { get; set; }
        [Column("ulastpwdchange", TypeName = "timestamp without time zone")]
        public DateTime? Ulastpwdchange { get; set; }
        [Column("isonline")]
        public bool? Isonline { get; set; }
        [Column("isbanned")]
        public bool? Isbanned { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Ltransaction> Ltransactions { get; set; }
    }
}
