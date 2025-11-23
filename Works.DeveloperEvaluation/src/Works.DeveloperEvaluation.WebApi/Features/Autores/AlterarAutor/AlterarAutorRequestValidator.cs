using FluentValidation;
namespace Works.DeveloperEvaluation.WebApi.Features.Autores.AlterarAutor;

/// <summary>
/// Validator for ModifiedProjectRequest that defines validation rules for ModifiedProject.
/// </summary>
public class AlterarAutorRequestValidator : AbstractValidator<AlterarAutorRequest>
{
    public AlterarAutorRequestValidator()
    {
        RuleFor(livro => livro.CodAu)
           .NotEmpty()
           .WithMessage("Código do autor é obrigatório");

        RuleFor(livro => livro.Nome)
          .NotEmpty()
          .MaximumLength(40).WithMessage("Nome não pode ser maior que 40 caracteres.");

       
    }
}