namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddServiceTypesModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceAbbrieviation = c.String(nullable: false),
                        ServiceName = c.String(nullable: false),
                        ServiceCode = c.Int(nullable: false),
                        CurrentService = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ServiceTypes");
        }
    }
}
