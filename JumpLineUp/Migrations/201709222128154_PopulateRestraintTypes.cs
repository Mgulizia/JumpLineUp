namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRestraintTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO RestraintTypes (RestraintName) VALUES ( 'Infant')");
            Sql("INSERT INTO RestraintTypes (RestraintName) VALUES ( 'High Back Booster Seat' )");
            Sql("INSERT INTO RestraintTypes (RestraintName) VALUES ( 'Booster Seat' )");
            Sql("INSERT INTO RestraintTypes (RestraintName) VALUES ( '5 Point Front Facing' )");
            Sql("INSERT INTO RestraintTypes (RestraintName) VALUES ('5 Point Rear Facing' )");
        }
        
        public override void Down()
        {
        }
    }
}
