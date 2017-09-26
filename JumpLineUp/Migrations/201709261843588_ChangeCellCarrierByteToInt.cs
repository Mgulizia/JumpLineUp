namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCellCarrierByteToInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "CellCarrier_Id", "dbo.CellCarriers");
            DropIndex("dbo.AspNetUsers", new[] { "CellCarrier_Id" });
            DropColumn("dbo.AspNetUsers", "CellCarrierId");
            RenameColumn(table: "dbo.AspNetUsers", name: "CellCarrier_Id", newName: "CellCarrierId");
            AlterColumn("dbo.AspNetUsers", "CellCarrierId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "CellCarrierId");
            AddForeignKey("dbo.AspNetUsers", "CellCarrierId", "dbo.CellCarriers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "CellCarrierId", "dbo.CellCarriers");
            DropIndex("dbo.AspNetUsers", new[] { "CellCarrierId" });
            AlterColumn("dbo.AspNetUsers", "CellCarrierId", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "CellCarrierId", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.AspNetUsers", name: "CellCarrierId", newName: "CellCarrier_Id");
            AddColumn("dbo.AspNetUsers", "CellCarrierId", c => c.Byte(nullable: false));
            CreateIndex("dbo.AspNetUsers", "CellCarrier_Id");
            AddForeignKey("dbo.AspNetUsers", "CellCarrier_Id", "dbo.CellCarriers", "Id");
        }
    }
}
