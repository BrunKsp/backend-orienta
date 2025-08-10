using Orienta.Domain.Contracts;
using Orienta.Domain.Entities;

namespace Orienta.Infrastructure.Factories
{
    public sealed class UsuarioProfessorFactory : IUsuarioFactory<ProfessorEntity>
    {
        public ProfessorEntity Criar(string nome, string email, string senha, string foto)
            => new ProfessorEntity(nome, email, senha, foto); 
    }
}