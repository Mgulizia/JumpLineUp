using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using JumpLineUp.Models;

namespace JumpLineUp.ViewModels.Accounts
{
    public class UserEditViewModel
    {

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        //model data for drop downs and other selectors
        public IEnumerable CellularCarriers { get; set; }
        public List<ApplicationRole> Roles { get; set; }
        public IEnumerable BlcsOffices { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}