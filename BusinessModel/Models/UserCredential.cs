using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessModel.Models
{
    public class UserCredential : BaseModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        [ForeignKey("Username")]
        public User User { get; set; }
    }
}
