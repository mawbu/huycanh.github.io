using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace De02
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=model1")
        {
        }

        public static IEnumerable<object> SanPham { get; internal set; }
        public virtual DbSet<LoaiSP> LoaiSPs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiSP>()
                .Property(e => e.MaLoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LoaiSP>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.LoaiSP)
                .HasForeignKey(e => e.MaLoai);

            modelBuilder.Entity<LoaiSP>()
                .HasMany(e => e.SanPhams1)
                .WithOptional(e => e.LoaiSP1)
                .HasForeignKey(e => e.MaLoai);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaSP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaLoai)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
