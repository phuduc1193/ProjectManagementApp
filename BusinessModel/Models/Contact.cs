namespace BusinessModel.Models
{
    public class Contact : BaseModel
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public bool IsPrimary { get; set; }
    }
}
