namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCellCarrierModelSeedWithData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CellCarriers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarrierName = c.String(),
                        CarrierExtension = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CellCarriers");
        }
    }
}
