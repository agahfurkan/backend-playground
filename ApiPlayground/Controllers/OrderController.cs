using System.Threading.Tasks;
using ApiPlayground.Entities;
using ApiPlayground.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPlayground.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly DbContextClass _dbContextClass;

        public OrderController(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }

        [HttpPost("createneworder")]
        public async Task<IActionResult> CreateNewOrder(Order newOrder)
        {
            await _dbContextClass.Order.AddAsync(newOrder);
            return Ok(new ResponseModel {Code = 1, Message = "New Order Created Successfully!"});
        }
    }
}