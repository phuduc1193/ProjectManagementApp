namespace BusinessModel.Models
{
    public class State : BaseModel
    {
        public string Name { get; set; }
        public Country Country { get; set; }
    }
}