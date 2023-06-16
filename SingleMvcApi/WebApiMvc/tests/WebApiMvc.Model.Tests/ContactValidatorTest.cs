using FluentAssertions;
using WebApiMvc.Model.Enums;
using WebApiMvc.Model.ObjectValue;
using WebApiMvc.Model.Tests._02_Fixtures;

namespace WebApiMvc.Model.Tests;

[Collection(nameof(ContactCollection))]
public class ContactValidatorTest
{
    private readonly ContactTestFixture _contactTestFixture;

    public ContactValidatorTest(
        ContactTestFixture contactTestFixture
        )
    {
        _contactTestFixture = contactTestFixture;
    }

    [TraitAttribute("Contact", "Unity tests for contact.")]
    [Fact(DisplayName = "A valid contact")]
    public void ValidContactTest()
    {
        // Arrange

        var obj = _contactTestFixture.GenerateValidContact();

        // Action

        var result = obj.IsValid();

        // Assert

        Assert.True(result);

        //result.Should()
        //      .BeTrue();

    }


    [TraitAttribute("Contact", "Unity tests for contact.")]
    [Fact(DisplayName = "A invalid contact (address)")]
    public void Invalid_Contact_Adress_Test()
    {
        // Arrange

        var obj = _contactTestFixture.GenerateInvalidContactAddress();

        // Action

        var resultIsValid = obj.IsValid();
        var resultIsInvalid = obj.IsInvalid();

        // Assert

        resultIsValid.Should()
                     .BeFalse();

        resultIsInvalid.Should()
                       .BeTrue();


    }

    [TraitAttribute("Contact", "Unity tests for contact.")]
    [Fact(DisplayName = "A invalid contact (category)")]
    public void Invalid_Contact_Category_Test()
    {
        // Arrange

        var obj = _contactTestFixture.GenerateInvalidContactCategory();

        // Action

        var resultIsValid = obj.IsValid();
        var resultIsInvalid = obj.IsInvalid();

        // Assert

        resultIsValid.Should()
                     .BeFalse();

        resultIsInvalid.Should()
                       .BeTrue();


    }



}