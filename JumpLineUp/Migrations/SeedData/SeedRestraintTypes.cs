using System.Data.Entity.Migrations;
using JumpLineUp.Models;

namespace JumpLineUp.Migrations.SeedData
{
    public static class SeedRestraintTypes
    {
        public static void Seed()
        {
            var context = ApplicationDbContext.Create();

            context.RestraintTypes.AddOrUpdate(x => x.Id,
                new RestraintType() { Id = 1, RestraintName = "High Back Booster Seat" },
                new RestraintType() { Id = 2, RestraintName = "Booster Seat" },
                new RestraintType() { Id = 3, RestraintName = "5 Point Front Facing" },
                new RestraintType() { Id = 4, RestraintName = "5 Point Rear Facing" }
            );
            context.SaveChanges();

        }

    }
}