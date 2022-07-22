using System.ComponentModel.DataAnnotations;

namespace RealEstate.ViewModels
{
    public class PropertyTypeViewModel
    {
        [Key]
        public Int64 ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
 
    }
}
