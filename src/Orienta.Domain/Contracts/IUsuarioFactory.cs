using Orienta.Domain.Entities;

namespace Orienta.Domain.Contracts;

public interface IUsuarioFactory<out TUsuario> where TUsuario : UsuarioEntity
{
    TUsuario Criar(string nome, string email, string senha, string foto);
}