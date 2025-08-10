using Microsoft.EntityFrameworkCore;

using Orienta.Domain.Entities;
using Orienta.Infrastructure.Persistence;
using Orienta.Infrastructure.Repositories.Interfaces;

namespace Orienta.Infrastructure.Repositories;

public class AlunoRepository : BaseRepository<AlunoEntity>, IAlunoRepository
{

    public AlunoRepository(OrientaDbContext context) : base(context)
    {

    }

    public async Task<AlunoEntity> ObterPorEmailAsync(string email)
    {
        return await DbSet.FirstOrDefaultAsync(p => p.Email == email);
    }
}