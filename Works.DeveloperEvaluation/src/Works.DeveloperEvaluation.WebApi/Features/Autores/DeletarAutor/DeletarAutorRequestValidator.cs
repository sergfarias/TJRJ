using FluentValidation;
namespace Works.DeveloperEvaluation.WebApi.Features.Autores.DeletarAutor;

/// <summary>
/// Validator for DeleteProjectRequest
/// </summary>
public class DeletarAutorRequestValidator : AbstractValidator<DeletarAutorRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteProjectRequest
    /// </summary>
    public DeletarAutorRequestValidator()
    {
        RuleFor(x => x.CodAu)
            .NotEmpty()
            .WithMessage("Project ID is required");
    }
}
