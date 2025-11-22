using Works.DeveloperEvaluation.Common.Security;
using Works.DeveloperEvaluation.Common.Validation;
using Works.DeveloperEvaluation.Domain.Validation;
using System.ComponentModel.DataAnnotations;
namespace Works.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a Autor in the system.
/// </summary>
public class Assunto : IAssunto //BaseEntity,
{
    [Key]
    public int CodAs { get; set; }

    public string Descricao { get; set; } = string.Empty;

    int IAssunto.CodAs =>   CodAs;
    string IAssunto.Descricao =>   Descricao;

    /// <summary>
    /// Performs validation of the user entity using the ProjectValidator rules.
    /// </summary>
    public ValidationResultDetail Validate()
    {
        var validator = new AssuntoValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}