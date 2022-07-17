using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RealEstate.Models;


namespace RealEstate.Data

{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
        }


        DbSet<PropertyTypeModel> PropertyTypes { get; set; }
        DbSet<PropertyModel> Properties { get; set; }

    }
}
