using System.Data.Entity.Migrations;
using JumpLineUp.Models;

namespace JumpLineUp.Migrations.SeedData
{
    public static class SeedClients
    {
        public static void Seed()
        {
            var context = ApplicationDbContext.Create();

            context.Clients.AddOrUpdate(x => x.Id,
                new Client() { Id = 1, FirstName = "George", LastName = "Carlin", Street1 = "3234 First St.", Street2 = "", City = "Lincoln", State = "NE",
                    Zip = "68506", Phone = "1231231234", MasterCaseNumber = "584562", ClientId = "5855522", IsEnabled = false},

                new Client() { Id = 2, FirstName = "Jerry", LastName = "Seinfeld", Street1 = "2311 Second St.", Street2 = "", City = "Lincoln", State = "NE",
                    Zip = "68507", Phone = "2524246868", MasterCaseNumber = "48523", ClientId = "4789633", IsEnabled = true},

                new Client() { Id = 3, FirstName = "Dave", LastName = "Chappelle", Street1 = "48523 Third St.", Street2 = "", City = "Lincoln", State = "NE",
                    Zip = "68506", Phone = "8547523658", MasterCaseNumber = "142424", ClientId = "965855",IsEnabled = true},

                new Client() { Id = 4, FirstName = "Chris", LastName = "Rock", Street1 = "123214 Forth St.", Street2 = "", City = "Lincoln", State = "NE",
                    Zip = "68506", Phone = "1231231234", MasterCaseNumber = "584562", ClientId = "5855522", IsEnabled = true},

                new Client() { Id = 5, FirstName = "Amy", LastName = "Schumer", Street1 = "25252 Fifth St.", Street2 = "", City = "Lincoln", State = "NE",
                    Zip = "68506", Phone = "7458652145", MasterCaseNumber = "95621", ClientId = "78562", IsEnabled = true},

                new Client() { Id = 6, FirstName = "Sarah", LastName = "Silverment", Street1 = "585424 Sixth St.", Street2 = "", City = "Lincoln", State = "NE",
                    Zip = "68506", Phone = "7854212125", MasterCaseNumber = "789456", ClientId = "12345678", IsEnabled = true},

                new Client() { Id = 7, FirstName = "Conan", LastName = "O'Brien", Street1 = "122 Seventh St.", Street2 = "", City = "Lincoln", State = "NE",
                    Zip = "68506", Phone = "4521456325", MasterCaseNumber = "7456321", ClientId = "789632558", IsEnabled = true},

                new Client() { Id = 8, FirstName = "Robin", LastName = "Williams", Street1 = "4578 Eigth St.", Street2 = "", City = "Lincoln", State = "NE",
                    Zip = "68506", Phone = "4512587463", MasterCaseNumber = "785412365", ClientId = "45621486", IsEnabled = false}

            );
            context.SaveChanges();

        }

    }
}