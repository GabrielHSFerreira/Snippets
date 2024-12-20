using Microsoft.Extensions.Configuration;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace EF6OnCore
{
    public static class Program
    {
        public async static Task Main()
        {
            var configuration = ConfigurationProvider.Configuration;

            using var context = new DataContext(configuration.GetConnectionString("DefaultConnection")!);

            context.Entities.Add(new Entity { Value = "Some value" });
            context.Entities.Add(new Entity { Value = "Another value" });
            await context.SaveChangesAsync();

            var entities = await context.Entities.ToListAsync();
            foreach (var entity in entities)
                Console.WriteLine(entity);
        }
    }
}