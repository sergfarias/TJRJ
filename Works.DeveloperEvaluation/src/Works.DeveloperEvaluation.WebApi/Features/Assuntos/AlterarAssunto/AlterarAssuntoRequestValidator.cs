using Works.DeveloperEvaluation.Domain.Entities;
using Works.DeveloperEvaluation.WebApi.Features.Assuntos.AlterarAssunto;
using FluentValidation;
namespace Works.DeveloperEvaluation.WebApi.Features.Assuntos.AlterarAssunto;

/// <summary>
/// Validator for ModifiedProjectRequest that defines validation rules for ModifiedProject.
/// </summary>
public class AlterarAssuntoRequestValidator : AbstractValidator<AlterarAssuntoRequest>
{
    public AlterarAssuntoRequestValidator()
    {
        RuleFor(assunto => assunto.CodAs)
           .NotEmpty()
           .WithMessage("Código do sssunto é obrigatório");

        RuleFor(assunto => assunto.Descricao)
          .NotEmpty()
          .MaximumLength(40).WithMessage("Descrição não pode ser maior que 40 caracteres.");

        
    }
}