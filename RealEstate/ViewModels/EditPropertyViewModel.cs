using System.ComponentModel.DataAnnotations;


namespace RealEstate.ViewModels

{
    


    public class EditPropertyViewModel
    {

        [Key]
        public Int64 Id { get; set; }


        [StringLength(50)]
        [Required]
        public string Description { get; set; }

  
        public string? City { get; set; }

        public string? Street { get; set; } = string.Empty;

        [Display(Name = "Postal Code")]
        public string? PostalCode { get; set; } = string.Empty;

        public string? Area { get; set; } = string.Empty;

        public float? Price { get; set; } = 0;

        public IFormFile? Picture { get; set; }
 
        public string Service { get; set; } // rent or sell

        [Display(Name = "Type")]
        public Int64 PropertyTypeID { get; set; }
 

      






    }
}
