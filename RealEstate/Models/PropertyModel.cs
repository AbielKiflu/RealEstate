using System.ComponentModel.DataAnnotations;


namespace RealEstate.Models

{




    public class PropertyModel
    {
        [Key]
        public Int64 Id { get; set; }

        public Int64 UserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


        [StringLength(50)]
        public string Description { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string street { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        public string Area { get; set; } = string.Empty;

        public float Price { get; set; } = 0;

        public bool IsActive { get; set; } = true;
        public string service { get; set; } // rent or sell

        [Display(Name = "Type")]
        public Int64 PropertyTypeID { get; set; }


        public PropertyTypeModel PropertyType { get; set; }

      






    }
}
