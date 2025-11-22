using FluentValidation;
namespace Works.DeveloperEvaluation.WebApi.Features.Livros.DeletarLivro;

/// <summary>
/// Validator for DeleteProjectRequest
/// </summary>
public class DeletarLivroRequestValidator : AbstractValidator<DeletarLivroRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteProjectRequest
    /// </summary>
    public DeletarLivroRequestValidator()
    {
        RuleFor(x => x.CodL)
            .NotEmpty()
            .WithMessage("Project ID is required");
    }
}
