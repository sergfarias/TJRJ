using FluentValidation;
namespace Works.DeveloperEvaluation.WebApi.Features.Livros.AlterarLivro;

/// <summary>
/// Validator for ModifiedProjectRequest that defines validation rules for ModifiedProject.
/// </summary>
public class AlterarLivroRequestValidator : AbstractValidator<AlterarLivroRequest>
{
    public AlterarLivroRequestValidator()
    {
        RuleFor(livro => livro.CodL)
           .NotEmpty()
           .WithMessage("Código do livro é obrigatório");

        RuleFor(livro => livro.Titulo)
          .NotEmpty()
          .MaximumLength(40).WithMessage("Título não pode ser maior que 40 caracteres.");

        RuleFor(livro => livro.Editora)
          .MaximumLength(40).WithMessage("Editora não pode ser maior que 40 caracteres.");

        RuleFor(livro => livro.AnoPublicacao)
         .MaximumLength(40).WithMessage("Ano publicação não pode ser maior que 4 caracteres.");

    }
}