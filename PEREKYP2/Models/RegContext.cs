using Microsoft.EntityFrameworkCore;

namespace PEREKYP2.Models
{
    public partial class RegContext : DbContext
    {
        public RegContext()
        {
        }

        public RegContext(DbContextOptions<RegContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.Property(e => e.IdUser).HasColumnName("IDUser");

                entity.Property(e => e.SurnameUser)
                    .IsUnicode(false);

                entity.Property(e => e.NameUser)
                    .IsUnicode(false);

                entity.Property(e => e.PatronymicUser)
                    .IsUnicode(false);

                entity.Property(e => e.SeriNumUser)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumberUser)
                    .IsUnicode(false);

                entity.Property(e => e.LoginUser)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordUser)
                    .IsUnicode(false);

                entity.Property(e => e.UserRoleId)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
