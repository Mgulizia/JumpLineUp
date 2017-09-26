using System.ComponentModel.DataAnnotations;

namespace JumpLineUp.ViewModels.Accounts
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}