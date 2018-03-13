using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public static class DbInitializer
    {
        public static void Initialize(DbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
