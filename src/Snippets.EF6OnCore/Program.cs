using Microsoft.Extensions.Configuration;
using System;
using System.Data.Entity;
using System.IO;
using System.Threading.Tasks;

namespace Snippets.EF6OnCore
{
    public static class Program
    {
        public async static Task Main()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            using var context = new DataContext(configuration.GetConnectionString("DefaultConnection"));

            context.Entities.Add(new Entity { Value = "Some value" });
            context.Entities.Add(new Entity { Value = "Another value" });
            await context.SaveChangesAsync();

            var entities = await context.Entities.ToListAsync();
            foreach (var entity in entities)
                Console.WriteLine(entity);
        }
    }

    public class DataContext : DbContext
    {
        public DbSet<Entity> Entities { get; set; }

        public DataContext(string connectionString) : base(connectionString) { }
    }

    public class Entity
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Value}";
        }
    }
}