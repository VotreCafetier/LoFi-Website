using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Lofi_API.Models.Generated;

namespace Lofi_API.Data
{
    public partial class _dbContext : DbContext
    {
        public _dbContext()
        {
        }

        public _dbContext(DbContextOptions<_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ilocation> Ilocations { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Itype> Itypes { get; set; } = null!;
        public virtual DbSet<Ltransaction> Ltransactions { get; set; } = null!;
        public virtual DbSet<Luser> Lusers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Name=LofiDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Idatecreated).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Ilocation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Ilocationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("item_ilocationid_fkey");

                entity.HasOne(d => d.Itype)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Itypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("item_itypeid_fkey");
            });

            modelBuilder.Entity<Ltransaction>(entity =>
            {
                entity.HasKey(e => e.Transactionid)
                    .HasName("ltransaction_pkey");

                entity.Property(e => e.Transactiondate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Ltransactions)
                    .HasForeignKey(d => d.Itemid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ltransaction_itemid_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ltransactions)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ltransaction_userid_fkey");
            });

            modelBuilder.Entity<Luser>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("luser_pkey");

                entity.Property(e => e.Cookieid).IsFixedLength();

                entity.Property(e => e.Isbanned).HasDefaultValueSql("false");

                entity.Property(e => e.Isonline).HasDefaultValueSql("false");

                entity.Property(e => e.Ubackgroundhex).HasDefaultValueSql("'FFE6E6'::character varying");

                entity.Property(e => e.Udatecreated).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Ulastlogin).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
