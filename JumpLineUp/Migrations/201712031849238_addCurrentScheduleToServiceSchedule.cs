namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCurrentScheduleToServiceSchedule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceSchedules", "CurrentSchedule", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceSchedules", "CurrentSchedule");
        }
    }
}
