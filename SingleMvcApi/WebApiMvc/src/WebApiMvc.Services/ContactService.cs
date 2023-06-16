using WebApiMvc.Model;
using WebApiMvc.Model.Extensions;
using WebApiMvc.Model.Interfaces;
using WebApiMvc.Repository;
using WebApiMvc.Services.Exceptions;
using WebApiMvc.Services.Interfaces;

namespace WebApiMvc.Services;

public class ContactService : IContactService
{
    #region Properties

    private readonly IContactRepository _contactRepository;
    private readonly IContactDetailRepository _contactDetailRepository;
    private readonly ICategoryService _categoryService;

    #endregion

    #region Constructor

    public ContactService(
        IContactRepository contactRepository,
        IContactDetailRepository contactDetailRepository,
        ICategoryService categoryService
        )
    {
        _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        _contactDetailRepository = contactDetailRepository ?? throw new ArgumentNullException( nameof(contactDetailRepository));
        _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
    }

    #endregion

    #region Write operations
    public async Task AddAsync(
        Contact contact
        )
    {
        await ValidateAddContactAsync(contact);

        await _contactRepository.AddAsync(contact);
        await _contactRepository.CommitAsync();
    }


    public async Task UpdateAsync(
        Contact contact
        )
    {
        _contactRepository.Update(contact);
        await _contactRepository.CommitAsync();
    }
    public async Task DeleteByIdAsync(
        Guid id
        )
    {
        _contactRepository.DeleteById(id);
        await _contactRepository.CommitAsync();

    }
    public async Task ActiveContactAsync(
        Guid id
        )
    {
        var contact = await GetByIdAsync(id);

        if (contact is null)
            return;

        contact.ActiveContact();
        await _contactRepository.CommitAsync();

    }

    public async Task InactiveContactAsync(
        Guid id
        )
    {
        var contact = await GetByIdAsync(id);

        if (contact is null)
            return;

        contact.InactiveContact();
        await _contactRepository.CommitAsync();

    }

    public async Task AddContactDetailAsync(
        Guid id, 
        ContactDetail detail
        )
    {
        await ValidateAddContactDetailAsync(id, detail);

        detail.SetContactId(id);

        await _contactDetailRepository.AddAsync(detail);
        await _contactDetailRepository.CommitAsync();

    }


    public async Task DeleteContactDetailAsync(
        Guid id,
        Guid idDetail
        )
    {
        var contactDetal = await _contactDetailRepository.Filter(p => p.ContactId == id 
                                                                   && p.Id == idDetail);

        if (contactDetal is null)
            return;        

        _contactDetailRepository.DeleteById(idDetail);
        await _contactDetailRepository.CommitAsync();

    }


    public async Task ApplyCategoryAsync(
        Guid id, 
        Guid idCategory
        )
    {
        var contact = await GetByIdAsync(id);

        Category categoryExists = await ValidateApplyCategoryAsync(idCategory, contact);

        contact.ApplyCategory(categoryExists);

        _contactRepository.Update(contact);
        await _contactRepository.CommitAsync();

    }


    #endregion

    #region Read operations

    public async Task<Contact> GetByIdAsync(
        Guid id
        )
        => await _contactRepository.GetByIdAsync(id);

    public async Task<IEnumerable<Contact>> GetByAll()
        => await _contactRepository.GetAllAsync();

    public async Task<IEnumerable<Contact>> GetByNameAsync(
        string filter
        )
    =>
        await _contactRepository.FilterAsync(p => p.Name.Contains(filter));

    #endregion


    #region Private methods

    private async Task ValidateAddContactDetailAsync(
        Guid id, 
        ContactDetail detail
        )
    {
        var contact = await GetByIdAsync(id);

        if (contact is null)
            throw new EntityNotFoundException("Contact not found");

        if (detail is null || detail.IsInvalid())
            throw new EntityValidatorException($"Invalid Contact detail: {detail.GetStringErrors()} ");

        var addressExists = contact.ContactsDetails
                                   .Any(p => p.Id == detail.Id);

        if (addressExists)
            throw new EntityAlreadyExistsException("Address already exists.");
    }


    private async Task ValidateAddContactAsync(
        Contact contact
        )
    {
        var existsContact = await _contactRepository.GetByIdAsync(contact.Id);

        if (existsContact is not null)
            throw new EntityAlreadyExistsException("Contact already exists.");

        var existsCategory = await _categoryService.GetByIdAsync(contact.CategoryId);

        if (existsCategory is null)
            throw new EntityNotFoundException("Category not found.");
    }


    private async Task<Category> ValidateApplyCategoryAsync(
        Guid idCategory, 
        Contact contact
        )
    {
        if (contact is null)
            throw new EntityNotFoundException("Contact not found");

        var categoryExists = await _categoryService.GetByIdAsync(idCategory);

        if (categoryExists is null)
            throw new EntityNotFoundException("Category not found");
        return categoryExists;
    }



    #endregion

}
