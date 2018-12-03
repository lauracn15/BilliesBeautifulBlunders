namespace PaintShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cart", "AmountOfProducts", c => c.Int(nullable: false));
            DropColumn("dbo.Cart", "AmountOfPaintings");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cart", "AmountOfPaintings", c => c.Int(nullable: false));
            DropColumn("dbo.Cart", "AmountOfProducts");
        }
    }
}
