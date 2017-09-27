namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBLCSofficesToApplicationUSer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BlcsOfficeId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "BlcsOfficeId");
            AddForeignKey("dbo.AspNetUsers", "BlcsOfficeId", "dbo.BlcsOffices", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "BlcsOfficeId", "dbo.BlcsOffices");
            DropIndex("dbo.AspNetUsers", new[] { "BlcsOfficeId" });
            DropColumn("dbo.AspNetUsers", "BlcsOfficeId");
        }
    }
}
