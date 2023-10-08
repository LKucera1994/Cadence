using AutoMapper;
using Core.Entities.DTOs;
using Core.Entities.Identity;
using Infrastructure.Data;
using Infrastructure.Data.Repository.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ITokenService tokenService, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {

            var email = User.FindFirstValue(ClaimTypes.Email);

            var user = await _userManager.FindByEmailAsync(email);

            return new UserDto
            {
                DisplayName = user.DisplayName,
                Token = _tokenService.CreateToken(user),
                Email = user.Email,

            };

        }

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [HttpGet("appuser")]
        [Authorize]
        public async Task<ActionResult<AppUserDto>> GetAppUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);

            return _mapper.Map<AppUser,AppUserDto>(user);

        }

        [HttpPut("appuser")]
        [Authorize]
        public async Task<ActionResult<AppUserDto>> UpdateAppUser(AppUserDto appUser)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);

            if(!string.IsNullOrEmpty(appUser.DisplayName))
                user.DisplayName = appUser.DisplayName;

            user.FirstName = appUser.FirstName; 
            user.LastName = appUser.LastName; 
            user.Street = appUser.Street; 
            user.City = appUser.City; 
            user.State = appUser.State; 
            user.Zipcode = appUser.Zipcode; 
         
            var result = await _userManager.UpdateAsync(user);

            if(result.Succeeded)
                return Ok(_mapper.Map<AppUser,AppUserDto>(user));

            else
                return BadRequest("Error at updating user");
         
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {         
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
                return Unauthorized();
            
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
                return Unauthorized();

            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DisplayName

            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if(CheckEmailExistsAsync(registerDto.Email).Result.Value)
            {
                return  BadRequest("Email already exists");
            }

            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
                return BadRequest();

            return new UserDto
            {
                DisplayName = user.DisplayName,
                Token=_tokenService.CreateToken(user),
                Email = user.Email,

            };
        }

        [HttpDelete("delete")]
        [Authorize]
        public async Task<ActionResult> DeleteUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
                return Ok("User successfully deleted");

            else
                return BadRequest("Error at deleting user");

        }
    }
}
