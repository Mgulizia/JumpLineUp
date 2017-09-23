namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedBLCSoffices : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO BlcsOffices (LocationDescription, Phone, Street1, Street2, City, State, Zip) VALUES ( 'Lincoln Office', '4024760104', '7100 S 29th St.', 'Ste. B', 'Lincoln','NE','68506')");
            Sql("INSERT INTO BlcsOffices (LocationDescription, Phone, Street1, Street2, City, State, Zip) VALUES ( 'Beatrice Office', '4022230266', '214 N 7th St.', null, 'Beatrice','NE','68310')");
            Sql("INSERT INTO BlcsOffices (LocationDescription, Phone, Street1, Street2, City, State, Zip) VALUES ( 'Columbus Office', '4026064524', '3154 18th Ave.', 'Ste. 6', 'Columbus','NE','68601')");
            Sql("INSERT INTO BlcsOffices (LocationDescription, Phone, Street1, Street2, City, State, Zip) VALUES ( 'Fremont Office', '4027532096', '245 E. 5th St.', null, 'Fremont','NE','68025')");
            Sql("INSERT INTO BlcsOffices (LocationDescription, Phone, Street1, Street2, City, State, Zip) VALUES ( 'Nebraska City Office', '4028749029', '1807 4th Corso', 'Ste. 7', 'Nebraska City','NE','68410')");
            Sql("INSERT INTO BlcsOffices (LocationDescription, Phone, Street1, Street2, City, State, Zip) VALUES ( 'York Office', '4027456527', '608 N. Grant Ave.', null, 'York','NE','68476')");
            Sql("INSERT INTO BlcsOffices (LocationDescription, Phone, Street1, Street2, City, State, Zip) VALUES ( 'South Sioux City Office', '424944904', '1000 W. 29th St.', 'Ste. 319', 'South Sioux City','NE','68410')");
        }
        
        public override void Down()
        {
        }
    }
}
