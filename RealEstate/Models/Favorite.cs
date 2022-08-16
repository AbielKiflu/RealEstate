using System.ComponentModel.DataAnnotations;
 

namespace RealEstate.Models

{



    public class Favorite
    {
        [Key]
        public Int64 Id { get; set; }

        [Display(Name = "User")]
        public Int64 ApplicationUserID { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
         
  
        public Int64 PropertyID { get; set; }

        public PropertyType? Property { get; set; }








    }
}
