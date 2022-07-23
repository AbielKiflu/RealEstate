using System.ComponentModel.DataAnnotations;
 

namespace RealEstate.Models

{
    public enum CityEnum
    {
        Liege,
        Antwerpen,
        Brussles,
        Vervier,
        Namur
    }



    public class Property
    {
        [Key]
        public Int64 Id { get; set; }

        [Display(Name = "User")]
        public Int64? ApplicationUserID { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }


        [StringLength(50)]
        [Required]
        public string Description { get; set; }

        public string? Longitude { get; set; } = string.Empty;

        public string? Latitude { get; set; } = string.Empty;

        public string? Country { get; set; } = "Belgium";

        public CityEnum? City { get; set; }

        public string? Street { get; set; } = string.Empty;

        [Display(Name = "Postal Code")]
        public string? PostalCode { get; set; } = string.Empty;

        public string? Area { get; set; } = string.Empty;

        public float? Price { get; set; } = 0;

        public string? Picture { get; set; } = string.Empty;

        public bool? IsActive { get; set; } = true;
        public string Service { get; set; } // rent or sell

        [Display(Name = "Type")]
        public Int64? PropertyTypeID { get; set; }

        public PropertyType? PropertyType { get; set; }

      






    }
}
