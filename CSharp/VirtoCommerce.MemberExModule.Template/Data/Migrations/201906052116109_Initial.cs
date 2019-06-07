namespace $safeprojectname$.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberSupplierReview",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Review = c.String(maxLength: 2048),
                        SupplierId = c.String(nullable: false, maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 64),
                        ModifiedBy = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MemberSupplier", t => t.SupplierId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.MemberSupplier",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ContractNumber = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Member", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MemberSupplier", "Id", "dbo.Member");
            DropForeignKey("dbo.MemberSupplierReview", "SupplierId", "dbo.MemberSupplier");

            DropIndex("dbo.MemberSupplier", new[] { "Id" });
            DropIndex("dbo.MemberSupplierReview", new[] { "SupplierId" });

            DropTable("dbo.MemberSupplier");
            DropTable("dbo.MemberSupplierReview");
        }
    }
}
