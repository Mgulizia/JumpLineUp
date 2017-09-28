using JumpLineUp.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JumpLineUp.Migrations.SeedData
{
    public static class SeedRoles
    {
        public static void Seed()
        {
            var context = ApplicationDbContext.Create();

            //Seed Roles
            IEnumerable<string> roles = new[]
            {
                "CanManageOffices",
                "CanManageCfsWorkers",
                "CanManageFosterParents",
                "CanManageGuardians",
                "CanManageRestraintTypes",
                "CanManageUsers",
                "CanManageYouth",
                "BasicUser"
            };


            foreach (var role in roles)
            {
                if (!context.Roles.Any(r => r.Name == role))
                {
                    var store = new RoleStore<IdentityRole>(context);
                    var manager = new RoleManager<IdentityRole>(store);
                    var newRole = new IdentityRole { Name = role };

                    manager.Create(newRole);
                }
            }
            context.SaveChanges();
        }
    }
}