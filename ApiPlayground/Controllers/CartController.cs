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
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _iCartRepository;
        private readonly IUserRepository _iUserRepository;

        public CartController(ICartRepository iCartRepository, IUserRepository iUserRepository)
        {
            _iCartRepository = iCartRepository;
            _iUserRepository = iUserRepository;
        }

        [HttpPost("AddProductToCart")]
        public async Task<ActionResult<GenericResponseModel>> AddProductToCart(AddProductToCartDto addProductToCartDto)
        {
            await _iCartRepository.AddAsync(new CartEntity
            {
                ProductId = addProductToCartDto.ProductId,
                UserId = addProductToCartDto.UserId,
                Discount = addProductToCartDto.Discount,
                Picture = addProductToCartDto.Picture,
                Price = addProductToCartDto.Price,
                ProductDescription = addProductToCartDto.ProductDescription,
                ProductName = addProductToCartDto.ProductName
            });
            return Ok(new GenericResponseModel {IsSuccess = true, Message = "Product Added to Cart Successfully"});
        }

        [HttpPost("RemoveProductFromCart")]
        public async Task<ActionResult<GenericResponseModel>> RemoveProductFromCart(
            RemoveProductFromCartDto removeProductFromCartDto)
        {
            var isSuccess = await _iCartRepository.RemoveProductFromCartAsync(removeProductFromCartDto.ProductId,
                removeProductFromCartDto.UserId);
            return Ok(new GenericResponseModel
            {
                IsSuccess = isSuccess,
                Message = isSuccess ? "Product Removed From Cart Successfully" : "Product Not Found!"
            });
        }

        [HttpPost("GetUserCart")]
        public async Task<ActionResult<GetUserCartResponse>> GetUserCart(int userId)
        {
            var user = _iUserRepository.GetAsync(userId);
            if (user == null) return Ok(new GenericResponseModel {IsSuccess = false, Message = "User Not Found"});
            var cartList = (await _iCartRepository.GetUserCartAsync(userId)).ConvertAll(c => new UserCart
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