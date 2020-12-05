namespace UpworkTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductSpecsAndLangs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductLanguages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductSpecifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductSpecifications");
            DropTable("dbo.ProductLanguages");
        }
    }
}
