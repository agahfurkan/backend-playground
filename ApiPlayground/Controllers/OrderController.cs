using System.Threading.Tasks;
using ApiPlayground.Entities;
using ApiPlayground.Models;
using ApiPlayground.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPlayground.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _iOrderRepository;

        public OrderController(IOrderRepository iOrderRepository)
        {
            _iOrderRepository = iOrderRepository;
        }

        [HttpPost("CreateNewOrder")]
        public async Task<IActionResult> CreateNewOrder(OrderEntity newOrder)
        {
            //await _iOrderRepository.AddAsync();
            return Ok(new GenericResponseModel {IsSuccess = true, Message = "New Order Created Successfully!"});
        }
    }
}