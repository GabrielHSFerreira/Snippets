using System.Data.Entity;

namespace EF6OnCore
{
    public class DataContext : DbContext
    {
        public DbSet<Entity> Entities => Set<Entity>();

        public DataContext(string connectionString) : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Database.SetInitializer(new DataContextInitializer());
        }
    }
}