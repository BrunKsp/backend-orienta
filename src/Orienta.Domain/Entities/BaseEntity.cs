using Orienta.Domain.Enums;

namespace Orienta.Domain.Entities;

public class BaseEntity
{
    public virtual Guid Id { get; set; }
    public virtual string Slug { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public Status Status { get; set; } = Status.Ativo;

    public void SetSlug(string slug)
    {
        if (string.IsNullOrWhiteSpace(Slug))
            Slug = slug;
    }
}