using BusinessModel.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModel
{
    public class BaseModel : ITraceable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Status Status { get; set; }
    }
}