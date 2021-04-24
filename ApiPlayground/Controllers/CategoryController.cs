using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPlayground.Entities;
using ApiPlayground.Models;
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
        public async Task<IActionResult> CreateNewCategory(CreateNewCategoryDto createNewCategoryDto)
        {
            var tempItem =
                await _dbContext.Category.FirstOrDefaultAsync(c => c.CategoryName == createNewCategoryDto.CategoryName);
            if (tempItem != null) return Ok(new ResponseModel {Code = -1, Message = "Category already exist!"});
            await _dbContext.Category.AddAsync(new Category {CategoryName = createNewCategoryDto.CategoryName});
            await _dbContext.SaveChangesAsync();
            return Ok(new ResponseModel {Code = 1, Message = "New Category Created Successfully."});
        }

        [HttpGet("GetAllCategories")]
        public List<Category> GetAllCategories()
        {
            return _dbContext.Category.ToList();
        }
    }
}