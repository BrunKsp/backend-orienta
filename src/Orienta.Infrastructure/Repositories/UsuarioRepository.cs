using Orienta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Orienta.Infrastructure.Persistence;
using Orienta.Infrastructure.Repositories.Interfaces;

namespace Orienta.Infrastructure.Repositories;

public class UsuarioRepository : BaseRepository<UsuarioEntity>, IUsuarioRepository
{
    public UsuarioRepository(OrientaDbContext context) : base(context) { }

    public async Task<UsuarioEntity> ObterPorEmailAsync(string email)
    {
        return await DbSet.FirstOrDefaultAsync(p => p.Email == email);
    }
}