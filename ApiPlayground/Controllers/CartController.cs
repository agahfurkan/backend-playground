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
    public class CartController : ControllerBase
    {
        private readonly DbContextClass _dbContextClass;

        public CartController(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }

        [HttpPost("AddProductToCart")]
        public async Task<ActionResult<GenericResponseModel>> AddProductToCart(AddProductToCartDto addProductToCartDto)
        {
            await _dbContextClass.ActiveCart.AddAsync(new CartEntity
            {
                ProductId = addProductToCartDto.ProductId,
                UserId = addProductToCartDto.UserId,
                Discount = addProductToCartDto.Discount,
                Picture = addProductToCartDto.Picture,
                Price = addProductToCartDto.Price,
                ProductDescription = addProductToCartDto.ProductDescription,
                ProductName = addProductToCartDto.ProductName
            });
            await _dbContextClass.SaveChangesAsync();
            return Ok(new GenericResponseModel {IsSuccess = true, Message = "Product Added to Cart Successfully"});
        }

        [HttpPost("RemoveProductFromCart")]
        public async Task<ActionResult<GenericResponseModel>> RemoveProductFromCart(
            RemoveProductFromCartDto removeProductFromCartDto)
        {
            var tempProduct =
                await _dbContextClass.ActiveCart.FirstOrDefaultAsync(
                    p => p.ProductId == removeProductFromCartDto.ProductId &&
                         p.UserId == removeProductFromCartDto.UserId);
            if (tempProduct == null)
                return Ok(new GenericResponseModel {IsSuccess = false, Message = "Product Not Found!"});
            _dbContextClass.ActiveCart.Remove(tempProduct);
            await _dbContextClass.SaveChangesAsync();
            return Ok(new GenericResponseModel {IsSuccess = true, Message = "Product Removed From Cart Successfully"});
        }

        [HttpPost("GetUserCart")]
        public ActionResult<GetUserCartResponse> GetUserCart(int userId)
        {
            var user = _dbContextClass.User.FirstOrDefault(u => u.UserId == userId);
            if (user == null) return Ok(new GenericResponseModel {IsSuccess = false, Message = "User Not Found"});
            var cartList = _dbContextClass.ActiveCart.Where(cart => cart.UserId == user.UserId).ToList()
                .ConvertAll(c => new UserCart
                {
                    CartId = c.Id,
                    ProductId = c.ProductId,
                    Discount = c.Discount,
                    Picture = c.Picture,
                    Price = c.Price,
                    ProductDescription = c.ProductDescription,
                    ProductName = c.ProductName
                });
            return new GetUserCartResponse {IsSuccess = true, CartList = cartList};
        }
    }
}