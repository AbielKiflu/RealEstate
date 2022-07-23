using System.ComponentModel.DataAnnotations;

namespace RealEstate.ViewModels
{
    public class PropertyTypeViewModel
    {
       
        [StringLength(50)]
        public string Name { get; set; }
 
    }
}
