using Microsoft.Extensions.Configuration;
using System.Data.Entity.Infrastructure;

namespace EF6OnCore
{
    public class DataContextFactory : IDbContextFactory<DataContext>
    {
        public DataContext Create()
        {
            var configuration = ConfigurationProvider.Configuration;
            return new DataContext(configuration.GetConnectionString("DefaultConnection")!);
        }
    }
}