using BusinessModel.Models.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModel.Models
{
    public class Project : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan ExtimatedTimeSpan { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PercentProgress { get; set; }

        public List<ProjectUser> ProjectUserRelation { get; set; }
    }
}
