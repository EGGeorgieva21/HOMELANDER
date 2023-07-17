using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using rb.api.ViewModels;
using rb.bll;
using rb.dal.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace rb.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService userService;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            userService = new UserService();
        }

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public ActionResult Login([FromBody] LoginUser loginUser)
        {
            User? user = userService.VerifyUser(loginUser.Username, loginUser.Password);

            if(user != null)
            {
                var token = GenerateToken(user);
                return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(new { token = token, user = user }));
            }
            return NotFound("User not found");
        }

        [AllowAnonymous]
        [HttpPost("RegisterUser")]
        public ActionResult Register([FromBody] RegisterUser registerUser)
        {
            User? user = userService.RegisterUser(registerUser.Username, registerUser.Password, registerUser.Email);

            if (user != null)
            {
                var token = GenerateToken(user);
                return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(new { token = token, user = user }));
            }
            return BadRequest("User already exists");
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("inKQxtfhWtLfkrd4hmaQeLE1TUBRgNY1"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Username)
            };
            var token = new JwtSecurityToken("https://localhost:7294",
                "https://localhost:7294",
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}