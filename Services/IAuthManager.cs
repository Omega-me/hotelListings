using System.Threading.Tasks;
using HotelListing.DTO;

namespace HotelListing.Services{
    public interface IAuthManager {
        Task<bool> ValidateUser(UserLoginDTO userLoginDto);
        Task<string> CreateToken();
    }
}