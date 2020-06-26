using System.Data.Entity.Migrations;

namespace EF6OnCore.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            context.Entities.AddOrUpdate(new Entity
            {
                Id = 1,
                Value = "I'm the first one!"
            });
            context.SaveChanges();
        }
    }
}