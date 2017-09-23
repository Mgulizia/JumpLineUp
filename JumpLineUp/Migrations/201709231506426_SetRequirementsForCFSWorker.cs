namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetRequirementsForCFSWorker : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CfsWorkers", "FirstName", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.CfsWorkers", "LastName", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.CfsWorkers", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.CfsWorkers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.CfsWorkers", "OfficeLocation", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CfsWorkers", "OfficeLocation", c => c.Int(nullable: false));
            AlterColumn("dbo.CfsWorkers", "Email", c => c.String());
            AlterColumn("dbo.CfsWorkers", "Phone", c => c.String());
            AlterColumn("dbo.CfsWorkers", "LastName", c => c.String());
            AlterColumn("dbo.CfsWorkers", "FirstName", c => c.String());
        }
    }
}
