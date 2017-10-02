namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsEnabledToBlcsOffice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlcsOffices", "IsEnabled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlcsOffices", "IsEnabled");
        }
    }
}
