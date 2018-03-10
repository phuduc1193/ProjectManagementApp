using System.Collections.Generic;

namespace BusinessModel.Models
{
    public class Country : BaseModel
    {
        public string Name { get; set; }
        public string LocalName { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public string NumericCode { get; set; }
        public List<State> States { get; set; }
    }
}