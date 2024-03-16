using API.Dtos;
using API.Models;
using API.Repositorios.Interfaces;
using API.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public TokenService(IConfiguration configuration, IUsuarioRepositorio usuarioRepositorio)
        {
            _configuration = configuration;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public string GenerateToken (LoginDto login)
        {
            var userData = _usuarioRepositorio.Login(login);

            if (userData == null)
            {
                throw new Exception("Usuário ou senha inválidos");
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]??string.Empty));
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(

                issuer: issuer,
                audience: audience,
                claims: new[]
                {
                    new Claim(type: ClaimTypes.Name, userData.Result.Email),
                    new Claim(type: ClaimTypes.Email, userData.Result.Email),

                },

                expires: DateTime.Now.AddHours(1),
                signingCredentials: signinCredentials

                ); 
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }

    }
}
