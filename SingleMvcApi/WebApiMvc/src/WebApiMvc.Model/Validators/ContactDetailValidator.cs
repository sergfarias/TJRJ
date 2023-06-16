using FluentValidation;

namespace WebApiMvc.Model.Validators;

public class ContactDetailValidator : AbstractValidator<ContactDetail>
{
    public ContactDetailValidator()
    {        
        RuleFor(r => r.ContactId).NotNull();
        RuleFor(r => r.Email).EmailAddress().When(r => ! String.IsNullOrEmpty(r.Email));
        RuleFor(r => r.CelPhone).NotNull().NotEmpty();        
    }
}
