namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedConstraintsIsEnabledRelationsToYouthModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Youths", "IsEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Youths", "RestraintTypeId", c => c.Int());
            AlterColumn("dbo.Youths", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Youths", "LastName", c => c.String(nullable: false));
            CreateIndex("dbo.Youths", "RestraintTypeId");
            AddForeignKey("dbo.Youths", "RestraintTypeId", "dbo.RestraintTypes", "Id");
            DropColumn("dbo.Youths", "CarSeatRequirements");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Youths", "CarSeatRequirements", c => c.Int(nullable: false));
            DropForeignKey("dbo.Youths", "RestraintTypeId", "dbo.RestraintTypes");
            DropIndex("dbo.Youths", new[] { "RestraintTypeId" });
            AlterColumn("dbo.Youths", "LastName", c => c.String());
            AlterColumn("dbo.Youths", "FirstName", c => c.String());
            DropColumn("dbo.Youths", "RestraintTypeId");
            DropColumn("dbo.Youths", "IsEnabled");
        }
    }
}
