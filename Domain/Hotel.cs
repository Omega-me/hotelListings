using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.Domain
{
    public class Hotel
    {
        public int Id { get; set; }       
        public string Name { get; set; }       
        public string Adrsess { get; set; }
        public double Rating { get; set; }       
        
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}