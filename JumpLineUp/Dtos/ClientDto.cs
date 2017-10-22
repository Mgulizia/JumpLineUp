using System.ComponentModel.DataAnnotations;


namespace JumpLineUp.Dtos
{
    public class ClientDto
    {
        public int Id { get; set; }

        [Required]
        public string ClientId { get; set; }

        [Required]
        public string MasterCaseNumber { get; set; }


        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string Phone { get; set; }

        [Required]
        [MinLength(3)]
        public string Street1 { get; set; }

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