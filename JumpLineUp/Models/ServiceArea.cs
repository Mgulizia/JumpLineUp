using System.ComponentModel.DataAnnotations;

namespace JumpLineUp.Models
{
    public class ServiceArea
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Service Area Abbreviation")]
        public string ServiceAreaAbbreviation { get; set; }

        [Required]
        [Display(Name = "Service Area Description")]
        [MinLength(3)]
        public string ServiceAreaDescription { get; set; }

        public bool CurrentlyServing { get; set; }

    }

    static class ServiceNames
    {
        public const int CSA = 1;
        public const int NSA = 2;
        public const int ESA = 3;
        public const int WSA = 4;
        public const int SESA = 5;
    }
}