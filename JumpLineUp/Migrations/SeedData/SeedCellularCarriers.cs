using System.Data.Entity.Migrations;
using JumpLineUp.Models;

namespace JumpLineUp.Migrations.SeedData
{
    public static class SeedCellularCarriers
    {
        public static void Seed()
        {
            var context = ApplicationDbContext.Create();

            context.CellularCarriers.AddOrUpdate(x => x.Id,
                new CellularCarriers() { Id = 1, CarrierExtension = "@vtext.com", CarrierName = "Verizon" },
                new CellularCarriers() { Id = 2, CarrierExtension = "@email.uscc.net", CarrierName = "US Cellular" },
                new CellularCarriers() { Id = 3, CarrierExtension = "@messaging.sprintpcs.com", CarrierName = "Sprint" },
                new CellularCarriers() { Id = 4, CarrierExtension = "@txt.att.net", CarrierName = "AT&T" },
                new CellularCarriers() { Id = 5, CarrierExtension = "@tmomail.net", CarrierName = "T-Mobile" },
                new CellularCarriers() { Id = 6, CarrierExtension = "@vtext.com", CarrierName = "Straight Talk" },
                new CellularCarriers() { Id = 7, CarrierExtension = "@viaerosms.com", CarrierName = "Viaero" },
                new CellularCarriers() { Id = 8, CarrierExtension = "@mms.cricketwireless.net", CarrierName = "Cricket" }
            );
            context.SaveChanges();

        }
    }
}