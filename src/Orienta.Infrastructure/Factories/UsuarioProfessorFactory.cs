using Orienta.Domain.Contracts;
using Orienta.Domain.Entities;
using Orienta.Domain.Enums;

namespace Orienta.Infrastructure.Factories
{
    public class UsuarioProfessorFactory : IUsuarioFactory
    {
        public UsuarioEntity Criar(string nome, string email, string senha, string foto)
        {
            return new UsuarioEntity(nome, email, senha, foto, TipoUsuario.Professor);
        }
    }
}