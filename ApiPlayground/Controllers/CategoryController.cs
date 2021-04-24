using System.Linq;
using System.Threading.Tasks;
using ApiPlayground.Entities;
using ApiPlayground.Models;
using ApiPlayground.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPlayground.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly DbContextClass _dbContext;

        public CategoryController(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("CreateNewCategory")]
        public async Task<ActionResult<GenericResponseModel>> CreateNewCategory(
            CreateNewCategoryDto createNewCategoryDto)
        {
            var tempItem =
                await _dbContext.Category.FirstOrDefaultAsync(c => c.CategoryName == createNewCategoryDto.CategoryName);
            if (tempItem != null)
                return Ok(new GenericResponseModel {IsSuccess = false, Message = "Category already exist!"});
            await _dbContext.Category.AddAsync(new CategoryEntity {CategoryName = createNewCategoryDto.CategoryName});
            await _dbContext.SaveChangesAsync();
            return Ok(new GenericResponseModel {IsSuccess = true, Message = "New Category Created Successfully."});
        }

        [HttpGet("GetAllCategories")]
        public ActionResult<GetAllCategoriesResponse> GetAllCategories()
        {
            var categoryList = _dbContext.Category.ToList().ConvertAll(c => new Category
                {CategoryId = c.CategoryId, CategoryName = c.CategoryName});
            return Ok(new GetAllCategoriesResponse {IsSuccess = true, CategoryList = categoryList});
        }
    }
}