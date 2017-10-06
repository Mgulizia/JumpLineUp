namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompletedModelForSupportServicesAndAddedAPIsupport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupportServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MasterCaseNumber = c.String(nullable: false),
                        AuthorizationNumber = c.String(),
                        ServiceStart = c.DateTime(),
                        ServiceStop = c.DateTime(),
                        ClientIds = c.Int(nullable: false),
                        ServiceAreaId = c.Int(nullable: false),
                        ServiceTypeId = c.Int(nullable: false),
                        CfsWorkerId = c.Int(nullable: false),
                        OnHold = c.Boolean(nullable: false),
                        Clients_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CfsWorkers", t => t.CfsWorkerId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Clients_Id)
                .ForeignKey("dbo.ServiceAreas", t => t.ServiceAreaId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypeId, cascadeDelete: true)
                .Index(t => t.ServiceAreaId)
                .Index(t => t.ServiceTypeId)
                .Index(t => t.CfsWorkerId)
                .Index(t => t.Clients_Id);
            
            CreateTable(
                "dbo.YouthInServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YouthId = c.Int(nullable: false),
                        SupportServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SupportServices", t => t.SupportServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Youths", t => t.YouthId, cascadeDelete: true)
                .Index(t => t.YouthId)
                .Index(t => t.SupportServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YouthInServices", "YouthId", "dbo.Youths");
            DropForeignKey("dbo.YouthInServices", "SupportServiceId", "dbo.SupportServices");
            DropForeignKey("dbo.SupportServices", "ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.SupportServices", "ServiceAreaId", "dbo.ServiceAreas");
            DropForeignKey("dbo.SupportServices", "Clients_Id", "dbo.Clients");
            DropForeignKey("dbo.SupportServices", "CfsWorkerId", "dbo.CfsWorkers");
            DropIndex("dbo.YouthInServices", new[] { "SupportServiceId" });
            DropIndex("dbo.YouthInServices", new[] { "YouthId" });
            DropIndex("dbo.SupportServices", new[] { "Clients_Id" });
            DropIndex("dbo.SupportServices", new[] { "CfsWorkerId" });
            DropIndex("dbo.SupportServices", new[] { "ServiceTypeId" });
            DropIndex("dbo.SupportServices", new[] { "ServiceAreaId" });
            DropTable("dbo.YouthInServices");
            DropTable("dbo.SupportServices");
        }
    }
}
