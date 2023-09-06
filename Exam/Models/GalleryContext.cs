using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Exam.Models
{
    public partial class GalleryContext : DbContext
    {
        public GalleryContext()
        {
        }

        public GalleryContext(DbContextOptions<GalleryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Photo> Photos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-7NUBAMDH\\SQLEXPRESS;Initial Catalog=Gallery;Persist Security Info=True;User ID=sa;Password=1111");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photo>(entity =>
            {
                entity.HasKey(e => e.IdPhoto);

                entity.ToTable("Photo");

                entity.Property(e => e.IdPhoto).HasColumnName("ID_Photo");

                entity.Property(e => e.Url)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("URL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
