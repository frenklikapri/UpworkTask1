namespace UpworkTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductLanguages", "Title", c => c.String());
            AddColumn("dbo.ProductSpecifications", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductSpecifications", "Title");
            DropColumn("dbo.ProductLanguages", "Title");
        }
    }
}
