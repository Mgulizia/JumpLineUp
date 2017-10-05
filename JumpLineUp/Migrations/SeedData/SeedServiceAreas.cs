using System.Data.Entity.Migrations;
using JumpLineUp.Models;

namespace JumpLineUp.Migrations.SeedData
{
    public static class SeedServiceAreas
    {
        public static void Seed()
        {
            var context = ApplicationDbContext.Create();

            context.ServiceAreas.AddOrUpdate(x => x.Id,
                new ServiceArea() { Id = 1, ServiceAreaAbbreviation = "CSA", ServiceAreaDescription = "Central Service Area", CurrentlyServing = true},
                new ServiceArea() { Id = 2, ServiceAreaAbbreviation = "NSA", ServiceAreaDescription = "Northern Service Area", CurrentlyServing = true},
                new ServiceArea() { Id = 3, ServiceAreaAbbreviation = "ESA", ServiceAreaDescription = "Eastern Service Area", CurrentlyServing = false},
                new ServiceArea() { Id = 4, ServiceAreaAbbreviation = "WSA", ServiceAreaDescription = "Western Service Area", CurrentlyServing = false},
                new ServiceArea() { Id = 5, ServiceAreaAbbreviation = "SESA", ServiceAreaDescription = "South East Service Area", CurrentlyServing = true}
                
            );
            context.SaveChanges();

        }

    }
}