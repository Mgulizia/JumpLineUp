using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JumpLineUp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<BlcsOffice> BlcsOffices { get; set; }
        public DbSet<CfsWorker> CfsWorkers { get; set; }
        public DbSet<CellularCarriers> CellularCarriers { get; set; }
        public DbSet<FosterParent> FosterParents { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<RestraintType> RestraintTypes { get; set; }
        public DbSet<Youth> Youths { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServiceArea> ServiceAreas { get; set; }
        public DbSet<SupportService> SupportServices { get; set; }
        public DbSet<YouthInService> YouthInService { get; set; }
        public DbSet<OtherContact> OtherContacts { get; set; }
        public DbSet<OthersInService> OthersInService { get; set; }

        
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}