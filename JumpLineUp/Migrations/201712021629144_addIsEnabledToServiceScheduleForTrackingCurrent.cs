namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsEnabledToServiceScheduleForTrackingCurrent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceSchedules", "IsEnabled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceSchedules", "IsEnabled");
        }
    }
}
