using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TEST.Models
{
    public partial class TestContext : DbContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TestAuto> TestAutos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestAuto>(entity =>
            {
                entity.HasKey(e => e.IdTestAuto);

                entity.ToTable("TEST_AUTO");

                entity.Property(e => e.IdTestAuto).HasColumnName("ID_TEST_AUTO");

                entity.Property(e => e.Milleage)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("MILLEAGE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
