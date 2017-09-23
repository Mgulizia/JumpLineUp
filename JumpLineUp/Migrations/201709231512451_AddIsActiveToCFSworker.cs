namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsActiveToCFSworker : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CfsWorkers", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.CfsWorkers", "OfficeLocation", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CfsWorkers", "OfficeLocation", c => c.String());
            DropColumn("dbo.CfsWorkers", "IsActive");
        }
    }
}
