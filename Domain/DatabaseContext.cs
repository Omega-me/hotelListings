using Microsoft.EntityFrameworkCore;

namespace HotelListing.Domain
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions options):base(options)
        {}
        
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Albania",
                    ShortName = "AL"
                },
                new Country
                {
                    Id = 2,
                    Name = "Germany",
                    ShortName = "DU"
                },
                new Country
                {
                    Id = 3,
                    Name = "Italy",
                    ShortName = "IT"
                },
                new Country
                {
                    Id = 4,
                    Name = "England",
                    ShortName = "EN"
                }
            );   
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Hotel 1",
                    Adrsess = "Hotel 1 street",
                    Rating = 4.8,
                    CountryId = 1,
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Hotel 2",
                    Adrsess = "Hotel 2 street",
                    Rating = 4.8,
                    CountryId = 2,
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Hotel 3",
                    Adrsess = "Hotel 3 street",
                    Rating = 4.8,
                    CountryId = 3,
                },
                new Hotel
                {
                    Id = 4,
                    Name = "Hotel 4",
                    Adrsess = "Hotel 4 street",
                    Rating = 4.8,
                    CountryId = 4,
                }
            );
        }


    }
}