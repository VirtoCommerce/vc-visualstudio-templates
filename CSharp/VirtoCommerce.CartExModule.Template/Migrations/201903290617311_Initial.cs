using System.Data.Entity.Migrations;

namespace $projectname$.Migrations
{
    public partial class Initial : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.CartEx",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    CartType = c.String(maxLength: 64),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cart", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);

            CreateTable(
                "dbo.CartLineItemEx",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    OuterId = c.String(maxLength: 64),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CartLineItem", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);

            //Convert  all exist ShoppingCart records to CartEx
            Sql("INSERT INTO dbo.CartEx (Id) SELECT Id FROM dbo.Cart");

            //Convert  all exist LineItem records to LineItemEx
            Sql("INSERT INTO dbo.CartLineItemEx (Id) SELECT Id FROM dbo.CartLineItem");
        }

        public override void Down()
        {
            DropForeignKey("dbo.CartLineItemEx", "Id", "dbo.CartLineItem");
            DropForeignKey("dbo.CartEx", "Id", "dbo.Cart");

            DropIndex("dbo.CartLineItemEx", new[] { "Id" });
            DropIndex("dbo.CartEx", new[] { "Id" });

            DropTable("dbo.CartLineItemEx");
            DropTable("dbo.CartEx");
        }
    }
}
