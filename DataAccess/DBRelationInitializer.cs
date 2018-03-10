using BusinessModel.Models.Relations;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess
{
    internal static class DBRelationInitializer
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {
            modelBuilder.SetRelations();

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private static void SetRelations(this ModelBuilder modelBuilder)
        {
            SetProjectUserRelation(modelBuilder);
            SetRolePermissionRelation(modelBuilder);
            SetUserAddressRelation(modelBuilder);
            SetUserRoleRelation(modelBuilder);
        }

        private static void SetProjectUserRelation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectUser>().HasKey(x => new { x.ProjectId, x.UserId });
            modelBuilder.Entity<ProjectUser>().HasOne(x => x.Project).WithMany(p => p.ProjectUserRelation).HasForeignKey(x => x.ProjectId);
            modelBuilder.Entity<ProjectUser>().HasOne(x => x.User).WithMany(t => t.ProjectUserRelation).HasForeignKey(x => x.UserId);
        }
        private static void SetRolePermissionRelation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolePermission>().HasKey(x => new { x.RoleId, x.PermissionId });
            modelBuilder.Entity<RolePermission>().HasOne(x => x.Role).WithMany(p => p.RolePermissionRelation).HasForeignKey(x => x.RoleId);
            modelBuilder.Entity<RolePermission>().HasOne(x => x.Permission).WithMany(t => t.RolePermissionRelation).HasForeignKey(x => x.PermissionId);
        }
        private static void SetUserAddressRelation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAddress>().HasKey(x => new { x.UserId, x.AddressId });
            modelBuilder.Entity<UserAddress>().HasOne(x => x.User).WithMany(p => p.UserAddressRelation).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<UserAddress>().HasOne(x => x.Address).WithMany(t => t.UserAddressRelation).HasForeignKey(x => x.AddressId);
        }
        private static void SetUserRoleRelation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<UserRole>().HasOne(x => x.User).WithMany(p => p.UserRoleRelation).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<UserRole>().HasOne(x => x.Role).WithMany(t => t.UserRoleRelation).HasForeignKey(x => x.RoleId);
        }
    }
}
