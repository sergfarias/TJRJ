using Bogus;
using WebApiMvc.Model.Enums;
using WebApiMvc.Model.ObjectValue;

namespace WebApiMvc.Model.Tests._02_Fixtures;

[CollectionDefinition(nameof(ContactCollection))]

public class ContactCollection : ICollectionFixture<ContactTestFixture> { }
public class ContactTestFixture : IDisposable
{
    private readonly CategoryTestFixture _categoryTestFixture;


    public ContactTestFixture()
    {
        _categoryTestFixture = new CategoryTestFixture();
    }
    public Contact GenerateValidContact()
    {
        var category = _categoryTestFixture.GenerateValidCategory();
        var contact = new Faker<Contact>("pt_BR")
                               .CustomInstantiator(f => new Contact(Guid.NewGuid(), 
                                                                    category.Id,
                                                                    category,
                                                                    f.Person.FullName,
                                                                    EStatus.Active,
                                                                    new AddressDetail(
                                                                        f.Address.StreetAddress(),
                                                                        f.Address.BuildingNumber(),
                                                                        f.Address.StreetSuffix(),
                                                                        f.Address.City(),
                                                                        f.Address.State(),
                                                                        f.Address.ZipCode()
                                                                    )));      
        return contact;
    }

    public Contact GenerateInvalidContactAddress()
    {
        var category = _categoryTestFixture.GenerateValidCategory();
        var contact = new Faker<Contact>("pt_BR")
                               .CustomInstantiator(f => new Contact(Guid.NewGuid(),
                                                                    category.Id,
                                                                    category,
                                                                    f.Person.FullName,
                                                                    EStatus.Active,
                                                                    null
                                                                    ));
        return contact;
    }


    public Contact GenerateInvalidContactCategory()
    {
        var category = _categoryTestFixture.GenerateInvalidCategory();
        var contact = new Faker<Contact>("pt_BR")
                               .CustomInstantiator(f => new Contact(Guid.NewGuid(),
                                                                    category.Id,
                                                                    category,
                                                                    f.Person.FullName,
                                                                    EStatus.Active,
                                                                    new AddressDetail(
                                                                        f.Address.StreetAddress(),
                                                                        f.Address.BuildingNumber(),
                                                                        f.Address.StreetSuffix(),
                                                                        f.Address.City(),
                                                                        f.Address.State(),
                                                                        f.Address.ZipCode()
                                                                    )));
        return contact;
    }

    public void Dispose()
    {
        _categoryTestFixture.Dispose();        
    }
}
