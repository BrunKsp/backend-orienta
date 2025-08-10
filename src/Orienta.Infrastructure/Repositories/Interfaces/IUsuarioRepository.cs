using Orienta.Domain.Entities;

namespace Orienta.Infrastructure.Repositories.Interfaces;

public interface IUsuarioRepository
{
    Task<UsuarioEntity> ObterPorEmailAsync(string email);
}