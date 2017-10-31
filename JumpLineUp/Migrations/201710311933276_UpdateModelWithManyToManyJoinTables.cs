namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelWithManyToManyJoinTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OthersInServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OtherContactId = c.Int(nullable: false),
                        SupportServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OtherContacts", t => t.OtherContactId, cascadeDelete: true)
                .ForeignKey("dbo.SupportServices", t => t.SupportServiceId, cascadeDelete: true)
                .Index(t => t.OtherContactId)
                .Index(t => t.SupportServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OthersInServices", "SupportServiceId", "dbo.SupportServices");
            DropForeignKey("dbo.OthersInServices", "OtherContactId", "dbo.OtherContacts");
            DropIndex("dbo.OthersInServices", new[] { "SupportServiceId" });
            DropIndex("dbo.OthersInServices", new[] { "OtherContactId" });
            DropTable("dbo.OthersInServices");
        }
    }
}
