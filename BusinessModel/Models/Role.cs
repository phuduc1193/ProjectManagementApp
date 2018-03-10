using BusinessModel.Models.Relations;
using System.Collections.Generic;

namespace BusinessModel.Models
{
    public class Role : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<RolePermission> RolePermissionRelation { get; set; }
        public List<UserRole> UserRoleRelation { get; set; }
    }
}
