namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUnUsedTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OthersInServices", "OtherContactId", "dbo.OtherContacts");
            DropForeignKey("dbo.OthersInServices", "SupportServiceId", "dbo.SupportServices");
            DropForeignKey("dbo.YouthInServices", "SupportServiceId", "dbo.SupportServices");
            DropForeignKey("dbo.YouthInServices", "YouthId", "dbo.Youths");
            DropIndex("dbo.OthersInServices", new[] { "OtherContactId" });
            DropIndex("dbo.OthersInServices", new[] { "SupportServiceId" });
            DropIndex("dbo.YouthInServices", new[] { "YouthId" });
            DropIndex("dbo.YouthInServices", new[] { "SupportServiceId" });
            DropTable("dbo.OthersInServices");
            DropTable("dbo.YouthInServices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.YouthInServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YouthId = c.Int(nullable: false),
                        SupportServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OthersInServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OtherContactId = c.Int(nullable: false),
                        SupportServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.YouthInServices", "SupportServiceId");
            CreateIndex("dbo.YouthInServices", "YouthId");
            CreateIndex("dbo.OthersInServices", "SupportServiceId");
            CreateIndex("dbo.OthersInServices", "OtherContactId");
            AddForeignKey("dbo.YouthInServices", "YouthId", "dbo.Youths", "Id", cascadeDelete: true);
            AddForeignKey("dbo.YouthInServices", "SupportServiceId", "dbo.SupportServices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OthersInServices", "SupportServiceId", "dbo.SupportServices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OthersInServices", "OtherContactId", "dbo.OtherContacts", "Id", cascadeDelete: true);
        }
    }
}
