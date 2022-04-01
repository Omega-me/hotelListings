using System.ComponentModel.DataAnnotations;

namespace HotelListing.DTO
{
        public class CreateHotelDTO
        {
                [Required]
                [StringLength(maximumLength:150,ErrorMessage = "Hotel name is to long")] 
                public string Name { get; set; }       
                [Required]
                public string Adrsess { get; set; }
                [Range(1,5)]
                public double Rating { get; set; }       
                [Required]
                public int CountryId { get; set; }
        }
        
        public class HotelDTO:CreateHotelDTO
        {
                public int Id { get; set; }
                public CountryDTO Country { get; set;  }
        }
}