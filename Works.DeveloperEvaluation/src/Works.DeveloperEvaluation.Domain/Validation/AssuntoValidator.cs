using Works.DeveloperEvaluation.Domain.Entities;
using Works.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Works.DeveloperEvaluation.Domain.Validation;

public class AssuntoValidator : AbstractValidator<Assunto>
{
    public AssuntoValidator()
    {
        RuleFor(assunto => assunto.Descricao)
          .NotEmpty()
          .MaximumLength(40).WithMessage("Descrição do assunto não pode ser maior que 20 caracteres.");

    }
}
