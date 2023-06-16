using Bogus;

namespace WebApiMvc.Model.Tests._02_Fixtures;

[CollectionDefinition(nameof(CategoryCollection))]

public class CategoryCollection : ICollectionFixture<CategoryTestFixture> { }
public class CategoryTestFixture : IDisposable
{
    public Category GenerateValidCategory()
    {
        var category = new Faker<Category>("pt_BR")
                               .CustomInstantiator(f =>  new Category(Guid.NewGuid(), f.Commerce.Department(1))
                               );      
        return category;
    }

    public Category GenerateInvalidCategory()
    {
        var category = new Faker<Category>("pt_BR")
                               .CustomInstantiator(f => new Category(Guid.NewGuid(), null)
                               );
        return category;
    }

    public void Dispose()
    {
        
    }
}
