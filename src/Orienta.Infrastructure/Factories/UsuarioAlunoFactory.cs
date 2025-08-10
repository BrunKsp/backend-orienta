using Orienta.Domain.Contracts;
using Orienta.Domain.Entities;
using Orienta.Domain.Enums;

namespace Orienta.Infrastructure.Factories
{
    public sealed class UsuarioAlunoFactory : IUsuarioFactory<AlunoEntity>
    {
        public AlunoEntity Criar(string nome, string email, string senha, string foto)
            => new AlunoEntity(nome, email, senha, foto);
    }
}
