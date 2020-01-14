//
// For migration, use the following commands, indicating the type of migration configuration, for 
// multiple migrations in one project:
// Add-Migration <MigrateName> 
//      -ConfigurationTypeName $safeprojectname$.Migrations.Cart.Configuration 
//      -ConnectionString "Data Source=(local);Initial Catalog=VirtoCommerce2_Samples;Persist Security 
//          Info=True;User ID=virto;Password=virto;MultipleActiveResultSets=True;Connect Timeout=420" 
//      -ConnectionProviderName "System.Data.SqlClient"
// Where <MigrateName> is the name of the migration, in the current case it is Initial.
//
// Converting existing records from the source table to the extension table is necessary manually. 
// For example, Sql("INSERT INTO dbo.<TableNameEx> (Id) SELECT Id FROM dbo.<TableName>")
// Where <TableNameEx> is the name of the table with the extension, in the current case CartEx or CartLineItemEx.
// And <TableName> is a table that is expanded, in the current case, Cart or CartLineItem, respectively.
// 

namespace $safeprojectname$.Migrations.Cart
{
    using System;
    using System.Data.Entity.Migrations;
    
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
                        OuterId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CartLineItem", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);

            // Convert all exist ShoppingCart records to CartEx
            Sql("INSERT INTO dbo.CartEx (Id) SELECT Id FROM dbo.Cart");

            // Convert all exist LineItem records to LineItemEx
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
