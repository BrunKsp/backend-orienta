using Orienta.Domain.Entities;

namespace Orienta.Domain.Contracts;

public interface IUsuarioFactory
{
    UsuarioEntity Criar(string nome, string email, string senha, string foto);
}