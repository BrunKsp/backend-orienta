using Microsoft.EntityFrameworkCore;
using Orienta.Domain.Entities;
using Orienta.Infrastructure.Persistence;
using Orienta.Infrastructure.Repositories.Interfaces;

namespace Orienta.Infrastructure.Repositories;

public class ProfessorRepository : BaseRepository<ProfessorEntity>, IProfessorRepository
{

    public ProfessorRepository(OrientaDbContext context) : base(context)
    {

    }

    public async Task<ProfessorEntity?> ObterPorEmailAsync(string email)
    {
        return await DbSet.FirstOrDefaultAsync(p => p.Email == email);
    }
}