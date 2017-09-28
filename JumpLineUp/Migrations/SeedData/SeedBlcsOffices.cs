using System.Data.Entity.Migrations;
using JumpLineUp.Models;

namespace JumpLineUp.Migrations.SeedData
{
    public static class SeedBlcsOffices
    {
        public static void Seed()
        {
            var context = ApplicationDbContext.Create();

            context.BlcsOffices.AddOrUpdate(x => x.Id,
                new BlcsOffice() { Id = 1, LocationDescription = "Lincoln Office", Street1 = "7100 S. 29th St.", Street2 = "Ste. B", City = "Lincoln", State = "NE.", Zip = "68516", Phone = "4024760104" },
                new BlcsOffice() { Id = 2, LocationDescription = "Fremont Office", Street1 = "245 E. 5th St.", Street2 = "", City = "Fremont", State = "NE.", Zip = "68025", Phone = "4027532096" },
                new BlcsOffice() { Id = 3, LocationDescription = "Columbus Office", Street1 = "3154 18th Ave.", Street2 = "Ste. 6", City = "Columbus", State = "NE.", Zip = "68601", Phone = "4026064524" },
                new BlcsOffice() { Id = 4, LocationDescription = "York Office", Street1 = "808 Grant Ave.", Street2 = "", City = "York", State = "NE.", Zip = "68476", Phone = "4027456527" },
                new BlcsOffice() { Id = 5, LocationDescription = "Beatrice Office", Street1 = "214 N 7th St", Street2 = "", City = "Beatrice", State = "NE.", Zip = "68310", Phone = "4022230266" },
                new BlcsOffice() { Id = 6, LocationDescription = "Nebraska City Office", Street1 = "1807 4th Corso", Street2 = "Ste. 7", City = "Nebraska City", State = "NE.", Zip = "68310", Phone = "4028749029" },
                new BlcsOffice() { Id = 7, LocationDescription = "South Sioux City Office", Street1 = "1000 W. 29th St.", Street2 = "Ste. 319", City = "South Sioux City", State = "NE.", Zip = "68410", Phone = "4028749029" }
            );
            context.SaveChanges();
        }

    }
}