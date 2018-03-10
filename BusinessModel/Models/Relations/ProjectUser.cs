using BusinessModel.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModel.Models.Relations
{
    public class ProjectUser : BaseModel
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public RelationType Relation { get; set; }
    }
}
