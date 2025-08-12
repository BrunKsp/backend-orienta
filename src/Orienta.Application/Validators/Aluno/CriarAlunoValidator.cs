using FluentValidation;
using Orienta.Application.DTOs.Aluno;

namespace Orienta.Application.Validators.Aluno;

public class CriarAlunoValidator : AbstractValidator<CriarAlunoDto>
{
    public CriarAlunoValidator()
    {
        RuleFor(p => p.Email)
       .NotEmpty().WithMessage("Email é obrigatiorio")
       .EmailAddress().WithMessage("Insira um email válido");

        RuleFor(p => p.Nome)
            .NotEmpty().WithMessage("Nome é obrigatório");

        RuleFor(p => p.Senha)
            .NotEmpty().WithMessage("Senha é obrigatório")
            .MinimumLength(8).WithMessage("Senha deve ter no minimo 8 caracteres!");
    }
}