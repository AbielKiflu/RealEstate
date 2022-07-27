using System.ComponentModel.DataAnnotations;

namespace RealEstate.ViewModels
{
    public class  EditUserViewModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string? City { get; set; }

        public string? PhoneNumber { get; set; }

        public string? UserName { get; set; }


    }
}
