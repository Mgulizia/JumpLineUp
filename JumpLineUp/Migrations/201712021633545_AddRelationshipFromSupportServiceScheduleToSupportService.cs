namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationshipFromSupportServiceScheduleToSupportService : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceSchedules", "SupportServiceId", c => c.Int());
            CreateIndex("dbo.ServiceSchedules", "SupportServiceId");
            AddForeignKey("dbo.ServiceSchedules", "SupportServiceId", "dbo.SupportServices", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceSchedules", "SupportServiceId", "dbo.SupportServices");
            DropIndex("dbo.ServiceSchedules", new[] { "SupportServiceId" });
            DropColumn("dbo.ServiceSchedules", "SupportServiceId");
        }
    }
}
