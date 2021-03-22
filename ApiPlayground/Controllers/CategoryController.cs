using System.Threading.Tasks;
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
        public async Task<IActionResult> CreateNewCategory(Category category)
        {
            var tempItem = await _dbContext.Category.FirstOrDefaultAsync(c => c.CategoryName == category.CategoryName);
            if (tempItem != null) return Ok(new ResponseModel {Code = -1, Message = "Category already exist!"});
            await _dbContext.Category.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return Ok(new ResponseModel {Code = 1, Message = "New Category Created Successfully."});
        }
    }
}