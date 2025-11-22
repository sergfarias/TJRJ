using FluentValidation;
namespace Works.DeveloperEvaluation.WebApi.Features.LivrosAutores.DeletarLivroAutor;

/// <summary>
/// Validator for DeleteProjectRequest
/// </summary>
public class DeletarLivroAutorRequestValidator : AbstractValidator<DeletarLivroAutorRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteProjectRequest
    /// </summary>
    public DeletarLivroAutorRequestValidator()
    {
        RuleFor(x => x.Livro_CodL)
            .NotEmpty()
            .WithMessage("Livro ID is required");


        RuleFor(x => x.Autor_CodAu)
            .NotEmpty()
            .WithMessage("Autor ID is required");
    }
}
