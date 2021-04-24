using System.Linq;
using ApiPlayground.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPlayground.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly DbContextClass _dbContextClass;

        public ProductController(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }

        [HttpGet]
        [Route("GetProducts")]
        public ActionResult<GetProductsResponse> GetProducts([FromQuery] int categoryId)
        {
            var productList = _dbContextClass.Product.Where(product => product.CategoryId == categoryId).ToList()
                .ConvertAll(p => new Product
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
    }
}