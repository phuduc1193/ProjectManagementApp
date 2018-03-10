using BusinessModel.Enum;
using BusinessModel.Models.Relations;
using System.Collections.Generic;

namespace BusinessModel.Models
{
    public class Permission : BaseModel
    {
        public ResourceType Resource { get; set; }
        public ActionType Action { get; set; }

        public List<RolePermission> RolePermissionRelation { get; set; }
    }
}
