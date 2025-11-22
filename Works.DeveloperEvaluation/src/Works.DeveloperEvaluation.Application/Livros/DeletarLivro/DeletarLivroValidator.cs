using FluentValidation;
namespace Works.DeveloperEvaluation.Application.Livros.DeletarLivro;

/// <summary>
/// Validator for DeleteProjectCommand
/// </summary>
public class DeletarLivroValidator : AbstractValidator<DeletarLivroCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteProjectCommand
    /// </summary>
    public DeletarLivroValidator()
    {
        RuleFor(x => x.CodL)
            .NotEmpty()
            .WithMessage("Código do livro é obrigatório.");
    }
}
