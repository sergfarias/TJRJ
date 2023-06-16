using FluentValidation.Results;
using WebApiMvc.Model.Base;
using WebApiMvc.Model.Validators;

namespace WebApiMvc.Model;

public class Category : EntityBaseWithValidator<CategoryValidator, Category>
{
    #region Properties    

    public string Description { get; private set; }

    #endregion

    #region Constructor

    public Category(Guid id, string description) : base(id)
    {
        Description = description;
    }

    #endregion

    #region Validators

    public bool IsValid()
        => IsValid(this);

    public bool IsInvalid()
    => !IsValid();

    public List<ValidationFailure> GetErrors()
    => GetErrors(this);

    public List<string> GetStringErrors()
        => GetStringErrors(this);


    #endregion

}