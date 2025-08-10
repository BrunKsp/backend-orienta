using Orienta.Domain.Enums;

namespace Orienta.Application.DTOs.Usuario;

public class UsuarioAutenticadoDto
{
    public string Slug { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public TipoUsuario TipoUsuario { get; set; }
    public string Token { get; set; }
}