namespace Wop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StickerSelect : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Selects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        StickId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stickers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        UserName = c.String(),
                        Text = c.String(),
                        Date = c.DateTime(nullable: false),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stickers");
            DropTable("dbo.Selects");
        }
    }
}
