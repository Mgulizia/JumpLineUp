namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixNameOfCellularCarriers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "CellularCarriers_Id", "dbo.CellularCarriers");
            DropIndex("dbo.AspNetUsers", new[] { "CellularCarriers_Id" });
            RenameColumn(table: "dbo.AspNetUsers", name: "CellularCarriers_Id", newName: "CellularCarriersId");
            AlterColumn("dbo.AspNetUsers", "CellularCarriersId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "CellularCarriersId");
            AddForeignKey("dbo.AspNetUsers", "CellularCarriersId", "dbo.CellularCarriers", "Id", cascadeDelete: true);
            DropColumn("dbo.AspNetUsers", "CellularCarrierId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "CellularCarrierId", c => c.Int(nullable: false));
            DropForeignKey("dbo.AspNetUsers", "CellularCarriersId", "dbo.CellularCarriers");
            DropIndex("dbo.AspNetUsers", new[] { "CellularCarriersId" });
            AlterColumn("dbo.AspNetUsers", "CellularCarriersId", c => c.Int());
            RenameColumn(table: "dbo.AspNetUsers", name: "CellularCarriersId", newName: "CellularCarriers_Id");
            CreateIndex("dbo.AspNetUsers", "CellularCarriers_Id");
            AddForeignKey("dbo.AspNetUsers", "CellularCarriers_Id", "dbo.CellularCarriers", "Id");
        }
    }
}
