namespace PaintShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        AmountOfPaintings = c.Int(nullable: false, identity: true),
                        CartId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AmountOfPaintings);
            
            AddColumn("dbo.Product", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Product", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Product", "Size", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Size", c => c.Int(nullable: false));
            DropColumn("dbo.Product", "ModifiedUtc");
            DropColumn("dbo.Product", "CreatedUtc");
            DropTable("dbo.Cart");
        }
    }
}
