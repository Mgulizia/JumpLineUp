using System.Data.Entity.Migrations;
using JumpLineUp.Models;

namespace JumpLineUp.Migrations.SeedData
{
    public static class SeedFosterParents
    {
        public static void Seed()
        {
            var context = ApplicationDbContext.Create();

            context.FosterParents.AddOrUpdate(x => x.Id,
                new FosterParent {Id=1, FirstName1 = "Michael", LastName1 = "Betzold", Phone1 = "4022252536", FirstName2 = "Paula", LastName2 = "Betzold", Phone2 = "4027516587", Street1 = "3252 W Belvadier Ave", Street2 = "", City = "Lincoln", State = "NE", Zip = "68510", IsEnabled = true},
                new FosterParent {Id=2, FirstName1 = "Mathew", LastName1 = "Gulizia", Phone1 = "4024585203", FirstName2 = "Melissa", LastName2 = "Gulizia", Phone2 = "4024232501", Street1 = "123 6th St.", Street2 = "Apt 2", City = "Lincoln", State = "NE", Zip = "68503", IsEnabled = true },
                new FosterParent {Id=3, FirstName1 = "Julie", LastName1 = "Thompson", Phone1 = "4024585202", FirstName2 = "Steve", LastName2 = "Thompson", Phone2 = "4024232502", Street1 = "71 Pilgrim Avenue ", Street2 = "", City = "Lincoln", State = "NE", Zip = "68502", IsEnabled = true },
                new FosterParent {Id=4, FirstName1 = "Corinne", LastName1 = "Crouch", Phone1 = "4024585205", FirstName2 = "John", LastName2 = "Jones", Phone2 = "4024232503", Street1 = "70 Bowman St.", Street2 = "", City = "Lincoln", State = "NE", Zip = "68504", IsEnabled = true },
                new FosterParent {Id=5, FirstName1 = "Kevin", LastName1 = "Nelson", Phone1 = "4024585204", FirstName2 = "Rachel", LastName2 = "Nelson", Phone2 = "4024232504", Street1 = "4 Goldfield Rd.", Street2 = "Ste 34434 A", City = "Lincoln", State = "NE", Zip = "68505", IsEnabled = true }
            );
            context.SaveChanges();

        }

    }
}