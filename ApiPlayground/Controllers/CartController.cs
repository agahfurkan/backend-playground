using System.Collections.Generic;
using System.Linq;
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
    public class CartController : ControllerBase
    {
        private readonly DbContextClass _dbContextClass;

        public CartController(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }

        [HttpPost("AddProductToCart")]
        public async Task<IActionResult> AddProductToCart(Cart activeCart)
        {
            await _dbContextClass.ActiveCart.AddAsync(activeCart);
            await _dbContextClass.SaveChangesAsync();
            return Ok(new ResponseModel { Code = 1, Message = "Product Added to Cart Successfully" });
        }

        [HttpPost("RemoveProductFromCart")]
        public async Task<IActionResult> RemoveProductFromCart(Cart activeCart)
        {
            var tempProduct =
                await _dbContextClass.ActiveCart.FirstOrDefaultAsync(
                    p => p.ProductId == activeCart.ProductId && p.UserId == activeCart.UserId);
            if (tempProduct == null) return Ok(new ResponseModel { Code = -1, Message = "Product Not Found!" });
            _dbContextClass.ActiveCart.Remove(tempProduct);
            await _dbContextClass.SaveChangesAsync();
            return Ok(new ResponseModel { Code = 1, Message = "Product Removed From Cart Successfully" });
        }

        [HttpPost]
        [Route("getusercart")]
        public ActionResult<List<Cart>> GetUserCart(GetCartBody getCartBody)
        {
            var user = _dbContextClass.User.FirstOrDefault(u => u.Username == getCartBody.UserName);
            if (user == null)
            {
                return Ok(new ResponseModel { Code = -1, Message = "Invalid Username" });
            }
            return _dbContextClass.ActiveCart.Where(cart => cart.UserId == user.UserId).ToList();
        }
    }
}