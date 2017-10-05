namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddServiceAreasToDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceAreas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceAreaAbbreviation = c.String(nullable: false),
                        ServiceAreaDescription = c.String(nullable: false),
                        CurrentlyServing = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ServiceAreas");
        }
    }
}
