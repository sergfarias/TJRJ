using FluentValidation;
namespace Works.DeveloperEvaluation.Application.Assuntos.DeletarAssunto;

/// <summary>
/// Validator for DeleteProjectCommand
/// </summary>
public class DeletarAssuntoValidator : AbstractValidator<DeletarAssuntoCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteProjectCommand
    /// </summary>
    public DeletarAssuntoValidator()
    {
        RuleFor(x => x.CodAs)
            .NotEmpty()
            .WithMessage("Código do assunto é obrigatório.");
    }
}
