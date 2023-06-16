using FluentValidation.Results;
using WebApiMvc.Model.Base;
using WebApiMvc.Model.Validators;

namespace WebApiMvc.Model;

public class ContactDetail : EntityBaseWithValidator<ContactDetailValidator, ContactDetail>
{
    #region Properties

    public Guid ContactId { get; private set; }
    public Contact Contact { get; private set; }
    public string Email { get; private set; }
    public string CelPhone { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Linkedin { get; private set; }

    #endregion

    #region Constructor

    public ContactDetail()
    {            
    }

    public ContactDetail(
        Guid id,
        Guid contactId, 
        Contact contact, 
        string email, 
        string celPhone, 
        string phoneNumber, 
        string linkedin) : base(id)
    {
        ContactId = contactId;
        Contact = contact;
        Email = email;
        CelPhone = celPhone;
        PhoneNumber = phoneNumber;
        Linkedin = linkedin;
    }

    #endregion

    #region Public Methods

    public void SetContactId(Guid id)
    { 
        ContactId = id;        
    }

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
