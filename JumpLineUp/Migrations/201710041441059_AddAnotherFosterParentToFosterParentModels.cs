namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnotherFosterParentToFosterParentModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FosterParents", "FirstName1", c => c.String(nullable: false));
            AddColumn("dbo.FosterParents", "LastName1", c => c.String(nullable: false));
            AddColumn("dbo.FosterParents", "Phone1", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.FosterParents", "FirstName2", c => c.String());
            AddColumn("dbo.FosterParents", "LastName2", c => c.String());
            AddColumn("dbo.FosterParents", "Phone2", c => c.String(maxLength: 10));
            DropColumn("dbo.FosterParents", "FirstName");
            DropColumn("dbo.FosterParents", "LastName");
            DropColumn("dbo.FosterParents", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FosterParents", "Phone", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.FosterParents", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.FosterParents", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.FosterParents", "Phone2");
            DropColumn("dbo.FosterParents", "LastName2");
            DropColumn("dbo.FosterParents", "FirstName2");
            DropColumn("dbo.FosterParents", "Phone1");
            DropColumn("dbo.FosterParents", "LastName1");
            DropColumn("dbo.FosterParents", "FirstName1");
        }
    }
}
