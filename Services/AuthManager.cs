using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HotelListing.Domain;
using HotelListing.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HotelListing.Services {
    public class AuthManager:IAuthManager {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        private ApiUser _apiUser;

        public AuthManager(UserManager<ApiUser> userManager,IConfiguration configuration) {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<bool> ValidateUser(UserLoginDTO userLoginDto) {
            _apiUser = await _userManager.FindByEmailAsync(userLoginDto.Email);
            return (_apiUser != null && await  _userManager.CheckPasswordAsync(_apiUser, userLoginDto.Password));
        }

        public Task<string> CreateToken() {
            throw new NotImplementedException();
        }

        // public async Task<string> CreateToken()
        // {
        //     var sigingCredentials = GetSignigCredentials();
        //     var claims = await GetClaims();
        //     var TokenOptions = GenerateTokenOptions(sigingCredentials, claims);
        //
        //     return new JwtSecurityTokenHandler().WriteToken(TokenOptions);
        // }

        // private JwtSecurityToken GenerateTokenOptions(SigningCredentials sigingCredentials, List<Claim> claims)
        //{
            // var jwtSettings = _configuration.GetSection("Jwt");
            
            // var token = new JwtSecurityToken(
            //     issuer:jwtSettings.GetSection("Issuer").Value,
            //     claims:claims,
            //     expires:jwtSettings.GetSection("LifeTime").Value,
            //     sigingCredentials:sigingCredentials
            // );
            // var token = "";

            //return token;
        //}

        private async Task<List<Claim>> GetClaims() {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Email, _apiUser.Email),
            };
            var roles = await _userManager.GetRolesAsync(_apiUser);
            foreach (var role in roles) {
                claims.Add(new Claim(ClaimTypes.Role,role));
            }
            return claims;
        }

        private SigningCredentials GetSignigCredentials() {
            var key = Environment.GetEnvironmentVariable("KEY");
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
    }
}