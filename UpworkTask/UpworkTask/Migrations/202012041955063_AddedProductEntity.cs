namespace UpworkTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterialNumber = c.String(nullable: false),
                        EAN = c.String(nullable: false),
                        Specifications = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
