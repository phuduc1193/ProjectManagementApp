using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModel.Models.Relations
{
    public class UserAddress : BaseModel
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
