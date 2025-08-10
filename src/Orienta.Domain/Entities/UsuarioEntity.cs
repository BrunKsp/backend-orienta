using Orienta.Domain.Enums;

namespace Orienta.Domain.Entities;

public class UsuarioEntity : BaseEntity
{
    public string Nome { get; protected set; }
    public string Email { get; protected set; }
    public string Senha { get; protected set; }
    public string Foto { get; protected set; }
    public TipoUsuario TipoUsuario { get; protected set; }

    protected UsuarioEntity() { }

    public UsuarioEntity(string nome, string email, string senha, string foto, TipoUsuario tipo)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
        Foto = foto;
        TipoUsuario = tipo;
    }
}