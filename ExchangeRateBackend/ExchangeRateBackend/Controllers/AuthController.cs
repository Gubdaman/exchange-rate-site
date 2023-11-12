using AutoMapper;
using ExchangeRateBackend.Models.RequestResponse;
using ExchangeRateBackend.Models.Service;
using ExchangeRateBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExchangeRateBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private IProfileService _profileService;
        private readonly IMapper _mapper;

        public AuthController(IConfiguration config, IProfileService profileService, IMapper mapper)
        {
            _config = config;
            _profileService = profileService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDataRequest request)
        {
            var profile = await _profileService.Login(_mapper.Map<LoginData>(request));
            if(profile == null)
            {
                return BadRequest();
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>() { 
                new Claim("id", profile.Id.ToString()),
                new Claim("username", profile.Username),
            };
            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return Ok(token);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] LoginDataRequest request)
        {
            var profile = await _profileService.Register(_mapper.Map<LoginData>(request));
            if (profile == null)
            {
                return BadRequest();
            }
            
            return Ok();
        }
    }
}
