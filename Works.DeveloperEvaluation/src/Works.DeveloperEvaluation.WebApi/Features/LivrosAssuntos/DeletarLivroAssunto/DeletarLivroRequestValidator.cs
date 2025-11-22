using FluentValidation;
namespace Works.DeveloperEvaluation.WebApi.Features.LivrosAssuntos.DeletarLivroAssunto;

/// <summary>
/// Validator for DeleteProjectRequest
/// </summary>
public class DeletarLivroAssuntoRequestValidator : AbstractValidator<DeletarLivroAssuntoRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteProjectRequest
    /// </summary>
    public DeletarLivroAssuntoRequestValidator()
    {
        RuleFor(x => x.Livro_CodL)
            .NotEmpty()
            .WithMessage("Livro ID is required");


        RuleFor(x => x.Assunto_CodAs)
            .NotEmpty()
            .WithMessage("Assunto ID is required");
    }
}
