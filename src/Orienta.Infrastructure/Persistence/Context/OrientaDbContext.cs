using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Orienta.Domain.Entities;

namespace Orienta.Infrastructure.Persistence;

public class OrientaDbContext : DbContext
{
    public OrientaDbContext(DbContextOptions<OrientaDbContext> options)
       : base(options) { }

    public DbSet<PerguntaEntity> Perguntas { get; set; }
    public DbSet<AlternativaEntity> Alternativas { get; set; }
    public DbSet<QuestionarioEntity> Questionarios { get; set; }
    public DbSet<ProfessorEntity> Professores { get; set; }
    public DbSet<AlunoEntity> Alunos { get; set; }
    public DbSet<RespostaEntity> Respostas { get; set; }
    public DbSet<RespostaPerguntaEntity> RespostaPerguntas { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.HasDefaultSchema("orienta");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrientaDbContext).Assembly);
        foreach (var property in modelBuilder.Model.GetEntityTypes()
                    .SelectMany(e => e.GetProperties()
                        .Where(p => p.ClrType == typeof(string) &&
                                    p.GetMaxLength() == null &&
                                    p.GetColumnType() == null)))
            property.SetColumnType("varchar(100)");

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entityEntry in ChangeTracker.Entries())
        {
            if (entityEntry.Entity is BaseEntity be && entityEntry.State == EntityState.Added)
            {
                GerarSlug(be);
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    private void GerarSlug(BaseEntity be)
    {
        var hash = Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                    .Replace("/", "-")
                    .Replace("+", "_");
        be.SetSlug(hash);
    }
}

public class OrientaDbContextFactory : IDesignTimeDbContextFactory<OrientaDbContext>
{
    public OrientaDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<OrientaDbContext>();

        builder.UseNpgsql("User ID=coderace_owner;Password=npg_NxiVMfhaA02W;Host=ep-steep-poetry-a69f74zc-pooler.us-west-2.aws.neon.tech;Port=5432;Database=coderace",
                x => x.MigrationsHistoryTable("__ef_historico_migrations", "orienta"));

        return new OrientaDbContext(builder.Options);
    }
}