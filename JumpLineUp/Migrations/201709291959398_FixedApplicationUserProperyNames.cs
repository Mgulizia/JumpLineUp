namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedApplicationUserProperyNames : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "CellularCarriersId", "dbo.CellularCarriers");
            DropIndex("dbo.AspNetUsers", new[] { "CellularCarriersId" });
            RenameColumn(table: "dbo.AspNetUsers", name: "CellularCarriersId", newName: "CellularCarriers_Id");
            AddColumn("dbo.AspNetUsers", "CellularCarrierId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "CellularCarriers_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "CellularCarriers_Id");
            AddForeignKey("dbo.AspNetUsers", "CellularCarriers_Id", "dbo.CellularCarriers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "CellularCarriers_Id", "dbo.CellularCarriers");
            DropIndex("dbo.AspNetUsers", new[] { "CellularCarriers_Id" });
            AlterColumn("dbo.AspNetUsers", "CellularCarriers_Id", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "CellularCarrierId");
            RenameColumn(table: "dbo.AspNetUsers", name: "CellularCarriers_Id", newName: "CellularCarriersId");
            CreateIndex("dbo.AspNetUsers", "CellularCarriersId");
            AddForeignKey("dbo.AspNetUsers", "CellularCarriersId", "dbo.CellularCarriers", "Id", cascadeDelete: true);
        }
    }
}
