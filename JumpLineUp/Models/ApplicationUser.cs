﻿using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Text.RegularExpressions;

namespace JumpLineUp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
      

        [Required]
        [Phone]
        [Display(Name = "Cell Number")]
        public string CellNumber { get; set; }

        //--------------------------------- Relation Entities -------------------------------------------------------------

        [Display(Name = "Cellular Carrier")]
        public int CellularCarriersId { get; set; }
        public CellularCarriers CellularCarriers { get; set; }

        [Display(Name = "BLCS Offices")]
        public int BlcsOfficeId { get; set; }   
        public BlcsOffice BlcsOffice { get; set; }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }
}