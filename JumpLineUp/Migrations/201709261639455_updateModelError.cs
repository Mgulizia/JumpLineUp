namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModelError : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CellCarriers");
            AlterColumn("dbo.CellCarriers", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CellCarriers", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CellCarriers");
            AlterColumn("dbo.CellCarriers", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.CellCarriers", "Id");
        }
    }
}
