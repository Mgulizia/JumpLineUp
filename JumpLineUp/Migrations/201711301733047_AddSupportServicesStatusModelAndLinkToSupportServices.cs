namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSupportServicesStatusModelAndLinkToSupportServices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupportServicesStatus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        StatusDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SupportServices", "StatusId", c => c.Byte(nullable: false));
            CreateIndex("dbo.SupportServices", "StatusId");
            AddForeignKey("dbo.SupportServices", "StatusId", "dbo.SupportServicesStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupportServices", "StatusId", "dbo.SupportServicesStatus");
            DropIndex("dbo.SupportServices", new[] { "StatusId" });
            DropColumn("dbo.SupportServices", "StatusId");
            DropTable("dbo.SupportServicesStatus");
        }
    }
}
