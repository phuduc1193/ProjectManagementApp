using BusinessModel.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserCredential> UserCredentials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserCredential>().ToTable("UserCredential");
            modelBuilder.Entity<UserCredential>()
                        .HasOne(uc => uc.User)
                        .WithMany(u => u.UserCredentials);
        }
    }
}