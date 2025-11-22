using FluentValidation;
namespace Works.DeveloperEvaluation.WebApi.Features.Livros.InserirLivro;

/// <summary>
/// Validator for CreateProjectRequest that defines validation rules for project creation.
/// </summary>
public class InserirLivroRequestValidator : AbstractValidator<InserirLivroRequest>
{
    public InserirLivroRequestValidator()
    {
        RuleFor(livro => livro.Titulo)
          .NotEmpty()
          .MaximumLength(40).WithMessage("Título não pode ser maior que 40 caracteres.");

        RuleFor(livro => livro.Editora)
          .MaximumLength(40).WithMessage("Editora não pode ser maior que 40 caracteres.");

        RuleFor(livro => livro.AnoPublicacao)
         .MaximumLength(40).WithMessage("Ano publicação não pode ser maior que 4 caracteres.");

    }
}