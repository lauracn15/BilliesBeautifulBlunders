namespace PaintShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hep : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Sales", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "ModifiedUtc");
            DropColumn("dbo.Sales", "CreatedUtc");
        }
    }
}
