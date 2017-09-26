using System.ComponentModel.DataAnnotations;

namespace JumpLineUp.ViewModels.Accounts
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}