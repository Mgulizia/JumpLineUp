using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JumpLineUp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JumpLineUp.Helpers
{
    public static class RoleHelper
    {
        public static bool HasRole(string userId, string roleId)
        {
            ApplicationDbContext userscontext = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(userscontext);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<IdentityRole>(userscontext);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            return userManager.IsInRole(userId, roleId);
        }
    }
}