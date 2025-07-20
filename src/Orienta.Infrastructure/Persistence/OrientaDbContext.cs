using Microsoft.EntityFrameworkCore;

namespace Orienta.Infrastructure.Persistence;

public class OrientaDbContext : DbContext
{
    public OrientaDbContext(DbContextOptions<OrientaDbContext> options)
       : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrientaDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}