using Works.DeveloperEvaluation.WebApi.Features.Livros.InserirLivro;
using FluentValidation;
namespace Works.DeveloperEvaluation.WebApi.Features.Assuntos.InserirAssunto;

/// <summary>
/// Validator for CreateProjectRequest that defines validation rules for project creation.
/// </summary>
public class InserirAssuntoRequestValidator : AbstractValidator<InserirAssuntoRequest>
{
    public InserirAssuntoRequestValidator()
    {
        RuleFor(assunto => assunto.Descricao)
          .NotEmpty()
          .MaximumLength(40).WithMessage("Descrição não pode ser maior que 40 caracteres.");
    }
}