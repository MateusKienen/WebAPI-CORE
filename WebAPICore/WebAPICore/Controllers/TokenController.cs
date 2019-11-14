using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Dominio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace WebAPICore.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] Usuario request)
        {
            if (request.Login == "Admin" && request.Senha == "Admin")
            {
                var tokenString = GerarJSONWebToken(request);
                return Ok(new { token = tokenString });
            }
            return BadRequest();
        }

        private string GerarJSONWebToken(Usuario usuario)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var _claims = new List<Claim> { new Claim("usuarioId", usuario.Id.ToString()) };

            var token = new JwtSecurityToken(
                                    _configuration["Issuer"],
                                    _configuration["Audience"],
                                    claims: _claims,
                                    expires: DateTime.Now.AddHours(8),
                                    signingCredentials: creds
                                ) ;
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}