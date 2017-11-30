namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceScheduleModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScheduleStartDate = c.DateTime(nullable: false),
                        PickupDetails = c.String(nullable: false),
                        VisitationLocation = c.String(nullable: false),
                        DropOffLocation = c.String(nullable: false),
                        Restrictions = c.String(nullable: false),
                        Sunday = c.Boolean(nullable: false),
                        SunStartTime = c.DateTime(),
                        SunDuration = c.Byte(),
                        Monday = c.Boolean(nullable: false),
                        MonStartTime = c.DateTime(),
                        MonDuration = c.Byte(),
                        Tuesday = c.Boolean(nullable: false),
                        TueStartTime = c.DateTime(),
                        TueDuration = c.Byte(),
                        Wednesday = c.Boolean(nullable: false),
                        WedStartTime = c.DateTime(),
                        WedDuration = c.Byte(),
                        Thursday = c.Boolean(nullable: false),
                        ThurStartTime = c.DateTime(),
                        ThurDuration = c.Byte(),
                        Friday = c.Boolean(nullable: false),
                        FriStartTime = c.DateTime(),
                        FriDuration = c.Byte(),
                        Saturday = c.Boolean(nullable: false),
                        SatStartTime = c.DateTime(),
                        SatDuration = c.Byte(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ServiceSchedules");
        }
    }
}
