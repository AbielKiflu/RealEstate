using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;



namespace RealEstate.Models

{




    public class PropertyTypeModel
    {
        [Key]
        public Int64 ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<PropertyModel> PropertyModel { get; set; }



    }
}