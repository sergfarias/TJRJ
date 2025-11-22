using Works.DeveloperEvaluation.Domain.Entities;
using Works.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Works.DeveloperEvaluation.Domain.Validation;

public class LivroValidator : AbstractValidator<Livro>
{
    public LivroValidator()
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
