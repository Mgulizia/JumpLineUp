namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGuardianToClientAndAddClientId : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Guardians", newName: "Clients");
            AddColumn("dbo.Clients", "ClientId", c => c.String(nullable: false));
            Sql("UpDATE dbo.Clients Set ClientId = 'notset'");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "ClientId");
            RenameTable(name: "dbo.Clients", newName: "Guardians");
        }
    }
}
