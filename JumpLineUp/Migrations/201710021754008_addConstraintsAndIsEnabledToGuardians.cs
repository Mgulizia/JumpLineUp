namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addConstraintsAndIsEnabledToGuardians : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Guardians", "IsEnabled", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Guardians", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Guardians", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Guardians", "Phone", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Guardians", "Street1", c => c.String(nullable: false));
            AlterColumn("dbo.Guardians", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Guardians", "State", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.Guardians", "Zip", c => c.String(nullable: false, maxLength: 5));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Guardians", "Zip", c => c.String());
            AlterColumn("dbo.Guardians", "State", c => c.String());
            AlterColumn("dbo.Guardians", "City", c => c.String());
            AlterColumn("dbo.Guardians", "Street1", c => c.String());
            AlterColumn("dbo.Guardians", "Phone", c => c.String());
            AlterColumn("dbo.Guardians", "LastName", c => c.String());
            AlterColumn("dbo.Guardians", "FirstName", c => c.String());
            DropColumn("dbo.Guardians", "IsEnabled");
        }
    }
}
