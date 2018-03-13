using BusinessModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) { }

        public DbSet<BusinessModel.Models.User> Users { get; set; }
        public DbSet<BusinessModel.Models.Project> Projects { get; set; }
        public DbSet<BusinessModel.Models.Role> Roles { get; set; }
        public DbSet<BusinessModel.Models.State> States { get; set; }
        public DbSet<BusinessModel.Models.Country> Countries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BusinessModel.Models.User>().ToTable("User");
            modelBuilder.Entity<BusinessModel.Models.Project>().ToTable("Project");
            modelBuilder.Entity<BusinessModel.Models.Role>().ToTable("Role");
            modelBuilder.Entity<BusinessModel.Models.State>().ToTable("State");
            modelBuilder.Entity<BusinessModel.Models.Country>().ToTable("Country");

            DBRelationInitializer.Initialize(modelBuilder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is ITraceable traceable)
                {
                    var now = DateTime.UtcNow;
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            traceable.ModifiedOn = now;
                            break;

                        case EntityState.Added:
                            traceable.CreatedOn = now;
                            traceable.ModifiedOn = now;
                            break;
                    }
                }
            }
        }
    }
}
