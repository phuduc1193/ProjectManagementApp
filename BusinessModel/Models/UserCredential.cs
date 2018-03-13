namespace BusinessModel.Models
{
    public class UserCredential : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public User User { get; set; }
    }
}
