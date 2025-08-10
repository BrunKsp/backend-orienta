using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Orienta.Domain.Entities;
using Orienta.Infrastructure.Persistence;
using Orienta.Infrastructure.Repositories.Interfaces;

namespace Orienta.Infrastructure.Repositories
{
    public abstract class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : BaseEntity
    {
        protected readonly OrientaDbContext _context;
        protected readonly DbSet<TModel> DbSet;

        protected DbConnection Connection
        {
            get
            {
                return _context.Database.GetDbConnection();
            }
        }

        public BaseRepository(OrientaDbContext context)
        {
            _context = context;
            DbSet = context.Set<TModel>();
        }
        public async Task Criar(TModel model)
        {
            DbSet.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task Alterar(TModel model)
        {
            DbSet.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(TModel model)
        {
            DbSet.Remove(model);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<TModel> BuscarPorSlug(string slug)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Slug == slug);
        }
    }
}