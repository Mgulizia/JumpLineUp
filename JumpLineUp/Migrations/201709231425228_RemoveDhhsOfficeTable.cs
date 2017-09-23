namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDhhsOfficeTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.DhhsOffices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DhhsOffices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationDescription = c.String(),
                        Phone = c.String(),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
