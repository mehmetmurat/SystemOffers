using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersService _userService;
        private IConfiguration _configuration;
        public UsersController(IUsersService usersService, IConfiguration configuration)
        {
            _userService = usersService;
            _configuration = configuration;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Users user)
        {
            var userData = _userService.Login(user);
            if (userData.Success)
            {
                TokenResult r = new TokenResult();
                var tokenHandler = new JwtSecurityTokenHandler();
                DateTime expaireDate = DateTime.Now.AddDays(1);
                var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:TokenKey").Value);
                var tokenDescrepter = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Email)
                }),
                    Expires = expaireDate,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescrepter);


                r.Token = tokenHandler.WriteToken(token);
                r.ExpireDate =  expaireDate;
                return Ok(r);
            }
            return Unauthorized();
        }
        public class TokenResult
        {
            public string Token { get; set; }
            public DateTime ExpireDate { get; set; }
        }
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Users/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Users
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Users/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
