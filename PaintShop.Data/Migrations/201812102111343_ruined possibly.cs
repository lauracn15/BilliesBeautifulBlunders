namespace PaintShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ruinedpossibly : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Sales", "CreatedUtc");
            DropColumn("dbo.Sales", "ModifiedUtc");
            DropColumn("dbo.Sales", "Title");
            DropColumn("dbo.Sales", "Colors");
            DropColumn("dbo.Sales", "Size");
            DropColumn("dbo.Sales", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Sales", "Size", c => c.String());
            AddColumn("dbo.Sales", "Colors", c => c.String());
            AddColumn("dbo.Sales", "Title", c => c.String());
            AddColumn("dbo.Sales", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Sales", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
