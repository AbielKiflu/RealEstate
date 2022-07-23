using System.ComponentModel.DataAnnotations;
  

namespace RealEstate.Models

{
     
    public class PropertyType
    {
        [Key]
        public Int64 ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Property>? Properties { get; set; } = new List<Property>();



    }
}