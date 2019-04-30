namespace MyCompany.PriceEx4.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PriceEx",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BasePrice = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Price", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PriceEx", "Id", "dbo.Price");
            DropIndex("dbo.PriceEx", new[] { "Id" });
            DropTable("dbo.PriceEx");
        }
    }
}
