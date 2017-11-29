using System.Data.Entity.Migrations;
using JumpLineUp.Models;

namespace JumpLineUp.Migrations.SeedData
{
    public static class SeedOtherContacts
    {
        public static void Seed()
        {
            var context = ApplicationDbContext.Create();

            context.OtherContacts.AddOrUpdate(x => x.Id,
                new OtherContact { Id = 1, FirstName = "Lori", LastName = "Stehlik", Street1 = "123 Crete Street", Street2 = "", City = "Crete", State = "NE", Zip = "68502", Phone = "4025671548", IsEnabled = true},
                new OtherContact { Id = 2, FirstName = "Laura", LastName = "Marty", Street1 = "321 Lincoln Blvd", Street2 = "", City = "Lincoln", State = "NE", Zip = "68503", Phone = "4024255862", IsEnabled = true},
                new OtherContact { Id = 3, FirstName = "Sheri", LastName = "Ostemeier", Street1 = "5223 Crete Street", Street2 = "", City = "Crete", State = "NE", Zip = "68504", Phone = "4028675309", IsEnabled = true},
                new OtherContact { Id = 4, FirstName = "Jody", LastName = "Magnuson", Street1 = "5454 North Lincoln Blvd", Street2 = "Apt 4.5", City = "Lincoln", State = "NE", Zip = "68505", Phone = "4025252", IsEnabled = true},
                new OtherContact { Id = 5, FirstName = "Amy", LastName = "Bollen", Street1 = "2524 Part Time Ln", Street2 = "", City = "Lincoln", State = "NE", Zip = "68504", Phone = "4025687855", IsEnabled = true}
            );
            context.SaveChanges();

        }

    }
}