using Microsoft.AspNetCore.Mvc;
using Orienta.Application.DTOs.Usuario;
using Orienta.Application.Interfaces;
using Orienta.Application.Services;

namespace Orienta.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<UsuarioAutenticadoDto> Login([FromBody] LoginDto dto)
        {
            return await _authService.Login(dto);
        }
    }
}