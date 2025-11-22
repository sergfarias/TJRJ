using Works.DeveloperEvaluation.Common.Security;
using Works.DeveloperEvaluation.Common.Validation;
using Works.DeveloperEvaluation.Domain.Common;
using Works.DeveloperEvaluation.Domain.Enums;
using Works.DeveloperEvaluation.Domain.Validation;
using System.ComponentModel.DataAnnotations;
namespace Works.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a Autor in the system.
/// </summary>
public class Autor : IAutor //,BaseEntity
{
    [Key]
    public int CodAu { get; set; }

    public string Nome { get; set; } = string.Empty;

    int IAutor.CodAu =>     CodAu;
    string IAutor.Nome => Nome;

    /// <summary>
    /// Performs validation of the user entity using the ProjectValidator rules.
    /// </summary>
    public ValidationResultDetail Validate()
    {
        var validator = new AutorValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}