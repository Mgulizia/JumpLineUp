namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredAttributesInOtherContacts : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OtherContacts", "Street1", c => c.String());
            AlterColumn("dbo.OtherContacts", "City", c => c.String());
            AlterColumn("dbo.OtherContacts", "State", c => c.String(maxLength: 2));
            AlterColumn("dbo.OtherContacts", "Zip", c => c.String(maxLength: 5));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OtherContacts", "Zip", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.OtherContacts", "State", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.OtherContacts", "City", c => c.String(nullable: false));
            AlterColumn("dbo.OtherContacts", "Street1", c => c.String(nullable: false));
        }
    }
}
