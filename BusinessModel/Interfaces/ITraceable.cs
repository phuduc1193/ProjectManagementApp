using System;

namespace BusinessModel
{
    public interface ITraceable
    {
        DateTime CreatedOn { get; set; }

        DateTime ModifiedOn { get; set; }
    }
}
