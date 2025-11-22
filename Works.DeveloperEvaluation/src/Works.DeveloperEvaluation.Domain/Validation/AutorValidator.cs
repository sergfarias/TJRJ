using Works.DeveloperEvaluation.Domain.Entities;
using Works.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Works.DeveloperEvaluation.Domain.Validation;

public class AutorValidator : AbstractValidator<Autor>
{
    public AutorValidator()
    {
        RuleFor(autor => autor.Nome)
          .NotEmpty()
          .MaximumLength(40).WithMessage("Nome autor não pode ser maior que 40 caracteres.");

    }
}
