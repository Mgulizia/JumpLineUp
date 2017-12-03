namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeRestrictionsNullableInServiceSchedule : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ServiceSchedules", "Restrictions", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceSchedules", "Restrictions", c => c.String(nullable: false));
        }
    }
}
