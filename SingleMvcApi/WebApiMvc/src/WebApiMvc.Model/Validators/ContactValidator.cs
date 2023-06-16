using FluentValidation;

namespace WebApiMvc.Model.Validators;

public class ContactValidator : AbstractValidator<Contact>
{
    public ContactValidator()
    {
        RuleFor(r => r.CategoryId).NotEmpty();
        RuleFor(r => r.Category.Description).NotNull().NotEmpty().When(r => r.Category is not null);
        RuleFor(r => r.Name).NotNull().NotEmpty();
        RuleFor(r => r.Address).NotNull();
        RuleFor(r => r.Address.Address).NotNull().NotEmpty().When(r => r.Address is not null);

    }
}
