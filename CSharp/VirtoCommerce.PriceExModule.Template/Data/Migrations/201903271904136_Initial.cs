using System.Data.Entity.Migrations;

namespace $safeprojectname$.Migrations
{
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PriceEx",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    BasePrice = c.Decimal(precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Price", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);

            //Convert  all exist Price records to Price2
            Sql("INSERT INTO dbo.PriceEx (Id) SELECT Id FROM dbo.Price");
        }

        public override void Down()
        {
            DropForeignKey("dbo.PriceEx", "Id", "dbo.Price");
            DropIndex("dbo.PriceEx", new[] { "Id" });
            DropTable("dbo.PriceEx");
        }
    }
}
