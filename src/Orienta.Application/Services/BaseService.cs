// using System.Security.Claims;
// using application.Dtos.Error;
// using application.Exceptions;
// using FluentValidation;
// using FluentValidation.Results;
// using Orienta.Application.Utils;

// namespace application.Services;

// public class BaseService
// {
//     private readonly IUserInfo _user;
//     public BaseService(IUserInfo user)
//     {
//         _user = user;
//     }
//     // protected static void Validate<TV, TM>(TV validacao, TM viewModel) where TV : AbstractValidator<TM>
//     // {
//     //     var validador = validacao.Validate(viewModel);

//     //     if (validador.IsValid) return;

//     //     var errors = ProcessErrors(validador);

//     //     throw CustomException.ErroValidacao(errors);
//     // }

//     // protected static async Task ValidateAsync<TV, TM>(TV validacao, TM viewModel) where TV : AbstractValidator<TM>
//     // {
//     //     var validador = await validacao.ValidateAsync(viewModel);

//     //     if (validador.IsValid) return;

//     //     var errors = ProcessErrors(validador);

//     //     throw CustomException.ErroValidacao(errors);
//     // }

//     // private static IEnumerable<ErrorDto> ProcessErrors(ValidationResult result)
//     // {
//     //     return result.Errors.Select(e => new ErrorDto
//     //     {
//     //         Error = e.ErrorMessage,
//     //         ErrorCode = e.ErrorCode,
//     //         Property = e.PropertyName
//     //     });
//     // }

//     protected string GetUserSlug()
//     {
//         var claims = _user.GetClaims();
//         var claimUserSlug = claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid);
//         return claimUserSlug?.Value;
//     }
// }