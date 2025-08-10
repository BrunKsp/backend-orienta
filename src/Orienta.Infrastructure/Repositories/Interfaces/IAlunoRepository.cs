using Orienta.Domain.Entities;

namespace Orienta.Infrastructure.Repositories.Interfaces;

public interface IAlunoRepository : IBaseRepository<AlunoEntity>
{
    Task<AlunoEntity> ObterPorEmailAsync(string email);
}