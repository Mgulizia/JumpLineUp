using System.EnterpriseServices;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using JumpLineUp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JumpLineUp.Migrations.SeedData
{
    public class SeedAdminUser
    {
        public static void Seed()
        {
            var context = ApplicationDbContext.Create();
            var roles = context.Roles.ToList();

            if (!context.Users.Any(u => u.UserName == "admin@blcsne.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser();

                user.UserName = "admin@blcsne.com";
                user.BlcsOfficeId = 1;
                user.CellNumber = "4025026023";
                user.CellularCarriersId = 1;
                user.Email = "admin@blcsne.com";
                user.FirstName = "Mathew";
                user.LastName = "Gulizia";
                user.IsEnabled = true;
                
                manager.Create(user, "Password11!!");
            }

            if (context.Users.Any(u => u.UserName == "admin@blcsne.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = context.Users.Single(u => u.Email == "admin@blcsne.com");
                foreach (var role in roles)
                {
                    manager.AddToRole(user.Id, role.Name);
                }
            }
            context.SaveChanges();
        }
    }
}