using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using JumpLineUp.Migrations.SeedData;
using JumpLineUp.Models;

namespace JumpLineUp.Migrations
{



    internal sealed class Configuration : DbMigrationsConfiguration<JumpLineUp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JumpLineUp.Models.ApplicationDbContext context)
        {
            context = ApplicationDbContext.Create();
            //Seed BLCS Offices
            SeedBlcsOffices.Seed();
            
            //Seed Restraint Types
            SeedRestraintTypes.Seed();
            
            //Seed Cellular Carriers
            SeedCellularCarriers.Seed();
            
            //Seed Roles
            SeedRoles.Seed();

           
            //Seed the Admin User and give all roles
            SeedAdminUser.Seed();

            //Seed the Service Types
            SeedServiceTypes.Seed();

            //Seed the Service Areas
            SeedServiceAreas.Seed();

            //Seed the clients
            SeedClients.Seed();

            //Seed the CFS Workers
            SeedCfsWorkers.Seed();
            
            //Seed the CFS Workers
            SeedFosterParents.Seed();
            
            //Seed the CFS Workers
            SeedOtherContacts.Seed();

            //Seed the Youth
            SeedYouth.Seed();
            
            //Seed the Support Service Statuses
            SeedSupportStatus.Seed();

          
        }
    }
}
