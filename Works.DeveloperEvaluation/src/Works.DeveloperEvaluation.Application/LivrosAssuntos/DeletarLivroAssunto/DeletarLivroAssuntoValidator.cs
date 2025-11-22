using FluentValidation;
namespace Works.DeveloperEvaluation.Application.LivrosAssuntos.DeletarLivroAssunto;

/// <summary>
/// Validator for DeleteProjectCommand
/// </summary>
public class DeletarLivroAssuntoValidator : AbstractValidator<DeletarLivroAssuntoCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteProjectCommand
    /// </summary>
    public DeletarLivroAssuntoValidator()
    {
        RuleFor(x => x.Livro_CodL)
            .NotEmpty()
            .WithMessage("Código do livro é obrigatório.");

        RuleFor(x => x.Assunto_CodAs)
            .NotEmpty()
            .WithMessage("Código do assunto é obrigatório.");
    }
}
