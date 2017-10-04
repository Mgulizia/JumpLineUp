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

            ////Seed Roles
            //IEnumerable<string> roles = new[]
            //{
            //    "CanManageOffices",
            //    "CanManageCfsWorkers",
            //    "CanManageFosterParents",
            //    "CanManageGuardians",
            //    "CanManageRestraintTypes",
            //    "CanManageUsers",
            //    "CanManageYouth",
            //    "BasicUser"
            //};

            var roles = new Dictionary<string, string>();
            roles.Add("CanManageOffices", "Manage Offices");
            roles.Add("CanManageCfsWorkers", "Manage CFS Workers");
            roles.Add("CanManageFosterParents", "Manage Foster Parents");
            roles.Add("CanManageGuardians", "Manage Client Gaurdians");
            roles.Add("CanManageRestraintTypes", "Manage Vehicle Restraints");
            roles.Add("CanManageUsers", "Manage User Accounts");
            roles.Add("CanManageYouth", "Manage Client Youth");
            roles.Add("BasicUser", "Basic User Account");
            roles.Add("CanManageServiceTypes", "Manage BLCS Offered Services");
            


        //foreach (var role in roles)
        //    {
        //        if (!context.ApplicationRoles.Any(r => r.Name == role))
        //        {
        //            var store = new RoleStore<ApplicationRole>(context);
        //            var manager = new RoleManager<ApplicationRole>(store);
        //            var newRole = new IdentityRole { Name = role };
        //
        //            manager.Create(newRole);
        //        }
        //    }
        //    context.SaveChanges();
        //}

        foreach (var role in roles)
            {
                if (!context.ApplicationRoles.Any(r => r.Name == role.Key))
                {
                    var store = new RoleStore<ApplicationRole>(context);
                    var manager = new RoleManager<ApplicationRole>(store);
                    var newRole = new ApplicationRole() { Name = role.Key, Description = role.Value};

                    manager.Create(newRole);
                }
            }
            context.SaveChanges();
        }
    }
}