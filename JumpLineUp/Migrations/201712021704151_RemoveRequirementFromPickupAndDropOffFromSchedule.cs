namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequirementFromPickupAndDropOffFromSchedule : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ServiceSchedules", "PickupDetails", c => c.String());
            AlterColumn("dbo.ServiceSchedules", "DropOffLocation", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceSchedules", "DropOffLocation", c => c.String(nullable: false));
            AlterColumn("dbo.ServiceSchedules", "PickupDetails", c => c.String(nullable: false));
        }
    }
}
