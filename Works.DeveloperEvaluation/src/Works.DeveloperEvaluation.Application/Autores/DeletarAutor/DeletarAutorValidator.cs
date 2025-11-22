using FluentValidation;
namespace Works.DeveloperEvaluation.Application.Autores.DeletarAutor;

/// <summary>
/// Validator for DeleteProjectCommand
/// </summary>
public class DeletarAutorValidator : AbstractValidator<DeletarAutorCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteProjectCommand
    /// </summary>
    public DeletarAutorValidator()
    {
        RuleFor(x => x.CodAu)
            .NotEmpty()
            .WithMessage("Código do autor é obrigatório.");
    }
}
