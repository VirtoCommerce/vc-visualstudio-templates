namespace $safeprojectname$.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerOrderEx",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    NewField = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerOrder", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);

            CreateTable(
                "dbo.OrderInvoice",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    CustomerId = c.String(),
                    CustomerName = c.String(),
                    CustomerOrderExId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderOperation", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.CustomerOrderEx", t => t.CustomerOrderExId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.CustomerOrderExId);

            //Convert  all exist CustomerOrder records to CustomerOrderEx
            Sql("INSERT INTO dbo.CustomerOrderEx (Id) SELECT Id FROM dbo.CustomerOrder");
        }

        public override void Down()
        {
            DropForeignKey("dbo.OrderInvoice", "CustomerOrderExId", "dbo.CustomerOrderEx");
            DropForeignKey("dbo.OrderInvoice", "Id", "dbo.OrderOperation");
            DropForeignKey("dbo.CustomerOrderEx", "Id", "dbo.CustomerOrder");

            DropIndex("dbo.OrderInvoice", new[] { "CustomerOrderExId" });
            DropIndex("dbo.OrderInvoice", new[] { "Id" });
            DropIndex("dbo.CustomerOrderEx", new[] { "Id" });

            DropTable("dbo.OrderInvoice");
            DropTable("dbo.CustomerOrderEx");
        }
    }
}
