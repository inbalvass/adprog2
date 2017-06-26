namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.DbInfoes");
            AlterColumn("dbo.DbInfoes", "Password", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.DbInfoes", new[] { "Username", "Password" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.DbInfoes");
            AlterColumn("dbo.DbInfoes", "Password", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.DbInfoes", new[] { "Username", "Password" });
        }
    }
}
