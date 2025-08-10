using Orienta.Domain.Enums;

namespace Orienta.Domain.Entities;

public class ProfessorEntity : UsuarioEntity
{
    public ProfessorEntity(string nome, string email, string senha, string foto)
        : base(nome, email, senha, foto, TipoUsuario.Professor) { }

    private ProfessorEntity() { }
}