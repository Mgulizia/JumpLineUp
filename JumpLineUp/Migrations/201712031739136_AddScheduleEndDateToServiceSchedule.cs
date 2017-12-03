namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddScheduleEndDateToServiceSchedule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceSchedules", "ScheduleEndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceSchedules", "ScheduleEndDate");
        }
    }
}
