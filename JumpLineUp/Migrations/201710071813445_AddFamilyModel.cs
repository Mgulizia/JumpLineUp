namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFamilyModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientFamilies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrimaryClientId = c.Int(nullable: false),
                        SecondaryClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.PrimaryClientId)
                .ForeignKey("dbo.Clients", t => t.SecondaryClientId)
                .Index(t => t.PrimaryClientId)
                .Index(t => t.SecondaryClientId);
            
            AddColumn("dbo.Youths", "ClientFamily_Id", c => c.Int());
            CreateIndex("dbo.Youths", "ClientFamily_Id");
            AddForeignKey("dbo.Youths", "ClientFamily_Id", "dbo.ClientFamilies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Youths", "ClientFamily_Id", "dbo.ClientFamilies");
            DropForeignKey("dbo.ClientFamilies", "SecondaryClientId", "dbo.Clients");
            DropForeignKey("dbo.ClientFamilies", "PrimaryClientId", "dbo.Clients");
            DropIndex("dbo.Youths", new[] { "ClientFamily_Id" });
            DropIndex("dbo.ClientFamilies", new[] { "SecondaryClientId" });
            DropIndex("dbo.ClientFamilies", new[] { "PrimaryClientId" });
            DropColumn("dbo.Youths", "ClientFamily_Id");
            DropTable("dbo.ClientFamilies");
        }
    }
}
