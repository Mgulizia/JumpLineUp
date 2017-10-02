namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StructuredFosterParentModelAddIsEnabled : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FosterParents", "IsEnabled", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FosterParents", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.FosterParents", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.FosterParents", "Phone", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.FosterParents", "Street1", c => c.String(nullable: false));
            AlterColumn("dbo.FosterParents", "City", c => c.String(nullable: false));
            AlterColumn("dbo.FosterParents", "State", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.FosterParents", "Zip", c => c.String(nullable: false, maxLength: 5));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FosterParents", "Zip", c => c.String());
            AlterColumn("dbo.FosterParents", "State", c => c.String());
            AlterColumn("dbo.FosterParents", "City", c => c.String());
            AlterColumn("dbo.FosterParents", "Street1", c => c.String());
            AlterColumn("dbo.FosterParents", "Phone", c => c.String());
            AlterColumn("dbo.FosterParents", "LastName", c => c.String());
            AlterColumn("dbo.FosterParents", "FirstName", c => c.String());
            DropColumn("dbo.FosterParents", "IsEnabled");
        }
    }
}
