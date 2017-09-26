using System.ComponentModel.DataAnnotations;

namespace JumpLineUp.ViewModels.Accounts
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}