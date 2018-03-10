namespace DataAccess
{
    public static class DbInitializer
    {
        public static void Initialize(ProjectManagementContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
