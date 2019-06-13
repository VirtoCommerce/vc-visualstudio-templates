// For migration, use the following commands, indicating the type of migration configuration, for 
// multiple migrations in one project:
// Add-Migration <MigrateName> 
//      -ConfigurationTypeName $safeprojectname$.Migrations.Order.Configuration 
//      -ConnectionString "Data Source=(local);Initial Catalog=VirtoCommerce2_Samples;Persist Security 
//          Info=True;User ID=virto;Password=virto;MultipleActiveResultSets=True;Connect Timeout=420" 
//      -ConnectionProviderName "System.Data.SqlClient"
// Where <MigrateName> is the name of the migration, in the current case it is Initial.
//
// Converting existing records from the source table to the extension table is necessary manually. 
// For example, Sql("INSERT INTO dbo.<TableNameEx> (Id) SELECT Id FROM dbo.<TableName>")
// Where <TableNameEx> is the name of the table with the extension, in the current case CustomerOrderEx.
// And <TableName> is a table that is expanded, in the current case CustomerOrder.
// 

namespace $safeprojectname$.Migrations.Order
{
    using System;
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
                        NewField = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerOrder", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.OrderInvoice",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CustomerId = c.String(maxLength: 128),
                        CustomerName = c.String(maxLength: 128),
                        CustomerOrderExId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderOperation", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.CustomerOrderEx", t => t.CustomerOrderExId)
                .Index(t => t.Id)
                .Index(t => t.CustomerOrderExId);

            // Convert all exist CustomerOrder records to CustomerOrderEx
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
