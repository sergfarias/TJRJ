using FluentValidation;
namespace Works.DeveloperEvaluation.Application.LivrosAutores.DeletarLivroAutor;

/// <summary>
/// Validator for DeleteProjectCommand
/// </summary>
public class DeletarLivroAutorValidator : AbstractValidator<DeletarLivroAutorCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteProjectCommand
    /// </summary>
    public DeletarLivroAutorValidator()
    {
        RuleFor(x => x.Livro_CodL)
            .NotEmpty()
            .WithMessage("Código do livro é obrigatório.");

        RuleFor(x => x.Autor_CodAu)
            .NotEmpty()
            .WithMessage("Código do autor é obrigatório.");
    }
}
