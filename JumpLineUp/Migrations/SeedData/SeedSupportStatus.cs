using System.Data.Entity.Migrations;
using JumpLineUp.Models;

namespace JumpLineUp.Migrations.SeedData
{
    public static class SeedSupportStatus
    {
        public static void Seed()
        {
            var context = ApplicationDbContext.Create();

            context.SupportServicesStatuses.AddOrUpdate(x => x.Id,
                new SupportServicesStatus() { Id = 1, StatusDescription = "Needs Schedule"},
                new SupportServicesStatus() { Id = 2, StatusDescription = "Needs Assignment"}
                );
            context.SaveChanges();

        }

    }
}