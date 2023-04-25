using DishDeliveryWebSite.Dtos;
using DishDeliveryWebSite.Models;
using DishDeliveryWebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DishDeliveryWebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenService _tokenService;
        private readonly RefreshTokenService _refreshTokenService;

        public AuthController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            TokenService tokenService,
            RefreshTokenService refreshTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _refreshTokenService = refreshTokenService;
        }

        [HttpPost("singup")]
        public async Task<IActionResult> SingUpAsync(SingUpDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Surname = dto.Surname,
                UserName = dto.Username,
            };

            var singUpResult = await _userManager.CreateAsync(user, dto.Password);
            if (!singUpResult.Succeeded)
            {
                return BadRequest(singUpResult.Errors);
            }

            //var result = await _userManager.AddToRoleAsync(user, "");
            //result.Succeeded

            return Ok();
        }

        [HttpPost("singin")]
        public async Task<ActionResult<SingInResultDto>> SingInAsync(SingInDto dto)
        {
            var normalizedSingInInfo = dto.Username.ToUpper();
            var user = await _userManager.Users
                .SingleOrDefaultAsync(u => u.NormalizedUserName == normalizedSingInInfo || 
                                            u.NormalizedEmail == normalizedSingInInfo);

            if (user == null)
            {
                return Unauthorized();
            }

            var singInResult = await _signInManager
                .CheckPasswordSignInAsync(user, dto.Password, false);
            if (!singInResult.Succeeded)
            {
                return Unauthorized();
            }

            var token = _tokenService.CreateToken(user);

            var result = new SingInResultDto
            {
                AccessToken = _tokenService.CreateToken(user),
                RefreshToken = await _refreshTokenService.CreateRefreshTokenAsync(user),
            };

            return result;
        }
    }
}
