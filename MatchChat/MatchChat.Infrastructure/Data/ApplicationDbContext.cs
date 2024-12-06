using MatchChat.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MatchChat.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.Nickname).IsUnique();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Nickname).HasMaxLength(50).IsRequired();
                entity.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                entity.Property(e => e.FavoriteTeam).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.ApiMatchId).IsUnique();
                entity.Property(e => e.HomeTeam).HasMaxLength(50).IsRequired();
                entity.Property(e => e.AwayTeam).HasMaxLength(50).IsRequired();
            });
        }
    }
}