using API.Dtos;
using API.Models;
using API.Repositorios.Interfaces;

namespace API.Services.Interfaces
{
    public interface ITokenService
    {
      
        string GenerateToken(LoginDto login);
    }
}
