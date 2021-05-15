using System.Threading.Tasks;
using ApiPlayground.Models;
using ApiPlayground.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPlayground.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductRepository _iProductRepository;

        public ProductController(IProductRepository iProductRepository)
        {
            _iProductRepository = iProductRepository;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<ActionResult<GetProductsResponse>> GetProducts([FromQuery] int categoryId)
        {
            var productList = (await _iProductRepository.GetProductsByCategoryId(categoryId)).ConvertAll(p =>
                new Product
                {
                    CategoryId = p.CategoryId,
                    Discount = p.Discount,
                    Picture = p.Picture,
                    Price = p.Price,
                    ProductDescription = p.ProductDescription,
                    ProductId = p.ProductId,
                    ProductName = p.ProductName
                });
            return Ok(new GetProductsResponse {IsSuccess = true, ProductList = productList});
        }

        [HttpGet]
        [Route("GetProductDetail")]
        public async Task<ActionResult<GetProductDetailResponse>> GetProductDetail([FromQuery] int productId)
        {
            var p = await _iProductRepository.GetAsync(productId);
            if (p == null) return Ok(new GetProductsResponse {IsSuccess = false, Message = "No Product Found"});
            return Ok(new GetProductDetailResponse
            {
                IsSuccess = true,
                ProductDetail = new ProductDetail
                {
                    CategoryId = p.CategoryId,
                    Discount = p.Discount,
                    Picture = p.Picture,
                    Price = p.Price,
                    ProductDescription = p.ProductDescription,
                    ProductId = p.ProductId,
                    ProductName = p.ProductName
                }
            });
        }
    }
}