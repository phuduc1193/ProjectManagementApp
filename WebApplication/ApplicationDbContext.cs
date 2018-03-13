using Microsoft.EntityFrameworkCore;
using ZNetCS.AspNetCore.Logging.EntityFrameworkCore;

namespace WebApplication
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ExtendedLog> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // build default model.
            LogModelBuilderHelper.Build(modelBuilder.Entity<ExtendedLog>());

            // real relation database can map table:
            modelBuilder.Entity<ExtendedLog>().ToTable("Log");

            modelBuilder.Entity<ExtendedLog>().Property(r => r.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<ExtendedLog>().HasIndex(r => r.TimeStamp).HasName("IX_Log_TimeStamp");
            modelBuilder.Entity<ExtendedLog>().HasIndex(r => r.EventId).HasName("IX_Log_EventId");
            modelBuilder.Entity<ExtendedLog>().HasIndex(r => r.Level).HasName("IX_Log_Level");

            modelBuilder.Entity<ExtendedLog>().Property(u => u.Name).HasMaxLength(255);
            modelBuilder.Entity<ExtendedLog>().Property(u => u.Browser).HasMaxLength(255);
            modelBuilder.Entity<ExtendedLog>().Property(u => u.User).HasMaxLength(255);
            modelBuilder.Entity<ExtendedLog>().Property(u => u.Host).HasMaxLength(255);
            modelBuilder.Entity<ExtendedLog>().Property(u => u.Path).HasMaxLength(255);
        }
    }
}