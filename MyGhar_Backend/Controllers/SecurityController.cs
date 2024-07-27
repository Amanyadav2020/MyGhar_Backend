using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyGhar_Backend.Contract;
using MyGhar_Backend.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyGhar_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecurityController : ControllerBase
    {

        private readonly IUserMaster _UserMaster;
        private readonly IConfiguration _configuration;

        public SecurityController(IConfiguration configuration, IUserMaster UserMaster)
        {
            _configuration = configuration;
            _UserMaster = UserMaster;
        }

        [HttpPost]
        [Route("Token")]
        [AllowAnonymous]
        public IResult GetToken([FromBody] UserDTO model)
        {
            try
            {
                var user = _UserMaster.GetUser(model.UserName, model.Password).Result;

                if (user != null)
                {
                    var issuer = _configuration["Jwt:Issuer"];
                    var audience = _configuration["Jwt:Audience"];
                    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[]
                        {
                        new Claim(JwtRegisteredClaimNames.Sub, Convert.ToString(user.Id)),
                        new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                        new Claim("firstname", user.FirstName),
                        new Claim("lastname", user.LastName),
                        //new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        
                    }),
                        Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["IdentityAccessTokenLifeTime"])),
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHandler.WriteToken(token);
                    var stringToken = tokenHandler.WriteToken(token);
                    return Results.Ok(stringToken);
                }
                return Results.Unauthorized();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
