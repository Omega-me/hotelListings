using AutoMapper;
using HotelListing.Domain;
using HotelListing.DTO;

namespace HotelListing.Configurations
{
    public class MapperInitializer:Profile
    {
        public MapperInitializer()
        {
            CreateMap<Country,CountryDTO>().ReverseMap();
            CreateMap<Country,CreateCountryDTO>().ReverseMap();
            CreateMap<Hotel,HotelDTO>().ReverseMap();
            CreateMap<Hotel,CreateHotelDTO>().ReverseMap();
            CreateMap<ApiUser, UserDTO>().ReverseMap();
            CreateMap<ApiUser, UserLoginDTO>().ReverseMap();
        }
    }
}