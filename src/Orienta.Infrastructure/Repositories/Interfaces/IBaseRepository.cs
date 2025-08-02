namespace Orienta.Domain.Entities;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T> CriarAsync(T entity);
    Task<T> AlterarAsync(T entity);
    Task<T?> ObterPorIdAsync(Guid id);
}