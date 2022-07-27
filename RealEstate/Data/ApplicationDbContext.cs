using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using RealEstate.Models;
using RealEstate.ViewModels;
 

namespace RealEstate.Data

{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Int64>, Int64>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }



        public DbSet<PropertyType> PropertyType { get; set; }
        public DbSet<Property> Property { get; set; }  


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("User");

            builder.Entity<IdentityRole<Int64>>().ToTable("Role");
            builder.Entity<IdentityUserRole<Int64>>().ToTable("UserRole");
            builder.Entity<IdentityUserClaim<Int64>>().ToTable("UserClaim");
            builder.Entity<IdentityUserLogin<Int64>>().ToTable("UserLogin");
           
            builder.Entity<IdentityUserToken<Int64>>().ToTable("UserTokens");
            builder.Entity<IdentityRoleClaim<Int64>>().ToTable("RoleClaims");


        }


        public DbSet<RealEstate.ViewModels.EditUserViewModel>? EditUserViewModel { get; set; }



    }
}
