using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JumpLineUp.Models;

namespace JumpLineUp.ViewModels.Accounts
{
    public class RegisterViewModel
    {
        //[Required]
        //[EmailAddress]
        //[Display(Name = "Email")]
        //public string Email { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        
        //[Required]
        //[Phone]
        //[Display(Name = "Phone Number")]
        //public string Phone { get; set; }
        //
        //
        [Required]
        [Display(Name = "Cellular Carrier")]
        public int CellCarrierId { get; set; }

        [Required]
        [Display(Name = "Office Location")]
        public int BlcsOfficeId { get; set; }

        //Relational lists for the views
        public IEnumerable CellularCarriers { get; set; }

        public IEnumerable BlcsOffices { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

    }
}