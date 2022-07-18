using Microsoft.AspNetCore.Identity;


namespace RealEstate.Models
{
    public class ApplicationUser : IdentityUser<Int64>
    {
        public string Country { get; set; }
        public string City { get; set; }

        public string PostalCode { get; set; }

        public ICollection<PropertyModel> PropertyModel { get; set; }


    }
}
