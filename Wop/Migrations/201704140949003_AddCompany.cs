namespace Wop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompany : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Selects", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Selects", "UserId", c => c.Int(nullable: false));
        }
    }
}
