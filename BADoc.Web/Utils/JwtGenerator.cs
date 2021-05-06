using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

using BADoc.UseCases.DTO;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace BADoc.Web.Utils
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly IConfiguration _configuration;
        public JwtGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateToken(GetUserDTO user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes("stsaznzgt%@df1231%AFG35GS647GaetUIA46IjRTH5e");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.isAdmin ? "Admin": ""),
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}