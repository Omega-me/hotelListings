using System;
using System.Threading.Tasks;
using AutoMapper;
using HotelListing.Domain;
using HotelListing.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelListing.Controllers
{
    [Route("api/users")]
    public class AccountController:ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;

        public AccountController(UserManager<ApiUser> userManager,ILogger<AccountController> logger,IMapper mapper)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
        }

            
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDto)
        {
            _logger.LogInformation($"Registration attempt for {userDto.Email}");
            // if validation errors form data anotation dto 
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var user = _mapper.Map<ApiUser>(userDto);
                user.UserName = userDto.Email.Split("@")[0];
                var result = await _userManager.CreateAsync(user,userDto.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code,error.Description);
                    }
                    // we can get the informations to diplasy on the results if we want 
                    return BadRequest(ModelState);
                }
                return Accepted();
            }
            catch (Exception e) {
                _logger.LogError(e,$"Something went wrong in the {nameof(Register)}");
                // return StatusCode(500,$"Something went wrong in the {nameof(Register)}");
                // another way of returning the problem or error 
                return Problem($"Something went wrong in the {nameof(Register)}",statusCode:500);
            }
            
        }
        
        // [HttpPost]
        // [Route("login")]
        // public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDto)
        // {
        //     _logger.LogInformation($"Login attempt for {userLoginDto.Email}");
        //     // if validation errors form data anotation dto 
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }
        //     
        //     try
        //     {
        //         var result = await _signInManager.PasswordSignInAsync(userLoginDto.Email,userLoginDto.Password,false,false);
        //         if (!result.Succeeded)
        //         {
        //             // we can get the informations to diplasy on the results if we want 
        //             return Unauthorized(userLoginDto);
        //         }
        //         
        //         return Accepted();
        //     }
        //     catch (Exception e)
        //     {
        //         _logger.LogError(e,$"Something went wrong in the {nameof(Register)}");
        //         return StatusCode(500,$"Something went wrong in the {nameof(Register)}");
        //         // another way of returning the problem or error 
        //         return Problem($"Something went wrong in the {nameof(Register)}",statusCode:500);
        //     }
        //     
        // }
    }
}