using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Organic_Shop_BackEnd.DTO;
using Organic_Shop_BackEnd.Model;

namespace Organic_Shop_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;

        public AccountController(UserManager<ApiUser> userManager, 
            ILogger<AccountController> logger, 
            IMapper mapper)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO userDTO)
        {
            _logger.LogInformation($"Registration Attempt for {userDTO.Email}");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = _mapper.Map<ApiUser>(userDTO);
                user.UserName = userDTO.Email;
                var result = await _userManager.CreateAsync(user, userDTO.Password);

                if (!result.Succeeded)
                    return StatusCode(500, "User Registration Attempt Failed");

                await _userManager.AddToRolesAsync(user, new List<string> { "User" });
                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wront in the {nameof(Register)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
        //{
        //    _logger.LogInformation($"Login Attempt for {userDTO.Email}");

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    try
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(userDTO.Email, userDTO.Password, false, false);

        //        if (!result.Succeeded)
        //            return Unauthorized(userDTO);

        //        return Accepted();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Something Went Wront in the {nameof(Login)}");
        //        return StatusCode(500, "Internal Server Error. Please Try Again Later.");
        //    }
        //}
    }
}
