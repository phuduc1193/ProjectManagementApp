using BusinessModel.Models.Relations;
using System.Collections.Generic;

namespace BusinessModel.Models
{
    public class Address : BaseModel
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public bool IsPrimary { get; set; }

        public List<UserAddress> UserAddressRelation { get; set; }
    }
}