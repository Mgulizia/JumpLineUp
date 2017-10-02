
using System.ComponentModel.DataAnnotations;

namespace JumpLineUp.Models
{
    public class BlcsOffice
    {
        public static readonly byte Lincoln = 1;
        public static readonly byte Fremont = 2;
        public static readonly byte Columbus = 3;
        public static readonly byte York = 4;
        public static readonly byte Beatrice = 5;
        public static readonly byte NebraskaCity = 6;
        public static readonly byte SiouxCity = 7;


        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name = "Office Description")]
        public string LocationDescription { get; set; }

        [Required]
        [StringLength(10)]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        [MinLength(3)]
        public string Street1 { get; set; }

        [Display(Name = "Address Suffix")]
        public string Street2 { get; set; }

        [Required]
        [MinLength(3)]
        
        public string City { get; set; }

        [Required]
        [StringLength(2, ErrorMessage = "Abbrieviation only")]
        public string State { get; set; }

        [Required]
        [StringLength(5)]
        [Display(Name = "Zip Code")]
        public string Zip { get; set; }

        public bool IsEnabled { get; set; }
    }
}