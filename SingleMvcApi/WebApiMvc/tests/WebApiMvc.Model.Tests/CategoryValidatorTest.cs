using FluentAssertions;
using WebApiMvc.Model.Tests._02_Fixtures;

namespace WebApiMvc.Model.Tests;

[Collection(nameof(CategoryCollection))]
public class CategoryValidatorTest
{
    private readonly CategoryTestFixture _categoryTestFixture;

    public CategoryValidatorTest(
        CategoryTestFixture categoryTestFixture
        )
    {
        _categoryTestFixture = categoryTestFixture;
    }


    [TraitAttribute("Category", "Unity tests for category.")]
    [Fact(DisplayName = "A Valid Category")]
    public void A_Valid_Category()
    {
        // Arrange

        var obj = _categoryTestFixture.GenerateValidCategory();

        // Action

        var result = obj.IsValid();

        // Assert

        result.Should()
              .BeTrue();

    }


    [TraitAttribute("Category", "Unity tests for category.")]
    [Theory(DisplayName = "Invalid descriptions")]
    [InlineData(null)]
    [InlineData("")]
    public void A_Invalid_Category(string description)
    {
        // Arrange

        var obj = _categoryTestFixture.GenerateInvalidCategory();

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