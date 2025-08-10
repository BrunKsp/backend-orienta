using Microsoft.Extensions.DependencyInjection;
using Orienta.Domain.Contracts;
using Orienta.Domain.Entities;
using Orienta.Domain.Enums;

namespace Orienta.Application.Factories;

public interface IUsuarioFactoryProvider
{
    IUsuarioFactory<UsuarioEntity> Resolver(TipoUsuario tipo);
}

public class UsuarioFactoryProvider : IUsuarioFactoryProvider
{
    private readonly IServiceProvider _provider;
    public UsuarioFactoryProvider(IServiceProvider provider) => _provider = provider;

    public IUsuarioFactory<UsuarioEntity> Resolver(TipoUsuario tipo)
    {
        return tipo switch
        {
            TipoUsuario.Professor =>
                _provider.GetRequiredService<IUsuarioFactory<ProfessorEntity>>(), // covariante
            TipoUsuario.Aluno =>
                _provider.GetRequiredService<IUsuarioFactory<AlunoEntity>>(),     // covariante
            _ => throw new NotImplementedException()
        };
    }
}