


using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace RealEstate.Models

{




    public class PropertyModel
    {
        [Key]
        public Int64 Id { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Area { get; set; }

        public float Price { get; set; }

        public bool IsActive { get; set; }

        public Int64 PropertyTypeID { get; set; }

        public PropertyTypeModel PropertyTypes { get; set; }

      






    }
}
