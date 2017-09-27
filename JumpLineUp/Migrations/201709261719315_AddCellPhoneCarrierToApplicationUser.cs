namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCellPhoneCarrierToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CellCarrierId", c => c.Byte(nullable: false));
            AddColumn("dbo.AspNetUsers", "CellCarrier_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "CellCarrier_Id");
            AddForeignKey("dbo.AspNetUsers", "CellCarrier_Id", "dbo.CellCarriers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "CellCarrier_Id", "dbo.CellCarriers");
            DropIndex("dbo.AspNetUsers", new[] { "CellCarrier_Id" });
            DropColumn("dbo.AspNetUsers", "CellCarrier_Id");
            DropColumn("dbo.AspNetUsers", "CellCarrierId");
        }
    }
}
