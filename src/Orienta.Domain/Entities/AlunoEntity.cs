using Orienta.Domain.Enums;

namespace Orienta.Domain.Entities;

public class AlunoEntity : UsuarioEntity
{
    public AlunoEntity(string nome, string email, string senha, string foto)
        : base(nome, email, senha, foto, TipoUsuario.Aluno) { }

    private AlunoEntity() { }
}