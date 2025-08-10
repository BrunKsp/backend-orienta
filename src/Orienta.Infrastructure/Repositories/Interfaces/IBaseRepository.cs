using Orienta.Domain.Entities;

namespace Orienta.Infrastructure.Repositories.Interfaces;

public interface IBaseRepository<TModel> where TModel : BaseEntity
{
    Task Criar(TModel model);
    Task Alterar(TModel model);
    Task Deletar(TModel model);
    Task<TModel> BuscarPorSlug(string slug);
}