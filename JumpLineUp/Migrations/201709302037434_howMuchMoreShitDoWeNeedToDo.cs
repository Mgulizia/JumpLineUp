namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class howMuchMoreShitDoWeNeedToDo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CellularCarrierId", c => c.Int(nullable: false));
            //DropColumn("dbo.AspNetUsers", "CellularCarrier_Id");
            //AddForeignKey("dbo.AspNetUsers", "CellularCarriers_Id", "dbo.CellularCarriers", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "CellularCarrier_Id", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "CellularCarrierId");
        }
    }
}
