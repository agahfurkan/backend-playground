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

        [HttpPost("CreateNewOrder")]
        public async Task<IActionResult> CreateNewOrder(OrderEntity newOrder)
        {
            await _dbContextClass.Order.AddAsync(newOrder);
            return Ok(new GenericResponseModel {IsSuccess = true, Message = "New Order Created Successfully!"});
        }
    }
}