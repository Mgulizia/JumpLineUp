namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOtherContact : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OtherContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 10),
                        Street1 = c.String(nullable: false),
                        Street2 = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false, maxLength: 2),
                        Zip = c.String(nullable: false, maxLength: 5),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OtherContacts");
        }
    }
}
