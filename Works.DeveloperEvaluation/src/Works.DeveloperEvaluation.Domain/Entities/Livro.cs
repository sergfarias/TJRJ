using Works.DeveloperEvaluation.Common.Security;
using Works.DeveloperEvaluation.Common.Validation;
using Works.DeveloperEvaluation.Domain.Common;
using Works.DeveloperEvaluation.Domain.Enums;
using Works.DeveloperEvaluation.Domain.Validation;
using System.ComponentModel.DataAnnotations;
namespace Works.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a livro in the system.
/// </summary>
public class Livro : ILivro //BaseEntity,
{
    [Key]
    public int CodL { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Editora { get; set; } = string.Empty;
    public int Edicao { get; set; }
    public string AnoPublicacao { get; set; } = string.Empty;


    int ILivro.CodL => CodL; 
    string ILivro.Titulo => Titulo;
    string ILivro.Editora => Editora;
    int ILivro.Edicao => Edicao;
    string ILivro.AnoPublicacao => AnoPublicacao;


    /// <summary>
    /// Performs validation of the user entity using the ProjectValidator rules.
    /// </summary>
    public ValidationResultDetail Validate()
    {
        var validator = new LivroValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

}