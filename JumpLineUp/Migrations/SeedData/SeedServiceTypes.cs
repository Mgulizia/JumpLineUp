using System.Data.Entity.Migrations;
using JumpLineUp.Models;

namespace JumpLineUp.Migrations.SeedData
{
    public static class SeedServiceTypes
    {
        public static void Seed()
        {
            var context = ApplicationDbContext.Create();

            context.ServiceTypes.AddOrUpdate(x => x.Id,
                new ServiceType() { Id = 1, ServiceAbbrieviation = "BREATH", ServiceName = "Breathalyzer", ServiceCode = 6854, CurrentService = true},
                new ServiceType() { Id = 2, ServiceAbbrieviation = "DR", ServiceName = "Screening Refusal", ServiceCode = 5911, CurrentService = true},
                new ServiceType() { Id = 3, ServiceAbbrieviation = "IFP", ServiceName = "Intensive Family Preservation", ServiceCode = 8487, CurrentService = true},
                new ServiceType() { Id = 4, ServiceAbbrieviation = "IN-FS", ServiceName = "In Home Family Support", ServiceCode = 7171, CurrentService = true},
                new ServiceType() { Id = 5, ServiceAbbrieviation = "IN-HOME", ServiceName = "In Home Safety Service", ServiceCode = 1841, CurrentService = true},
                new ServiceType() { Id = 6, ServiceAbbrieviation = "INSTANT", ServiceName = "Instant Urine Screening -iCup", ServiceCode = 4509, CurrentService = true},
                new ServiceType() { Id = 7, ServiceAbbrieviation = "NFC", ServiceName = "Nebraska Families Collaberative", ServiceCode = 1234, CurrentService = true},
                new ServiceType() { Id = 8, ServiceAbbrieviation = "NS", ServiceName = "No Show - Drug Screening", ServiceCode = 9574, CurrentService = true},
                new ServiceType() { Id = 9, ServiceAbbrieviation = "ORAL", ServiceName = "Saliva Screening", ServiceCode = 9574, CurrentService = true},
                new ServiceType() { Id = 10, ServiceAbbrieviation = "OUT-FS", ServiceName = "Out of home Family Support", ServiceCode = 7443, CurrentService = true},
                new ServiceType() { Id = 11, ServiceAbbrieviation = "PT/SV", ServiceName = "Parenting Time / Supervised Visitation", ServiceCode = 8873, CurrentService = true},
                new ServiceType() { Id = 12, ServiceAbbrieviation = "SITE", ServiceName = "Parenting Time / Supervised Visitation", ServiceCode = 8873, CurrentService = true},
                new ServiceType() { Id = 13, ServiceAbbrieviation = "UA", ServiceName = "Urine Only Drug Screening", ServiceCode = 5045, CurrentService = true},
                new ServiceType() { Id = 14, ServiceAbbrieviation = "UA/ADM", ServiceName = "Admission of Use / Drug Screening", ServiceCode = 9109, CurrentService = true},
                new ServiceType() { Id = 15, ServiceAbbrieviation = "UA/ADM", ServiceName = "Admission of Use / Drug Screening", ServiceCode = 5045, CurrentService = true}
            );
            context.SaveChanges();

        }

    }
}