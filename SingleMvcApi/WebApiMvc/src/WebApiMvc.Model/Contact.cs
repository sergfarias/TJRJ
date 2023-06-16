using FluentValidation.Results;
using WebApiMvc.Model.Base;
using WebApiMvc.Model.Enums;
using WebApiMvc.Model.ObjectValue;
using WebApiMvc.Model.Validators;

namespace WebApiMvc.Model;

public class Contact : EntityBaseWithValidator<ContactValidator, Contact>
{
    #region Properties

    public EStatus Status { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }
    public string Name { get; private set; }
    public AddressDetail Address { get; private set; }
    public List<ContactDetail> ContactsDetails { get; private set; }

    #endregion

    #region Constructor
    public Contact()
    {            
    }

    public Contact(
        Guid id,
        Guid categoryId,
        Category category,
        string name,
        EStatus status,
        AddressDetail address) : base(id)
    {
        Name = name;
        Status = status;
        CategoryId = categoryId;
        Category = category;
        Address = address;
        ContactsDetails = new List<ContactDetail>();
    }

    #endregion

    #region Validator Methods

    public bool IsValid()
        => IsValid(this);

    public bool IsInvalid()
    => !IsValid();

    public List<ValidationFailure> GetErrors()
    => GetErrors(this);

    public List<string> GetStringErrors()
        => GetStringErrors(this);

    #endregion

    #region Public Methods

    public void ActiveContact()
        => Status = EStatus.Active;

    public void InactiveContact()
        => Status = EStatus.Inactive;

    public void ApplyCategory(Category category)
        => Category = category;


    #endregion
}
