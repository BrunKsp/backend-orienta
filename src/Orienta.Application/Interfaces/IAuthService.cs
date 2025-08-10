using Orienta.Application.DTOs.Usuario;
using Orienta.Domain.Entities;

namespace Orienta.Application.Interfaces;

public interface IAuthService
{
    Task<UsuarioAutenticadoDto> Login(LoginDto dto);
    UsuarioAutenticadoDto GenerateJWT(UsuarioEntity user);
}