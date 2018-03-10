using BusinessModel.Models.Relations;
using System;
using System.Collections.Generic;

namespace BusinessModel.Models
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Contact> Contacts { get; set; }
        
        public List<ProjectUser> ProjectUserRelation { get; set; }
        public List<UserAddress> UserAddressRelation { get; set; }
        public List<UserRole> UserRoleRelation { get; set; }
    }
}
