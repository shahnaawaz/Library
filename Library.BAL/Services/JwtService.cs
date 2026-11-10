using Library.DAL.DataModel;
using Library.DTO.DtoModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Library.BAL.Services
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(TokenDto tokenDto)
        {
            var authClaim = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, tokenDto.UserId.ToString()),
                new Claim(ClaimTypes.Name, tokenDto.UserName),
                new Claim(ClaimTypes.Email, tokenDto.Email),
            };

            foreach (var role in tokenDto.Roles) {
                authClaim.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: authClaim,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials:creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
