using FluentValidation;
namespace Works.DeveloperEvaluation.WebApi.Features.Assuntos.DeletarAssunto;

/// <summary>
/// Validator for DeleteProjectRequest
/// </summary>
public class DeletarAssuntoRequestValidator : AbstractValidator<DeletarAssuntoRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteProjectRequest
    /// </summary>
    public DeletarAssuntoRequestValidator()
    {
        RuleFor(x => x.CodAs)
            .NotEmpty()
            .WithMessage("Assunto ID is required");
    }
}
