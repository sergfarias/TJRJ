using FluentValidation;
using FluentValidation.Results;

namespace WebApiMvc.Model.Base;

public abstract class EntityBaseWithValidator<TValidator, T>
                where TValidator : IValidator
{
    #region Properties

    private readonly IValidator validator = Activator.CreateInstance<TValidator>();    

    public Guid Id { get; private set; }

    #endregion

    #region Constructor

    protected EntityBaseWithValidator()
        => Id = Guid.NewGuid();

    protected EntityBaseWithValidator(
        Guid id
        )
    {
        Id = id;
    }

    #endregion

    #region Validate Methods
    protected virtual bool IsValid(
        T instance
        ) 
    {
        IValidationContext validationContext = new ValidationContext<T>(instance);
        var result = validator.Validate(validationContext);
        return result.IsValid;
    }

    protected List<string> GetStringErrors(
        T instance
        )
    {
        IValidationContext validationContext = new ValidationContext<T>(instance);
        var results = validator.Validate(validationContext);

        List<string> err = new();

        if (!results.IsValid)
            foreach (var item in results.Errors)
                err.Add(item.ErrorMessage);

        return err;
    }

    protected List<ValidationFailure> GetErrors(
        T instance
        )
    {
        IValidationContext validationContext = new ValidationContext<T>(instance);
        var result = validator.Validate(validationContext);
        return result.Errors;
    }

    #endregion



}
