using System.ComponentModel.DataAnnotations;


namespace JumpLineUp.Models
{
    public class FosterParent
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name = "Street Address")]
        public string Street1 { get; set; }

        [Display(Name = "Address Suffix")]
        public string Street2 { get; set; }

        [Required]
        [MinLength(3)]
        public string City { get; set; }

        [Required]
        [StringLength(2)]
        public string State { get; set; }

        [Required]
        [StringLength(5)]
        public string Zip { get; set; }

        public bool IsEnabled { get; set; }

    }
}