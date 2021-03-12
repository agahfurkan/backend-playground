using ApiPlayground.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPlayground.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : Controller
    {
        private DbContextClass _dbContextClass;

        public ProductController(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }

        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return _dbContextClass.Product.ToList();
        }

    }
}