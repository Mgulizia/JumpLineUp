using System.Data.Entity.Migrations;
using JumpLineUp.Models;

namespace JumpLineUp.Migrations.SeedData
{
    public static class SeedCfsWorkers
    {
        public static void Seed()
        {
            var context = ApplicationDbContext.Create();

            context.CfsWorkers.AddOrUpdate(x => x.Id,
                
                new CfsWorker() {  Id = 1, FirstName = "Patrick",LastName = "Leahy", Email = "patrick.leahy@nebraska.gov", OfficeLocation = "Lincoln",        Phone = "1231231234", IsActive = true},
                new CfsWorker() {  Id = 2, FirstName = "Orrin", LastName = "Hatch", Email = "orrin.hatch@nebraska.gov", OfficeLocation = "Lincoln",           Phone = "5675675678", IsActive = true},
                new CfsWorker() {  Id = 3, FirstName = "Thad", LastName = "Cochran", Email = "thad.cochran@nebraska.gov", OfficeLocation = "Lincoln",         Phone = "4564564566", IsActive = true},
                new CfsWorker() {  Id = 4, FirstName = "Chuck", LastName = "Grassley", Email = "cheuck.grassley@nebraska.gov", OfficeLocation = "Lincoln",    Phone = "5412589632", IsActive = true},
                new CfsWorker() {  Id = 5, FirstName = "Mitch", LastName = "McConnell", Email = "mitch.mcconnell@nebraska.gov", OfficeLocation = "Lincoln",   Phone = "6785674567", IsActive = true},
                new CfsWorker() {  Id = 6, FirstName = "Barbara", LastName = "Mikulski", Email = "barbara.mikulski@nebraska.gov", OfficeLocation = "Lincoln", Phone = "1231231234", IsActive = true},
                new CfsWorker() {  Id = 7, FirstName = "Richard", LastName = "Shelby", Email = "richard.shelby@nebraska.gov", OfficeLocation = "Lincoln",     Phone = "5348571960", IsActive = true},
                new CfsWorker() {  Id = 8, FirstName = "John", LastName = "McCain", Email = "john.mccain@nebraska.gov", OfficeLocation = "Lincoln",           Phone = "4625851236", IsActive = true},
                new CfsWorker() {  Id = 9, FirstName = "Harry", LastName = "Reid", Email = "harry.reid@nebraska.gov", OfficeLocation = "Lincoln",             Phone = "4258624862", IsActive = true},
                new CfsWorker() { Id = 10, FirstName = "Dianne",LastName = "Feinstein", Email = "dianne.feinstein@nebraska.gov", OfficeLocation = "Lincoln",  Phone = "4561237895", IsActive = true}

            );
            context.SaveChanges();

        }

    }
}