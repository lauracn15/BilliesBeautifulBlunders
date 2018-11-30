namespace PaintShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Product", "Medium");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Medium", c => c.Int(nullable: false));
        }
    }
}
