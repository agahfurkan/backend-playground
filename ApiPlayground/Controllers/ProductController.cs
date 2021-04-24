using System.Collections.Generic;
using System.Linq;
using ApiPlayground.Entities;
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
        public List<Product> GetProducts([FromQuery] int categoryId)
        {
            var productList = _dbContextClass.Product.Where(product => product.CategoryId == categoryId);
            return productList.ToList();
        }
    }
}