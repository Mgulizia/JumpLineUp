namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSupportServiceModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SupportServices", name: "Clients_Id", newName: "Client_Id");
            RenameIndex(table: "dbo.SupportServices", name: "IX_Clients_Id", newName: "IX_Client_Id");
            CreateTable(
                "dbo.OtherContactSupportServices",
                c => new
                    {
                        OtherContact_Id = c.Int(nullable: false),
                        SupportService_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OtherContact_Id, t.SupportService_Id })
                .ForeignKey("dbo.OtherContacts", t => t.OtherContact_Id, cascadeDelete: true)
                .ForeignKey("dbo.SupportServices", t => t.SupportService_Id, cascadeDelete: true)
                .Index(t => t.OtherContact_Id)
                .Index(t => t.SupportService_Id);
            
            CreateTable(
                "dbo.YouthSupportServices",
                c => new
                    {
                        Youth_Id = c.Int(nullable: false),
                        SupportService_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Youth_Id, t.SupportService_Id })
                .ForeignKey("dbo.Youths", t => t.Youth_Id, cascadeDelete: true)
                .ForeignKey("dbo.SupportServices", t => t.SupportService_Id, cascadeDelete: true)
                .Index(t => t.Youth_Id)
                .Index(t => t.SupportService_Id);
            
            AddColumn("dbo.SupportServices", "FosterParentId", c => c.Int());
            CreateIndex("dbo.SupportServices", "FosterParentId");
            AddForeignKey("dbo.SupportServices", "FosterParentId", "dbo.FosterParents", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YouthSupportServices", "SupportService_Id", "dbo.SupportServices");
            DropForeignKey("dbo.YouthSupportServices", "Youth_Id", "dbo.Youths");
            DropForeignKey("dbo.OtherContactSupportServices", "SupportService_Id", "dbo.SupportServices");
            DropForeignKey("dbo.OtherContactSupportServices", "OtherContact_Id", "dbo.OtherContacts");
            DropForeignKey("dbo.SupportServices", "FosterParentId", "dbo.FosterParents");
            DropIndex("dbo.YouthSupportServices", new[] { "SupportService_Id" });
            DropIndex("dbo.YouthSupportServices", new[] { "Youth_Id" });
            DropIndex("dbo.OtherContactSupportServices", new[] { "SupportService_Id" });
            DropIndex("dbo.OtherContactSupportServices", new[] { "OtherContact_Id" });
            DropIndex("dbo.SupportServices", new[] { "FosterParentId" });
            DropColumn("dbo.SupportServices", "FosterParentId");
            DropTable("dbo.YouthSupportServices");
            DropTable("dbo.OtherContactSupportServices");
            RenameIndex(table: "dbo.SupportServices", name: "IX_Client_Id", newName: "IX_Clients_Id");
            RenameColumn(table: "dbo.SupportServices", name: "Client_Id", newName: "Clients_Id");
        }
    }
}
