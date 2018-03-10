using BusinessModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProjectManagementContext : DbContext
    {
        public ProjectManagementContext(DbContextOptions<ProjectManagementContext> options) : base(options)
        { }

        public DbSet<BusinessModel.Models.User> Users { get; set; }
        public DbSet<BusinessModel.Models.Project> Projects { get; set; }
        public DbSet<BusinessModel.Models.Role> Roles { get; set; }
        public DbSet<BusinessModel.Models.State> States { get; set; }
        public DbSet<BusinessModel.Models.Country> Countries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SetEntityToTable(modelBuilder);
            DBRelationInitializer.Initialize(modelBuilder);
        }

        private static void SetEntityToTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessModel.Models.User>().ToTable("User");
            modelBuilder.Entity<BusinessModel.Models.Project>().ToTable("Project");
            modelBuilder.Entity<BusinessModel.Models.Role>().ToTable("Role");
            modelBuilder.Entity<BusinessModel.Models.State>().ToTable("State");
            modelBuilder.Entity<BusinessModel.Models.Country>().ToTable("Country");
        }

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return await base.SaveChangesAsync(cancellationToken);
        }
        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                SetTraceableDateTime(entry);
            }
        }
        private static void SetTraceableDateTime(Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry)
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
