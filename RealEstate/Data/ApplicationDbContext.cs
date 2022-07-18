using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using RealEstate.Models;



namespace RealEstate.Data

{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Int64>, Int64>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
        }


        DbSet<PropertyTypeModel> PropertyType { get; set; }
        DbSet<PropertyModel> Property { get; set; }

    }
}
