using HotelListing.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Domain
{
    // public class DatabaseContext:DbContext this is default Inheritance from DbContext if we dont want to use Identity authentication
    
    // Inherit from IdentityDbContext if we want to use Identity auth
    public class DatabaseContext:IdentityDbContext<ApiUser>
    {
        public DatabaseContext(DbContextOptions options):base(options)
        {}
        
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<ApiUser> ApiUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // if DatabaseContext inherits from IdentityDbContext 
            base.OnModelCreating(modelBuilder);
            /////////////////////////////////////////////////////
            
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new HotelsConfiguration());

            // if we want to implement the configuration directly in thisDatabaseContext file as below
            // modelBuilder.Entity<Hotel>().HasData(
            //     new Hotel
            //     {
            //         Id = 1,
            //         Name = "Hotel 1",
            //         Adrsess = "Hotel 1 street",
            //         Rating = 4.8,
            //         CountryId = 1,
            //     },
            //     new Hotel
            //     {
            //         Id = 2,
            //         Name = "Hotel 2",
            //         Adrsess = "Hotel 2 street",
            //         Rating = 4.8,
            //         CountryId = 2,
            //     },
            //     new Hotel
            //     {
            //         Id = 3,
            //         Name = "Hotel 3",
            //         Adrsess = "Hotel 3 street",
            //         Rating = 4.8,
            //         CountryId = 3,
            //     },
            //     new Hotel
            //     {
            //         Id = 4,
            //         Name = "Hotel 4",
            //         Adrsess = "Hotel 4 street",
            //         Rating = 4.8,
            //         CountryId = 4,
            //     }
            // );
        }
    }
}