namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConstraintsToBlcsOffices : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BlcsOffices", "LocationDescription", c => c.String(nullable: false));
            AlterColumn("dbo.BlcsOffices", "Phone", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.BlcsOffices", "Street1", c => c.String(nullable: false));
            AlterColumn("dbo.BlcsOffices", "City", c => c.String(nullable: false));
            AlterColumn("dbo.BlcsOffices", "State", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.BlcsOffices", "Zip", c => c.String(nullable: false, maxLength: 5));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BlcsOffices", "Zip", c => c.String());
            AlterColumn("dbo.BlcsOffices", "State", c => c.String());
            AlterColumn("dbo.BlcsOffices", "City", c => c.String());
            AlterColumn("dbo.BlcsOffices", "Street1", c => c.String());
            AlterColumn("dbo.BlcsOffices", "Phone", c => c.String());
            AlterColumn("dbo.BlcsOffices", "LocationDescription", c => c.String());
        }
    }
}
