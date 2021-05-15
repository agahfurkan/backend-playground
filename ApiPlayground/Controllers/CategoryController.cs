using System.Threading.Tasks;
using ApiPlayground.Entities;
using ApiPlayground.Models;
using ApiPlayground.Models.Dtos;
using ApiPlayground.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPlayground.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _iCategoryRepository;

        public CategoryController(ICategoryRepository iCategoryRepository)
        {
            _iCategoryRepository = iCategoryRepository;
        }

        [HttpPost("CreateNewCategory")]
        public async Task<ActionResult<GenericResponseModel>> CreateNewCategory(
            CreateNewCategoryDto createNewCategoryDto)
        {
            var tempItem = _iCategoryRepository.GetCategoryByName(createNewCategoryDto.CategoryName);
            if (tempItem != null)
                return Ok(new GenericResponseModel {IsSuccess = false, Message = "Category already exist!"});
            await _iCategoryRepository.AddAsync(new CategoryEntity {CategoryName = createNewCategoryDto.CategoryName});
            return Ok(new GenericResponseModel {IsSuccess = true, Message = "New Category Created Successfully."});
        }

        [HttpGet("GetAllCategories")]
        public async Task<ActionResult<GetAllCategoriesResponse>> GetAllCategories()
        {
            var categoryList = (await _iCategoryRepository.GetAllAsync()).ConvertAll(c => new Category
                {CategoryId = c.CategoryId, CategoryName = c.CategoryName});
            return Ok(new GetAllCategoriesResponse {IsSuccess = true, CategoryList = categoryList});
        }
    }
}