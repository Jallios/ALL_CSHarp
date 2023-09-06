using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIProject.Models
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
        public virtual DbSet<HistoryAuto> HistoryAutos { get; set; } = null!;
        public virtual DbSet<PurchaseStatus> PurchaseStatuses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

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

                entity.Property(e => e.IdAuto).HasColumnName("ID_AUTO");

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

                entity.Property(e => e.IdPurchaseStatus).HasColumnName("ID_PURCHASE_STATUS");

                entity.Property(e => e.AutoId).HasColumnName("AUTO_ID");

                entity.Property(e => e.PurchaseStatus1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PURCHASE_STATUS");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("USER");

                entity.HasIndex(e => e.LoginUser, "UQ_LOG_USER")
                    .IsUnique();

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.Property(e => e.LoginUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LOGIN_USER");

                entity.Property(e => e.MobileNumberUser)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("MOBILE_NUMBER_USER");

                entity.Property(e => e.NameUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME_USER");

                entity.Property(e => e.PasswordUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD_USER");

                entity.Property(e => e.PatronymicUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PATRONYMIC_USER");

                entity.Property(e => e.SeriNumUser)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("SERI_NUM_USER");

                entity.Property(e => e.SurnameUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SURNAME_USER");

                entity.Property(e => e.UserRoleId).HasColumnName("USER_ROLE_ID");

            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.IdUserRole);

                entity.ToTable("USER_ROLE");

                entity.HasIndex(e => e.Role, "UQ_ROLE_USER")
                    .IsUnique();

                entity.Property(e => e.IdUserRole).HasColumnName("ID_USER_ROLE");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
