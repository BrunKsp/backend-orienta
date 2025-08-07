using Orienta.Domain.Entities;
using Orienta.Infrastructure.Persistence;
using Orienta.Infrastructure.Repositories.Interfaces;

namespace Orienta.Infrastructure.Repositories;

public class UsuarioRepository : BaseRepository<UsuarioEntity>, IUsuarioRepository
{
    public UsuarioRepository(OrientaDbContext context) : base(context) { }
}