using WebApiMvc.Model;
using WebApiMvc.Model.Interfaces;
using WebApiMvc.Services.Exceptions;
using WebApiMvc.Services.Interfaces;

namespace WebApiMvc.Services;

public class CategoryService : ICategoryService
{
    #region Properties

    private readonly ICategoryRepository _categoryRepository;

    #endregion

    #region Constructor

    public CategoryService(
        ICategoryRepository categoryRepository
        )
    {
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    #endregion

    #region Write Operations
    public async Task AddAsync(
        Category categoty
        )
    {
        var exists = await _categoryRepository.GetByIdAsync( categoty.Id );

        if (exists is not null)
            throw new EntityAlreadyExistsException("Category already exists.");

        await _categoryRepository.AddAsync(categoty);
        await _categoryRepository.CommitAsync();
    }

    public async Task UpdateAsync(
        Category categoty
        )
    {
        _categoryRepository.Update(categoty);
        await _categoryRepository.CommitAsync();
    }

    public async Task DeleteByIdAsync(
        Guid id
        )
    {
        _categoryRepository.DeleteById(id);
        await _categoryRepository.CommitAsync();

    }

    #endregion

    #region Read methods

    public async Task<Category> GetByIdAsync(
        Guid id
        )
        => await _categoryRepository.GetByIdAsync(id);

    public async Task<IEnumerable<Category>> GetByAll()
        => await _categoryRepository.GetAllAsync();

    public async Task<IEnumerable<Category>> GetByFilterAsync(
        string filter
        )
    =>
        await _categoryRepository.FilterAsync(p => p.Description.Contains(filter));
    #endregion
}
