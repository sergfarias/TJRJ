using Works.DeveloperEvaluation.Common.Security;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Works.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a livro in the system.
/// </summary>
public class LivroAssunto : ILivroAssunto //BaseEntity,
{
    public int Livro_CodL { get; set; }

    public int Assunto_CodAs { get; set; }

    public Livro Livro { get; set; }

    public Assunto Assunto { get; set; }


    int ILivroAssunto.Livro_CodL => Livro_CodL;
    int ILivroAssunto.Assunto_CodAs => Assunto_CodAs;

    

    /// <summary>
    /// Performs validation of the user entity using the ProjectValidator rules.
    /// </summary>
    //public ValidationResultDetail Validate()
    //{
    //    var validator = new LivroValidator();
    //    var result = validator.Validate(this);
    //    return new ValidationResultDetail
    //    {
    //        IsValid = result.IsValid,
    //        Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
    //    };
    //}

}