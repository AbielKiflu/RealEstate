using Microsoft.AspNetCore.Identity;


namespace RealEstate.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Country { get; set; }
        public string City { get; set; }

        public string PostalCode { get; set; }




    }
}
