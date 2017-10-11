namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveClientFamilyAttributes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClientFamilies", "PrimaryClientId", "dbo.Clients");
            DropForeignKey("dbo.ClientFamilies", "SecondaryClientId", "dbo.Clients");
            DropForeignKey("dbo.Youths", "ClientFamily_Id", "dbo.ClientFamilies");
            DropIndex("dbo.ClientFamilies", new[] { "PrimaryClientId" });
            DropIndex("dbo.ClientFamilies", new[] { "SecondaryClientId" });
            DropIndex("dbo.Youths", new[] { "ClientFamily_Id" });
            DropColumn("dbo.Youths", "ClientFamily_Id");
            DropTable("dbo.ClientFamilies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ClientFamilies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrimaryClientId = c.Int(nullable: false),
                        SecondaryClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Youths", "ClientFamily_Id", c => c.Int());
            CreateIndex("dbo.Youths", "ClientFamily_Id");
            CreateIndex("dbo.ClientFamilies", "SecondaryClientId");
            CreateIndex("dbo.ClientFamilies", "PrimaryClientId");
            AddForeignKey("dbo.Youths", "ClientFamily_Id", "dbo.ClientFamilies", "Id");
            AddForeignKey("dbo.ClientFamilies", "SecondaryClientId", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClientFamilies", "PrimaryClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
    }
}
