using System.ComponentModel.DataAnnotations;


namespace JumpLineUp.Dtos
{
    public class OtherContactDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string Phone { get; set; }


        [MinLength(3)]
        public string Street1 { get; set; }

        public string Street2 { get; set; }


        [MinLength(3)]
        public string City { get; set; }


        [StringLength(2)]
        public string State { get; set; }


        [StringLength(5)]
        public string Zip { get; set; }

        public bool IsEnabled { get; set; }

    }
}