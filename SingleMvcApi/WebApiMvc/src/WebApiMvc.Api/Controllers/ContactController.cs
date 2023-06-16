using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiMvc.Api.Controllers.Base;
using WebApiMvc.Api.ViewModels;
using WebApiMvc.Model;
using WebApiMvc.Services.Exceptions;
using WebApiMvc.Services.Interfaces;

namespace WebApiMvc.Api.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContactController : ApiBase
    {
        #region Properties

        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public ContactController(
            IMapper mapper,
            IContactService contactService
            )
        {
            _mapper = mapper;
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
        }

        #endregion

        #region Write Operations

        [HttpPost(Name = "AddContact")]
        public async Task<IActionResult> AddContactAsync(
            ContactViewModel contact
            )
        {
            var contactSave = _mapper.Map<Contact>(contact);

            if (contactSave.IsInvalid())
                return BadRequest(contactSave.GetErrors());

            try
            {
                await _contactService.AddAsync(contactSave);
            }
            catch (EntityAlreadyExistsException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(_mapper.Map<ContactViewModel>(contactSave));

        }

        [HttpPost("addcontactdetail/{id}", Name = "AddContactDetail")]
        public async Task<IActionResult> AddContactDetailAsync(
            Guid id,
            ContactDetailViewModel contactDetail
            )
        {

            try
            {
                await _contactService.AddContactDetailAsync(id, _mapper.Map<ContactDetail>(contactDetail));
            }
            catch (EntityNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (EntityValidatorException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (EntityAlreadyExistsException ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok();

        }


        [HttpPut(Name = "UpdateContact")]
        public async Task<IActionResult> UpdateContactAsync(
            ContactViewModel contact
            )
        {
            var contactSave = _mapper.Map<Contact>(contact);

            if (contactSave.IsInvalid())
                return BadRequest(contactSave.GetErrors());

            await _contactService.UpdateAsync(contactSave);

            return Ok(_mapper.Map<ContactViewModel>(contactSave));

        }

        [HttpDelete(Name = "DeleteContact")]
        public async Task<IActionResult> DeleteContactAsync(
            Guid id
            )
        {
            await _contactService.DeleteByIdAsync(id);

            return Ok();
        }

        [HttpDelete("contactid/{idContact}/contactdetailid/{idContactDetail}", Name = "DeleteContactDetail")]
        public async Task<IActionResult> DeleteContactDetailAsync(
            Guid idContact,
            Guid idContactDetail
            )
        {
            await _contactService.DeleteContactDetailAsync(idContact, idContactDetail);

            return Ok();
        }


        [HttpPatch("activecontact/{id}", Name = "ActiveContact")]
        public async Task<IActionResult> ActiveContactAsync(
            Guid id
            )
        {
            await _contactService.ActiveContactAsync(id);

            return Ok();
        }


        [HttpPatch("contactid/{idContact}/applycategory/{idCategory}", Name = "ApplyCategory")]
        public async Task<IActionResult> ActiveContactAsync(
            Guid idContact,
            Guid idCategory
            )
        {
            await _contactService.ApplyCategoryAsync(idContact, idCategory);

            return Ok();
        }


        [HttpPatch("inactivecontact/{id}", Name = "InactiveContact")]
        public async Task<IActionResult> InactiveContactAsync(
            Guid id
            )
        {
            await _contactService.InactiveContactAsync(id);

            return Ok();
        }



        #endregion

        #region GETs operations

        [HttpGet(Name = "GetAllContacts")]
        public async Task<IActionResult> GetAllContactsAsync()
        {
            var result = await _contactService.GetByAll();

            return !result.Any() ? NotFound() : Ok(_mapper.Map<List<ContactViewModel>>(result));
        }


        [HttpGet("{id}", Name = "GetContactById")]
        public async Task<IActionResult> GetCotactByIdAsync(
            Guid id
            )
        {
            var result = await _contactService.GetByIdAsync(id);

            return result == null ? NotFound() : Ok(_mapper.Map<ContactViewModel>(result));

        }

        [HttpGet("/byname/{filter}", Name = "GetAllContactsByNameAsync")]
        public async Task<IActionResult> GetAllContactsByNameAsync(
            string filter
            )
        {
            if (string.IsNullOrEmpty(filter))
                return BadRequest("Filter is mandatory.");

            var result = await _contactService.GetByNameAsync(filter);

            return result == null ? NotFound() : Ok(_mapper.Map<ContactViewModel>(result));

        }

        #endregion


    }
}
