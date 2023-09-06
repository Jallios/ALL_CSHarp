using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Perekyp.Models
{
    public partial class PEREKYPContext : DbContext
    {
        public PEREKYPContext()
        {
        }

        public PEREKYPContext(DbContextOptions<PEREKYPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auto> Autos { get; set; } = null!;
        public virtual DbSet<Buyer> Buyers { get; set; } = null!;
        public virtual DbSet<HistoryAuto> HistoryAutos { get; set; } = null!;
        public virtual DbSet<PurchaseStatus> PurchaseStatuses { get; set; } = null!;
        public virtual DbSet<Salesman> Salesmen { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-7NUBAMDH\\SQLEXPRESS;Initial Catalog=PEREKYP;Persist Security Info=True;User ID=sa;Password=1111");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auto>(entity =>
            {
                entity.HasKey(e => e.IdAuto);

                entity.ToTable("AUTO");

                entity.Property(e => e.IdAuto)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_AUTO");

                entity.Property(e => e.BodyType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BODY_TYPE");

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BRAND");

                entity.Property(e => e.DriveUnit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DRIVE_UNIT");

                entity.Property(e => e.EnginePower).HasColumnName("ENGINE_POWER");

                entity.Property(e => e.IdHistoryAuto).HasColumnName("ID_HISTORY_AUTO");

                entity.Property(e => e.Kpp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("KPP");

                entity.Property(e => e.WeightKg).HasColumnName("WEIGHT_KG");

                entity.Property(e => e.YearOfIssue)
                    .HasColumnType("date")
                    .HasColumnName("YEAR_OF_ISSUE");

                entity.HasOne(d => d.IdHistoryAutoNavigation)
                    .WithMany(p => p.Autos)
                    .HasForeignKey(d => d.IdHistoryAuto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HISTORY_AUTO");
            });

            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.HasKey(e => e.IdBuyer);

                entity.ToTable("BUYER");

                entity.HasIndex(e => e.LoginBuyer, "UQ_LOG_BUYER")
                    .IsUnique();

                entity.Property(e => e.IdBuyer).HasColumnName("ID_BUYER");

                entity.Property(e => e.LoginBuyer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LOGIN_BUYER");

                entity.Property(e => e.MobileNumberBuyer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("MOBILE_NUMBER_BUYER");

                entity.Property(e => e.NameBuyer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME_BUYER");

                entity.Property(e => e.PasswordBuyer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD_BUYER");

                entity.Property(e => e.PatronymicBuyer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PATRONYMIC_BUYER");

                entity.Property(e => e.SeriNumBuyer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("SERI_NUM_BUYER");

                entity.Property(e => e.SurnameBuyer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SURNAME_BUYER");
            });

            modelBuilder.Entity<HistoryAuto>(entity =>
            {
                entity.HasKey(e => e.IdHistoryAuto);

                entity.ToTable("HISTORY_AUTO");

                entity.Property(e => e.IdHistoryAuto).HasColumnName("ID_HISTORY_AUTO");

                entity.Property(e => e.Accidents).HasColumnName("ACCIDENTS");

                entity.Property(e => e.Milleage).HasColumnName("MILLEAGE");
            });

            modelBuilder.Entity<PurchaseStatus>(entity =>
            {
                entity.HasKey(e => e.IdPurchaseStatus);

                entity.ToTable("PURCHASE_STATUS");

                entity.Property(e => e.IdPurchaseStatus)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_PURCHASE_STATUS");

                entity.Property(e => e.IdAuto).HasColumnName("ID_AUTO");

                entity.Property(e => e.IdBuyer).HasColumnName("ID_BUYER");

                entity.Property(e => e.IdSalesman).HasColumnName("ID_SALESMAN");

                entity.Property(e => e.PurchaseStatus1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PURCHASE_STATUS");

                entity.HasOne(d => d.IdAutoNavigation)
                    .WithMany(p => p.PurchaseStatuses)
                    .HasForeignKey(d => d.IdAuto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AUTO");

                entity.HasOne(d => d.IdBuyerNavigation)
                    .WithMany(p => p.PurchaseStatuses)
                    .HasForeignKey(d => d.IdBuyer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BUYER");

                entity.HasOne(d => d.IdSalesmanNavigation)
                    .WithMany(p => p.PurchaseStatuses)
                    .HasForeignKey(d => d.IdSalesman)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SALESMAN");
            });

            modelBuilder.Entity<Salesman>(entity =>
            {
                entity.HasKey(e => e.IdSalesman);

                entity.ToTable("SALESMAN");

                entity.HasIndex(e => e.LoginSalesman, "UQ_LOG_SALESMAN")
                    .IsUnique();

                entity.Property(e => e.IdSalesman).HasColumnName("ID_SALESMAN");

                entity.Property(e => e.LoginSalesman)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LOGIN_SALESMAN");

                entity.Property(e => e.MobileNumberSalesman)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("MOBILE_NUMBER_SALESMAN");

                entity.Property(e => e.NameSalesman)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME_SALESMAN");

                entity.Property(e => e.PasswordSalesman)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD_SALESMAN");

                entity.Property(e => e.PatronymicSalesman)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PATRONYMIC_SALESMAN");

                entity.Property(e => e.SeriNumSalesman)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("SERI_NUM_SALESMAN");

                entity.Property(e => e.SurnameSalesman)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SURNAME_SALESMAN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
