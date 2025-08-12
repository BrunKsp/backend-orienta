using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Orienta.Application.DTOs.Usuario;
using Orienta.Application.Exceptions;
using Orienta.Application.Interfaces;
using Orienta.Domain.Entities;
using Orienta.Infrastructure.Repositories.Interfaces;
using BC = BCrypt.Net.BCrypt;


namespace Orienta.Application.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IUsuarioRepository _usuarioRepository;

    public AuthService(IUsuarioRepository usuarioRepository, IConfiguration configuration)
    {
        _usuarioRepository = usuarioRepository;
        _configuration = configuration;
    }

    public UsuarioAutenticadoDto GenerateJWT(UsuarioEntity user)
    {
        var setting = _configuration["Jwt:Settings"];

        var key = Encoding.ASCII.GetBytes(setting);
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Name, user.Nome),
                new(ClaimTypes.Sid, user.Slug),
                new(ClaimTypes.Email, user.Email)
            }),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Expires = DateTime.MaxValue
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new UsuarioAutenticadoDto
        {
            Slug = user.Slug,
            Token = tokenHandler.WriteToken(token),
            Nome = user.Nome,
            Email = user.Email,
            TipoUsuario = user.TipoUsuario,
            Foto = user.Foto
        };
    }

    public async Task<UsuarioAutenticadoDto> Login(LoginDto dto)
    {
        dto.Email = dto.Email.Trim();

        var clienteEmail = await _usuarioRepository.ObterPorEmailAsync(dto.Email)
            ?? throw CustomException.EntityNotFound(new { error = "Email não encontrado!" });

        var senha = BC.Verify(dto.Senha, clienteEmail.Senha);

        if (clienteEmail == null || senha != true)
        {
            throw CustomException.BadRequest(new { error = "Email ou senha não correspondem" });
        }

        return GenerateJWT(clienteEmail);
    }
}