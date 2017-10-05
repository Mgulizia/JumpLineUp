namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedNameOfGuardianToClientAddMasterCaseNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "MasterCaseNumber", c => c.String(nullable: false));
            Sql("UPDATE dbo.Clients SET MasterCaseNumber = 'notset'");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "MasterCaseNumber");
        }
    }
}
