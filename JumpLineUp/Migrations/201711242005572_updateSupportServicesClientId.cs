namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSupportServicesClientId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SupportServices", "Client_Id", "dbo.Clients");
            DropIndex("dbo.SupportServices", new[] { "Client_Id" });
            RenameColumn(table: "dbo.SupportServices", name: "Client_Id", newName: "ClientId");
            AlterColumn("dbo.SupportServices", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.SupportServices", "ClientId");
            AddForeignKey("dbo.SupportServices", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupportServices", "ClientId", "dbo.Clients");
            DropIndex("dbo.SupportServices", new[] { "ClientId" });
            AlterColumn("dbo.SupportServices", "ClientId", c => c.Int());
            RenameColumn(table: "dbo.SupportServices", name: "ClientId", newName: "Client_Id");
            CreateIndex("dbo.SupportServices", "Client_Id");
            AddForeignKey("dbo.SupportServices", "Client_Id", "dbo.Clients", "Id");
        }
    }
}
