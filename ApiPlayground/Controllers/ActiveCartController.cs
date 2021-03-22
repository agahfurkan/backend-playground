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
    public class ActiveCartController : ControllerBase
    {
        private readonly DbContextClass _dbContextClass;

        public ActiveCartController(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }

        [HttpPost("AddProductToCart")]
        public async Task<IActionResult> AddProductToCart(ActiveCart activeCart)
        {
            await _dbContextClass.ActiveCart.AddAsync(activeCart);
            await _dbContextClass.SaveChangesAsync();
            return Ok(new ResponseModel {Code = 1, Message = "Product Added to Cart Successfully"});
        }

        [HttpPost("RemoveProductFromCart")]
        public async Task<IActionResult> RemoveProductFromCart(ActiveCart activeCart)
        {
            var tempProduct =
                await _dbContextClass.ActiveCart.FirstOrDefaultAsync(
                    p => p.ProductId == activeCart.ProductId && p.UserId == activeCart.UserId);
            if (tempProduct == null) return Ok(new ResponseModel {Code = -1, Message = "Product Not Found!"});
            _dbContextClass.ActiveCart.Remove(tempProduct);
            await _dbContextClass.SaveChangesAsync();
            return Ok(new ResponseModel {Code = 1, Message = "Product Removed From Cart Successfully"});
        }
    }
}