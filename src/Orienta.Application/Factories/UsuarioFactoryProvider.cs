using Microsoft.Extensions.DependencyInjection;
using Orienta.Domain.Contracts;
using Orienta.Domain.Enums;
using Orienta.Infrastructure.Factories;

public interface IUsuarioFactoryProvider
{
    IUsuarioFactory Resolver(TipoUsuario tipo);
}

public class UsuarioFactoryProvider : IUsuarioFactoryProvider
{
    private readonly IServiceProvider _provider;

    public UsuarioFactoryProvider(IServiceProvider provider)
    {
        _provider = provider;
    }

    public IUsuarioFactory Resolver(TipoUsuario tipo)
    {
        return tipo switch
        {
            TipoUsuario.Professor => _provider.GetRequiredService<UsuarioProfessorFactory>(),
            TipoUsuario.Aluno => _provider.GetRequiredService<UsuarioAlunoFactory>(),
            _ => throw new NotImplementedException()
        };
    }
}
