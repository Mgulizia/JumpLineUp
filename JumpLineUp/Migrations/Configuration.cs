using JumpLineUp.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JumpLineUp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JumpLineUp.Models.ApplicationDbContext context)
        {
            context.BlcsOffices.AddOrUpdate(x => x.Id,
                new BlcsOffice(){Id = 1, LocationDescription = "Lincoln Office", Street1 = "7100 S. 29th St.", Street2 = "Ste. B", City = "Lincoln", State = "NE.", Zip = "68516", Phone = "4024760104" },   
                new BlcsOffice(){Id = 2, LocationDescription = "Fremont Office", Street1 = "245 E. 5th St.", Street2 = "", City = "Fremont", State = "NE.", Zip = "68025", Phone = "4027532096" },  
                new BlcsOffice(){Id = 3, LocationDescription = "Columbus Office", Street1 = "3154 18th Ave.", Street2 = "Ste. 6", City = "Columbus", State = "NE.", Zip = "68601", Phone = "4026064524" },  
                new BlcsOffice(){Id = 4, LocationDescription = "York Office", Street1 = "808 Grant Ave.", Street2 = "", City = "York", State = "NE.", Zip = "68476", Phone = "4027456527" },  
                new BlcsOffice(){Id = 4, LocationDescription = "Beatrice Office", Street1 = "214 N 7th St", Street2 = "", City = "Beatrice", State = "NE.", Zip = "68310", Phone = "4022230266" },  
                new BlcsOffice(){Id = 4, LocationDescription = "Nebraska City Office", Street1 = "1807 4th Corso", Street2 = "Ste. 7", City = "Nebraska City", State = "NE.", Zip = "68310", Phone = "4028749029" },  
                new BlcsOffice(){Id = 4, LocationDescription = "South Sioux City Office", Street1 = "1000 W. 29th St.", Street2 = "Ste. 319", City = "South Sioux City", State = "NE.", Zip = "68410", Phone = "4028749029" }  
            );
            
            context.RestraintTypes.AddOrUpdate(x => x.Id,
                new RestraintType() { Id = 1, RestraintName = "High Back Booster Seat"},
                new RestraintType() { Id = 2, RestraintName = "Booster Seat"},
                new RestraintType() { Id = 3, RestraintName = "5 Point Front Facing"},
                new RestraintType() { Id = 4, RestraintName = "5 Point Rear Facing"}
            );

            //context.Roles.AddOrUpdate(x => x.Id,
            //    new IdentityRole() {Id="CAN_MANAGE_Office_ASPNET_ROLE", Name="CanManageBlcsOffice"},
            //    new IdentityRole() {Id="CAN_MANAGE_CfsWorker_ASPNET_ROLE", Name="CAnManageCfsWorkers"},
            //    new IdentityRole() {Id="CAN_MANAGE_FosterParents_ASPNET_ROLE", Name="CanManageFosterParents"},
            //    new IdentityRole() {Id="CAN_MANAGE_Guardians_ASPNET_ROLE", Name="CanManageGuardians"},
            //    new IdentityRole() {Id="CAN_MANAGE_RestraintTypes_ASPNET_ROLE", Name="CanManageRestraintTypes"},
            //    new IdentityRole() {Id="CAN_MANAGE_Users_ASPNET_ROLE", Name="CanManageUsers"},
            //    new IdentityRole() {Id="CAN_MANAGE_Youths_ASPNET_ROLE", Name="CanManageYouths"}
            //);
            
            
            
            
            
            
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //







        }
    }
}
