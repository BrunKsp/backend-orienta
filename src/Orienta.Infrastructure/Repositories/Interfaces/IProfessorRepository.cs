using Orienta.Domain.Entities;

namespace Orienta.Infrastructure.Repositories.Interfaces;

public interface IProfessorRepository : IBaseRepository<ProfessorEntity>
{
    Task<ProfessorEntity?> ObterPorEmailAsync(string email);
}