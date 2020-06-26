using System.Data.Entity.Migrations;

namespace EF6OnCore.Migrations
{
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entities",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Value = c.String(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Entities");
        }
    }
}