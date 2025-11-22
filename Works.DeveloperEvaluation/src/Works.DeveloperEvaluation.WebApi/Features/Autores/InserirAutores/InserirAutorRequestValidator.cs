using Works.DeveloperEvaluation.WebApi.Features.Autores.InserirAutor;
using FluentValidation;
namespace Works.DeveloperEvaluation.WebApi.Features.Autors.InserirAutor;

/// <summary>
/// Validator for CreateProjectRequest that defines validation rules for project creation.
/// </summary>
public class InserirAutorRequestValidator : AbstractValidator<InserirAutorRequest>
{
    public InserirAutorRequestValidator()
    {
        RuleFor(livro => livro.Nome)
          .NotEmpty()
          .MaximumLength(40).WithMessage("Nome não pode ser maior que 40 caracteres.");

      
    }
}