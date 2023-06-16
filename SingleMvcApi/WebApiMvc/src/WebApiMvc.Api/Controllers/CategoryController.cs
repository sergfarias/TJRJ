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
    public class CategoryController : ApiBase
    {
        #region Properties

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public CategoryController(
            IMapper mapper,
            ICategoryService categoryService
            )
        {
            _mapper = mapper;
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        #endregion

        #region Write Operations

        [HttpPost(Name = "AddCategory")]
        public async Task<IActionResult> SaveCategoryAsync(
            CategoryViewModel category
            )
        {
            var categorySave = _mapper.Map<Category>(category);

            if (categorySave.IsInvalid())
                return BadRequest(categorySave.GetErrors());

            try
            {
                await _categoryService.AddAsync(categorySave);
            }
            catch (EntityAlreadyExistsException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(_mapper.Map<CategoryViewModel>(categorySave));

        }

        [HttpPut(Name = "UpdateCategory")]
        public async Task<IActionResult> UpdateCategoryAsync(
            CategoryViewModel category
            )
        {
            var categorySave = _mapper.Map<Category>(category);

            if (categorySave.IsInvalid())
                return BadRequest(categorySave.GetErrors());

            await _categoryService.UpdateAsync(categorySave);

            return Ok(_mapper.Map<CategoryViewModel>(categorySave));

        }

        [HttpDelete(Name = "DeleteCategory")]
        public async Task<IActionResult> DeleteCategoryAsync(
            Guid id
            )
        {
            await _categoryService.DeleteByIdAsync(id);

            return Ok();
        }


        #endregion

        #region GETs operations

        [HttpGet(Name = "GetAllCategories")]
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
            => _mapper.Map<IEnumerable<Category>>(await _categoryService.GetByAll());


        [HttpGet("{id}", Name = "GetCategoryById")]
        public async Task<IActionResult> GetCategoriesByIdAsync(
            Guid id
            )
        {
            var result = await _categoryService.GetByIdAsync(id);

            return result == null ? NotFound() : Ok(result);

        }

        [HttpGet("/bydescription/{filter}", Name = "GetAllCategoriesByFilter")]
        public async Task<IActionResult> GetAllCategoriesByFilterAsync(
            string filter
            )
        {
            if (string.IsNullOrEmpty(filter))
                return BadRequest("Filter is mandatory.");

            return Ok(_mapper.Map<IEnumerable<Category>>(await _categoryService.GetByFilterAsync(filter)));
        }

        #endregion


    }
}
