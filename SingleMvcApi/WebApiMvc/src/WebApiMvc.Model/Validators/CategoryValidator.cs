using FluentValidation;

namespace WebApiMvc.Model.Validators;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {        
        RuleFor(r => r.Description).NotNull().NotEmpty();
    }
}
