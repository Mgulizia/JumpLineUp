namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCellCarriers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO CellCarriers (CarrierName, CarrierExtension) VALUES ( 'Verizon', '@vtext.com')
                INSERT INTO CellCarriers (CarrierName, CarrierExtension) VALUES ( 'U.S. Cellular', '@email.uscc.net')
                INSERT INTO CellCarriers (CarrierName, CarrierExtension) VALUES ( 'Sprint', '@messaging.sprintpcs.com')
                INSERT INTO CellCarriers (CarrierName, CarrierExtension) VALUES ( 'AT&T', '@txt.att.net')
                INSERT INTO CellCarriers (CarrierName, CarrierExtension) VALUES ( 'T-Mobile', '@tmomail.net')
                INSERT INTO CellCarriers (CarrierName, CarrierExtension) VALUES ( 'Straight Talk', '@vtext.com')
                INSERT INTO CellCarriers (CarrierName, CarrierExtension) VALUES ( 'Viaero', '@viaerosms.com')
                INSERT INTO CellCarriers (CarrierName, CarrierExtension) VALUES ( 'Cricket', '@mms.cricketwireless.net')  
            ");
        }
        
        public override void Down()
        {
        }
    }
}
