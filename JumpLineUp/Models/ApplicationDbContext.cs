﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JumpLineUp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<BlcsOffice> BlcsOffices { get; set; }
        public DbSet<CfsWorker> CfsWorkers { get; set; }
        //public DbSet<DhhsOffice> DhhsOffices { get; set; }
        public DbSet<FosterParent> FosterParents { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<RestraintType> RestraintTypes { get; set; }
        public DbSet<Youth> Youths { get; set; }
        
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